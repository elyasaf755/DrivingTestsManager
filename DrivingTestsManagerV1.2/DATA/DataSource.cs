using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DATA
{
    public class DataSource
    {
        //Entities
        public static List<Tester> TestersList = new List<Tester>();
        public static List<Trainee> TraineesList = new List<Trainee>();
        public static List<Test> TestsList = new List<Test>();

        //Addressed
        public static List<City> CitiesList = FileDataExtractor.CitiesList;
        public static List<string> CitiesStringList = FileDataExtractor.CitiesListStringFormat;
        
        //Driving Schools
        public static List<DrivingSchoolCity> DrivingSchoolsCities = FileDataExtractor.DrivingSchoolsCitiesList;
        public static List<string> DrivingSchoolsCitiesStringFormat = FileDataExtractor.DrivingSchoolsCitiesListStringFormat;
        public static List<DrivingSchool> DrivingSchools { get; set; }

        //Departments of Motor Vehicles List
        public static List<string> DmvList = new List<string>();

        //Distances
        public static List<DistanceStruct> DistancesList { get; set; } = new List<DistanceStruct>();

        //Permissons
        public static List<Permisson> PermissionsList { get; set; } = new List<Permisson>();

        //Constructors
        public DataSource()
        {
            FileDataExtractor m_fde = new FileDataExtractor();
            FillDmvList();
        }

        //ToDo: Store In XML The DMV List
        //Methods
        public void FillDmvList()
        {
            DmvList.Add("אום אל פאחם");
            DmvList.Add("אופקים");
            DmvList.Add("אור יהודה");
            DmvList.Add("אילת");
            DmvList.Add("אריאל");
            DmvList.Add("אשדוד");
            DmvList.Add("אשקלון");
            DmvList.Add("באקה אל גרבייה");
            DmvList.Add("באר שבע");
            DmvList.Add("בית דגן");
            DmvList.Add("בית שאן");
            DmvList.Add("בית שמש");
            DmvList.Add("בת ים");
            DmvList.Add("גבעתיים");
            DmvList.Add("דימונה");
            DmvList.Add("הכרמל");
            DmvList.Add("הרצליה");
            DmvList.Add("זכרון יעקב");
            DmvList.Add("חדרה");
            DmvList.Add("חולון");
            DmvList.Add("חיפה");
            DmvList.Add("טבריה");
            DmvList.Add("טייבה");
            DmvList.Add("טירת הכרמל");
            DmvList.Add("טמרה");
            DmvList.Add("יבנה");
            DmvList.Add("יקנעם");
            DmvList.Add("יקנעם עלית");
            DmvList.Add("ירושלים");
            DmvList.Add("כפר יאסיף");
            DmvList.Add("כפר סבא");
            DmvList.Add("כרמיאל");
            DmvList.Add("לוד");
            DmvList.Add("מבשרת ציון");
            DmvList.Add("מגדל העמק");
            DmvList.Add("מודיעין");
            DmvList.Add("מעלה אדומים");
            DmvList.Add("נס ציונה");
            DmvList.Add("נצרת");
            DmvList.Add("נצרת עילית");
            DmvList.Add("נתב\"ג\"");
            DmvList.Add("נתיבות");
            DmvList.Add("נתניה");
            DmvList.Add("סח'נין");
            DmvList.Add("עכו");
            DmvList.Add("עפולה");
            DmvList.Add("ערד");
            DmvList.Add("פתח תקווה");
            DmvList.Add("צפת");
            DmvList.Add("קריית ארבע");
            DmvList.Add("קריית גת");
            DmvList.Add("קריית מלאכי");
            DmvList.Add("קריית עקרון");
            DmvList.Add("קריית שמונה");
            DmvList.Add("ראש העין");
            DmvList.Add("ראשון לציון");
            DmvList.Add("רגבה");
            DmvList.Add("רהט");
            DmvList.Add("רחובות");
            DmvList.Add("רמלה");
            DmvList.Add("רמת גן");
            DmvList.Add("רמת ישי");
            DmvList.Add("רעננה");
            DmvList.Add("שדרות");
            DmvList.Add("שפרעם");
            DmvList.Add("תל אביב-יפו");
        }
    }
}
