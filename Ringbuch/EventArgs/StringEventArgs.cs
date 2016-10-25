using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ringbuch
{
    public class StringEventArgs
    {
        private string _value;

        public StringEventArgs(string value)
        {
            _value = value;
        }
        public string value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
