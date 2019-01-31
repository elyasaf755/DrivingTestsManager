using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace DrivingTestsManagerV1._2
{
    public static class UITools
    {
        public static void SendKey(Key key)
        {
            if (Keyboard.PrimaryDevice != null)
            {
                if (Keyboard.PrimaryDevice.ActiveSource != null)
                {
                    var ea = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key)
                    {
                        RoutedEvent = Keyboard.KeyDownEvent
                    };
                    InputManager.Current.ProcessInput(ea);
                }
            }
        }
        public static string GetRichTextBoxText(RichTextBox rtb)
        {
            return new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text;
        }
        
        //ToDo: Demo of Func use. Del this later.
        private static void PrintAllTesters()
        {
            List<Tester> testersList = BLFactory.GetIBl().GetAllTesters();
            Func<Tester, string> selector = tester => string.Format("{0} - {1}", tester.Id, tester.GetName());
            IEnumerable<string> namesAndIds = testersList.Select(selector);
            
            foreach(string str in namesAndIds)
            {
                Console.WriteLine(str);
            }
        }
    }
}
