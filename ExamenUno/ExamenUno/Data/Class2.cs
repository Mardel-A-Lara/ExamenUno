using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using ExamenUno.Models;
using System.Threading.Tasks;

namespace ExamenUno.Data
{
    public class Class2
    {
        SQLiteAsyncConnection db;
        public Class2 (string dbPath)
        {
            db = new SQLiteAsyncConnection (dbPath);
            db.CreateTableAsync<Class1>().Wait (); 
        }

        public Task<int> SaveClass1Async(Class1 uno)
        {
            if (uno.idlatitud !=0)
            {
                return db.UpdateAsync(uno);
            }
            else
            {
                return db.InsertAsync(uno);
            }
        }
        /// <summary>
        /// Recupera datos
        /// </summary>
        /// <returns></returns>

        public Task <List<Class1>> GetClass1Async()
        {
            return db.Table<Class1>().ToListAsync();
        }

        /// <summary>
        /// Recupera id de latiud
        /// </summary>
        /// <param name="idlatitud"> id de la latitud que se requiere</param>
        /// <returns></returns>
        public Task<Class1> GetClass1Async(int idlatitud)
        { 
            return db.Table<Class1>().Where(a=> a.idlatitud== idlatitud).FirstOrDefaultAsync();
        }
    }
}
