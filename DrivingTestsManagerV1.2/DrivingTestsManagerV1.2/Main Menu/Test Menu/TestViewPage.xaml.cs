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

namespace DrivingTestsManagerV1._2.Main_Menu.Test_Menu
{
    /// <summary>
    /// Interaction logic for TestViewPage.xaml
    /// </summary>
    public partial class TestViewPage : Page
    {
        //Private Members
        private IBl m_Ibl = BLFactory.GetIBl();
        private Test m_targetTest = new Test();
        private PageMode m_pageMode;
        private List<string> m_dmvList = new List<string>();
        private List<DrivingSchool> m_drivingSchools = new List<DrivingSchool>();

        //Properties
        public int ValidatorsCount { get; }
        public int ValidFieldsCount { get; set; }

        //Constructors
        public TestViewPage()
        {
            InitializeComponent();
        }

        //Methods
        /// <summary>
        /// Returns a test instance with properties' values according to the fields in the page
        /// </summary>
        /// <returns></returns>
        private Test GetTest()
        {
            return new Test(GetTestId(), GetTesterId(), GetTraineeId(),
                            GetTestDateAndTime(), GetTestLocation(), GetTesterNotes()
                            , GetCarType(), GetDrivingSchool(), GetDMV());
        }
        private void ClearForm()
        {
            testIdTb.Text = "";
            traineeIdTb.Text = "";
            traineeNameTb.Text = "";
            testerIdTb.Text = "";
            testerNameTb.Text = "";
            testDateDp.DatePicker.SelectedDate = null;
            testDateDp.DatePicker.Text = "";
            testTimeTp.Value = null;
            testTimeTp.Text = "09:00:00 AM";
            carTypeCb.ComboBox.SelectedItem = null;
            carTypeCb.ComboBox.Text = "";
            DMVCb.ComboBox.ItemsSource = null;
            DMVCb.ComboBox.Items.Clear();
            DMVCb.ComboBox.SelectedItem = "";
            DMVCb.ComboBox.Text = "";
            drivingSchoolsCitiesCb.ComboBox.ItemsSource = null;
            drivingSchoolsCitiesCb.ComboBox.Items.Clear();
            drivingSchoolsCitiesCb.ComboBox.SelectedItem = "";
            drivingSchoolsCitiesCb.ComboBox.Text = "";
            drivingSchoolsNamesCb.ComboBox.ItemsSource = null;
            drivingSchoolsNamesCb.ComboBox.Items.Clear();
            drivingSchoolsNamesCb.ComboBox.SelectedItem = "";
            drivingSchoolsNamesCb.ComboBox.Text = "";
            testCityCb.ComboBox.ItemsSource = null;
            testCityCb.ComboBox.Items.Clear();
            testCityCb.ComboBox.SelectedItem = "";
            testCityCb.ComboBox.Text = "";
            testStreetCb.ComboBox.ItemsSource = null;
            testStreetCb.ComboBox.Items.Clear();
            testStreetCb.ComboBox.SelectedItem = "";
            testStreetCb.ComboBox.Text = "";
            testBuildingTb.Text = "";
            RenewRtbHint();
        }
        private void SelectivelyClearForm()
        {
            testIdTb.Text = "";
            testDateDp.DatePicker.SelectedDate = null;
            testDateDp.DatePicker.Text = "";
            testTimeTp.Value = null;
            testTimeTp.Text = "09:00 AM";
            carTypeCb.ComboBox.SelectedItem = null;
            carTypeCb.ComboBox.Text = "";
            DMVCb.ComboBox.ItemsSource = null;
            DMVCb.ComboBox.Items.Clear();
            DMVCb.ComboBox.SelectedItem = "";
            DMVCb.ComboBox.Text = "";
            drivingSchoolsCitiesCb.ComboBox.ItemsSource = null;
            drivingSchoolsCitiesCb.ComboBox.Items.Clear();
            drivingSchoolsCitiesCb.ComboBox.SelectedItem = "";
            drivingSchoolsCitiesCb.ComboBox.Text = "";
            drivingSchoolsNamesCb.ComboBox.ItemsSource = null;
            drivingSchoolsNamesCb.ComboBox.Items.Clear();
            drivingSchoolsNamesCb.ComboBox.SelectedItem = "";
            drivingSchoolsNamesCb.ComboBox.Text = "";
            testCityCb.ComboBox.ItemsSource = null;
            testCityCb.ComboBox.Items.Clear();
            testCityCb.ComboBox.SelectedItem = "";
            testCityCb.ComboBox.Text = "";
            testStreetCb.ComboBox.ItemsSource = null;
            testStreetCb.ComboBox.Items.Clear();
            testStreetCb.ComboBox.SelectedItem = "";
            testStreetCb.ComboBox.Text = "";
            testBuildingTb.Text = "";
            testerNotesRtb.Document.Blocks.Clear();
            rtbHint.Visibility = Visibility.Visible;
            rtbHint.Content = "Write notes here...";
        }
        private void FillForm()
        {
            testIdTb.Text = "";
            traineeIdTb.Text = "308116664";
            testerIdTb.Text = "308478098";
            testDateDp.DatePicker.Text = "1/23/2019";
            testTimeTp.Text = "09:00:00 AM";
            carTypeCb.ComboBox.SelectedItem = CarTypeEnum.Private;

            DMVCb.ComboBox.ItemsSource = null;
            DMVCb.ComboBox.Items.Clear();
            DMVCb.ComboBox.ItemsSource = m_dmvList;
            DMVCb.ComboBox.SelectedItem = "ירושלים";

            drivingSchoolsCitiesCb.ComboBox.ItemsSource = null;
            drivingSchoolsCitiesCb.ComboBox.Items.Clear();
            drivingSchoolsCitiesCb.ComboBox.ItemsSource = m_Ibl.GetAllDrivingSchoolsCitiesStringFormat();
            drivingSchoolsCitiesCb.ComboBox.SelectedItem = "ירושלים";

            drivingSchoolsNamesCb.ComboBox.SelectedItem = "אור ירוק";

            testCityCb.ComboBox.ItemsSource = null;
            testCityCb.ComboBox.Items.Clear();
            testCityCb.ComboBox.ItemsSource = m_Ibl.GetAllCitiesStringFormat();
            testCityCb.ComboBox.SelectedItem = "ירושלים";

            testStreetCb.ComboBox.SelectedItem = "הרב קוק";
            testBuildingTb.Text = "5";

            testerNotesRtb.Document.Blocks.Clear();
            testerNotesRtb.Document.Blocks.Add(new Paragraph(new Run("Hello")));
            rtbHint.Visibility = Visibility.Hidden;
        }

        //Getters For Fields' Values
        private int GetTestId()
        {
            int temp;

            int.TryParse(testIdTb.Text, out temp);

            return temp;
        }
        private string GetTraineeId()
        {
            return traineeIdTb.Text;
        }
        private string GetTesterId()
        {
            return testerIdTb.Text;
        }
        private DateTime GetTestDateAndTime()
        {
            if (testDateDp.SelectedDate == null)
            {
                return new DateTime();
            }

            return new DateTime(testDateDp.SelectedDate.Value.Year,
                                testDateDp.SelectedDate.Value.Month,
                                testDateDp.SelectedDate.Value.Day,
                                testTimeTp.Value.Value.Hour,
                                testTimeTp.Value.Value.Minute,
                                testTimeTp.Value.Value.Second);
        }
        private CarTypeEnum GetCarType()
        {
            CarTypeEnum temp;

            Enum.TryParse(carTypeCb.SelectedItem.ToString(), out temp);

            return temp;
        }
        private string GetCity()
        {
            return testCityCb.Text;
        }
        private string GetStreet()
        {
            return testStreetCb.Text;
        }
        private string GetBuilding()
        {
            return testBuildingTb.Text;
        }
        private AddressStruct GetTestLocation()
        {
            return new AddressStruct(GetCity(),
                                     GetStreet(),
                                     GetBuilding());
        }
        private string GetDMV()
        {
            return DMVCb.SelectedItem.ToString();
        }
        private string GetDrivingSchoolCity()
        {
            return drivingSchoolsCitiesCb.SelectedItem.ToString();
        }
        private string GetDrivingSchoolName()
        {
            return drivingSchoolsNamesCb.SelectedItem.ToString();
        }
        private DrivingSchool GetDrivingSchool()
        {
            try
            {
                foreach (DrivingSchool drivingSchool in m_drivingSchools)
                {
                    if (drivingSchool.City == GetDrivingSchoolCity() &&
                        drivingSchool.Name == GetDrivingSchoolName())
                    {
                        return drivingSchool;
                    }
                }

                throw new Exception("Couldn't find the driving school");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return new DrivingSchool();
            }
        }
        private string GetTesterNotes()
        {
            return new TextRange(testerNotesRtb.Document.ContentStart, testerNotesRtb.Document.ContentEnd).Text;
        }

        //Helper methods
        private void LoseAllHinttableTextBoxesFocus()
        {
            foreach (Control item in TestAddPageMainGrid.Children)
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
            foreach (Control item in TestAddPageMainGrid.Children)
            {
                if (item is HinttableDatePicker)
                {
                    HinttableDatePicker hinttableDp = item as HinttableDatePicker;

                    hinttableDp.LoseFocus(hinttableDp);
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

            foreach (Control control in TestAddPageMainGrid.Children)
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
        private void SelectivelyEnableControls()
        {
            testDateDp.IsEnabled = true;
            testTimeTp.IsEnabled = true;
            carTypeCb.IsEnabled = true;
            DMVCb.IsEnabled = true;
            drivingSchoolsCitiesCb.IsEnabled = true;
            testCityCb.IsEnabled = true;
            testBuildingTb.IsEnabled = true;
            testerNotesRtb.IsEnabled = true;
        }
        private void SelectivelyDisableControls()
        {
            testDateDp.IsEnabled = false;
            testTimeTp.IsEnabled = false;
            carTypeCb.IsEnabled = false;
            DMVCb.IsEnabled = false;
            drivingSchoolsCitiesCb.IsEnabled = false;
            drivingSchoolsNamesCb.IsEnabled = false;
            testCityCb.IsEnabled = false;
            testStreetCb.IsEnabled = false;
            testBuildingTb.IsEnabled = false;
            testerNotesRtb.IsEnabled = false;
        }
        private void LoadCityComboBox(List<string> cities)
        {
            testCityCb.ComboBox.ItemsSource = null;
            testCityCb.ComboBox.Items.Clear();

            Task.Run(() =>
            {
                int i = 0;
                foreach (string city in cities)
                {
                    Dispatcher.Invoke(() =>
                    {
                        testCityCb.ComboBox.Items.Add(city);
                    });
                    ++i;
                    if (i % 20 == 0)
                    {
                        Thread.Sleep(10);
                    }
                }
            }).ContinueWith((task) =>
            {
            }, TaskScheduler.FromCurrentSynchronizationContext()
            );
        }
        private void LoadStreetComboBox(List<string> streets)
        {
            testStreetCb.ComboBox.Items.Clear();
            testCityCb.IsEnabled = false;
            Task.Run(() =>
            {
                int i = 0;
                foreach (string street in streets)
                {
                    Dispatcher.Invoke(() =>
                    {
                        testStreetCb.ComboBox.Items.Add(street);
                    });
                    ++i;
                    if (i % 20 == 0)
                    {
                        Thread.Sleep(25);
                    }
                }
            }).ContinueWith((task) =>
            {
                testCityCb.IsEnabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext()
            );
        }
        private void RenewRtbHint()
        {
            testerNotesRtb.Document.Blocks.Clear();
            rtbHint = new Label();
            testerNotesRtb.Document.Blocks.Add(new Paragraph(new InlineUIContainer(rtbHint)));
            rtbHint.Visibility = Visibility.Visible;
            rtbHint.Content = "Write notes here...";
        }

        //Search Operations
        private Trainee GetTraineeById(string id)
        {
            foreach (Trainee trainee in m_Ibl.GetAllTrainees())
            {
                if (trainee.Id == id)
                {
                    return trainee;
                }
            }

            return null;
        }
        private Tester GetTesterById(string id)
        {
            foreach (Tester tester in m_Ibl.GetAllTesters())
            {
                if (tester.Id == id)
                {
                    return tester;
                }
            }

            return null;
        }

        //Validations
        private void ValidateTraineeIdField()
        {
            if (traineeIdTb.Validator == null)
            {
                return;
            }

            traineeIdTb.Validator.Visibility = Visibility.Visible;

            if (traineeIdTb.IsHintVisible == true || GetTraineeId() == "")
            {
                traineeIdTb.Validator.Validate(false);
                traineeIdTb.Validator.ToolTip = "tester's Id field can't be empty";
                traineeNameTb.Text = "";
            }
            else
            {
                traineeIdTb.Validator.Validate(BlValidations.IsIdFormatValid(GetTraineeId()));

                if (BlValidations.IsIdFormatValid(GetTraineeId()) == false)
                {
                    traineeIdTb.Validator.ToolTip = "Id format isn't valid";
                    traineeNameTb.Text = "";
                }
                else if (GetTraineeById(GetTraineeId()) == null)
                {
                    traineeIdTb.Validator.ToolTip = "Couldn't find trainee with Id " + GetTraineeId();
                    traineeIdTb.Validator.Validate(false);
                    traineeNameTb.Text = "";
                }
                else if (GetTesterById(GetTraineeId()) != null)
                {
                    traineeIdTb.Validator.ToolTip = "This Id belongs to an existing Tester";
                    traineeIdTb.Validator.Validate(false);
                    traineeNameTb.Text = "";
                }
                else if (GetTesterId() == GetTraineeId())
                {
                    traineeIdTb.Validator.ToolTip = "Trainee and tester can't have the same Id";
                    traineeIdTb.Validator.Validate(false);
                    traineeNameTb.Text = "";
                }
                else
                {
                    traineeIdTb.Validator.ToolTip = "Good";
                    traineeNameTb.Text = GetTraineeById(GetTraineeId()).GetName();
                }
            }
        }
        private void ValidateTesterIdField()
        {
            if (testerIdTb.Validator == null)
            {
                return;
            }

            testerIdTb.Validator.Visibility = Visibility.Visible;

            if (testerIdTb.IsHintVisible == true || GetTesterId() == "")
            {
                testerIdTb.Validator.Validate(false);
                testerNameTb.Text = "";
                testerIdTb.Validator.ToolTip = "Tester's Id field can't be empty";
            }
            else
            {
                testerIdTb.Validator.Validate(BlValidations.IsIdFormatValid(GetTesterId()));

                if (BlValidations.IsIdFormatValid(GetTesterId()) == false)
                {
                    testerIdTb.Validator.ToolTip = "Id format isn't valid";
                    testerNameTb.Text = "";
                }
                else if (GetTesterId() == GetTraineeId())
                {
                    testerIdTb.Validator.ToolTip = "Tester and trainee can't have the same Id";
                    testerIdTb.Validator.Validate(false);
                    testerNameTb.Text = "";
                }
                else if (GetTesterById(GetTesterId()) == null)
                {
                    testerIdTb.Validator.ToolTip = "Couldn't find tester with Id " + GetTesterId();
                    testerIdTb.Validator.Validate(false);
                    testerNameTb.Text = "";
                }
                else if (GetTraineeById(GetTesterId()) != null)
                {
                    testerIdTb.Validator.ToolTip = "This Id belongs to an existing trainee";
                    testerIdTb.Validator.Validate(false);
                    testerNameTb.Text = "";
                }
                else
                {
                    testerIdTb.Validator.ToolTip = "Good";
                    testerNameTb.Text = GetTesterById(GetTesterId()).GetName();
                }
            }
        }
        private void ValidateTestDate()
        {
            if (testDateDp.Validator == null)
            {
                return;
            }

            Tester tester = GetTesterById(GetTesterId());

            testDateDp.Validator.Visibility = Visibility.Visible;

            if (tester == null)
            {
                testDateDp.Validator.Validate(false);
                testDateDp.Validator.ToolTip = "You must enter a tester Id first";
                return;
            }

            DateTime date = GetTestDateAndTime();

            if (testDateDp.SelectedDate == null)
            {
                testDateDp.Validator.Validate(false);
                testDateDp.Validator.ToolTip = "You must select a date for the test";
            }
            else if (BlValidations.IsTesterFreeForTest(tester, date) == false)
            {
                testDateDp.Validator.Validate(false);
                testDateDp.Validator.ToolTip = "Tester with Id " + GetTesterId() + " is not free at this date and time";
            }
            else
            {
                testDateDp.Validator.ToolTip = "Good";
                testDateDp.Validator.Validate(true);
            }

            ValidateValidators();
        }
        private void ValidateTestTime()
        {
            if (testTimeValidator == null)
            {
                return;
            }

            Tester tester = GetTesterById(GetTesterId());

            testTimeValidator.Visibility = Visibility.Visible;

            DateTime date = GetTestDateAndTime();

            if (testTimeTp.Value == null)
            {
                testTimeValidator.Validate(false);
                testTimeValidator.ToolTip = "You must select time for test";
            }
            else if (testTimeTp.Value.Value.Hour < 9 || testTimeTp.Value.Value.Hour > 15)
            {
                testTimeValidator.Validate(false);
                testTimeValidator.ToolTip = "Testers only work between 9 AM to 15:AM (Included)";
            }
            else if (testTimeTp.Value.Value.Minute != 0 || testTimeTp.Value.Value.Minute != 0)
            {
                testTimeValidator.Validate(false);
                testTimeValidator.ToolTip = "Please select rounded hours only";
            }
            else
            {
                //timePicker
                testTimeValidator.Validate(true);
                testTimeValidator.ToolTip = "Good";
            }

            ValidateValidators();
        }

        //Events
        private void MyTestAddPage_Loaded(object sender, RoutedEventArgs e)
        {
            List<Test> list = m_Ibl.GetAllTests();
            m_dmvList = m_Ibl.GetAllDMVs();
            m_drivingSchools = m_Ibl.GetAllDrivingSchools();

            //Initilize ComboBoxes
            carTypeCb.ComboBox.ItemsSource = typeof(CarTypeEnum).GetEnumValues();

            ProgressBar.Maximum = ValidatorsCount;
        }

        //SelectionChanged Events
        private void IdTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateTraineeIdField();
            ValidateTesterIdField();
            ValidateValidators();

            if (traineeIdTb.Validator.MyCircle.Foreground == Brushes.Green &&
                testerIdTb.Validator.MyCircle.Foreground == Brushes.Green)
            {
                SelectivelyEnableControls();
            }
            else
            {
                SelectivelyDisableControls();
                SelectivelyClearForm();
            }
        }
        private void TestDateDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidateTestDate();
        }
        private void TestTimeTp_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ValidateTestTime();
        }
        private void DrivingSchoolsCitiesCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (drivingSchoolsCitiesCb.Validator == null)
                return;

            if (drivingSchoolsCitiesCb.IsHintVisible == true)
            {
                drivingSchoolsCitiesCb.Validator.Validate(false);
                drivingSchoolsCitiesCb.Validator.ToolTip = "You must select a driving school city";
            }
            else
            {
                drivingSchoolsCitiesCb.Validator.Validate(true);
                drivingSchoolsCitiesCb.Validator.ToolTip = "Good";
            }

            if (drivingSchoolsCitiesCb.SelectedItem == null)
            {
                drivingSchoolsCitiesCb.Validator.Validate(false);
                drivingSchoolsCitiesCb.Validator.ToolTip = "You must select a driving school city";
                ValidateValidators();
                drivingSchoolsNamesCb.IsEnabled = false;
                return;
            }
            else
            {
                drivingSchoolsNamesCb.IsEnabled = true;
            }

            try
            {
                if (m_Ibl.GetDrivingSchoolsNamesOfCity(drivingSchoolsCitiesCb.SelectedItem.ToString()) == null)
                {
                    throw new Exception("Couldn't load driving school names to" + drivingSchoolsNamesCb.Name + "ComboBox");
                }
                else
                {
                    drivingSchoolsNamesCb.IsFullyLoaded = false;
                    drivingSchoolsNamesCb.ComboBox.ItemsSource = null;
                    drivingSchoolsNamesCb.ComboBox.Items.Clear();
                    drivingSchoolsNamesCb.ComboBox.ItemsSource = m_Ibl.GetDrivingSchoolsNamesOfCity(drivingSchoolsCitiesCb.SelectedItem.ToString());
                }
            }
            catch (Exception)
            {

            }

            drivingSchoolsCitiesCb.Validator.Visibility = Visibility.Visible;

            ValidateValidators();
        }
        private void DrivingSchoolsNamesCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (drivingSchoolsNamesCb.Validator == null)
                return;


            if (drivingSchoolsNamesCb.IsHintVisible == true)
            {
                drivingSchoolsNamesCb.Validator.Validate(false);
                drivingSchoolsNamesCb.Validator.ToolTip = "You must select a street";
            }
            else
            {
                drivingSchoolsNamesCb.Validator.Validate(true);
                drivingSchoolsNamesCb.Validator.ToolTip = "Good";
            }

            if (drivingSchoolsNamesCb.SelectedItem == null)
            {
                drivingSchoolsNamesCb.Validator.Validate(false);
                drivingSchoolsNamesCb.Validator.ToolTip = "You must select a street";
                ValidateValidators();
                return;
            }

            drivingSchoolsNamesCb.Validator.Visibility = Visibility.Visible;

            if (drivingSchoolsNamesCb.SelectedItem.ToString() == "None")
            {
                drivingSchoolsNamesCb.Validator.Validate(false);
                drivingSchoolsNamesCb.Validator.ToolTip = "You must select a street";
            }
            else
            {
                drivingSchoolsNamesCb.Validator.Validate(true);
                drivingSchoolsNamesCb.Validator.ToolTip = "Good";
            }

            ValidateValidators();
        }
        private void TesterNotesRtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (rtbHint == null)
            {
                return;
            }

            if (GetTesterNotes() == "")
            {
                rtbHint.Visibility = Visibility.Visible;
                rtbHint.Content = "Write notes here...";
            }
            else
            {
                rtbHint.Visibility = Visibility.Hidden;
            }
        }

        private void CarTypeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tester tester = GetTesterById(GetTesterId());
            Trainee trainee = GetTraineeById(GetTraineeId());

            if (carTypeCb.Validator == null)
            {
                return;
            }

            carTypeCb.Validator.Visibility = Visibility.Visible;

            if (carTypeCb.SelectedItem == null || carTypeCb.SelectedItem.ToString() == "None")
            {
                carTypeCb.Validator.Validate(false);
                carTypeCb.Validator.ToolTip = "You must select a car type";
            }
            else if (tester.CarType != trainee.CarType)
            {
                carTypeCb.Validator.Validate(false);
                carTypeCb.Validator.ToolTip = string.Format("Tester with Id {0} cant only test trainees for " +
                                                            "\"{1}\" car type", tester.Id, tester.CarType);
            }
            else
            {
                carTypeCb.Validator.Validate(true);
                carTypeCb.Validator.ToolTip = "Good";
            }

            ValidateValidators();
        }
        private void DMVCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DMVCb.Validator == null)
            {
                return;
            }

            DMVCb.Validator.Visibility = Visibility.Visible;

            if (DMVCb.SelectedItem == null || DMVCb.SelectedItem.ToString() == "")
            {
                DMVCb.Validator.Validate(false);
                DMVCb.Validator.ToolTip = "You must select a D.M.V";
            }
            else
            {
                DMVCb.Validator.Validate(true);
                DMVCb.Validator.ToolTip = "Good";
            }

            ValidateValidators();
        }
        private void TestCityCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (testCityCb.Validator == null)
            {
                return;
            }

            if (testCityCb.IsHintVisible == true)
            {
                testCityCb.Validator.Validate(false);
                testCityCb.Validator.ToolTip = "You must select a city";
            }
            else
            {
                testCityCb.Validator.Validate(true);
                testCityCb.Validator.ToolTip = "Good";
            }

            if (testCityCb.SelectedItem == null)
            {
                testCityCb.Validator.Validate(false);
                testCityCb.Validator.ToolTip = "You must select a city";
                ValidateValidators();
                return;
            }
            else
            {
                testStreetCb.IsEnabled = true;
            }

            try
            {
                if (m_Ibl.GetStreetsOfCity(testCityCb.SelectedItem.ToString()) == null)
                {
                    throw new Exception();
                }
                else
                {
                    testStreetCb.IsFullyLoaded = false;
                    testStreetCb.ComboBox.ItemsSource = null;
                    testStreetCb.ComboBox.Items.Clear();
                    testStreetCb.ComboBox.ItemsSource = m_Ibl.GetStreetsOfCity(testCityCb.SelectedItem.ToString());
                }
            }
            catch (Exception)
            {

            }

            testCityCb.Validator.Visibility = Visibility.Visible;

            ValidateValidators();
        }
        private void TestStreetCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (testStreetCb.Validator == null)
            {
                return;
            }

            if (testStreetCb.IsHintVisible == true)
            {
                testStreetCb.Validator.Validate(false);
                testStreetCb.Validator.ToolTip = "You must select a street";
            }
            else
            {
                testStreetCb.Validator.Validate(true);
                testStreetCb.Validator.ToolTip = "Good";
            }

            if (testStreetCb.SelectedItem == null)
            {
                testStreetCb.Validator.Validate(false);
                testStreetCb.Validator.ToolTip = "You must select a street";
                ValidateValidators();
                return;
            }

            testStreetCb.Validator.Visibility = Visibility.Visible;

            if (testStreetCb.SelectedItem.ToString() == "None")
            {
                testStreetCb.Validator.Validate(false);
                testStreetCb.Validator.ToolTip = "You must select a street";
            }
            else
            {
                testStreetCb.Validator.Validate(true);
                testStreetCb.Validator.ToolTip = "Good";
            }

            ValidateValidators();
        }
        private void TestBuildingTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (testBuildingTb.Validator == null)
            {
                return;
            }

            testBuildingTb.Validator.Visibility = Visibility.Visible;

            if (testBuildingTb.IsHintVisible == true || testBuildingTb.Text == "")
            {
                testBuildingTb.Validator.Validate(false);
                testBuildingTb.Validator.ToolTip = "You must select a building";
            }
            else
            {
                testBuildingTb.Validator.Validate(true);
                testBuildingTb.Validator.ToolTip = "Good";
            }

            ValidateValidators();
        }

        //Click events
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            List<Test> tests = m_Ibl.GetAllTests();

            string error = "";
            if (m_pageMode == PageMode.Add)
            {
                //Adds a T and getting the error string (if not succeed)
                error = m_Ibl.AddTest(GetTest());
            }
            else if (m_pageMode == PageMode.Edit)
            {
                //Edit a trainee and getting the error string (if not succeed)
                error = m_Ibl.UpdateTest(m_targetTest.TestId, GetTest());
            }


            if (error != null)
            {
                System.Windows.MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                System.Windows.MessageBox.Show("Success", "Message", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                UIFactory.GetMainWin().MainFrame.Content = new TestEditPage();
                ClearForm();
            }
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
            SelectivelyDisableControls();
        }
        private void FillButton_Click(object sender, RoutedEventArgs e)
        {
            FillForm();
        }

        //PMLB Events
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
            LoseAllHinttableTextBoxesFocus();
            LoseAllDatePickersFocus();
        }
        private void TestCityCb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (testCityCb.IsFullyLoaded == false)
            {
                testCityCb.ComboBox.ItemsSource = null;
                testCityCb.IsFullyLoaded = true;
                LoadCityComboBox(m_Ibl.GetAllCitiesStringFormat());
            }
        }
        private void TestStreetCb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (testStreetCb.IsFullyLoaded == false)
            {
                testStreetCb.IsFullyLoaded = true;
                testStreetCb.ComboBox.ItemsSource = null;
                LoadStreetComboBox(m_Ibl.GetStreetsOfCity(testCityCb.SelectedItem.ToString()));
            }
        }

        //Context Menu Events
        private void TimePickerCmi_Click(object sender, RoutedEventArgs e)
        {
            Tester tester = GetTesterById(GetTesterId());

            if (tester == null)
            {
                return;
            }

            bool[,] workHours = (bool[,])tester.WorkTime.Clone();

            WorkTimeWindow temp = new WorkTimeWindow(tester);
            temp.IsReadOnly = true;
            temp.Show();
        }
    }
}
