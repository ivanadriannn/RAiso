using ProjectAkhir_RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAkhir_RAiso.Factory
{
    public class UserFactory
    {
        public static User CreateCustomer(string name, string DOB, string gender, string address, string phone, string password)
        {
            User newUser = new User
            {
                UserName = name,
                UserDOB = Convert.ToDateTime(DOB),
                UserGender = gender,
                UserAddress = address,
                UserPhone = phone,
                UserPassword = password,
                UserRole = "Customer"
            };

            return newUser;
        }
    }
}