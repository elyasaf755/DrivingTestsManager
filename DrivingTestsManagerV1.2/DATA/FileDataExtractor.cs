using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DATA
{
    public class FileDataExtractor
    {
        public static List<City> CitiesList = new List<City>();
        public static List<DrivingSchoolCity> DrivingSchoolsCitiesList = new List<DrivingSchoolCity>();
        public static List<DrivingSchool> DrivingSchoolsList = new List<DrivingSchool>();

        public static List<string> CitiesListStringFormat = new List<string>();
        public static List<string> DrivingSchoolsCitiesListStringFormat = new List<string>();

        public FileDataExtractor()
        {
            InitializeLists(ref CitiesList, ref DrivingSchoolsCitiesList, ref CitiesListStringFormat, ref DrivingSchoolsCitiesListStringFormat);

            DataSource.CitiesList = CitiesList;
            DataSource.DrivingSchoolsCities = DrivingSchoolsCitiesList;
            DataSource.CitiesStringList = CitiesListStringFormat;
            DataSource.DrivingSchoolsCitiesStringFormat = DrivingSchoolsCitiesListStringFormat;
            DataSource.DrivingSchools = DrivingSchoolsList;
        }

        private void InitializeLists(ref List<City> MyCities, ref List<DrivingSchoolCity> MyDrivingSchools,
            ref List<string> CitiesStringFormat, ref List<string> DrivingSchoolsCities)
        {
            General general = new General();

            #region Get Cities
            //Load file
            List<string> file = general.loadCsvFile(@"..\..\..\DATA\DataFiles\StreetsUnicode.txt");

            //Remove Headers
            file.RemoveAt(0);
            file.RemoveAt(0);

            CitiesStringFormat = GetAllCitiesStringFormatFromFile(file);
            MyCities = GetAllCities(file, CitiesStringFormat);
            CitiesStringFormat = GetUniqueCities(MyCities);
            CitiesStringFormat = CitiesStringFormat.OrderBy(str => str).ToList();
            #endregion

            #region Get Driving Schools
            //Load file
            file = general.loadCsvFile(@"..\..\..\DATA\DataFiles\DrivingSchoolsUnicode.txt");

            //Remove headers
            file.RemoveAt(0);

            DrivingSchoolsCities = GetAllDrivingSchoolsCities(file);
            MyDrivingSchools = GetAllDrivingSchools(file, DrivingSchoolsCities);
            DrivingSchoolsCities = GetUniqueDrivingSchoolCities(MyDrivingSchools);
            //Sort By Name
            DrivingSchoolsCities = DrivingSchoolsCities.OrderBy(str => str).ToList();
            CleanDrivingSchoolNames(ref MyDrivingSchools);

            DrivingSchoolsList = GetAllDrivingSchoolsFromFile(file);
            #endregion
        }

        private List<string> GetColumnInFile(List<string> file, int columnNumber, char seperator)
        {
            List<string> result = new List<string>();

            foreach (string line in file)
            {
                int columnStartIndex = GetStartIndexOfColumnInLine(line, columnNumber, seperator);
                result.Add(GetColumnDataInLine(line, columnStartIndex, seperator));
            }

            return result;
        }
        private static int GetStartIndexOfColumnInLine(string line, int columnNumber, char seperator)
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
        private static string GetColumnDataInLine(string line, int startIndex, char seperator)
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
                    result = result.Trim();
                    return result;
                }
            }
            
            return result.Trim();
        }

        private List<City> GetAllCities(List<string> list, List<string> cityList)
        {
            List<City> result = new List<City>();

            string currCity;
            for (int i = 0; i < list.Count - 1; ++i)
            {
                currCity = cityList[i];
                City tempCity = new City();
                tempCity.city = currCity;
                tempCity.streets = new List<string>();
                List<string> tempStreets = new List<string>();

                while (GetCityStoredInLine(list[i], ',') == currCity)
                {
                    tempStreets.Add(GetStreetStoredInLine(list[i], ','));
                    ++i;
                }
                tempCity.streets = tempStreets;
                result.Add(tempCity);
                --i;
            }

            return result;
        }
        private string GetCityStoredInLine(string line, char seperator)
        {
            return GetColumnDataInLine(line, GetStartIndexOfColumnInLine(line, 2, seperator), seperator);
        }
        private string GetStreetStoredInLine(string line, char seperator)
        {
            return GetColumnDataInLine(line, GetStartIndexOfColumnInLine(line, 4, seperator), seperator);
        }
        private List<string> GetAllCitiesStringFormatFromFile(List<string> file)
        {
            return GetColumnInFile(file, 2, ',');
        }
        private List<string> GetAllStreetsStringFormatFromFile(List<string> file)
        {
            return GetColumnInFile(file, 4, ',');
        }
        private List<string> GetUniqueCities(List<City> CityList)
        {
            List<string> result = new List<string>();

            foreach (City city in CityList)
            {
                result.Add(city.city);
            }

            return result;
        }

        private List<DrivingSchoolCity> GetAllDrivingSchools(List<string> list, List<string> drivingSchoolCityList)
        {
            List<DrivingSchoolCity> result = new List<DrivingSchoolCity>();

            string currCity;
            for (int i = 0; i < list.Count - 1; ++i)
            {
                currCity = drivingSchoolCityList[i].TrimEnd().TrimStart();
                DrivingSchoolCity tempCity = new DrivingSchoolCity();
                tempCity.City = currCity;
                tempCity.DrivingSchools = new List<string>();
                List<string> tempDrivingSchools = new List<string>();

                while (GetCityOfDrivingSchoolInLine(list[i], '|') == currCity)
                {
                    tempDrivingSchools.Add(GetDrivingSchoolNameInLine(list[i], '|').Trim());
                    ++i;
                    if (i == list.Count)
                    {
                        break;
                    }
                }
                tempCity.DrivingSchools = tempDrivingSchools;
                result.Add(tempCity);
                --i;
            }

            return result;
        }
        private string GetCityOfDrivingSchoolInLine(string line, char seperator)
        {
            return GetColumnDataInLine(line, GetStartIndexOfColumnInLine(line, 1, seperator), seperator);
        }
        private string GetDrivingSchoolNameInLine(string line, char seperator)
        {
            return GetColumnDataInLine(line, GetStartIndexOfColumnInLine(line, 3, seperator), seperator).Trim();
        }
        private List<string> GetAllDrivingSchoolsCities(List<string> file)
        {
            return GetColumnInFile(file, 1, '|');
        }
        private List<string> GetUniqueDrivingSchoolCities(List<DrivingSchoolCity> DrivingSchoolCityList)
        {
            List<string> result = new List<string>();

            foreach (DrivingSchoolCity school in DrivingSchoolCityList)
            {
                result.Add(school.City.Trim());
            }

            return result;
        }

        private List<DrivingSchool> GetAllDrivingSchoolsFromFile(List<string> file)
        {
            List<DrivingSchool> drivingSchools = new List<DrivingSchool>();

            foreach (string line in file)
            {
                drivingSchools.Add(GetDrivingSchoolFromLine(line));
            }

            return drivingSchools;
        }
        private DrivingSchool GetDrivingSchoolFromLine(string line)
        {   //          1                         3                                           8     9    10     11    12    
            //cod_ezor|ezor|cod_beit_sefer|shem_beit_sefer|cod_hiter|menahel|ktovet|telefon|prati|masa|traktor|ofnoa|otobus|grar
            int cityStartIndex = GetStartIndexOfColumnInLine(line, 1, '|');
            int nameStartIndex = GetStartIndexOfColumnInLine(line, 3, '|');

            return new DrivingSchool()
            {
                City = CleanString(GetColumnDataInLine(line, cityStartIndex, '|')),
                Name = CleanString(GetColumnDataInLine(line, nameStartIndex, '|').Trim()),
                CarTypes = GetCarTypeEnumsFromLine(line)
            };
        }
        private CarTypeEnum[] GetCarTypeEnumsFromLine(string line)
        {
            //          1                         3                                           8     9    10     11    12    
            //cod_ezor|ezor|cod_beit_sefer|shem_beit_sefer|cod_hiter|menahel|ktovet|telefon|prati|masa|traktor|ofnoa|otobus|grar
            int privateStartIndex = GetStartIndexOfColumnInLine(line, 8, '|');
            int truckStartIndex = GetStartIndexOfColumnInLine(line, 9, '|');
            int traktorStartIndex = GetStartIndexOfColumnInLine(line, 10, '|');
            int motorcycleStartIndex = GetStartIndexOfColumnInLine(line, 11, '|');
            int busStartIndex = GetStartIndexOfColumnInLine(line, 12, '|');

            CarTypeEnum[] carTypes = new CarTypeEnum[5];

            if (GetColumnDataInLine(line, privateStartIndex, '|') == "0")
                carTypes[0] = CarTypeEnum.Private;
            else
                carTypes[0] = CarTypeEnum.None;

            if (GetColumnDataInLine(line, truckStartIndex, '|') == "0")
                carTypes[1] = CarTypeEnum.Truck;
            else
                carTypes[1] = CarTypeEnum.None;

            if (GetColumnDataInLine(line, traktorStartIndex, '|') == "0")
                carTypes[2] = CarTypeEnum.Tractor;
            else
                carTypes[2] = CarTypeEnum.None;

            if (GetColumnDataInLine(line, motorcycleStartIndex, '|') == "0")
                carTypes[3] = CarTypeEnum.Motorcycle;
            else
                carTypes[3] = CarTypeEnum.None;

            if (GetColumnDataInLine(line, busStartIndex, '|') == "0")
                carTypes[4] = CarTypeEnum.Bus;
            else
                carTypes[4] = CarTypeEnum.None;

            return carTypes;
        }
        
        private static void CleanDrivingSchoolNames(ref List<DrivingSchoolCity> DrivingSchoolsCitiesList)
        {
            for (int i = 0; i < DrivingSchoolsCitiesList.Count; ++i)
            {
                for (int j = 0; j < DrivingSchoolsCitiesList[i].DrivingSchools.Count; ++j)
                {
                    string schoolName = DrivingSchoolsCitiesList[i].DrivingSchools[j];
                    schoolName = schoolName.Trim();
                    RemoveDuplicateChar(ref schoolName, '"');
                    schoolName = TrimChar(schoolName, '"');
                    schoolName = TrimChar(schoolName, '"');
                    schoolName = TrimChar(schoolName, '-');
                    DrivingSchoolsCitiesList[i].DrivingSchools[j] = schoolName;
                }
            }
        }
        private static string CleanString(string str)
        {
            str = str.Trim();
            RemoveDuplicateChar(ref str, '"');
            str = TrimChar(str, '"');
            str = TrimChar(str, '"');
            str = TrimChar(str, '-');

            return str.Trim();
        }
        private static string TrimChar(string str, char c)
        {
            if (str == "")
            {
                return null;
            }

            if (str[0] == c)
            {
                str = str.Substring(1);
            }
            if (str[str.Length - 1] == c)
            {
                str = str.Substring(0, str.Length - 1);
            }

            return str;
        }
        private static void RemoveDuplicateChar(ref string str, char c)
        {
            if (str.Length < 2)
            {
                return;
            }

            for (int i = 1; i < str.Length; ++i)
            {
                if (str[i] == str[i - 1] && str[i] == c)
                {
                    str = str.Substring(0, i - 1) + str.Substring(i + 1);
                    --i;
                }
            }
        }
    }
}
