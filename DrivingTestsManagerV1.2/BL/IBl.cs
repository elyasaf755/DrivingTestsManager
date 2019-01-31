using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBl
    {
        string AddTester(Tester tester);
        string DeleteTester(Tester tester);
        string UpdateTester(Tester targetTester, Tester sourceTester);
        List<Tester> GetAllTesters();

        string AddTrainee(Trainee trainee);
        string DeleteTrainee(Trainee trainee);
        string UpdateTrainee(Trainee targetTester, Trainee sourceTester);
        List<Trainee> GetAllTrainees();

        string AddTest(Test test);
        string UpdateTest(int targetTestId, Test sourceTest);
        List<Test> GetAllTests();

        List<City> GetAllCities();
        List<string> GetAllCitiesStringFormat();
        List<string> GetStreetsOfCity(string city);

        List<DrivingSchoolCity> GetAllDrivingSchoolsCities();
        List<string> GetAllDrivingSchoolsCitiesStringFormat();
        List<string> GetDrivingSchoolsNamesOfCity(string drivingSchoolCity);
        List<DrivingSchool> GetAllDrivingSchools();

        List<string> GetAllDMVs();

        void AddDistance(DistanceStruct distance);
        List<DistanceStruct> GetAllDistances();

        List<Permisson> GetAllPermissions();

        void UpdateConfigurations();
    }
}
