using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using BE;
using DATA;

namespace DAL
{
    internal class DAL_Imp : IDal
    {
        //Private Members
        private IDal m_xaml_Imp = DalFactory.GetIDalXaml();

        //Constructors
        public DAL_Imp()
        {
            DataSource ds = new DataSource();
        }

        public void AddTest(Test test)
        {
            m_xaml_Imp.AddTest(test);
        }
        public string AddTester(Tester tester)
        {
            return m_xaml_Imp.AddTester(tester);
        }
        public string AddTrainee(Trainee trainee)
        {
            return m_xaml_Imp.AddTrainee(trainee);
        }

        public string UpdateTest(int targetTestId, Test sourceTest)
        {
            return m_xaml_Imp.UpdateTest(targetTestId, sourceTest);
        }
        public string UpdateTester(Tester targetTester, Tester sourceTester)
        {
            return m_xaml_Imp.UpdateTester(targetTester, sourceTester);
        }
        public string UpdateTrainee(Trainee targetTrainee, Trainee sourceTrainee)
        {
            return UpdateTrainee(targetTrainee, sourceTrainee);
        }

        public string DeleteTester(Tester tester)
        {
            return m_xaml_Imp.DeleteTester(tester);
        }
        public string DeleteTrainee(Trainee trainee)
        {
            return m_xaml_Imp.DeleteTrainee(trainee);
        }

        public List<Tester> GetAllTesters()
        {
            return m_xaml_Imp.GetAllTesters();
        }
        public List<Test> GetAllTests()
        {
            return m_xaml_Imp.GetAllTests();
        }
        public List<Trainee> GetAllTrainees()
        {
            return m_xaml_Imp.GetAllTrainees();
        }
        
        public List<City> GetAllCities()
        {
            return m_xaml_Imp.GetAllCities();
        }
        public List<string> GetAllCitiesStringFormat()
        {
            return m_xaml_Imp.GetAllCitiesStringFormat();
        }

        public List<DrivingSchoolCity> GetAllDrivingSchoolsCities()
        {
            return m_xaml_Imp.GetAllDrivingSchoolsCities();
        }
        public List<string> GetAllDrivingSchoolsCitiesStringFormat()
        {
            return m_xaml_Imp.GetAllDrivingSchoolsCitiesStringFormat();
        }
        public List<DrivingSchool> GetAllDrivingSchools()
        {
            return m_xaml_Imp.GetAllDrivingSchools();
        }

        public List<string> GetAllDMVs()
        {
            return m_xaml_Imp.GetAllDMVs();
        }

        public void AddDistance(DistanceStruct distance)
        {
            DataSource.DistancesList.Add(distance);
            DataSource.DistancesList.Sort((d1, d2) => d1.OriginAddress.CompareTo(d2.OriginAddress));
        }
        public List<DistanceStruct> GetAllDistances()
        {
            return m_xaml_Imp.GetAllDistances();
        }

        //Permissons
        public List<Permisson> GetAllPermissions()
        {
            return m_xaml_Imp.GetAllPermissions();
        }

        //Configurations
        public void UpdateConfigurations()
        {
            m_xaml_Imp.UpdateConfigurations();
        }
    }
}
