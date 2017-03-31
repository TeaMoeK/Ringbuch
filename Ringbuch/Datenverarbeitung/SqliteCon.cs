using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Logging_APE;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Ringbuch
{
  public static class SqliteCon
  {
    private static SQLiteConnection _con = null;
    private static String _sqliteDatabase = string.Empty;

    public static SQLiteConnection Con
    {
      get
      {
        if (_con == null)
        {
          DoConnect();
        }
        return _con;
      }
    }

    private static void DoConnect()
    {
      getDatabasePathXML();
      if (Environment.GetCommandLineArgs().Length > 1)
      {
        //  Do Nothing
      }
      try
      {
        _con = new SQLiteConnection();
        _con.ConnectionString = "Data Source=" + _sqliteDatabase;
        _con.Open();
      }
      catch (Exception ex)
      {
        writeLog("SQL-Verbindung ist fehlgeschlagen. Exception: " + ex.Message + " Methode: " + MethodBase.GetCurrentMethod().ToString());
        MessageBox.Show(ex.Message);
        _con = null;
        Environment.Exit(-1);
      }
    }
    private static void getDatabasePathXML()
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
        getDatabasePathXML();
      }
    }
    private static void writeLog(string logText)
    {
      Log.Instance.FILENAME_SUFFIX = "Ringbuch";
      Log.Instance.Write(logText, typeof(Program).ToString());
    }
    private static void createXMLFile()
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


        XmlDocument doc = new XmlDocument();
        XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        doc.AppendChild(docNode);
        //  Element 'Datenbank' erstellen und dem XmlDocument hinzufügen
        XmlNode DatenbankNode = doc.CreateElement("Datenbank");
        doc.AppendChild(DatenbankNode);
        //  Element 'Pfad' erstellen, mit dem Pfad füllen und als 'Unterknoten' dem Node 'Datenbank' hinzufügen
        if (openFileDialog.FileName.Length > 0)
        {
          XmlNode PfadNode = doc.CreateElement("Pfad");
          PfadNode.AppendChild(doc.CreateTextNode(openFileDialog.FileName));
          DatenbankNode.AppendChild(PfadNode);
        }
        else
        {
          //  Neue, leere Datenbank erzeugen
        }
        //  Element 'Password' erstellen, mit dem Passwort füllen und als 'Unterknoten' dem Node 'Datenbank' hinzufügen
        MyDialog myDialog = new MyDialog(true, "Password", "Bitte ein Admin-Password eingeben.", true);
        myDialog.ShowDialog();

        XmlNode PasswordNode = doc.CreateElement("Password");
        PasswordNode.AppendChild(doc.CreateTextNode(myDialog.codedText));
        DatenbankNode.AppendChild(PasswordNode);
        string adminPW = myDialog.codedText;
        //  Element 'DatenbankPassword' erstellen, mit dem Passwort füllen und als 'Unterknoten' dem Node 'Datenbank' hinzufügen
        //myDialog = null;
        //myDialog = new MyDialog(true, "Datenbank-Password", "Bitte ein datenbank-Password eingeben.", true);
        //myDialog.ShowDialog();

        //XmlNode DBPasswordNode = doc.CreateElement("DatenbankPassword");
        //DBPasswordNode.AppendChild(doc.CreateTextNode(myDialog.codedText));
        //DatenbankNode.AppendChild(DBPasswordNode);
        //string DatenbankPW = myDialog.codedText;
        //  Xml-Datei speichern
        doc.Save("Ringbuch.xml");
        SetDaten setDaten = new SetDaten();

        setDaten.SetAdminPasswordToDatabase(adminPW);
        //setDaten.SetDatenbankPassword(DatenbankPW);

        _sqliteDatabase = openFileDialog.FileName;
        writeLog("Es wurde eine neue XML-Datei angelegt. Pfad: " + openFileDialog.FileName.ToString() + " Methode: " + MethodBase.GetCurrentMethod().ToString());
      }
      else
      {
        writeLog("Benutzer hat das Anlegen der XML-Datei abgebrochen. DialogResult: " + result.ToString() + " Methode: " + MethodBase.GetCurrentMethod().ToString());
        Environment.Exit(1);
      }
    }
  }
}
