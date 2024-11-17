using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoMAUI.Models;
using SQLite;

namespace ProyectoMAUI.Services
{
    public static class PurchaseService
    {
        private static SQLiteConnection db;

        static PurchaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "purchases.db");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Purchase>();
        }

        public static void SavePurchase(Purchase purchase)
        {
            db.Insert(purchase);
        }

        public static List<Purchase> GetAllPurchases()
        {
            return db.Table<Purchase>().ToList();
        }

        public static void ClearPurchases()
        {
            db.DeleteAll<Purchase>();
        }
    }
}

