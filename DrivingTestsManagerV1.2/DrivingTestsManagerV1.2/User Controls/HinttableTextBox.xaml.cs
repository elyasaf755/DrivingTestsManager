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
    /// Interaction logic for HinttableTextBox.xaml
    /// </summary>
    public partial class HinttableTextBox : UserControl
    {
        public event TextChangedEventHandler TextChanged
        {
            add { TextBox.TextChanged += value; }
            remove { TextBox.TextChanged -= value; }
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
        public string Text
        {
            get { return TextBox.Text; }
            set
            {
                TextBox.Text = value;
            }
        }
        public bool IsHintVisible
        {
            get { return HintLabel.Visibility == Visibility.Visible; }
            set
            {
                if (value == true)
                {
                    HintLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    HintLabel.Visibility = Visibility.Hidden;
                }
            }
        }
        public bool IsSearchEnabled { get; set; }
        public bool IsValidatorVisible
        {
            get { return Validator.Visibility == Visibility.Visible ? true : false; }
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
        public int MaxLengeth
        {
            get { return TextBox.MaxLength; }
            set { TextBox.MaxLength = value; }
        }
        public TextWrapping TextWrapping
        {
            get { return TextBox.TextWrapping; }
            set
            {
                TextBox.TextWrapping = value;
            }
        }

        //Constructors
        public HinttableTextBox()
        {
            InitializeComponent();
            IsSearchEnabled = false;
        }

        //Methods
        public void LoseFocus(HinttableTextBox hinttableTb)
        {
            if (hinttableTb.TextBox.Text == "")
            {
                HintLabel.Visibility = Visibility.Visible;
            }
        }
        private void TextBoxBehaviour()
        {
            if (TextBox.Text == "")
            {
                HintLabel.Visibility = Visibility.Visible;
            }
            else
            {
                HintLabel.Visibility = Visibility.Hidden;
            }
        }

        //Events
        //ToDo: Add descriptions To All Events in All Files
        private void TextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBoxBehaviour();
            SelectivelyIgnoreMouseButton(sender, e);
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBoxBehaviour();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxBehaviour();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxBehaviour();
        }
        private void TextBox_GotKeyboardFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb != null)
            {
                tb.SelectAll();
            }
        }
        private void SelectivelyIgnoreMouseButton(object sender, MouseButtonEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb != null)
            {
                if (!tb.IsKeyboardFocusWithin)
                {
                    e.Handled = true;
                    tb.Focus();
                }
            }
        }
    }
}
