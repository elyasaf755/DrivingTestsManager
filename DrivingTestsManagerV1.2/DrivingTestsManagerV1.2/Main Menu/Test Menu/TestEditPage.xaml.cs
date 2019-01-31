using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrivingTestsManagerV1._2.Main_Menu.Test_Menu
{
    /// <summary>
    /// Interaction logic for TestEditPage.xaml
    /// </summary>
    public partial class TestEditPage : Page
    {
        //Private Fields
        private MainWindow m_mainWin = UIFactory.GetMainWin();
        private IBl m_Ibl = BLFactory.GetIBl();

        //Properties
        public List<Test> TestsList { get; set; } = new List<Test>();
        public ObservableCollection<Test> TestsCollection { get; set; } = new ObservableCollection<Test>();
        public ICollectionView TestsCollectionView { get; private set; }
        public ICollectionView GroupedTests { get; private set; }

        //Read Only Properties
        private bool IsGroupingEnabled { get { return IsGroupingEnabledCheckBox.IsChecked == true; } }

        //Constructoors
        public TestEditPage()
        {
            TestsList = m_Ibl.GetAllTests();
            UpdateCollection();
            InitializeComponent();
        }

        //Methods
        private void UpdateCollection()
        {
            TestsCollection.Clear();

            foreach(Test test in TestsList)
            {
                TestsCollection.Add(test);
            }
        }
        private void UpdateGroup()
        {
            if (GroupedTests == null)
                return;

            ObservableCollection<GroupDescription> currentGroupDescription = GroupedTests.GroupDescriptions;

            TestsCollectionView = CollectionViewSource.GetDefaultView(TestsList);
            GroupedTests = new ListCollectionView(TestsList);

            foreach (GroupDescription gd in currentGroupDescription)
            {
                GroupedTests.GroupDescriptions.Add(gd);
            }
        }
        private void CollectAll()
        {
            TestsCollection.Clear();
            TestsList = m_Ibl.GetAllTests();
            UpdateCollection();
        }
        private void GroupAll()
        {
            TestsList = m_Ibl.GetAllTests();
            TestsCollectionView = CollectionViewSource.GetDefaultView(TestsList);
            GroupedTests = new ListCollectionView(TestsList);
        }
        private void GroupById()
        {
            IEnumerable<IGrouping<string, Test>> query = from test in TestsList
                                                         group test by test.TesterId;
            TestsList = new List<Test>();
            foreach (var group in query)
            {
                foreach (Test test in group)
                {
                    //testDataGrid.Items.Add(test);
                }
            }
            UpdateCollection();
        }
        private void ClearFilters()
        {
            testIdFilter.Text = "";
            testerIdFilter.Text = "";
            traineeIdFilter.Text = "";

            yearFilter.Text = "";
            monthFilter.Text = "";
            dayFilter.Text = "";
            hourFilter.Text = "";

            cityFilter.Text = "";
            streetFilter.Text = "";
            
            carTypeFilter.ComboBox.SelectedItem = null;
            carTypeFilter.ComboBox.Text = "";

            isPassedFilter.IsChecked = null;
            
            drivingSchoolCityFilter.ComboBox.SelectedItem = null;
            drivingSchoolCityFilter.Text = "";
            drivingSchoolNameFilter.ComboBox.SelectedItem = null;
            drivingSchoolNameFilter.Text = "";

            DMVFilter.ComboBox.SelectedItem = null;
            DMVFilter.Text = "";
        }
        private void FilterData()
        {
            TestsList = m_Ibl.GetAllTests();

            if (GetTestId() != "")
            {
                TestsList = GetTestsByTestId();
            }
            if (GetTesterId() != "")
            {
                TestsList = GetTestsByTesterId();
            }
            if (GetTraineeId() != "")
            {
                TestsList = GetTestsByTraineeId();
            }
            if (GetDay() !=0)
            {
                TestsList = GetTestsByDay();
            }
            if (GetMonth() != 0)
            {
                TestsList = GetTestsByMonth();
            }
            if (GetYear() != 0)
            {
                TestsList = GetTestsByYear();
            }
            if (GetHour() != 0)
            {
                TestsList = GetTestsByHour();
            }
            if (GetCity() != "" && GetCity() != null)
            {
                TestsList = GetTestsByCity();
            }
            if (GetStreet() != "" && GetStreet() != null)
            {
                TestsList = GetTestsByStreet();
            }
            if (carTypeFilter.SelectedItem != null && GetCarType() != CarTypeEnum.None)
            {
                TestsList = GetTestsByCarType();
            }
            if (GetIsPassed() != null)
            {
                TestsList = GetTestsByIsPassed();
            }
            if (GetSchoolCity() != "" && GetSchoolCity() != null)
            {
                TestsList = GetTestsBySchoolCity();
            }
            if (GetSchoolName() != "" && GetSchoolName() != null)
            {
                TestsList = GetTestsBySchoolName();
            }
            if (GetDmv() != "" && GetDmv() != null)
            {
                TestsList = GetTestsByDmv();
            }


            if (IsGroupingEnabled == true)
            {
                UpdateGroup();
                testDataGrid.ItemsSource = GroupedTests;
            }
            else
            {
                UpdateCollection();
                testDataGrid.ItemsSource = TestsCollection;
            }
        }
        private void DataGridSortAndGroupBehaviour(string headerName, ListSortDirection sortDirection)
        {
            switch (headerName)
            {
                case "Test's Date":
                    SortByTestDate(sortDirection);
                    GroupByTestDate();
                    break;
                case "Test's Location":
                    SortByTestLocation(sortDirection);
                    GroupByTestLocation();
                    break;
                case "Trainee's Id":
                    SortByTraineeId(sortDirection);
                    GroupByTraineeId();
                    break;
                case "Is Passed?":
                    SortByIsPassed(sortDirection);
                    GroupByIsPassed();
                    break;
                case "Tester's Id":
                    SortByTesterId(sortDirection);
                    GroupByTesterId();
                    break;
                default:
                    testDataGrid.ItemsSource = TestsCollection;
                    return;
            }

            testDataGrid.ItemsSource = GroupedTests;
        }
        private bool ShouldBeGrouped(string headerName)
        {
            switch (headerName)
            {
                case "Test's Date": return true;
                case "Test's Location": return true;
                case "Trainee's Id": return true;
                case "Is Passed?": return true;
                case "Tester's Id": return true;
                default:
                    return false;
            }
        }

        //Getters For The Filters' Fields' Value
        private string GetTestId()
        {
            return testIdFilter.Text;
        }
        private string GetTraineeId()
        {
            return traineeIdFilter.Text;
        }
        private string GetTesterId()
        {
            return testerIdFilter.Text;
        }
        private int GetYear()
        {
            int temp;

            int.TryParse(yearFilter.Text, out temp);

            return temp;
        }
        private int GetMonth()
        {
            int temp;

            int.TryParse(monthFilter.Text, out temp);

            return temp;
        }
        private int GetDay()
        {
            int temp;

            int.TryParse(dayFilter.Text, out temp);

            return temp;
        }
        private int GetHour()
        {
            int temp;

            int.TryParse(hourFilter.Text, out temp);

            return temp;
        }
        private string GetCity()
        {
            if (cityFilter.SelectedItem == null)
            {
                return null;
            }

            return cityFilter.SelectedItem.ToString();
        }
        private string GetStreet()
        {
            if (streetFilter.SelectedItem == null)
            {
                return null;
            }

            return streetFilter.SelectedItem.ToString();
        }
        private CarTypeEnum GetCarType()
        {
            if (carTypeFilter.SelectedItem == null)
            {
                return CarTypeEnum.None;
            }

            return Utilities.ConvertStringToCarTypeEnum(carTypeFilter.SelectedItem.ToString());
        }
        private bool? GetIsPassed()
        {
            return isPassedFilter.IsChecked;
        }
        private string GetSchoolCity()
        {
            if (drivingSchoolCityFilter.SelectedItem == null)
            {
                return null;
            }

            return drivingSchoolCityFilter.SelectedItem.ToString();
        }
        private string GetSchoolName()
        {
            if (drivingSchoolNameFilter.SelectedItem == null)
            {
                return null;
            }

            return drivingSchoolNameFilter.SelectedItem.ToString();
        }
        private string GetDmv()
        {
            if (DMVFilter.SelectedItem == null)
            {
                return null;
            }

            return DMVFilter.SelectedItem.ToString();
        }

        //Filtering Methods
        private List<Test> GetTestsByTestId()
        {
            var result = from test in TestsList
                         where test.TestIdStringFormat.Contains(GetTestId()) == true
                         select test;

            return result.ToList();
        }
        private List<Test> GetTestsByTesterId()
        {
            var result = from test in TestsList
                         where test.TesterId.Contains(GetTesterId()) == true
                         select test;

            return result.ToList();
        }
        private List<Test> GetTestsByTraineeId()
        {
            var result = from test in TestsList
                         where test.TraineeId.Contains(GetTraineeId()) == true
                         select test;

            return result.ToList();
        }
        private List<Test> GetTestsByDay()
        {
            var result = from test in TestsList
                         where test.TestDateAndTime.Day == GetDay()
                         select test;

            return result.ToList();
        }
        private List<Test> GetTestsByMonth()
        {
            var result = from test in TestsList
                         where test.TestDateAndTime.Month == GetMonth()
                         select test;

            return result.ToList();
        }
        private List<Test> GetTestsByYear()
        {
            var result = from test in TestsList
                         where test.TestDateAndTime.Year == GetYear()
                         select test;

            return result.ToList();
        }
        private List<Test> GetTestsByHour()
        {
            var result = from test in TestsList
                         where test.TestDateAndTime.Hour == GetHour()
                         select test;

            return result.ToList();
        }
        private List<Test> GetTestsByCity()
        {
            var result = from test in TestsList
                         where test.TestLocation.City == GetCity()
                         select test;

            return result.ToList();
        }
        private List<Test> GetTestsByStreet()
        {
            var result = from test in TestsList
                         where test.TestLocation.Street == GetStreet()
                         select test;

            return result.ToList();
        }
        private List<Test> GetTestsByCarType()
        {
            var result = from test in TestsList
                         where test.CarType == GetCarType()
                         select test;

            return result.ToList();
        }
        private List<Test> GetTestsByIsPassed()
        {
            var result = from test in TestsList
                         where test.IsPassed == GetIsPassed()
                         select test;

            return result.ToList();
        }
        private List<Test> GetTestsBySchoolCity()
        {
            var result = from test in TestsList
                         where test.DrivingSchool.City == GetSchoolCity()
                         select test;

            return result.ToList();
        }
        private List<Test> GetTestsBySchoolName()
        {
            var result = from test in TestsList
                         where test.DrivingSchool.Name == GetSchoolName()
                         select test;

            return result.ToList();
        }
        private List<Test> GetTestsByDmv()
        {
            var result = from test in TestsList
                         where test.DMV == GetDmv()
                         select test;

            return result.ToList();
        }

        //Grouping
        private void GroupByTestDate()
        {
            TestsCollectionView = CollectionViewSource.GetDefaultView(TestsList);
            GroupedTests = new ListCollectionView(TestsList);
            GroupedTests.GroupDescriptions.Add(new PropertyGroupDescription("TestYear"));
            GroupedTests.GroupDescriptions.Add(new PropertyGroupDescription("TestMonth"));
        }
        private void GroupByTestLocation()
        {
            TestsCollectionView = CollectionViewSource.GetDefaultView(TestsList);
            GroupedTests = new ListCollectionView(TestsList);
            GroupedTests.GroupDescriptions.Add(new PropertyGroupDescription("TestCity"));
            GroupedTests.GroupDescriptions.Add(new PropertyGroupDescription("TestStreet"));
        }
        private void GroupByTraineeId()
        {
            TestsCollectionView = CollectionViewSource.GetDefaultView(TestsList);
            GroupedTests = new ListCollectionView(TestsList);
            GroupedTests.GroupDescriptions.Add(new PropertyGroupDescription("TraineeId"));
        }
        private void GroupByIsPassed()
        {
            TestsCollectionView = CollectionViewSource.GetDefaultView(TestsList);
            GroupedTests = new ListCollectionView(TestsList);
            GroupedTests.GroupDescriptions.Add(new PropertyGroupDescription("IsPassed"));
        }
        private void GroupByTesterId()
        {
            TestsCollectionView = CollectionViewSource.GetDefaultView(TestsList);
            GroupedTests = new ListCollectionView(TestsList);
            GroupedTests.GroupDescriptions.Add(new PropertyGroupDescription("TesterId"));
        }


        //Sorting
        private void SortByTraineeId(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Descending)
            {
                TestsList = TestsList.OrderByDescending(test => test.TraineeId).ToList();
            }
            else
            {
                TestsList = TestsList.OrderBy(test => test.TraineeId).ToList();
            }
        }
        private void SortByTestDate(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Descending)
            {
                TestsList = TestsList.OrderByDescending(test => test.TestDateAndTime).ToList();
            }
            else
            {
                TestsList = TestsList.OrderBy(test => test.TestDateAndTime).ToList();
            }
        }
        private void SortByTestLocation(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Descending)
            {
                TestsList = TestsList.OrderByDescending(test => test.TestLocation).ToList();
            }
            else
            {
                TestsList = TestsList.OrderBy(test => test.TestLocation).ToList();
            }
        }
        private void SortByIsPassed(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Descending)
            {
                TestsList = TestsList.OrderByDescending(test => test.IsPassed).ToList();
            }
            else
            {
                TestsList = TestsList.OrderBy(test => test.IsPassed).ToList();
            }
        }
        private void SortByTesterId(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Descending)
            {
                TestsList = TestsList.OrderByDescending(test => test.TesterId).ToList();
            }
            else
            {
                TestsList = TestsList.OrderBy(test => test.TesterId).ToList();
            }
        }

        //Events
        private void TestDataGrid_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (testDataGrid.SelectedItem != null)
            {
                Test test = testDataGrid.SelectedItem as Test;

                if (test != null)
                {
                    if (test.IsPassed != null)
                    {
                        EditCmi.IsEnabled = false;
                    }
                    else
                    {
                        EditCmi.IsEnabled = true;
                    }
                }
            }
        }

        //Loaded Events
        private void MyTestEditPage_Loaded(object sender, RoutedEventArgs e)
        {
            TestsList = m_Ibl.GetAllTests();

            DMVFilter.ComboBox.ItemsSource = null;
            DMVFilter.ComboBox.Items.Clear();
            DMVFilter.ComboBox.ItemsSource = m_Ibl.GetAllDMVs();

            carTypeFilter.ComboBox.ItemsSource = typeof(CarTypeEnum).GetEnumValues();
            cityFilter.ComboBox.ItemsSource = m_Ibl.GetAllCitiesStringFormat();
            drivingSchoolCityFilter.ComboBox.ItemsSource = m_Ibl.GetAllDrivingSchoolsCitiesStringFormat();
        }
        private void TestDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            TesterNotesCmi.IsEnabled = false;
        }

        //Click Events
        private void EditCmi_Click(object sender, RoutedEventArgs e)
        {
            Test test = testDataGrid.SelectedItem as Test;

            AddTestResultsWin win = new AddTestResultsWin(test);
            win.ShowDialog();
        }
        private void TesterNotesCmi_Click(object sender, RoutedEventArgs e)
        {
            Test test = testDataGrid.SelectedItem as Test;

            if (test == null)
            {
                return;
            }



            MessageBox.Show(test.TesterNotes);
        }
        
        //Changed Events
        private void TestDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Test test = testDataGrid.SelectedItem as Test;

            if (test == null)
            {
                TesterNotesCmi.IsEnabled = false;
                return;
            }

            if (test.TesterNotes == "")
            {
                TesterNotesCmi.IsEnabled = false;
            }
            else
            {
                TesterNotesCmi.IsEnabled = true;
            }
        }
        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterData();
        }
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterData();
        }
        private void IsPassedFilter_Changed(object sender, RoutedEventArgs e)
        {
            FilterData();
        }

        //Drop Down Events
        private void DrivingSchoolCityFilter_DropDownOpened(object sender, EventArgs e)
        {
            drivingSchoolCityFilter.IsDropDownOpen = false;
        }
        private void DrivingSchoolNameFilter_DropDownOpened(object sender, EventArgs e)
        {
            drivingSchoolNameFilter.IsDropDownOpen = false;
        }
        private void CityFilter_DropDownOpened(object sender, EventArgs e)
        {
            cityFilter.IsDropDownOpen = false;
        }
        private void StreetFilter_DropDownOpened(object sender, EventArgs e)
        {
            streetFilter.IsDropDownOpen = false;
        }

        //Checked Events
        private void IsGroupingEnabledCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GroupAll();
            testDataGrid.ItemsSource = GroupedTests;
        }
        private void IsGroupingEnabledCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CollectAll();
            testDataGrid.ItemsSource = TestsCollection;
        }

        private void TestDataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            if (IsGroupingEnabledCheckBox.IsChecked == false)
                return;

            var column = e.Column;
            var headerName = column.Header.ToString();

            if (ShouldBeGrouped(headerName) == false)
                return;

            e.Handled = true;

            var sortDirection = column.SortDirection == ListSortDirection.Ascending ?
                ListSortDirection.Descending : ListSortDirection.Ascending;

            DataGridSortAndGroupBehaviour(headerName, sortDirection);

            ListCollectionView source = (sender as System.Windows.Controls.DataGrid).ItemsSource as ListCollectionView;
            if (source == null)
                return;

            column.SortDirection = sortDirection;
            source.Refresh();
        }

        private void ClearFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFilters();
        }
    }
}
