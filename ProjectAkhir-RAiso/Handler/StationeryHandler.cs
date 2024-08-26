using ProjectAkhir_RAiso.Model;
using ProjectAkhir_RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAkhir_RAiso.Handler
{
    public class StationeryHandler
    {
        public static void DeleteStationery(string name)
        {
            StationeryRepository.DeleteStationery(name);
        }
        public static void UpdateStationery (string name, int price, int id)
        {
            StationeryRepository.UpdateStationery (name, price, id);
        }
        public static void InsertNewStationery(string name, int price)
        {
            StationeryRepository.insertNewStationery(name, price);
        }
        public static List<Stationery> GetStationeryList()
        {
            return StationeryRepository.GetAllStationery();
        }

        public static int GetIDbyName(string name)
        {
            return StationeryRepository.GetIDbyName(name);
        }

        public static Stationery GetStationery(int id)
        {
            return StationeryRepository.GetStationery(id);
        }
    }
}