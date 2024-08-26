using ProjectAkhir_RAiso.Handler;
using ProjectAkhir_RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAkhir_RAiso.Controller
{
    public class StationeryController
    {
        public static string DeleteStationery(string name)
        {
            if (CartController.CheckItemInCart(name))
            {
                CartController.DeleteItemFromAllCart(name);
            }
            if (TransactionController.CheckItemInTransaction(name))
            {
                TransactionController.DeleteItemFromAllTransaction(name);
            }

            StationeryHandler.DeleteStationery(name);

            return "Delete Success";

        }
        public static string UpdateStationery(string name, string price, int id)
        {
            if (name == "" || price == "")
            {
                return "All field must be filled!";
            }
            else if (name.Length < 3 || name.Length > 50)
            {
                return "Stationery name invalid.";
            }

            if (int.TryParse(price, out int stationeryPrice))
            {
                if (stationeryPrice < 2000)
                {
                    return "Price must be >2000";
                }
            }
            else
            {
                return "Price must be integer.";
            }

            int parsedPrice = int.Parse(price);
            StationeryHandler.UpdateStationery(name, parsedPrice, id);

            return "Update Success.";
        }
        public static string InsertNewStationery(string name, string price)
        {
            if(name == "" || price == "")
            {
                return "All field must be filled!";
            }else if(name.Length < 3 || name.Length > 50)
            {
                return "Stationery name must be 3-50 characters.";
            }else if (CheckDuplicateItem(name))
            {
                return "Item is already been inserted.";
            }

            if(int.TryParse(price, out int stationeryPrice))
            {
                if(stationeryPrice < 2000)
                {
                    return "Price must be >2000";
                }
            }
            else
            {
                return "Price must be integer.";
            }

            int parsedPrice = int.Parse(price);
            StationeryHandler.InsertNewStationery(name, parsedPrice);

            return "Insert Success.";
            
        }
        public static List<Stationery> GetStationeryList()
        {
            return StationeryHandler.GetStationeryList();
        }

        public static int findIDbyName(string name)
        {
            return StationeryHandler.GetIDbyName(name);
        }

        public static Stationery findItem(int id)
        {
            return StationeryHandler.GetStationery(id);
        }

        public static bool CheckDuplicateItem(string name)
        {
            Stationery item = StationeryHandler.GetStationery(StationeryHandler.GetIDbyName(name));

            if (item == null) { return false; }

            return true;
        }
    }
}