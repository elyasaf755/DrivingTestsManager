using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DrivingTestsManagerV1._2.Main_Menu.Home_Menu
{
    /// <summary>
    /// Interaction logic for ShowAllTestersPage.xaml
    /// </summary>
    public partial class ShowAllTestersPage : Page
    {
        private IBl m_Ibl = BLFactory.GetIBl();

        public ObservableCollection<Tester> Collection { get; set; }
        public List<Tester> TestersList { get; set; }

        public ShowAllTestersPage()
        {
            Collection = new ObservableCollection<Tester>();
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Collection.Clear();
            TestersList = m_Ibl.GetAllTesters();

            foreach(Tester tester in TestersList)
            {
                Collection.Add(tester);
            }
        }
    }
}
