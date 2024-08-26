using ProjectAkhir_RAiso.Handler;
using ProjectAkhir_RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ProjectAkhir_RAiso.Controller
{
    public class TransactionController
    {
        public static bool CheckItemInTransaction(string ItemName)
        {
            int ItemID = StationeryController.findIDbyName(ItemName);
            return TransactionHandler.FindItemInTransaction(ItemID);
        }
        public static void Checkout(int UserID)
        {
            if (UserID == 0) { return; }

            int TransactionID = TransactionHandler.InitTransaction(UserID);

            List<dynamic> carts = CartController.GetCartInformation(UserID);

            foreach (dynamic cart in carts)
            {
                TransactionHandler.InsertTransactionDetail(TransactionID, cart.StationeryID, cart.Quantity);
                CartController.DeleteItemFromCart(UserID, cart.StationeryName);
            }
        }
        public static List<dynamic> GetTransactionInformation(int UserID)
        {
            List<TransactionHeader> Transaction = TransactionHandler.GetUserTransaction(UserID);
            List<dynamic> TransactionList = new List<dynamic>();

            if (Transaction == null) return null;

            foreach (TransactionHeader transaction in Transaction)
            {
                TransactionList.Add(new
                {
                    TransactionID = transaction.TransactionID,
                    TransactionDate = transaction.TransactionDate,
                    UserName = UserController.GetUserName(UserID)
                });
            }

            return TransactionList;
        }
        public static List<dynamic> GetTransactionDetail(int TransactionID)
        {
            List<TransactionDetail> Details = TransactionHandler.GetTransactionDetail(TransactionID);
            List<dynamic> TransactionList = new List<dynamic>();

            if (Details == null) return null;

            foreach (TransactionDetail transaction in Details)
            {
                Stationery item = StationeryController.findItem(transaction.StationeryID);

                TransactionList.Add(new
                {
                    StationeryName = item.StationeryName,
                    StationeryPrice = item.StationeryPrice,
                    Quantity = transaction.Quantity
                });
            }

            return TransactionList;
        }

        public static void DeleteItemFromAllTransaction(string ItemName)
        {
            TransactionHandler.DeleteItemFromAllTransaction(ItemName);
        }
        
        public static List<TransactionHeader> GetTransactionHeaders()
        {
            return TransactionHandler.GetTransactionHeaders();
        }
    }
}