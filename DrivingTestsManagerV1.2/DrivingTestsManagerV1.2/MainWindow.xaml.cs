using DrivingTestsManagerV1._2.Main_Menu.Home_Menu;
using DrivingTestsManagerV1._2.Main_Menu.Tester_Menu;
using DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu;
using DrivingTestsManagerV1._2.Main_Menu.Test_Menu;
using DrivingTestsManagerV1._2.User_Controls;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using BL;
using BE;



//ToDo: Upon left click remove all selected items from left grid
namespace DrivingTestsManagerV1._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Private Fields
        private List<Storyboard> storyboardList = new List<Storyboard>();
        private List<bool> isMenuOpenList = new List<bool>();

        //Properties
        public AccessLevelEnum AccessLevel { get; set; }

        //Constructors
        internal MainWindow()
        {
            InitializeComponent();
            Initilization();
        }

        //Methods
        private void Initilization()
        {
            //Menu = 0.HomeMenu = 1.AddMenu = 2.EditMenu = 3.DeleteMenu = 4.
            for (int i = 0; i < 5; ++i)
            {
                isMenuOpenList.Add(false);
            }

            InitializeStoryboards();
        }
        private void InitializeStoryboards()
        {
            //Menu = 0.HomeMenu = 1.AddMenu = 2.EditMenu = 3.DeleteMenu = 4.
            storyboardList.Add(FindResource("MenuClose") as Storyboard);
            storyboardList.Add(FindResource("HomeMenuClose") as Storyboard);
            storyboardList.Add(FindResource("TesterMenuClose") as Storyboard);
            storyboardList.Add(FindResource("TraineeMenuClose") as Storyboard);
            storyboardList.Add(FindResource("TestMenuClose") as Storyboard);
        }

        //MainWindow Events
        private void MyMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UIFactory.InitializeMainWin(this);
        }
        private void MyMainWindow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllLeftOpenMenus();
        }
        private void MyMainWindow_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllLeftOpenMenus();
        }

        //Upper Grid Events And Functions//
        /// <summary>
        /// Draggable Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Header_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Red Close Button Events
        private void CloseIconItem_MouseEnter(object sender, MouseEventArgs e)
        {
            CloseIcon.Foreground = Brushes.White;
            CloseIconItem.Background = Brushes.Red;
        }
        private void CloseIconItem_MouseLeave(object sender, MouseEventArgs e)
        {
            CloseIcon.Foreground = Brushes.Black;
            Color color = (Color)ColorConverter.ConvertFromString("#FF00AEFF");
            SolidColorBrush UpperPannelBrush = new SolidColorBrush(color);
            CloseIconItem.Background = UpperPannelBrush;
        }
        private void CloseIconItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Left grid event and functions functions.//
        /// <summary>
        /// Will close all open menus in the left grid except for the one that is currently opening.
        /// The menu that is currently opening is known by the "index" variable.
        /// </summary>
        /// <param name="index">Menu = 0. HomeMenu = 1. AddMenu = 2. EditMenu = 3. DeleteMenu = 4. Close all open menus = else (-1 by default).</param>
        private void CloseAllLeftOpenMenus(int index = -1)
        {
            for (int i = 0; i < 5; ++i)
            {
                if (i != index)
                {
                    if (isMenuOpenList[i] == true)
                    {
                        storyboardList[i].Begin();

                        if (i == 0)
                        {
                            CloseMenu();
                        }
                        else if (i == 1)
                        {
                            CloseHomeMenu();
                        }
                        else if (i == 2)
                        {
                            CloseTesterMenu();
                        }
                        else if (i == 3)
                        {
                            CloseTraineeMenu();
                        }
                        else if (i == 4)
                        {
                            CloseTestsMenu();
                        }
                    }
                }
            }
        }

        //Main Menu click events and functions.
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            CloseAllLeftOpenMenus(0);
            OpenMenu();
        }
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
        }
        private void OpenMenu()
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
            isMenuOpenList[0] = true;
        }
        private void CloseMenu()
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            isMenuOpenList[0] = false;
        }

        //Home Menu click events and functions.
        private void ButtonOpenHomeMenu_Click(object sender, RoutedEventArgs e)
        {
            CloseAllLeftOpenMenus(1);
            OpenHomeMenu();
        }
        private void ButtonCloseHomeMenu_Click(object sender, RoutedEventArgs e)
        {
            CloseHomeMenu();
        }
        private void OpenHomeMenu()
        {
            ButtonOpenHomeMenu.Visibility = Visibility.Collapsed;
            ButtonCloseHomeMenu.Visibility = Visibility.Visible;
            isMenuOpenList[1] = true;
        }
        private void CloseHomeMenu()
        {
            ButtonOpenHomeMenu.Visibility = Visibility.Visible;
            ButtonCloseHomeMenu.Visibility = Visibility.Collapsed;
            isMenuOpenList[1] = false;
        }
        private void ShowTestersItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllLeftOpenMenus();
            MainFrame.Content = new TesterEditPage();
        }

        //Tester Menu click events and functions.
        private void ButtonOpenTesterMenu_Click(object sender, RoutedEventArgs e)
        {
            CloseAllLeftOpenMenus(2);
            OpenTesterMenu();
        }
        private void ButtonCloseAddMenu_Click(object sender, RoutedEventArgs e)
        {
            CloseTesterMenu();
        }
        private void OpenTesterMenu()
        {
            ButtonOpenTesterMenu.Visibility = Visibility.Collapsed;
            ButtonCloseAddMenu.Visibility = Visibility.Visible;
            isMenuOpenList[2] = true;
        }
        private void CloseTesterMenu()
        {
            ButtonOpenTesterMenu.Visibility = Visibility.Visible;
            ButtonCloseAddMenu.Visibility = Visibility.Collapsed;
            isMenuOpenList[2] = false;
        }
        private void AddTesterItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new TesterAddPage();
        }
        private void ShowAllTestersItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllLeftOpenMenus();
            MainFrame.Content = new TesterEditPage();
        }

        //Trainee Menu click events and functions.
        private void ButtonOpenTraineeMenu_Click(object sender, RoutedEventArgs e)
        {
            CloseAllLeftOpenMenus(3);
            OpenTraineeMenu();
        }
        private void ButtonCloseTraineeMenu_Click(object sender, RoutedEventArgs e)
        {
            CloseTraineeMenu();
        }
        private void OpenTraineeMenu()
        {
            ButtonOpenTraineeMenu.Visibility = Visibility.Collapsed;
            ButtonCloseTraineeMenu.Visibility = Visibility.Visible;
            isMenuOpenList[3] = true;
        }
        private void CloseTraineeMenu()
        {
            ButtonOpenTraineeMenu.Visibility = Visibility.Visible;
            ButtonCloseTraineeMenu.Visibility = Visibility.Collapsed;
            isMenuOpenList[3] = false;
        }
        private void AddTraineeItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new TraineeAddPage();
        }
        private void ShowAllTraineesItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new TraineeEditPage();
        }


        //Test Menu click events and functions.
        private void ButtonOpenTestMenu_Click(object sender, RoutedEventArgs e)
        {
            CloseAllLeftOpenMenus(4);
            OpenTestsMenu();
        }
        private void ButtonCloseTestMenu_Click(object sender, RoutedEventArgs e)
        {
            CloseTestsMenu();
        }
        private void OpenTestsMenu()
        {
            ButtonOpenTestMenu.Visibility = Visibility.Collapsed;
            ButtonCloseTestMenu.Visibility = Visibility.Visible;
            isMenuOpenList[4] = true;
        }
        private void CloseTestsMenu()
        {
            ButtonOpenTestMenu.Visibility = Visibility.Visible;
            ButtonCloseTestMenu.Visibility = Visibility.Collapsed;
            isMenuOpenList[4] = false;
        }
        private void AddTestItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //ToDo: Del
            //MainFrame.Content = new TestAddPage();
        }
        private void FindFreeTesterItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new PotentialTestersView();
        }
        private void ShowTests_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new TestEditPage();
        }

        private void ShowAllTestsItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new TestEditPage();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWin win = new SettingsWin();
            win.ShowDialog();
        }

        private void ShowTrainees_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new TraineeEditPage();
        }

    }
}
