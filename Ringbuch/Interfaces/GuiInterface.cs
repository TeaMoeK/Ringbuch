using System;
using System.Collections.Generic;
using System.Data;

namespace Ringbuch
{
    public interface GuiInterface
    {
        event EventHandler NamesRequested;
        /// <summary>
        /// Reaktion auf 'NamesRequested'
        /// </summary>
        void SetNamen(DataTable dt);

        event EventHandler<IDEventArgs> ErgebnisseRequested;
        /// <summary>
        /// Reaktion auf 'ErgebisseRequested'
        /// </summary>
        void SetErgebnisse(DataTable dt);

        event EventHandler<IDEventArgs> SchiessKlasseRequested;
        /// <summary>
        /// Reaktion auf'SchiessKlasseRequested'
        /// </summary>
        void SetSchiessKlasse(string schiessKlasse, int Schuss, string schiessart);

        event EventHandler SchFestRequested;
        /// <summary>
        /// Reaktion auf 'SchFestRequested'
        /// </summary>
        void SetSchFest(string datum);

        /// <summary>
        /// Hat keine Folgeaktion
        /// </summary>
        event EventHandler<DateTimeEventArgs> SchFestSetRequired;

        event EventHandler<IntListeEventArgs> ShowMaterialRequested;
        /// <summary>
        /// Reaktion auf 'ShowMaterialRequested'
        /// </summary>
        /// <param name="dt"></param>
        void SetShowMaterial(DataTable dt);

        /// <summary>
        /// Ermittelt das Alter(Heute) und Alter(SchFest)
        /// </summary>
        event EventHandler<IDEventArgs> AlterRequested;
        /// <summary>
        /// Reaktion auf 'AlterRequested'
        /// </summary>
        /// <param name="alter"></param>
        void SetAlter(List<int> alter);

        event EventHandler DatenbankPathRequested;
        void SetDatabasePathToTitle(string path);

        event EventHandler<IDEventArgs> ProfilDeleteRequested;

        event EventHandler AdminPassword;

        event EventHandler<InterfaceEventHandler> ProfilBerarbeitenSetRequired;
        event EventHandler<InterfaceEventHandler> ErgebnisBearbeitenSetRequired;
        event EventHandler<InterfaceEventHandler> MaterialBearbeitenSetRequired;
        event EventHandler<InterfaceEventHandler> StatistikToolSetRequired;
        event EventHandler XMLDateiDatenbankBearbeitenRequired;
        event EventHandler XMLDateiPasswordBearbeitenRequired;

    }
}
