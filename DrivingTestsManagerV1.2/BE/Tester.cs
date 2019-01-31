using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Tester : Person
    {
        public int YearsOfExperience { get; set; }
        public int MaximalWeeklyTests { get; set; }
        public CarTypeEnum CarType { get; set; }
        public bool[,] WorkTime { get; set; }//5x7 sized Matrix. 5 days, 7 hours. Working Hours: 9:00 - 16:00 (excluded)
        public int MaximalDistance { get; set; }

        //Added properties
        public int WeeklyTestsCount { get; set; }
        public List<ScheduleStruct> ScheduleList { get; set; } = new List<ScheduleStruct>();

        //Overrides
        public override string ToString()
        {
            return base.ToString() + "\n"
                + "Years of Experience: " + YearsOfExperience + "\n"
                + "Maximal Weekly Tests: " + MaximalWeeklyTests + "\n"
                + "Car Type: " + CarType + "\n"
                + "Work Time: " + "\n" + GetWorkTime() + "\n"
                + "Maximal Distance: " + MaximalDistance + "\n";
        }

        //Constructors
        public Tester(string id, string lastName, string firstName, MyDate dateOfBirth, 
                      GenderEnum gender, string phoneNumber, AddressStruct address, 
                      string emailAddress, int yearsOfExperience, int maximalWeeklylTests, 
                      CarTypeEnum carType, bool[,] workTime, int maximalDistance, 
                      int weeklyTestsCount, List<ScheduleStruct> scheduleList)
                       : base(id, lastName, firstName, dateOfBirth, gender, phoneNumber, address, emailAddress)
        {
            YearsOfExperience = yearsOfExperience;
            MaximalWeeklyTests = maximalWeeklylTests;
            CarType = carType;
            WorkTime = workTime;
            MaximalDistance = maximalDistance;
            WeeklyTestsCount = 0;

            foreach(ScheduleStruct schedule in scheduleList)
            {
                ScheduleList.Add(schedule);
            }
        }

        public Tester(Tester tester):base(tester.Id, tester.LastName, tester.FirstName, tester.DateOfBirth,
                                          tester.Gender, tester.PhoneNumber, tester.Address, tester.EmailAddress)
        {
            YearsOfExperience = tester.YearsOfExperience;
            MaximalWeeklyTests = tester.MaximalWeeklyTests;
            CarType = tester.CarType;
            WorkTime = (bool[,])tester.WorkTime.Clone();
            MaximalDistance = tester.MaximalDistance;
            WeeklyTestsCount = tester.WeeklyTestsCount;

            foreach(ScheduleStruct schedule in tester.ScheduleList)
            {
                ScheduleList.Add(schedule);
            }
        }
        public Tester()
        {

        }

        //Methods
        /// <summary>
        /// Returns a string format of the tester's work time over the week
        /// </summary>
        /// <returns></returns>
        private string GetWorkTime()
        {
            //Console.WriteLine(" Sun |" + " Mon |" + " Tue |" + " Wed |" + " Thu ");
            string str = "     | 09:00 | 10:00 | 11:00 | 12:00 | 13:00 | 14:00 | 15:00 |\n" +
                         "-----|-------|-------|-------|-------|-------|-------|-------|\n";
            for (int i = 0; i < 5; ++i)
            {
                #region//Day conditions.
                string day = "";
                if (i == 0) day = "Sun";
                else if (i == 1) day = "Mon";
                else if (i == 2) day = "Tue";
                else if (i == 3) day = "Wed";
                else if (i == 4) day = "Thu";
                else
                {
                    try
                    {
                        if (false)
                        {
                            throw new Exception("Error! Days must be between Sunday and Thursday!");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                #endregion
                str += " " + day + " | ";
                for (int j = 0; j < 7; ++j)
                {
                    str += (WorkTime[i, j]) ? " Yes  | " : " No   | ";
                }
                str += "\n-----|-------|-------|-------|-------|-------|-------|-------|\n";
            }

            return str;
        }
        public Tester Clone()
        {
            return new Tester(this);
        }
    }
}