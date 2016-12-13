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
            string createProfilTable =
                    "CREATE TABLE [Personen](" +
                    "[AdressID] INT NOT NULL DEFAULT (-1)," +
                    "[Vorname] char(24) NOT NULL," +
                    "[Zweitname] char(24)," +
                    "[Nachname] char(24) NOT NULL," +
                    "[Geburtstag] date NOT NULL DEFAULT(1900 - 01 - 01)," +
                    "[Geschlecht] char(1) NOT NULL DEFAULT x," +
                    "[DarfKK] BOOLEAN DEFAULT 0," +
                    "[DarfLG] boolean DEFAULT 0," +
                    "[KleinkaliberID] int," +
                    "[LuftgewehrID] int," +
                    "[HandschuhID] int," +
                    "[JackeID] int," +
                    "[Info] VARCHAR(1024)," +
                    "[IstKoenig] BOOLEAN DEFAULT 0," +
                    "[IstArchiviert] BOOLEAN); ";
        }

    }
}
