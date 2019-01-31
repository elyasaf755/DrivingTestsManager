using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace BL
{
    public static class BlValidations
    {
        //Private Members
        private static IDal m_xamlImp = DalFactory.GetIDal();
        private static List<Tester> testers = m_xamlImp.GetAllTesters();
        private static List<Trainee> trainees = m_xamlImp.GetAllTrainees();
        private static List<Test> test = m_xamlImp.GetAllTests();
        private static List<City> m_cities = m_xamlImp.GetAllCities();

        /*Validations*/
        //General Validations
        /// <summary>
        /// Return true if a wanted lisence is already owned
        /// </summary>
        /// <param name="ownedLisences">Trainee's owned lisences</param>
        /// <param name="wantedLisence">Trainee's wanted lisence</param>
        /// <returns></returns>
        public static bool IsLisenceOwned(List<Lisence> ownedLisences, Lisence wantedLisence)
        {
            foreach (Lisence ownedLisence in ownedLisences)
            {
                if (ownedLisence == wantedLisence)
                {
                    return true;
                }
                else if (ownedLisence.carType == wantedLisence.carType && ownedLisence.gearType == GearTypeEnum.Manual)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Returns true if Id is a 9-digit format.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public static bool IsIdFormatValid(string id)
        {
            int temp;
            if (int.TryParse(id, out temp) == false)
            {
                return false;
            }

            string m_PERID = id;
            char[] digits = m_PERID.PadLeft(9, '0').ToCharArray();
            int[] oneTwo = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            int[] multiply = new int[9];
            int[] oneDigit = new int[9];
            for (int i = 0; i < 9; i++)
                multiply[i] = Convert.ToInt32(digits[i].ToString()) * oneTwo[i];
            for (int i = 0; i < 9; i++)
                oneDigit[i] = (int)(multiply[i] / 10) + multiply[i] % 10;
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += oneDigit[i];

            if (Configuration.IsDemoModeEnabled == true)
            {
                sum = 10;
            }

            return Regex.IsMatch(id, @"^\d{9}$") && (sum % 10 == 0);
        }
        /// <summary>
        /// Returns true if Name or Last Name is in a valid format.
        /// e.g - no numbers, no symbols, only letters and white spaces.
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns></returns>
        public static bool IsNameFormatValid(string name)
        {
            return Regex.IsMatch(name, @"^([A-Za-z]{1}?[A-Za-z ]*)$|^([א-ת]{1}?[א-ת ]*)$");
        }
        /// <summary>
        /// Returns true if phone number's format is valid.
        /// </summary>
        /// <param name="number">Phone Number</param>
        /// <returns></returns>
        public static bool IsPhoneNumberFormatValid(string number)
        {
            return Regex.IsMatch(number, @"^((\+|00)?972\-?|0)(([23489]|[57]\d)\-?\d{7})$");
        }
        /// <summary>
        /// Returns true if email address is valid.
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns></returns>
        public static bool IsEmailAddressFormatValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        /// <summary>
        /// Returns true only if the time format "yyy/mm/dd, hh:mm" is equal on both dates
        /// </summary>
        /// <param name="t1">Time to be compared</param>
        /// <param name="t2">Time to be compared</param>
        /// <returns></returns>
        public static bool IsTimeMatch(DateTime t1, DateTime t2)
        {
            if (t1.Year == t2.Year && t1.Month == t2.Month &&
                t1.Day == t2.Day && t1.Hour == t2.Hour &&
                t1.Minute == t2.Minute)
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// Returns true if a tester is working in a given date & time
        /// </summary>
        /// <param name="tester">Tester to be checked</param>
        /// <param name="dateTime">Date and time to be checked if the tester is available at</param>
        /// <returns></returns>
        public static bool IsTesterWorking(Tester tester, DateTime dateTime)
        {
            if (dateTime.Hour < 9 || dateTime.Hour > 15)
            {
                return false;
            }

            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return tester.WorkTime[0, dateTime.Hour - 9];
                case DayOfWeek.Monday:
                    return tester.WorkTime[1, dateTime.Hour - 9];
                case DayOfWeek.Tuesday:
                    return tester.WorkTime[2, dateTime.Hour - 9];
                case DayOfWeek.Wednesday:
                    return tester.WorkTime[3, dateTime.Hour - 9];
                case DayOfWeek.Thursday:
                    return tester.WorkTime[4, dateTime.Hour - 9];
                case DayOfWeek.Friday:
                    return false;
                case DayOfWeek.Saturday:
                    return false;
                default:
                    return false;
            }
        }
        /// <summary>
        /// Returns true only if the tester is free for a new test in a given date & time
        /// </summary>
        /// <param name="tester">Tester to be checked</param>
        /// <param name="testDate">Upcoming test's date</param>
        /// <returns></returns>
        public static bool IsTesterFreeForTest(Tester tester, DateTime testDate)
        {
            //If the tester IS NOT working at the given test's date and time (If he's not working at these hours)
            if (IsTesterWorking(tester, testDate) == false)
            {
                return false;
            }

            foreach (ScheduleStruct testerSchedule in tester.ScheduleList)
            {
                //If the tester IS ALREADY scheduled for a test in a given date & time
                if (IsTimeMatch(testerSchedule.TestDateTime, testDate) == true)
                {
                    return false;
                }
            }

            return true;
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        //Entities' Properties Validations
        /// <summary>
        /// Returns true if all of the person's details are valid.
        /// Object's class must inherit from Person class.
        /// </summary>
        /// <param name="person">Person to be validated</param>
        /// <returns></returns>
        public static bool PersonPropertiesValidation(Person person)
        {
            //Add Logic For Address? (If address == null)
            try
            {
                //Id format validation
                if (IsIdFormatValid(person.Id) == false)
                {
                    throw new Exception("Id format is not valid.");
                }
                //Last name format validation
                else if (IsNameFormatValid(person.LastName) == false)
                {
                    throw new Exception("Last name must start with a letter and contain only letters and spaces.");
                }
                //First name format validation
                else if (IsNameFormatValid(person.FirstName) == false)
                {
                    throw new Exception("First name must start with a letter and contain only letters and spaces.");
                }
                //Phone number format validation
                else if (IsPhoneNumberFormatValid(person.PhoneNumber) == false)
                {
                    throw new Exception("Phone number format is not valid.");
                }
                //Email address format validation
                else if (IsEmailAddressFormatValid(person.EmailAddress) == false)
                {
                    throw new Exception("Email address format is not valid.");
                }
                //Gender selection validation
                else if (person.Gender != GenderEnum.Male && person.Gender != GenderEnum.Female)
                {
                    throw new Exception("You must select a gender");
                }
                else if (IsAddressExists(person.Address) == false)
                {
                    throw new Exception("Address is not valid");
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        /// <summary>
        /// Returns true if all of the trainee's properties are valid.
        /// </summary>
        /// <param name="trainee">Trainee to be validated</param>
        /// <returns></returns>
        public static bool TraineePropertiesValidation(Trainee trainee)
        {
            try
            {
                if (PersonPropertiesValidation(trainee) == false ||
                    IsTesterIdFound(trainee.Id) == true)
                {
                    return false;
                }
                else if (trainee.FullAge.Years < Configuration.MinimalTraineeAge)
                {
                    throw new Exception("Trainee must be aged " + Configuration.MinimalTraineeAge.ToString() + " or more");
                }
                //Car type selection validation
                else if (trainee.CarType == CarTypeEnum.None)
                {
                    throw new Exception("You must select a car type");
                }
                //Gear type selection validation
                else if (trainee.GearType == GearTypeEnum.None)
                {
                    throw new Exception("You must select a gear type");
                }
                //Driving school validation
                else if (trainee.FullDrivingSchoolDetails == null)
                {
                    throw new Exception("You must select a driving school");
                }
                //Driving teacher selection validation
                else if (IsNameFormatValid(trainee.DrivingSchoolTeacher) == false)
                {
                    throw new Exception("Driving teacher name must start with a letter and contain only letters and spaces.");
                }
                //Driving lessons count validation
                else if (trainee.DrivingLessonsCount < 0)
                {
                    throw new Exception("Number of driving lessons must be 0 or more");
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        /// <summary>
        /// Returns true if all of the tester's properties are valid.
        /// </summary>
        /// <param name="tester">Tester to be validated</param>
        /// <returns></returns>
        public static bool TesterPropertiesValidation(Tester tester)
        {
            try
            {
                if (PersonPropertiesValidation(tester) == false ||
                    IsTraineeIdFound(tester.Id) == true)
                {
                    return false;
                }
                //Age validation
                else if (tester.FullAge.Years < Configuration.MinimalTesterAge)
                {
                    throw new Exception("Tester must be aged " + Configuration.MinimalTesterAge.ToString() + " or more");
                }
                //Years of experience validation
                //Minimal age to be a tester is 40. Maximal age of human is 120. Tester can never have more than 95 years of experience as a tester.
                else if (tester.YearsOfExperience < 0 && tester.YearsOfExperience > 120 - Configuration.MinimalTesterAge)
                {
                    throw new Exception("Years of experience must be 0 or more and less than " + (120 - Configuration.MinimalTesterAge).ToString());
                }
                else if (tester.CarType == CarTypeEnum.None)
                {
                    throw new Exception("You must select a car type");
                }
                else if (tester.MaximalDistance < 0)
                {
                    throw new Exception("Maximal distance value must be 0 or more");
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        /// <summary>
        /// Return true if all of the Test's properties are valid
        /// </summary>
        /// <param name="test">Test to be validated</param>
        /// <returns></returns>
        public static bool TestPropertiesValidation(Test test)
        {
            Trainee trainee = GetTraineeById(test.TraineeId);
            Tester tester = GetTesterById(test.TesterId);

            try
            {
                //Trainee's Id format validation
                if (IsIdFormatValid(trainee.Id) == false)
                {
                    throw new Exception(trainee.GetName() + "'s Id is not valid");
                }
                //Trainee's existence validation
                else if (trainee == null)
                {
                    throw new Exception(trainee.GetName() + " was not found!");
                }
                //Tester's Id format validation
                else if (IsIdFormatValid(tester.Id) == false)
                {
                    throw new Exception(tester.GetName() + "'s id is not valid");
                }
                //Tester's existence validation
                else if (tester == null)
                {
                    throw new Exception(tester.GetName() + " was not found!");
                }
                //Number of days passed since the trainee's last test validation
                else if (trainee.DaysPassedSinceLastTest < Configuration.MinimalDaysBetweenTests)
                {
                    throw new Exception("Test can only be scheduled at least " + Configuration.MinimalDaysBetweenTests + " days after the trainee's last test.");
                }
                //Validating if the tester is available for test at that date & time
                else if (IsTesterFreeForTest(tester, test.TestDateAndTime) == false)
                {
                    throw new Exception("Tester with Id" + tester.Id + " is busy at " + test.TestDateAndTime);
                }
                //Test location validation
                else if (IsAddressExists(test.TestLocation) == false)
                {
                    throw new Exception("Test location \"" + test.TestLocation + "\" is not valid");
                }
                //Tester's notes validations
                else if (test.TesterNotes == "" || test.TesterNotes == null)
                {
                    throw new Exception("You didnt write any notes");
                }
                //Trainee's driving lessons' count validation
                else if (trainee.DrivingLessonsCount < Configuration.MinimalLessonsCount)
                {
                    throw new Exception(trainee.GetName() + " must do at least " + Configuration.MinimalLessonsCount + " driving lessons before doing a test");
                }
                //Tester's weekly tests count validation
                else if (tester.MaximalWeeklyTests <= tester.WeeklyTestsCount)
                {
                    throw new Exception(tester.GetName() + " can't do more than " + tester.MaximalWeeklyTests + " tests in a week");
                }
                //Validating if the trainee is currently owning the desired lisence
                else if (IsLisenceOwned(trainee.OwnedLisences, trainee.WantedLisence) == false)
                {
                    throw new Exception("Lisence " + trainee.CarType + " is already owned by " + trainee.GetName());
                }
                //Validating if the tester can test a trainee for the trainee's desired lisence
                else if (tester.CarType != trainee.CarType)
                {
                    throw new Exception(tester.GetName() + " can't test " + trainee.GetName() + " for lisence " + trainee.CarType);
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        /// <summary>
        /// Returns true if a test for a certain cartype already exists in a list of ScheduleStruct
        /// </summary>
        /// <param name="scheduleList">Schedule list to be checked</param>
        /// <param name="carType">Wanted car type</param>
        /// <returns></returns>
        public static bool IsCarTypeExist(List<ScheduleStruct> scheduleList, CarTypeEnum carType)
        {
            foreach (ScheduleStruct schedule in scheduleList)
            {
                Test test = GetTestByTestId(schedule.TestId);

                if (test == null)
                {
                    return false;
                }

                if (test.CarType == carType)
                {
                    return true;
                }
            }

            return false;
        }

        //Search Operations
        /// <summary>
        /// Search for a trainee's Id and returns true if found. else - return false.
        /// </summary>
        /// <param name="Id">Trainee's Id</param>
        /// <returns></returns>
        public static bool IsTraineeIdFound(string Id)
        {
            List<Trainee> traineeList = m_xamlImp.GetAllTrainees();
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
            List<Tester> testerList = m_xamlImp.GetAllTesters();
            foreach (Tester tester in testerList)
            {
                if (tester.Id == Id)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Returns true if a given address exists in the DataSource
        /// </summary>
        /// <param name="address">Address to be checked</param>
        /// <returns></returns>
        public static bool IsAddressExists(AddressStruct address)
        {
            List<City> m_cities = m_xamlImp.GetAllCities();

            foreach (City city in m_cities)
            {
                if (city.city == address.City)
                {
                    foreach (string street in city.streets)
                    {
                        if (street == address.Street)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        public static AccessLevelEnum IsLoginValid(string id, string password)
        {
            foreach (Permisson permission in m_xamlImp.GetAllPermissions())
            {
                if (permission.Id == id && permission.Password == password)
                {
                    return permission.AccessLevel;
                }
            }

            return AccessLevelEnum.DeniedAccess;
        }

        //Data Getters
        /// <summary>
        /// Search trainee by Id and return the corresponding Trainee object if found. If not found, return null.
        /// </summary>
        /// <param name="id">Id of a trainee.</param>
        /// <returns>If found - return the Trainee object with the corresponding Id. else - Return null.</returns>
        public static Trainee GetTraineeById(string id)
        {
            List<Trainee> traineeList = m_xamlImp.GetAllTrainees();
            foreach (Trainee trainee in traineeList)
            {
                if (id == trainee.Id)
                {
                    return trainee;
                }
            }

            return null;
        }
        /// <summary>
        /// Search tester by Id and return the corresponding Tester object if found. If not found, return null.
        /// </summary>
        /// <param name="id">Id of a tester.</param>
        /// <returns>If found - return the Tester object with the corresponding Id. else - Return null.</returns>
        public static Tester GetTesterById(string id)
        {
            List<Tester> testerList = m_xamlImp.GetAllTesters();
            foreach (Tester tester in testerList)
            {
                if (id == tester.Id)
                {
                    return tester;
                }
            }

            return null;
        }
        /// <summary>
        /// Returns a Test instance by Test Id. Returs null if not found.
        /// </summary>
        /// <param name="testId">Test Id to be checked</param>
        /// <returns></returns>
        public static Test GetTestByTestId(int testId)
        {
            foreach (Test test in m_xamlImp.GetAllTests())
            {
                if (test.TestId == testId)
                {
                    return test;
                }
            }

            return null;
        }
    }
}
