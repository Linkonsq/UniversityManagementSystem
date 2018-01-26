using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Drawing;

namespace BusinessLogicLayer
{
    public class FacultyBusinessLogic
    {
        FacultyDataAccess fda = new FacultyDataAccess();

        //
        public bool IsValidCSFaculty(string userName, string password)
        {
            if (fda.IsValidCSFaculty(userName, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidEEEFaculty(string userName, string password)
        {
            if (fda.IsValidEEEFaculty(userName, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidBBAFaculty(string userName, string password)
        {
            if (fda.IsValidBBAFaculty(userName, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //

        //
        public List<string> GetFacultyList(string department)
        {
            List<string> facultyList = fda.GetFacultyList(department);

            return facultyList;
        }
        //

        //
        public List<string> GetFacultyInfo(string userName, string department)
        {
            List<string> facultyInfo = fda.GetFacultyInfo(userName, department);

            return facultyInfo;
        }
        
        //
        public Image GetCSFacultyImage(string userName)
        {
            Image img = fda.GetCSFacultyImage(userName);
            return img;
        }

        public Image GetEEEFacultyImage(string userName)
        {
            Image img = fda.GetEEEFacultyImage(userName);
            return img;
        }

        public Image GetBBAFacultyImage(string userName)
        {
            Image img = fda.GetBBAFacultyImage(userName);
            return img;
        }
        //
        public bool IsExistCSFaculty(string userName)
        {
            if (fda.IsExistCSFaculty(userName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsExistEEEFaculty(string userName)
        {
            if (fda.IsExistEEEFaculty(userName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsExistBBAFaculty(string userName)
        {
            if (fda.IsExistBBAFaculty(userName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //
        public void AddFaculty(string userName, string password, string fullName, string roomNo, string contactNo, string email, string dob, string age, string sex, string bloodGroup, string college, string university, string address, Image img, string department)
        {
            fda.AddFaculty(userName, password, fullName, roomNo, contactNo, email, dob, age, sex, bloodGroup, college, university, address, img, department);
        }

        //

        public void UpdateFaculty(string selectedItem, string userName, string password, string fullName, string roomNo, string contactNo, string email, string dob, string age, string sex, string bloodGroup, string college, string university, string address, Image img, string department)
        {
            fda.UpdateFaculty(selectedItem, userName, password, fullName, roomNo, contactNo, email, dob, age, sex, bloodGroup, college, university, address, img, department);
        }

        //
        public void DeleteFaculty(string userName, string department)
        {
            fda.DeleteFaculty(userName, department);
        }

        public void ChangePassword(string userName, string password, string department)
        {
            fda.ChangePassword(userName, password, department);
        }

        //REG
        public dynamic GetCSCourseTableData()
        {
            var listOfCourse = fda.GetCSCourseTableData();
            return listOfCourse;
        }

        public dynamic GetEEECourseTableData()
        {
            var listOfCourse = fda.GetEEECourseTableData();
            return listOfCourse;
        }

        public dynamic GetBBACourseTableData()
        {
            var listOfCourse = fda.GetBBACourseTableData();
            return listOfCourse;
        }
    }
}
