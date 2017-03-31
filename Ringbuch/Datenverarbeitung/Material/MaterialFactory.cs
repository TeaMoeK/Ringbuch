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
    public void getMaterial(String Typ, int id)
    {
      _con = SqliteCon.Con;
      SQLiteCommand com = new SQLiteCommand(_con);
      com.CommandText = "SELECT rowid, * FROM Material WHERE Bezeichnung NOT LIKE 'ignore'";
      SQLiteDataReader dr;
      dr = com.ExecuteReader();

      List<Material> material = new List<Material>();

      //material.Add(new Material(-1, "gruppe", "bez","lang","gr"));
      NameValueCollection test = dr.GetValues();
      string[] namen = test.AllKeys;
      while (dr.Read())
      {

        material.Add(new Material(Convert.ToInt32(dr.GetValue(0)), dr.GetValue(1).ToString(), dr.GetValue(2).ToString(), dr.GetValue(3).ToString(), dr.GetValue(4).ToString()));
      }

    }
  }
}
