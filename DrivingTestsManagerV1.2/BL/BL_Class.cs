using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Globalization;
using System.Windows;

namespace BL
{
    internal class BL_Class : BLTools, IBl
    {
        //Private Members
        private static IDal m_imp = DalFactory.GetIDal();
        private static IDal m_xamlImp = DalFactory.GetIDalXaml();
        private List<City> m_cities = m_xamlImp.GetAllCities();

        /*Validations*/
        //General Validations
        /// <summary>
        /// Return true if a wanted lisence is already owned
        /// </summary>
        /// <param name="ownedLisences">Trainee's owned lisences</param>
        /// <param name="wantedLisence">Trainee's wanted lisence</param>
        /// <returns></returns>
        private bool IsLisenceOwned(List<Lisence> ownedLisences, Lisence wantedLisence)
        {
            foreach(Lisence ownedLisence in ownedLisences)
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
        /// Return true if the tester is free in a specific day of the week and time.
        /// </summary>
        /// <param name="tester">Tester to be checked</param>
        /// <param name="time">Time to be checked</param>
        /// <returns></returns>
        private bool IsTesterFreeInDayAndTime(Tester tester, DateTime time)
        {
            bool[] workHours = GetTesterWorkHoursInDay(tester, time);
            int day = (int)time.DayOfWeek;

            try
            {
                if (day == 5 || day == 6)
                {
                    throw new Exception("Testers don't work in Fridays and Saturedays");
                }
                else
                {
                    switch (time.Hour)
                    {
                        case 9:
                            return tester.WorkTime[day, 0];
                        case 10:
                            return tester.WorkTime[day, 1];
                        case 11:
                            return tester.WorkTime[day, 2];
                        case 12:
                            return tester.WorkTime[day, 3];
                        case 13:
                            return tester.WorkTime[day, 4];
                        case 14:
                            return tester.WorkTime[day, 5];
                        case 15:
                            return tester.WorkTime[day, 6];
                        default:
                            throw new Exception("Testers don't work pre 9 AM and past 16 PM (excluded)");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }
        /// <summary>
        /// Returns true only if the given Id is valid to be added to the trainee's list
        /// </summary>
        /// <param name="trainee">Trainee to be checked</param>
        /// <returns></returns>
        private bool IsTraineeIdValid(Trainee trainee)
        {
            string id = trainee.Id;
            if (IsIdFormatValid(id) == false)
            {
                return false;
            }
            else if (IsTesterIdFound(id) == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Returns true only if the given Id is valid to be added to the tester's list
        /// </summary>
        /// <param name="tester">Tester to be checked</param>
        /// <returns></returns>
        private bool IsTesterIdValid(Tester tester)
        {
            string id = tester.Id;
            if (IsIdFormatValid(id) == false)
            {
                return false;
            }
            else if (IsTraineeIdFound(id) == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Returns true only if the time format "yyy/mm/dd, hh:mm" is equal on both dates
        /// </summary>
        /// <param name="t1">Time to be compared</param>
        /// <param name="t2">Time to be compared</param>
        /// <returns></returns>
        private bool IsTimeMatch(DateTime t1, DateTime t2)
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
        private bool IsTesterWorking(Tester tester, DateTime dateTime)
        {
            if (dateTime.Hour< 9 || dateTime.Hour > 15)
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
        private bool IsTesterFreeForTest(Tester tester, DateTime testDate)
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
        /// <summary>
        /// Returns true if a test for a certain cartype already exists in a list of ScheduleStruct
        /// </summary>
        /// <param name="scheduleList">Schedule list to be checked</param>
        /// <param name="carType">Wanted car type</param>
        /// <returns></returns>
        private bool IsCarTypeExist(List<ScheduleStruct> scheduleList, CarTypeEnum carType)
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

        //Properties' String Format Validation
        /// <summary>
        /// Returns true if Id is a 9-digit format.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        private bool IsIdFormatValid(string id)
        {
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
        private bool IsNameFormatValid(string name)
        {
            return Regex.IsMatch(name, @"^([A-Za-z]{1}?[A-Za-z ]*)$|^([א-ת]{1}?[א-ת ]*)$");
        }
        /// <summary>
        /// Returns true if phone number's format is valid.
        /// </summary>
        /// <param name="number">Phone Number</param>
        /// <returns></returns>
        private bool IsPhoneNumberFormatValid(string number)
        {
            return Regex.IsMatch(number, @"^((\+|00)?972\-?|0)(([23489]|[57]\d)\-?\d{7})$");
        }
        /// <summary>
        /// Returns true if email address is valid.
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns></returns>
        private bool IsEmailAddressFormatValid(string email)
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

        //Entities' Properties Validations
        /// <summary>
        /// Returns true if all of the person's details are valid.
        /// Object's class must inherit from Person class.
        /// </summary>
        /// <param name="person">Person to be validated</param>
        /// <returns></returns>
        private bool PersonPropertiesValidation(Person person)
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
        private bool TraineePropertiesValidation(Trainee trainee)
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
        private bool TesterPropertiesValidation(Tester tester)
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
        private bool TestPropertiesValidation(Test test)
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
                    throw new Exception("Test can only be scheduled at least " + Configuration.MinimalDaysBetweenTests
                                        + " days after the trainee's last test.");
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
                //Trainee's driving lessons' count validation
                else if (trainee.DrivingLessonsCount < Configuration.MinimalLessonsCount)
                {
                    throw new Exception(trainee.GetName() + " must do at least " + Configuration.MinimalLessonsCount
                                        + " driving lessons before doing a test");
                }
                //Tester's weekly tests count validation
                else if (tester.MaximalWeeklyTests <= tester.WeeklyTestsCount)
                {
                    throw new Exception(tester.GetName() + " can't do more than " + tester.MaximalWeeklyTests + " tests in a week");
                }
                //Validating if the trainee is currently owning the desired lisence
                else if (IsLisenceOwned(trainee.OwnedLisences, trainee.WantedLisence) ==  true)
                {
                    throw new Exception("Lisence " + trainee.CarType + " is already owned by " + trainee.GetName());
                }
                //Validating if the trainee is already been registered for a tests for the certain car type
                else if (IsCarTypeExist(trainee.ScheduleList, trainee.CarType) == true)
                {
                    throw new Exception("trainee with Id " + trainee.Id + " is already have an upcomming test for " + trainee.CarType);
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

        //Search Operations
        /// <summary>
        /// Search for a trainee's Id and returns true if found. else - return false.
        /// </summary>
        /// <param name="Id">Trainee's Id</param>
        /// <returns></returns>
        private bool IsTraineeIdFound(string Id)
        {
            List<Trainee> traineeList = GetAllTrainees();
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
        private bool IsTesterIdFound(string Id)
        {
            List<Tester> testerList = GetAllTesters();
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
        /// Search for a trainee's first name and returns true if found. else - return false.
        /// </summary>
        /// <param name="firstName">Trainee's first name</param>
        /// <returns></returns>
        private bool IsTraineeFirstNameFound(string firstName)
        {
            List<Trainee> traineeList = GetAllTrainees();
            foreach (Trainee trainee in traineeList)
            {
                if (trainee.FirstName == firstName)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Search for a tester's first name and returns true if found. else - return false.
        /// </summary>
        /// <param name="firstName">Tester's first name</param>
        /// <returns></returns>
        private bool IsTesterFirstNameFound(string firstName)
        {
            List<Tester> testersList = GetAllTesters();
            foreach (Tester tester in testersList)
            {
                if (tester.FirstName == firstName)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Search for a trainee's last name and returns true if found. else - return false.
        /// </summary>
        /// <param name="lastName">Trainee's last name</param>
        /// <returns></returns>
        private bool IsTraineeLastNameFound(string lastName)
        {
            List<Trainee> traineeList = GetAllTrainees();
            foreach (Trainee trainee in traineeList)
            {
                if (trainee.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Search for a tester's last name and returns true if found. else - return false.
        /// </summary>
        /// <param name="lastName">Tester's last name</param>
        /// <returns></returns>
        private bool IsTesterLastNameFound(string lastName)
        {
            List<Tester> testersList = GetAllTesters();
            foreach (Tester tester in testersList)
            {
                if (tester.LastName == lastName)
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
        private bool IsAddressExists(AddressStruct address)
        {
            foreach(City city in m_cities)
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
        /// <summary>
        /// Returns true if a distance between 2 address was found in the DataSource
        /// </summary>
        /// <param name="distanceTarget">Distance object to be checked</param>
        /// <returns></returns>
        private bool IsDistanceExist(DistanceStruct distanceTarget)
        {
            foreach(DistanceStruct distance in m_xamlImp.GetAllDistances())
            {
                if (distance == distanceTarget)
                {
                    return true;
                }
            }

            return false;
        }
        
        //Data Getters
        /// <summary>
        /// Search trainee by Id and return the corresponding Trainee object if found. If not found, return null.
        /// </summary>
        /// <param name="id">Id of a trainee.</param>
        /// <returns>If found - return the Trainee object with the corresponding Id. else - Return null.</returns>
        private Trainee GetTraineeById(string id)
        {
            List<Trainee> traineeList = GetAllTrainees();
            foreach(Trainee trainee in traineeList)
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
        private Tester GetTesterById(string id)
        {
            List<Tester> testerList = GetAllTesters();
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
        /// Returns a capitalized string
        /// </summary>
        /// <param name="str">string</param>
        /// <returns></returns>
        private string GetCapitalizedSentence(string str)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(str);
        }
        /// <summary>
        /// Returns the working hours of a tester in a certain day.
        /// </summary>
        /// <param name="tester">Tester to be checked</param>
        /// <param name="day">Day to be checked</param>
        /// <returns></returns>
        private bool[] GetTesterWorkHoursInDay(Tester tester, DateTime day)
        {
            bool[] result = new bool[7];

            try
            {
                switch (day.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        for (int i = 0; i < 7; ++i)
                        {
                            result[i] = tester.WorkTime[0, i];
                        }
                        break;
                    case DayOfWeek.Monday:
                        for (int i = 0; i < 7; ++i)
                        {
                            result[i] = tester.WorkTime[1, i];
                        }
                        break;
                    case DayOfWeek.Tuesday:
                        for (int i = 0; i < 7; ++i)
                        {
                            result[i] = tester.WorkTime[2, i];
                        }
                        break;
                    case DayOfWeek.Wednesday:
                        for (int i = 0; i < 7; ++i)
                        {
                            result[i] = tester.WorkTime[3, i];
                        }
                        break;
                    case DayOfWeek.Thursday:
                        for (int i = 0; i < 7; ++i)
                        {
                            result[i] = tester.WorkTime[4, i];
                        }
                        break;
                    case DayOfWeek.Friday:
                        throw new Exception("Testers don't work on Fridays");
                    case DayOfWeek.Saturday:
                        throw new Exception("Testers don't work on Saturdays");
                    default:
                        throw new Exception("Error getting working hours of " + tester.GetName() + " in " + day.DayOfWeek);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            

            return result;
        }

        public List<City> GetAllCities()
        {
            return m_imp.GetAllCities();
        }
        public List<string> GetAllCitiesStringFormat()
        {
            return m_imp.GetAllCitiesStringFormat();
        }
        public List<DrivingSchoolCity> GetAllDrivingSchoolsCities()
        {
            return m_imp.GetAllDrivingSchoolsCities();
        }
        public List<string> GetAllDrivingSchoolsCitiesStringFormat()
        {
            return m_imp.GetAllDrivingSchoolsCitiesStringFormat();
        }
        public List<string> GetDrivingSchoolsNamesOfCity(string drivingSchoolCity)
        {
            List<DrivingSchoolCity> drivingSchoolsCitiesList = GetAllDrivingSchoolsCities();

            List<string> result = new List<string>();

            foreach (DrivingSchoolCity schoolTemp in drivingSchoolsCitiesList)
            {
                if (schoolTemp.City == drivingSchoolCity)
                {
                    result = schoolTemp.DrivingSchools;
                    break;
                }
            }

            return result;
        }
        public List<DrivingSchool> GetAllDrivingSchools()
        {
            return m_xamlImp.GetAllDrivingSchools();
        }
        public List<string> GetAllDMVs()
        {
            return m_xamlImp.GetAllDMVs();
        }
        public List<DistanceStruct> GetAllDistances()
        {
            return m_xamlImp.GetAllDistances();
        }
        public List<Permisson> GetAllPermissions()
        {
            return m_xamlImp.GetAllPermissions();
        }

        /// <summary>
        /// Returns a list of all the streets in a given city
        /// </summary>
        /// <param name="city">The city to be checked</param>
        /// <returns></returns>
        public List<string> GetStreetsOfCity(string city)
        {
            List<City> CityList = GetAllCities();
            List<string> result = new List<string>();

            foreach (City cityTemp in CityList)
            {
                if (cityTemp.city == city)
                {
                    result = cityTemp.streets;
                    break;
                }
            }

            return result;
        }
        /// <summary>
        /// Returns a list of all the testers in the Data Source.
        /// </summary>
        /// <returns></returns>
        public List<Tester> GetAllTesters()
        {
            return m_xamlImp.GetAllTesters();
        }
        /// <summary>
        /// Returns a list of all the trainees in the Data Source
        /// </summary>
        /// <returns></returns>
        public List<Trainee> GetAllTrainees()
        {
            return m_xamlImp.GetAllTrainees();
        }
        /// <summary>
        /// Returns a list of all the tests in the Data source
        /// </summary>
        /// <returns></returns>
        public List<Test> GetAllTests()
        {
            return m_xamlImp.GetAllTests();
        }

        /*Converters*/
        /// <summary>
        /// Convert DateTime type to MyDate type.
        /// </summary>
        /// <param name="dateTime">DateTime to be converted to MyDate.</param>
        /// <returns></returns>
        private MyDate ConvertToMyDate(DateTime dateTime)
        {
            return new MyDate() { Year = dateTime.Year, Month = dateTime.Month, Day = dateTime.Day };
        }
        /// <summary>
        /// Convert MyDate type to DateTime type.
        /// </summary>
        /// <param name="dateTime">MyDaate to be converted to DateTime.</param>
        /// <returns></returns>
        private DateTime ConvertToDateTime(MyDate myDate)
        {
            return new DateTime(myDate.Year, myDate.Month, myDate.Day);
        }
        
        /*Data Manipulations*/
        //Data manipulations on TESTERS
        /// <summary>
        /// Adds a tester to the testers list in the Data Source
        /// </summary>
        /// <param name="tester">Tester to be added</param>
        public string AddTester(Tester tester)
        {
            string error = "Failed to add " + tester.GetName();

            if (IsTesterIdFound(tester.Id) == true)
            {
                return "Id " + tester.Id + " was already found";
            }
            else if (TesterPropertiesValidation(tester) == true)
            {
                error = m_xamlImp.AddTester(tester);
            }

            return error;
        }
        /// <summary>
        /// Deletes a tester from the testers list in the Data Source
        /// </summary>
        /// <param name="tester">Tester to be deleted</param>
        public string DeleteTester(Tester tester)
        {
            try
            {
                //Check if the tester to be deleted is in the Data Source
                if (IsTesterIdFound(tester.Id) == false)
                {
                    throw new Exception(tester.FirstName + " was not found");
                }
                else
                {
                    return m_xamlImp.DeleteTester(tester);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        /// <summary>
        /// Update a tester's properties
        /// </summary>
        /// <param name="targetTester">Tester to be updated</param>
        /// <param name="sourceTester">Tester update source</param>
        public string UpdateTester(Tester targetTester, Tester sourceTester)
        {
            string error = "";

            try
            {
                if (IsTesterIdFound(targetTester.Id) == false)
                {
                    throw new Exception(targetTester.GetName() + " was not found");
                }
                else if (PersonPropertiesValidation(sourceTester) == false || TesterPropertiesValidation(sourceTester) == false)
                {
                    throw new Exception("Couldnt update the tester because of 1 or more errors");
                }
                else
                {
                    error = m_xamlImp.UpdateTester(targetTester, sourceTester);
                }
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return error;
        }
        
        //Data manipulations on TRAINEES
        /// <summary>
        /// Adds a trainee to the trainee list in the Data Source
        /// </summary>
        /// <param name="trainee">Trainee to be added</param>
        public string AddTrainee(Trainee trainee)
        {
            string error = "Failed to add " + trainee.GetName();

            if (IsTraineeIdFound(trainee.Id) == true)
            {
                return "Id " + trainee.Id + " was already found";
            }
            else if (TraineePropertiesValidation(trainee) == true)
            {
                error = m_xamlImp.AddTrainee(trainee);
            }

            return error;
        }
        /// <summary>
        /// Deletes a trainee from the trainees list in the Data Source
        /// </summary>
        /// <param name="trainee">Trainee to be deleted</param>
        public string DeleteTrainee(Trainee trainee)
        {
            try
            {
                //Check if the trainee to be deleted is in the Data Source
                if (IsTraineeIdFound(trainee.Id) == false)
                {
                    throw new Exception(trainee.FirstName + " was not found");
                }
                else
                {
                    return m_xamlImp.DeleteTrainee(trainee);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        /// <summary>
        /// Updates a trainee's properties
        /// </summary>
        /// <param name="targetTrainee">Trainee to be updated</param>
        /// <param name="sourceTrainee">Trainee update source</param>
        public string UpdateTrainee(Trainee targetTrainee, Trainee sourceTrainee)
        {
            try
            {
                if (IsTraineeIdFound(targetTrainee.Id) == false)
                {
                    throw new Exception(targetTrainee.GetName() + " was not found");
                }
                else if (TraineePropertiesValidation(sourceTrainee) == false)
                {
                    throw new Exception("Couldnt update the trainee because of 1 or more errors");
                }
                else
                {
                    return m_xamlImp.UpdateTrainee(targetTrainee, sourceTrainee);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //Data manipulations on TESTS
        /// <summary>
        /// Adds a test to the tests list in the DataSource
        /// </summary>
        /// <param name="test">Test to be added</param>
        /// <returns></returns>
        public string AddTest(Test test)
        {
            if (TestPropertiesValidation(test) == true)
            {
                m_xamlImp.AddTest(test);
                return null;
            }
            else
            {
                return "Couldn't add the test because of 1 or more errors";
            }
        }
        /// <summary>
        /// Updates a test's properties
        /// </summary>
        /// <param name="targetTest">Test to be updated</param>
        /// <param name="sourceTest">Test update source</param>
        /// <returns></returns>
        public string UpdateTest(int targetTestId, Test sourceTest)
        {
            Test test = GetTestByTestId(targetTestId);
            if (test.IsPassed == null)
            {
                return m_xamlImp.UpdateTest(targetTestId, sourceTest);
            }

            return "This tese it already been given a grade!";
        }

        /// <summary>
        /// Adds a distance instance to the distances list in the DataSource
        /// </summary>
        /// <param name="distance"></param>
        public void AddDistance(DistanceStruct distance)
        {
            if (IsDistanceExist(distance) == true)
            {
                return;
            }

            m_xamlImp.AddDistance(distance);
        }

        public void UpdateConfigurations()
        {
            m_xamlImp.UpdateConfigurations();
        }

        //Constructors
        public BL_Class()
        {

        }
    }
}
