using BE;
using BL;
using DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu;
using DrivingTestsManagerV1._2.Main_Menu.Tester_Menu;
using DrivingTestsManagerV1._2.User_Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using Xceed.Wpf.Toolkit;

namespace DrivingTestsManagerV1._2.Main_Menu.Tester_Menu
{
    /// <summary>
    /// Interaction logic for TesterAddPage.xaml
    /// </summary>
    public partial class TesterAddPage : Page
    {
        //Private Members
        private IBl m_Ibl = BLFactory.GetIBl();
        private PageMode m_pageMode;
        private Tester m_targetTester = new Tester();//Target tester to be edited if PageMode is "Edit"

        //Properties
        public int ValidatorsCount { get; }
        public int ValidFieldsCount { get; set; }

        //Constructors
        public TesterAddPage()
        {
            InitializeComponent();

            m_pageMode = PageMode.Add;
            SendButton.Content = "Add";
            RefillButton.Visibility = Visibility.Hidden;

            int validatorsCount = 0;
            int validFieldsCount = 0;
            GetValidatorsInfo(ref validatorsCount, ref validFieldsCount);
            ValidatorsCount = validatorsCount;
            ValidFieldsCount = validFieldsCount;

        }
        public TesterAddPage(Tester tester)
        {
            InitializeComponent();

            m_pageMode = PageMode.Edit;
            m_targetTester = tester;

            RefillButton.Visibility = Visibility.Visible;

            int validatorsCount = 0;
            int validFieldsCount = 0;
            GetValidatorsInfo(ref validatorsCount, ref validFieldsCount);
            ValidatorsCount = validatorsCount;
            ValidFieldsCount = validFieldsCount;

            FillForm(tester);
            SendButton.Content = "Apply";
        }

        //Methods
        /// <summary>
        /// Returns a tester instance with properties' values according to the fields in the page
        /// </summary>
        /// <returns></returns>
        private Tester GetTester()
        {
            return new Tester(GetId(),         GetLastName(),       GetFirstName(), GetBirthDate(),
                              GetGender(),     GetPhoneNumber(),    GetAddress(),   GetEmail(),
                              GetExperience(), GetMaxWeeklyTests(), GetCarType(),
                              GetWorkTime(),   GetMaxDistance(), 0, new List<ScheduleStruct>());
        }
        private void FillForm()
        {
            IdTb.Text = "308478098";
            FirstNameTb.Text = "Elyasaf";
            LastNameTb.Text = "Elbaz";
            GenderCb.ComboBox.SelectedItem = GenderEnum.Male;
            CityCb.ComboBox.ItemsSource = null;
            CityCb.ComboBox.Items.Clear();
            CityCb.ComboBox.ItemsSource = m_Ibl.GetAllCitiesStringFormat();
            CityCb.ComboBox.SelectedItem = "בית אל";
            StreetCb.ComboBox.SelectedItem = "סופה";
            BuildingTb.Text = "4";
            PhoneNumberTb.Text = "0546401267";
            EmailTb.Text = "elyasaf755@gmail.com";
            CarTypeCb.ComboBox.SelectedItem = CarTypeEnum.Private;
            MaximalDistance.Value = 120;
            Experience.Value = 3;
            MaxWeeklyTests.Value = 1;
            BirthDateDp.DatePicker.Text = "10/27/1962";
            WorkTimeExpander.IsExpanded = true;

        }
        private void FillForm(Tester tester)
        {
            IdTb.Text = tester.Id;
            FirstNameTb.Text = tester.FirstName;
            LastNameTb.Text = tester.LastName;
            GenderCb.ComboBox.SelectedItem = tester.Gender;
            CityCb.ComboBox.ItemsSource = null;
            CityCb.ComboBox.Items.Clear();
            CityCb.ComboBox.ItemsSource = m_Ibl.GetAllCitiesStringFormat();
            CityCb.ComboBox.SelectedItem = tester.Address.City;
            StreetCb.IsFullyLoaded = false;
            StreetCb.ComboBox.ItemsSource = null;
            StreetCb.ComboBox.Items.Clear();
            StreetCb.ComboBox.ItemsSource = m_Ibl.GetStreetsOfCity(CityCb.SelectedItem.ToString());
            StreetCb.ComboBox.SelectedItem = tester.Address.Street;
            BuildingTb.Text = tester.Address.Building;
            PhoneNumberTb.Text = tester.PhoneNumber;
            EmailTb.Text = tester.EmailAddress;
            CarTypeCb.ComboBox.SelectedItem = tester.CarType;
            MaximalDistance.Value = tester.MaximalDistance;
            Experience.Value = tester.YearsOfExperience;
            MaxWeeklyTests.Value = tester.MaximalWeeklyTests;
            BirthDateDp.DatePicker.SelectedDate = Utilities.ConvertToDateTime(tester.DateOfBirth);
            BirthDateDp.DatePicker.Text = Utilities.ConvertToDateTime(tester.DateOfBirth).ToString();
            WorkTimeExpander.IsExpanded = true;
            
            bool[,] temp = (bool[,])tester.WorkTime.Clone();


            MyWorkTime.MyWorkTimeTable.SetTable(temp);

            ValidateWorkTime();

            ValidateValidators();
        }
        private void ClearForm()
        {
            IdTb.Text = "";
            FirstNameTb.Text = "";
            LastNameTb.Text = "";
            GenderCb.ComboBox.SelectedItem = null;
            CityCb.ComboBox.ItemsSource = null;
            CityCb.ComboBox.Items.Clear();
            CityCb.ComboBox.SelectedItem = "";
            StreetCb.ComboBox.ItemsSource = null;
            StreetCb.ComboBox.Items.Clear();
            StreetCb.ComboBox.SelectedItem = "";
            BuildingTb.Text = "";
            PhoneNumberTb.Text = "";
            EmailTb.Text = "";
            CarTypeCb.ComboBox.SelectedItem = null;
            MaximalDistance.Value = null;
            Experience.Value = null;
            MaxWeeklyTests.Value = null;
            BirthDateDp.DatePicker.SelectedDate = null;
            BirthDateDp.DatePicker.Text = "";
            MyWorkTime.ClearTable();
            WorkTimeExpander.IsExpanded = false;
            HideAllValidators();

        }

        //Getters For Fields' Values
        private string GetId()
        {
            return IdTb.Text;
        }
        private string GetFirstName()
        {
            return FirstNameTb.Text;
        }
        private string GetLastName()
        {
            return LastNameTb.Text;
        }
        private MyDate GetBirthDate()
        {
            return Utilities.ConvertToMyDate(BirthDateDp.SelectedDate.Value);
        }
        private GenderEnum GetGender()
        {
            //ToDo: Clean Up
            switch (GenderCb.SelectedItem.ToString())
            {
                case "Female": return GenderEnum.Female;
                case "Male":   return GenderEnum.Male;
                default:       return GenderEnum.None;
            }
        }
        private string GetPhoneNumber()
        {
            return PhoneNumberTb.Text;
        }
        private AddressStruct GetAddress()
        {
            return new AddressStruct(CityCb.SelectedItem.ToString(),
                                     StreetCb.SelectedItem.ToString(),
                                     BuildingTb.Text);
        }
        private string GetEmail()
        {
            return EmailTb.Text;
        }
        private int GetExperience()
        {
            return (int)Experience.Value;
        }
        private int GetMaxWeeklyTests()
        {
            return (int)MaxWeeklyTests.Value;
        }
        private CarTypeEnum GetCarType()
        {
            //ToDo: Clean Up
            switch (CarTypeCb.SelectedItem.ToString())
            {
                case "Private":    return CarTypeEnum.Private;
                case "Truck":      return CarTypeEnum.Truck;
                case "Bus":        return CarTypeEnum.Bus;
                case "Motorcycle": return CarTypeEnum.Motorcycle;
                case "Tractor":    return CarTypeEnum.Tractor;
                default:           return CarTypeEnum.None;
            }
        }
        private bool[,] GetWorkTime()
        {
            return MyWorkTime.WorkTime;
        }
        private int GetMaxDistance()
        {
            return (int)MaximalDistance.Value;
        }
        
        //Helper Methods
        private void LoseAllHinttableTextBoxesFocus()
        {
            foreach (Control item in TesterAddPageMainGrid.Children)
            {
                if (item is HinttableTextBox)
                {
                    HinttableTextBox hinttableTb = item as HinttableTextBox;

                    hinttableTb.LoseFocus(hinttableTb);
                }
            }
        }
        private void LoseAllDatePickersFocus()
        {
            foreach (Control item in TesterAddPageMainGrid.Children)
            {
                if (item is HinttableDatePicker)
                {
                    HinttableDatePicker hinttableDp = item as HinttableDatePicker;

                    hinttableDp.LoseFocus(hinttableDp);
                }
            }
        }
        private void HideAllValidators()
        {
            foreach (Control control in TesterAddPageMainGrid.Children)
            {
                if (control is CircleValidator)
                {
                    CircleValidator validator = control as CircleValidator;
                    validator.Visibility = Visibility.Hidden;
                }
                else if (control is HinttableTextBox)
                {
                    HinttableTextBox htb = control as HinttableTextBox;
                    htb.Validator.Visibility = Visibility.Hidden;
                }
                else if (control is HinttableComboBox)
                {
                    HinttableComboBox hcb = control as HinttableComboBox;
                    hcb.Validator.Visibility = Visibility.Hidden;
                }
                else if (control is HinttableDatePicker)
                {
                    HinttableDatePicker hdp = control as HinttableDatePicker;
                    hdp.Validator.Visibility = Visibility.Hidden;
                }
            }
        }
        /// <summary>
        /// Returns the total number of validators in the page, and the current valid ones.
        /// </summary>
        /// <param name="validatorsCount">Number of total validators in the page</param>
        /// <param name="greenValidatorsCount">Number of valid fields in the page</param>
        private void GetValidatorsInfo(ref int validatorsCount, ref int greenValidatorsCount)
        {
            validatorsCount = 0;
            greenValidatorsCount = 0;

            foreach (Control control in TesterAddPageMainGrid.Children)
            {
                if (control is CircleValidator)
                {
                    ++validatorsCount;
                    CircleValidator validator = control as CircleValidator;
                    if (validator.MyCircle.Foreground == Brushes.Green)
                    {
                        ++greenValidatorsCount;
                    }
                }
                else if (control is HinttableTextBox)
                {
                    ++validatorsCount;
                    HinttableTextBox htb = control as HinttableTextBox;
                    if (htb.Validator.MyCircle.Foreground == Brushes.Green)
                    {
                        ++greenValidatorsCount;
                    }
                }
                else if (control is HinttableComboBox)
                {
                    ++validatorsCount;
                    HinttableComboBox hcb = control as HinttableComboBox;
                    if (hcb.Validator.MyCircle.Foreground == Brushes.Green)
                    {
                        ++greenValidatorsCount;
                    }
                }
                else if (control is HinttableDatePicker)
                {
                    ++validatorsCount;
                    HinttableDatePicker hdp = control as HinttableDatePicker;
                    if (hdp.Validator.MyCircle.Foreground == Brushes.Green)
                    {
                        ++greenValidatorsCount;
                    }
                }
            }
        }
        /// <summary>
        /// Will enable the send button if all fields are valid
        /// </summary>
        private void ValidateValidators()
        {
            int validatorsCount = 0;
            int greenValidatorsCount = 0;

            GetValidatorsInfo(ref validatorsCount, ref greenValidatorsCount);

            if (validatorsCount == greenValidatorsCount)
            {
                SendButton.IsEnabled = true;
            }
            else
            {
                SendButton.IsEnabled = false;
            }

            ValidFieldsCount = greenValidatorsCount;
            ProgressBar.Value = (double)ValidFieldsCount;

        }
        private void ValidateWorkTime()
        {
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 7; ++j)
                {
                    if (MyWorkTime.WorkTime[i, j] == true)
                    {
                        WorkHoursValidator.Validate(true);
                        WorkHoursValidator.ToolTip = "Good";
                        ValidateValidators();
                        return;
                    }
                }
            }
        }
        private void LoadCityComboBox(List<string> cities)
        {
            CityCb.ComboBox.ItemsSource = null;
            CityCb.ComboBox.Items.Clear();

            Task.Run(() =>
            {
                int i = 0;
                foreach (string city in cities)
                {
                    Dispatcher.Invoke(() =>
                    {
                        CityCb.ComboBox.Items.Add(city);
                    });
                    ++i;
                    if (i % 20 == 0)
                    {
                        Thread.Sleep(10);
                    }
                }
            }).ContinueWith((task) =>
            {
                CityBusyIndicator.IsBusy = false;
            }, TaskScheduler.FromCurrentSynchronizationContext()
            );
        }
        private void LoadStreetComboBox(List<string> streets)
        {
            StreetCb.ComboBox.Items.Clear();
            CityCb.IsEnabled = false;
            Task.Run(() =>
            {
                int i = 0;
                foreach (string street in streets)
                {
                    Dispatcher.Invoke(() =>
                    {
                        //ToDo: Check for del
                        if (StreetCb.IsDropDownOpen == false)
                        {
                            //StreetCb.IsDropDownOpen = true;
                        }
                        StreetCb.ComboBox.Items.Add(street);
                    });
                    ++i;
                    if (i % 20 == 0)
                    {
                        Thread.Sleep(25);
                    }
                }
            }).ContinueWith((task) =>
            {
                StreetBusyIndicator.IsBusy = false;
                CityCb.IsEnabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext()
            );
        }

        //Events
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Tester> list = m_Ibl.GetAllTesters();

            //Initilize ComboBoxes
            GenderCb.ComboBox.ItemsSource = typeof(GenderEnum).GetEnumValues();
            CarTypeCb.ComboBox.ItemsSource = typeof(CarTypeEnum).GetEnumValues();
            CityCb.ComboBox.ItemsSource = m_Ibl.GetAllCitiesStringFormat();

            ProgressBar.Maximum = ValidatorsCount;

            //ToDo: Demo mode
            if (Configuration.IsDemoModeEnabled == true)
            {
                FillButton.Visibility = Visibility.Visible;
                FillButton.IsEnabled = true;
            }
        }

        //Fields' Value Changed Events
        private void IdTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IdTb.Validator == null)
            {
                return;
            }

            IdTb.Validator.Visibility = Visibility.Visible;

            if (IdTb.IsHintVisible == true || IdTb.Text == "")
            {
                IdTb.Validator.Validate(false);
                IdTb.Validator.ToolTip = "Id field can't be empty";
            }
            else
            {
                IdTb.Validator.Validate(BlValidations.IsIdFormatValid(IdTb.Text));

                if (BlValidations.IsIdFormatValid(IdTb.Text) == false)
                {
                    IdTb.Validator.ToolTip = "Id format isn't valid";
                }
                else
                {
                    IdTb.Validator.ToolTip = "Good";
                }
            }

            ValidateValidators();
        }
        private void FirstNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FirstNameTb.Validator == null)
            {
                return;
            }

            FirstNameTb.Validator.Visibility = Visibility.Visible;
            
            if (FirstNameTb.IsHintVisible == true || FirstNameTb.Text == "")
            {
                FirstNameTb.Validator.Validate(false);
                FirstNameTb.Validator.ToolTip = "First name field can't be empty";
            }
            else
            {
                FirstNameTb.Validator.Validate(BlValidations.IsNameFormatValid(FirstNameTb.Text));

                if (BlValidations.IsNameFormatValid(FirstNameTb.Text) == false)
                {
                    FirstNameTb.Validator.ToolTip = "First name must contain only letters";
                }
                else
                {
                    FirstNameTb.Validator.ToolTip = "Good";
                }
            }

            ValidateValidators();
        }
        private void LastNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LastNameTb.Validator == null)
            {
                return;
            }

            LastNameTb.Validator.Visibility = Visibility.Visible;

            if (LastNameTb.IsHintVisible == true || LastNameTb.Text == "")
            {
                LastNameTb.Validator.Validate(false);
                LastNameTb.Validator.ToolTip = "Last name field can't be empty";
            }
            else
            {
                LastNameTb.Validator.Validate(BlValidations.IsNameFormatValid(LastNameTb.Text));

                if (BlValidations.IsNameFormatValid(LastNameTb.Text) == false)
                {
                    LastNameTb.Validator.ToolTip = "Last name must contain only letters";
                }
                else
                {
                    LastNameTb.Validator.ToolTip = "Good";
                }
            }

            

            ValidateValidators();
        }
        private void GenderCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GenderCb.Validator == null)
            {
                return;
            }

            GenderCb.Validator.Visibility = Visibility.Visible;

            if (GenderCb.SelectedItem == null || GenderCb.SelectedItem.ToString() == "None")
            {
                GenderCb.Validator.Validate(false);
                GenderCb.Validator.ToolTip = "You must select a gender.";
            }
            else
            {
                GenderCb.Validator.Validate(true);
                GenderCb.Validator.ToolTip = "Good";
            }

            ValidateValidators();
        }
        private void CityCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CityCb.Validator == null)
            {
                return;
            }

            if (CityCb.IsHintVisible == true)
            {
                CityCb.Validator.Validate(false);
                CityCb.Validator.ToolTip = "You must select a city";
            }
            else
            {
                CityCb.Validator.Validate(true);
                CityCb.Validator.ToolTip = "Good";
            }

            if (CityCb.SelectedItem == null)
            {
                CityCb.Validator.Validate(false);
                CityCb.Validator.ToolTip = "You must select a city";
                ValidateValidators();
                StreetCb.IsEnabled = false;
                return;
            }
            else
            {
                StreetCb.IsEnabled = true;
            }

            try
            {
                if (m_Ibl.GetStreetsOfCity(CityCb.SelectedItem.ToString()) == null)
                {
                    throw new Exception();
                }
                else
                {
                    StreetCb.IsFullyLoaded = false;
                    StreetCb.ComboBox.ItemsSource = null;
                    StreetCb.ComboBox.Items.Clear();
                    StreetCb.ComboBox.ItemsSource = m_Ibl.GetStreetsOfCity(CityCb.SelectedItem.ToString());
                }
            }
            catch (Exception)
            {

            }

            CityCb.Validator.Visibility = Visibility.Visible;

            ValidateValidators();
        }
        private void StreetCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StreetCb.Validator == null)
            {
                return;
            }

            if (StreetCb.IsHintVisible == true)
            {
                StreetCb.Validator.Validate(false);
                StreetCb.Validator.ToolTip = "You must select a street";
            }
            else
            {
                StreetCb.Validator.Validate(true);
                StreetCb.Validator.ToolTip = "Good";
            }

            if (StreetCb.SelectedItem == null)
            {
                StreetCb.Validator.Validate(false);
                StreetCb.Validator.ToolTip = "You must select a street";
                ValidateValidators();
                return;
            }

            StreetCb.Validator.Visibility = Visibility.Visible;

            if (StreetCb.SelectedItem.ToString() == "None")
            {
                StreetCb.Validator.Validate(false);
                StreetCb.Validator.ToolTip = "You must select a street";
            }
            else
            {
                StreetCb.Validator.Validate(true);
                StreetCb.Validator.ToolTip = "Good";
            }

            ValidateValidators();
        }
        private void BuildingTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (BuildingTb.Validator == null)
            {
                return;
            }

            BuildingTb.Validator.Visibility = Visibility.Visible;

            if (BuildingTb.IsHintVisible == true || BuildingTb.Text == "")
            {
                BuildingTb.Validator.Validate(false);
                BuildingTb.Validator.ToolTip = "You must select a building";
            }
            else
            {
                BuildingTb.Validator.Validate(true);
                BuildingTb.Validator.ToolTip = "Good";
            }

            ValidateValidators();
        }
        private void PhoneNumberTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PhoneNumberTb.Validator == null)
            {
                return;
            }

            PhoneNumberTb.Validator.Visibility = System.Windows.Visibility.Visible;
            PhoneNumberTb.Validator.Validate(BlValidations.IsPhoneNumberFormatValid(PhoneNumberTb.Text));

            //ToolTip
            if (PhoneNumberTb.Text == "")
            {
                PhoneNumberTb.Validator.ToolTip = "Phone number field can't be empty";
            }
            else if (BlValidations.IsPhoneNumberFormatValid(PhoneNumberTb.Text) == false)
            {
                PhoneNumberTb.Validator.ToolTip = "Phone number format isn't valid";
            }
            else
            {
                PhoneNumberTb.Validator.ToolTip = "Good";
            }

            ValidateValidators();
        }
        private void EmailTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EmailTb.Validator == null)
            {
                return;
            }

            EmailTb.Validator.Visibility = System.Windows.Visibility.Visible;
            EmailTb.Validator.Validate(BlValidations.IsEmailAddressFormatValid(EmailTb.Text));

            //ToolTip
            if (EmailTb.Text == "")
            {
                EmailTb.Validator.ToolTip = "Email field can't be empty";
            }
            else if (BlValidations.IsPhoneNumberFormatValid(PhoneNumberTb.Text) == false)
            {
                EmailTb.Validator.ToolTip = "Email address format isn't valid";
            }
            else
            {
                EmailTb.Validator.ToolTip = "Good";
            }

            ValidateValidators();
        }
        private void CarTypeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarTypeCb.Validator == null)
            {
                return;
            }

            CarTypeCb.Validator.Visibility = Visibility.Visible;

            if (CarTypeCb.SelectedItem == null || CarTypeCb.SelectedItem.ToString() == "None")
            {
                CarTypeCb.Validator.Validate(false);
                CarTypeCb.Validator.ToolTip = "You must select a car type";
            }
            else
            {
                CarTypeCb.Validator.Validate(true);
                CarTypeCb.Validator.ToolTip = "Good";
            }

            ValidateValidators();
        }
        private void MaximalDistance_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (MaxDistanceValidator == null)
            {
                return;
            }

            MaxDistanceValidator.Visibility = Visibility.Visible;
            
            if (MaximalDistance.Value == null)
            {
                MaxDistanceValidator.ToolTip = "Maximal distance can't be 0";
            }
            else if (MaximalDistance.Value == 0)
            {
                MaxDistanceValidator.Validate(false);
                MaxDistanceValidator.ToolTip = "Maximal distance can't be 0";
            }
            else
            {
                MaxDistanceValidator.Validate(true);
                MaxDistanceValidator.ToolTip = "Good";
            }

            ValidateValidators();
        }
        private void Experience_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (ExperienceValidator == null)
            {
                return;
            }

            ExperienceValidator.Visibility = Visibility.Visible;

            if (Experience.Value == null)
            {
                ExperienceValidator.ToolTip = "Years of experience can't be 0";
            }
            else if (Experience.Value == 0)
            {
                ExperienceValidator.Validate(false);
                ExperienceValidator.ToolTip = "Years of experience can't be 0";
            }
            else
            {
                ExperienceValidator.Validate(true);
                ExperienceValidator.ToolTip = "Good";
            }

            ValidateValidators();
        }
        private void MaxWeeklyTests_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (MaxWeeklyTestsValidator == null)
            {
                return;
            }

            MaxWeeklyTestsValidator.Visibility = Visibility.Visible;

            if (MaxWeeklyTests.Value == null)
            {
                MaxWeeklyTestsValidator.ToolTip = "Maximal weekly tests can't be 0";
            }
            else if (MaxWeeklyTests.Value == 0)
            {
                MaxWeeklyTestsValidator.Validate(false);
                MaxWeeklyTestsValidator.ToolTip = "Maximal weekly tests can't be 0";
            }
            else
            {
                MaxWeeklyTestsValidator.Validate(true);
                MaxWeeklyTestsValidator.ToolTip = "Good";
            }

            ValidateValidators();
        }
        private void MyWorkTime_SelectionChanged(object sender, RoutedEventArgs e)
        {
            WorkHoursValidator.Visibility = Visibility.Visible;

            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 7; ++j)
                {
                    if (MyWorkTime.WorkTime[i, j] == true)
                    {
                        WorkHoursValidator.Validate(true);
                        WorkHoursValidator.ToolTip = "Good";
                        ValidateValidators();
                        return;
                    }
                }
            }

            WorkHoursValidator.ToolTip = "You must select at least 1 hour";
            WorkHoursValidator.Validate(false);

            ValidateValidators();
        }
        private void BirthDateDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BirthDateDp.Validator == null)
            {
                return;
            }

            BirthDateDp.Validator.Visibility = Visibility.Visible;

            DateTime date = BirthDateDp.SelectedDate.GetValueOrDefault(DateTime.Now);

            if (BirthDateDp.SelectedDate == null)
            {
                BirthDateDp.Validator.Validate(false);
                BirthDateDp.Validator.ToolTip = "You must select a date of birth";
            }
            else
            {
                BirthDateDp.Validator.Validate(Utilities.CalculateAge(date).Years >= Configuration.MinimalTesterAge);
            }

            //ToolTip
            if (Utilities.CalculateAge(date).Years < Configuration.MinimalTesterAge)
            {
                BirthDateDp.Validator.ToolTip = string.Format("Testers must be at least {0} years old", Configuration.MinimalTesterAge);
            }
            else
            {
                BirthDateDp.Validator.ToolTip = "Good";
            }

            ValidateValidators();
        }

        //Click Events
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            List<Tester> testers = m_Ibl.GetAllTesters();
            string error = "";
            if (m_pageMode == PageMode.Add)
            {
                //Adds a tester and getting the error string (if not succeed)
                error = m_Ibl.AddTester(GetTester());
            }
            else if (m_pageMode == PageMode.Edit)
            {
                //Edit a tester and getting the error string (if not succeed)
                error = m_Ibl.UpdateTester(m_targetTester, GetTester());
            }


            if (error != null && m_pageMode == PageMode.Add)
            {
                System.Windows.MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (m_pageMode == PageMode.Edit || m_pageMode == PageMode.Add)
            {
                System.Windows.MessageBox.Show("Success", "Message", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                UIFactory.GetMainWin().MainFrame.Content = new TesterEditPage();
                ClearForm();
            }
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }
        private void RefillButton_Click(object sender, RoutedEventArgs e)
        {
            FillForm(m_targetTester);
        }
        private void FillButton_Click(object sender, RoutedEventArgs e)
        {
            FillForm();
        }

        //Preview Mouse Events
        private void CityCb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (CityCb.IsFullyLoaded == false)
            {
                CityCb.ComboBox.ItemsSource = null;
                CityCb.IsFullyLoaded = true;
                CityBusyIndicator.IsBusy = true;
                LoadCityComboBox(m_Ibl.GetAllCitiesStringFormat());
            }
        }
        private void StreetCb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (StreetCb.IsFullyLoaded == false)
            {
                StreetCb.IsFullyLoaded = true;
                StreetBusyIndicator.IsBusy = true;
                StreetCb.ComboBox.ItemsSource = null;
                LoadStreetComboBox(m_Ibl.GetStreetsOfCity(CityCb.SelectedItem.ToString()));
            }
        }
        
        //Mouse Events
        /// <summary>
        /// Will force focus loss on all hinttable items upon MLB click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TesterAddPageMainGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
            LoseAllHinttableTextBoxesFocus();
            LoseAllDatePickersFocus();
        }
    }
}
