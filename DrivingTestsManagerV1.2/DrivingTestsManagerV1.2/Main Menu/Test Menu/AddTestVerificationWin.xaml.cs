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

namespace DrivingTestsManagerV1._2.Main_Menu.Test_Menu
{
    /// <summary>
    /// Interaction logic for AddTestVerificationWin.xaml
    /// </summary>
    public partial class AddTestVerificationWin : Window
    {
        //Private Fields
        private IBl m_Ibl = BLFactory.GetIBl();
        private Test m_targetTest = new Test();
        private Tester m_targetTester = new Tester();
        private Trainee m_targetTrainee = new Trainee();
        private MainWindow m_mainWin = new MainWindow();

        //Constructors
        public AddTestVerificationWin()
        {
            InitializeComponent();
        }
        public AddTestVerificationWin(Test test)
        {
            m_targetTest = test.Clone();
            m_targetTester = BLTools.GetTesterById(m_targetTest.TesterId).Clone();
            m_targetTrainee = BLTools.GetTraineeById(m_targetTest.TraineeId).Clone();

            InitializeComponent();
        }

        //Events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            traineeDetailsTb.Text = string.Format("Id: {0}, {1}", m_targetTest.TraineeId, m_targetTrainee.GetName());
            testerDetailsTb.Text = string.Format("Id: {0}, {1}", m_targetTester.Id, m_targetTester.GetName());
            testDetailsTb.Text = string.Format("Testing for {0} (Car Type) \nat {1}  \non {2}",
                                                m_targetTest.CarType,
                                                m_targetTest.TestLocation,
                                                m_targetTest.TestDateAndTime);

            m_mainWin = UIFactory.GetMainWin();
        }
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        //Close Button Events
        private void LoginCloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void LoginCloseButton_MouseEnter(object sender, MouseEventArgs e)
        {
            closeIcon.Foreground = Brushes.White;
        }
        private void LoginCloseButton_MouseLeave(object sender, MouseEventArgs e)
        {
            closeIcon.Foreground = Brushes.Black;
        }

        //Click Events
        private void AddTestButton_Click(object sender, RoutedEventArgs e)
        {
            string error = m_Ibl.AddTest(m_targetTest);

            if (error == null)
            {
                MessageBox.Show("Test have been added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();

                m_mainWin.MainFrame.Content = new TestEditPage();
            }
            else
            {
                MessageBox.Show(string.Format("Couldn't add this test.\nPlease Recheck the thest's details or contact the application manager"), "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
