using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLayer
{
    public class AdminDataAccess
    {
        public static InformationDataContext context = new InformationDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming\C#\UniversityManagementSystem\DataAccessLayer\UniData.mdf;Integrated Security=True");

        //using linq
        public List<object> GetAdminList()
        {
            var x = from a in context.AdminTables
                    select new { a.UserName };

            List<object> ob = new List<object>();
            ob.AddRange(x.ToList());
            return ob;
        }
        //

        //using sql
        public List<string> GetAdminLst()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming\C#\UniversityManagementSystem\DataAccessLayer\UniData.mdf;Integrated Security=True");
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From AdminTable", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            List<string> adminNames = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                adminNames.Add(row["UserName"].ToString());
            }
            conn.Close();

            return adminNames;
        }
        //

        //check for a valid admin
        public bool IsValidAdmin(string userName, string password)
        {
            var q = from p in context.AdminTables
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

        //check whether admin with same userName exist or not
        public bool IsExistAdmin(string userName)
        {
            var q = from p in context.AdminTables
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

        //add new admin
        public void AddAdmin(string userName, string password, string fullName, string birthDate, string age, string email, string contactNo, string cityName)
        {
            AdminTable at = new AdminTable();
            at.UserName = userName;
            at.Password = password;
            at.FullName = fullName;
            at.Birthdate = birthDate;
            at.Age = age;
            at.Email = email;
            at.ContactNo = contactNo;
            at.CityName = cityName;
            context.AdminTables.InsertOnSubmit(at);
            context.SubmitChanges();
        }

        public void UpdateAdmin(string selectedItem, string userName, string password, string fullName, string birthDate, string age, string email, string contactNo, string cityName)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\Desktop\UniversityMangementSystem\DataAccessLayer\UniData.mdf;Integrated Security=True");
            //conn.Open();
            //SqlCommand cmd = conn.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "update AdminTable set UserName = '" + userName + "', Password = '" + password + "', FullName = '" + fullName + "', Birthdate = '" + birthDate + "', Age = '" + age + "', Email = '" + email + "', ContactNo = '" + contactNo + "', CityName = '" + cityName + "' where UserName = '" + userName + "'";
            //cmd.ExecuteNonQuery();
            //conn.Close();

            var query = from p in context.AdminTables
                        where p.UserName == selectedItem
                        select p;

            foreach (AdminTable at in query)
            {
                at.UserName = userName;
                at.Password = password;
                at.FullName = fullName;
                at.Birthdate = birthDate;
                at.Age = age;
                at.Email = email;
                at.ContactNo = contactNo;
                at.CityName = cityName;
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

        //delete an admin
        public void DeleteAdmin(string userName)
        {
            var p = from a in context.AdminTables
                    where a.UserName == userName
                    select a;

            foreach (AdminTable z in p.ToList())
            {
                context.AdminTables.DeleteOnSubmit(z);
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

        //Admin Information
        public List<string> GetAdminInfo(string userName)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming\C#\UniversityManagementSystem\DataAccessLayer\UniData.mdf;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From AdminTable where UserName = '" + userName + "'";
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            List<string> adminInfo = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                adminInfo.Add(row["UserName"].ToString());
                adminInfo.Add(row["Password"].ToString());
                adminInfo.Add(row["FullName"].ToString());
                adminInfo.Add(row["Birthdate"].ToString());
                adminInfo.Add(row["Age"].ToString());
                adminInfo.Add(row["Email"].ToString());
                adminInfo.Add(row["ContactNo"].ToString());
                adminInfo.Add(row["CityName"].ToString());
            }
            conn.Close();

            return adminInfo;
        }
    }
}
