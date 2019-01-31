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
    /// Interaction logic for WorkTimeControl.xaml
    /// </summary>
    public partial class WorkTimeControl : UserControl
    {
        //Event Handlers
        public event RoutedEventHandler SelectionChanged
        {
            add { MyWorkTimeTable.SelectionChanged += value; }
            remove { MyWorkTimeTable.SelectionChanged -= value; }
        }

        //Properties
        public bool[,] WorkTime { get { return MyWorkTimeTable.WorkTime; } }
        public bool IsReadOnly
        {
            get { return MyWorkTimeTable.IsReadOnly; }
            set
            {
                MyWorkTimeTable.IsReadOnly = value;
            }
        }

        //Read Only Properties
        private double m_heightProportion
        {
            get { return ActualHeight / SuggestedMinHeigt; }
        }
        private double m_widthProportion
        {
            get { return ActualWidth / SuggestedMinWidth; }
        }
        private readonly int m_fontSize = 7;
        public int SuggestedMinHeigt { get { return 190; } }
        public int SuggestedMinWidth { get { return 255; } }

        //Constructors
        public WorkTimeControl()
        {
            InitializeComponent();
        }
        
        //Methods
        /// <summary>
        /// Will stretch the labels' text's FontSize proportionally to the control's size.
        /// </summary>
        public void TextStretcher()
        {
            foreach (Label label in HoursGrid.Children)
            {
                if (double.IsNaN(FindMinProportion()) == true)
                    break;

                label.FontSize = m_fontSize * FindMinProportion();
            }
            foreach(Label label in DaysGrid.Children)
            {
                if (double.IsNaN(FindMinProportion()) == true)
                    break;

                label.FontSize = m_fontSize * FindMinProportion();
            }
        }
        public void ClearTable()
        {
            MyWorkTimeTable.ClearTable();
        }
        private double FindMinProportion()
        {
            return m_heightProportion < m_widthProportion ? m_heightProportion : m_widthProportion;
        }

        //Events
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TextStretcher();
        }
    }
}
