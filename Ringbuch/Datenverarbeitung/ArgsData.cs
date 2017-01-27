using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ringbuch
{
    internal static class ArgsData
    {
        private static string _aes_key = "TimoistDerCoolsteDerCoolenDigger";  //32
        private static string _aes_iv = "EineKetteVonkeys";   //16
        private static string _cleardbpw;

        public const string PARAM_CLEAR_DB_PW = "-cleardbpw";
        internal static string Aes_key
        {
            get
            {
                return _aes_key;
            }
        }

        internal static string Aes_iv
        {
            get
            {
                return _aes_iv;
            }
        }
        internal static string ClearDBPW
        {
            get
            {
                return _cleardbpw;
            }
            set
            {
                _cleardbpw = value;
            }
        }
    }
}
