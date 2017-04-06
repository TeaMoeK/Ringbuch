using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ringbuch
{
  class MaterialFactory
  {
    private SQLiteConnection _con;
    /// <summary>
    /// Liefert eine Liste alle Materialen zurück
    /// </summary>
    /// <returns></returns>
    public List<Material> getMaterial()
    {
      return getMaterial(string.Empty, -1);
    }
    /// <summary>
    /// Liefert das Material mit der angegebnen ID zurück
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<Material> getMaterial(int id)
    {
      return getMaterial(string.Empty, id);
    }
    /// <summary>
    /// Liefert eine Liste mit Material des angegebenen Typs zurück
    /// </summary>
    /// <param name="Gruppe"></param>
    /// <returns></returns>
    public List<Material> getMaterial(string Gruppe)
    {
      return getMaterial(Gruppe, -1);
    }

    private List<Material> getMaterial(String Gruppe, int id)
    {
      SQLiteDataReader dr = DoConnect(Gruppe, id);

      List<Material> material = new List<Material>();
      List<string> matListe = new List<string>();
      NameValueCollection nvcColumnNames = dr.GetValues();
      string[] arrayColumnNames = nvcColumnNames.AllKeys;
      while (dr.Read())
      {
        for (int i = 0; i < dr.FieldCount; i++)
        {
          matListe.Add(dr.GetValue(i).ToString());
        }
        material.Add(new Material(Convert.ToInt32(dr.GetValue(0)), dr.GetValue(1).ToString(), dr.GetValue(2).ToString(), dr.GetValue(3).ToString(), dr.GetValue(4).ToString()));
      }
      return material;
    }

    private SQLiteDataReader DoConnect(String Gruppe, int id)
    {

      _con = SqliteCon.Con;
      SQLiteCommand com = new SQLiteCommand(_con);
      string commandText = string.Empty;
      if (id == -1 && Gruppe.Equals(string.Empty))
      {
        //TODO: Alles suchen
        commandText = "SELECT rowid, * FROM Material WHERE Bezeichnung NOT LIKE 'ignore'";
      }
      else if (id != -1 && Gruppe.Equals(string.Empty))
      {
        //TODO: Nach ID suchen
        commandText = "SELECT rowid, * FROM Material WHERE Bezeichnung NOT LIKE 'ignore' AND rowid = " + id.ToString();
      }
      else if (id == -1 && !Gruppe.Equals(string.Empty))
      {
        //TODO: Nach Typ suchen
        commandText = "SELECT rowid, *FROM Material WHERE Bezeichnung NOT LIKE 'ignore' AND Gruppe = " + Gruppe;
      }
      com.CommandText = commandText;
      SQLiteDataReader dr = com.ExecuteReader();
      return dr;
    }

    enum columns
    {
      rowid,
      Gruppe,
      Bezeichnung,
      Langtext,
      Groesse
    }
  }
}
