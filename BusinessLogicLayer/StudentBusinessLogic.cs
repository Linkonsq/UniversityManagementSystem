using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class StudentBusinessLogic
    {
        StudentDataAccsess sda = new StudentDataAccsess();

        //
        public bool IsValidCSStudent(string studentID, string password)
        {
            if (sda.IsValidCSStudent(studentID, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidEEEStudent(string studentID, string password)
        {
            if (sda.IsValidEEEStudent(studentID, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidBBAStudent(string studentID, string password)
        {
            if (sda.IsValidBBAStudent(studentID, password))
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
        public List<string> GetStudentList(string department)
        {
            List<string> studentList = sda.GetStudentList(department);

            return studentList;
        }
        //

        //
        public List<string> GetStudentInfo(string studentID, string department)
        {
            List<string> studentInfo = sda.GetStudentInfo(studentID, department);

            return studentInfo;
        }

        //
        public Image GetCSStudentImage(string studentID)
        {
            Image img = sda.GetCSStudentImage(studentID);
            return img;
        }

        public Image GetEEEStudentImage(string studentID)
        {
            Image img = sda.GetEEEStudentImage(studentID);
            return img;
        }

        public Image GetBBAStudentImage(string studentID)
        {
            Image img = sda.GetBBAStudentImage(studentID);
            return img;
        }
        //

        //
        public bool IsExistCSStudent(string studentID)
        {
            if (sda.IsExistCSStudent(studentID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsExistEEEStudent(string studentID)
        {
            if (sda.IsExistEEEStudent(studentID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsExistBBAStudent(string studentID)
        {
            if (sda.IsExistBBAStudent(studentID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //
        public void AddStudent(string studentID, string password, string fullName, string cgpa, string program, string fatherName, string motherName, string presentAddress, string permanentAddress, string phone, string email, string dob, string sex, string nationality, string religion, string maritalStatus, string bloodGroup, string admissionDate, string graduationDate, Image pic, string department)
        {
            sda.AddStudent(studentID, password, fullName, cgpa, program, fatherName, motherName, presentAddress, permanentAddress, phone, email, dob, sex, nationality, religion, maritalStatus, bloodGroup, admissionDate, graduationDate, pic, department);
        }

        //

        public void UpdateStudent(string selectedItem, string studentID, string password, string fullName, string cgpa, string program, string fatherName, string motherName, string presentAddress, string permanentAddress, string phone, string email, string dob, string sex, string nationality, string religion, string maritalStatus, string bloodGroup, string admissionDate, string graduationDate, Image pic, string department)
        {
            sda.UpdateStudent(selectedItem, studentID, password, fullName, cgpa, program, fatherName, motherName, presentAddress, permanentAddress, phone, email, dob, sex, nationality, religion, maritalStatus, bloodGroup, admissionDate, graduationDate, pic, department);
        }

        //
        public void DeleteStudent(string studentID, string department)
        {
            sda.DeleteStudent(studentID, department);
        }

        //
        public void ChangePassword(string studentID, string password, string department)
        {
            sda.ChangePassword(studentID, password, department);
        }
    }
}