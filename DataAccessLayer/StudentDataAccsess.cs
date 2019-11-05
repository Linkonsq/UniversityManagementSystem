using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;

namespace DataAccessLayer
{
    public class StudentDataAccsess
    {
        public static InformationDataContext context = new InformationDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming\C#\UniversityManagementSystem\DataAccessLayer\UniData.mdf;Integrated Security=True");

        //check for a valid faculty
        public bool IsValidCSStudent(string studentID, string password)
        {
            var q = from p in context.CSStudentsTables
                    where p.StudentID == studentID
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

        public bool IsValidEEEStudent(string studentID, string password)
        {
            var q = from p in context.EEEStudentsTables
                    where p.StudentID == studentID
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

        public bool IsValidBBAStudent(string studentID, string password)
        {
            var q = from p in context.BBAStudentsTables
                    where p.StudentID == studentID
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
        public List<string> GetStudentList(string department)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming\C#\UniversityManagementSystem\DataAccessLayer\UniData.mdf;Integrated Security=True");
            List<string> studentList = new List<string>();

            if (department == "CS")
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * From CSStudentsTable", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    studentList.Add(row["StudentID"].ToString());
                }
                conn.Close();
            }
            else if (department == "EEE")
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * From EEEStudentsTable", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    studentList.Add(row["StudentID"].ToString());
                }
                conn.Close();
            }
            else if (department == "BBA")
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * From BBAStudentsTable", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    studentList.Add(row["StudentID"].ToString());
                }
                conn.Close();
            }

            return studentList;
        }
        //

        //Faculty Information
        public List<string> GetStudentInfo(string studentID, string department)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming\C#\UniversityManagementSystem\DataAccessLayer\UniData.mdf;Integrated Security=True");
            List<string> studentInfo = new List<string>();

            if (department == "CS")
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * From CSStudentsTable where StudentID = '" + studentID + "'";
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    studentInfo.Add(row["StudentID"].ToString());
                    studentInfo.Add(row["Password"].ToString());
                    studentInfo.Add(row["FullName"].ToString());
                    studentInfo.Add(row["CGPA"].ToString());
                    studentInfo.Add(row["Program"].ToString());
                    studentInfo.Add(row["FatherName"].ToString());
                    studentInfo.Add(row["MotherName"].ToString());
                    studentInfo.Add(row["PresentAddress"].ToString());
                    studentInfo.Add(row["PermanentAddress"].ToString());
                    studentInfo.Add(row["Phone"].ToString());
                    studentInfo.Add(row["Email"].ToString());
                    studentInfo.Add(row["DOB"].ToString());
                    studentInfo.Add(row["Sex"].ToString());
                    studentInfo.Add(row["Nationality"].ToString());
                    studentInfo.Add(row["Religion"].ToString());
                    studentInfo.Add(row["MaritalStatus"].ToString());
                    studentInfo.Add(row["BloodGroup"].ToString());
                    studentInfo.Add(row["AdmissionDate"].ToString());
                    studentInfo.Add(row["GraduationDate"].ToString());
                }
                conn.Close();
            }
            else if (department == "EEE")
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * From EEEStudentsTable where StudentID = '" + studentID + "'";
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    studentInfo.Add(row["StudentID"].ToString());
                    studentInfo.Add(row["Password"].ToString());
                    studentInfo.Add(row["FullName"].ToString());
                    studentInfo.Add(row["CGPA"].ToString());
                    studentInfo.Add(row["Program"].ToString());
                    studentInfo.Add(row["FatherName"].ToString());
                    studentInfo.Add(row["MotherName"].ToString());
                    studentInfo.Add(row["PresentAddress"].ToString());
                    studentInfo.Add(row["PermanentAddress"].ToString());
                    studentInfo.Add(row["Phone"].ToString());
                    studentInfo.Add(row["Email"].ToString());
                    studentInfo.Add(row["DOB"].ToString());
                    studentInfo.Add(row["Sex"].ToString());
                    studentInfo.Add(row["Nationality"].ToString());
                    studentInfo.Add(row["Religion"].ToString());
                    studentInfo.Add(row["MaritalStatus"].ToString());
                    studentInfo.Add(row["BloodGroup"].ToString());
                    studentInfo.Add(row["AdmissionDate"].ToString());
                    studentInfo.Add(row["GraduationDate"].ToString());
                }
                conn.Close();
            }
            else if (department == "BBA")
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * From BBAStudentsTable where StudentID = '" + studentID + "'";
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    studentInfo.Add(row["StudentID"].ToString());
                    studentInfo.Add(row["Password"].ToString());
                    studentInfo.Add(row["FullName"].ToString());
                    studentInfo.Add(row["CGPA"].ToString());
                    studentInfo.Add(row["Program"].ToString());
                    studentInfo.Add(row["FatherName"].ToString());
                    studentInfo.Add(row["MotherName"].ToString());
                    studentInfo.Add(row["PresentAddress"].ToString());
                    studentInfo.Add(row["PermanentAddress"].ToString());
                    studentInfo.Add(row["Phone"].ToString());
                    studentInfo.Add(row["Email"].ToString());
                    studentInfo.Add(row["DOB"].ToString());
                    studentInfo.Add(row["Sex"].ToString());
                    studentInfo.Add(row["Nationality"].ToString());
                    studentInfo.Add(row["Religion"].ToString());
                    studentInfo.Add(row["MaritalStatus"].ToString());
                    studentInfo.Add(row["BloodGroup"].ToString());
                    studentInfo.Add(row["AdmissionDate"].ToString());
                    studentInfo.Add(row["GraduationDate"].ToString());
                }
                conn.Close();
            }

            return studentInfo;
        }

        //Get image
        public Image GetCSStudentImage(string studentID)
        {
            Image photo;

            var img = (from image in context.CSStudentsTables
                       where image.StudentID == studentID
                       select image).Single();

            photo = ByteArrayToImage(img.Image.ToArray());

            return photo;
        }

        public Image GetEEEStudentImage(string studentID)
        {
            Image photo;

            var img = (from image in context.EEEStudentsTables
                       where image.StudentID == studentID
                       select image).Single();

            photo = ByteArrayToImage(img.Image.ToArray());

            return photo;
        }

        public Image GetBBAStudentImage(string studentID)
        {
            Image photo;

            var img = (from image in context.BBAStudentsTables
                       where image.StudentID == studentID
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

        //check whether student with same userName exist or not
        public bool IsExistCSStudent(string studentID)
        {
            var q = from p in context.CSStudentsTables
                    where p.StudentID == studentID
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

        public bool IsExistEEEStudent(string studentID)
        {
            var q = from p in context.EEEStudentsTables
                    where p.StudentID == studentID
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

        public bool IsExistBBAStudent(string studentID)
        {
            var q = from p in context.BBAStudentsTables
                    where p.StudentID == studentID
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
        public void AddStudent(string studentID, string password, string fullName, string cgpa, string program, string fatherName, string motherName, string presentAddress, string permanentAddress, string phone, string email, string dob, string sex, string nationality, string religion, string maritalStatus, string bloodGroup, string admissionDate, string graduationDate, Image pic, string department)
        {
            if (department == "CS")
            {
                CSStudentsTable csst = new CSStudentsTable();
                csst.StudentID = studentID;
                csst.Password = password;
                csst.FullName = fullName;
                csst.CGPA = cgpa;
                csst.Program = program;
                csst.FatherName = fatherName;
                csst.MotherName = motherName;
                csst.PresentAddress = presentAddress;
                csst.PermanentAddress = permanentAddress;
                csst.Phone = phone;
                csst.Email = email;
                csst.DOB = dob;
                csst.Sex = sex;
                csst.Nationality = nationality;
                csst.Religion = religion;
                csst.MaritalStatus = maritalStatus;
                csst.BloodGroup = bloodGroup;
                csst.AdmissionDate = admissionDate;
                csst.GraduationDate = graduationDate;

                //img
                byte[] fileByte = ImageToByteArray(pic);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);

                csst.Image = fileBinary;

                context.CSStudentsTables.InsertOnSubmit(csst);
                context.SubmitChanges();
            }
            else if (department == "EEE")
            {
                EEEStudentsTable eeest = new EEEStudentsTable();
                eeest.StudentID = studentID;
                eeest.Password = password;
                eeest.FullName = fullName;
                eeest.CGPA = cgpa;
                eeest.Program = program;
                eeest.FatherName = fatherName;
                eeest.MotherName = motherName;
                eeest.PresentAddress = presentAddress;
                eeest.PermanentAddress = permanentAddress;
                eeest.Phone = phone;
                eeest.Email = email;
                eeest.DOB = dob;
                eeest.Sex = sex;
                eeest.Nationality = nationality;
                eeest.Religion = religion;
                eeest.MaritalStatus = maritalStatus;
                eeest.BloodGroup = bloodGroup;
                eeest.AdmissionDate = admissionDate;
                eeest.GraduationDate = graduationDate;

                //img
                byte[] fileByte = ImageToByteArray(pic);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);

                eeest.Image = fileBinary;

                context.EEEStudentsTables.InsertOnSubmit(eeest);
                context.SubmitChanges();
            }
            else if (department == "BBA")
            {
                BBAStudentsTable bbast = new BBAStudentsTable();
                bbast.StudentID = studentID;
                bbast.Password = password;
                bbast.FullName = fullName;
                bbast.CGPA = cgpa;
                bbast.Program = program;
                bbast.FatherName = fatherName;
                bbast.MotherName = motherName;
                bbast.PresentAddress = presentAddress;
                bbast.PermanentAddress = permanentAddress;
                bbast.Phone = phone;
                bbast.Email = email;
                bbast.DOB = dob;
                bbast.Sex = sex;
                bbast.Nationality = nationality;
                bbast.Religion = religion;
                bbast.MaritalStatus = maritalStatus;
                bbast.BloodGroup = bloodGroup;
                bbast.AdmissionDate = admissionDate;
                bbast.GraduationDate = graduationDate;

                //img
                byte[] fileByte = ImageToByteArray(pic);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);

                bbast.Image = fileBinary;

                context.BBAStudentsTables.InsertOnSubmit(bbast);
                context.SubmitChanges();
            }
        }

        public void UpdateStudent(string selectedIem, string studentID, string password, string fullName, string cgpa, string program, string fatherName, string motherName, string presentAddress, string permanentAddress, string phone, string email, string dob, string sex, string nationality, string religion, string maritalStatus, string bloodGroup, string admissionDate, string graduationDate, Image pic, string department)
        {
            if (department == "CS")
            {
                var query = from p in context.CSStudentsTables
                            where p.StudentID == studentID
                            select p;

                //img
                byte[] fileByte = ImageToByteArray(pic);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);

                foreach (CSStudentsTable csst in query)
                {
                    csst.StudentID = studentID;
                    csst.Password = password;
                    csst.FullName = fullName;
                    csst.CGPA = cgpa;
                    csst.Program = program;
                    csst.FatherName = fatherName;
                    csst.MotherName = motherName;
                    csst.PresentAddress = presentAddress;
                    csst.PermanentAddress = permanentAddress;
                    csst.Phone = phone;
                    csst.Email = email;
                    csst.DOB = dob;
                    csst.Sex = sex;
                    csst.Nationality = nationality;
                    csst.Religion = religion;
                    csst.MaritalStatus = maritalStatus;
                    csst.BloodGroup = bloodGroup;
                    csst.AdmissionDate = admissionDate;
                    csst.GraduationDate = graduationDate;
                    csst.Image = fileBinary;
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
                var query = from p in context.EEEStudentsTables
                            where p.StudentID == studentID
                            select p;

                //img
                byte[] fileByte = ImageToByteArray(pic);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);

                foreach (EEEStudentsTable eeest in query)
                {
                    eeest.StudentID = studentID;
                    eeest.Password = password;
                    eeest.FullName = fullName;
                    eeest.CGPA = cgpa;
                    eeest.Program = program;
                    eeest.FatherName = fatherName;
                    eeest.MotherName = motherName;
                    eeest.PresentAddress = presentAddress;
                    eeest.PermanentAddress = permanentAddress;
                    eeest.Phone = phone;
                    eeest.Email = email;
                    eeest.DOB = dob;
                    eeest.Sex = sex;
                    eeest.Nationality = nationality;
                    eeest.Religion = religion;
                    eeest.MaritalStatus = maritalStatus;
                    eeest.BloodGroup = bloodGroup;
                    eeest.AdmissionDate = admissionDate;
                    eeest.GraduationDate = graduationDate;
                    eeest.Image = fileBinary;
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
                var query = from p in context.BBAStudentsTables
                            where p.StudentID == studentID
                            select p;

                //img
                byte[] fileByte = ImageToByteArray(pic);
                System.Data.Linq.Binary fileBinary = new System.Data.Linq.Binary(fileByte);

                foreach (BBAStudentsTable bbast in query)
                {
                    bbast.StudentID = studentID;
                    bbast.Password = password;
                    bbast.FullName = fullName;
                    bbast.CGPA = cgpa;
                    bbast.Program = program;
                    bbast.FatherName = fatherName;
                    bbast.MotherName = motherName;
                    bbast.PresentAddress = presentAddress;
                    bbast.PermanentAddress = permanentAddress;
                    bbast.Phone = phone;
                    bbast.Email = email;
                    bbast.DOB = dob;
                    bbast.Sex = sex;
                    bbast.Nationality = nationality;
                    bbast.Religion = religion;
                    bbast.MaritalStatus = maritalStatus;
                    bbast.BloodGroup = bloodGroup;
                    bbast.AdmissionDate = admissionDate;
                    bbast.GraduationDate = graduationDate;
                    bbast.Image = fileBinary;
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

        public void DeleteStudent(string studentID, string departmen)
        {
            if (departmen == "CS")
            {
                var p = from a in context.CSStudentsTables
                        where a.StudentID == studentID
                        select a;

                foreach (CSStudentsTable z in p.ToList())
                {
                    context.CSStudentsTables.DeleteOnSubmit(z);
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
                var p = from a in context.EEEStudentsTables
                        where a.StudentID == studentID
                        select a;

                foreach (EEEStudentsTable z in p.ToList())
                {
                    context.EEEStudentsTables.DeleteOnSubmit(z);
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
                var p = from a in context.BBAStudentsTables
                        where a.StudentID == studentID
                        select a;

                foreach (BBAStudentsTable z in p.ToList())
                {
                    context.BBAStudentsTables.DeleteOnSubmit(z);
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

        public void ChangePassword(string studentID, string password, string department)
        {
            if (department == "CS")
            {
                var query = from p in context.CSStudentsTables
                            where p.StudentID == studentID
                            select p;

                foreach (CSStudentsTable cst in query)
                {
                    cst.Password = password;
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
                var query = from p in context.EEEStudentsTables
                            where p.StudentID == studentID
                            select p;

                foreach (EEEStudentsTable est in query)
                {
                    est.Password = password;
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
                var query = from p in context.BBAStudentsTables
                            where p.StudentID == studentID
                            select p;

                foreach (BBAStudentsTable bst in query)
                {
                    bst.Password = password;
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
    }
}
