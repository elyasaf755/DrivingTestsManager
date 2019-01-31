using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for WorkTimeTable.xaml
    /// </summary>
    public partial class WorkTimeTable : UserControl
    {
        private bool m_isReadOnly;

        public bool[,] WorkTime { get; set; } = new bool[5, 7];
        public bool IsReadOnly
        {
            get { return m_isReadOnly; }
            set
            {
                m_isReadOnly = value;

                if (value == true)
                {
                    foreach(Button button in WorkTimeTableGrid.Children)
                    {
                        Button btn = button;

                        btn.IsEnabled = false;
                    }
                }
                else
                {
                    foreach (Button button in WorkTimeTableGrid.Children)
                    {
                        Button btn = button;

                        btn.IsEnabled = true;
                    }
                }
            }
        }

        public event RoutedEventHandler SelectionChanged;

        //Constructors
        public WorkTimeTable()
        {
            InitializeComponent();
        }
        
        //Methods
        private void ButtonClickBehavior(ref Button button,ref PackIcon icon, ref bool flag)
        {
            if (button.Background == Brushes.Red)
            {
                button.Background = Brushes.Green;
                icon.Kind = PackIconKind.Check;
                flag = true;
            }
            else if (button.Background == Brushes.Green)
            {
                button.Background = Brushes.Red;
                icon.Kind = PackIconKind.Close;
                flag = false;
            }
        }
        private void SetButton(ref Button button, ref PackIcon icon, bool flag)
        {
            if (flag == true)
            {
                button.Background = Brushes.Green;
                icon.Kind = PackIconKind.Check;
            }
            else
            {
                button.Background = Brushes.Red;
                icon.Kind = PackIconKind.Close;
            }
        }
        public void ClearTable()
        {
            WorkTime = new bool[5, 7];
            foreach (Button button in WorkTimeTableGrid.Children)
            {
                Button btn = button as Button;
                PackIcon icon = new PackIcon();

                bool flag = true;

                if (btn.Background == Brushes.Green)
                {
                    ButtonClickBehavior(ref btn, ref icon, ref flag);
                    SelectionChanged(btn, null);
                }
            }
        }
        public void SetTable(bool[,] workTime)
        {
            ClearTable();
            WorkTime = workTime;


            int i = 0;
            int j = 0;
            foreach (Button btn in WorkTimeTableGrid.Children)
            {
                Button button = btn as Button;
                PackIcon icon = new PackIcon();
                bool flag = WorkTime[i, j];
                switch (button.Name)
                {
                    case "Sun9":
                        icon = Sun9Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[0, 0] = flag;
                        break;
                    case "Sun10":
                        icon = Sun10Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[0, 1] = flag;
                        break;
                    case "Sun11":
                        icon = Sun11Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[0, 2] = flag;
                        break;
                    case "Sun12":
                        icon = Sun12Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[0, 3] = flag;
                        break;
                    case "Sun13":
                        icon = Sun13Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[0, 4] = flag;
                        break;
                    case "Sun14":
                        icon = Sun14Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[0, 5] = flag;
                        break;
                    case "Sun15":
                        icon = Sun15Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[0, 6] = flag;
                        break;

                    case "Mon9":
                        icon = Mon9Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[1, 0] = flag;
                        break;
                    case "Mon10":
                        icon = Mon10Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[1, 1] = flag;
                        break;
                    case "Mon11":
                        icon = Mon11Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[1, 2] = flag;
                        break;
                    case "Mon12":
                        icon = Mon12Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[1, 3] = flag;
                        break;
                    case "Mon13":
                        icon = Mon13Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[1, 4] = flag;
                        break;
                    case "Mon14":
                        icon = Mon14Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[1, 5] = flag;
                        break;
                    case "Mon15":
                        icon = Mon15Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[1, 6] = flag;
                        break;

                    case "Tue9":
                        icon = Tue9Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[2, 0] = flag;
                        break;
                    case "Tue10":
                        icon = Tue10Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[2, 1] = flag;
                        break;
                    case "Tue11":
                        icon = Tue11Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[2, 2] = flag;
                        break;
                    case "Tue12":
                        icon = Tue12Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[2, 3] = flag;
                        break;
                    case "Tue13":
                        icon = Tue13Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[2, 4] = flag;
                        break;
                    case "Tue14":
                        icon = Tue14Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[2, 5] = flag;
                        break;
                    case "Tue15":
                        icon = Tue15Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[2, 6] = flag;
                        break;

                    case "Wed9":
                        icon = Wed9Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[3, 0] = flag;
                        break;
                    case "Wed10":
                        icon = Wed10Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[3, 1] = flag;
                        break;
                    case "Wed11":
                        icon = Wed11Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[3, 2] = flag;
                        break;
                    case "Wed12":
                        icon = Wed12Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[3, 3] = flag;
                        break;
                    case "Wed13":
                        icon = Wed13Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[3, 4] = flag;
                        break;
                    case "Wed14":
                        icon = Wed14Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[3, 5] = flag;
                        break;
                    case "Wed15":
                        icon = Wed15Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[3, 6] = flag;
                        break;

                    case "Thu9":
                        icon = Thu9Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[4, 0] = flag;
                        break;
                    case "Thu10":
                        icon = Thu10Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[4, 1] = flag;
                        break;
                    case "Thu11":
                        icon = Thu11Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[4, 2] = flag;
                        break;
                    case "Thu12":
                        icon = Thu12Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[4, 3] = flag;
                        break;
                    case "Thu13":
                        icon = Thu13Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[4, 4] = flag;
                        break;
                    case "Thu14":
                        icon = Thu14Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[4, 5] = flag;
                        break;
                    case "Thu15":
                        icon = Thu15Icon;
                        SetButton(ref button, ref icon, flag);
                        WorkTime[4, 6] = flag;
                        break;

                    default:
                        break;
                }
                ++j;
                if (j == 7)
                {
                    j = 0;
                    ++i;
                }
                if (i == 5)
                {
                    break;
                }
            }
        }

        //Events
        private void Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            PackIcon icon = new PackIcon();

            bool flag = false;

            switch (button.Name)
            {
                case "Sun9":
                    icon = Sun9Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[0, 0] = flag;
                    break;
                case "Sun10":
                    icon = Sun10Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[0, 1] = flag;
                    break;
                case "Sun11":
                    icon = Sun11Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[0, 2] = flag;
                    break;
                case "Sun12":
                    icon = Sun12Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[0, 3] = flag;
                    break;
                case "Sun13":
                    icon = Sun13Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[0, 4] = flag;
                    break;
                case "Sun14":
                    icon = Sun14Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[0, 5] = flag;
                    break;
                case "Sun15":
                    icon = Sun15Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[0, 6] = flag;
                    break;

                case "Mon9":
                    icon = Mon9Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[1, 0] = flag;
                    break;
                case "Mon10":
                    icon = Mon10Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[1, 1] = flag;
                    break;
                case "Mon11":
                    icon = Mon11Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[1, 2] = flag;
                    break;
                case "Mon12":
                    icon = Mon12Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[1, 3] = flag;
                    break;
                case "Mon13":
                    icon = Mon13Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[1, 4] = flag;
                    break;
                case "Mon14":
                    icon = Mon14Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[1, 5] = flag;
                    break;
                case "Mon15":
                    icon = Mon15Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[1, 6] = flag;
                    break;

                case "Tue9":
                    icon = Tue9Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[2, 0] = flag;
                    break;
                case "Tue10":
                    icon = Tue10Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[2, 1] = flag;
                    break;
                case "Tue11":
                    icon = Tue11Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[2, 2] = flag;
                    break;
                case "Tue12":
                    icon = Tue12Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[2, 3] = flag;
                    break;
                case "Tue13":
                    icon = Tue13Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[2, 4] = flag;
                    break;
                case "Tue14":
                    icon = Tue14Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[2, 5] = flag;
                    break;
                case "Tue15":
                    icon = Tue15Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[2, 6] = flag;
                    break;

                case "Wed9":
                    icon = Wed9Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[3, 0] = flag;
                    break;
                case "Wed10":
                    icon = Wed10Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[3, 1] = flag;
                    break;
                case "Wed11":
                    icon = Wed11Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[3, 2] = flag;
                    break;
                case "Wed12":
                    icon = Wed12Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[3, 3] = flag;
                    break;
                case "Wed13":
                    icon = Wed13Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[3, 4] = flag;
                    break;
                case "Wed14":
                    icon = Wed14Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[3, 5] = flag;
                    break;
                case "Wed15":
                    icon = Wed15Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[3, 6] = flag;
                    break;

                case "Thu9":
                    icon = Thu9Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[4, 0] = flag;
                    break;
                case "Thu10":
                    icon = Thu10Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[4, 1] = flag;
                    break;
                case "Thu11":
                    icon = Thu11Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[4, 2] = flag;
                    break;
                case "Thu12":
                    icon = Thu12Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[4, 3] = flag;
                    break;
                case "Thu13":
                    icon = Thu13Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[4, 4] = flag;
                    break;
                case "Thu14":
                    icon = Thu14Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[4, 5] = flag;
                    break;
                case "Thu15":
                    icon = Thu15Icon;
                    ButtonClickBehavior(ref button, ref icon, ref flag);
                    WorkTime[4, 6] = flag;
                    break;

                default:
                    break;
            }

            SelectionChanged(sender, null);
        }
    }
}