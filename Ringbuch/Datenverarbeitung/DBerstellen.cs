using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Ringbuch
{
    class DBerstellen
    {

        public void DBErstellen()
        {
            SQLiteConnection.CreateFile("Ringbuch.db");

            SQLiteConnection con = new SQLiteConnection("Data Source = Ringbuch.db;Version = 3");
            con.Open();
        }

    }
}
