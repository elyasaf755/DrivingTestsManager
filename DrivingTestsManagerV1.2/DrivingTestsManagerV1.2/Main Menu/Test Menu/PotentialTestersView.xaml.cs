using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
    /// Interaction logic for PotentialTestersView.xaml
    /// </summary>
    public partial class PotentialTestersView : Page
    {
        //Private Fields
        private IBl m_Ibl = BLFactory.GetIBl();
        private MainWindow m_mainWin;
        private double m_distance = 0;
        private Trainee m_targetTrainee = new Trainee();
        private Tester m_targetTester = new Tester();
        private int m_timer = 0;
        private bool m_isMouseOver = false;
        private bool m_isToolTipOpen = false;

        //Private Properties
        private List<Tester> TestersList { get; set; } = new List<Tester>();
        private ICollectionView TestersCollectionView { get; set; }
        private ICollectionView GroupedTesters { get; set; }
        private List<DistanceStruct> DistancesList { get; set; } = new List<DistanceStruct>();
        private List<Tester> TestersInRange { get; set; }

        //Public Properties
        public ObservableCollection<Tester> TestersCollection { get; set; } = new ObservableCollection<Tester>();

        //Constructors
        public PotentialTestersView()
        {
            InitializeComponent();
        }

        //Methods
        private void UpdateCollection()
        {
            if (TestersList == null)
            {
                return;
            }

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
        private void ClearFields()
        {
            traineeIdTb.Text = "";
            testDateTimeDtp.Value = null;
        }
        private void SetTimer(int seconds)
        {
            Task.Run(() =>
            {
                for (int i = seconds - 1; i >= 0; --i)
                {
                    Dispatcher.Invoke(() =>
                    {
                        m_timer = i;
                    });
                    Thread.Sleep(1000);
                }
            });
        }
        private void FilterData()
        {
            TestersList = m_Ibl.GetAllTesters();

            Trainee trainee = GetTrainee();

            if (trainee != null)
            {
                findClosetTesterButton.IsEnabled = true;
                TestersList = GetTestersByCarType();
                UpdateCollection();
                UpdateGroup();
            }
            else
            {
                findClosetTesterButton.IsEnabled = false;
            }

            if (IsTestDateTimeValid() == true)
            {
                TestersList = GetAvailableTestersByDateTime();
                UpdateCollection();
                UpdateGroup();
            }
            else
            {
                TestersList.Clear();
                UpdateCollection();
                UpdateGroup();
                return;
            }

            if (m_distance != 0)
            {
                TestersList = TestersInRange;
                UpdateCollection();
                UpdateGroup();
            }
        }
        private void SelectTester()
        {
            if (testerDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a tester first");
                return;
            }

            if (testerDataGrid.SelectedItem is Tester)
            {
                m_targetTester = testerDataGrid.SelectedItem as Tester;
            }
            else
            {
                MessageBox.Show("Please select a tester first");
            }
        }
        private void TriggerSpinner()
        {
            //Trigger spinner to stop.
            distanceTb.Text = "1";
            distanceTb.Text = "";
            return;
        }
        private void OpenVerificationWindow()
        {
            Trainee trainee = GetTrainee();
            Tester tester = GetTester();

            if (trainee == null || tester == null)
            {
                return;
            }

            Test test = new Test()
            {
                TraineeId = trainee.Id,
                TesterId = tester.Id,
                TestDateAndTime = GetTestDateAndTime(),
                TestLocation = GetTestAddress(),
                IsPassed = null,
                TesterNotes = "",
                CarType = trainee.CarType,
                DrivingSchool = trainee.FullDrivingSchoolDetails,
                DMV = GetDmv()
            };

            AddTestVerificationWin win = new AddTestVerificationWin(test);
            win.ShowDialog();
            win.Close();
        }
        /// <summary>
        /// Forces a control to open a ToolTip with certain string in it
        /// </summary>
        /// <param name="control">Control to be forced to open its ToolTip</param>
        /// <param name="content">Content of the ToolTip to be showed</param>
        private void OpenToolTip(Control control, string content)
        {
            try
            {
                var toolTip = new ToolTip();
                control.ToolTip = new ToolTip();

                if (control.ToolTip != null)
                {
                    if (control.ToolTip is ToolTip)
                    {
                        var castToolTip = control.ToolTip as ToolTip;
                        castToolTip.IsOpen = true;
                    }

                    control.ToolTip = content;
                    toolTip.Content = content;
                    toolTip.StaysOpen = false;
                    toolTip.PlacementTarget = control;

                    if (toolTip.IsOpen == false && m_isToolTipOpen == false)
                    {
                        toolTip.IsOpen = true;

                        Task.Run(() =>
                        {
                            Thread.Sleep(1300);
                            Dispatcher.Invoke(() =>
                            {
                                toolTip.IsOpen = false;
                            });
                        });
                    }

                    
                }
            }
            catch (Exception)
            {
                
            }
            
        }
        /// <summary>
        /// Forces a control to open a Tooltip with its current content
        /// </summary>
        /// <param name="control">Control to be forced to open its ToolTip</param>
        private void OpenToolTip(Control control)
        {
            try
            {
                var toolTip = new ToolTip();

                if (control.ToolTip != null)
                {
                    if (control.ToolTip is ToolTip)
                    {
                        var castToolTip = control.ToolTip as ToolTip;
                        castToolTip.IsOpen = true;
                    }
                    else
                    {
                        toolTip.Content = control.ToolTip;
                        toolTip.StaysOpen = false;
                        toolTip.PlacementTarget = control;

                        if (toolTip.IsOpen == false)
                        {
                            toolTip.IsOpen = true;
                        }

                        Task.Run(() =>
                        {
                            Thread.Sleep(1300);
                            Dispatcher.Invoke(() =>
                            {
                                toolTip.IsOpen = false;
                            });
                        });
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        //Getters For The Fields' Values
        private string GetTraineeId()
        {
            return traineeIdTb.Text;
        }
        private DateTime GetTestDateAndTime()
        {
            if (testDateTimeDtp.Value == null)
            {
                return new DateTime();
            }

            return new DateTime(testDateTimeDtp.Value.Value.Year,
                                testDateTimeDtp.Value.Value.Month,
                                testDateTimeDtp.Value.Value.Day,
                                testDateTimeDtp.Value.Value.Hour,
                                testDateTimeDtp.Value.Value.Minute,
                                testDateTimeDtp.Value.Value.Second);
        }
        private string GetTestCity()
        {
            return testCityCb.Text;
        }
        private string GetTestStreet()
        {
            return testStreetCb.Text;
        }
        private AddressStruct GetTestAddress()
        {
            if (GetTestCity() == "" && GetTestStreet() == "")
            {
                return new AddressStruct();
            }

            return new AddressStruct(GetTestCity(), GetTestStreet(), "");
        }
        private string GetDmv()
        {
            return DMVCb.ComboBox.SelectedItem.ToString();
        }

        //Data Getters
        private Trainee GetTraineeById(string id)
        {
            foreach(Trainee trainee in m_Ibl.GetAllTrainees())
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
        private List<Tester> GetTestersByCarType()
        {
            Trainee trainee = GetTrainee();

            if (trainee == null)
            {
                return TestersList;
            }

            var result = from tester in TestersList
                         where tester.CarType == trainee.CarType
                         select tester;

            return result.ToList();
        }
        private List<Tester> GetAvailableTestersByDateTime()
        {
            if (GetTestDateAndTime() == null || GetTestDateAndTime() == new DateTime())
            {
                return TestersList;
            }

            DateTime testDateTime = GetTestDateAndTime();
            
            var result = from tester in TestersList
                         where BlValidations.IsTesterFreeForTest(tester, testDateTime) == true
                         select tester;

            return result.ToList();
        }
        private Tester GetTester()
        {
            if (testerDataGrid.SelectedItem == null)
            {
                return null;
            }

            if (testerDataGrid.SelectedItem is Tester)
            {
                return testerDataGrid.SelectedItem as Tester;
            }

            return null;
        }
        private Trainee GetTrainee()
        {
            return GetTraineeById(GetTraineeId());
        }

        //Validations
        private void ValidateTraineeIdField()
        {
            if (traineeIdTb.Validator == null)
            {
                return;
            }

            Trainee trainee = GetTrainee();
            traineeIdTb.Validator.Visibility = Visibility.Visible;

            try
            {
                if (traineeIdTb.IsHintVisible == true || GetTraineeId() == "")
                {
                    throw new Exception("trainee's Id field can't be empty");
                }
                else if (BlValidations.IsIdFormatValid(GetTraineeId()) == false)
                {
                    throw new Exception("Id " + trainee.Id + "'s format is not valid");
                }
                else if (trainee == null)
                {
                    throw new Exception("Couldn't find trainee with Id " + GetTraineeId());
                }
                else if (GetTesterById(GetTraineeId()) != null)
                {
                    throw new Exception("This Id belongs to an existing Tester");
                }
                else if (trainee.DaysPassedSinceLastTest < Configuration.MinimalDaysBetweenTests)
                {
                    throw new Exception("Test can only be scheduled at least " + Configuration.MinimalDaysBetweenTests
                                        + " days after the trainee's last test.");
                }
                else if (trainee.DrivingLessonsCount < Configuration.MinimalLessonsCount)
                {
                    throw new Exception(trainee.GetName() + " must do at least " + Configuration.MinimalLessonsCount
                                        + " driving lessons before doing a test");
                }
                else if (BlValidations.IsLisenceOwned(trainee.OwnedLisences, trainee.WantedLisence) == true)
                {
                    throw new Exception("Lisence " + trainee.CarType + " is already owned by " + trainee.GetName());
                }
                else if (BlValidations.IsCarTypeExist(trainee.ScheduleList, trainee.CarType) == true)
                {
                    throw new Exception("trainee with Id " + trainee.Id + " is already have an upcomming test for " + trainee.CarType);
                }
                else
                {
                    traineeIdTb.Validator.Validate(true);
                    traineeIdTb.Validator.ToolTip = "Good";
                    traineeNameTb.Text = trainee.GetName();
                    traineeCarTypeCb.ComboBox.SelectedItem = trainee.CarType;
                }
            }
            catch (Exception e)
            {
                traineeIdTb.Validator.ToolTip = e.Message;
                traineeIdTb.Validator.Validate(false);
                traineeNameTb.Text = "";
                traineeCarTypeCb.Text = "";
            }
        }
        private void ValidateTestDateTime()
        {
            if (testDateTimeValidator == null)
            {
                return;
            }

            DateTime date = GetTestDateAndTime();

            try
            {
                if (testDateTimeDtp.Value == null || GetTestDateAndTime() == new DateTime())
                {
                    testDateTimeValidator.Validate(false);
                    throw new Exception("You must select a date for the test");
                }
                else if (GetTestDateAndTime().DayOfWeek == DayOfWeek.Friday ||
                         GetTestDateAndTime().DayOfWeek == DayOfWeek.Saturday)
                {
                    testDateTimeValidator.Validate(false);
                    throw new Exception("Testers only work between Sunday and Thursday (included)");
                }
                else if (GetTestDateAndTime().Hour < 9 || GetTestDateAndTime().Hour > 15)
                {
                    testDateTimeValidator.Validate(false);
                    throw new Exception("Testers only work between 9:00 AM and 15:00 PM (included)");
                }
                else if (GetTestDateAndTime() < DateTime.Now)
                {
                    testDateTimeValidator.Validate(false);
                    throw new Exception("You can't appoint a new test on a date belongs in the past");
                }
                else if (TestersList.Count == 0)
                {
                    testDateTimeValidator.Validate(false);
                    throw new Exception("No testers were found on this date and time");
                }
                else
                {
                    testDateTimeValidator.Validate(true);
                    testDateTimeValidator.ToolTip = "Good";
                    OpenToolTip(testDateTimeValidator);
                }
            }
            catch (Exception e)
            {
                if (m_isToolTipOpen == false)
                {
                    OpenToolTip(testDateTimeValidator, e.Message);
                }
            }
            
        }
        private bool IsTestDateTimeValid()
        {
            DateTime date = GetTestDateAndTime();

            if (testDateTimeDtp.Value == null || GetTestDateAndTime() == new DateTime())
            {
                return false;
            }
            else if (GetTestDateAndTime().DayOfWeek == DayOfWeek.Friday ||
                     GetTestDateAndTime().DayOfWeek == DayOfWeek.Saturday)
            {
                return false;
            }
            else if (GetTestDateAndTime().Hour < 9 || GetTestDateAndTime().Hour > 15)
            {
                return false;
            }
            else if (GetTestDateAndTime() < DateTime.Now)
            {
                return false;
            }
            else if (TestersList.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Loaded Events
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            m_mainWin = UIFactory.GetMainWin();
            DistancesList = m_Ibl.GetAllDistances();
            TestersList = m_Ibl.GetAllTesters();

            DMVCb.ComboBox.ItemsSource = null;
            DMVCb.ComboBox.Items.Clear();
            DMVCb.ComboBox.ItemsSource = m_Ibl.GetAllDMVs();

            SelectTesterCmi.IsEnabled = false;

            traineeCarTypeCb.ComboBox.ItemsSource = typeof(CarTypeEnum).GetEnumValues();
            testCityCb.ComboBox.ItemsSource = m_Ibl.GetAllCitiesStringFormat();
        }
        private void TestDateTimeDtp_Loaded(object sender, RoutedEventArgs e)
        {
            testDateTimeDtp.Value = null;
        }

        //Value Changed Events
        private void TraineeId_TextChanged(object sender, TextChangedEventArgs e)
        {
            testerDataGrid.SelectedItem = null;
            ValidateTraineeIdField();

            if (GetTrainee() == null)
            {
                DMVCb.ComboBox.SelectedItem = null;
                DMVCb.ComboBox.Text = "";

                return;
            }

            FilterData();
            OpenToolTip(traineeIdTb.Validator);
        }
        private void DMVCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            testerDataGrid.SelectedItem = null;

            if (DMVCb.Validator == null)
            {
                return;
            }

            DMVCb.Validator.Visibility = Visibility.Visible;

            if (DMVCb.SelectedItem == null || DMVCb.SelectedItem.ToString() == "")
            {
                DMVCb.Validator.Validate(false);
                DMVCb.Validator.ToolTip = "You must select a D.M.V";

                testCityCb.IsEnabled = false;
                testCityCb.ComboBox.SelectedItem = null;
                testCityCb.ComboBox.Text = "";
            }
            else
            {
                DMVCb.Validator.Validate(true);
                DMVCb.Validator.ToolTip = "Good";

                testCityCb.IsEnabled = true;
            }
        }
        private void DateTimePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            testerDataGrid.SelectedItem = null;

            DateTime? testDateTime = testDateTimeDtp.Value;

            if (testDateTime == null)
            {
                return;
            }

            if (testDateTimeDtp.Value.Value.Minute != 0 || testDateTimeDtp.Value.Value.Second != 0)
            {
                testDateTimeDtp.Value = new DateTime(testDateTime.Value.Year,
                                            testDateTime.Value.Month,
                                            testDateTime.Value.Day,
                                            testDateTime.Value.Hour, 0, 0);
            }

            FilterData();
            ValidateTestDateTime();
        }
        private void DistanceTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            testerDataGrid.SelectedItem = null;

            distanceSpinner.Spin = false;
            ClearFieldsButton.IsEnabled = true;
            distanceSpinner.Visibility = Visibility.Hidden;

            if (distanceTb.Text == "")
            {
                selectTesterButton.IsEnabled = false;
            }
            else
            {
                selectTesterButton.IsEnabled = true;
            }
        }
        private void TestCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            testerDataGrid.SelectedItem = null;

            if (testCityCb.ComboBox.SelectedItem == null || testCityCb.ComboBox.Text == "")
            {
                testStreetCb.ComboBox.ItemsSource = null;
                testStreetCb.ComboBox.Items.Clear();
                testStreetCb.ComboBox.Text = "";
                testStreetCb.IsEnabled = false;
                return;
            }

            testStreetCb.IsEnabled = true;
            testStreetCb.ComboBox.ItemsSource = m_Ibl.GetStreetsOfCity(testCityCb.ComboBox.SelectedItem.ToString());
        }
        private void TestStreet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            testerDataGrid.SelectedItem = null;
            SelectTesterCmi.IsEnabled = false;

            if (testStreetCb.ComboBox.SelectedItem != null &&
                testStreetCb.ComboBox.SelectedItem.ToString() != "")
            {
                testersInRangeButton.IsEnabled = true;
            }
            else
            {
                testersInRangeButton.IsEnabled = false;
                distanceTb.Text = "";
            }
        }
        private void TesterDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tester tester = testerDataGrid.SelectedItem as Tester;
            Trainee trainee = GetTrainee();
            AddressStruct testAddress = GetTestAddress();

            if (tester == null || testAddress == null || 
                testAddress == new AddressStruct() || trainee == null)
            {
                return;
            }

            selectTesterButton.IsEnabled = true;

            double distance = BLTools.GetDistanceFromDataSource(trainee.Address, tester.Address);

            //If no distance was already measured between 2 addresses
            if (distance < 0)
            {
                Task.Run(() =>
                {
                    distance = BLTools.CalculateDistanceGoogle(trainee.Address, tester.Address);
                }).ContinueWith((t) =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        testerDistanceTb.Text = distance.ToString("0.00") + " Km";
                    });
                });
            }
            //If distance was already measured between 2 addresses
            else
            {
                testerDistanceTb.Text = distance.ToString("0.00") + " Km";
            }
        }

        //Click Events
        private async void TestersInRangeButton_Click(object sender, RoutedEventArgs e)
        {
            distanceSpinner.Visibility = Visibility.Visible;
            findClosetTesterButton.IsEnabled = false;
            ClearFieldsButton.IsEnabled = false;
            distanceSpinner.Spin = true;

            m_targetTrainee = GetTrainee();
            AddressStruct testAddress = GetTestAddress();
            FilterData();
            double distanceFromTrainee = 100.000001;
            
            await Task.Run(async () =>
            {
                TestersList = BLTools.GetAllTestersInRange(TestersList, testAddress);
                TestersInRange = BLTools.GetClonedList(TestersList);
                distanceFromTrainee = BLTools.CalculateDistanceGoogle(m_targetTrainee.Address, testAddress);

            }).ContinueWith((s) =>
            {
                Dispatcher.Invoke(() =>
                {
                    if (TestersList.Count == 0)
                    {
                        MessageBox.Show(string.Format("Couldn't find a tester in range\nTry a different test location"), 
                                                       "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        SelectTesterCmi.IsEnabled = false;
                        TriggerSpinner();
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Success!\nPlease select a tester"), "Success!", 
                                                       MessageBoxButton.OK, MessageBoxImage.Information);
                        SelectTesterCmi.IsEnabled = true;
                        distanceTb.Text = distanceFromTrainee.ToString();
                    }
                    
                    UpdateCollection();
                });
            });
        }
        private void ClearFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                ClearFields();
            }
        }
        private void SelectTesterButton_Click(object sender, RoutedEventArgs e)
        {
            SelectTester();
            OpenVerificationWindow();
        }
        private void SelectTesterCmi_Click(object sender, RoutedEventArgs e)
        {
            SelectTester();
            OpenVerificationWindow();
        }
        private async void FindClosetTesterButton_Click(object sender, RoutedEventArgs e)
        {
            distanceSpinner.Visibility = Visibility.Visible;
            distanceSpinner.Spin = true;

            m_targetTrainee = GetTrainee();
            Tester tester = new Tester();

            await Task.Run(async () =>
            {
                tester = BLTools.GetClosestTester(m_targetTrainee.Address);

                if (tester == null)
                {
                    return;
                }

                double distance = BLTools.GetDistanceFromDataSource(m_targetTrainee.Address, tester.Address);

                //If distance was NOT found in the DataSource
                if (distance == -1)
                {
                    m_distance = BLTools.CalculateDistanceGoogle(m_targetTrainee.Address, tester.Address);
                }
                //If distance WAS found in the DataSource
                else
                {
                    m_distance = distance;
                }
            }).ContinueWith((str) =>
            {
                Dispatcher.Invoke(() =>
                {
                    //If no internet connection was found
                    if (m_distance == -2)
                    {
                        MessageBox.Show("No internet connection found");
                        return;
                    }
                    if (tester == null)
                    {
                        distanceTb.Text = "f";
                        distanceTb.Text = "";
                        MessageBox.Show(string.Format("Couldn't find a tester"), "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (m_distance != 100.00001 && m_distance != -1)
                    {
                        distanceTb.Text = "";
                        distanceTb.Text = m_distance.ToString("0.00") + " Km";

                        testCityCb.ComboBox.SelectedItem = m_targetTrainee.Address.City;
                        testStreetCb.ComboBox.SelectedItem = m_targetTrainee.Address.Street;

                        m_Ibl.AddDistance(new DistanceStruct(m_targetTrainee.Address, tester.Address, m_distance));
                        TestersInRange = new List<Tester>();
                        TestersInRange.Add(tester);

                        if (TestersInRange.Count == 0)
                        {
                            MessageBox.Show(string.Format("Couldn't find a tester"), "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Success!\nPlease choose the tester to continue"), "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                    FilterData();
                });
            });
        }

        //ComboBox DropDown Events
        private void TestCity_DropDownOpened(object sender, EventArgs e)
        {
            testCityCb.IsDropDownOpen = false;
        }
        private void TestStreet_DropDownOpened(object sender, EventArgs e)
        {
            testStreetCb.IsDropDownOpen = false;
        }

        //Focus Events
        private void TestDateTimeDtp_LostFocus(object sender, RoutedEventArgs e)
        {
            m_isMouseOver = false;
        }

        //Mouse Over Events
        private void TestDateTimeDtp_MouseEnter(object sender, MouseEventArgs e)
        {
            if (m_timer != 0)
            {
                return;
            }

            SetTimer(5);

            m_isMouseOver = true;

            Task.Run(() =>
            {
                Thread.Sleep(500);

                Dispatcher.Invoke(() =>
                {
                    if (m_isMouseOver == false)
                    {
                        return;
                    }

                    testDateTimeDtp.IsOpen = true;
                });
            });
        }
        private void TestDateTimeDtp_MouseLeave(object sender, MouseEventArgs e)
        {
            m_isMouseOver = false;
        }
    }
}
