using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Configuration
    {
        public static int MinimalLessonsCount = 20;//Minimal lessons count before test.
        public static int MaximalTesterAge;
        public static int MinimalTesterAge = 40;
        public static int MaximalTraineeAge;
        public static int MinimalTraineeAge = 18;
        public static int MinimalDaysBetweenTests = 7;
        public static int TestsCount { get; set; }

        //Set to true for demo and debug only. Will skip certain validations like real id etc..
        public static bool IsDemoModeEnabled = true;
    }
}
