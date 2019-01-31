using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using BE;
using DATA;

namespace DAL
{
    public class DAL_Class
    {
        /// <summary>
        /// Returns true if Id is a 9-digit format.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public static bool IsIdFormatValid(string id)
        {
            return Regex.IsMatch(id, @"^\d{9}$");
        }
        /// <summary>
        /// Search for a trainee's Id and returns true if found. else - return false.
        /// </summary>
        /// <param name="Id">Trainee's Id</param>
        /// <returns></returns>
        public static bool IsTraineeIdFound(string Id)
        {
            List<Trainee> traineeList = DalFactory.GetIDalXaml().GetAllTrainees();
            foreach (Trainee trainee in traineeList)
            {
                if (trainee.Id == Id)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Search for a tester's Id and returns true if found. else - return false.
        /// </summary>
        /// <param name="Id">Tester's Id</param>
        /// <returns></returns>
        public static bool IsTesterIdFound(string Id)
        {
            List<Tester> testerList = DalFactory.GetIDalXaml().GetAllTesters();
            foreach (Tester tester in testerList)
            {
                if (tester.Id == Id)
                {
                    return true;
                }
            }

            return false;
        }

        public static List<T> GetClonedList<T>(List<T> sourceList)
        {
            List<T> destinationList = new List<T>();

            foreach (T element in sourceList)
            {
                destinationList.Add(element);
            }

            return destinationList;
        }
        /// <summary>
        /// Copy tester's properties to another tester
        /// </summary>
        /// <param name="targetTester">Tester to be copied to</param>
        /// <param name="sourceTarget">Tester to be copied from</param>
        public static void CopyTesters(ref Tester targetTester, Tester sourceTarget)
        {
            Tester originalTester = targetTester;

            targetTester.Id = sourceTarget.Id;
            targetTester.FirstName = sourceTarget.FirstName;
            targetTester.LastName = sourceTarget.LastName;
            targetTester.DateOfBirth = targetTester.DateOfBirth;
            targetTester.Gender = sourceTarget.Gender;
            targetTester.PhoneNumber = sourceTarget.PhoneNumber;
            targetTester.Address = sourceTarget.Address;
            targetTester.EmailAddress = sourceTarget.EmailAddress;
            targetTester.YearsOfExperience = sourceTarget.YearsOfExperience;
            targetTester.MaximalDistance = sourceTarget.MaximalDistance;
            targetTester.CarType = targetTester.CarType;
            targetTester.WorkTime = sourceTarget.WorkTime;
            targetTester.MaximalDistance = sourceTarget.MaximalDistance;
            targetTester.WeeklyTestsCount = sourceTarget.WeeklyTestsCount;
        }
        /// <summary>
        /// Copy test's properties to another test
        /// </summary>
        /// <param name="targetTest">Test to be copied to</param>
        /// <param name="sourceTest">Test to copied from</param>
        public void CopyTests(ref Test targetTest, Test sourceTest)
        {
            targetTest.TestId = sourceTest.TestId;
            targetTest.TesterId = sourceTest.TesterId;
            targetTest.TraineeId = sourceTest.TraineeId;
            targetTest.TestDateAndTime = sourceTest.TestDateAndTime;
            targetTest.TestLocation = sourceTest.TestLocation;
            targetTest.IsPassed = sourceTest.IsPassed;
            targetTest.TesterNotes = sourceTest.TesterNotes;
            targetTest.CarType = sourceTest.CarType;
            targetTest.DrivingSchool = sourceTest.DrivingSchool;
            targetTest.DMV = sourceTest.DMV;
        }
    }
}
