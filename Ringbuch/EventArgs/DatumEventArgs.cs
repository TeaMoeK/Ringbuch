namespace Ringbuch
{
    public class DatumEventArgs
    {
        private string _Datum;

        public DatumEventArgs(string Datum)
        {
            _Datum = Datum;
        }
        public string Datum
        {
            get { return _Datum; }
            set { _Datum = value; }
        }
    }
}
