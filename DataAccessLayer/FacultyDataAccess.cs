using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;

namespace DataAccessLayer
{
    public class FacultyDataAccess
    {
        public static InformationDataContext context = new InformationDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming\C#\UniversityManagementSystem\DataAccessLayer\UniData.mdf;Integrated Security=True");

        //check for a valid faculty
        public bool IsValidCSFaculty(string userName, string password)
        {
            var q = from p in context.CSFacultyTables
                    where p.UserName == userName
                    && p.Password == password
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

        public bool IsValidEEEFaculty(string userName, string password)
        {
            var q = from p in context.EEEFacultyTables
                    where p.UserName == userName
                    && p.Password == password
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

        public bool IsValidBBAFaculty(string userName, string password)
        {
            var q = from p in context.BBAFacultyTables
                    where p.UserName == userName
                    && p.Password == password
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

        //using sql
        public List<string> GetFacultyList(string department)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming\C#\UniversityManagementSystem\DataAccessLayer\UniData.mdf;Integrated Security=True");
            List<string> facultyList = new List<string>();

            if (department == "CS")
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * From CSFacultyTable", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                //List<string> csFacultyList = new List<string>();

                foreach (DataRow row in dt.Rows)
                {
                    facultyList.Add(row["UserName"].ToString());
                }
                conn.Close();

                //return csFacultyList;
            }
            else if (department == "EEE")
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * From EEEFacultyTable", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    facultyList.Add(row["UserName"].ToString());
                }
                conn.Close();
            }
            else if (department == "BBA")
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * From BBAFacultyTable", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    facultyList.Add(row["UserName"].ToString());
                }
                conn.Close();
            }

            return facultyList;
        }
        //

        //Faculty Information
        public List<string> GetFacultyInfo(string userName, string department)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming\C#\UniversityManagementSystem\DataAccessLayer\UniData.mdf;Integrated Security=True");
            List<string> facultyInfo = new List<string>();

            if (department == "CS")
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * From CSFacultyTable where UserName = '" + userName + "'";
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    facultyInfo.Add(row["UserName"].ToString());
                    facultyInfo.Add(row["Password"].ToString());
                    facultyInfo.Add(row["FullName"].ToString());
                    facultyInfo.Add(row["RoomNo"].ToString());
                    facultyInfo.Add(row["CntactNo"].ToString());
                    facultyInfo.Add(row["Email"].ToString());
                    facultyInfo.Add(row["DOB"].ToString());
                    facultyInfo.Add(row["Age"].ToString());
                    facultyInfo.Add(row["Sex"].ToString());
                    facultyInfo.Add(row["BloodGroup"].ToString());
                    facultyInfo.Add(row["College"].ToString());
                    facultyInfo.Add(row["University"].ToString());
                    facultyInfo.Add(row["Address"].ToString());
                }
                conn.Close();
            }
            else if (department == "EEE")
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * From EEEFacultyTable where UserName = '" + userName + "'";
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    facultyInfo.Add(row["UserName"].ToString());
                    facultyInfo.Add(row["Password"].ToString());
                    facultyInfo.Add(row["FullName"].ToString());
                    facultyInfo.Add(row["RoomNo"].ToString());
                    facultyInfo.Add(row["CntactNo"].ToString());
                    facultyInfo.Add(row["Email"].ToString());
                    facultyInfo.Add(row["DOB"].ToString());
                    facultyInfo.Add(row["Age"].ToString());
                    facultyInfo.Add(row["Sex"].ToString());
                    facultyInfo.Add(row["BloodGroup"].ToString());
                    facultyInfo.Add(row["College"].ToString());
                    facultyInfo.Add(row["University"].ToString());
                    facultyInfo.Add(row["Address"].ToString());
                }
                conn.Close();
            }
            else if (department == "BBA")
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * From BBAFacultyTable where UserName = '" + userName + "'";
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    facultyInfo.Add(row["UserName"].ToString());
                    facultyInfo.Add(row["Password"].ToString());
                    facultyInfo.Add(row["FullName"].ToString());
                    facultyInfo.Add(row["RoomNo"].ToString());
                    facultyInfo.Add(row["CntactNo"].ToString());
                    facultyInfo.Add(row["Email"].ToString());
                    facultyInfo.Add(row["DOB"].ToString());
                    facultyInfo.Add(row["Age"].ToString());
                    facultyInfo.Add(row["Sex"].ToString());
                    facultyInfo.Add(row["BloodGroup"].ToString());
                    facultyInfo.Add(row["College"].ToString());
                    facultyInfo.Add(row["University"].ToString());
                    facultyInfo.Add(row["Address"].ToString());
                }
                conn.Close();
            }

            return facultyInfo;
        }

        //Get image
        public Image GetCSFacultyImage(string userName)
        {
            Image photo;

            var img = (from image in context.CSFacultyTables
                       where image.UserName == userName
                       select image).Single();

            photo = ByteArrayToImage(img.Image.ToArray());

            return photo;
        }

        public Image GetEEEFacultyImage(string userName)
        {
            Image photo;

            var img = (from image in context.EEEFacultyTables
                       where image.UserName == userName
                       select image).Single();

            photo = ByteArrayToImage(img.Image.ToArray());

            return photo;
        }

        public Image GetBBAFacultyImage(string userName)
        {
            Image photo;

            var img = (from image in context.BBAFacultyTables
                       where image.UserName == userName
                       select image).Single();

            photo = ByteArrayToImage(img.Image.ToArray());

            return photo;
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;

            //using (MemoryStream ms = new MemoryStream())
            //{         
            //    Image returnImage = Image.FromStream(ms);
            //    return returnImage;
            //}
        }

        //check whether faculty with same userName exist or not
        public bool IsExistCSFaculty(string userName)
        {
            var q = from p in context.CSFacultyTables
                    where p.UserName == userName
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

        public bool IsExistEEEFaculty(string userName)
        {
            var q = from p in context.EEEFacultyTables
                    where p.UserName == userName
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

        public bool IsExistBBAFaculty(string userName)
        {
            var q = from p in context.BBAFacultyTables
                    where p.UserName == userName
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

        //add new faculty
        public void AddFaculty(string userName, string password, string fullName, string roomNo, string contactNo, string email, string dob, string age, string sex, string bloodGroup, string college, string university, string address, Image pic, string department)
        {
            if (department == "CS")
            {
                CSFacultyTable csft = new CSFacultyTable();
                csft.UserName = userName;
                csft.Password = password;
                csft.FullName = fullName;
                csft.RoomNo = roomNo;
                csft.CntactNo = contactNo;
                csft.Email = email;
                csft.DOB = dob;
                csft.Age = age;
                csft.Sex = sex;
                csft.BloodGroup = bloodGroup;
                csft.College = college;
                csft.University = university;
                csft.Address = address;

                //img
                byte[] fileByte = ImageToByteArray(pic);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);

                csft.Image = fileBinary;

                context.CSFacultyTables.InsertOnSubmit(csft);
                context.SubmitChanges();
            }
            else if (department == "EEE")
            {
                EEEFacultyTable eeeft = new EEEFacultyTable();
                eeeft.UserName = userName;
                eeeft.Password = password;
                eeeft.FullName = fullName;
                eeeft.RoomNo = roomNo;
                eeeft.CntactNo = contactNo;
                eeeft.Email = email;
                eeeft.DOB = dob;
                eeeft.Age = age;
                eeeft.Sex = sex;
                eeeft.BloodGroup = bloodGroup;
                eeeft.College = college;
                eeeft.University = university;
                eeeft.Address = address;

                //img
                byte[] fileByte = ImageToByteArray(pic);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);

                eeeft.Image = fileBinary;

                context.EEEFacultyTables.InsertOnSubmit(eeeft);
                context.SubmitChanges();
            }
            else if (department == "BBA")
            {
                BBAFacultyTable bbaft = new BBAFacultyTable();
                bbaft.UserName = userName;
                bbaft.Password = password;
                bbaft.FullName = fullName;
                bbaft.RoomNo = roomNo;
                bbaft.CntactNo = contactNo;
                bbaft.Email = email;
                bbaft.DOB = dob;
                bbaft.Age = age;
                bbaft.Sex = sex;
                bbaft.BloodGroup = bloodGroup;
                bbaft.College = college;
                bbaft.University = university;
                bbaft.Address = address;

                //img
                byte[] fileByte = ImageToByteArray(pic);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);

                bbaft.Image = fileBinary;

                context.BBAFacultyTables.InsertOnSubmit(bbaft);
                context.SubmitChanges();
            }
        }

        public void UpdateFaculty(string selectedItem, string userName, string password, string fullName, string roomNo, string contactNo, string email, string dob, string age, string sex, string bloodGroup, string college, string university, string address, Image pic, string department)
        {
            if (department == "CS")
            {
                var query = from p in context.CSFacultyTables
                            where p.UserName == selectedItem
                            select p;

                //img
                byte[] fileByte = ImageToByteArray(pic);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);

                foreach (CSFacultyTable csft in query)
                {
                    csft.UserName = userName;
                    csft.Password = password;
                    csft.FullName = fullName;
                    csft.RoomNo = roomNo;
                    csft.CntactNo = contactNo;
                    csft.Email = email;
                    csft.DOB = dob;
                    csft.Age = age;
                    csft.Sex = sex;
                    csft.BloodGroup = bloodGroup;
                    csft.College = college;
                    csft.University = university;
                    csft.Address = address;
                    csft.Image = fileBinary;
                }

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else if (department == "EEE")
            {
                var query = from p in context.EEEFacultyTables
                            where p.UserName == selectedItem
                            select p;

                //img
                byte[] fileByte = ImageToByteArray(pic);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);

                foreach (EEEFacultyTable eeeft in query)
                {
                    eeeft.UserName = userName;
                    eeeft.Password = password;
                    eeeft.FullName = fullName;
                    eeeft.RoomNo = roomNo;
                    eeeft.CntactNo = contactNo;
                    eeeft.Email = email;
                    eeeft.DOB = dob;
                    eeeft.Age = age;
                    eeeft.Sex = sex;
                    eeeft.BloodGroup = bloodGroup;
                    eeeft.College = college;
                    eeeft.University = university;
                    eeeft.Address = address;
                    eeeft.Image = fileBinary;
                }

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else if (department == "BBA")
            {
                var query = from p in context.BBAFacultyTables
                            where p.UserName == selectedItem
                            select p;

                //img
                byte[] fileByte = ImageToByteArray(pic);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);

                foreach (BBAFacultyTable bbaft in query)
                {
                    bbaft.UserName = userName;
                    bbaft.Password = password;
                    bbaft.FullName = fullName;
                    bbaft.RoomNo = roomNo;
                    bbaft.CntactNo = contactNo;
                    bbaft.Email = email;
                    bbaft.DOB = dob;
                    bbaft.Age = age;
                    bbaft.Sex = sex;
                    bbaft.BloodGroup = bloodGroup;
                    bbaft.College = college;
                    bbaft.University = university;
                    bbaft.Address = address;
                    bbaft.Image = fileBinary;
                }

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        //Image
        private byte[] ImageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        //delete a faculty
        public void DeleteFaculty(string userName, string departmen)
        {
            if (departmen == "CS")
            {
                var p = from a in context.CSFacultyTables
                        where a.UserName == userName
                        select a;

                foreach (CSFacultyTable z in p.ToList())
                {
                    context.CSFacultyTables.DeleteOnSubmit(z);
                }

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else if (departmen == "EEE")
            {
                var p = from a in context.EEEFacultyTables
                        where a.UserName == userName
                        select a;

                foreach (EEEFacultyTable z in p.ToList())
                {
                    context.EEEFacultyTables.DeleteOnSubmit(z);
                }

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else if (departmen == "BBA")
            {
                var p = from a in context.BBAFacultyTables
                        where a.UserName == userName
                        select a;

                foreach (BBAFacultyTable z in p.ToList())
                {
                    context.BBAFacultyTables.DeleteOnSubmit(z);
                }

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void ChangePassword(string userName, string password, string department)
        {
            if (department == "CS")
            {
                var query = from p in context.CSFacultyTables
                            where p.UserName == userName
                            select p;

                foreach (CSFacultyTable csft in query)
                {
                    csft.Password = password;
                }

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else if (department == "EEE")
            {
                var query = from p in context.EEEFacultyTables
                            where p.UserName == userName
                            select p;

                foreach (EEEFacultyTable eft in query)
                {
                    eft.Password = password;
                }

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else if (department == "BBA")
            {
                var query = from p in context.BBAFacultyTables
                            where p.UserName == userName
                            select p;

                foreach (BBAFacultyTable bft in query)
                {
                    bft.Password = password;
                }

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        //REG
        //get course table data
        public dynamic GetCSCourseTableData()
        {
            var listOfCourse = from all in context.CSCourseTables
                               select all;

            return listOfCourse;
        }

        public dynamic GetEEECourseTableData()
        {
            var listOfCourse = from all in context.EEECourseTables
                               select all;

            return listOfCourse;
        }

        public dynamic GetBBACourseTableData()
        {
            var listOfCourse = from all in context.BBACourseTables
                               select all;

            return listOfCourse;
        }
    }
}