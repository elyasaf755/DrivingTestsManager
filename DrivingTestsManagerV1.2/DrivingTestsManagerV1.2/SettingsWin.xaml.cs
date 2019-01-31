using BE;
using BL;
using DrivingTestsManagerV1._2.User_Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DrivingTestsManagerV1._2
{
    /// <summary>
    /// Interaction logic for SettingsWin.xaml
    /// </summary>
    public partial class SettingsWin : Window
    {
        //Private Fields
        IBl m_IBl = BLFactory.GetIBl();

        //Properties
        public int ValidatorsCount { get; }
        public int ValidFieldsCount { get; set; }

        //Constructors
        public SettingsWin()
        {
            InitializeComponent();

            int validatorsCount = 0;
            int validFieldsCount = 0;
            GetValidatorsInfo(ref validatorsCount, ref validFieldsCount);
            ValidatorsCount = validatorsCount;
            ValidFieldsCount = validFieldsCount;

            RefreshForm();
        }

        //Methods
        private bool IsTwoDigitText(string str)
        {
            return Regex.IsMatch(str, @"^\d{1}$|^\d{2}$");
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

            foreach (Control control in configurationsGrid.Children)
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
        }
        private void RefreshForm()
        {
            minTraineeAgeTb.Text = Configuration.MinimalTraineeAge.ToString();
            maxTraineeAgeTb.Text = Configuration.MaximalTraineeAge.ToString();
            minDaysBetweenTestsTb.Text = Configuration.MinimalDaysBetweenTests.ToString();
            minTesterAgeTb.Text = Configuration.MinimalTesterAge.ToString();
            minLessonsTb.Text = Configuration.MinimalLessonsCount.ToString();
            maxTesterAge.Text = Configuration.MaximalTesterAge.ToString();
        }

        //Events
        private void MinTraineeAgeTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            minTraineeAgeTb.Validator.Validate(IsTwoDigitText(minTraineeAgeTb.Text));
            ValidateValidators();
        }
        private void MaxTraineeAgeTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            maxTraineeAgeTb.Validator.Validate(IsTwoDigitText(maxTraineeAgeTb.Text));
            ValidateValidators();
        }
        private void MinDaysBetweenTestsTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            minDaysBetweenTestsTb.Validator.Validate(IsTwoDigitText(minDaysBetweenTestsTb.Text));
            ValidateValidators();
        }
        private void MinTesterAgeTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            minTesterAgeTb.Validator.Validate(IsTwoDigitText(minTesterAgeTb.Text));
            ValidateValidators();
        }
        private void MinLessonsTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            minLessonsTb.Validator.Validate(IsTwoDigitText(minLessonsTb.Text));
            ValidateValidators();
        }
        private void MaxTesterAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            maxTesterAge.Validator.Validate(IsTwoDigitText(maxTesterAge.Text));
            ValidateValidators();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Change settings?", "Validation",
                                                      MessageBoxButton.OKCancel, 
                                                      MessageBoxImage.Question);
                                                
            if (result == MessageBoxResult.OK)
            {
                Configuration.MinimalTraineeAge = Convert.ToInt32(minTraineeAgeTb.Text);
                Configuration.MaximalTraineeAge = Convert.ToInt32(maxTraineeAgeTb.Text);
                Configuration.MinimalDaysBetweenTests = Convert.ToInt32(minDaysBetweenTestsTb.Text);
                Configuration.MinimalTesterAge = Convert.ToInt32(minTesterAgeTb.Text);
                Configuration.MinimalLessonsCount = Convert.ToInt32(minLessonsTb.Text);
                Configuration.MaximalTesterAge = Convert.ToInt32(maxTesterAge.Text);

                m_IBl.UpdateConfigurations();
            }
        }

        private void RestoreButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Restore default settigs?", "Validation",
                                                      MessageBoxButton.OKCancel,
                                                      MessageBoxImage.Question);

            if (result == MessageBoxResult.OK)
            {
                Configuration.MinimalTraineeAge = 18;
                Configuration.MaximalTraineeAge = 0;
                Configuration.MinimalDaysBetweenTests = 7;
                Configuration.MinimalTesterAge = 40;
                Configuration.MinimalLessonsCount = 20;
                Configuration.MaximalTesterAge = 0;

                m_IBl.UpdateConfigurations();
                RefreshForm();
            }
        }
    }
}
