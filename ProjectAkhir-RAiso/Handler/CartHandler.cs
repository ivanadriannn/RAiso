using ProjectAkhir_RAiso.Model;
using ProjectAkhir_RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProjectAkhir_RAiso.Handler
{
    public class CartHandler
    {
        public static void AddItemToCart(int Qty, int UserID, int ItemID)
        {
            CartRepository.AddItemToCart(Qty, UserID, ItemID);
        }

        public static Cart GetCart(int UserID, int ItemID)
        {
            return CartRepository.GetCart(UserID, ItemID);
        }

        public static List<Cart> GetAllCartByID(int UserID)
        {
            return CartRepository.GetAllCart(UserID);
        }

        public static void DeleteItemFromCart(int UserID, int ItemID)
        {
            CartRepository.DeleteItemFromCart(UserID, ItemID);
        }

        public static void DeleteItemFromAllCart(string ItemName)
        {
            CartRepository.DeleteItemFromAllCart(ItemName);
        }

        public static void UpdateCart(int UserID, int ItemID, int Quantity)
        {
            CartRepository.UpdateCart(UserID, ItemID, Quantity);
        }

        public static bool FindItemInCart(int ItemID)
        {
            return CartRepository.FindItemInCart(ItemID);
        }
    }
}