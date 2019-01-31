using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

//Elyasaf Elbaz
//308478098
namespace DrivingTestsManagerV1._2.Main_Menu.Test_Menu
{
    /// <summary>
    /// Interaction logic for AddTestResultsWin.xaml
    /// </summary>
    public partial class AddTestResultsWin : Window
    {
        //Private Fields
        private MainWindow m_mainWin = UIFactory.GetMainWin();
        private IBl m_Ibl = BLFactory.GetIBl();
        private Test m_originalTest = new Test();
        private Test m_targetTest = new Test();
        private List<CheckBox> m_gradesColumnA = new List<CheckBox>();
        private List<CheckBox> m_gradesColumnB = new List<CheckBox>();
        private List<CheckBox> m_gradesColumnC = new List<CheckBox>();
        private List<CheckBox> m_relevantCheckBoxes = new List<CheckBox>();
        private List<RadioButton> m_radioButtonsList = new List<RadioButton>();

        //Constructors
        public AddTestResultsWin(Test test)
        {
            InitializeComponent();

            m_originalTest = test.Clone();
            m_targetTest = test.Clone();

            InitializeForm();
        }
        public AddTestResultsWin()
        {
            InitializeComponent();
        }

        //Methods
        private void InitializeForm()
        {
            InitializeCheckBoxes();
            InitializeTestFields();
        }
        private void InitializeTestFields()
        {
            Trainee trainee = BLTools.GetTraineeById(m_targetTest.TraineeId);

            dmvTb.Text = m_targetTest.DMV;
            InitializeTestCarTypeRadioButtons();
            traineeFirstNameTb.Text = trainee.FirstName;
            traineeLasatNameTb.Text = trainee.LastName;
            traineeIdTb.Text = trainee.Id;
            traineeCarTypeTb.Text = trainee.CarType.ToString();
            traineeDrivingSchoolTb.Text = m_targetTest.DrivingSchoolFullName;
            testDateTb.Text = m_targetTest.TestDateStringFormat;
            testTimeTb.Text = m_targetTest.TestTimeStringFormat;
            testLocationTb.Text = m_targetTest.TestLocation.ToString();
        }
        private void InitializeTestCarTypeRadioButtons()
        {
            FillRadioButtonsList();
            DisableAllRadioButtons();

            CarTypeEnum carType = m_targetTest.CarType;

            switch (carType)
            {
                case CarTypeEnum.None:
                    break;
                case CarTypeEnum.Private:
                    privateRb.IsChecked = true;
                    privateRb.IsEnabled = true;
                    break;
                case CarTypeEnum.Truck:
                    truckRb.IsChecked = true;
                    truckRb.IsEnabled = true;
                    break;
                case CarTypeEnum.Tractor:
                    tractorRb.IsChecked = true;
                    tractorRb.IsEnabled = true;
                    break;
                case CarTypeEnum.Motorcycle:
                    motorcycleRb.IsChecked = true;
                    motorcycleRb.IsEnabled = true;
                    break;
                case CarTypeEnum.Bus:
                    busRb.IsChecked = true;
                    busRb.IsEnabled = true;
                    break;
                default:
                    break;
            }
        }
        private void FillRadioButtonsList()
        {
            foreach (Control control in radioButtonsSp.Children)
            {
                if (control is RadioButton)
                {
                    if (control.Visibility == Visibility.Visible)
                    {
                        RadioButton rb = control as RadioButton;

                        m_radioButtonsList.Add(rb);
                    }
                }
            }
        }
        private void DisableAllRadioButtons()
        {
            foreach(RadioButton rb in m_radioButtonsList)
            {
                rb.IsEnabled = false;
            }
        }
        private void InitializeCheckBoxes()
        {
            FillAllCheckBoxesArrays();
            DisableUnrelevantCheckBoxes();
            FillRelevantCheckBoxes();
        }
        private void FillRelevantCheckBoxes()
        {
            foreach(CheckBox cb in m_gradesColumnA)
            {
                if (cb.IsEnabled == true)
                {
                    m_relevantCheckBoxes.Add(cb);
                }
            }

            foreach (CheckBox cb in m_gradesColumnB)
            {
                if (cb.IsEnabled == true)
                {
                    m_relevantCheckBoxes.Add(cb);
                }
            }

            foreach (CheckBox cb in m_gradesColumnC)
            {
                if (cb.IsEnabled == true)
                {
                    m_relevantCheckBoxes.Add(cb);
                }
            }
        }
        private void FillAllCheckBoxesArrays()
        {
            foreach (Control control in gradesSpA.Children)
            {
                if (control is CheckBox)
                {
                    if (control.Visibility == Visibility.Visible)
                    {
                        CheckBox cb = control as CheckBox;

                        m_gradesColumnA.Add(cb);
                    }
                }
            }

            foreach (Control control in gradesSpB.Children)
            {
                if (control is CheckBox)
                {
                    if (control.Visibility == Visibility.Visible)
                    {
                        CheckBox cb = control as CheckBox;

                        m_gradesColumnB.Add(cb);
                    }
                }
            }

            foreach (Control control in gradesSpC.Children)
            {
                if (control is CheckBox)
                {
                    if (control.Visibility == Visibility.Visible)
                    {
                        CheckBox cb = control as CheckBox;

                        m_gradesColumnC.Add(cb);
                    }
                }
            }
        }
        private void DisableUnrelevantCheckBoxes()
        {
            CarTypeEnum carType = m_targetTest.CarType;

            switch (carType)
            {
                case CarTypeEnum.None:
                    DisableAllCheckBoxes();
                    break;
                case CarTypeEnum.Private:
                    SetPrivateCarTypeCheckBoxes();
                    break;
                case CarTypeEnum.Truck:
                    SetHeavyCarTypeCheckBoxes();
                    break;
                case CarTypeEnum.Tractor:
                    SetHeavyCarTypeCheckBoxes();
                    break;
                case CarTypeEnum.Motorcycle:
                    SetMotorcycleCarTypeCheckBoxes();
                    break;
                case CarTypeEnum.Bus:
                    SetHeavyCarTypeCheckBoxes();
                    break;
                default:
                    DisableAllCheckBoxes();
                    break;
            }
        }
        private void SetPrivateCarTypeCheckBoxes()
        {
            //Column A
            DisableCheckBoxesRangeInColumn(m_gradesColumnA, 10, 21);

            //Column B
            DisableCheckBoxesRangeInColumn(m_gradesColumnB, 13, 19);

            //Column C
            DisableCheckBoxesRangeInColumn(m_gradesColumnC, 13, 15);
        }
        private void SetHeavyCarTypeCheckBoxes()
        {
            //Column A
            DisableCheckBoxesRangeInColumn(m_gradesColumnA, 0, 10);
            DisableCheckBoxesRangeInColumn(m_gradesColumnA, 15, 21);

            //Column B
            DisableCheckBoxesRangeInColumn(m_gradesColumnB, 0, 13);
            DisableCheckBoxesRangeInColumn(m_gradesColumnB, 15, 17);

            //Column C
            DisableCheckBoxesRangeInColumn(m_gradesColumnC, 0, 13);
        }
        private void SetMotorcycleCarTypeCheckBoxes()
        {
            //Column A
            DisableCheckBoxesRangeInColumn(m_gradesColumnA, 0, 15);

            //Column B
            DisableCheckBoxesRangeInColumn(m_gradesColumnB, 0, 15);
            DisableCheckBoxesRangeInColumn(m_gradesColumnB, 16, 19);

            //Column C
            DisableCheckBoxesRangeInColumn(m_gradesColumnC, 0, 15);
        }
        private void DisableAllCheckBoxes()
        {
            DisableCheckBoxesRangeInColumn(m_gradesColumnA, 0, 21);
            DisableCheckBoxesRangeInColumn(m_gradesColumnB, 0, 19);
            DisableCheckBoxesRangeInColumn(m_gradesColumnC, 0, 15);
        }
        private void DisableCheckBoxesRangeInColumn(List<CheckBox> checkBoxesList, 
                                                    int startIndex, int endIndex)
        {
            for (int i = startIndex; i < endIndex; ++i)
            {
                checkBoxesList[i].IsChecked = null;
                checkBoxesList[i].IsEnabled = false;
            }
        }
        private bool IsPassed()
        {
            int passedCriterions = 0;

            foreach(CheckBox cb in m_relevantCheckBoxes)
            {
                if (cb.IsChecked == true)
                {
                    ++passedCriterions;
                }
            }

            if (passedCriterions > m_relevantCheckBoxes.Count / 2)
            {
                return true;
            }

            return false;
        }
        private void TakeWinScreenShot()
        {
            ScreenCapture sc = new ScreenCapture();

            string path = @"../../../DATA/DataFiles/TestScreenCaptures/" + m_targetTest.TestIdStringFormat + ".jpg";

            sc.CaptureWindowToFile(new WindowInteropHelper(this).Handle, path, ImageFormat.Jpeg);
        }
        
        //Events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void TesterNotesRtb_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UITools.SendKey(Key.Back);
                testerNotesRtb.AppendText("\r");
                UITools.SendKey(Key.Down);
            }
        }

        //Changed Events
        private void TesterNotesRtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string richText = UITools.GetRichTextBoxText(testerNotesRtb);
            richText = richText.Trim();

            if (richText != "")
            {
                testerNotesHintLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                testerNotesHintLabel.Visibility = Visibility.Visible;
            }
        }

        //Click Events
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            m_targetTest.IsPassed = IsPassed();
            m_targetTest.TesterNotes = UITools.GetRichTextBoxText(testerNotesRtb);

            MessageBoxResult result = MessageBox.Show("Changes can't be undone\nProcceed?",
                                                      "Warning", MessageBoxButton.OKCancel,
                                                      MessageBoxImage.Question);

            if (result == MessageBoxResult.OK)
            {
                string error = m_Ibl.UpdateTest(m_targetTest.TestId, m_targetTest);

                if (error == null)
                {
                    MessageBox.Show("Success!", "Success", MessageBoxButton.OK,
                                                           MessageBoxImage.Information);
                    TakeWinScreenShot();
                    m_mainWin.MainFrame.Content = new TestEditPage();
                    Close();
                }
                else
                {
                    MessageBox.Show(error, "Error", MessageBoxButton.OK,
                                                           MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Changes have been canceled", "Operation Cancelled",
                                MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }
    }
}
