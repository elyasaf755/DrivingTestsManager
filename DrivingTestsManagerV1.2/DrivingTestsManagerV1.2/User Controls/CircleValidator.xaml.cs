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
    /// Interaction logic for CircleValidator.xaml
    /// </summary>
    public partial class CircleValidator : UserControl
    {
        public CircleValidator()
        {
            InitializeComponent();
        }

        public void Validate(bool condition)
        {
            if (condition == true)
            {
                MyCircle.Foreground = Brushes.Green;
                MyCircle.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircle;
            }
            else
            {
                MyCircle.Foreground = Brushes.Red;
                MyCircle.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircle;
            }
        }
    }
}
