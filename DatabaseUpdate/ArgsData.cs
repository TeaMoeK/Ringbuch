using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseUpdate
{
  internal static class ArgsData
  {
    private static string _sfile = string.Empty;
    private static string _tfile = string.Empty;

    public const string PARAM_SFILE = "-sfile";
    public const string PARAM_TFILE = "-tfile";

    public static string SourceFile
    {
      get
      {
        return _sfile;
      }

      set
      {
        _sfile = value;
      }
    }

    public static string TargetFile
    {
      get
      {
        return _tfile;
      }

      set
      {
        _tfile = value;
      }
    }
  }
}
