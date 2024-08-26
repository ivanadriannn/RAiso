using ProjectAkhir_RAiso.Model;
using ProjectAkhir_RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAkhir_RAiso.Handler
{
    public class UserHandler
    {
        public static void UpdateUser(int UserID, string name, string DOB, string gender, string address, string phone, string password)
        {
            UserRepository.UpdateUser(UserID, name, DOB, gender, address, phone, password);
        }
        public static User findUserByName(string name)
        {
            return UserRepository.findUserByName(name);
        }

        public static void insertCustomer(string name, string DOB, string gender, string address, string phone, string password)
        {
            UserRepository.insertNewCustomer(name, DOB, gender, address, phone, password);
        }

        public static User findRegisteredUser(string name, string password)
        {
            return UserRepository.findRegisteredUser(name, password);
        }

        public static string GetUserName(int UserID)
        {
            return UserRepository.GetUserName(UserID);
        }
    }
}