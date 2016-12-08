namespace Ringbuch
{
    public class IDEventArgs
    {
        private int _NamenID;
        private int _KKID;
        private int _LGID;
        private int _HandschuhID;
        private int _JackeID;
        private int _ergebnisID;
        private int _materialID;
        /// <summary>
        /// IDEventArgs
        /// </summary>
        /// <param name="ID">Die zu übergebende ID</param>
        /// <param name="IDTyp">Um Welche ID handelt es sich? name, kk, lg, handschuh, jacke, ergebnis</param>
        public IDEventArgs(int ID, string IDTyp)
        {
            switch (IDTyp.ToLower())
            {
                case "name":
                    _NamenID = ID;
                    break;
                case "kk":
                    _KKID = ID;
                    break;
                case "lg":
                    _LGID = ID;
                    break;
                case "handschuh":
                    _HandschuhID = ID;
                    break;
                case "jacke":
                    _JackeID = ID;
                    break;
                case "ergebnis":
                    _ergebnisID = ID;
                    break;
                case "material":
                    _materialID = ID;
                    break;
            }
        }
        public IDEventArgs(int namenID, int ergebnisID)
        {
            _NamenID = namenID;
            _ergebnisID = ergebnisID;
        }

        public int NamenID
        {
            get { return _NamenID; }
        }
        public int KKID
        {
            get { return _KKID; }
        }
        public int LGID
        {
            get { return _LGID; }
        }
        public int HandschuhID
        {
            get { return _HandschuhID; }
        }
        public int JackeID
        {
            get { return _JackeID; }
        }
        public int ErgebnisID
        {
            get { return _ergebnisID; }
        }
        public int MaterialID
        {
            get { return _materialID; }
        }
    }
}
