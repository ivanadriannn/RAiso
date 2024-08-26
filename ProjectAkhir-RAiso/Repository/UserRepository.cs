using ProjectAkhir_RAiso.Factory;
using ProjectAkhir_RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAkhir_RAiso.Repository
{
    public class UserRepository
    {
        private static StationeryDBEntities _db = DatabaseSingleton.GetInstance();

        public static User findUserByName (string name)
        {
            if (_db.Users == null) return null;

            User user = _db.Users.Where(x=> x.UserName == name).FirstOrDefault();

            if(user == null) { return null; } 
            
            return user;
        }

        public static User findRegisteredUser(string name, string password)
        {
            if (_db.Users == null) return null;

            User user = _db.Users.Where(x => x.UserName == name && x.UserPassword == password).FirstOrDefault();

            if (user == null) { return null; }

            return user;
        }

        public static void insertNewCustomer(string name, string DOB, string gender, string address, string phone, string password)
        {
            User newUser = UserFactory.CreateCustomer(name, DOB, gender, address, phone, password);
            if(newUser == null) { return; }

            _db.Users.Add(newUser);
            _db.SaveChanges();

        }

        public static string GetUserName(int UserID)
        {
            User user = _db.Users.Find(UserID);

            if (user == null) { return null; }

            return user.UserName;
        }

        public static void UpdateUser(int UserID, string name, string DOB, string gender, string address, string phone, string password)
        {
            User oldUser = _db.Users.Find(UserID);
            if (oldUser == null) { return; }

            oldUser.UserName = name;
            oldUser.UserDOB = Convert.ToDateTime(DOB);
            oldUser.UserGender = gender;
            oldUser.UserAddress = address;
            oldUser.UserPhone = phone;
            oldUser.UserPassword = password;

            _db.SaveChanges();
            return;
        }
    }
}