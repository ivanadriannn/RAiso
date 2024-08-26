using ProjectAkhir_RAiso.Factory;
using ProjectAkhir_RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProjectAkhir_RAiso.Repository
{
    public class CartRepository
    {
        private static StationeryDBEntities _db = DatabaseSingleton.GetInstance();

        public static void AddItemToCart(int Qty, int UserID, int ItemID)
        {
            Cart newCart = CartFactory.CreateCart(Qty, UserID, ItemID);

            if (newCart == null ) { return; }

            _db.Carts.Add(newCart);
            _db.SaveChanges();
        }

        public static Cart GetCart(int UserID, int ItemID)
        {
            Cart cart = _db.Carts.Where(x => x.UserID == UserID && x.StationeryID == ItemID).FirstOrDefault();

            if (cart == null) { return null; }

            return cart;
        }

        public static List<Cart> GetAllCart(int UserID)
        {
            List<Cart> carts = _db.Carts.Where(x => x.UserID == UserID).ToList();

            if (_db.Carts == null || carts == null)
            {
                return null;
            }

            return carts;
        }
        public static void DeleteItemFromCart(int UserID, int ItemID)
        {
            Cart TargetCart = _db.Carts.Where(x => x.UserID == UserID && x.StationeryID == ItemID).FirstOrDefault();

            if (TargetCart == null) { return; }

            _db.Carts.Remove(TargetCart);
            _db.SaveChanges();
        }

        public static void DeleteItemFromAllCart(string ItemName)
        {
            int itemId = _db.Stationeries.Where(x => x.StationeryName == ItemName).FirstOrDefault().StationeryID;
            List<Cart> TargetCart = (from cart in _db.Carts
                                     where cart.StationeryID == itemId
                                     select cart).ToList();

            if (TargetCart == null) { return; };

            foreach (Cart cart in TargetCart)
            {
                _db.Carts.Remove(cart);
                _db.SaveChanges();
            }
        }
        public static void UpdateCart(int UserID, int ItemID, int newQuantity)
        {
            Cart OldCart = _db.Carts.Where(x => x.UserID == UserID && x.StationeryID == ItemID).FirstOrDefault();

            if (OldCart == null) { return; }

            OldCart.Quantity = newQuantity;
            _db.SaveChanges();
        }
        public static bool FindItemInCart(int ItemID)
        {
            Cart cart = _db.Carts.Where(x=> x.StationeryID == ItemID).FirstOrDefault();

            if (cart == null) { return false; }

            return true;
        }
    }
}