using BE;
using BL;
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

namespace DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu
{
    /// <summary>
    /// Interaction logic for TraineeAddPage.xaml
    /// </summary>
    public partial class TraineeAddPage : Page
    {
        //Private Members
        private IBl m_Ibl = BLFactory.GetIBl();
        private PageMode m_pageMode;
        private Trainee m_targetTrainee = new Trainee();//Target trainee to be edited if PageMode is "Edit"
        private List<DrivingSchoolCity> m_drivingSchoolsCities = new List<DrivingSchoolCity>();

        //Properties
        public int ValidatorsCount { get; }
        public int ValidFieldsCount { get; set; }

        //Constructors
        public TraineeAddPage()
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
        public TraineeAddPage(Trainee trainee)
        {
            InitializeComponent();

            m_pageMode = PageMode.Edit;
            m_targetTrainee = trainee;
            RefillButton.Visibility = Visibility.Visible;

            int validatorsCount = 0;
            int validFieldsCount = 0;
            GetValidatorsInfo(ref validatorsCount, ref validFieldsCount);
            ValidatorsCount = validatorsCount;
            ValidFieldsCount = validFieldsCount;

            FillForm(trainee);
            SendButton.Content = "Apply";
        }

        //Methods
        /// <summary>
        /// Returns a trainee instance with properties' values according to the fields in the page
        /// </summary>
        /// <returns></returns>
        private Trainee GetTrainee()
        {
            return new Trainee(GetId(),      GetLastName(),    GetFirstName(), GetBirthDate(),
                               GetGender(),  GetPhoneNumber(), GetAddress(),   GetEmail(),
                               GetCarType(), GetGearType(),    GetDrivingSchool(),
                               GetDrivingTeacher(), GetDrivingLessonsCount());
        }
        private void FillForm()
        {
            IdTb.Text = "308116664";
            FirstNameTb.Text = "Noya";
            LastNameTb.Text = "Elbaz";
            GenderCb.ComboBox.SelectedItem = GenderEnum.Female;
            BirthDateDp.DatePicker.Text = "12/23/1991";
            CityCb.ComboBox.ItemsSource = null;
            CityCb.ComboBox.Items.Clear();
            CityCb.ComboBox.ItemsSource = m_Ibl.GetAllCitiesStringFormat();
            CityCb.ComboBox.SelectedItem = "באר שבע";
            StreetCb.ComboBox.SelectedItem = "משעול פנקס דוד";
            BuildingTb.Text = "24";
            PhoneNumberTb.Text = "0525503649";
            EmailTb.Text = "noya4212@gmail.com";
            CarTypeCb.ComboBox.SelectedItem = CarTypeEnum.Private;
            GearTypeCb.ComboBox.SelectedItem = GearTypeEnum.Auto;
            DrivingSchoolsCitiesCb.ComboBox.ItemsSource = null;
            DrivingSchoolsCitiesCb.ComboBox.Items.Clear();
            DrivingSchoolsCitiesCb.ComboBox.ItemsSource = m_Ibl.GetAllDrivingSchoolsCitiesStringFormat();
            DrivingSchoolsCitiesCb.ComboBox.SelectedItem = "ירושלים";
            DrivingSchoolsNamesCb.ComboBox.SelectedItem = "אור ירוק";
            DrivingTeacherTb.Text = "Moshe";
            DrivingLessonsCountNUD.Value = 30;
        }
        private void FillForm(Trainee trainee)
        {
            IdTb.Text = trainee.Id;
            FirstNameTb.Text = trainee.FirstName;
            LastNameTb.Text = trainee.LastName;
            GenderCb.ComboBox.SelectedItem = trainee.Gender;
            BirthDateDp.DatePicker.SelectedDate = Utilities.ConvertToDateTime(trainee.DateOfBirth);
            BirthDateDp.DatePicker.Text = Utilities.ConvertToDateTime(trainee.DateOfBirth).ToString();
            
            //Address
            CityCb.ComboBox.ItemsSource = null;
            CityCb.ComboBox.Items.Clear();
            CityCb.ComboBox.ItemsSource = m_Ibl.GetAllCitiesStringFormat();
            CityCb.ComboBox.SelectedItem = trainee.Address.City;
            StreetCb.IsFullyLoaded = false;
            StreetCb.ComboBox.ItemsSource = null;
            StreetCb.ComboBox.Items.Clear();
            StreetCb.ComboBox.ItemsSource = m_Ibl.GetStreetsOfCity(CityCb.SelectedItem.ToString());
            StreetCb.ComboBox.SelectedItem = trainee.Address.Street;
            BuildingTb.Text = trainee.Address.Building;

            PhoneNumberTb.Text = trainee.PhoneNumber;
            EmailTb.Text = trainee.EmailAddress;
            CarTypeCb.ComboBox.SelectedItem = trainee.CarType;
            GearTypeCb.ComboBox.SelectedItem = trainee.GearType;
            
            //Driving School
            DrivingSchoolsCitiesCb.ComboBox.ItemsSource = null;
            DrivingSchoolsCitiesCb.ComboBox.Items.Clear();
            DrivingSchoolsCitiesCb.ComboBox.ItemsSource = m_Ibl.GetAllDrivingSchoolsCitiesStringFormat();
            DrivingSchoolsCitiesCb.ComboBox.SelectedItem = trainee.FullDrivingSchoolDetails.City;
            DrivingSchoolsNamesCb.ComboBox.ItemsSource = null;
            DrivingSchoolsNamesCb.ComboBox.Items.Clear();
            DrivingSchoolsNamesCb.ComboBox.ItemsSource = m_Ibl.GetDrivingSchoolsNamesOfCity(trainee.FullDrivingSchoolDetails.City);
            DrivingSchoolsNamesCb.ComboBox.SelectedItem = trainee.FullDrivingSchoolDetails.Name.Trim();
            DrivingTeacherTb.Text = trainee.DrivingSchoolTeacher;

            DrivingLessonsCountNUD.Value = trainee.DrivingLessonsCount;

            ValidateValidators();
        }
        private void ClearForm()
        {
            IdTb.Text = "";
            FirstNameTb.Text = "";
            LastNameTb.Text = "";
            GenderCb.ComboBox.SelectedItem = null;
            BirthDateDp.DatePicker.SelectedDate = null;
            BirthDateDp.DatePicker.Text = "";
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
            GearTypeCb.ComboBox.SelectedItem = null;
            DrivingSchoolsCitiesCb.ComboBox.ItemsSource = null;
            DrivingSchoolsCitiesCb.ComboBox.Items.Clear();
            DrivingSchoolsCitiesCb.ComboBox.SelectedItem = "";

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
                case "Male": return GenderEnum.Male;
                default: return GenderEnum.None;
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
        private CarTypeEnum GetCarType()
        {
            CarTypeEnum result;

            Enum.TryParse(CarTypeCb.SelectedItem.ToString(), out result);

            return result;
        }
        private GearTypeEnum GetGearType()
        {
            GearTypeEnum result;

            Enum.TryParse(GearTypeCb.SelectedItem.ToString(), out result);

            return result;
        }
        private DrivingSchool GetDrivingSchool()
        {
            return new DrivingSchool()
            {
                City = DrivingSchoolsCitiesCb.SelectedItem.ToString(),
                Name = DrivingSchoolsNamesCb.SelectedItem.ToString(),
                //ToDo: 
                CarTypes = new CarTypeEnum[5]
            };
        }
        private string GetDrivingTeacher()
        {
            return DrivingTeacherTb.Text;
        }
        private int GetDrivingLessonsCount()
        {
            return (int)DrivingLessonsCountNUD.Value;
        }

        //Helper Methods
        private void LoseAllHinttableTextBoxesFocus()
        {
            foreach (Control item in TraineeAddPageMainGrid.Children)
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
            foreach (Control item in TraineeAddPageMainGrid.Children)
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
            foreach (Control control in TraineeAddPageMainGrid.Children)
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

            foreach (Control control in TraineeAddPageMainGrid.Children)
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
        /// <summary>
        /// Returns true if "str" is in "list"
        /// </summary>
        /// <param name="list">List of strings</param>
        /// <param name="str">string to be checked if exists in "list"</param>
        /// <returns></returns>
        private bool IsExists(List<string> list, string str)
        {
            foreach(string s in list)
            {
                if (s == str)
                {
                    return true;
                }
            }

            return false;
        }

        //Events
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Trainee> list = m_Ibl.GetAllTrainees();
            m_drivingSchoolsCities = m_Ibl.GetAllDrivingSchoolsCities();

            //Initilize ComboBoxes
            GenderCb.ComboBox.ItemsSource = typeof(GenderEnum).GetEnumValues();
            CarTypeCb.ComboBox.ItemsSource = typeof(CarTypeEnum).GetEnumValues();
            GearTypeCb.ComboBox.ItemsSource = typeof(GearTypeEnum).GetEnumValues();
            CityCb.ComboBox.ItemsSource = m_Ibl.GetAllCitiesStringFormat();
            DrivingSchoolsCitiesCb.ComboBox.ItemsSource = m_Ibl.GetAllDrivingSchoolsCitiesStringFormat();

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

                BirthDateDp.Validator.Validate(Utilities.CalculateAge(date).Years >= Configuration.MinimalTraineeAge);
            }

            //ToolTip
            if (Utilities.CalculateAge(date).Years < Configuration.MinimalTraineeAge)
            {
                BirthDateDp.Validator.ToolTip = string.Format("Trainees must be at least {0} years old", Configuration.MinimalTraineeAge);
            }
            else
            {
                BirthDateDp.Validator.ToolTip = "Good";
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
                return;

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
        private void GearTypeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GearTypeCb.Validator == null)
            {
                return;
            }

            GearTypeCb.Validator.Visibility = Visibility.Visible;

            if (GearTypeCb.SelectedItem == null || GearTypeCb.SelectedItem.ToString() == "None")
            {
                GearTypeCb.Validator.Validate(false);
                GearTypeCb.Validator.ToolTip = "You must select a gear type";
            }
            else
            {
                GearTypeCb.Validator.Validate(true);
                GearTypeCb.Validator.ToolTip = "Good";
            }

            ValidateValidators();
        }
        private void DrivingSchoolsCitiesCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DrivingSchoolsCitiesCb.Validator == null)
                return;

            if (DrivingSchoolsCitiesCb.IsHintVisible == true)
            {
                DrivingSchoolsCitiesCb.Validator.Validate(false);
                DrivingSchoolsCitiesCb.Validator.ToolTip = "You must select a driving school city";
            }
            else
            {
                DrivingSchoolsCitiesCb.Validator.Validate(true);
                DrivingSchoolsCitiesCb.Validator.ToolTip = "Good";
            }

            if (DrivingSchoolsCitiesCb.SelectedItem == null)
            {
                DrivingSchoolsCitiesCb.Validator.Validate(false);
                DrivingSchoolsCitiesCb.Validator.ToolTip = "You must select a driving school city";
                ValidateValidators();
                DrivingSchoolsNamesCb.IsEnabled = false;
                return;
            }
            else
            {
                DrivingSchoolsNamesCb.IsEnabled = true;
            }

            try
            {
                if (m_Ibl.GetDrivingSchoolsNamesOfCity(DrivingSchoolsCitiesCb.SelectedItem.ToString()) == null)
                {
                    throw new Exception("Couldn't load driving school names to" + DrivingSchoolsNamesCb.Name + "ComboBox");
                }
                else
                {
                    DrivingSchoolsNamesCb.IsFullyLoaded = false;
                    DrivingSchoolsNamesCb.ComboBox.ItemsSource = null;
                    DrivingSchoolsNamesCb.ComboBox.Items.Clear();
                    DrivingSchoolsNamesCb.ComboBox.ItemsSource = m_Ibl.GetDrivingSchoolsNamesOfCity(DrivingSchoolsCitiesCb.SelectedItem.ToString());
                }
            }
            catch (Exception)
            {

            }

            DrivingSchoolsCitiesCb.Validator.Visibility = Visibility.Visible;

            ValidateValidators();
        }
        private void DrivingSchoolsNamesCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DrivingSchoolsNamesCb.Validator == null)
                return;


            if (DrivingSchoolsNamesCb.IsHintVisible == true)
            {
                DrivingSchoolsNamesCb.Validator.Validate(false);
                DrivingSchoolsNamesCb.Validator.ToolTip = "You must select a street";
            }
            else
            {
                DrivingSchoolsNamesCb.Validator.Validate(true);
                DrivingSchoolsNamesCb.Validator.ToolTip = "Good";
            }

            if (DrivingSchoolsNamesCb.SelectedItem == null)
            {
                DrivingSchoolsNamesCb.Validator.Validate(false);
                DrivingSchoolsNamesCb.Validator.ToolTip = "You must select a street";
                ValidateValidators();
                return;
            }

            DrivingSchoolsNamesCb.Validator.Visibility = Visibility.Visible;

            if (DrivingSchoolsNamesCb.SelectedItem.ToString() == "None")
            {
                DrivingSchoolsNamesCb.Validator.Validate(false);
                DrivingSchoolsNamesCb.Validator.ToolTip = "You must select a street";
            }
            else
            {
                DrivingSchoolsNamesCb.Validator.Validate(true);
                DrivingSchoolsNamesCb.Validator.ToolTip = "Good";
            }

            ValidateValidators();
        }
        private void DrivingTeacherTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DrivingTeacherTb.Validator == null)
            {
                return;
            }

            DrivingTeacherTb.Validator.Visibility = Visibility.Visible;

            if (DrivingTeacherTb.IsHintVisible == true || DrivingTeacherTb.Text == "")
            {
                DrivingTeacherTb.Validator.Validate(false);
                DrivingTeacherTb.Validator.ToolTip = "Driving teacher name field can't be empty";
            }
            else
            {
                DrivingTeacherTb.Validator.Validate(BlValidations.IsNameFormatValid(DrivingTeacherTb.Text));

                if (BlValidations.IsNameFormatValid(DrivingTeacherTb.Text) == false)
                {
                    DrivingTeacherTb.Validator.ToolTip = "Driving teacher name must contain only letters";
                }
                else
                {
                    DrivingTeacherTb.Validator.ToolTip = "Good";
                }
            }

            ValidateValidators();
        }
        private void DrivingLessonsCountNUD_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (LessonsValidator == null)
                return;

            LessonsValidator.Visibility = Visibility.Visible;

            if (DrivingLessonsCountNUD.Value == null)
            {
                LessonsValidator.ToolTip = "Lessons count can't be 0";
            }
            else if (DrivingLessonsCountNUD.Value == 0)
            {
                LessonsValidator.Validate(false);
                LessonsValidator.ToolTip = "Lessons count can't be 0";
            }
            else
            {
                LessonsValidator.Validate(true);
                LessonsValidator.ToolTip = "Good";
            }

            ValidateValidators();
        }

        //Click Events
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            List<Trainee> trainees = m_Ibl.GetAllTrainees();
            string error = "";
            if (m_pageMode == PageMode.Add)
            {
                //Adds a trainee and getting the error string (if not succeed)
                error = m_Ibl.AddTrainee(GetTrainee());
            }
            else if (m_pageMode == PageMode.Edit)
            {
                //Edit a trainee and getting the error string (if not succeed)
                error = m_Ibl.UpdateTrainee(m_targetTrainee, GetTrainee());
            }


            if (error != null)
            {
                System.Windows.MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                System.Windows.MessageBox.Show("Success", "Message", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                UIFactory.GetMainWin().MainFrame.Content = new TraineeEditPage();
                ClearForm();
            }
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }
        private void RefillButton_Click(object sender, RoutedEventArgs e)
        {
            FillForm(m_targetTrainee);
        }
        private void FillButton_Click(object sender, RoutedEventArgs e)
        {
            FillForm();
        }

        //Preview Events
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
        private void TraineeAddPageMainGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
            LoseAllHinttableTextBoxesFocus();
            LoseAllDatePickersFocus();
        }
    }
}
