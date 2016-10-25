using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ringbuch
{
    public class InterfaceEventHandler
    {
        private ProfilBearbeitenInterface _profilBearbeiten;
        private ErgebnisBearbeitenInterface _ergebnisBearbeiten;
        private MaterialBearbeitenInterface _materialBearbeiten;
        private StatistikToolInterface _statistikTool;

        public InterfaceEventHandler(ProfilBearbeitenInterface profilBearbeiten)
        {
            _profilBearbeiten = profilBearbeiten;
        }

        public InterfaceEventHandler(ErgebnisBearbeitenInterface ergebnisBearbeiten)
        {
            _ergebnisBearbeiten = ergebnisBearbeiten;
        }

        public InterfaceEventHandler(MaterialBearbeitenInterface materialBearbeiten)
        {
            _materialBearbeiten = materialBearbeiten;
        }

        public InterfaceEventHandler(StatistikTool statistikTool)
        {
            _statistikTool = statistikTool;
        }
        public ProfilBearbeitenInterface profilBearbeiten
        {
            get { return _profilBearbeiten; }
            set { _profilBearbeiten = value; }
        }

        public ErgebnisBearbeitenInterface ergebisBearbeiten
        {
            get { return _ergebnisBearbeiten; }
            set { _ergebnisBearbeiten = value; }
        }

        public MaterialBearbeitenInterface materialBearbeiten
        {
            get { return _materialBearbeiten; }
            set { _materialBearbeiten = value; }
        }
        public StatistikToolInterface statistikTool
        {
            get { return _statistikTool; }
            set { _statistikTool = value; }
        }
    }
}
