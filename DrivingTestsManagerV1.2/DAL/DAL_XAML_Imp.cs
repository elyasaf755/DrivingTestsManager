using BE;
using DATA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace DAL
{
    internal class DAL_XAML_Imp : DAL_Class, IDal
    {
        //XElement Roots
        XElement testsRoot;
        XElement testersRoot;
        XElement traineesRoot;
        XElement distancesRoot;
        XElement permissionsRoot;
        XElement configurationsRoot;

        //Files' Paths
        readonly string testsPath = @"..\..\..\DATA\DataFiles\tests.xml";
        readonly string testersPath = @"..\..\..\DATA\DataFiles\testers.xml";
        readonly string traineesPath = @"..\..\..\DATA\DataFiles\trainees.xml";
        readonly string distancesPath = @"..\..\..\DATA\DataFiles\distances.xml";
        readonly string permissionsPath = @"..\..\..\DATA\DataFiles\permissions.xml";
        readonly string configurationsPath = @"..\..\..\DATA\DataFiles\configurations.xml";

        //Constructor
        public DAL_XAML_Imp()
        {
            DataSource ds = new DataSource();

            LoadFiles();
            LoadDataSourceLists();
        }

        //Methods
        private void LoadFiles()
        {
            if (!File.Exists(testsPath))
                CreateTestsFiles();
            else
                LoadTestsFile();

            if (!File.Exists(testersPath))
                CreateTestersFiles();
            else
                LoadTestersFile();

            if (!File.Exists(traineesPath))
                CreateTraineesFiles();
            else
                LoadTraineesFile();

            if (!File.Exists(distancesPath))
                CreateDistancesFiles();
            else
                LoadDistancesFile();

            if (!File.Exists(permissionsPath))
                CreatePermissionsFiles();
            else
                LoadPermissionsFile();

            if (!File.Exists(configurationsPath))
                CreateConfigurationsFiles();
            else
                LoadConfigurationsFile();
        }
        private void LoadDataSourceLists()
        {
            LoadTestsList();
            LoadTestersList();
            LoadTraineesList();
            LoadDistancesList();
            LoadPermissionsList();
            LoadConfigurations();
        }

        //Files Creators Methods
        private void CreateTestsFiles()
        {
            testsRoot = new XElement("Test");
            testsRoot.Save(testsPath);
        }
        private void CreateTestersFiles()
        {
            testersRoot = new XElement("Tester");
            testersRoot.Save(testersPath);
        }
        private void CreateTraineesFiles()
        {
            traineesRoot = new XElement("Trainee");
            traineesRoot.Save(traineesPath);
        }
        private void CreateDistancesFiles()
        {
            distancesRoot = new XElement("Distance");
            distancesRoot.Save(distancesPath);
        }
        private void CreatePermissionsFiles()
        {
            permissionsRoot = new XElement("Permission");
            permissionsRoot.Save(permissionsPath);
        }
        private void CreateConfigurationsFiles()
        {
            configurationsRoot = new XElement("Configuration");
            configurationsRoot.Save(configurationsPath);
        }

        //Files Loaders
        /// <summary>
        /// Loading the tests' file to the XElement "testsRoot"
        /// </summary>
        private void LoadTestsFile()
        {
            try
            {
                testsRoot = XElement.Load(testsPath);
            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't load " + testsPath);
            }
        }
        /// <summary>
        /// Loading the testers' file to the XElement "testersRoot"
        /// </summary>
        private void LoadTestersFile()
        {
            try
            {
                testersRoot = XElement.Load(testersPath);
            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't load " + testersPath);
            }
        }
        /// <summary>
        /// Loading the trainees' file to the XElement "traineesRoot"
        /// </summary>
        private void LoadTraineesFile()
        {
            try
            {
                traineesRoot = XElement.Load(traineesPath);
            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't load " + traineesPath);
            }
        }
        /// <summary>
        /// Loading the distances' file to the XElement "distancesRoot"
        /// </summary>
        private void LoadDistancesFile()
        {
            try
            {
                distancesRoot = XElement.Load(distancesPath);
            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't load " + distancesPath);
            }
        }
        /// <summary>
        /// Loading the permissions' file to the XElement "permissionsPath"
        /// </summary>
        private void LoadPermissionsFile()
        {
            try
            {
                permissionsRoot = XElement.Load(permissionsPath);
            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't load " + permissionsPath);
            }
        }
        /// <summary>
        /// Loading the configurations' file to the XElement "configurationsPath"
        /// </summary>
        private void LoadConfigurationsFile()
        {
            try
            {
                configurationsRoot = XElement.Load(configurationsPath);
            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't load " + configurationsPath);
            }
        }

        //Lists Savers
        private void SaveTestsList(List<Test> testsList)
        {
            testsRoot = new XElement("Tests",
                                      from test in testsList
                                      select new XElement("Test",
                                                          new XElement("TestId", test.TestId),
                                                          new XElement("TesterId", test.TesterId),
                                                          new XElement("TraineeId", test.TraineeId),
                                                          new XElement("TestDateAndTime", test.TestDateAndTime),
                                                          new XElement("TestLocation", test.TestLocation),
                                                          new XElement("IsPassed", test.IsPassed),
                                                          new XElement("TesterNotes", test.TesterNotes),
                                                          new XElement("CarType", test.CarType),
                                                          new XElement("DrivingSchool", test.DrivingSchool),
                                                          new XElement("DMV", test.DMV)));


            testsRoot.Save(testsPath);
        }
        private void SaveTestersList(List<Tester> testersList)
        {
            testersRoot = new XElement("Testers",
                                      from tester in testersList
                                      select new XElement("Tester",
                                                          new XElement("Id", tester.Id),
                                                          new XElement("LastName", tester.LastName),
                                                          new XElement("FirstName", tester.FirstName),
                                                          new XElement("DateOfBirth", tester.DateOfBirth),
                                                          new XElement("Gender", tester.Gender),
                                                          new XElement("PhoneNumber", tester.PhoneNumber),
                                                          new XElement("Address", tester.Address),
                                                          new XElement("EmailAddress", tester.EmailAddress),//Person until here
                                                          new XElement("YearsOfExperience", tester.YearsOfExperience),
                                                          new XElement("MaximalWeeklyTests", tester.MaximalWeeklyTests),
                                                          new XElement("CarType", tester.CarType),
                                                          GetWorkTimeXElement(tester),
                                                          new XElement("MaximalDistance", tester.MaximalDistance),
                                                          new XElement("WeeklyTestsCount", tester.WeeklyTestsCount),
                                                          GetScheduleListXElement(tester)));


            testersRoot.Save(testersPath);
        }
        private void SaveTraineesList(List<Trainee> traineesList)
        {
            traineesRoot = new XElement("Trainees",
                                      from trainee in traineesList
                                      select new XElement("Trainee",
                                                          new XElement("Id", trainee.Id),
                                                          new XElement("LastName", trainee.LastName),
                                                          new XElement("FirstName", trainee.FirstName),
                                                          new XElement("DateOfBirth", trainee.DateOfBirth),
                                                          new XElement("Gender", trainee.Gender),
                                                          new XElement("PhoneNumber", trainee.PhoneNumber),
                                                          new XElement("Address", trainee.Address),
                                                          new XElement("EmailAddress", trainee.EmailAddress),//Person until here
                                                          new XElement("CarType", trainee.CarType),
                                                          new XElement("GearType", trainee.GearType),
                                                          new XElement("DrivingSchool", trainee.FullDrivingSchoolDetails),
                                                          new XElement("DrivingTeacher", trainee.DrivingSchoolTeacher),
                                                          new XElement("DrivingLessonsCount", trainee.DrivingLessonsCount),
                                                          GetScheduleListXElement(trainee),
                                                          GetOwnedLisencesXElement(trainee)));

            traineesRoot.Save(traineesPath);
        }
        private void SaveDistancesList(List<DistanceStruct> distancesList)
        {
            distancesRoot = new XElement("DistancesList",
                                        from distance in distancesList
                                        select new XElement("DistanceStruct",
                                                             new XElement("OriginAddress", distance.OriginAddress),
                                                             new XElement("DestinationAddress", distance.DestinationAddress),
                                                             new XElement("Distance", distance.Distance)));


            distancesRoot.Save(distancesPath);
        }
        private void SavePermissionsList(List<Permisson> permissionsList)
        {
            permissionsRoot = new XElement("Permissions",
                                     from permission in permissionsList
                                     select new XElement("Permission",
                                                          new XElement("AccessLevel", permission.AccessLevel),
                                                          new XElement("Id", permission.Id),
                                                          new XElement("Password", permission.Password)));

            permissionsRoot.Save(permissionsPath);
        }
        private void SaveConfigurations()
        {
            configurationsRoot = new XElement("Configurations",
                                            new XElement("MinimalLessonsCount", Configuration.MinimalLessonsCount),
                                            new XElement("MaximalTesterAge", Configuration.MaximalTesterAge),
                                            new XElement("MinimalTesterAge", Configuration.MinimalTesterAge),
                                            new XElement("MaximalTraineeAge", Configuration.MaximalTraineeAge),
                                            new XElement("MinimalTraineeAge", Configuration.MinimalTraineeAge),
                                            new XElement("MinimalDaysBetweenTests", Configuration.MinimalDaysBetweenTests),
                                            new XElement("TestsCount", Configuration.TestsCount));

            configurationsRoot.Save(configurationsPath);
        }
        
        //Lists Loaders
        private void LoadTestsList()
        {
            DataSource.TestsList = GetAllTests();
        }
        private void LoadTestersList()
        {
            DataSource.TestersList = GetAllTesters();
        }
        private void LoadTraineesList()
        {
            DataSource.TraineesList = GetAllTrainees();
        }
        private void LoadDistancesList()
        {
            DataSource.DistancesList = GetAllDistances();
        }
        private void LoadPermissionsList()
        {
            DataSource.PermissionsList = GetAllPermissions();
        }
        private void LoadConfigurations()
        {
            LoadConfigurationsFile();

            try
            {
                Configuration.MinimalLessonsCount = Convert.ToInt32(configurationsRoot.Element("MinimalLessonsCount").Value);
                Configuration.MaximalTesterAge = Convert.ToInt32(configurationsRoot.Element("MaximalTesterAge").Value);
                Configuration.MinimalTesterAge = Convert.ToInt32(configurationsRoot.Element("MinimalTesterAge").Value);
                Configuration.MaximalTraineeAge = Convert.ToInt32(configurationsRoot.Element("MaximalTraineeAge").Value);
                Configuration.MinimalTraineeAge = Convert.ToInt32(configurationsRoot.Element("MinimalTraineeAge").Value);
                Configuration.MinimalDaysBetweenTests = Convert.ToInt32(configurationsRoot.Element("MinimalDaysBetweenTests").Value);
                Configuration.TestsCount = Convert.ToInt32(configurationsRoot.Element("TestsCount").Value);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /*Data Manipulations*/
        //Tester
        public string AddTester(Tester tester)
        {
            try
            {
                //Tester id validation
                if (DAL_Class.IsIdFormatValid(tester.Id) == false)
                {
                    throw new Exception(tester.GetName() + "'s Id " + tester.Id + " is not valid");
                }
                else if (DAL_Class.IsTesterIdFound(tester.Id) == true)
                {
                    throw new Exception(tester.GetName() + "'s Id " + tester.Id + " is already found");
                }
                else
                {
                    DataSource.TestersList.Add(tester);
                    SaveTestersList(DataSource.TestersList);
                    return null;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
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
                    DataSource.TestersList.RemoveAt(FindIndexOfTesterById(tester));
                    SaveTestersList(DataSource.TestersList);
                    return null;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string UpdateTester(Tester targetTester, Tester sourceTester)
        {
            string error = "";

            error = DeleteTester(targetTester);
            //if deletion succeed
            if (error == null)
            {
                error = AddTester(sourceTester);

                //If addition didnt succeed, revert changes
                if (error != null)
                {
                    AddTester(targetTester);
                }
            }

            return error;
        }
        public List<Tester> GetAllTesters()
        {
            LoadTestersFile();

            List<Tester> testersList = new List<Tester>();
            try
            {
                testersList = (from tester in testersRoot.Elements()
                               select new Tester()
                               {
                                   Id = tester.Element("Id").Value,
                                   LastName = tester.Element("LastName").Value,
                                   FirstName = tester.Element("FirstName").Value,
                                   DateOfBirth = Utilities.ConvertStringToMyDate(tester.Element("DateOfBirth").Value),
                                   Gender = ConvertStringToGenderEnum(tester.Element("Gender").Value),
                                   PhoneNumber = tester.Element("PhoneNumber").Value,
                                   Address = ConvertStringToAddressStruct(tester.Element("Address").Value),
                                   EmailAddress = tester.Element("EmailAddress").Value,//Person
                                   YearsOfExperience = int.Parse(tester.Element("YearsOfExperience").Value),
                                   MaximalWeeklyTests = int.Parse(tester.Element("MaximalWeeklyTests").Value),
                                   CarType = ConvertStringToCarTypeEnum(tester.Element("CarType").Value),
                                   WorkTime = ConvertXElementToWorkTime(tester.Element("WorkTime")),
                                   MaximalDistance = int.Parse(tester.Element("MaximalDistance").Value),
                                   WeeklyTestsCount = int.Parse(tester.Element("WeeklyTestsCount").Value),
                                   ScheduleList = ConvertXElementToScheduleList(tester.Element("ScheduleList"))
                               }).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
            DataSource.TestersList = testersList;


            List<Tester> result = (from tester in DataSource.TestersList
                                   select tester).ToList();

            return result;
        }

        //Trainee
        public string AddTrainee(Trainee trainee)
        {
            try
            {
                //Tester id validation
                if (DAL_Class.IsIdFormatValid(trainee.Id) == false)
                {
                    throw new Exception(trainee.GetName() + "'s Id " + trainee.Id + " is not valid");
                }
                else if (DAL_Class.IsTraineeIdFound(trainee.Id) == true)
                {
                    throw new Exception(trainee.GetName() + "'s Id " + trainee.Id + " is already found");
                }
                else
                {
                    DataSource.TraineesList.Add(trainee);
                    SaveTraineesList(DataSource.TraineesList);
                    return null;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
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
                    DataSource.TraineesList.RemoveAt(FindIndexOfTraineeById(trainee));
                    SaveTraineesList(DataSource.TraineesList);
                    return null;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string UpdateTrainee(Trainee targetTrainee, Trainee sourceTrainee)
        {
            string error = "";

            error = DeleteTrainee(targetTrainee);
            //if deletion succeed
            if (error == null)
            {
                error = AddTrainee(sourceTrainee);

                //If addition didnt succeed, revert changes
                if (error != null)
                {
                    AddTrainee(targetTrainee);
                }
            }

            return error;
        }
        public List<Trainee> GetAllTrainees()
        {
            LoadTraineesFile();

            List<Trainee> traineesList = new List<Trainee>();
            try
            {
                traineesList = (from trainee in traineesRoot.Elements()
                                select new Trainee()
                                {
                                    Id = trainee.Element("Id").Value,
                                    LastName = trainee.Element("LastName").Value,
                                    FirstName = trainee.Element("FirstName").Value,
                                    DateOfBirth = Utilities.ConvertStringToMyDate(trainee.Element("DateOfBirth").Value),
                                    Gender = ConvertStringToGenderEnum(trainee.Element("Gender").Value),
                                    PhoneNumber = trainee.Element("PhoneNumber").Value,
                                    Address = ConvertStringToAddressStruct(trainee.Element("Address").Value),//Person
                                    EmailAddress = trainee.Element("EmailAddress").Value,
                                    CarType = ConvertStringToCarTypeEnum(trainee.Element("CarType").Value),
                                    GearType = ConvertStringToGearTypeEnum(trainee.Element("GearType").Value),
                                    FullDrivingSchoolDetails = ConvertStringToDrivingSchool(trainee.Element("DrivingSchool").Value),
                                    DrivingSchoolTeacher = trainee.Element("DrivingTeacher").Value,
                                    DrivingLessonsCount = int.Parse(trainee.Element("DrivingLessonsCount").Value),
                                    OwnedLisences = ConvertXElementToOwnedLisences(trainee.Element("OwnedLisences")),
                                    ScheduleList = ConvertXElementToScheduleList(trainee.Element("ScheduleList"))
                                }).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            DataSource.TraineesList = traineesList;

            return DAL_Class.GetClonedList(DataSource.TraineesList);
        }
        
        //Test
        public void AddTest(Test test)
        {
            test.TestId = ++Configuration.TestsCount;
            DataSource.TestsList.Add(test);

            //Update schedule of the tester
            for (int i = 0; i < DataSource.TestersList.Count; ++i)
            {
                if (test.TesterId == DataSource.TestersList[i].Id)
                {
                    DataSource.TestersList[i].ScheduleList.Add(new ScheduleStruct(test.TestId, test.TestDateAndTime));
                    SaveTestersList(DataSource.TestersList);
                }
            }

            //Update schedule of a trainee
            for (int i = 0; i < DataSource.TraineesList.Count; ++i)
            {
                if (test.TraineeId == DataSource.TraineesList[i].Id)
                {
                    DataSource.TraineesList[i].ScheduleList.Add(new ScheduleStruct(test.TestId, test.TestDateAndTime));
                }
            }

            SaveTestsList(DataSource.TestsList);
            SaveTestersList(DataSource.TestersList);
            SaveTraineesList(DataSource.TraineesList);
            SaveConfigurations();
        }
        public string UpdateTest(int targetTestId, Test sourceTest)
        {
            Test targetTest = null;

            foreach (Test test in DataSource.TestsList)
            {
                if (test.TestId == targetTestId)
                {
                    targetTest = new Test();
                    targetTest = test;
                }
            }

            if (targetTest == null)
            {
                return "Couldn't edit the test";
            }

            CopyTests(ref targetTest, sourceTest);

            SaveTestsList(DataSource.TestsList);

            return null;
        }
        public List<Test> GetAllTests()
        {
            LoadTestersFile();

            List<Test> testsList = new List<Test>();

            try
            {
                testsList = (from test in testsRoot.Elements()
                                   select new Test()
                                   {
                                       TestId = Convert.ToInt32(test.Element("TestId").Value),
                                       TesterId = test.Element("TesterId").Value,
                                       TraineeId = test.Element("TraineeId").Value,
                                       TestDateAndTime = DateTime.Parse(test.Element("TestDateAndTime").Value),
                                       TestLocation = ConvertStringToAddressStruct(test.Element("TestLocation").Value),
                                       IsPassed = ConvertStringToNullableBool(test.Element("IsPassed").Value),
                                       TesterNotes = test.Element("TesterNotes").Value,
                                       CarType = ConvertStringToCarTypeEnum(test.Element("CarType").Value),
                                       DrivingSchool = ConvertStringToDrivingSchool(test.Element("DrivingSchool").Value),
                                       DMV = test.Element("DMV").Value
                                   }).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            DataSource.TestsList = testsList;

            return DAL_Class.GetClonedList(DataSource.TestsList);
        }

        //Cities
        public List<City> GetAllCities()
        {
            return DAL_Class.GetClonedList(DataSource.CitiesList);
        }
        public List<string> GetAllCitiesStringFormat()
        {
            return DAL_Class.GetClonedList(DataSource.CitiesStringList);
        }

        //Driving Schools
        public List<DrivingSchoolCity> GetAllDrivingSchoolsCities()
        {
            return DAL_Class.GetClonedList(DataSource.DrivingSchoolsCities);
        }
        public List<string> GetAllDrivingSchoolsCitiesStringFormat()
        {
            return DAL_Class.GetClonedList(DataSource.DrivingSchoolsCitiesStringFormat);
        }
        public List<DrivingSchool> GetAllDrivingSchools()
        {
            return DAL_Class.GetClonedList(DataSource.DrivingSchools);
        }

        //D.M.V
        public List<string> GetAllDMVs()
        {
            return DAL_Class.GetClonedList(DataSource.DmvList);
        }

        //Distances
        public void AddDistance(DistanceStruct distance)
        {
            DataSource.DistancesList.Add(distance);
            DataSource.DistancesList.Sort((d1, d2) => d1.OriginAddress.CompareTo(d2.OriginAddress));
            SaveDistancesList(DataSource.DistancesList);
        }
        public List<DistanceStruct> GetAllDistances()
        {
            LoadDistancesFile();

            List<DistanceStruct> distancesList = new List<DistanceStruct>();

            try
            {
                distancesList = (from distance in distancesRoot.Elements()
                                 select new DistanceStruct()
                                 {
                                     OriginAddress = Utilities.ConvertStringToAddressStruct(distance.Element("OriginAddress").Value),
                                     DestinationAddress = Utilities.ConvertStringToAddressStruct(distance.Element("DestinationAddress").Value),
                                     Distance = Convert.ToDouble(distance.Element("Distance").Value)
                                 }).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            DataSource.DistancesList = distancesList;

            return DAL_Class.GetClonedList(DataSource.DistancesList);
        }

        //Permissons
        public List<Permisson> GetAllPermissions()
        {
            LoadPermissionsFile();

            List<Permisson> permissionsList = new List<Permisson>();

            try
            {
                permissionsList = (from permission in permissionsRoot.Elements()
                                   select new Permisson()
                                   {
                                       AccessLevel = Utilities.ConvertStringToAccessLevelEnum(permission.Element("AccessLevel").Value),
                                       Id = permission.Element("Id").Value,
                                       Password = permission.Element("Password").Value
                                   }).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            DataSource.PermissionsList = permissionsList;

            return DAL_Class.GetClonedList(DataSource.PermissionsList);
        }

        //Configurations
        public void UpdateConfigurations()
        {
            SaveConfigurations();
        }

        //Converters
        private XElement GetScheduleListXElement(Tester tester)
        {
            XElement scheduleListRoot = new XElement("ScheduleList");

            for (int i = 0; i < tester.ScheduleList.Count; ++i)
            {
                scheduleListRoot.Add(new XElement("Schedule",
                                                    new XElement("TestId", tester.ScheduleList[i].TestId),
                                                    new XElement("TestDateTime", tester.ScheduleList[i].TestDateTime)));
            }

            return scheduleListRoot;
        }
        private XElement GetScheduleListXElement(Trainee trainee)
        {
            XElement scheduleListRoot = new XElement("ScheduleList");

            for (int i = 0; i < trainee.ScheduleList.Count; ++i)
            {
                scheduleListRoot.Add(new XElement("Schedule",
                                                    new XElement("TestId", trainee.ScheduleList[i].TestId),
                                                    new XElement("TestDateTime", trainee.ScheduleList[i].TestDateTime)));
            }

            return scheduleListRoot;
        }
        private List<ScheduleStruct> ConvertXElementToScheduleList(XElement scheduleList)
        {
            List<ScheduleStruct> result = new List<ScheduleStruct>();

            foreach (XElement scheduleElement in scheduleList.Elements())
            {
                ScheduleStruct schedule = new ScheduleStruct()
                {
                    TestId = int.Parse(scheduleElement.Element("TestId").Value),
                    TestDateTime = DateTime.Parse(scheduleElement.Element("TestDateTime").Value)
                };

                result.Add(schedule);
            }

            return result;
        }
        private DrivingSchool ConvertStringToDrivingSchool(string drivingSchool)
        {
            int nameStartIndex = Utilities.GetStartIndexOfColumnInLine(drivingSchool, 1, ',');
            int carTypesStartIndex = Utilities.GetStartIndexOfColumnInLine(drivingSchool, 2, ',');

            return new DrivingSchool()
            {
                City = Utilities.GetColumnDataInLine(drivingSchool, 0, ','),
                Name = Utilities.GetColumnDataInLine(drivingSchool, nameStartIndex, ','),
                CarTypes = ConvertStringToCarTypes(Utilities.GetColumnDataInLine(drivingSchool,
                                                                               carTypesStartIndex,
                                                                               ','))
            };
        }
        private CarTypeEnum[] ConvertStringToCarTypes(string carTypes)
        {
            int privateStartIndex = Utilities.GetStartIndexOfColumnInLine(carTypes, 0, '|');
            int truckStartIndex = Utilities.GetStartIndexOfColumnInLine(carTypes, 1, '|');
            int tractorStartIndex = Utilities.GetStartIndexOfColumnInLine(carTypes, 2, '|');
            int motorcycleStartIndex = Utilities.GetStartIndexOfColumnInLine(carTypes, 3, '|');
            int busStartIndex = Utilities.GetStartIndexOfColumnInLine(carTypes, 3, '|');

            CarTypeEnum[] result = new CarTypeEnum[5];

            result[0] = Utilities.ConvertStringToCarTypeEnum(Utilities.GetColumnDataInLine(carTypes, privateStartIndex, '|'));
            result[1] = Utilities.ConvertStringToCarTypeEnum(Utilities.GetColumnDataInLine(carTypes, truckStartIndex, '|'));
            result[2] = Utilities.ConvertStringToCarTypeEnum(Utilities.GetColumnDataInLine(carTypes, tractorStartIndex, '|'));
            result[3] = Utilities.ConvertStringToCarTypeEnum(Utilities.GetColumnDataInLine(carTypes, motorcycleStartIndex, '|'));
            result[4] = Utilities.ConvertStringToCarTypeEnum(Utilities.GetColumnDataInLine(carTypes, busStartIndex, '|'));

            return result;
        }
        private XElement GetOwnedLisencesXElement(Trainee trainee)
        {
            XElement ownedLisencesRoot = new XElement("OwnedLisences");

            for (int i = 0; i < trainee.OwnedLisences.Count; ++i)
            {
                ownedLisencesRoot.Add(new XElement("Lisence",
                                                    new XElement("CarType", trainee.OwnedLisences[i].carType),
                                                    new XElement("GearType", trainee.OwnedLisences[i].gearType)));
            }

            return ownedLisencesRoot;
        }
        private List<Lisence> ConvertXElementToOwnedLisences(XElement ownedLisences)
        {
            List<Lisence> result = new List<Lisence>();

            foreach (XElement lisenceElement in ownedLisences.Elements())
            {
                Lisence lisence = new Lisence()
                {
                    carType = Utilities.ConvertStringToCarTypeEnum(lisenceElement.Element("CarType").Value),
                    gearType = Utilities.ConvertStringToGearTypeEnum(lisenceElement.Element("GearType").Value)
                };

                result.Add(lisence);
            }

            return result;
        }
        private XElement GetWorkTimeXElement(Tester tester)
        {
            XElement workTimeRoot = new XElement("WorkTime");
            for (int i = 0; i < 5; ++i)
            {
                XElement rowRoot = new XElement("Row" + i);
                for (int j = 0; j < 7; ++j)
                {
                    rowRoot.Add(new XElement("Column" + j, tester.WorkTime[i, j]));
                }
                workTimeRoot.Add(rowRoot);
            }

            return workTimeRoot;
        }
        private bool[,] ConvertXElementToWorkTime(XElement workTime)
        {
            bool[,] result = new bool[5, 7];

            List<XElement> rows = new List<XElement>();
            foreach (XElement element in workTime.Elements())
            {
                rows.Add(element);
            }

            for (int i = 0; i < 5; ++i)
            {
                int j = 0;
                foreach (XElement element in rows[i].Elements())
                {
                    result[i, j] = bool.Parse(element.Value);
                    ++j;
                }
            }
            return result;
        }
        private GenderEnum ConvertStringToGenderEnum(string gender)
        {
            GenderEnum result = new GenderEnum();

            Enum.TryParse(gender, out result);

            return result;
        }
        private CarTypeEnum ConvertStringToCarTypeEnum(string carType)
        {
            CarTypeEnum result = new CarTypeEnum();

            Enum.TryParse(carType, out result);

            return result;
        }
        private GearTypeEnum ConvertStringToGearTypeEnum(string gearType)
        {
            GearTypeEnum result;

            Enum.TryParse(gearType, out result);

            return result;
        }
        private AddressStruct ConvertStringToAddressStruct(string address)
        {
            return Utilities.ConvertStringToAddressStruct(address);
        }
        private AccessLevelEnum ConvertStringToAccessLevelEnum(string accessLevel)
        {
            AccessLevelEnum temp;

            Enum.TryParse(accessLevel, out temp);

            return temp;
        }
        private bool? ConvertStringToNullableBool(string nullableBool)
        {
            if (nullableBool == "")
                return null;

            return Convert.ToBoolean(nullableBool);
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
        private int FindIndexOfTesterById(Tester targetTaster)
        {
            for (int i = 0; i < DataSource.TestersList.Count; ++i)
            {
                if (DataSource.TestersList[i].Id == targetTaster.Id)
                {
                    return i;
                }
            }

            return -1;
        }
        private int FindIndexOfTraineeById(Trainee targetTrainee)
        {
            for (int i = 0; i < DataSource.TraineesList.Count; ++i)
            {
                if (DataSource.TraineesList[i].Id == targetTrainee.Id)
                {
                    return i;
                }
            }

            return -1;
        }

        //Helper Methods
        
        
    }
}
