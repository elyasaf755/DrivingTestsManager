using BE;
using BL;
using DrivingTestsManagerV1._2.Main_Menu.Tester_Menu;
using DrivingTestsManagerV1._2.User_Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

using System.ComponentModel;

//ToDo: Add Tool Tips To Filter Fields
namespace DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu
{
    /// <summary>
    /// Interaction logic for TesterEditPage.xaml
    /// </summary>
    public partial class TesterEditPage : Page, INotifyPropertyChanged
    {
        //Event Handlers
        public event PropertyChangedEventHandler PropertyChanged;

        //Private Members
        private IBl m_Ibl = BLFactory.GetIBl();
        private MainWindow m_mainWin;
        private ObservableCollection<Tester> m_testersCollection = new ObservableCollection<Tester>();
        
        //Properties
        public ObservableCollection<Tester> TestersCollection
        {
            get
            {
                return m_testersCollection;
            }
            set
            {
                m_testersCollection = value;
                OnPropertyChanged("Collection");
            }
        }
        public List<Tester> TestersList { get; set; }
        public ICollectionView TestersCollectionView { get; set; }
        public ICollectionView GroupedTesters { get; set; }

        //Read Only Properties
        private bool IsGroupingEnabled { get { return IsGroupingEnabledCheckBox.IsChecked == true; } }

        //Constructors
        public TesterEditPage()
        {
            TestersCollection = new ObservableCollection<Tester>();
            InitializeComponent();
        }

        //Methods
        /// <summary>
        /// Will be called when the Collection property is changed
        /// </summary>
        /// <param name="property">Name of property</param>
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                //PropertyChangedEventArgs gets the *NAMES* of the properties.
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        private void UpdateCollection()
        {
            TestersCollection.Clear();
            foreach (Tester tester in TestersList)
            {
                TestersCollection.Add(tester);
            }
        }
        private void UpdateGroup()
        {
            if (GroupedTesters == null)
                return;

            ObservableCollection<GroupDescription> currentGroupDescription = GroupedTesters.GroupDescriptions;

            TestersCollectionView = CollectionViewSource.GetDefaultView(TestersList);
            GroupedTesters = new ListCollectionView(TestersList);

            foreach (GroupDescription gd in currentGroupDescription)
            {
                GroupedTesters.GroupDescriptions.Add(gd);
            }
        }
        private void CollectAll()
        {
            TestersCollection.Clear();
            TestersList = m_Ibl.GetAllTesters();
            UpdateCollection();
        }
        private void GroupAll()
        {
            TestersList = m_Ibl.GetAllTesters();
            TestersCollectionView = CollectionViewSource.GetDefaultView(TestersList);
            GroupedTesters = new ListCollectionView(TestersList);
        }
        private void FilterData()
        {
            TestersList = m_Ibl.GetAllTesters();

            if (GetId() != "")
            {
                TestersList = GetTestersById();
            }
            if (GetFirstName() != "")
            {
                TestersList = GetTestersByFirstName();
            }
            if (GetLastName() != "")
            {
                TestersList = GetTestersByLastName();
            }
            if (genderFilter.SelectedItem != null && GetGender() != GenderEnum.None)
            {
                TestersList = GetTestersByGender();
            }
            if (carTypeFilter.SelectedItem != null && GetCarType() != CarTypeEnum.None)
            {
                TestersList = GetTestersByCarType();
            }
            if (GetAge() != 0 && ageFilter.Text != "")
            {
                TestersList = GetTestersByAge();
            }
            if (GetYear() != 0 && yearFilter.Text != "")
            {
                TestersList = GetTestersByYear();
            }
            if (GetMonth() != 0 && monthFilter.Text != "")
            {
                TestersList = GetTestersByMonth();
            }
            if (GetDay() != 0 && dayFilter.Text != "")
            {
                TestersList = GetTestersByDay();
            }
            if (GetMaxDist() > 0 && maxDistFilter.Text != "")
            {
                TestersList = GetTestersByMaxDist();
            }
            if (weeklyTestsCountFilter.Text != "")
            {
                TestersList = GetTestersByWeeklyTestsCount();
            }
            if (maxWeeklyTestsFilter.Text != "")
            {
                TestersList = GetTestersByMaxWeeklyTests();
            }
            if (GetExperience() > 0 && experienceFilter.Text != "")
            {
                TestersList = GetTestersByExperience();
            }
            if (GetCity() != "")
            {
                TestersList = GetTestersByCity();
            }
            if (GetStreet() != "")
            {
                TestersList = GetTestersByStreet();
            }
            if (GetBuilding() != "")
            {
                TestersList = GetTestersByBuilding();
            }
            if (GetEmail() != "")
            {
                TestersList = GetTestersByEmail();
            }
            if (GetPhoneNumber() != "")
            {
                TestersList = GetTestersByPhoneNumber();
            }

            if (IsGroupingEnabled == true)
            {
                UpdateGroup();
                testerDataGrid.ItemsSource = GroupedTesters;
            }
            else
            {
                UpdateCollection();
                OnPropertyChanged("Collection");
                testerDataGrid.ItemsSource = TestersCollection;
            }
        }
        private void ClearFilters()
        {
            IdFilter.Text = "";
            firstNameFilter.Text = "";
            lastNameFilter.Text = "";
            genderFilter.ComboBox.SelectedItem = null;
            genderFilter.ComboBox.Text = "";
            ageFilter.Text = "";
            yearFilter.Text = "";
            monthFilter.Text = "";
            dayFilter.Text = "";
            cityFilter.Text = "";
            streetFilter.Text = "";
            buildingFilter.Text = "";
            carTypeFilter.ComboBox.SelectedItem = null;
            carTypeFilter.ComboBox.Text = "";
            emailAddressFilter.Text = "";
            phoneNumberFilter.Text = "";
            maxDistFilter.Text = "";
            experienceFilter.Text = "";
            weeklyTestsCountFilter.Text = "";
            maxWeeklyTestsFilter.Text = "";
        }
        private void DataGridSortAndGroupBehaviour(string headerName, ListSortDirection sortDirection)
        {
            switch (headerName)
            {
                case "First Name":
                    SortByFirstName(sortDirection);
                    GroupByFirstName();
                    break;
                case "Last Name":
                    SortByLastName(sortDirection);
                    GroupByLastName();
                    break;
                case "Age":
                    SortByAge(sortDirection);
                    GroupByAge();
                    break;
                case "Date Of Birth":
                    SortByDateOfBirth(sortDirection);
                    GroupByDateOfBirth();
                    break;
                case "Gender":
                    SortByGender(sortDirection);
                    GroupByGender();
                    break;
                case "Address":
                    SortByAddress(sortDirection);
                    GroupByAddress();
                    break;
                case "Car Type":
                    SortByCarType(sortDirection);
                    GroupByCarType();
                    break;
                case "Max. Dist.":
                    SortByMaxDistance(sortDirection);
                    GroupByMaxDistance();
                    break;
                case "Exp. (Years)":
                    SortByExperience(sortDirection);
                    GroupByExperience();
                    break;

                default:
                    testerDataGrid.ItemsSource = TestersCollection;
                    return;
            }

            testerDataGrid.ItemsSource = GroupedTesters;
        }
        private bool ShouldBeGrouped(string headerName)
        {
            switch (headerName)
            {
                case "First Name": return true;
                case "Last Name": return true;
                case "Age": return true;
                case "Date Of Birth": return true;
                case "Gender": return true;
                case "Address": return true;
                case "Car Type": return true;
                case "Max. Dist.": return true;
                case "Exp. (Years)": return true;
                default:
                    return false;
            }
        }

        //Filtering Methods
        private List<Tester> GetTestersById()
        {
            var result = from tester in TestersList
                         where tester.Id.Contains(GetId()) == true
                         select tester;

            return result.ToList();
        }
        private List<Tester> GetTestersByFirstName()
        {
            var result = from tester in TestersList
                         where tester.FirstName.ToLower().Contains(GetFirstName().ToLower()) == true
                         select tester;
            
            return result.ToList();
        }
        private List<Tester> GetTestersByLastName()
        {
            var result = from tester in TestersList
                         where tester.LastName.ToLower().Contains(GetLastName().ToLower()) == true
                         select tester;

            return result.ToList();
        }
        private List<Tester> GetTestersByGender()
        {
            var result = from tester in TestersList
                         where tester.Gender == GetGender()
                         select tester;

            return result.ToList();
        }
        private List<Tester> GetTestersByAge()
        {
            var result = from tester in TestersList
                         where tester.FullAge.Years == GetAge()
                         select tester;

            return result.ToList();
        }
        private List<Tester> GetTestersByYear()
        {
            var result = from tester in TestersList
                         where tester.DateOfBirth.Year == GetYear()
                         select tester;

            return result.ToList();
        }
        private List<Tester> GetTestersByMonth()
        {
            var result = from tester in TestersList
                         where tester.DateOfBirth.Month == GetMonth()
                         select tester;

            return result.ToList();
        }
        private List<Tester> GetTestersByDay()
        {
            var result = from tester in TestersList
                         where tester.DateOfBirth.Day == GetDay()
                         select tester;

            return result.ToList();
        }
        private List<Tester> GetTestersByCity()
        {
            var result = from tester in TestersList
                         where tester.Address.City.ToLower().Contains(GetCity().ToLower()) == true
                         select tester;

            return result.ToList();
        }
        private List<Tester> GetTestersByStreet()
        {
            var result = from tester in TestersList
                         where tester.Address.Street.ToLower().Contains(GetStreet().ToLower()) == true
                         select tester;

            return result.ToList();
        }
        private List<Tester> GetTestersByBuilding()
        {
            var result = from tester in TestersList
                         where tester.Address.Building.ToLower().Contains(GetBuilding().ToLower()) == true
                         select tester;

            return result.ToList();
        }
        private List<Tester> GetTestersByCarType()
        {
            var result = from tester in TestersList
                         where tester.CarType == GetCarType()
                         select tester;

            return result.ToList();
        }
        private List<Tester> GetTestersByEmail()
        {
            var result = from tester in TestersList
                         where tester.EmailAddress.Contains(GetEmail())
                         select tester;

            return result.ToList();
        }
        private List<Tester> GetTestersByPhoneNumber()
        {
            var result = from tester in TestersList
                         where tester.PhoneNumber.Contains(GetPhoneNumber())
                         select tester;

            return result.ToList();
        }
        private List<Tester> GetTestersByMaxDist()
        {
            var result = from tester in TestersList
                         where tester.MaximalDistance == GetMaxDist()
                         select tester;

            return result.ToList();
        }
        private List<Tester> GetTestersByExperience()
        {
            var result = from tester in TestersList
                         where tester.YearsOfExperience == GetExperience()
                         select tester;

            return result.ToList();
        }
        private List<Tester> GetTestersByWeeklyTestsCount()
        {
            var result = from tester in TestersList
                         where tester.WeeklyTestsCount == GetWeeklyTestsCount()
                         select tester;

            return result.ToList();
        }
        private List<Tester> GetTestersByMaxWeeklyTests()
        {
            var result = from tester in TestersList
                         where tester.MaximalWeeklyTests == GetMaxWeeklyTests()
                         select tester;

            return result.ToList();
        }
        
        //Getters For The Filters' Fields' Value
        private string GetId()
        {
            return IdFilter.Text;
        }
        private string GetFirstName()
        {
            return firstNameFilter.Text;
        }
        private string GetLastName()
        {
            return lastNameFilter.Text;
        }
        private GenderEnum GetGender()
        {
            return Utilities.ConvertStringToGenderEnum(genderFilter.SelectedItem.ToString());
        }
        private int GetAge()
        {
            int temp;

            int.TryParse(ageFilter.Text, out temp);

            return temp;
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
        private string GetCity()
        {
            return cityFilter.Text;
        }
        private string GetStreet()
        {
            return streetFilter.Text;
        }
        private string GetBuilding()
        {
            return buildingFilter.Text;
        }
        private CarTypeEnum GetCarType()
        {
            return Utilities.ConvertStringToCarTypeEnum(carTypeFilter.SelectedItem.ToString());
        }
        private string GetEmail()
        {
            return emailAddressFilter.Text;

        }
        private string GetPhoneNumber()
        {
            return phoneNumberFilter.Text;
        }
        private int GetMaxDist()
        {
            int temp;

            int.TryParse(maxDistFilter.Text, out temp);
            
            return temp;
        }
        private int GetExperience()
        {
            int temp;
            int.TryParse(experienceFilter.Text, out temp);
            return temp;
        }
        private int GetWeeklyTestsCount()
        {
            int temp;

            int.TryParse(weeklyTestsCountFilter.Text, out temp);

            return temp;
        }
        private int GetMaxWeeklyTests()
        {
            int temp;

            int.TryParse(maxWeeklyTestsFilter.Text, out temp);

            return temp;
        }
        
        //Sorting
        private void SortByFirstName(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TestersList = TestersList.OrderBy(tester => tester.FirstName).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TestersList = TestersList.OrderByDescending(tester => tester.FirstName).ToList();
            }
            else
            {
                TestersList = TestersList.OrderBy(tester => tester.FirstName).ToList();
            }
        }
        private void SortByLastName(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TestersList = TestersList.OrderBy(tester => tester.LastName).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TestersList = TestersList.OrderByDescending(tester => tester.LastName).ToList();
            }
            else
            {
                TestersList = TestersList.OrderBy(tester => tester.LastName).ToList();
            }
        }
        private void SortByAge(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TestersList = TestersList.OrderBy(tester => tester.Age).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TestersList = TestersList.OrderByDescending(tester => tester.Age).ToList();
            }
            else
            {
                TestersList = TestersList.OrderBy(tester => tester.Age).ToList();
            }
        }
        private void SortByDateOfBirth(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TestersList = TestersList.OrderBy(tester => tester.DateOfBirth).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TestersList = TestersList.OrderByDescending(tester => tester.DateOfBirth).ToList();
            }
            else
            {
                TestersList = TestersList.OrderBy(tester => tester.DateOfBirth).ToList();
            }
        }
        private void SortByGender(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TestersList = TestersList.OrderBy(tester => tester.Gender).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TestersList = TestersList.OrderByDescending(tester => tester.Gender).ToList();
            }
            else
            {
                TestersList = TestersList.OrderBy(tester => tester.Gender).ToList();
            }
        }
        private void SortByAddress(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TestersList = TestersList.OrderBy(tester => tester.Address).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TestersList = TestersList.OrderByDescending(tester => tester.Address).ToList();
            }
            else
            {
                TestersList = TestersList.OrderBy(tester => tester.Address).ToList();
            }
        }
        private void SortByCarType(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TestersList = TestersList.OrderBy(tester => tester.CarType).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TestersList = TestersList.OrderByDescending(tester => tester.CarType).ToList();
            }
            else
            {
                TestersList = TestersList.OrderBy(tester => tester.CarType).ToList();
            }
        }
        private void SortByMaxDistance(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TestersList = TestersList.OrderBy(tester => tester.MaximalDistance).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TestersList = TestersList.OrderByDescending(tester => tester.MaximalDistance).ToList();
            }
            else
            {
                TestersList = TestersList.OrderBy(tester => tester.MaximalDistance).ToList();
            }
        }
        private void SortByExperience(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TestersList = TestersList.OrderBy(tester => tester.YearsOfExperience).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TestersList = TestersList.OrderByDescending(tester => tester.YearsOfExperience).ToList();
            }
            else
            {
                TestersList = TestersList.OrderBy(tester => tester.YearsOfExperience).ToList();
            }
        }

        //Grouping
        private void GroupByFirstName()
        {
            TestersCollectionView = CollectionViewSource.GetDefaultView(TestersList);
            GroupedTesters = new ListCollectionView(TestersList);
            GroupedTesters.GroupDescriptions.Add(new PropertyGroupDescription("FirstName"));
        }
        private void GroupByLastName()
        {
            TestersCollectionView = CollectionViewSource.GetDefaultView(TestersList);
            GroupedTesters = new ListCollectionView(TestersList);
            GroupedTesters.GroupDescriptions.Add(new PropertyGroupDescription("LastName"));
        }
        private void GroupByAge()
        {
            TestersCollectionView = CollectionViewSource.GetDefaultView(TestersList);
            GroupedTesters = new ListCollectionView(TestersList);
            GroupedTesters.GroupDescriptions.Add(new PropertyGroupDescription("Age"));
        }
        private void GroupByDateOfBirth()
        {
            TestersCollectionView = CollectionViewSource.GetDefaultView(TestersList);
            GroupedTesters = new ListCollectionView(TestersList);
            GroupedTesters.GroupDescriptions.Add(new PropertyGroupDescription("Year"));
            GroupedTesters.GroupDescriptions.Add(new PropertyGroupDescription("Month"));
        }
        private void GroupByGender()
        {
            TestersCollectionView = CollectionViewSource.GetDefaultView(TestersList);
            GroupedTesters = new ListCollectionView(TestersList);
            GroupedTesters.GroupDescriptions.Add(new PropertyGroupDescription("Gender"));
        }
        private void GroupByAddress()
        {
            TestersCollectionView = CollectionViewSource.GetDefaultView(TestersList);
            GroupedTesters = new ListCollectionView(TestersList);
            GroupedTesters.GroupDescriptions.Add(new PropertyGroupDescription("City"));
            GroupedTesters.GroupDescriptions.Add(new PropertyGroupDescription("Street"));
        }
        private void GroupByCarType()
        {
            TestersCollectionView = CollectionViewSource.GetDefaultView(TestersList);
            GroupedTesters = new ListCollectionView(TestersList);
            GroupedTesters.GroupDescriptions.Add(new PropertyGroupDescription("CarType"));
        }
        private void GroupByMaxDistance()
        {
            TestersCollectionView = CollectionViewSource.GetDefaultView(TestersList);
            GroupedTesters = new ListCollectionView(TestersList);
            GroupedTesters.GroupDescriptions.Add(new PropertyGroupDescription("MaximalDistance"));
        }
        private void GroupByExperience()
        {
            TestersCollectionView = CollectionViewSource.GetDefaultView(TestersList);
            GroupedTesters = new ListCollectionView(TestersList);
            GroupedTesters.GroupDescriptions.Add(new PropertyGroupDescription("YearsOfExperience"));
        }

        //Events
        private void MyTesterEditPage_Loaded(object sender, RoutedEventArgs e)
        {
            m_mainWin = UIFactory.GetMainWin();

            TestersCollection.Clear();
            TestersList = m_Ibl.GetAllTesters();
            UpdateCollection();

            genderFilter.ComboBox.ItemsSource = typeof(GenderEnum).GetEnumValues();
            carTypeFilter.ComboBox.ItemsSource = typeof(CarTypeEnum).GetEnumValues();
        }
        private void TesterDataGrid_Sorting(object sender, DataGridSortingEventArgs e)
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

        //Click Events
        private void ClearFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFilters();
        }

        //Filters' Value Changed Events
        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterData();
        }
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterData();
        }

        //Context Menu Items' Events
        private void AddCmi_Clicked(object sender, RoutedEventArgs e)
        {
            m_mainWin.MainFrame.Content = new TesterAddPage();
        }
        private void EditCmi_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (testerDataGrid.SelectedItem != null)
                {
                    m_mainWin.MainFrame.Content = new TesterAddPage(testerDataGrid.SelectedItem as Tester);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void RemoveCmi_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (testerDataGrid.SelectedItem != null)
                {
                    Tester tester = testerDataGrid.SelectedItem as Tester;

                    if (tester != null)
                    {
                        MessageBoxResult result = MessageBox.Show("Are you sure you want to delete tester " +
                                                               tester.Id + "?", "Warning", MessageBoxButton.OKCancel,
                                                               MessageBoxImage.Warning);

                        if (result == MessageBoxResult.OK)
                        {
                            m_Ibl.DeleteTester(testerDataGrid.SelectedItem as Tester);
                            CollectAll();
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }
            
        }
        private void WorkTimeCmi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (testerDataGrid.SelectedItem != null)
                {
                    Tester tester = testerDataGrid.SelectedItem as Tester;

                    WorkTimeWindow temp = new WorkTimeWindow(tester);
                    temp.IsReadOnly = true;
                    temp.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Grouping Check Box Events
        private void IsGroupingEnabledCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GroupAll();
            testerDataGrid.ItemsSource = GroupedTesters;
        }
        private void IsGroupingEnabledCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CollectAll();
            testerDataGrid.ItemsSource = TestersCollection;
        }
        
        //ToDo: CHECK FOR DEL
        #region Filters
        private void FilterByAge(int age)
        {
            var testers = from tester in TestersList
                          where tester.FullAge.Years == age
                          select tester;

            testerDataGrid.ItemsSource = testers;
        }
        private void FilterByFirstName(string firstName)
        {
            var testers = from tester in TestersList
                          where tester.FirstName == firstName
                          select tester;

            testerDataGrid.ItemsSource = testers;
        }
        private void FilterByLastName(string lastName)
        {
            var testers = from tester in TestersList
                          where tester.LastName == lastName
                          select tester;

            testerDataGrid.ItemsSource = testers;
        }
        private void FilterByCarType(CarTypeEnum carType)
        {
            var testers = from tester in TestersList
                          where tester.CarType == carType
                          select tester;

            testerDataGrid.ItemsSource = testers;
        }
        private void FilterByGender(GenderEnum gender)
        {
            var testers = from tester in TestersList
                          where tester.Gender == gender
                          select tester;

            testerDataGrid.ItemsSource = testers;
        }
        private void FilterByMaxDistance(int maxDist)
        {
            var testers = from tester in TestersList
                          where tester.MaximalDistance == maxDist
                          select tester;

            testerDataGrid.ItemsSource = testers;
        }
        private void FilterByMaxWeeklyTests(int maxTests)
        {
            var testers = from tester in TestersList
                          where tester.MaximalWeeklyTests == maxTests
                          select tester;

            testerDataGrid.ItemsSource = testers;
        }
        private void FilterByExperience(int experience)
        {
            var testers = from tester in TestersList
                          where tester.YearsOfExperience == experience
                          select tester;

            testerDataGrid.ItemsSource = testers;
        }
        private void FilterByTests(int tests)
        {
            var testers = from tester in TestersList
                          where tester.WeeklyTestsCount == tests
                          select tester;

            testerDataGrid.ItemsSource = testers;
        }
        #endregion
    }
}
