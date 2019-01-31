using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Trainee : Person
    {
        public CarTypeEnum CarType { get; set; }//Private / Truck / Motorcycle etc...
        public GearTypeEnum GearType { get; set; }//Auto / Manual
        public DrivingSchool FullDrivingSchoolDetails { get; set; }
        public string DrivingSchoolTeacher { get; set; }
        public int DrivingLessonsCount { get; set; }

        //Added properties
        public List<Lisence> OwnedLisences { get; set; }
        public List<ScheduleStruct> ScheduleList { get; set; } = new List<ScheduleStruct>();
        
        //Read Only Properties
        public int DaysPassedSinceLastTest
        {
            get
            {
                TimeSpan ts = DateTime.Now - DateOfLastTest;
                return ts.Days;
            }
        }
        public Lisence WantedLisence { get { return new Lisence(CarType, GearType); } }
        public string DrivingSchoolCity { get { return FullDrivingSchoolDetails.City.Trim(); } }
        public string DrivingSchoolName { get { return FullDrivingSchoolDetails.Name.Trim(); } }
        public string DateOfLastTestStringFormat { get { return DateOfLastTest.ToString(); } }
        public DateTime DateOfLastTest
        {
            get
            {
                if (ScheduleList.Count == 0)
                {
                    return new DateTime();
                }

                DateTime latestTestDate = ScheduleList[0].TestDateTime;

                foreach (ScheduleStruct schedule in ScheduleList)
                {
                    if (schedule.TestDateTime < DateTime.Now)
                    {
                        if (schedule.TestDateTime > latestTestDate)
                        {
                            latestTestDate = schedule.TestDateTime;
                        }
                    }
                }

                return latestTestDate;
            }
        }

        //Overrides
        public override string ToString()
        {
            return base.ToString() + "\n"
                + "Car Type: " + CarType + "\n"
                + "Gear Type: " + GearType + "\n"
                + "Driving School: " + FullDrivingSchoolDetails + "\n"
                + "Driving Teacher: " + DrivingSchoolTeacher + "\n"
                + "Number of Driving Lessons: " + DrivingLessonsCount + "\n"
                + "Date of Last Test: " + DateOfLastTest + "\n"
                + "Days Passed Since Last Test: " + DaysPassedSinceLastTest + "\n"
                + "Owned Lisences: " + OwnedLisences;
        }

        //Constructors
        public Trainee(string id, string lastName, string firstName, MyDate dateOfBirth, GenderEnum gender,
                       string phoneNumber, AddressStruct address, string emailAddress, CarTypeEnum carType, 
                       GearTypeEnum gearType, DrivingSchool drivingSchool, string drivingTeacher, 
                       int drivingLessonsCount)
              : base(id, lastName, firstName, dateOfBirth, gender, phoneNumber, address, emailAddress)
        {
            CarType = carType;
            GearType = gearType;
            FullDrivingSchoolDetails = drivingSchool;
            DrivingSchoolTeacher = drivingTeacher;
            DrivingLessonsCount = drivingLessonsCount;
            OwnedLisences = new List<Lisence>();
            ScheduleList = new List<ScheduleStruct>();
        }
        public Trainee(Trainee trainee) : base(trainee.Id, trainee.LastName, trainee.FirstName,
                                               trainee.DateOfBirth, trainee.Gender, trainee.PhoneNumber,
                                               trainee.Address, trainee.EmailAddress)
        {
            CarType = trainee.CarType;
            GearType = trainee.GearType;
            FullDrivingSchoolDetails = trainee.FullDrivingSchoolDetails;
            DrivingSchoolTeacher = trainee.DrivingSchoolTeacher;
            DrivingLessonsCount = trainee.DrivingLessonsCount;

            OwnedLisences = new List<Lisence>();
            foreach (Lisence lisence in trainee.OwnedLisences)
            {
                OwnedLisences.Add(lisence);
            }

            ScheduleList = new List<ScheduleStruct>();
            foreach (ScheduleStruct schedule in trainee.ScheduleList)
            {
                ScheduleList.Add(schedule);
            }
        }
        public Trainee()
        {

        }

        //Methods
        public Trainee Clone()
        {
            return new Trainee(this);
        }
    }
}