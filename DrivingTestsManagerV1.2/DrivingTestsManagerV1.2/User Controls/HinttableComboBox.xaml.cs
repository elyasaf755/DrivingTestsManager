using System;
using System.Collections.Generic;
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

namespace DrivingTestsManagerV1._2.User_Controls
{
    /// <summary>
    /// Interaction logic for HinttableComboBox.xaml
    /// </summary>
    public partial class HinttableComboBox : UserControl
    {
        //Event Handlers
        public event SelectionChangedEventHandler SelectionChanged
        {
            add { ComboBox.SelectionChanged += value; }
            remove { ComboBox.SelectionChanged -= value; }
        }
        public event EventHandler DropDownOpened
        {
            add { ComboBox.DropDownOpened += value; }
            remove { ComboBox.DropDownOpened -= value; }
        }
        public event EventHandler DropDownClosed
        {
            add { ComboBox.DropDownClosed += value; }
            remove { ComboBox.DropDownClosed -= value; }
        }
        public event TextChangedEventHandler TextChanged;

        //Private Members
        private string m_hint;

        //Properties
        public string Hint
        {
            get { return m_hint; }
            set
            {
                HintLabel.Content = value;
                m_hint = value;
            }
        }
        public object SelectedItem
        {
            get { return ComboBox.SelectedItem; }
        }
        public bool IsHintVisible
        {
            get { return HintLabel.Visibility == Visibility.Visible; }
        }
        public string Text
        {
            get { return ComboBox.Text; }
            set { ComboBox.Text = value; }
        }
        public bool IsFullyLoaded { get; set; }
        public bool IsDropDownOpen
        {
            get { return ComboBox.IsDropDownOpen; }
            set { ComboBox.IsDropDownOpen = value; }
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

        //Constructors
        public HinttableComboBox()
        {
            InitializeComponent();
            IsFullyLoaded = false;
        }

        //Private Methods
        private void ShowHint()
        {
            HintLabel.Visibility = Visibility.Visible;
        }
        private void HideHint()
        {
            HintLabel.Visibility = Visibility.Hidden;
        }

        //Events
        private void HinttableCb_DropDownOpened(object sender, EventArgs e)
        {
            HideHint();
        }
        private void HinttableCb_DropDownClosed(object sender, EventArgs e)
        {
            if (ComboBox.SelectedItem == null)
            {
                ShowHint();
            }
            else
            {
                HideHint();
            }
        }
        private void HinttableCb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ComboBox.SelectedItem == null)
            {
                ShowHint();
            }
        }
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (ComboBox.SelectedItem == null)
            {
                ShowHint();
            }
        }

        //Value Changed Events
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedItem == null)
            {
                ShowHint();
            }
            else
            {
                HideHint();
            }
        }
        private void ComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ComboBox.Text != "")
            {
                HintLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                HintLabel.Visibility = Visibility.Visible;
            }

            try
            {
                if (TextChanged == null)
                {
                    throw new Exception();
                }
                else
                {
                    TextChanged(sender, e);
                }
            }
            catch (Exception)
            {
                
            }
            
        }
    }
}
