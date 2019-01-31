using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDal
    {
        string AddTester(Tester tester);
        string DeleteTester(Tester tester);
        string UpdateTester(Tester targetTester, Tester sourceTester);
        List<Tester> GetAllTesters();

        string AddTrainee(Trainee trainee);
        string DeleteTrainee(Trainee trainee);
        string UpdateTrainee(Trainee targetTrainee, Trainee sourceTrainee);
        List<Trainee> GetAllTrainees();

        void AddTest(Test test);
        string UpdateTest(int targetTestId, Test sourceTest);
        List<Test> GetAllTests();

        List<City> GetAllCities();
        List<string> GetAllCitiesStringFormat();

        List<DrivingSchoolCity> GetAllDrivingSchoolsCities();
        List<string> GetAllDrivingSchoolsCitiesStringFormat();
        List<DrivingSchool> GetAllDrivingSchools();

        List<string> GetAllDMVs();

        void AddDistance(DistanceStruct distance);
        List<DistanceStruct> GetAllDistances();

        List<Permisson> GetAllPermissions();

        void UpdateConfigurations();
    }
}
