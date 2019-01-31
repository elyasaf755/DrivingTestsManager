using BE;
using BL;
using DrivingTestsManagerV1._2.User_Controls;
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

//ToDo: Add Combobox for owned lisences in data grid (solution in eliezer's file?)
//ToDo: Add Tool Tips To Filter Fields
namespace DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu
{
    /// <summary>
    /// Interaction logic for TraineeEditPage.xaml
    /// </summary>
    public partial class TraineeEditPage : Page
    {
        //Event Handlers
        public event PropertyChangedEventHandler PropertyChanged;

        //Private Members
        private IBl m_Ibl = BLFactory.GetIBl();
        private MainWindow m_mainWin;
        private ObservableCollection<Trainee> m_traineesCollection = new ObservableCollection<Trainee>();

        //Properties
        public ObservableCollection<Trainee> TraineesCollection
        {
            get
            {
                return m_traineesCollection;
            }
            set
            {
                m_traineesCollection = value;
                OnPropertyChanged("Collection");
            }
        }
        public List<Trainee> TraineesList { get; set; }
        private ICollectionView TraineesCollectionView { get; set; }
        private ICollectionView GroupedTrainees { get; set; }
        
        //Read Only Properties
        private bool IsGroupingEnabled { get { return IsGroupingEnabledCheckBox.IsChecked == true; } }

        //Constructors
        public TraineeEditPage()
        {
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
            TraineesCollection.Clear();
            foreach (Trainee trainee in TraineesList)
            {
                TraineesCollection.Add(trainee);
            }
        }
        private void UpdateGroup()
        {
            if (GroupedTrainees == null)
                return;

            ObservableCollection<GroupDescription> currentGroupDescription = GroupedTrainees.GroupDescriptions;

            TraineesCollectionView = CollectionViewSource.GetDefaultView(TraineesList);
            GroupedTrainees = new ListCollectionView(TraineesList);

            foreach (GroupDescription gd in currentGroupDescription)
            {
                GroupedTrainees.GroupDescriptions.Add(gd);
            }
        }
        private void CollectAll()
        {
            TraineesCollection.Clear();
            TraineesList = m_Ibl.GetAllTrainees();
            UpdateCollection();
        }
        private void GroupAll()
        {
            TraineesList = m_Ibl.GetAllTrainees();
            TraineesCollectionView = CollectionViewSource.GetDefaultView(TraineesList);
            GroupedTrainees = new ListCollectionView(TraineesList);
        }
        private void FilterData()
        {
            TraineesList = m_Ibl.GetAllTrainees();

            if (GetId() != "")
            {
                TraineesList = GetTraineesById();
            }
            if (GetFirstName() != "")
            {
                TraineesList = GetTraineesByFirstName();
            }
            if (GetLastName() != "")
            {
                TraineesList = GetTraineesByLastName();
            }
            if (genderFilter.SelectedItem != null && GetGender() != GenderEnum.None)
            {
                TraineesList = GetTraineesByGender();
            }
            if (carTypeFilter.SelectedItem != null && GetCarType() != CarTypeEnum.None)
            {
                TraineesList = GetTraineesByCarType();
            }
            if (gearTypeFilter.SelectedItem != null && GetGearType() != GearTypeEnum.None)
            {
                TraineesList = GetTraineesByGearType();
            }
            if (GetAge() != 0 && ageFilter.Text != "")
            {
                TraineesList = GetTraineesByAge();
            }
            if (GetYear() != 0 && yearFilter.Text != "")
            {
                TraineesList = GetTraineesByYear();
            }
            if (GetMonth() != 0 && monthFilter.Text != "")
            {
                TraineesList = GetTraineesByMonth();
            }
            if (GetDay() != 0 && dayFilter.Text != "")
            {
                TraineesList = GetTraineesByDay();
            }
            if (GetEmail() != "")
            {
                TraineesList = GetTraineesByEmail();
            }
            if (drivingSchoolNameFilter.Text != "")
            {
                TraineesList = GetTraineesByDrivingSchoolsNames();
            }
            if (GetCity() != "")
            {
                TraineesList = GetTraineesByCity();
            }
            if (GetStreet() != "")
            {
                TraineesList = GetTraineesByStreet();
            }
            if (GetBuilding() != "")
            {
                TraineesList = GetTraineesByBuilding();
            }
            if (GetDaysPassed() != 0 && daysPassedFilter.Text != "")
            {
                TraineesList = GetTraineesByDaysPassed();
            }
            if (GetDrivingTeacher() != "")
            {
                TraineesList = GetTraineesByDrivingTeacher();
            }
            if (GetDrivingSchoolCity() != "")
            {
                TraineesList = GetTraineesByDrivingSchoolsCities();
            }
            if (GetPhoneNumber() != "")
            {
                TraineesList = GetTraineesByPhoneNumber();
            }

            if (IsGroupingEnabled == true)
            {
                UpdateGroup();
                traineeDataGrid.ItemsSource = GroupedTrainees;
            }
            else
            {
                UpdateCollection();
                OnPropertyChanged("Collection");
                traineeDataGrid.ItemsSource = TraineesCollection;
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
            gearTypeFilter.ComboBox.SelectedItem = null;
            gearTypeFilter.ComboBox.Text = "";
            emailAddressFilter.Text = "";
            phoneNumberFilter.Text = "";
            drivingTeacherFilter.Text = "";
            drivingSchoolCityFilter.Text = "";
            drivingSchoolNameFilter.Text = "";
            daysPassedFilter.Text = "";
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
                case "Gear Type":
                    SortByGearType(sortDirection);
                    GroupByGearType();
                    break;
                case "Date Of Last Test":
                    SortByDateOfLastTest(sortDirection);
                    GroupByDateOfLastTest();
                    break;
                case "Days Passed":
                    SortByDaysPassed(sortDirection);
                    GroupByDaysPassed();
                    break;
                case "D.School City":
                    SortByDrivingSchoolCity(sortDirection);
                    GroupByDrivingSchoolCity();
                    break;
                case "D.School Name":
                    SortByDrivingSchoolName(sortDirection);
                    GroupByDrivingSchoolName();
                    break;
                case "Driving Teacher":
                    SortByDrivingSchoolTeacher(sortDirection);
                    GroupByDrivingSchoolTeacher();
                    break;

                default:
                    traineeDataGrid.ItemsSource = TraineesCollection;
                    return;
            }

            traineeDataGrid.ItemsSource = GroupedTrainees;
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
                case "Gear Type": return true;
                case "Date Of Last Test": return true;
                case "Days Passed": return true;
                case "D.School City": return true;
                case "D.School Name": return true;
                case "Driving Teacher": return true;

                default:
                    return false;
            }
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
        private CarTypeEnum GetCarType()
        {
            return Utilities.ConvertStringToCarTypeEnum(carTypeFilter.SelectedItem.ToString());
        }
        private GearTypeEnum GetGearType()
        {
            return Utilities.ConvertStringToGearTypeEnum(gearTypeFilter.SelectedItem.ToString());
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
        private string GetEmail()
        {
            return emailAddressFilter.Text;
        }
        private DrivingSchool GetDrivingSchool()
        {
            return new DrivingSchool()
            {
                City = GetDrivingSchoolCity(),
                Name = GetDrivingSchoolName(),
                CarTypes = new CarTypeEnum[5]//ToDo: Get Real Car Types & Search for "new CarTypeEnum" in the entire solution
            };
        }
        private string GetDrivingSchoolCity()
        {
            return drivingSchoolCityFilter.Text;
        }
        private string GetDrivingSchoolName()
        {
            return drivingSchoolNameFilter.Text;
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
        private int GetDaysPassed()
        {
            int temp;

            int.TryParse(daysPassedFilter.Text, out temp);

            return temp;
        }
        private string GetDrivingTeacher()
        {
            return drivingTeacherFilter.Text;
        }
        private string GetPhoneNumber()
        {
            return phoneNumberFilter.Text;
        }

        //Filtering Methods
        private List<Trainee> GetTraineesById()
        {
            var result = from trainee in TraineesList
                         where trainee.Id.Contains(GetId()) == true
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByFirstName()
        {
            var result = from trainee in TraineesList
                         where trainee.FirstName.ToLower().Contains(GetFirstName().ToLower()) == true
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByLastName()
        {
            var result = from trainee in TraineesList
                         where trainee.LastName.ToLower().Contains(GetLastName().ToLower()) == true
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByGender()
        {
            var result = from trainee in TraineesList
                         where trainee.Gender == GetGender()
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByCarType()
        {
            var result = from trainee in TraineesList
                         where trainee.CarType == GetCarType()
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByGearType()
        {
            var result = from trainee in TraineesList
                         where trainee.GearType == GetGearType()
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByAge()
        {
            var result = from trainee in TraineesList
                         where trainee.FullAge.Years == GetAge()
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByYear()
        {
            var result = from trainee in TraineesList
                         where trainee.DateOfBirth.Year == GetYear()
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByMonth()
        {
            var result = from trainee in TraineesList
                         where trainee.DateOfBirth.Month == GetMonth()
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByDay()
        {
            var result = from trainee in TraineesList
                         where trainee.DateOfBirth.Day == GetDay()
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByEmail()
        {
            var result = from trainee in TraineesList
                         where trainee.EmailAddress.ToLower().Contains(GetEmail().ToLower())
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByDrivingSchoolsNames()
        {
            var result = from trainee in TraineesList
                         where trainee.FullDrivingSchoolDetails.Name.ToString().ToLower().Contains(GetDrivingSchoolName().ToString().ToLower()) == true
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByDrivingSchoolsCities()
        {
            var result = from trainee in TraineesList
                         where trainee.FullDrivingSchoolDetails.ToString().ToLower().Contains(GetDrivingSchoolCity().ToString().ToLower()) == true
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByDrivingTeacher()
        {
            var result = from trainee in TraineesList
                         where trainee.DrivingSchoolTeacher.ToLower().Contains(GetDrivingTeacher().ToLower()) == true
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByCity()
        {
            var result = from trainee in TraineesList
                         where trainee.Address.City.ToLower().Contains(GetCity().ToLower()) == true
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByStreet()
        {
            var result = from trainee in TraineesList
                         where trainee.Address.Street.ToLower().Contains(GetStreet().ToLower()) == true
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByBuilding()
        {
            var result = from trainee in TraineesList
                         where trainee.Address.Building.ToLower().Contains(GetBuilding().ToLower()) == true
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByDaysPassed()
        {
            var result = from trainee in TraineesList
                         where trainee.DaysPassedSinceLastTest == GetDaysPassed()
                         select trainee;

            return result.ToList();
        }
        private List<Trainee> GetTraineesByPhoneNumber()
        {
            var result = from trainee in TraineesList
                         where trainee.PhoneNumber.Contains(GetPhoneNumber()) == true
                         select trainee;

            return result.ToList();
        }

        //Sorting
        private void SortByFirstName(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.FirstName).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TraineesList = TraineesList.OrderByDescending(trainee => trainee.FirstName).ToList();
            }
            else
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.FirstName).ToList();
            }
        }
        private void SortByLastName(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.LastName).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TraineesList = TraineesList.OrderByDescending(trainee => trainee.LastName).ToList();
            }
            else
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.LastName).ToList();
            }
        }
        private void SortByAge(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.Age).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TraineesList = TraineesList.OrderByDescending(trainee => trainee.Age).ToList();
            }
            else
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.Age).ToList();
            }
        }
        private void SortByDateOfBirth(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.DateOfBirth).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TraineesList = TraineesList.OrderByDescending(trainee => trainee.DateOfBirth).ToList();
            }
            else
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.DateOfBirth).ToList();
            }
        }
        private void SortByGender(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.Gender).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TraineesList = TraineesList.OrderByDescending(trainee => trainee.Gender).ToList();
            }
            else
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.Gender).ToList();
            }
        }
        private void SortByAddress(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.Address).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TraineesList = TraineesList.OrderByDescending(trainee => trainee.Address).ToList();
            }
            else
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.Address).ToList();
            }
        }
        private void SortByCarType(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.CarType).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TraineesList = TraineesList.OrderByDescending(trainee => trainee.CarType).ToList();
            }
            else
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.CarType).ToList();
            }
        }
        private void SortByGearType(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.GearType).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TraineesList = TraineesList.OrderByDescending(trainee => trainee.GearType).ToList();
            }
            else
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.GearType).ToList();
            }
        }
        private void SortByDateOfLastTest(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.DateOfLastTest).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TraineesList = TraineesList.OrderByDescending(trainee => trainee.DateOfLastTest).ToList();
            }
            else
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.DateOfLastTest).ToList();
            }
        }
        private void SortByDaysPassed(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.DaysPassedSinceLastTest).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TraineesList = TraineesList.OrderByDescending(trainee => trainee.DaysPassedSinceLastTest).ToList();
            }
            else
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.DaysPassedSinceLastTest).ToList();
            }
        }
        private void SortByDrivingSchoolCity(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.DrivingSchoolCity).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TraineesList = TraineesList.OrderByDescending(trainee => trainee.DrivingSchoolCity).ToList();
            }
            else
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.DrivingSchoolCity).ToList();
            }
        }
        private void SortByDrivingSchoolName(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.DrivingSchoolName).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TraineesList = TraineesList.OrderByDescending(trainee => trainee.DrivingSchoolName).ToList();
            }
            else
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.DrivingSchoolName).ToList();
            }
        }
        private void SortByDrivingSchoolTeacher(ListSortDirection? direction)
        {
            if (direction == ListSortDirection.Ascending)
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.DrivingSchoolTeacher).ToList();
            }
            else if (direction == ListSortDirection.Descending)
            {
                TraineesList = TraineesList.OrderByDescending(trainee => trainee.DrivingSchoolTeacher).ToList();
            }
            else
            {
                TraineesList = TraineesList.OrderBy(trainee => trainee.DrivingSchoolTeacher).ToList();
            }
        }

        //Grouping
        private void GroupByFirstName()
        {
            TraineesCollectionView = CollectionViewSource.GetDefaultView(TraineesList);
            GroupedTrainees = new ListCollectionView(TraineesList);
            GroupedTrainees.GroupDescriptions.Add(new PropertyGroupDescription("FirstName"));
        }
        private void GroupByLastName()
        {
            TraineesCollectionView = CollectionViewSource.GetDefaultView(TraineesList);
            GroupedTrainees = new ListCollectionView(TraineesList);
            GroupedTrainees.GroupDescriptions.Add(new PropertyGroupDescription("LastName"));
        }
        private void GroupByAge()
        {
            TraineesCollectionView = CollectionViewSource.GetDefaultView(TraineesList);
            GroupedTrainees = new ListCollectionView(TraineesList);
            GroupedTrainees.GroupDescriptions.Add(new PropertyGroupDescription("Age"));
        }
        private void GroupByDateOfBirth()
        {
            TraineesCollectionView = CollectionViewSource.GetDefaultView(TraineesList);
            GroupedTrainees = new ListCollectionView(TraineesList);
            GroupedTrainees.GroupDescriptions.Add(new PropertyGroupDescription("Year"));
            GroupedTrainees.GroupDescriptions.Add(new PropertyGroupDescription("Month"));
        }
        private void GroupByGender()
        {
            TraineesCollectionView = CollectionViewSource.GetDefaultView(TraineesList);
            GroupedTrainees = new ListCollectionView(TraineesList);
            GroupedTrainees.GroupDescriptions.Add(new PropertyGroupDescription("Gender"));
        }
        private void GroupByAddress()
        {
            TraineesCollectionView = CollectionViewSource.GetDefaultView(TraineesList);
            GroupedTrainees = new ListCollectionView(TraineesList);
            GroupedTrainees.GroupDescriptions.Add(new PropertyGroupDescription("City"));
            GroupedTrainees.GroupDescriptions.Add(new PropertyGroupDescription("Street"));
        }
        private void GroupByCarType()
        {
            TraineesCollectionView = CollectionViewSource.GetDefaultView(TraineesList);
            GroupedTrainees = new ListCollectionView(TraineesList);
            GroupedTrainees.GroupDescriptions.Add(new PropertyGroupDescription("CarType"));
        }
        private void GroupByGearType()
        {
            TraineesCollectionView = CollectionViewSource.GetDefaultView(TraineesList);
            GroupedTrainees = new ListCollectionView(TraineesList);
            GroupedTrainees.GroupDescriptions.Add(new PropertyGroupDescription("GearType"));
        }
        private void GroupByDateOfLastTest()
        {
            TraineesCollectionView = CollectionViewSource.GetDefaultView(TraineesList);
            GroupedTrainees = new ListCollectionView(TraineesList);
            GroupedTrainees.GroupDescriptions.Add(new PropertyGroupDescription("DateOfLastTest"));
        }
        private void GroupByDaysPassed()
        {
            TraineesCollectionView = CollectionViewSource.GetDefaultView(TraineesList);
            GroupedTrainees = new ListCollectionView(TraineesList);
            GroupedTrainees.GroupDescriptions.Add(new PropertyGroupDescription("DaysPassedSinceLastTest"));
        }
        private void GroupByDrivingSchoolCity()
        {
            TraineesCollectionView = CollectionViewSource.GetDefaultView(TraineesList);
            GroupedTrainees = new ListCollectionView(TraineesList);
            GroupedTrainees.GroupDescriptions.Add(new PropertyGroupDescription("DrivingSchoolCity"));
        }
        private void GroupByDrivingSchoolName()
        {
            TraineesCollectionView = CollectionViewSource.GetDefaultView(TraineesList);
            GroupedTrainees = new ListCollectionView(TraineesList);
            GroupedTrainees.GroupDescriptions.Add(new PropertyGroupDescription("DrivingSchoolName"));
        }
        private void GroupByDrivingSchoolTeacher()
        {
            TraineesCollectionView = CollectionViewSource.GetDefaultView(TraineesList);
            GroupedTrainees = new ListCollectionView(TraineesList);
            GroupedTrainees.GroupDescriptions.Add(new PropertyGroupDescription("DrivingSchoolTeacher"));
        }
        
        //Events
        private void MyTraineeEditPage_Loaded(object sender, RoutedEventArgs e)
        {
            m_mainWin = UIFactory.GetMainWin();

            TraineesCollection.Clear();
            TraineesList = m_Ibl.GetAllTrainees();
            UpdateCollection();

            genderFilter.ComboBox.ItemsSource = typeof(GenderEnum).GetEnumValues();
            carTypeFilter.ComboBox.ItemsSource = typeof(CarTypeEnum).GetEnumValues();
            gearTypeFilter.ComboBox.ItemsSource = typeof(GearTypeEnum).GetEnumValues();
        }
        private void TraineeDataGrid_Sorting(object sender, DataGridSortingEventArgs e)
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
            m_mainWin.MainFrame.Content = new TraineeAddPage();
        }
        private void EditCmi_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (traineeDataGrid.SelectedItem != null)
                {
                    m_mainWin.MainFrame.Content = new TraineeAddPage(traineeDataGrid.SelectedItem as Trainee);
                }
            }
            catch (Exception)
            {

            }
            
        }
        private void RemoveCmi_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (traineeDataGrid.SelectedItem != null)
                {
                    Trainee trainee = traineeDataGrid.SelectedItem as Trainee;

                    if (trainee != null)
                    {
                        MessageBoxResult result = MessageBox.Show("Are you sure you want to delete trainee " +
                                                               trainee.Id + "?", "Warning", MessageBoxButton.OKCancel,
                                                               MessageBoxImage.Warning);

                        if (result == MessageBoxResult.OK)
                        {
                            m_Ibl.DeleteTrainee(traineeDataGrid.SelectedItem as Trainee);
                            CollectAll();
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            
        }

        //Grouping Check Box Events
        private void IsGroupingEnabledCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GroupAll();
            traineeDataGrid.ItemsSource = GroupedTrainees;
        }
        private void IsGroupingEnabledCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CollectAll();
            traineeDataGrid.ItemsSource = TraineesCollection;
        }
    }
}
