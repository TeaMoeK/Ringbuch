﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Globalization;

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
        _conSource.ConnectionString = @"Data Source=" + sqliteDatabase;
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
        _conTarget.ConnectionString = @"Data Source=" + sqliteDatabase;
        _conTarget.SetPassword("");
        _conTarget.Open();
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
      Console.WriteLine("Starte den Kopiervorgang...");
      Ergebnisse_uebertragen();
      Personen_uebertragen();
      Material_uebertragen();
      Verschiedenes_uebertragen();
      Adressen_uebertragen();

      Console.WriteLine("Der Vorgang wurde abgeschlossen...");
      Console.ReadKey();
    }

    private void Ergebnisse_uebertragen()
    {
      Console.WriteLine("Ergebnisse ewrden übertragen...");
      DoConnectSource();
      DataTable dt = CreateDataTable("Ergebnisse");
      _dataReaderSource = CreateSelect("Ergebnisse");

      //int i = 1;
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
      int currentRow = 0;
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
              insert += "1,";
              string infotext = string.Empty;
              if (row[z + 1].ToString().Length != 0)
              {
                infotext = " Infotext: " + row[z + 1].ToString();
              }
              insert += "'SchnittstellenInfo: Schiessart konnte nicht erkannt werden: " + row[z].ToString() + ". Es wurde Freihand als Default-Wert eingetragen!" + infotext + "',";
              z++;
            }
          }
          else if (z == 1)
          {
            insert += "'" + Date(dt.Rows[currentRow][z].ToString()) + "',";
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
        currentRow++;
      }
      Console.WriteLine("Ergebnisse übertragen abgeschlossen.");
    }

    private void Personen_uebertragen()
    {
      Console.WriteLine("Personen werden übertragen...");
      DoConnectSource();
      DataTable dt = CreateDataTable("Personen");
      _dataReaderSource = CreateSelect("Personen");

      while (_dataReaderSource.Read())
      {
        dt.Rows.Add(new object[]{
                    _dataReaderSource.GetValue(0),    //  AdressID
                    _dataReaderSource.GetValue(1),    //  Vorname
                    _dataReaderSource.GetValue(2),    //  Zweitname
                    _dataReaderSource.GetValue(3),    //  Nachname
                    _dataReaderSource.GetValue(4),    //  Geburtstag
                    _dataReaderSource.GetValue(5),    //  Geschlecht
                    _dataReaderSource.GetValue(6),    //  DarfKK
                    _dataReaderSource.GetValue(7),    //  DarfLG                  
                    _dataReaderSource.GetValue(8),    //  KleinkaliberID
                    _dataReaderSource.GetValue(9),    //  LuftgewehrID
                    _dataReaderSource.GetValue(10),   //  handschuhID
                    _dataReaderSource.GetValue(11),   //  JackeID
                    _dataReaderSource.GetValue(12),   //  Info
                    _dataReaderSource.GetValue(13),   //  IstKoenig
                    _dataReaderSource.GetValue(14)    //  IstArchiviert
                });
      }

      string insert = string.Empty;
      int currentRow = 0;
      foreach (DataRow row in dt.Rows)
      {
        for (int z = 0; z < row.ItemArray.Count(); z++)
        {
          {
            if (row[z].ToString().Length == 0)
            {
              insert += "' ',";
            }
            else
            {
              if (row[z].ToString().ToLower() == "true")
              {
                insert += "1,";
              }
              else if (row[z].ToString().ToLower() == "false")
              {
                insert += "0,";
              }
              else if (z == 4)
              {
                insert += "'" + Date(dt.Rows[currentRow][z].ToString()) + "',";
              }
              else
              {
                insert += "'" + row[z].ToString() + "',";
              }

            }

          }
        }
        insert += "'-1'";
        CreateInsert("Personen", insert);
        Console.WriteLine(insert);
        insert = string.Empty;
        currentRow++;
      }
      Console.WriteLine("Personen übertragen abgeschlossen.");
    }
    private void Material_uebertragen()
    {
      Console.WriteLine("Material wird übertragen...");
      DoConnectSource();
      DataTable dt = CreateDataTable("Material");
      _dataReaderSource = CreateSelect("Material");

      while (_dataReaderSource.Read())
      {
        dt.Rows.Add(new object[]{
                    _dataReaderSource.GetValue(0),    //  Gruppe
                    _dataReaderSource.GetValue(1),    //  Bezeichnung
                    _dataReaderSource.GetValue(2),    //  Langtext
                    _dataReaderSource.GetValue(3)     //  Groesse

                });
      }

      string insert = string.Empty;
      foreach (DataRow row in dt.Rows)
      {
        for (int z = 0; z < row.ItemArray.Count(); z++)
        {
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
        if (insert[insert.Length - 1] == ',')
        {
          insert = insert.Remove(insert.Length - 1);
        }
        CreateInsert("Material", insert);
        Console.WriteLine(insert);
        insert = string.Empty;
      }
      Console.WriteLine("Material wurde übertragen.");
    }

    private void Verschiedenes_uebertragen()
    {
      Console.WriteLine("Verschiedenes wird übertragen...");
      DoConnectSource();
      DataTable dt = CreateDataTable("Verschiedenes");
      _dataReaderSource = CreateSelect("Verschiedenes");

      while (_dataReaderSource.Read())
      {
        dt.Rows.Add(new object[]{
                    _dataReaderSource.GetValue(0),    //  Schuetzenfest (Datum)
                    _dataReaderSource.GetValue(1),    //  SchiessArten
                    _dataReaderSource.GetValue(2)     //  Password
                });
      }

      string insert = string.Empty;
      dt.Rows[0][0] = Date(dt.Rows[0][0].ToString());
      foreach (DataRow row in dt.Rows)
      {
        insert = "'" + row[0].ToString() + "','" + row[2].ToString() + "'";
        CreateInsert("Verschiedenes", insert);
        Console.WriteLine(insert);
        insert = row[1].ToString();
        string[] liste = insert.Split(',');
        foreach (string schiessArt in liste)
        {
          insert = "'" + schiessArt + "', 0";
          CreateInsert("SchiessArten", insert);
          Console.WriteLine(insert);
        }
      }
      Console.WriteLine("Verschiedenes wurde übertragen.");
    }
    private void Adressen_uebertragen()
    {
      Console.WriteLine("Adressen werden übertragen...");
      DoConnectSource();
      DataTable dt = CreateDataTable("Adressen");
      _dataReaderSource = CreateSelect("Adressen");

      while (_dataReaderSource.Read())
      {
        dt.Rows.Add(new object[]{
                    _dataReaderSource.GetValue(0),    //  Strasse
                    _dataReaderSource.GetValue(1),    //  Stadt
                    _dataReaderSource.GetValue(2),    //  Land
                    _dataReaderSource.GetValue(3)     //  PLZ

                });
      }

      string insert = string.Empty;
      foreach (DataRow row in dt.Rows)
      {
        insert = "'" + row[0].ToString() + "','" + row[1].ToString() + "', '" + row[2].ToString() + "','" + row[3].ToString() + "'";
        CreateInsert("Adressen", insert);
        Console.WriteLine(insert);
      }
      Console.WriteLine("Adressen wurden übertragen.");
    }
    private string Date(string dateString)
    {
      DateTime dt = DateTime.Parse(dateString);
      return dt.ToString("yyyy-MM-dd HH:mm:ss");
    }
    //  Datum muss geparsed werden und das Format 'jjjj-mm-dd HH:mm:ss'
    private void CreateInsert(string tabelle, string values)
    {
      DoConnectTarget();
      _commandTarget.CommandText = "INSERT INTO " + tabelle + " VALUES (" + values + ")";
      _dataReaderTarget = _commandTarget.ExecuteReader();

    }
    private SQLiteDataReader CreateSelect(string tabelle)
    {
      _commandSource.CommandText = "SELECT * FROM " + tabelle;
      SQLiteDataReader r = _commandSource.ExecuteReader();
      return r;
      //return _commandSource.ExecuteReader();
    }
    enum SchiessArten
    {
      Freihand = 1, Auflage = 2, Liegend = 3, Sitzend = 4, Knieeden = 5
    }

    public DataTable CreateDataTable(string dbTableName)
    {
      DataTable dt = new DataTable();
      _commandSource = new SQLiteCommand(_conSource);
      _commandSource.CommandText = "PRAGMA table_info(" + dbTableName + ")";
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
