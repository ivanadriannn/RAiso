using ProjectAkhir_RAiso.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProjectAkhir_RAiso.Factory
{
    public class TransactionFactory
    {
        public static TransactionHeader CreateHeader(int UserID)
        {
            TransactionHeader newHeader = new TransactionHeader
            {
                UserID = UserID,
                TransactionDate = DateTime.Now
            };

            return newHeader;
        }

        public static TransactionDetail CreateDetail(int TransactionID, int ItemID, int Quantity)
        {
            TransactionDetail newDetail = new TransactionDetail
            {
                TransactionID = TransactionID,
                StationeryID = ItemID,
                Quantity = Quantity
            };

            return newDetail;
        }
    }
}