using ProjectAkhir_RAiso.Model;
using ProjectAkhir_RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using System.Web.Util;
using System.Xml.Linq;

namespace ProjectAkhir_RAiso.Handler
{
    public class TransactionHandler
    {
        public static bool FindItemInTransaction(int ItemID)
        {
            return TransactionRepository.FindItemInTransaction(ItemID);
        }
        public static int InitTransaction(int UserID)
        {
            return TransactionRepository.InitTransaction(UserID);
        }

        public static void InsertTransactionDetail(int TransactionID, int StationeryID, int Quantity)
        {
            TransactionRepository.InsertTransactionDetail(TransactionID, StationeryID, Quantity);
        }

        public static List<TransactionHeader> GetUserTransaction(int UserID)
        {
            return TransactionRepository.GetUserTransaction(UserID);
        }

        public static List<TransactionDetail> GetTransactionDetail(int TransactionID)
        {
            return TransactionRepository.GetTransactionDetail(TransactionID);
        }

        public static void DeleteItemFromAllTransaction(string ItemName)
        {
            TransactionRepository.DeleteItemFromAllTransaction(ItemName);
        }

        public static List<TransactionHeader> GetTransactionHeaders()
        {
            return TransactionRepository.GetTransactionHeaders();
        }
    }
}