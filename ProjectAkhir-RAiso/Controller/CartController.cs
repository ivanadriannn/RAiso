using ProjectAkhir_RAiso.Handler;
using ProjectAkhir_RAiso.Model;
using ProjectAkhir_RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ProjectAkhir_RAiso.Controller
{
    public class CartController
    {
        public static string AddItemToCart(int Qty, int UserID, int ItemID)
        {
            if (Qty <= 0)
            {
                return "Quantity must be at least 1";
            }

            if (UserID == 0 || ItemID == 0)
            {
                return "Error! A wild problem has appeared.";
            }

            if (CartHandler.GetCart(UserID, ItemID) != null)
            {
                return "Item is already in cart.";
            }

            CartHandler.AddItemToCart(Qty, UserID, ItemID);
            return "Successfully added to cart.";
        }

        public static List<dynamic> GetCartInformation(int UserID)
        {
            List<Cart> carts = CartHandler.GetAllCartByID(UserID);

            List<dynamic> CartDetail = new List<dynamic>();
            foreach (Cart cart in carts)
            {
                Stationery item = StationeryController.findItem(cart.StationeryID);
                CartDetail.Add(new
                {
                    StationeryID = cart.StationeryID,
                    StationeryName = item.StationeryName,
                    StationeryPrice = item.StationeryPrice,
                    Quantity = cart.Quantity
                });
            }

            return CartDetail;
        }

        public static void DeleteItemFromCart(int UserID, string ItemName)
        {
            int ItemID = StationeryController.findIDbyName(ItemName);
            CartHandler.DeleteItemFromCart(UserID, ItemID);
        }

        public static void DeleteItemFromAllCart(string ItemName)
        {
            CartHandler.DeleteItemFromAllCart(ItemName);
        }

        public static Cart GetCart(int UserID, int ItemID)
        {
            return CartHandler.GetCart(UserID, ItemID);
        }

        public static string UpdateCart(int UserID, int ItemID, int Quantity)
        {
            if (Quantity <= 0)
            {
                return "Quantity must be at least 1";
            }
            if (UserID == 0 || ItemID == 0 )
            {
                return "Error! A wild problem has appeared.";
            }

            CartHandler.UpdateCart(UserID, ItemID, Quantity);
            return "Update Success.";
        }

        public static bool CheckItemInCart(string ItemName)
        {
            int ItemID = StationeryController.findIDbyName(ItemName);
            return CartHandler.FindItemInCart(ItemID);
        }
    }
}