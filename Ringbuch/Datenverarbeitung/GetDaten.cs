using Logging_APE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
// Kommentar
namespace Ringbuch
{
    class GetDaten
    {
        private string _sqliteDatabase;
        private SQLiteConnection _con;
        private SQLiteDataReader _dataReader;
        private SQLiteCommand _command;

        private void DoConnect()
        {
            try
            {
                getDatabasePath();
                _con = new SQLiteConnection();
                _con.ConnectionString = "Data Source=" + _sqliteDatabase;
                //setPW();
                _con.SetPassword("abc");
                _con.Open();
                _command = new SQLiteCommand(_con);
                _command.CommandText = "";
                _command.ExecuteNonQuery();
                //clearPW();
            }
            catch (Exception ex)
            {
                writeLog("SQL-Verbindung ist fehlgeschlagen. Exception: " + ex.Message + " Methode: " + MethodBase.GetCurrentMethod().ToString());
                MessageBox.Show(ex.Message);
                Environment.Exit(-1);
            }
        }

        private void clearPW()
        {
            _con.ChangePassword("");
            Environment.Exit(-1);
        }

        private void setPW()
        {
            _con = new SQLiteConnection();
            _con.ConnectionString = "Data Source=" + _sqliteDatabase;
            _con.Open();
            _command = new SQLiteCommand(_con);
            _command.CommandText = "";
            _command.ExecuteNonQuery();
            _con.ChangePassword("abc");
            CloseConections();
            _con.Close();
            Environment.Exit(-1);
        }

        private bool SetSQLitePassword()
        {
            try
            {
                _con = new SQLiteConnection();
                _con.ConnectionString = "Data Source=" + _sqliteDatabase;
                _con.Open();
                _command = new SQLiteCommand(_con);
                _command.CommandText = "";
                _command.ExecuteNonQuery();
                _con.ChangePassword("abc");
                CloseConections();
                _con.Close();
                return true;
            }
            catch (Exception ex)
            {
                writeLog(ex.Message + " Methode: " + MethodBase.GetCurrentMethod().ToString());
                MessageBox.Show(ex.Message);
                CloseConections();
                _con.Close();
                return false;
            }
        }

        private void writeLog(string logText)
        {
            Log.Instance.FILENAME_SUFFIX = "Ringbuch";
            Log.Instance.Write(logText, typeof(Program).ToString());
        }

        private void getDatabasePath()
        {

            if (File.Exists(Directory.GetCurrentDirectory() + "\\ringbuch.xml"))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(Directory.GetCurrentDirectory() + "\\ringbuch.xml");
                XmlNode node = xml.DocumentElement.SelectSingleNode("/Datenbank/Pfad");
                _sqliteDatabase = node.InnerText;
            }
            else
            {
                createXMLFile();
                getDatabasePath();
                //SetSQLitePassword();
            }
        }
        private void createXMLFile()
        {
            writeLog("Die XML-Datei konnte nicht gefunden werden. Methode: " + MethodBase.GetCurrentMethod().ToString());
            DialogResult result = MessageBox.Show(
                 "Es ist ein Fehler mit der xml-Datei aufgetreten." + Environment.NewLine +
                 "Wollen Sie die Datei neu anlegen?", "XML-Error", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "SQLite-Datenbank | *.db";
                openFileDialog.Title = "Select Database";
                openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                openFileDialog.ShowDialog();
                MyDialog myDialog = new MyDialog(true, "Password", "Bitte ein Password eingeben.", true);
                myDialog.ShowDialog();

                XmlDocument doc = new XmlDocument();
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(docNode);
                //  Element 'Datenbank' erstellen und dem XmlDocument hinzufügen
                XmlNode DatenbankNode = doc.CreateElement("Datenbank");
                doc.AppendChild(DatenbankNode);
                //  Element 'Pfad' erstellen, mit dem Pfad füllen und als 'Unterknoten' dem Node 'Datenbank' hinzufügen
                XmlNode PfadNode = doc.CreateElement("Pfad");
                PfadNode.AppendChild(doc.CreateTextNode(openFileDialog.FileName));
                DatenbankNode.AppendChild(PfadNode);
                //  Element 'Password' erstellen, mit dem Passwort füllen und als 'Unterknoten' dem Node 'Datenbank' hinzufügen
                XmlNode PasswordNode = doc.CreateElement("Password");
                PasswordNode.AppendChild(doc.CreateTextNode(myDialog.codedText));
                DatenbankNode.AppendChild(PasswordNode);
                //  Xml-Datei speichern
                doc.Save("Ringbuch.xml");
                SetDaten setDaten = new SetDaten();
                setDaten.SetPasswordToDatabase(myDialog.codedText);

                _sqliteDatabase = openFileDialog.FileName;
                writeLog("Es wurde eine neue XML-Datei angelegt. Pfad: " + openFileDialog.FileName.ToString() + " Methode: " + MethodBase.GetCurrentMethod().ToString());
            }
            else
            {
                writeLog("Benutzer hat das Anlegen der XML-Datei abgebrochen. DialogResult: " + result.ToString() + " Methode: " + MethodBase.GetCurrentMethod().ToString());
                Environment.Exit(1);
            }
        }
        public string getPassword()
        {
            DoConnect();
            string password = string.Empty;
            _command = new SQLiteCommand(_con);
            _dataReader = CreateSelectStatement("Password", "Verschiedenes");
            while (_dataReader.Read())
            {
                password = _dataReader.GetValue(0).ToString();
            }
            CloseConections();
            return password;
        }
        public string getAdminPW()
        {
            DoConnect();
            string password = string.Empty;
            _command = new SQLiteCommand(_con);
            _dataReader = CreateSelectStatement("AdminPW", "Verschiedenes");
            while (_dataReader.Read())
            {
                password = _dataReader.GetValue(0).ToString();
            }
            CloseConections();
            return password;
        }
        private void CloseConections()
        {
            if (_dataReader != null)
            {
                _dataReader.Close();
            }
        }

        public string getSchiessKlasse(int namenID)
        {
            string ret = "NULL";
            int alter = Convert.ToInt16(DateTime.Now.ToString("yyyy")) - getJahrgang(namenID);
            if (alter <= 12)
            {
                ret = "Schüler B";
            }
            else if (alter > 12 && alter < 15)
            {
                ret = "Schüler A";
            }
            else if (alter >= 15 && alter < 17)
            {
                ret = "Jugend";
            }
            else if (alter >= 17 && alter < 19)
            {
                ret = "Junioren B";
            }
            else if (alter >= 19 && alter < 21)
            {
                ret = "Junioren A";
            }
            else if (alter >= 21)
            {
                char geschlecht = getGeschlecht(namenID);
                if (geschlecht == 'm')
                {
                    ret = "Herren";
                }
                else if (geschlecht == 'w')
                {
                    ret = "Damen";
                }
                else
                {
                    ret = "Herren/Damen";
                }
            }
            return ret;
        }

        internal string getSchiessArt(string SchiessKlasse)
        {
            switch (SchiessKlasse)
            {
                case "Schüler B":
                    return "Auflage";

                case "Schüler A":
                    return "Freihand";

                case "Jugend":
                    return "Freihand";

                case "Junioren B":
                    return "Freihand";

                case "Junioren A":
                    return "Freihand";

                case "Herren":
                    return "Freihand";

                case "Damen":
                    return "Freihand";

                case "Herren/Damen":
                    return "Freihand";

                default:
                    return "";
            }
        }

        public int getSchuss(string SchiessKlasse)
        {
            switch (SchiessKlasse)
            {
                case "Schüler B":
                    return 30;

                case "Schüler A":
                    return 30;

                case "Jugend":
                    return 40;

                case "Junioren B":
                    return 40;

                case "Junioren A":
                    return 40;

                case "Herren":
                    return 40;

                case "Damen":
                    return 40;

                case "Herren/Damen":
                    return 40;

                default:
                    return -1;
            }
        }
        public string getPathDatabase()
        {
            return _sqliteDatabase;
        }

        public List<String> getErgebnis(int namenID, int ergebnisID)
        {
            DoConnect();
            _command = new SQLiteCommand(_con);
            _dataReader = CreateSelectStatement(
                "Datum, \"Satz 1\", \"Satz 2\", \"Satz 3\", \"Satz 4\", Art, Info",
                "Ergebnisse",
                "NamenID = " + namenID + " AND rowid = " + ergebnisID, "");
            List<String> liste = new List<String>();
            while (_dataReader.Read())
            {
                liste.Add(_dataReader.GetValue(0).ToString());
                liste.Add(_dataReader.GetValue(1).ToString());
                liste.Add(_dataReader.GetValue(2).ToString());
                liste.Add(_dataReader.GetValue(3).ToString());
                liste.Add(_dataReader.GetValue(4).ToString());
                liste.Add(_dataReader.GetValue(5).ToString());
                liste.Add(_dataReader.GetValue(6).ToString());
            }
            CloseConections();
            return liste;
        }

        public List<string> getSchiessArten()
        {
            DoConnect();
            _command = new SQLiteCommand(_con);
            _dataReader = CreateSelectStatement("SchiessArten", "Verschiedenes");
            List<string> liste = new List<string>();
            while (_dataReader.Read())
            {
                liste = _dataReader.GetValue(0).ToString().Split(',').ToList();
            }

            CloseConections();
            return liste;
        }

        public List<String> getName(int namenID)
        {
            DoConnect();
            _command = new SQLiteCommand(_con);
            _dataReader = CreateSelectStatement("Vorname, Zweitname, Nachname", "Personen", "rowid", namenID.ToString());
            List<String> liste = new List<string>();
            while (_dataReader.Read())
            {
                liste.Add(_dataReader.GetValue(0).ToString());
                liste.Add(_dataReader.GetValue(1).ToString());
                liste.Add(_dataReader.GetValue(2).ToString());
            }
            CloseConections();
            return liste;
        }

        public int getMaterialIDByNamenID(int namenID, string materialName)
        {
            if (materialName.ToLower() == "handschuh" || materialName.ToLower() == "jacke" || materialName.ToLower() == "kleinkaliber" || materialName.ToLower() == "luftgewehr")
            {
                materialName = materialName + "ID";

                DoConnect();
                _command = new SQLiteCommand(_con);
                int ID = -1;
                _dataReader = CreateSelectStatement(materialName, "Personen", "rowid", namenID.ToString());
                while (_dataReader.Read())
                {
                    ID = _dataReader.GetInt16(0);
                }
                CloseConections();
                return ID;
            }
            return -1;
        }
        public List<string> getMaterialGruppen()
        {

            DoConnect();
            _command = new SQLiteCommand(_con);
            DataTable dt = new DataTable();
            List<string> listeMaterialGruppen = new List<string>();
            _dataReader = CreateSelectStatement("Gruppe", "Material", "Bezeichnung = 'ignore'", "");
            while (_dataReader.Read())
            {
                listeMaterialGruppen.Add(_dataReader.GetValue(0).ToString());
            }

            CloseConections();
            return listeMaterialGruppen;
        }
        public DataTable getMaterialByGruppe(string gruppe)
        {
            DoConnect();
            _command = new SQLiteCommand(_con);
            DataTable dt = CreateDataTable("Material");
            dt.Columns.Add("Anzeige");
            _dataReader = CreateSelectStatement("rowid, *", "Material", "Gruppe = '" + gruppe + "' AND Bezeichnung != 'ignore'", "");
            int i = 0;
            while (_dataReader.Read())
            {
                dt.Rows.Add(new object[]{
                    _dataReader.GetValue(0),
                    _dataReader.GetValue(1),
                    _dataReader.GetValue(2),
                    _dataReader.GetValue(3),
                    _dataReader.GetValue(4)
                });
                CreateBezeichnung(dt, i);
                i++;
            }
            dt.Rows.Add(new object[]{
                -1,
            });
            CloseConections();
            return dt;
        }

        private DataTable CreateBezeichnung(DataTable dt, int rowCount)
        {
            if (Object.Equals(_dataReader.GetValue(3).ToString(), "") & Object.Equals(_dataReader.GetValue(4).ToString(), ""))
            {
                dt.Rows[rowCount]["Anzeige"] = _dataReader.GetValue(2).ToString();
            }
            else if (Object.Equals(_dataReader.GetValue(3).ToString(), "") & !Object.Equals(_dataReader.GetValue(4).ToString(), ""))
            {
                dt.Rows[rowCount]["Anzeige"] = _dataReader.GetValue(2).ToString() + " | " + _dataReader.GetValue(4).ToString();
            }
            else if (!Object.Equals(_dataReader.GetValue(3).ToString(), "") & !Object.Equals(_dataReader.GetValue(4).ToString(), ""))
            {
                dt.Rows[rowCount]["Anzeige"] = _dataReader.GetValue(2).ToString() + " | " + _dataReader.GetValue(3).ToString() + " | " + _dataReader.GetValue(4).ToString();
            }
            else if (!Object.Equals(_dataReader.GetValue(3).ToString(), "") & Object.Equals(_dataReader.GetValue(4).ToString(), ""))
            {
                dt.Rows[rowCount]["Anzeige"] = _dataReader.GetValue(2).ToString() + " | " + _dataReader.GetValue(3).ToString();
            }

            return dt;
        }

        public DataTable getPersonenDaten(int namenID)
        {
            DoConnect();
            _command = new SQLiteCommand(_con);
            DataTable dt = CreateDataTable("Personen");
            _dataReader = CreateSelectStatement("rowid, *", "Personen", "rowid", namenID.ToString());
            while (_dataReader.Read())
            {
                dt.Rows.Add(new object[]{
                    _dataReader.GetValue(0),
                    _dataReader.GetValue(1),
                    _dataReader.GetValue(2),
                    _dataReader.GetValue(3),
                    _dataReader.GetValue(4),
                    _dataReader.GetValue(5),
                    _dataReader.GetValue(6),
                    _dataReader.GetValue(7),
                    _dataReader.GetValue(8),
                    _dataReader.GetValue(9),
                    _dataReader.GetValue(10),
                    _dataReader.GetValue(11),
                    _dataReader.GetValue(12),
                    _dataReader.GetValue(13),
                    _dataReader.GetValue(14)
                });
            }
            CloseConections();
            return dt;
        }

        public string getAdresse(int namenID)
        {
            string adresse = "";
            DoConnect();
            _command = new SQLiteCommand(_con);
            _dataReader = CreateSelectInnerJoinStatement(
                "Adressen.Strasse, Adressen.PLZ, Adressen.Stadt, Adressen.Land", "Adressen", "Personen",
                "Personen.rowid = " + namenID + " AND Personen.AdressID = Adressen.rowid", "");
            while (_dataReader.Read())
            {
                adresse =
                    _dataReader.GetValue(0) + ", " +
                    _dataReader.GetValue(1) + " " +
                    _dataReader.GetValue(2) + ", " +
                    _dataReader.GetValue(3);
            }
            CloseConections();
            return adresse;
        }

        private int getJahrgang(int namenID)
        {
            DoConnect();
            _command = new SQLiteCommand(_con);
            DateTime datum = DateTime.Now;
            _dataReader = CreateSelectStatement("Geburtstag", "Personen", "rowID", namenID.ToString());
            while (_dataReader.Read())
            {
                datum = Convert.ToDateTime(_dataReader.GetValue(0));
            }
            int jahrgang = Convert.ToInt16(datum.ToString("yyyy"));
            return jahrgang;
        }
        private char getGeschlecht(int namenID)
        {
            DoConnect();
            _command = new SQLiteCommand(_con);
            char geschlecht = 'x';
            _dataReader = CreateSelectStatement("Geschlecht", "Personen", "rowID", namenID.ToString());
            while (_dataReader.Read())
            {
                geschlecht = Convert.ToChar(_dataReader.GetValue(0));
            }
            return geschlecht;
        }
        public List<int> getAlter(int namenID)
        {
            DoConnect();
            _command = new SQLiteCommand(_con);
            string Geburtstag = "";
            string SchFest = "";
            List<int> listAlter = new List<int>();
            _dataReader = CreateSelectInnerJoinStatement("Geburtstag, Schuetzenfest", "Personen", "Verschiedenes", "Personen.rowid", namenID.ToString());
            while (_dataReader.Read())
            {
                Geburtstag = _dataReader.GetValue(0).ToString();
                SchFest = _dataReader.GetValue(1).ToString();
            }

            DateTime zeroTime = new DateTime(1, 1, 1);

            DateTime dateTimeGeburtstag = DateTime.Parse(Geburtstag);
            DateTime dateTimeSchFest = DateTime.Parse(SchFest);

            TimeSpan timeSpan = DateTime.Now - dateTimeGeburtstag;
            if (timeSpan.Ticks > 0)
            {
                listAlter.Add((zeroTime + timeSpan).Year - 1);
            }
            else
            {
                listAlter.Add(-1);
            }

            timeSpan = dateTimeSchFest - dateTimeGeburtstag;
            TimeSpan timeSpanSchFestZuHeute = DateTime.Now - dateTimeSchFest;
            if (timeSpanSchFestZuHeute.Days < 0)
            {
                if (timeSpan.Days >= 0)
                {
                    listAlter.Add((zeroTime + timeSpan).Year - 1);
                }
            }
            CloseConections();
            return listAlter;
        }

        public DataTable getShowMaterial(List<int> MaterialIDList)
        {
            DoConnect();
            _command = new SQLiteCommand(_con);
            DataTable dt = CreateDataTable("Material");
            _dataReader = CreateSelectStatement("rowid, *", "Material",
                "rowid = " + MaterialIDList[0] + " OR" +
                " rowid = " + MaterialIDList[1] + " OR" +
                " rowid = " + MaterialIDList[2] + " OR" +
                " rowid = " + MaterialIDList[3], "");
            while (_dataReader.Read())
            {
                dt.Rows.Add(new object[]{
                    _dataReader.GetValue(0),
                    _dataReader.GetValue(1),
                    _dataReader.GetValue(2),
                    _dataReader.GetValue(3),
                    _dataReader.GetValue(4)
                });
            }
            CloseConections();
            return dt;
        }

        public DataTable getMaterialByID(int ID)
        {
            DoConnect();
            _command = new SQLiteCommand(_con);
            DataTable dt = CreateDataTable("Material");
            _dataReader = CreateSelectStatement("Material", "NamenID", ID.ToString());

            CloseConections();
            return null;
        }

        public string getSchFest()
        {

            DoConnect();
            _command = new SQLiteCommand(_con);
            DataTable dt = CreateDataTable("Verschiedenes");
            _dataReader = CreateSelectStatement("Schuetzenfest", "Verschiedenes");
            string DatumSchFest = "";
            while (_dataReader.Read())
            {
                DatumSchFest = _dataReader.GetValue(0).ToString();
            }
            CloseConections();
            return DatumSchFest;
        }

        public DataTable getNamen()
        {
            DoConnect();
            _command = new SQLiteCommand(_con);
            DataTable dt = CreateDataTable("Personen");
            _dataReader = CreateSelectStatement("Personen");

            while (_dataReader.Read())
            {
                dt.Rows.Add(new object[]{
                    _dataReader.GetValue(0),
                    _dataReader.GetValue(1),
                    _dataReader.GetValue(2),
                    _dataReader.GetValue(3),
                    _dataReader.GetValue(4),
                    _dataReader.GetValue(5),
                    _dataReader.GetValue(6),
                    _dataReader.GetValue(7),
                    _dataReader.GetValue(8),
                    _dataReader.GetValue(9),
                    _dataReader.GetValue(10),
                    _dataReader.GetValue(11),
                    _dataReader.GetValue(12),
                    _dataReader.GetValue(13),
                    _dataReader.GetValue(14)
                });
            }
            CloseConections();
            return dt;
        }

        private string ConvertDateTime(string datum)
        {
            DateTime date = DateTime.Parse(datum.ToString());
            string DatumOhneZeit = date.ToString("dd.MM.yyyy");
            return DatumOhneZeit;
        }
        public DataTable GetErgebnisse(int ID, string vonDatum, string bisDatum, string schiessArt)
        {
            DoConnect();
            DataTable dt = CreateDataTable("Ergebnisse");
            if (vonDatum == "" && bisDatum == "")
            {
                if (schiessArt == "")
                {
                    _dataReader = CreateSelectStatement("Ergebnisse", "NamenID", ID.ToString());
                }
                else
                {
                    _dataReader = CreateSelectStatement("rowid, *", "Ergebnisse", "Art = '" + schiessArt + "' AND NamenID = " + ID, "");
                }

            }
            else if (vonDatum != "" && bisDatum == "")
            {
                if (schiessArt == "")
                {
                    _dataReader = CreateSelectStatement(
                        "rowid, *", "Ergebnisse", "Datum > '" + vonDatum + " 00:00.000' AND IstArchiviert = 0 AND NamenID = " + ID, "");
                }
                else
                {
                    _dataReader = CreateSelectStatement(
                        "rowid, *", "Ergebnisse", "Datum > '" + vonDatum + " 00:00.000' AND IstArchiviert = 0 AND NamenID = " + ID + " AND Art = '" + schiessArt + "'", "");
                }
            }
            else if (vonDatum != "" && bisDatum != "")
            {
                if (schiessArt == "")
                {
                    _dataReader = CreateSelectStatement(
                        "rowid, *", "Ergebnisse", "Datum >'" + vonDatum + " 00:00.000' AND Datum <'" + bisDatum + " 23:59.999' AND IstArchiviert = 0 AND NamenID = " + ID, "");
                }
                else
                {
                    _dataReader = CreateSelectStatement(
                        "rowid, *", "Ergebnisse",
                        "Datum >'" + vonDatum + " 00:00.000' AND Datum <'" + bisDatum + " 23:59.999' AND IstArchiviert = 0 AND NamenID = " + ID + " AND Art = '" + schiessArt + "'", "");
                }
            }


            while (_dataReader.Read())
            {
                //var test = Convert.ToDateTime(dataReader.GetValue(2)).ToString("dd.MM.yyyy hh:mm");
                double Ergebniss = 0.0;
                for (int i = 3; i <= 6; i++)
                {

                    Ergebniss = Ergebniss + Convert.ToDouble(_dataReader.GetValue(i));
                }
                dt.Rows.Add(new object[]{
                    _dataReader.GetValue(0),
                    _dataReader.GetValue(1),
                    Convert.ToDateTime(_dataReader.GetValue(2)).ToString("dd.MM.yyyy hh:mm"),
                    _dataReader.GetValue(3),
                    _dataReader.GetValue(4),
                    _dataReader.GetValue(5),
                    _dataReader.GetValue(6),
                    Ergebniss,
                    _dataReader.GetValue(7),
                    _dataReader.GetValue(8),
                });
            }
            CloseConections();
            return dt;
        }
        public DataTable GetErgebnisse(int ID, string vonDatum)
        {
            return GetErgebnisse(ID, vonDatum, "", "");
        }
        public DataTable GetErgebnisse(int ID)
        {
            return GetErgebnisse(ID, "", "", "");
        }

        public DataTable CreateDataTable(string dbTableName)
        {
            DoConnect();
            _command = new SQLiteCommand(_con);
            _command.CommandText = "PRAGMA table_info(" + dbTableName + ")";
            _dataReader = _command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("rowid", typeof(Int16));
            int i = 0;
            while (_dataReader.Read())
            {
                dt.Columns.Add(_dataReader.GetValue(1).ToString());
                if (i == 5 && dbTableName == "Ergebnisse")
                {
                    dt.Columns.Add("Ergebnis", typeof(double));
                }
                i++;
            }
            CloseConections();
            return dt;
        }

        /// <summary>
        /// SELECT rowid, * FROM " + dbTableName
        /// </summary>
        /// <param name="dbTableName"></param>
        /// <returns></returns>
        private SQLiteDataReader CreateSelectStatement(string dbTableName)
        {
            if (dbTableName.ToLower() == "personen" || dbTableName.ToLower() == "ergebnisse")
            {
                _command.CommandText = "SELECT rowid, * FROM " + dbTableName + " WHERE IstArchiviert = 0";
            }
            else
            {
                _command.CommandText = "SELECT rowid, * FROM " + dbTableName;
            }

            _dataReader = _command.ExecuteReader();
            return _dataReader;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbTableName"></param>
        /// <param name="dbWhere"></param>
        /// <param name="dbValue"></param>
        /// <returns></returns>
        private SQLiteDataReader CreateSelectStatement(string dbTableName, string dbWhere, string dbValue)
        {
            if (dbTableName.ToLower() == "ergebnisse")
            {
                _command.CommandText = "SELECT rowid, * FROM " + dbTableName + " WHERE " + dbWhere + " = '" + dbValue + "' AND IstArchiviert = 0";
            }
            else
            {
                _command.CommandText = "SELECT rowid, * FROM " + dbTableName + " WHERE " + dbWhere + " = '" + dbValue + "'";
            }
            _dataReader = _command.ExecuteReader();
            return _dataReader;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbColumns"></param>
        /// <param name="dbTableName"></param>
        /// <returns></returns>
        private SQLiteDataReader CreateSelectStatement(string dbColumns, string dbTableName)
        {
            _command.CommandText = "SELECT " + dbColumns + " FROM " + dbTableName;
            _dataReader = _command.ExecuteReader();
            return _dataReader;
        }

        /// <summary>
        /// CreateSelectStatement
        /// </summary>
        /// <param name="dbColumns"></param>
        /// <param name="dbTableName"></param>
        /// <param name="dbWhere"></param>
        /// <param name="dbValue">Kann leer sein, dann bei dbWhere komplette Suchbedingung, ohne 'WHERE', eingeben</param>
        /// <returns></returns>
        private SQLiteDataReader CreateSelectStatement(string dbColumns, string dbTableName, string dbWhere, string dbValue)
        {
            if (dbValue != "")
            {
                _command.CommandText = "SELECT " + dbColumns + " FROM " + dbTableName + " WHERE " + dbWhere + " = '" + dbValue + "' AND IstArchiviert = 0";
            }
            else
            {
                _command.CommandText = "SELECT " + dbColumns + " FROM " + dbTableName + " WHERE " + dbWhere;
            }

            _dataReader = _command.ExecuteReader();
            return _dataReader;
        }
        /// <summary>
        /// CreateSelectInnerJoinStatement
        /// </summary>
        /// <param name="dbColumns"></param>
        /// <param name="dbTableName1"></param>
        /// <param name="dbTableName2"></param>
        /// <param name="dbWhere"></param>
        /// <param name="dbValue">Kann leer sein, dann bei dbWhere komplette Suchbedingung, ohne 'WHERE', eingeben</param>
        /// <returns></returns>
        private SQLiteDataReader CreateSelectInnerJoinStatement(string dbColumns, string dbTableName1, string dbTableName2, string dbWhere, string dbValue)
        {
            if (dbValue != "")
            {
                _command.CommandText = "SELECT " + dbColumns + " FROM " + dbTableName1 + " INNER JOIN " + dbTableName2 + " WHERE " + dbWhere + " = " + dbValue;
            }
            else
            {
                _command.CommandText = "SELECT " + dbColumns + " FROM " + dbTableName1 + " INNER JOIN " + dbTableName2 + " WHERE " + dbWhere;
            }

            _dataReader = _command.ExecuteReader();
            return _dataReader;
        }
    }
}
