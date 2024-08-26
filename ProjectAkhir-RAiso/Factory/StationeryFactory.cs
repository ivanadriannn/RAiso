using ProjectAkhir_RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAkhir_RAiso.Factory
{
    public class StationeryFactory
    {
        public static Stationery CreateStationery(string name, int price)
        {
            Stationery newItem = new Stationery
            {
                StationeryName = name,
                StationeryPrice = price
            };

            return newItem;
        }
    }
}