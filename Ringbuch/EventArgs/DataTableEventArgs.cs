using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Ringbuch
{
    public class DataTableEventArgs
    {
        private DataTable _dt;

        public DataTableEventArgs(DataTable dt)
        {
            _dt = dt;
        }

        public DataTable dt
        {
            get { return _dt; }
        }
    }
}
