using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BE
{
    public class Person
    {
        private AddressStruct m_address;

        //Public properties
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public MyDate DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        public string PhoneNumber { get; set; }
        public AddressStruct Address
        {
            get { return m_address; }
            set
            {
                m_address.City = value.City.TrimStart().TrimEnd();
                m_address.Street = value.Street.TrimStart().TrimEnd();
                m_address.Building = value.Building.TrimStart().TrimEnd();
            }
        }

        //Added properties
        public string EmailAddress { get; set; }

        //Read Only Properties
        public Age FullAge
        {
            get { return CalculateAge(ConvertToDateTime(DateOfBirth)); }
        }
        public int Age
        {
            get { return FullAge.Years; }
        }
        public string City { get { return Address.City; } }
        public string Street { get { return Address.Street; } }
        public string Building { get { return Address.Building; } }
        public int Year { get { return DateOfBirth.Year; } }
        public int Month { get { return DateOfBirth.Month; } }
        public int Day { get { return DateOfBirth.Day; } }
        public string DateOfBirthStringFormat { get { return DateOfBirth.ToString(); } }
        public string AddressStringFormat { get { return Address.ToString(); } }

        //Getters
        /// <summary>
        /// Returns the full name of a person
        /// The format is "[First Name] [Last Name]"
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return FirstName + " " + LastName;
        }

        //Overrides
        public override string ToString()
        {
            return "ID: " + Id.ToString() + "\n"
                + "Last Name: " + LastName + "\n"
                + "First Name: " + FirstName + "\n"
                + "Date of Birth: " + DateOfBirth + "\n"
                + "Gender: " + Gender + "\n"
                + "Phone Number: " + PhoneNumber + "\n"
                + "Address: " + Address + "\n"
                + "Age: " + FullAge + "\n"
                + "Email: " + EmailAddress;
        }
        
        //Constructors
        public Person(string id, string lastName, string firstName, MyDate dateOfBirth,
            GenderEnum gender, string phoneNumber, AddressStruct address, string emailAddress)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Address = address;
            EmailAddress = emailAddress;
        }
        public Person()
        {

        }

        //Methods
        /// <summary>  
        /// For calculating age  
        /// </summary>  
        /// <param name="person">Enter Date of Birth to Calculate the age</param>  
        /// <returns> years, months,days, hours...</returns>  
        private Age CalculateAge(DateTime person)
        {
            DateTime now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(person).Ticks).Year - 1;
            DateTime PastYearDate = person.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= now)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = now.Subtract(PastYearDate.AddMonths(Months)).Days;
            int Hours = now.Subtract(PastYearDate).Hours;
            int Minutes = now.Subtract(PastYearDate).Minutes;
            int Seconds = now.Subtract(PastYearDate).Seconds;

            Age age = new Age(Years, Months, Days);
            return age;
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
    }
}