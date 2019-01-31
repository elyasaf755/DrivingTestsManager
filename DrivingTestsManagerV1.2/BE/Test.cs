using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BE
{
    
    public class Test
    {
        //Properties
        public int TestId { get; set; }
        public string TesterId { get; set; }
        public string TraineeId { get; set; }
        public DateTime TestDateAndTime { get; set; }
        public AddressStruct TestLocation { get; set; }
        public bool? IsPassed { get; set; }
        public string TesterNotes { get; set; }

        //Added properties
        public CarTypeEnum CarType { get; set; }
        public DrivingSchool DrivingSchool { get; set; }
        public string DMV { get; set; }

        //Read Only Properties
        public string TestIdStringFormat
        {
            get { return TestId.ToString("00000000"); }
        }
        public string TestDateStringFormat
        {
            get
            {
                return string.Format("{0}/{1}/{2}", TestDateAndTime.Day,
                                                    TestDateAndTime.Month,
                                                    TestDateAndTime.Year);
            }
        }
        public string TestTimeStringFormat
        {
            get
            {
                return string.Format("{0}:{1}", TestDateAndTime.Hour.ToString("00"),
                                                TestDateAndTime.Minute.ToString("00"));
            }
        }
        public string DrivingSchoolFullName
        {
            get
            {
                return DrivingSchool.Name + ", " + DrivingSchool.City;
            }
        }
        public string TestYear { get { return TestDateAndTime.Year.ToString(); } }
        public string TestMonth { get { return TestDateAndTime.Month.ToString(); } }
        public string TestDat { get { return TestDateAndTime.Day.ToString(); } }
        public string TestCity { get { return TestLocation.City; } }
        public string TestStreet { get { return TestLocation.Street; } }

        //Overrides
        public override string ToString()
        {
            string isPassed;
            if (IsPassed == null)
            {
                isPassed = "No Grade Yet";
            }
            else if (IsPassed == true)
            {
                isPassed = "Yes";
            }
            else
            {
                isPassed = "No";
            }

            return "Test#: " + TestIdStringFormat + "\nTester ID: " + TesterId + "\nTrainee ID: " + TraineeId +
                "\nTest's Date & Time: " + TestDateAndTime + "\nTest's Location: " + TestLocation +
                "\nGrade: " + isPassed + "\nTester Notes: " + TesterNotes;
        }

        //Constructors
        public Test(int testId, string testerId, string traineeId, DateTime testDateAndTime,
                    AddressStruct testLocation, string testerNotes, CarTypeEnum carType,
                    DrivingSchool drivingSchool, string dmv)
        {
            TestId = testId;
            TesterId = testerId;
            TraineeId = traineeId;
            TestDateAndTime = testDateAndTime;
            TestLocation = testLocation;
            TesterNotes = testerNotes;
            IsPassed = null;
            CarType = carType;
            DrivingSchool = drivingSchool;
            DMV = dmv;
        }
        public Test(Test test)
        {
            TestId = test.TestId;
            TesterId = test.TesterId;
            TraineeId = test.TraineeId;
            TestDateAndTime = test.TestDateAndTime;
            TestLocation = test.TestLocation;
            TesterNotes = test.TesterNotes;
            IsPassed = test.IsPassed;
            CarType = test.CarType;
            DrivingSchool = test.DrivingSchool;
            DMV = test.DMV;
        }
        public Test()
        {

        }

        //Methods
        public Test Clone()
        {
            return new Test(this);
        }
    }
}
