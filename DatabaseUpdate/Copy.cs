using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace DatabaseUpdate
{
  internal class Copy
  {
    private string _sqlSourceDatabase = string.Empty;
    private string _sqlTargetDatabase = string.Empty;

    private SQLiteConnection _conSource;
    private SQLiteCommand _commandSource;
    private SQLiteDataReader _dataReaderSource;

    private SQLiteConnection _conTarget;
    private SQLiteCommand _commandTarget;
    private SQLiteDataReader _dataReaderTarget;
    public void Copy_Start()
    {
      getDatabasePath();
      Data_Exchange();
    }
    private void DoConnectSource()
    {
      string sqliteDatabase = _sqlSourceDatabase;
      try
      {
        _conSource = new SQLiteConnection();
        _conSource.ConnectionString = "Data Source=" + sqliteDatabase;
        _conSource.SetPassword("");
        _conSource.Open();
        _commandSource = new SQLiteCommand(_conSource);
        _commandSource.CommandText = "";
        _commandSource.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        Console.WriteLine("Fehler beim Herstellen der Verbindung mit '" + sqliteDatabase + "'/nExeption: " + ex.Message + "/nTaste drücken...");
        Console.ReadKey();
        Environment.Exit(-1);
      }
    }

    private void DoConnectTarget()
    {
      string sqliteDatabase = _sqlTargetDatabase;
      try
      {
        _conTarget = new SQLiteConnection();
        _conTarget.ConnectionString = "Data Target=" + sqliteDatabase;
        _conTarget.SetPassword("");
        //_conTarget.Open();
        _commandTarget = new SQLiteCommand(_conTarget);
        _commandTarget.CommandText = "";
        _commandTarget.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        Console.WriteLine("Fehler beim Herstellen der Verbindung mit '" + sqliteDatabase + "'/nExeption: " + ex.Message + "/nTaste drücken...");
        Console.ReadKey();
        Environment.Exit(-1);
      }
    }
    private void getDatabasePath()
    {
      _sqlSourceDatabase = ArgsData.SourceFile;
      _sqlTargetDatabase = ArgsData.TargetFile;
    }
    private void Data_Exchange()
    {
      Ergebnisse_uebertragen();
    }
    private void Ergebnisse_uebertragen()
    {
      DoConnectSource();
      DataTable dt = CreateDataTable("Ergebnisse");
      _dataReaderSource = CreateSelect("Ergebnisse");

      int i = 1;
      while (_dataReaderSource.Read())
      {
        dt.Rows.Add(new object[]{
                    _dataReaderSource.GetValue(0),    //  NamenID
                    _dataReaderSource.GetValue(1),    //  Datum
                    _dataReaderSource.GetValue(2),    //  Satz1
                    _dataReaderSource.GetValue(3),    //  Satz2
                    _dataReaderSource.GetValue(4),    //  Satz3
                    _dataReaderSource.GetValue(5),    //  Satz4
                    _dataReaderSource.GetValue(6),    //  SchiessArt
                    _dataReaderSource.GetValue(7),    //  Info                    
                    _dataReaderSource.GetValue(8),    //  IstArchiviert
                });
      }

      string insert = string.Empty;
      foreach (DataRow row in dt.Rows)
      {
        for (int z = 0; z < row.ItemArray.Count(); z++)
        {
          if (z == row.ItemArray.Count() - 1)
          {
            if (row[z].ToString().ToLower() == "true")
            {
              insert += "1";
            }
            else
            {
              insert += "0";
            }
          }
          else if (z == 6)
          {
            Array EnumValues = Enum.GetValues(typeof(SchiessArten));
            bool artGefunden = false;

            foreach (SchiessArten art in EnumValues)
            {
              if (art.ToString().ToLower() == row[z].ToString().ToLower())
              {
                insert += "'" + Convert.ToString((int)art) + "',";
                artGefunden = true;
              }
            }
            if (!artGefunden)
            {
              insert += "1";
              string infotext = string.Empty;
              if (row[z + 1].ToString().Length != 0)
              {
                infotext = " Infotext: " + row[z + 1].ToString();
              }
              insert += "'SchnittstellenInfo: Schiessart konnte nicht erkannt werden: " + row[z].ToString() + ". Es wurde 'Freihand' als Default-Wert eingetragen!" + infotext;
              z++;
            }
          }
          else
          {
            if (row[z].ToString().Length == 0)
            {
              insert += "' ',";
            }
            else
            {
              insert += "'" + row[z].ToString() + "',";
            }

          }
        }
        CreateInsert("Ergebnisse", insert);
        Console.WriteLine(insert);
        insert = string.Empty;
      }
      Console.ReadKey();
    }

    private void CreateInsert(string tabelle, string values)
    {
      DoConnectTarget();
      _commandTarget.CommandText = "INSERT INTO " + tabelle + " VALUES (" + values + ")";
      _dataReaderTarget = _commandTarget.ExecuteReader();

    }
    private SQLiteDataReader CreateSelect(string tabelle)
    {
      _commandSource.CommandText = "SELECT * FROM " + tabelle;

      return _commandSource.ExecuteReader();
    }
    enum SchiessArten
    {
      Freihand = 1, Auflage = 2, Liegend = 3, Sitzend = 4, Knieeden = 5, Test = 6
    }

    public DataTable CreateDataTable(string dbTableName)
    {
      //DoConnect(true);
      DataTable dt = new DataTable();
      _commandSource = new SQLiteCommand(_conSource);
      _commandSource.CommandText = "PRAGMA table_info(" + dbTableName + ")";
      //SQLiteDataAdapter adapter = new SQLiteDataAdapter(_command);
      _dataReaderSource = _commandSource.ExecuteReader();
      int i = 0;

      while (_dataReaderSource.Read())
      {
        dt.Columns.Add(_dataReaderSource.GetValue(1).ToString());
        i++;
      }
      CloseConections();
      return dt;
    }
    private void CloseConections()
    {
      if (_dataReaderSource != null)
      {
        _dataReaderSource.Close();
      }
    }
  }
}
