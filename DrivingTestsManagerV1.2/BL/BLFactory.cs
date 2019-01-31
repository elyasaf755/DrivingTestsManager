using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLFactory
    {
        private static IBl IBlInstance = null;

        protected BLFactory()
        {

        }

        public static IBl GetIBl()
        {
            if (IBlInstance == null)
            {
                IBlInstance = new BL_Class();
            }

            return IBlInstance;
        }
    }
}
