using System;
using System.Collections.Generic;
using System.Data;

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
