using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Mpp_Lab1.DBUtils
{
    class DBUtils
    {
        private static SQLiteConnection _instance = null;

        private static SQLiteConnection getNewConnection()
        {
            // Windows Sqlite Connection, fisierul .db ar trebuie sa fie in directorul debug/bin
            String connectionString = "Data Source = Lab1Mpp.db; Version = 3; FailIfMissing = True";
            return new SQLiteConnection(connectionString);
        }

        public static SQLiteConnection getConnection()
        {
            if (_instance == null )
            {
                _instance = getNewConnection();
                
            }

            return _instance;
        }
    }
}
