using System.Collections.Generic;

namespace Ringbuch
{
    public class IntListeEventArgs
    {
        private List<int> _IntListe;

        public IntListeEventArgs(List<int> IntListe)
        {
            _IntListe = IntListe;
        }
        public List<int> IntListe
        {
            get { return _IntListe; }
        }
    }
}
