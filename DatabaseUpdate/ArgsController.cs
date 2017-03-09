using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseUpdate
{
  internal static class ArgsController
  {
    private static string[] _args;

    internal static void Start()
    {
      _args = Environment.GetCommandLineArgs();

      if (_args.Length == 0)
      {
        Console.WriteLine("Keine Argumente gefunden. Bitte den '-sfile' und '-tfile' angeben./n Taste drücken...");
        Console.ReadKey();
      }
      else
      {
        if (Read_Args())
        {
          if (!Check_Params())
          {
            Console.WriteLine("Beim Prüfen der Parameter ist ein Fehler aufgetreten./n Taste drücken...");
            Console.ReadKey();
          }
          else
          {
            Start_Copy();
          }
        }
        else
        {
          Console.WriteLine("Die Argumente konnten nicht ausgewertet werden./n Taste drücken...");
          Console.ReadKey();
        }
      }
    }
    private static bool Read_Args()
    {
      Console.WriteLine("Lese die Argumente ein...");
      for (int i = 0; i < _args.Length; i++)
      {
        switch (_args[i].ToLower())
        {

          case ArgsData.PARAM_SFILE:
            if (i != _args.Length - 1)
            {
              ArgsData.SourceFile = _args[++i];
            }
            break;

          case ArgsData.PARAM_TFILE:
            if (i != _args.Length - 1)
            {
              ArgsData.TargetFile = _args[++i];
            }
            break;
        }
      }
      if (ArgsData.TargetFile == string.Empty || ArgsData.SourceFile == string.Empty || ArgsData.TargetFile == null || ArgsData.SourceFile == null)
      {
        Console.WriteLine("Die Parameter -tfile & -sfile dürfen nicht leer sein! Hinweis: Pfade bitte immer OHNE abschliessenden Backslash ('\\') eingeben.");
        return false;
      }
      return true;
    }
    private static bool Check_Params()
    {
      Console.WriteLine("Die eingegebenen Parameter werden überprüft...");
      bool state = true;
      if (!File.Exists(ArgsData.SourceFile))
      {
        Console.WriteLine("Die Datei' " + ArgsData.SourceFile + " 'konnte nicht gefunden werden.");
        state = false;
      }
      if (!File.Exists(ArgsData.TargetFile))
      {
        Console.WriteLine("Die Datei' " + ArgsData.TargetFile + " 'konnte nicht gefunden werden.");
        state = false;
      }
      if (state)
      {
        Console.WriteLine("Parameter sind OK.");
      }

      return state;
    }
    private static void Start_Copy()
    {
      Copy copy = new Copy();
      copy.Copy_Start();
    }
  }
}
