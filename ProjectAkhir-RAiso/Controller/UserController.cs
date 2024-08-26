using ProjectAkhir_RAiso.Handler;
using ProjectAkhir_RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProjectAkhir_RAiso.Controller
{
    public class UserController
    {
        public static string RegisterAuth(string name, string DOB, string gender, string address, string phone, string password)
        {
            if (name == "" || DOB == "" || gender == "" || address == "" || password == "" || phone == "")
            {
                if (string.IsNullOrEmpty(gender))
                {
                    return "Please select your gender.";
                }
                return "All field must be filled!";
            }
            else if (isDuplicateName(name))
            {
                return "Username has already been used.";
            }
            else if (!password.Any(char.IsLetter) || !password.Any(char.IsDigit))
            {
                return "Password must be alphanumeric.";
            }
            else if (name.Length < 5 || name.Length > 50)
            {
                return "Name must be at least 5 characters.";
            }
            else if (getUserAge(DOB) < 1)
            {
                return "User must be at least 1 year old";
            }

            UserHandler.insertCustomer(name, DOB, gender, address, phone, password);

            return "Account has been registered.";
        }

        public static string LoginAuth(string username, string password)
        {
            if (username == "" || password == "")
            {
                return "All field must be filled!";
            }
            else if (checkRegisteredUser(username, password) == null)
            {
                return "Wrong Credentials.";
            }

            return "Login Success.";
        }

        public static User checkRegisteredUser(string username, string password)
        {
            return UserHandler.findRegisteredUser(username, password);
        }

        public static bool isDuplicateName(string name)
        {
            User user = UserHandler.findUserByName(name);

            if (user == null) { return false; }
            return true;
        }

        public static User getUser(string name)
        {
            return UserHandler.findUserByName(name);
        }

        public static int getUserAge(string DOB)
        {
            DateTime parsedDOB = Convert.ToDateTime(DOB);
            int age = DateTime.Today.Year - parsedDOB.Year;

            return age;
        }
        public static string GetUserName(int UserID)
        {
            return UserHandler.GetUserName(UserID);
        }

        public static string UpdateUser(int UserID, string name, string DOB, string gender, string address, string phone, string password)
        {
            if (name == "" || DOB == "" || gender == "" || address == "" || password == "" || phone == "")
            {
                return "All field must be filled!";
            }
            else if (!password.Any(char.IsLetter) || !password.Any(char.IsDigit))
            {
                return "Password must be alphanumeric.";
            }
            else if (name.Length < 5 || name.Length > 50)
            {
                return "Name must be at least 5 characters.";
            }
            else if (getUserAge(DOB) < 1)
            {
                return "User must be at least 1 year old";
            }

            UserHandler.UpdateUser(UserID, name, DOB, gender, address, phone, password);

            return "Account has been updated.";
        }
    }
}