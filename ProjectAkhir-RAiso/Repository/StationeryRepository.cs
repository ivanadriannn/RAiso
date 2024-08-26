using ProjectAkhir_RAiso.Factory;
using ProjectAkhir_RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAkhir_RAiso.Repository
{
    public class StationeryRepository
    {
        private static StationeryDBEntities _db = DatabaseSingleton.GetInstance();

        public static List<Stationery> GetAllStationery()
        {
            if(_db.Stationeries == null) {
                return null;
            }

            return _db.Stationeries.ToList();
        }

        public static int GetIDbyName(string name)
        {
            if (_db.Stationeries == null)
            {
                return 0;
            }
            Stationery item = _db.Stationeries.Where(x => x.StationeryName == name).FirstOrDefault();
            if (item == null) return 0;

            int id = _db.Stationeries.Where(x => x.StationeryName == name).FirstOrDefault().StationeryID;

            return id;
        }

        public static Stationery GetStationery(int id)
        {
            Stationery item = _db.Stationeries.Find(id);

            if (item == null) { return null; }

            return item;
        }
        public static void insertNewStationery(string name, int price)
        {
            Stationery newItem = StationeryFactory.CreateStationery(name, price);
            if (newItem == null) { return; }

            _db.Stationeries.Add(newItem);
            _db.SaveChanges();

        }
        public static void UpdateStationery(string name, int price, int id)
        {
            Stationery oldItem = _db.Stationeries.Find(id);
            if (oldItem == null) { return; };

            oldItem.StationeryName = name;
            oldItem.StationeryPrice = price;
            _db.SaveChanges();
        }
        public static void DeleteStationery(string name)
        {
            Stationery targetItem = _db.Stationeries.Where(x=> x.StationeryName == name).FirstOrDefault();

            if (targetItem == null) { return; }

            _db.Stationeries.Remove(targetItem);
            _db.SaveChanges();
        }
    }
}