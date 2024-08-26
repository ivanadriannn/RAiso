using ProjectAkhir_RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAkhir_RAiso.Repository
{
    public class DatabaseSingleton
    {
        public static StationeryDBEntities db = null;

        public static StationeryDBEntities GetInstance () {
            if(db == null) { db = new StationeryDBEntities(); }

            return db;
        }
    }
}