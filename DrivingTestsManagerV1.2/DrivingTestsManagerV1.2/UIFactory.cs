using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingTestsManagerV1._2
{
    public class UIFactory
    {
        //Private Fields
        private static MainWindow MainWin = null;

        //Constructors
        protected UIFactory()
        {

        }

        //Initializers
        public static void InitializeMainWin(MainWindow mainWin)
        {
            if (MainWin == null)
            {
                MainWin = mainWin;
            }
        }

        //Gettres
        public static MainWindow GetMainWin()
        {
            return MainWin;
        }
    }
}
