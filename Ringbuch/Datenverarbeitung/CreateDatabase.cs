using System.IO;
using System.Data.SQLite;
using System;
using System.Windows.Forms;

namespace Ringbuch
{
    class CreateDatabase
    {
        private string _sqliteDatabase;
        private SQLiteConnection _con;
        private SQLiteCommand _command;
        private SQLiteDataReader _dataReader;
        private string _pfad;
        private MyDialog _dialog;

        private string[] TabellenNamen = { "Personen", "Ergebnisse", "Material", "Verschiedenes", "Adressen" };

        public void DBErstellen(string pfad)
        {
            _pfad = pfad;
            _sqliteDatabase = Path.Combine(_pfad, "Ringbuch.db");
            SQLiteConnection.CreateFile(_sqliteDatabase);
            if (File.Exists(_sqliteDatabase))
            {
                PersonenTabelle();
                ErgebnisseTable();
                MaterialTable();
                VerschiedenesTable();
                AdressenTable();
                if (CheckIfTablesExists())
                {
                    _dialog = new MyDialog(false, "Datenbank angelegt", "Die Datenbank wurde angelegt.", false);
                    MessageBox.Show("Die Datenbank würde angelegt." + Environment.NewLine + "Pfad: " + _sqliteDatabase, "Datenbak angelegt", MessageBoxButtons.OK);
                }
                else
                {
                    File.Delete(_sqliteDatabase);
                    DialogResult result = MessageBox.Show(
                        "Beim Erstellen der Datenbank ist ein Fehler aufgetreten." + Environment.NewLine +
                        "Pfad: " + _sqliteDatabase, "Fehler", MessageBoxButtons.RetryCancel);
                    if (result == DialogResult.Retry)
                    {
                        DBErstellen(_pfad);
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
        private void DoConnect()
        {
            try
            {
                _con = new SQLiteConnection();
                _con.ConnectionString = "Data Source=" + _sqliteDatabase;
                _con.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CloseConections()
        {
            if (_dataReader != null)
            {
                _dataReader.Close();
            }
            if (_con != null)
            {
                _con.Close();
            }
        }
        private void PersonenTabelle()
        {
            DoConnect();
            using (_command = new SQLiteCommand(_con))
            {
                _command.CommandText =
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
           "[IstVize] BOOLEAN DEFAULT 0," +
           "[IstArchiviert] BOOLEAN); ";
                _dataReader = _command.ExecuteReader();
            }
            CloseConections();
        }
        private void ErgebnisseTable()
        {
            DoConnect();
            using (_command = new SQLiteCommand(_con))
            {

                _command.CommandText =
           "CREATE TABLE[Ergebnisse](" +
           "[NamenID] int NOT NULL, " +
           "[Datum]" +
           "DATE NOT NULL, " +
           "[Satz 1] NVARCHAR(18) NOT NULL," +
           "[Satz 2] NVARCHAR(18), " +
           "[Satz 3] NVARCHAR(18), " +
           "[Satz 4] NVARCHAR(18), " +
           "[Art]" +
           "char(32) NOT NULL," +
           "[Info] nvarchar(128)," +
           "[IstArchiviert] BOOL NOT NULL DEFAULT 0)";
                _dataReader = _command.ExecuteReader();
            }
            CloseConections();
        }
        private void MaterialTable()
        {
            DoConnect();
            using (_command = new SQLiteCommand(_con))
            {

                _command.CommandText =
           "CREATE TABLE[Material](" +
           "[Gruppe] char(32) NOT NULL," +
           "[Bezeichnung] char(32)," +
           "[Langtext] char(32)," +
           "[Groesse] char(32))";
                _dataReader = _command.ExecuteReader();
            }
            CloseConections();
        }
        private void VerschiedenesTable()
        {
            DoConnect();
            using (_command = new SQLiteCommand(_con))
            {

                _command.CommandText =
           "CREATE TABLE[Verschiedenes](" +
           "[Schuetzenfest] date NOT NULL, SchiessArten Text, Password Text, AdminPW Text)";
                _dataReader = _command.ExecuteReader();
            }
            CloseConections();
        }
        private void AdressenTable()
        {
            DoConnect();
            using (_command = new SQLiteCommand(_con))
            {

                _command.CommandText =
        "CREATE TABLE [Adressen](" +
        "[Strasse] VARCHAR NOT NULL," +
        "[Stadt] VARCHAR NOT NULL," +
        "[Land] VARCHAR NOT NULL," +
        "[PLZ] INTEGER NOT NULL)";
                _dataReader = _command.ExecuteReader();
            }
            CloseConections();
        }
        private bool CheckIfTablesExists()
        {
            bool retn = false;
            DoConnect();
            int count = 0;
            string statement = string.Empty;
            using (_command = new SQLiteCommand(_con))
            {
                foreach (string name in TabellenNamen)
                {
                    _command.CommandText = "SELECT name FROM sqlite_master WHERE name = '" + name + "' AND type = 'table'";
                    _dataReader = _command.ExecuteReader();
                    if (_dataReader.StepCount > 0)
                    {
                        count += 1;
                    }
                    _dataReader.Close();
                }
                CloseConections();
                if (count == TabellenNamen.Length)
                {
                    retn = true;
                }
            }
            return retn;
        }
    }
}
