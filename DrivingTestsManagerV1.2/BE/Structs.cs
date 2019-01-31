using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public struct AddressStruct : IComparable<AddressStruct>
    {
        //Fields
        public string City;
        public string Street;
        public string Building;

        //Constructors
        public AddressStruct(string city, string street, string building)
        {
            City = city.Trim();
            Street = street.Trim();
            Building = building.Trim();
        }

        //Overrides
        public override string ToString()
        {
            if (City == "" || City == null)
            {
                return "";
            }

            if (Street == "" || Street == null)
            {
                return City;
            }

            if (Building == "" || Building == null)
            {
                return City + ", " + Street;
            }

            return City + ", " + Street + ", " + Building;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is AddressStruct))
            {
                return false;
            }

            var @struct = (AddressStruct)obj;
            return City == @struct.City &&
                   Street == @struct.Street &&
                   Building == @struct.Building;
        }
        public override int GetHashCode()
        {
            var hashCode = -2034431195;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Street);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Building);
            return hashCode;
        }

        //Operators
        public static bool operator ==(AddressStruct as1, AddressStruct as2)
        {
            return as1.Equals(as2);
        }
        public static bool operator !=(AddressStruct as1, AddressStruct as2)
        {
            return !as1.Equals(as2);
        }

        public int CompareTo(AddressStruct other)
        {
            return ToString().CompareTo(other.ToString());
        }
    }
    public struct Age
    {
        //Fields
        public int Years;
        public int Months;
        public int Days;

        //Overrides
        public override string ToString()
        {
            return Years.ToString();
        }

        //Constructors.
        public Age(int years, int months, int days)
        {
            Years = years;
            Months = months;
            Days = days;
        }
    }
    public struct MyDate : IComparable<MyDate>, IEquatable<MyDate>
    {
        //Fields
        public int Year;
        public int Month;
        public int Day;

        //Overrides
        public override string ToString()
        {
            return Day + "/" + Month + "/" + Year;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is MyDate))
            {
                return false;
            }

            var date = (MyDate)obj;
            return Year == date.Year &&
                   Month == date.Month &&
                   Day == date.Day;
        }
        public override int GetHashCode()
        {
            var hashCode = 592158470;
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            hashCode = hashCode * -1521134295 + Month.GetHashCode();
            hashCode = hashCode * -1521134295 + Day.GetHashCode();
            return hashCode;
        }

        //Interfaces
        public int CompareTo(MyDate other)
        {
            if (Year < other.Year)
                return -1;
            else if (Year == other.Year)
            {
                if (Month < other.Month)
                    return -1;
                else if (Month == other.Month)
                {
                    if (Day < other.Day)
                        return -1;
                    else if (Day == other.Day)
                        return 0;
                    else
                        return 1;
                }
                else
                    return 1;
            }
            else
                return 1;
        }

        public bool Equals(MyDate other)
        {
            return Year == other.Year && Month == other.Month && Day == other.Day;
        }


        //Constructors
        public MyDate(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }
    }
    public struct City
    {
        //Fields
        public string city;
        public List<string> streets;
    }
    public struct DrivingSchoolCity : IComparable<DrivingSchool>
    {
        //Fields
        public string City;
        public List<string> DrivingSchools;

        //Interfaces Implementations
        public int CompareTo(DrivingSchool other)
        {
            return City.CompareTo(other.City);
        }
    }
    public struct DrivingSchool
    {
        //Fields
        public string City;
        public string Name;
        public CarTypeEnum[] CarTypes;//size of 5 - Private, Truck, Tractor, Motorcycle, Bus

        //Constructors
        public DrivingSchool(string city, string name, CarTypeEnum[] carTypes)
        {
            City = city;
            Name = name;
            CarTypes = carTypes;
        }

        //Overrides
        public override bool Equals(object obj)
        {
            if (!(obj is DrivingSchool))
            {
                return false;
            }

            var school = (DrivingSchool)obj;
            return City == school.City &&
                   Name == school.Name &&
                   EqualityComparer<CarTypeEnum[]>.Default.Equals(CarTypes, school.CarTypes);
        }

        public override int GetHashCode()
        {
            var hashCode = 996520422;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<CarTypeEnum[]>.Default.GetHashCode(CarTypes);
            return hashCode;
        }
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}|{3}|{4}|{5}|{6}", City, Name,
                                                                  CarTypes[0],
                                                                  CarTypes[1],
                                                                  CarTypes[2],
                                                                  CarTypes[3],
                                                                  CarTypes[4]);
        }

        //Operators
        public static bool operator ==(DrivingSchool ds1, DrivingSchool ds2)
        {
            return ds1.Equals(ds2);
        }
        public static bool operator !=(DrivingSchool ds1, DrivingSchool ds2)
        {
            return !ds1.Equals(ds2);
        }
    }
    public struct Lisence
    {
        //Fields
        public CarTypeEnum carType;
        public GearTypeEnum gearType;

        //Constructors
        public Lisence(CarTypeEnum carType, GearTypeEnum gearType)
        {
            this.carType = carType;
            this.gearType = gearType;
        }

        //Overrides
        public override string ToString()
        {
            return carType.ToString() + ", " + gearType.ToString();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Lisence))
            {
                return false;
            }

            var lisence = (Lisence)obj;
            return carType == lisence.carType &&
                   gearType == lisence.gearType;
        }
        public override int GetHashCode()
        {
            var hashCode = 1134910495;
            hashCode = hashCode * -1521134295 + carType.GetHashCode();
            hashCode = hashCode * -1521134295 + gearType.GetHashCode();
            return hashCode;
        }

        //Operators
        public static bool operator ==(Lisence l1, Lisence l2)
        {
            return l1.Equals(l2);
        }
        public static bool operator !=(Lisence l1, Lisence l2)
        {
            return !l1.Equals(l2);
        }
    }
    public struct DistanceStruct
    {
        //Fields
        public AddressStruct OriginAddress;
        public AddressStruct DestinationAddress;
        public double Distance;

        //Constructors
        public DistanceStruct(AddressStruct originAddress, AddressStruct destinationAddress, double distance)
        {
            OriginAddress = originAddress;
            DestinationAddress = destinationAddress;
            Distance = distance;
        }

        //Overrides
        public override bool Equals(object obj)
        {
            if (!(obj is DistanceStruct))
            {
                return false;
            }

            var @struct = (DistanceStruct)obj;

            return OriginAddress.City.Trim() == @struct.OriginAddress.City.Trim() &&
                   OriginAddress.Street.Trim() == @struct.OriginAddress.Street.Trim() &&
                   OriginAddress.Building.Trim() == @struct.OriginAddress.Building.Trim() &&
                   DestinationAddress.City.Trim() == @struct.DestinationAddress.City.Trim() &&
                   DestinationAddress.Street.Trim() == @struct.DestinationAddress.Street.Trim();
        }
        public override int GetHashCode()
        {
            var hashCode = 2104172772;
            hashCode = hashCode * -1521134295 + EqualityComparer<AddressStruct>.Default.GetHashCode(OriginAddress);
            hashCode = hashCode * -1521134295 + EqualityComparer<AddressStruct>.Default.GetHashCode(DestinationAddress);
            hashCode = hashCode * -1521134295 + Distance.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return string.Format("Origin: {0}, Destination: {1}, Distance: {2}",
                                OriginAddress.ToString(), DestinationAddress.ToString(), Distance);
        }

        //Operators
        public static bool operator ==(DistanceStruct ds1, DistanceStruct ds2)
        {
            return ds1.Equals(ds2);
        }
        public static bool operator !=(DistanceStruct ds1, DistanceStruct ds2)
        {
            return !ds1.Equals(ds2);
        }
    }
    public struct ScheduleStruct
    {
        //Fields
        public int TestId;
        public DateTime TestDateTime;

        //Constructors
        public ScheduleStruct(int testId, DateTime testDateTime)
        {
            TestId = testId;
            TestDateTime = testDateTime;
        }

        //Overrides
        public override bool Equals(object obj)
        {
            if (!(obj is ScheduleStruct))
            {
                return false;
            }

            var @struct = (ScheduleStruct)obj;
            return TestId == @struct.TestId &&
                   TestDateTime == @struct.TestDateTime;
        }
        public override int GetHashCode()
        {
            var hashCode = -632508144;
            hashCode = hashCode * -1521134295 + TestId.GetHashCode();
            hashCode = hashCode * -1521134295 + TestDateTime.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return TestId.ToString() + ", " + TestDateTime.ToString();
        }
    }
}
