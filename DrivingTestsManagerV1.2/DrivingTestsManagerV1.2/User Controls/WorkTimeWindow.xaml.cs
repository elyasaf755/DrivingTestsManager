using BE;
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

namespace DrivingTestsManagerV1._2.User_Controls
{
    /// <summary>
    /// Interaction logic for WorkTimeWindow.xaml
    /// </summary>
    public partial class WorkTimeWindow : Window
    {
        //Properties
        public bool[,] WorkTime
        {
            get { return MyWorkTimeControl.WorkTime; }
            set
            {
                MyWorkTimeControl.MyWorkTimeTable.WorkTime = value;
            }
        }
        public bool IsReadOnly
        {
            get { return MyWorkTimeControl.IsReadOnly; }
            set { MyWorkTimeControl.IsReadOnly = value; }
        }

        //Constructors
        public WorkTimeWindow(Tester tester)
        {
            InitializeComponent();

            Title = string.Format("{0}'s Work Time", tester.FirstName);

            WorkTime = (bool[,])tester.WorkTime.Clone();
            MyWorkTimeControl.MyWorkTimeTable.SetTable(WorkTime);
        }

        //Events
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MyWorkTimeControl.TextStretcher();
        }
    }
}
