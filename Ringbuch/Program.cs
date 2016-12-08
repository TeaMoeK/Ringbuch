using System;
using System.Windows.Forms;

namespace Ringbuch
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Hauptfenster hauptfenster = new Hauptfenster();
            Vermittler datenbearbeiten = new Vermittler(hauptfenster);
            Application.Run(hauptfenster);            
        }
    }
}
