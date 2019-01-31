using System;
using System.Collections.Generic;
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

namespace DrivingTestsManagerV1._2.User_Controls
{
    /// <summary>
    /// Interaction logic for HinttableDatePicker.xaml
    /// </summary>
    public partial class HinttableDatePicker : UserControl
    {
        //Event Handlers
        public event EventHandler<SelectionChangedEventArgs> SelectedDateChanged
        {
            add { DatePicker.SelectedDateChanged += value; }
            remove { DatePicker.SelectedDateChanged -= value; }
        }

        //Properties
        public string Hint
        {
            get { return HintLabel.Content.ToString(); }
            set
            {
                HintLabel.Content = value;
            }
        }
        public bool IsValidatorVisible
        {
            get { return Validator.Visibility == Visibility.Visible; }
            set
            {
                if (value == true)
                {
                    Validator.Visibility = Visibility.Visible;
                }
                else
                {
                    Validator.Visibility = Visibility.Hidden;
                }
            }
        }

        //Read Only Properties
        public DateTime? SelectedDate { get { return DatePicker.SelectedDate; } }

        //Constructors
        public HinttableDatePicker()
        {
            InitializeComponent();
            
        }

        //Methods
        public void GetFocus()
        {
            HintLabel.Visibility = System.Windows.Visibility.Hidden;
        }
        public void LoseFocus(HinttableDatePicker hinttableDp)
        {
            DateTime temp;

            if (DateTime.TryParse(DatePicker.Text, out temp) == false)
            {
                DatePicker.Text = "";
                HintLabel.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void MyDatePickerBehaviour()
        {
            if (DatePicker.IsFocused == false)
            {
                LoseFocus(this);
            }
        }
        private void SendKey(Key key)
        {
            if (Keyboard.PrimaryDevice != null)
            {
                if (Keyboard.PrimaryDevice.ActiveSource != null)
                {
                    var ea = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key)
                    {
                        RoutedEvent = Keyboard.KeyDownEvent
                    };
                    InputManager.Current.ProcessInput(ea);
                }
            }
        }

        //Events
        private void DatePicker_GotFocus(object sender, RoutedEventArgs e)
        {
            GetFocus();
        }
        private void DatePicker_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            GetFocus();
        }
        private void DatePicker_LostFocus(object sender, RoutedEventArgs e)
        {
            LoseFocus(this);
        }
        private void DatePicker_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            LoseFocus(this);
        }
        private void DatePicker_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DatePicker.Text == "")
            {
                HintLabel.Visibility = Visibility.Visible;
            }
            else
            {
                HintLabel.Visibility = Visibility.Hidden;
            }
        }
    }
}
