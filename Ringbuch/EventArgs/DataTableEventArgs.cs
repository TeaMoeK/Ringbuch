using System.Data;

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
