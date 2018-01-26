using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataAccessLayer
{
    public class CourseDataAccess
    {
        public static InformationDataContext context = new InformationDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AIUB\Semester\9thSem\C#\Final\UniversityMangementSystem\DataAccessLayer\UniData.mdf;Integrated Security=True");

        //get table data
        public dynamic GetCSTableData()
        {
            var listOfCourse = from all in context.CSCourseTables
                              select all;

            return listOfCourse;
        }

        public dynamic GetEEETableData()
        {
            var listOfCourse = from all in context.EEECourseTables
                               select all;

            return listOfCourse;
        }

        public dynamic GetBBATableData()
        {
            var listOfCourse = from all in context.BBACourseTables
                               select all;

            return listOfCourse;
        }

        //offer new course
        public void AddCourse(string department, string subID, string subName, string section, string time, string seat)
        {
            if(department == "CS")
            {
                CSCourseTable ct = new CSCourseTable();
                ct.SubjectID = subID;
                ct.SubjectName = subName;
                ct.Section = section;
                ct.Time = time;
                ct.Seat = seat;
                ct.AvailableSeat = seat;
                context.CSCourseTables.InsertOnSubmit(ct);
                context.SubmitChanges();
            }
            else if(department == "EEE")
            {
                EEECourseTable et = new EEECourseTable();
                et.SubjectID = subID;
                et.SubjectName = subName;
                et.Section = section;
                et.Time = time;
                et.Seat = seat;
                et.AvailableSeat = seat;
                context.EEECourseTables.InsertOnSubmit(et);
                context.SubmitChanges();
            }
            else if(department == "BBA")
            {
                BBACourseTable bt = new BBACourseTable();
                bt.SubjectID = subID;
                bt.SubjectName = subName;
                bt.Section = section;
                bt.Time = time;
                bt.Seat = seat;
                bt.AvailableSeat = seat;
                context.BBACourseTables.InsertOnSubmit(bt);
                context.SubmitChanges();
            }
        }

        //check whether section with same id exist or not
        public bool IsExistID(string subName, string subID)
        {
            var q = from p in context.CSCourseTables
                    where p.SubjectName == subName
                    && p.SubjectID == subID
                    select p;
            if (q.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //check whether section with same sec exist or not
        public bool IsExistSection(string subName, string section)
        {
            var q = from p in context.CSCourseTables
                    where p.SubjectName == subName
                    && p.Section == section
                    select p;
            if (q.Any())
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
