using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Xml;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using GMap.NET.WindowsPresentation;
using GMap.NET.MapProviders;

namespace BL
{
    //ToDo: Del this class?
    public static class BlGroupAndFilter
    {
        public static List<string> AllStringsStartsWith(List<string> strList, string subStr)
        {
            IEnumerable<string> result = from str in strList
                                         where IsStringStartsWith(str, subStr) == true
                                         select str;

            return result.ToList<string>();
        }
        private static bool IsStringStartsWith(string str, string subStr)
        {
            int count = 0;
            for (int i = 0; i < Math.Min(subStr.Length, str.Length); ++i)
            {
                if (subStr[i] == str[i])
                {
                    ++count;
                }
            }

            return count == subStr.Length;
        }
    }
}
