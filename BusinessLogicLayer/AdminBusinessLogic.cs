using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class AdminBusinessLogic
    {
        
        AdminDataAccess dac = new AdminDataAccess();
        
        //
        public List<object> GetAdminList()
        {
            List<object> admin = dac.GetAdminList();

            return admin.ToList();
        }
        //
       
        //
        public List<string> GetAdminLst()
        {
            List<string> adminList = dac.GetAdminLst();

            return adminList;
        }
        //

        //
        public List<string> GetAdminInfo(string userName)
        {
            List<string> adminInfo = dac.GetAdminInfo(userName);

            return adminInfo;
        }
        //

        //
        public bool IsValidAdmin(string userName, string password)
        {
            if(dac.IsValidAdmin(userName, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //

        public bool IsExistAdmin(string userName)
        {
            if(dac.IsExistAdmin(userName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //
        public void AddAdmin(string userName, string password, string fullName, string birthDate, string age, string email, string contactNo, string cityName)
        {
            dac.AddAdmin(userName, password, fullName, birthDate, age, email, contactNo, cityName);
        }

        public void DeleteAdmin(string userName)
        {
            dac.DeleteAdmin(userName);
        }

        public void UpdateAdmin(string selectedItem, string userName, string password, string fullName, string birthDate, string age, string email, string contactNo, string cityName)
        {
            dac.UpdateAdmin(selectedItem, userName, password, fullName, birthDate, age, email, contactNo, cityName);
        }
        //

        //
        
        //
    }
}