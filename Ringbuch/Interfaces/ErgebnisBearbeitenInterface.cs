using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ringbuch
{
    public interface ErgebnisBearbeitenInterface
    {
        event EventHandler<IDEventArgs> ErgebnisBearbeitenRequest;
        void SetErgebnis(List<String> ergebnis);

        event EventHandler<IDEventArgs> NameRequest;
        void SetName(List<String> name);

        event EventHandler ArtRequest;
        void SetSchiessArten(List<string> liste);

        event EventHandler<DataTableEventArgs> ErgebnisCreateRequired;
        void CreateOrUpdateConfirm(Boolean confirmed);

        event EventHandler<StringEventArgs> SchiessartCreateRequired;
        event EventHandler<StringEventArgs> SchiessartDeleteRequested;

        event EventHandler<DataTableEventArgs> ErgebnisUpdateRequired;
        event EventHandler<IDEventArgs> ErgebnisDeleteRequested;
    }
}
