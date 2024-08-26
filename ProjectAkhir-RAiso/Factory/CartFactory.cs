using ProjectAkhir_RAiso.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProjectAkhir_RAiso.Factory
{
    public class CartFactory
    {
        public static Cart CreateCart(int Qty, int UserID, int ItemID)
        {
            Cart newCart = new Cart
            {
                UserID = UserID,
                StationeryID = ItemID,
                Quantity = Qty
            };

            return newCart;
        }
    }
}