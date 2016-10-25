using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ringbuch
{
    public interface StatistikToolInterface
    {
        event EventHandler<IDEventArgs> ErgebnisseRequested;
        /// <summary>
        /// Erwartet 'namenid', 'fromDate'
        /// </summary>
        event EventHandler<MultibleDataEventArgs> ErgebnisseVonBisRequested;

        void SetErgebnisse(DataTable dt);
        event EventHandler ArtRequest;
        void SetSchiessArten(List<string> liste);
    }
}
