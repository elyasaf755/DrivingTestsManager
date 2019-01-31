using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace BL
{
    public class BLTools
    {
        //Private Members
        private static IDal m_xamlImp = DalFactory.GetIDalXaml();
        private static List<Tester> m_testersList = m_xamlImp.GetAllTesters();

        //Methods
        /// <summary>
        /// Calculates distance between two address using MapQuest API
        /// </summary>
        /// <param name="originAddress">Origin Address</param>
        /// <param name="destinationAddress">Destination address</param>
        /// <returns></returns>
        public static double CalculateDistanceMapQuest(AddressStruct originAddress, AddressStruct destinationAddress)
        {
            if (BlValidations.CheckForInternetConnection() == false)
            {
                return -2;
            }

            Thread.Sleep(100);//Prevents continious calls

            double distanceInKm = 100.00001;
            string drivingTime;
            string addressMQFormat1 = originAddress.Street + ", " + originAddress.City;
            string addressMQFormat2 = destinationAddress.Street + ", " + destinationAddress.City;

            string url = @"https://www.mapquestapi.com/directions/v2/route" +
            @"?key=" + "7LkPRPGhyp6sB8mYiAFRKpM72oFYAtCh" +
            @"&from=" + originAddress.ToString() +
            @"&to=" + destinationAddress.ToString() +
            @"&outFormat=xml" +
            @"&ambiguities=ignore&routeType=fastest&doReverseGeocode=false" +
            @"&enhancedNarrative=false&avoidTimedConditions=false";

            //request from MapQuest service the distance between the 2 addresses
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            //the response is given in an XML format
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);

            //If we have a valid answer
            if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "0")
            {
                //distance
                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                double distInMiles = Convert.ToDouble(distance[0].ChildNodes[0].InnerText);

                //driving time
                XmlNodeList formattedTime = xmldoc.GetElementsByTagName("formattedTime");
                string fTime = formattedTime[0].ChildNodes[0].InnerText;

                //MessageBox.Show("Driving Time: " + fTime);

                drivingTime = fTime;
                distanceInKm = distInMiles * 1.609344;
            }
            //if an error occurred, one of the addresses is not found
            else if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "402")
            {
                MessageBox.Show("Address was not found. Please try again");
            }
            //busy network or other error...
            else
            {
                MessageBox.Show("Server is too busy...");
            }

            return distanceInKm;
        }
        /// <summary>
        /// Calculates distance between two address using Google Maps API. Returns -2 if no internet connection was found
        /// </summary>
        /// <param name="originAddress">Origin address</param>
        /// <param name="destinationAddress">Destination address</param>
        /// <returns></returns>
        public static double CalculateDistanceGoogle(AddressStruct originAddress, AddressStruct destinationAddress)
        {
            if (BlValidations.CheckForInternetConnection() == false)
            {
                return -2;
            }

            Thread.Sleep(100);//Prevents continious requests

            double distanceInKm = 100.00001;
            string drivingTime;

            string url = @"https://maps.googleapis.com/maps/api/distancematrix/xml?units=imperial" +
                "&origins=" + originAddress.ToString() +
                "&destinations=" + destinationAddress.ToString() +
                "&key=AIzaSyADtzLMIItcgU6_9jSifNHC8oMmDN6bpdA";

            //request from Google Distance Matrix API service the distance between the 2 addresses
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            //the response is given in an XML format
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);

            //If we have an answer
            if (xmldoc.GetElementsByTagName("status")[0].ChildNodes[0].InnerText == "OK")
            {
                //If one of the addresses is not found   
                if (xmldoc.GetElementsByTagName("status")[1].ChildNodes[0].InnerText == "NOT_FOUND")
                {
                    Console.WriteLine("one of the adrresses is not found");
                }
                //if 2 of the addresses are found
                else
                {
                    //the returned distance         
                    XmlNodeList distanceXml = xmldoc.GetElementsByTagName("distance");
                    double distanceInMiles = Convert.ToDouble(distanceXml[0].ChildNodes[1].InnerText.Replace(" mi", ""));
                    
                    distanceInKm = distanceInMiles * 1.609344;
                    m_xamlImp.AddDistance(new DistanceStruct(originAddress, destinationAddress, distanceInKm));

                    //the returned duration         
                    XmlNodeList duration = xmldoc.GetElementsByTagName("duration");
                    string dur = duration[0].ChildNodes[1].InnerText;

                    drivingTime = dur;
                }
            }
            //we have no answer, the web is busy, the waiting time for answer is limited (QUERY_OVER_LIMIT), we should try again (at least 2 seconds between 2 requests) 
            else
            {
                Console.WriteLine("We have'nt got an answer, maybe the net is busy...");
            }

            return distanceInKm;
        }

        /// <summary>
        /// Returns true if a distance between two addresses of DistanceStruct object was found in the DataSource
        /// </summary>
        /// <param name="distanceTarget">Distance object to be checked</param>
        /// <returns></returns>
        public static bool IsDistanceExist(DistanceStruct distanceTarget)
        {
            foreach (DistanceStruct distance in m_xamlImp.GetAllDistances())
            {
                if (distance == distanceTarget)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Returns true if a distance between two addresses was found in the DataSource
        /// </summary>
        /// <param name="originAddress">Origin address</param>
        /// <param name="destinationAddress">Destination address</param>
        /// <returns></returns>
        public static bool IsDistanceExist(AddressStruct originAddress, AddressStruct destinationAddress)
        {
            DistanceStruct distanceTarget = new DistanceStruct(originAddress, destinationAddress, 0);

            foreach (DistanceStruct distance in m_xamlImp.GetAllDistances())
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
        /// Returns all testers in a specific range
        /// </summary>
        /// <param name="distance">Distance to be checked</param>
        /// <returns></returns>
        public static List<Tester> GetAllTestersInRange(double distance)
        {
            var result = from tester in m_testersList
                                  where tester.MaximalDistance >= distance
                                  select tester;

            return result.ToList();
        }
        /// <summary>
        /// Returns ALL testers in range from a specified address
        /// </summary>
        /// <param name="address">Address to calculate the distance from</param>
        /// <returns></returns>
        public static List<Tester> GetAllTestersInRange(AddressStruct address)
        {
            List<Tester> testersInRange = new List<Tester>();

            foreach (Tester tester in m_testersList)
            {
                //double distance = GetDistanceFromDataSource(tester.Address, address);

                double distance = -1;
                if (distance != -1)
                {
                    if (distance <= tester.MaximalDistance)
                    {
                        testersInRange.Add(tester);
                    }
                }
                else
                {
                    distance = CalculateDistanceGoogle(tester.Address, address);

                    if (distance <= tester.MaximalDistance)
                    {
                        testersInRange.Add(tester);
                    }
                }
            }

            return testersInRange;
        }
        /// <summary>
        /// Given a list of testers, returns all testers in range from a specified address
        /// </summary>
        /// <param name="testersList">Testers to be examined</param>
        /// <param name="address">Address to calculate the distance from</param>
        /// <returns></returns>
        public static List<Tester> GetAllTestersInRange(List<Tester> testersList, AddressStruct address)
        {
            List<Tester> testersInRange = new List<Tester>();

            foreach (Tester tester in testersList)
            {
                //double distance = GetDistanceFromDataSource(tester.Address, address);

                double distance = -1;

                if (distance != -1)
                {
                    if (distance <= tester.MaximalDistance)
                    {
                        testersInRange.Add(tester);
                    }
                }
                else
                {
                    distance = CalculateDistanceGoogle(tester.Address, address);

                    if (distance <= tester.MaximalDistance)
                    {
                        testersInRange.Add(tester);
                    }
                }
            }

            return testersInRange;
        }
        /// <summary>
        /// Returns the distance between two addresses if found in the DataSource. Returns -1 if not found
        /// </summary>
        /// <param name="originAddress">Origin address</param>
        /// <param name="destinationAddress">Destination address</param>
        /// <returns></returns>
        public static double GetDistanceFromDataSource(AddressStruct originAddress, 
                                                       AddressStruct destinationAddress)
        {
            DistanceStruct distanceTarget = new DistanceStruct(originAddress, destinationAddress, 0);

            foreach (DistanceStruct distance in m_xamlImp.GetAllDistances())
            {
                if (distance == distanceTarget)
                {
                    return distance.Distance;
                }
            }

            return -1;
        }
        /// <summary>
        /// Search tester by Id and return the corresponding Tester object if found. If not found, return null.
        /// </summary>
        /// <param name="testerId">Id of a tester.</param>
        /// <returns>If found - return the Tester object with the corresponding Id. else - Return null.</returns>
        public static Tester GetTesterById(string testerId)
        {
            List<Tester> testersList = m_xamlImp.GetAllTesters();

            foreach (Tester tester in testersList)
            {
                if (testerId == tester.Id)
                {
                    return tester;
                }
            }

            return null;
        }
        /// <summary>
        /// Search trainee by Id and return the corresponding Trainee object if found. If not found, return null.
        /// </summary>
        /// <param name="traineeId">Id of a trainee.</param>
        /// <returns>If found - return the Trainee object with the corresponding Id. else - Return null.</returns>
        public static Trainee GetTraineeById(string traineeId)
        {
            List<Trainee> traineesList = m_xamlImp.GetAllTrainees();

            foreach (Trainee trainee in traineesList)
            {
                if (traineeId == trainee.Id)
                {
                    return trainee;
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
        /// <summary>
        /// Search the DataSource for the closest tester to a given address
        /// </summary>
        /// <param name="address">Address to be checked</param>
        /// <returns></returns>
        public static Tester GetClosestTester(AddressStruct address)
        {
            List<Tester> testers = new List<Tester>();
            List<DistanceStruct> distances = new List<DistanceStruct>();

            double minDistance;
            Tester closestTester = null;

            foreach(Tester tester in m_testersList)
            {
                double distance = GetDistanceFromDataSource(tester.Address, address);

                //If there is no internet connection
                if (distance == -2)
                {
                    return null;
                }
                if (distance != -1)
                {
                    testers.Add(tester);
                    distances.Add(new DistanceStruct(tester.Address, address, distance));
                    m_xamlImp.AddDistance(new DistanceStruct(tester.Address, address, distance));
                }
                else 
                {
                    distance = CalculateDistanceGoogle(tester.Address, address);

                    if (distance != 100.00001)
                    {
                        testers.Add(tester);
                        distances.Add(new DistanceStruct(tester.Address, address, distance));
                        m_xamlImp.AddDistance(new DistanceStruct(tester.Address, address, distance));
                    }
                }
            }

            if (testers.Count == 0)
            {
                return null;
            }

            minDistance = distances[0].Distance;
            closestTester = testers[0];
            for (int i = 1; i < testers.Count; ++i)
            {
                if (distances[i].Distance < minDistance)
                {
                    if (closestTester == null)
                    {
                        closestTester = new Tester();
                    }

                    minDistance = distances[i].Distance;
                    closestTester = testers[i];
                }
            }

            return closestTester;
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
        //Copy operations
        /// <summary>
        /// Copy trainee's properties to another trainee
        /// </summary>
        /// <param name="targetTrainee">Trainee to be copied to</param>
        /// <param name="sourceTrainee">Trainee to be copied from</param>
        public static void CopyTrainees(ref Trainee targetTrainee, Trainee sourceTrainee)
        {
            targetTrainee.Id = sourceTrainee.Id;
            targetTrainee.FirstName = sourceTrainee.FirstName;
            targetTrainee.LastName = sourceTrainee.LastName;
            targetTrainee.DateOfBirth = targetTrainee.DateOfBirth;
            targetTrainee.Gender = sourceTrainee.Gender;
            targetTrainee.PhoneNumber = sourceTrainee.PhoneNumber;
            targetTrainee.Address = sourceTrainee.Address;
            targetTrainee.EmailAddress = sourceTrainee.EmailAddress;
            targetTrainee.CarType = sourceTrainee.CarType;
            targetTrainee.GearType = sourceTrainee.GearType;
            targetTrainee.FullDrivingSchoolDetails = sourceTrainee.FullDrivingSchoolDetails;
            targetTrainee.DrivingSchoolTeacher = sourceTrainee.DrivingSchoolTeacher;
            targetTrainee.DrivingLessonsCount = sourceTrainee.DrivingLessonsCount;
            targetTrainee.ScheduleList = sourceTrainee.ScheduleList;
            targetTrainee.OwnedLisences = sourceTrainee.OwnedLisences;
        }
        /// <summary>
        /// Copy test's properties to another test
        /// </summary>
        /// <param name="targetTest">Test to be copied to</param>
        /// <param name="sourceTest">Test to copied from</param>
        public static void CopyTests(ref Test targetTest, Test sourceTest)
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
