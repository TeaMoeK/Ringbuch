using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace Ringbuch.Datenverarbeitung
{
  class NewDatabase
  {

    internal string _pfad = string.Empty;
    public NewDatabase(string pfad)
    {
      _pfad = pfad;
    }
    private void createFile()
    {
      SQLiteConnection.CreateFile("RingBuchNeu.db");
      SQLiteConnection con = new SQLiteConnection("Data Source=RingBuchNeu.db;Version=3;");
      con.Open();

      string tableAdressen = "CREATE TABLE 'Adressen'('Strasse' VARCHAR NOT NULL, 'Stadt' VARCHAR NOT NULL, 'Land' VARCHAR NOT NULL, 'PLZ' INTEGER NOT NULL);";
      string tableErgebnisse = "CREATE TABLE 'Ergebnisse'(    [NamenID] int NOT NULL,     [Datum]    DATE NOT NULL,     [Satz1] NVARCHAR(18) NOT NULL,    [Satz2] NVARCHAR(18),     [Satz3] NVARCHAR(18),     [Satz4] NVARCHAR(18),     [SchiessArtenID]    INTEGER NOT NULL,     [Info] nvarchar(128), 'IstArchiviert' BOOL NOT NULL DEFAULT 0);";
      string tableMaterial = "CREATE TABLE[Material](    [Gruppe] char(32) NOT NULL,    [Bezeichnung] char(32),    [Langtext] char(32),    [Groesse] char(32));";
      string tablePersonen = "CREATE TABLE[Personen](    [AdressID] INT NOT NULL DEFAULT (-1),    [Vorname] char(24) NOT NULL,    [Zweitname] char(24),    [Nachname] char(24) NOT NULL,    [Geburtstag] date NOT NULL DEFAULT(1900 - 01 - 01),    [Geschlecht] char(1) NOT NULL DEFAULT x,    [DarfKK] BOOLEAN DEFAULT 0,    [DarfLG] boolean DEFAULT 0,    [KleinkaliberID] int,    [LuftgewehrID] int,    [HandschuhID] int,    [JackeID] int,    [Info] VARCHAR(1024),    [IstKoenig] BOOLEAN DEFAULT 0,    [IstArchiviert] BOOLEAN,    [PistoleID] INT DEFAULT(-1));";
      string tableSchiessArten = "CREATE TABLE `SchiessArten` (       SchiessArt VARCHAR(50) NOT NULL,       IstArchiviert INTEGER NOT NULL DEFAULT '0'        );";
      string tableSchiessKlassen = "CREATE TABLE `SchiessKlassen`    (           KlassenName VARCHAR(50) NOT NULL,           SchiessArtenID INTEGER NOT NULL DEFAULT '-1',           AnzahlSchuss INTEGER,           JahrgangVon INTEGER,           JahrgangBis INTEGER,           AlterVon INTEGER,           AlterBis INTEGER,           IstArchiviert INTEGER NOT NULL DEFAULT '0'    , Geschlecht char(1));";
      string tableVerschiedenes = "CREATE TABLE[Verschiedenes](    [Schuetzenfest] date NOT NULL,     [Password]    Text);";

      List<String> tabellen = new List<string>();
      tabellen.Add(tableAdressen);
      tabellen.Add(tableErgebnisse);
      tabellen.Add(tableMaterial);
      tabellen.Add(tablePersonen);
      tabellen.Add(tableSchiessArten);
      tabellen.Add(tableSchiessKlassen);
      tabellen.Add(tableVerschiedenes);

      foreach (string statement in tabellen)
      {
        SQLiteCommand command = new SQLiteCommand(statement, con);
        command.ExecuteNonQuery();
        
      }
    }
  }
}
