using BE;
using BL;
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
using System.Windows.Shapes;

namespace DrivingTestsManagerV1._2.Main_Menu.Home_Menu
{
    /// <summary>
    /// Interaction logic for LoginWin.xaml
    /// </summary>
    public partial class LoginWin : Window
    {
        //Private Fields
        private IBl m_Ibl = BLFactory.GetIBl();
        private MainWindow m_mainWin = UIFactory.GetMainWin();
        
        //Constructors
        public LoginWin()
        {
            InitializeComponent();
        }

        //Events
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        //Close Button Events
        private void LoginCloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            UIFactory.GetMainWin().Close();
        }
        private void LoginCloseButton_MouseEnter(object sender, MouseEventArgs e)
        {
            closeIcon.Foreground = Brushes.White;
        }
        private void LoginCloseButton_MouseLeave(object sender, MouseEventArgs e)
        {
            closeIcon.Foreground = Brushes.Black;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passwordPb.Password != "")
            {
                passwordHintLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                passwordHintLabel.Visibility = Visibility.Visible;
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            AccessLevelEnum accessLevel = BlValidations.IsLoginValid(idTb.Text, passwordPb.Password);

            if (accessLevel == AccessLevelEnum.DeniedAccess)
            {
                MessageBox.Show("Wrong Details");
            }

            m_mainWin.AccessLevel = accessLevel;
            Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
