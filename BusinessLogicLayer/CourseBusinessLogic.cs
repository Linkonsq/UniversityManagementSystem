using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CourseBusinessLogic
    {
        CourseDataAccess cda = new CourseDataAccess();

        public dynamic GetCSTableData()
        {
            var listOfCourse = cda.GetCSTableData();
            return listOfCourse;
        }

        public dynamic GetEEETableData()
        {
            var listOfCourse = cda.GetEEETableData();
            return listOfCourse;
        }

        public dynamic GetBBATableData()
        {
            var listOfCourse = cda.GetBBATableData();
            return listOfCourse;
        }

        public void AddCourse(string department, string subName, string section, string subID, string time, string seat)
        {
            cda.AddCourse(department, subName, section, subID, time, seat);
        }

        public bool IsExistID(string subName, string subID)
        {
            if(cda.IsExistID(subName, subID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsExistSection(string subName, string section)
        {
            if (cda.IsExistSection(subName, section))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
