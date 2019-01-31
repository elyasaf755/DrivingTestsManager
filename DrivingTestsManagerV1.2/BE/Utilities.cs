using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public static class Utilities
    {
        /// <summary>
        /// Convert DateTime type to MyDate type.
        /// </summary>
        /// <param name="dateTime">DateTime to be converted to MyDate.</param>
        /// <returns></returns>
        public static MyDate ConvertToMyDate(DateTime dateTime)
        {
            return new MyDate() { Year = dateTime.Year, Month = dateTime.Month, Day = dateTime.Day };
        }
        public static MyDate ConvertStringToMyDate(string date)
        {
            int monthIndex = GetStartIndexOfColumnInLine(date, 1, '/');
            int yearIndex = GetStartIndexOfColumnInLine(date, 2, '/');

            return new MyDate()
            {
                Day = int.Parse(GetColumnDataInLine(date, 0, '/')),
                Month = int.Parse(GetColumnDataInLine(date, monthIndex, '/')),
                Year = int.Parse(GetColumnDataInLine(date, yearIndex, '/'))
            };
        }
        /// <summary>
        /// Convert MyDate type to DateTime type.
        /// </summary>
        /// <param name="dateTime">MyDaate to be converted to DateTime.</param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(MyDate myDate)
        {
            return new DateTime(myDate.Year, myDate.Month, myDate.Day);
        }
        public static DateTime ConvertStringToDateTime(string date)
        {
            return DateTime.Parse(date);
        }
        public static Lisence ConvertStringToLisence(string lisence)
        {
            int carTypeStartIndex = GetStartIndexOfColumnInLine(lisence, 0, ',');
            int gearTypeStartIndex = GetStartIndexOfColumnInLine(lisence, 1, ',');

            return new Lisence()
            {
                carType = ConvertStringToCarTypeEnum(GetColumnDataInLine(lisence, carTypeStartIndex, ',')),
                gearType = ConvertStringToGearTypeEnum(GetColumnDataInLine(lisence, gearTypeStartIndex, ','))
            };

        }
        public static DrivingSchool ConvertStringToDrivingSchool(string drivingSchool)
        {
            int nameStartIndex = GetStartIndexOfColumnInLine(drivingSchool, 1, ',');
            int carTypesStartIndex = GetStartIndexOfColumnInLine(drivingSchool, 2, ',');

            return new DrivingSchool()
            {
                City = GetColumnDataInLine(drivingSchool, 0, ','),
                Name = GetColumnDataInLine(drivingSchool, nameStartIndex, ','),
                CarTypes = ConvertStringToCarTypes(GetColumnDataInLine(drivingSchool,
                                                                               carTypesStartIndex,
                                                                               ','))
            };
        }
        public static CarTypeEnum[] ConvertStringToCarTypes(string carTypes)
        {
            int privateStartIndex = GetStartIndexOfColumnInLine(carTypes, 0, '|');
            int truckStartIndex = GetStartIndexOfColumnInLine(carTypes, 1, '|');
            int tractorStartIndex = GetStartIndexOfColumnInLine(carTypes, 2, '|');
            int motorcycleStartIndex = GetStartIndexOfColumnInLine(carTypes, 3, '|');
            int busStartIndex = GetStartIndexOfColumnInLine(carTypes, 3, '|');

            CarTypeEnum[] result = new CarTypeEnum[5];

            result[0] = ConvertStringToCarTypeEnum(GetColumnDataInLine(carTypes, privateStartIndex, '|'));
            result[1] = ConvertStringToCarTypeEnum(GetColumnDataInLine(carTypes, truckStartIndex, '|'));
            result[2] = ConvertStringToCarTypeEnum(GetColumnDataInLine(carTypes, tractorStartIndex, '|'));
            result[3] = ConvertStringToCarTypeEnum(GetColumnDataInLine(carTypes, motorcycleStartIndex, '|'));
            result[4] = ConvertStringToCarTypeEnum(GetColumnDataInLine(carTypes, busStartIndex, '|'));

            return result;
        }
        /// <summary>  
        /// Calculates the age of a person by a given date of birth  
        /// </summary>  
        /// <param name="person">Person to be checked</param>  
        /// <returns> years, months,days, hours...</returns>  
        public static Age CalculateAge(DateTime person)
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
        public static GenderEnum ConvertStringToGenderEnum(string gender)
        {
            GenderEnum result = new GenderEnum();

            Enum.TryParse(gender, out result);

            return result;
        }
        public static CarTypeEnum ConvertStringToCarTypeEnum(string carType)
        {
            CarTypeEnum result = new CarTypeEnum();

            Enum.TryParse(carType, out result);

            return result;
        }
        public static GearTypeEnum ConvertStringToGearTypeEnum(string gearType)
        {
            GearTypeEnum result;

            Enum.TryParse(gearType, out result);

            return result;
        }
        public static AddressStruct ConvertStringToAddressStruct(string address)
        {
            int streetIndex = GetStartIndexOfColumnInLine(address, 1, ',');
            int buildingIndex = GetStartIndexOfColumnInLine(address, 2, ',');
            int seperatorsCount = GetSeperatorsCount(address, ',');

            string city, street, building;

            switch (seperatorsCount)
            {
                case 0:
                    city = GetColumnDataInLine(address, 0, ',');
                    return new AddressStruct(city, "", "");
                case 1:
                    city = GetColumnDataInLine(address, 0, ',');
                    street = GetColumnDataInLine(address, streetIndex, ',');
                    return new AddressStruct(city, street, "");
                case 2:
                    city = GetColumnDataInLine(address, 0, ',');
                    street = GetColumnDataInLine(address, streetIndex, ',');
                    building = GetColumnDataInLine(address, buildingIndex, ',');
                    return new AddressStruct(city, street, building);
                default:
                    return new AddressStruct("", "", "");
            }
        }
        public static AccessLevelEnum ConvertStringToAccessLevelEnum(string accessLevel)
        {
            AccessLevelEnum temp;

            Enum.TryParse(accessLevel, out temp);

            return temp;
        }

        public static int GetStartIndexOfColumnInLine(string line, int columnNumber, char seperator)
        {
            int commaCounter = 0;

            for (int i = 0; i < line.Length; ++i)
            {
                if (commaCounter == columnNumber)
                {
                    return i;
                }
                if (line[i] == seperator)
                {
                    ++commaCounter;
                }
            }

            return commaCounter;
        }
        public static string GetColumnDataInLine(string line, int startIndex, char seperator)
        {
            line = line.Substring(startIndex);

            string result = "";
            foreach (char c in line)
            {
                if (c != seperator)
                {
                    result += c;
                }
                else
                {
                    result = result.TrimEnd();
                    return result;
                }
            }

            result = result.TrimEnd().TrimStart();
            return result;
        }

        private static int GetSeperatorsCount(string line, char seperator)
        {
            int count = 0;

            foreach(char c in line)
            {
                if (c == seperator)
                {
                    ++count;
                }
            }

            return count;
        }
    }
}
