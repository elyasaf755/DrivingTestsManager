using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalFactory
    {
        private static IDal IDalInstance = null;
        private static DAL_XAML_Imp IDalXamlInstance = null;

        protected DalFactory()
        {

        }

        public static IDal GetIDal()
        {
            if (IDalInstance == null)
            {
                IDalInstance = new DAL_Imp();
            }

            return IDalInstance;
        }
        public static IDal GetIDalXaml()
        {
            if (IDalXamlInstance == null)
            {
                IDalXamlInstance = new DAL_XAML_Imp();
            }

            return IDalXamlInstance;
        }
    }
}
