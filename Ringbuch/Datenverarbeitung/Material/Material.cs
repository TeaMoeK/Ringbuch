using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ringbuch
{
  class Material
  {
    private string gruppe, bezeichnung, langtext, groesse;
    private int id;

    public Material(int id, string gruppe, string bezeichnung, string langtext, string groesse)
    {
      this.id = id;
      this.gruppe = gruppe;
      this.bezeichnung = bezeichnung;
      this.langtext = langtext;
      this.groesse = groesse;
    }
    public Material(List<string> listeMitMaterial)
    {
    }
    public int ID
    {
      get
      {
        return id;
      }

      set
      {
        id = value;
      }
    }

    public string Bezeichnung
    {
      get
      {
        return bezeichnung;
      }

      set
      {
        bezeichnung = value;
      }
    }

    public string Groesse
    {
      get
      {
        return groesse;
      }

      set
      {
        groesse = value;
      }
    }

    public string Gruppe
    {
      get
      {
        return gruppe;
      }

      set
      {
        gruppe = value;
      }
    }



    public string Langtext
    {
      get
      {
        return langtext;
      }

      set
      {
        langtext = value;
      }
    }
  }
}
