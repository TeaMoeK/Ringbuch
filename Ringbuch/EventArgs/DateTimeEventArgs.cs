using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ringbuch
{
    public class DateTimeEventArgs
    {
        private DateTime _dt;

        public DateTimeEventArgs(DateTime dt)
        {
            _dt = dt;
        }
        public DateTime dt
        {
            get { return _dt; }
            set { _dt = value; }
        }
    }
}
