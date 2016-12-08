using System;

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
