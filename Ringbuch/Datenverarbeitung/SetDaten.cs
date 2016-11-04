using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Globalization;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Microsoft.VisualBasic;
using System.Diagnostics;
using Logging_APE;
using System.Reflection;

namespace Ringbuch
{
    class SetDaten
    {
        private string _sqliteDatabase;
        private SQLiteConnection _con;
        private SQLiteCommand _command;
        private SQLiteDataReader _dataReader;
        private GetDaten _getDaten = new GetDaten();
        private MyDialog _myDialog;
        private bool _showMsgBoxes = true;

        public SetDaten(bool showMsgBoxes)
        {
            _showMsgBoxes = showMsgBoxes;
        }
        public SetDaten()
        {
            if (!Debugger.IsAttached)
            {
                _showMsgBoxes = false;
            }
        }

        private void DoConnect()
        {
            try
            {
                getDatabasePath();
                _con = new SQLiteConnection();
                _con.ConnectionString = "Data Source=" + _sqliteDatabase;
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

        private void writeLog(string logText)
        {
            Log.Instance.FILENAME_SUFFIX = "Ringbuch";
            Log.Instance.Write(logText, typeof(Program).ToString());
        }
        private void getDatabasePath()
        {
            XmlDocument xml = new XmlDocument();
            if (File.Exists(Directory.GetCurrentDirectory() + "\\ringbuch.xml"))
            {
                xml.Load(Directory.GetCurrentDirectory() + "\\ringbuch.xml");
                XmlNode node = xml.DocumentElement.SelectSingleNode("/Datenbank/Pfad");
                _sqliteDatabase = node.InnerText;
            }
            else
            {
                writeLog("Es ist ein Fehler mit der xml-Datei aufgetreten! Methode: " + MethodBase.GetCurrentMethod().ToString());
                MessageBox.Show("Es ist ein Fehler mit der xml-Datei aufgetreten!");
            }
        }

        public void SetPassword()
        {
            if (PasswortAbfrage())
            {
                _myDialog = new MyDialog(true, "Passwort", "Bitte ein Passwort eingeben.", true);
                _myDialog.ShowDialog();
                if (_myDialog.OK)
                {
                    SetPasswordToDatabase(_myDialog.codedText);
                    writeLog("Das Passwort wurde geändert." + " Methode: " + MethodBase.GetCurrentMethod().ToString());
                }
            }
        }

        private void SetPasswordToDatabase(string password)
        {
            DoConnect();
            _command = new SQLiteCommand(_con);
            _command.CommandText = CreateUpdateStatement("Verschiedenes", "Password", password);
            _dataReader = _command.ExecuteReader();
            StatementSuccessful(_dataReader, false);
            CloseConnections();
        }
        public void SetDatabase()
        {
            if (PasswortAbfrage())
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "SQLite-Datenbank | *.db";
                openFileDialog.Title = "Select Database";
                openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    XMLDateiBeschreiben("Datenbank", "Pfad", openFileDialog.FileName);
                }
            }
        }

        private void XMLDateiBeschreiben(string node1, string node2, string text)
        {
            //if (PasswortAbfrage())
            //{
                XmlDocument doc = new XmlDocument();
                doc.Load("Ringbuch.xml");
                XmlNode docNode = doc.SelectSingleNode("/" + node1 + "/" + node2);
                docNode.InnerText = text;
                doc.Save("Ringbuch.xml");
                getDatabasePath();
                if (_showMsgBoxes)
                {
                    MessageBox.Show("Die Eintrage für '" + node2 + "' wurde geändert.", node2 + " ändern");
                }
            //}
        }
        /// <summary>
        /// Passwortabfrage. Im Debuggerbetrieb abgeschaltet
        /// </summary>
        /// <returns></returns>
        private Boolean PasswortAbfrage()
        {
            if (!Debugger.IsAttached)
            {
                _myDialog = new MyDialog(true, "Password", "Für diese Aktion ist ein Passwort erforderlich", false);
                _myDialog.ShowDialog();
                if (_myDialog.PasswortOK)
                {
                    return true;
                }
                else
                {
                    writeLog("Das Passwort wurde falsch eingegeben. Methode: " + MethodBase.GetCurrentMethod().ToString());
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private void CloseConnections()
        {
            if (_dataReader != null)
            {
                _dataReader.Close();
            }
        }
        public void SetSchiessartenDelete(string schiessart)
        {
            if (PasswortAbfrage())
            {
                if (MessageBox.Show("Soll der Eintrag '" + schiessart + "' wirklich gelöscht werden?" + Environment.NewLine + "(" + Convert.ToInt16(Debugger.IsAttached) + ")", "Schiessart löschen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<string> alteScheissarten = _getDaten.getSchiessArten();
                    alteScheissarten.Remove(schiessart);

                    string schiessarten = "";

                    foreach (string item in alteScheissarten)
                    {
                        schiessarten += item.Replace(" ", "") + ",";
                    }
                    schiessarten = schiessarten.Remove(schiessarten.Length - 1, 1);
                    schiessartenUpdate(schiessarten, true);
                }
            }
        }
        public void SetSchiessartenNeu(string schiessart)
        {
            List<string> neueSchiessarten = schiessart.Split(',').ToList();
            List<string> alteScheissarten = _getDaten.getSchiessArten();
            List<string> newList = new List<string>(neueSchiessarten.Count + alteScheissarten.Count);
            newList.AddRange(neueSchiessarten);
            newList.AddRange(alteScheissarten);

            string schiessarten = "";

            foreach (string item in newList)
            {
                if (item.Trim() != "")
                {
                    schiessarten += item.Replace(" ", "") + ",";
                }
            }
            schiessarten = schiessarten.Remove(schiessarten.Length - 1, 1);
            schiessartenUpdate(schiessarten, false);

        }
        private void schiessartenUpdate(string schiessarten, bool delete)
        {
            DoConnect();
            _command = new SQLiteCommand(_con);
            _command.CommandText = CreateUpdateStatement("Verschiedenes", "SchiessArten", schiessarten);
            _dataReader = _command.ExecuteReader();
            if (!StatementSuccessful(_dataReader, delete))
            {
                writeLog("Statement war nicht erfolgreich. Statement: " + _command.CommandText.ToString() + " Methode: " + MethodBase.GetCurrentMethod().ToString());
            }
            CloseConnections();
        }

        public void SetSchFest(DateTime dt)
        {
            bool setDate = true;
            TimeSpan timeSpan = DateTime.Now - dt;

            if (timeSpan.Days > 0)
            {
                if (MessageBox.Show("Das Datum liegt in der Vergangenheit.", "Schützenfest", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.Cancel)
                {
                    setDate = false;
                }
            }

            if (setDate)
            {
                DoConnect();
                _command = new SQLiteCommand(_con);
                _command.CommandText = CreateUpdateStatement("Verschiedenes", "Schuetzenfest", dt.ToString("yyyy-MM-dd"));
                _dataReader = _command.ExecuteReader();
                //StatementSuccessful(dataReader, false);
                CloseConnections();
            }
        }

        public void DeleteErgebnis(int id)
        {
            if (PasswortAbfrage())
            {
                DialogResult result = MessageBox.Show("Ergebnis löschen?" + Environment.NewLine + "(" + Convert.ToInt16(Debugger.IsAttached) + ")", "Löschen", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DoConnect();
                    _command = new SQLiteCommand(_con);
                    _command.CommandText = CreateDeleteStatement("Ergebnisse", id);
                    _command.ExecuteNonQuery();
                    CloseConnections();
                }
            }
        }

        public bool UpdateErgebnis(DataTable dt)
        {
            if (CheckErgebnis(dt))
            {
                DoConnect();
                _command = new SQLiteCommand(_con);
                _command.CommandText = CreateUpdateStatement(
                    "Ergebnisse",
                    "Datum = '" + dt.Rows[0]["Datum"] + "', " +
                    "\"Satz 1\" = '" + dt.Rows[0]["Satz 1"] + "', " +
                    "\"Satz 2\" = '" + dt.Rows[0]["Satz 2"] + "', " +
                    "\"Satz 3\" = '" + dt.Rows[0]["Satz 3"] + "', " +
                    "\"Satz 4\" = '" + dt.Rows[0]["Satz 4"] + "', " +
                    "Art = '" + dt.Rows[0]["Art"] + "', " +
                    "Info = '" + dt.Rows[0]["Info"] + "'",
                    "rowid", dt.Rows[0]["ErgebnisID"].ToString());
                _command.ExecuteNonQuery();
                CloseConnections();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CreateErgebnis(DataTable dt)
        {
            if (CheckErgebnis(dt))
            {
                DoConnect();
                _command = new SQLiteCommand(_con);
                _command.CommandText = CreateInsertIntoStatement(
                    "Ergebnisse",
                    "NamenID, Datum, \"Satz 1\", \"Satz 2\", \"Satz 3\", \"Satz 4\", Art, Info",
                    "'" +
                    dt.Rows[0]["NamenID"] + "', '" +
                    dt.Rows[0]["Datum"] + "', '" +
                    dt.Rows[0]["Satz 1"] + "', '" +
                    dt.Rows[0]["Satz 2"] + "', '" +
                    dt.Rows[0]["Satz 3"] + "', '" +
                    dt.Rows[0]["Satz 4"] + "', '" +
                    dt.Rows[0]["Art"] + "', '" +
                    dt.Rows[0]["Info"] + "'"
                    );
                _command.ExecuteNonQuery();
                CloseConnections();
                return true;
            }
            else
            {
                return false;
            }
        }
        private Boolean CheckErgebnis(DataTable dt)
        {
            List<string> liste = new List<string>();
            liste.Add("Satz 1");
            liste.Add("Satz 2");
            liste.Add("Satz 3");
            liste.Add("Satz 4");
            string errorMessage = "";
            foreach (string satz in liste)
            {
                string test = dt.Rows[0][satz].ToString();
                if (Convert.ToDouble(dt.Rows[0][satz]) > 109 || Convert.ToDouble(dt.Rows[0][satz]) < 0)
                {
                    errorMessage += "Der Eintrage in " + satz + " macht mit dem Wert " + Convert.ToDouble(dt.Rows[0][satz]) + " keinen Sinn." +
                        Environment.NewLine;
                }
            }
            if (errorMessage != "")
            {
                errorMessage += "Es sind nur Werte zwischen 0.0 und 109 erlaubt.";
                writeLog(errorMessage);
                MessageBox.Show(errorMessage, "Fehler");
                return false;
            }
            else
            {
                return true;
            }
        }

        private List<string> getMaterialGruppen()
        {
            return _getDaten.getMaterialGruppen();
        }
        public bool SetProfilUpdate(DataTable dt)
        {
            if (PasswortAbfrage())
            {
                List<string> listMaterial = getMaterialGruppen();
                for (int i = 0; i < dt.Columns.Count - 1; i++)
                {
                    if (listMaterial.Contains(dt.Columns[i].ToString().Replace("ID", ""))
                        && dt.Columns[i].ToString().Substring(dt.Columns[i].ToString().Length - 2) == "ID"
                        && dt.Rows[0][i].ToString() == "")
                    {
                        dt.Rows[0][i] = -1;
                    }
                }
                if (CheckGeburtstag(Convert.ToDateTime(dt.Rows[0]["Geburtstag"].ToString()), MethodInfo.GetCurrentMethod().Name))
                {
                    DoConnect();
                    _command = new SQLiteCommand(_con);
                    _command.CommandText = CreateUpdateStatement(
                        "Personen",
                        "Vorname = \"" + dt.Rows[0]["Vorname"] + "\", " +
                        "Zweitname = \"" + dt.Rows[0]["Zweitname"] + "\", " +
                        "Nachname = \"" + dt.Rows[0]["Nachname"] + "\", " +
                        "Geburtstag = \"" + dt.Rows[0]["Geburtstag"] + "\", " +
                        "Geschlecht = \"" + dt.Rows[0]["Geschlecht"] + "\", " +
                        "DarfKK = \"" + dt.Rows[0]["DarfKK"] + "\", " +
                        "DarfLG = \"" + dt.Rows[0]["DarfLG"] + "\", " +
                        "IstKoenig = \"" + dt.Rows[0]["IstKoenig"] + "\", " +
                        "KleinkaliberID = \"" + dt.Rows[0]["KleinkaliberID"] + "\", " +
                        "LuftgewehrID = \"" + dt.Rows[0]["LuftgewehrID"] + "\", " +
                        "HandschuhID = \"" + dt.Rows[0]["HandschuhID"] + "\", " +
                        "JackeID = \"" + dt.Rows[0]["JackeID"] + "\", " +
                        "Info = \"" + dt.Rows[0]["Info"] + "\"",
                        "rowid",
                        dt.Rows[0]["rowid"].ToString());
                    _dataReader = _command.ExecuteReader();
                    CloseConnections();
                    if (!StatementSuccessful(_dataReader, false))
                    {
                        writeLog("Der Eintrag konnte nicht geändert werden. Methode: " + MethodBase.GetCurrentMethod().ToString());
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public bool SetProfilNeu(DataTable dt)
        {
            if (PasswortAbfrage())
            {
                if (CheckGeburtstag(Convert.ToDateTime(dt.Rows[0]["Geburtstag"].ToString()), MethodInfo.GetCurrentMethod().Name))
                {
                    DoConnect();
                    _command = new SQLiteCommand(_con);
                    _command.CommandText = CreateInsertIntoStatement(
                        "Personen",
                        "AdressID, Vorname, Zweitname, Nachname, Geburtstag, Geschlecht, DarfKK, DarfLG, KleinkaliberID, LuftgewehrID, JackeID, HandschuhID, Info, IstKoenig, IstArchiviert",
                        "'" + dt.Rows[0]["AdressID"] + "', " +
                        "'" + dt.Rows[0]["Vorname"] + "', " +
                        "'" + dt.Rows[0]["Zweitname"] + "', " +
                        "'" + dt.Rows[0]["Nachname"] + "', " +
                        "'" + dt.Rows[0]["Geburtstag"] + "', " +
                        "'" + dt.Rows[0]["Geschlecht"] + "', " +
                        "'" + dt.Rows[0]["DarfKK"] + "', " +
                        "'" + dt.Rows[0]["DarfLG"] + "', " +
                        "'" + dt.Rows[0]["KleinkaliberID"] + "', " +
                        "'" + dt.Rows[0]["LuftgewehrID"] + "', " +
                        "'" + dt.Rows[0]["JackeID"] + "', " +
                        "'" + dt.Rows[0]["HandschuhID"] + "', " +
                        "'" + dt.Rows[0]["Info"] + "', " +
                        "'" + dt.Rows[0]["IstKoenig"] + "', " +
                        "'0'"   //  IstArchiviert
                        );
                    _dataReader = _command.ExecuteReader();
                    CloseConnections();
                    if (!StatementSuccessful(_dataReader, false))
                    {
                        writeLog("Statement war nicht erfolgreich. Methode: SetProfilNeu(DataTable dt) Statement: " + _command.CommandText.ToString());
                        return false;
                    }

                    return true;
                }
            }
            return false;
        }

        private bool CheckGeburtstag(DateTime geburtstag, object sender)
        {
            TimeSpan timeSpan = DateTime.Now - geburtstag;
            if (timeSpan.Days < 0)
            {
                if (MessageBox.Show("Das Datum liegt in der Zukunft.", "Geburtstag", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {

                    return false;
                }
            }
            else
            {
                int alter = Convert.ToInt16(DateTime.Now.ToString("yyyy")) - geburtstag.Year;
                if (alter <= 5)
                {
                    if (MessageBox.Show("Das Alter ist unter 6 Jahre.", "Alter", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void SetProfilDelete(int ID)
        {
            if (PasswortAbfrage())
            {
                if (DeleteProfilRequested("Profil löschen"))
                {
                    DoConnect();
                    _command = new SQLiteCommand(_con);
                    _command.CommandText = CreateDeleteStatement("Personen", ID);
                    _dataReader = _command.ExecuteReader();
                    if (!StatementSuccessful(_dataReader, true))
                    {
                        writeLog("Statement war nicht erfolgreich. Statement: " + _command.CommandText.ToString() + "Methode: " + MethodBase.GetCurrentMethod().ToString());
                    }
                    CloseConnections();
                }
            }
        }

        private bool DeleteProfilRequested(string titelText)
        {
            DialogResult result = MessageBox.Show("Soll der Eintrag wirklich gelöscht werden?" + Environment.NewLine + "(" + Convert.ToInt16(Debugger.IsAttached) + ")", titelText, MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool StatementSuccessful(SQLiteDataReader dataReader, bool delete)
        {
            if (dataReader.RecordsAffected > 0)
            {
                if (delete)
                {
                    if (_showMsgBoxes)
                    {
                        MessageBox.Show("Löschen erfolgreich.");
                    }

                    return true;
                }
                else
                {
                    if (_showMsgBoxes)
                    {
                        MessageBox.Show("Eintrag erfolgreich.");
                    }

                    return true;
                }

            }
            else
            {
                if (delete)
                {
                    MessageBox.Show("Eintrag konnte nicht gelöscht werden.");
                    return false;
                }
                else
                {
                    MessageBox.Show("Eintrag konnte nicht erstellt werden.");
                    return false;
                }
            }
        }

        public void SetMaterialInsert(DataTable dt)
        {
            if (dt != null)
            {
                if (!dt.Rows[0]["Bezeichnung"].ToString().ToLower().Contains("n/a") && dt.Rows[0]["Bezeichnung"].ToString().ToLower().Trim() != "")
                {
                    DoConnect();
                    _command = new SQLiteCommand(_con);
                    _command.CommandText = CreateInsertIntoStatement(
                        "Material",
                        "Gruppe, Bezeichnung, Langtext, Groesse",
                        "'" + dt.Rows[0]["Gruppe"].ToString() + "', " +
                        "'" + dt.Rows[0]["Bezeichnung"].ToString() + "', " +
                        "'" + dt.Rows[0]["Langtext"].ToString() + "', " +
                        "'" + dt.Rows[0]["Groesse"].ToString() + "'");
                    _dataReader = _command.ExecuteReader();
                    if (!StatementSuccessful(_dataReader, false))
                    {
                        writeLog("Statement war nicht erfolgreich. Statement: " + _command.CommandText.ToString() + "Methode: " + MethodBase.GetCurrentMethod().ToString());
                    }
                    CloseConnections();
                }
                else
                {
                    MessageBox.Show(
                        "Die Bezeichnung ist ungültig!" + Environment.NewLine +
                        "Die darf nicht 'N/A' oder leer sein.", "Material");
                }
            }
        }
        public void SetMaterialUpdate(DataTable dt)
        {
            if (dt != null)
            {
                if (!dt.Rows[0]["Bezeichnung"].ToString().ToLower().Contains("n/a") && dt.Rows[0]["Bezeichnung"].ToString().ToLower().Trim() != "")
                {
                    DoConnect();
                    _command = new SQLiteCommand(_con);
                    _command.CommandText = CreateUpdateStatement(
                        "Material",
                        "Bezeichnung = '" + dt.Rows[0]["Bezeichnung"] + "', " +
                        "Langtext = '" + dt.Rows[0]["Langtext"] + "', " +
                        "Groesse = '" + dt.Rows[0]["Groesse"] + "'",
                        "rowid", dt.Rows[0]["rowid"].ToString());
                    _dataReader = _command.ExecuteReader();
                    if (!StatementSuccessful(_dataReader, false))
                    {
                        writeLog("Statement war nicht erfolgreich. Statement: " + _command.CommandText.ToString() + "Methode: " + MethodBase.GetCurrentMethod().ToString());
                    }
                    CloseConnections();
                }
            }
        }
        public void SetMaterialDelete(int id)
        {
            if (PasswortAbfrage())
            {
                if (DeleteProfilRequested("Material löschen"))
                {
                    if (id > 8)
                    {
                        DoConnect();
                        _command = new SQLiteCommand(_con);
                        _command.CommandText = CreateDeleteStatement("Material", id);
                        _dataReader = _command.ExecuteReader();
                        if (!StatementSuccessful(_dataReader, true))
                        {
                            writeLog("Statement war nicht erfolgreich. Statement: " + _command.CommandText.ToString() + " Methode: " + MethodBase.GetCurrentMethod().ToString());
                        }
                        CloseConnections();
                    }
                    else
                    {
                        writeLog("Es wurde versucht einen festen Material-Eintrag zu löschen. Statement: " + _command.CommandText.ToString() + " Methode: " + MethodBase.GetCurrentMethod().ToString());
                        MessageBox.Show("Dieser Eintrag darf nicht gelöscht werden!", "Material");
                    }
                }
            }
        }
        /// <summary>
        /// Update Statement
        /// </summary>
        /// <param name="dbTable"></param>
        /// <param name="dbColumn"></param>
        /// <param name="dbValue"></param>
        /// <returns></returns>
        private string CreateUpdateStatement(string dbTable, string dbColumn, string dbValue)
        {
            return "UPDATE " + dbTable + " SET " + dbColumn + " = '" + dbValue + "'";
        }
        /// <summary>
        /// Update Statement Einzelwert
        /// </summary>
        /// <param name="dbtable"></param>
        /// <param name="dbColumnAndValues"></param>
        /// <param name="dbWhere"></param>
        /// <param name="dbValue"></param>
        /// <returns></returns>
        private string CreateUpdateStatement(string dbtable, string dbColumnAndValues, string dbWhere, string dbValue)
        {
            return "UPDATE " + dbtable + " SET " + dbColumnAndValues + " WHERE " + dbWhere + " = " + dbValue;
        }
        /// <summary>
        /// Insert Into Statement viele Werte
        /// </summary>
        /// <param name="dbTable"></param>
        /// <param name="dbColumns"></param>
        /// <param name="dbValues"></param>
        /// <returns></returns>
        private string CreateInsertIntoStatement(string dbTable, string dbColumns, string dbValues)
        {
            return "INSERT INTO " + dbTable + "( " + dbColumns + " ) VALUES " + "( " + dbValues + " )";
        }
        /// <summary>
        /// Delete Statement
        /// </summary>
        /// <param name="dbTable">as string</param>
        /// <param name="dbRowid">as int</param>
        /// <returns></returns>
        private string CreateDeleteStatement(string dbTable, int dbRowid)
        {
            if (dbTable.ToLower() == "personen" || dbTable.ToLower() == "ergebnisse")
            {
                return "UPDATE " + dbTable + " SET IstArchiviert = 1 WHERE " + "rowid = " + dbRowid;
            }
            else
            {
                return "DELETE FROM " + dbTable + " WHERE rowid = " + dbRowid;
            }
        }
    }
}
