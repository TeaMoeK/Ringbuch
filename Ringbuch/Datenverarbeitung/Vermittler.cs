
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Ringbuch
{
    /// <summary>
    /// Vermittelt zwischen GuiInterface und SetDaten und GetDaten
    /// </summary>
    class Vermittler : IDisposable
    {
        private GuiInterface _guiInterface;
        private ProfilBearbeitenInterface _profilBearbeitenInterface;
        private ErgebnisBearbeitenInterface _ergebnisBearbeitenInterface;
        private MaterialBearbeitenInterface _materialBearbeitenInterface;
        private StatistikToolInterface _statistikInterface;
        private GetDaten _getDaten;
        private SetDaten _setDaten;

        public Vermittler(GuiInterface gui)
        {
            _getDaten = new GetDaten();
            _setDaten = new SetDaten();
            _guiInterface = gui;

            _guiInterface.NamesRequested += GuiNamesRequested;
            _guiInterface.ErgebnisseRequested += GuiErgebnisseRequested;
            _guiInterface.SchFestRequested += GuiSchFestRequested;
            _guiInterface.SchFestSetRequired += GuiSchFestSetRequired;
            _guiInterface.ShowMaterialRequested += GuiShowMaterialRequested;
            _guiInterface.AlterRequested += GuiAlterHeuteRequested;
            _guiInterface.SchiessKlasseRequested += GuiInterfaceSchiessKlasseRequested;
            _guiInterface.ProfilBerarbeitenSetRequired += GuiInterfaceProfilBerarbeitenSetRequired;
            _guiInterface.ErgebnisBearbeitenSetRequired += GuiInterfaceErgebnisBearbeitenSetRequired;
            _guiInterface.MaterialBearbeitenSetRequired += GuiInterfaceMaterialBearbeitenSetRequired;
            _guiInterface.StatistikToolSetRequired += GuiInterfaceStatistikToolSetRequired;
            _guiInterface.ProfilDeleteRequested += GuiInterfaceProfilDeleteRequested;
            _guiInterface.XMLDateiDatenbankBearbeitenRequired += GuiInterfaceXMLDateiDatenbankBearbeitenRequired;
            _guiInterface.DatenbankPathRequested += GuiInterfaceDatenbankPathRequested;
            _guiInterface.XMLDateiPasswordBearbeitenRequired += GuiInterfaceXMLDateiPasswordBearbeitenRequired;

        }

        public ProfilBearbeitenInterface profilBearbeiten
        {
            set { _profilBearbeitenInterface = value; }
        }

        public ErgebnisBearbeitenInterface ergebnisBearbeiten
        {
            set { _ergebnisBearbeitenInterface = value; }
        }

        public MaterialBearbeitenInterface materialBearbeiten
        {
            set { _materialBearbeitenInterface = value; }
        }

        public StatistikToolInterface statistikTool
        {
            set { _statistikInterface = value; }
        }

        private void GuiInterfaceStatistikToolSetRequired(object sender, InterfaceEventHandler e)
        {
            _statistikInterface = e.statistikTool;
            _statistikInterface.ErgebnisseVonBisRequested += StatistikInterfaceErgebnisseVonBisRequested;
            _statistikInterface.ErgebnisseRequested += StatistikInterfaceErgebnisseRequested;
            _statistikInterface.ArtRequest += StatistikInterfaceArtRequest;
        }

        private void StatistikInterfaceArtRequest(object sender, EventArgs e)
        {
            _statistikInterface.SetSchiessArten(_getDaten.getSchiessArten());
        }
        private void StatistikInterfaceErgebnisseVonBisRequested(object sender, MultibleDataEventArgs e)
        {
            if (Convert.ToDateTime(e.args.GetValue(1)).ToString("yyyy-MM-dd") == Convert.ToDateTime(e.args.GetValue(2)).ToString("yyyy-MM-dd"))
            {
                _statistikInterface.SetErgebnisse(_getDaten.GetErgebnisse(
                    Convert.ToInt16(e.args.GetValue(0)),
                    Convert.ToDateTime(e.args.GetValue(1)).ToString("yyyy-MM-dd")));
            }
            else
            {
                string schiessArt = "";
                List<string> listeSchiessarten = _getDaten.getSchiessArten();
                if (listeSchiessarten.Contains(e.args.GetValue(3).ToString()))
                {
                    schiessArt = e.args.GetValue(3).ToString();
                }
                _statistikInterface.SetErgebnisse(_getDaten.GetErgebnisse(
                    Convert.ToInt16(e.args.GetValue(0)),
                    Convert.ToDateTime(e.args.GetValue(1)).ToString("yyyy-MM-dd"),
                    Convert.ToDateTime(e.args.GetValue(2)).ToString("yyyy-MM-dd"),
                    schiessArt));
            }

        }
        private void StatistikInterfaceErgebnisseRequested(object sender, IDEventArgs e)
        {
            _statistikInterface.SetErgebnisse(_getDaten.GetErgebnisse(e.NamenID));
        }
        public void GuiInterfaceDatenbankPathRequested(object sender, EventArgs e)
        {
            _guiInterface.SetDatabasePathToTitle(_getDaten.getPathDatabase());
        }
        private void GuiInterfaceXMLDateiPasswordBearbeitenRequired(object sender, EventArgs e)
        {
            _setDaten.SetPassword();
        }
        private void GuiInterfaceXMLDateiDatenbankBearbeitenRequired(object sender, EventArgs e)
        {
            _setDaten.SetDatabase();
            _guiInterface.SetNamen(_getDaten.getNamen());
            _guiInterface.SetDatabasePathToTitle(_getDaten.getPathDatabase());
        }

        private void GuiErgebnisseRequested(object sender, IDEventArgs e)
        {
            _guiInterface.SetErgebnisse(_getDaten.GetErgebnisse(e.NamenID));
        }

        private void GuiNamesRequested(object sender, EventArgs e)
        {
            _guiInterface.SetNamen(_getDaten.getNamen());
        }

        private void GuiSchFestRequested(object sender, EventArgs e)
        {
            _guiInterface.SetSchFest(_getDaten.getSchFest());
        }
        private void GuiSchFestSetRequired(object sender, DateTimeEventArgs e)
        {
            _setDaten.SetSchFest(e.dt);
        }

        private void GuiShowMaterialRequested(object sender, IntListeEventArgs e)
        {
            _guiInterface.SetShowMaterial(_getDaten.getShowMaterial(e.IntListe));
        }

        private void GuiAlterHeuteRequested(object sender, IDEventArgs e)
        {
            _guiInterface.SetAlter(_getDaten.getAlter(e.NamenID));
        }

        private void GuiInterfaceSchiessKlasseRequested(object sender, IDEventArgs e)
        {
            _guiInterface.SetSchiessKlasse(_getDaten.getSchiessKlasse(e.NamenID));
        }
        private void GuiInterfaceProfilDeleteRequested(object sender, IDEventArgs e)
        {
            _setDaten.SetProfilDelete(e.NamenID);
        }

        /// <summary>
        /// Profil Berarbeiten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuiInterfaceProfilBerarbeitenSetRequired(object sender, InterfaceEventHandler e)
        {
            _profilBearbeitenInterface = e.profilBearbeiten;
            _profilBearbeitenInterface.PersonenDatenRequested += ProfilBearbeitenInterfacePersonenDatenRequested;
            _profilBearbeitenInterface.MaterialByGruppeRequested += ProfilBearbeitenInterfaceMaterialByGruppeRequested;
            _profilBearbeitenInterface.SetSelectedRequested += ProfilBearbeitenSetSelectedRequested;
            _profilBearbeitenInterface.ProfilUpdateRequired += ProfilBearbeitenInterfaceDatenSpeichernRequired;
            _profilBearbeitenInterface.ProfilErstellenRequired += ProfilBearbeitenInterfaceProfilErstellenRequired;
            _profilBearbeitenInterface.AdresseDatenRequested += ProfilBearbeitenInterfaceAdresseDatenRequested;
            _profilBearbeitenInterface.PersonenDataTableRequested += ProfilBearbeitenInterfacePersonenDataTableRequested;
            _profilBearbeitenInterface.ProfilDeleteRequested += ProfilBearbeitenInterfaceProfilDeleteRequested;
        }

        private void ProfilBearbeitenInterfaceProfilDeleteRequested(object sender, IDEventArgs e)
        {
            _setDaten.SetProfilDelete(e.NamenID);
        }
        private void ProfilBearbeitenInterfacePersonenDataTableRequested(object sender, EventArgs e)
        {
            _profilBearbeitenInterface.SetDataTable(_getDaten.CreateDataTable("Personen"));
        }

        private void ProfilBearbeitenInterfaceAdresseDatenRequested(object sender, IDEventArgs e)
        {

        }
        private void ProfilBearbeitenInterfaceMaterialByGruppeRequested(object sender, StringEventArgs e)
        {
            switch (e.value)
            {
                case "Handschuhe":
                    _profilBearbeitenInterface.SetHandschuheAll(_getDaten.getMaterialByGruppe(e.value));
                    break;

                case "Jacke":
                    _profilBearbeitenInterface.SetJackenAll(_getDaten.getMaterialByGruppe(e.value));
                    break;

                case "Kleinkaliber":
                    _profilBearbeitenInterface.SetKKAll(_getDaten.getMaterialByGruppe(e.value));
                    break;

                case "Luftgewehr":
                    _profilBearbeitenInterface.SetLGAll(_getDaten.getMaterialByGruppe(e.value));
                    break;
            }
        }

        private void ProfilBearbeitenSetSelectedRequested(object sender, IDEventArgs e)
        {
            _profilBearbeitenInterface.SetColmboBoxesSelected(
                _getDaten.getMaterialIDByNamenID(e.NamenID, "handschuh"),
                _getDaten.getMaterialIDByNamenID(e.NamenID, "jacke"),
                _getDaten.getMaterialIDByNamenID(e.NamenID, "kleinkaliber"),
                _getDaten.getMaterialIDByNamenID(e.NamenID, "luftgewehr"));
        }

        private void ProfilBearbeitenInterfaceDatenSpeichernRequired(object sender, DataTableEventArgs e)
        {
            _profilBearbeitenInterface.SetDatenOk(_setDaten.SetProfilUpdate(e.dt));
        }

        private void ProfilBearbeitenInterfaceProfilErstellenRequired(object sender, DataTableEventArgs e)
        {
            _profilBearbeitenInterface.SetDatenOk(_setDaten.SetProfilNeu(e.dt));
        }
        private void ProfilBearbeitenInterfacePersonenDatenRequested(object sender, IDEventArgs e)
        {
            _profilBearbeitenInterface.SetPersonenDaten(_getDaten.getPersonenDaten(e.NamenID));
            _profilBearbeitenInterface.SetAdresse(_getDaten.getAdresse(e.NamenID));
        }

        /// <summary>
        /// Ergebnis Bearbeiten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuiInterfaceErgebnisBearbeitenSetRequired(object sender, InterfaceEventHandler e)
        {
            _ergebnisBearbeitenInterface = e.ergebisBearbeiten;
            _ergebnisBearbeitenInterface.ErgebnisBearbeitenRequest += ErgebnisBearbeitenInterfaceErgebnisBearbeitenRequested;
            _ergebnisBearbeitenInterface.NameRequest += ErgebnisBearbeitenInterfaceNameRequest;
            _ergebnisBearbeitenInterface.ArtRequest += ErgebnisBearbeitenInterfaceArtRequest;
            _ergebnisBearbeitenInterface.ErgebnisCreateRequired += ErgebnisBearbeitenInterfaceErgebnisCreateRequired;
            _ergebnisBearbeitenInterface.ErgebnisUpdateRequired += ErgebnisBearbeitenInterfaceErgebnisUpdateRequired;
            _ergebnisBearbeitenInterface.ErgebnisDeleteRequested += ErgebnisBearbeitenInterfaceErgebnisDeleteRequested;
            _ergebnisBearbeitenInterface.SchiessartCreateRequired += ErgebnisBearbeitenInterfaceSchiessartCreateRequired;
            _ergebnisBearbeitenInterface.SchiessartDeleteRequested += ErgebnisBearbeitenInterfaceSchiessartDeleteRequested;
        }
        //  Schiessart  >>>>
        private void ErgebnisBearbeitenInterfaceSchiessartDeleteRequested(object sender, StringEventArgs e)
        {
            _setDaten.SetSchiessartenDelete(e.value);
        }
        private void ErgebnisBearbeitenInterfaceSchiessartCreateRequired(object sender, StringEventArgs e)
        {
            _setDaten.SetSchiessartenNeu(e.value);
        }
        //  Schiessart  <<<<
        //  Create, Update, Delete  >>>>
        private void ErgebnisBearbeitenInterfaceErgebnisDeleteRequested(object sender, IDEventArgs e)
        {
            _setDaten.DeleteErgebnis(e.ErgebnisID);
        }
        private void ErgebnisBearbeitenInterfaceErgebnisCreateRequired(object sender, DataTableEventArgs e)
        {
            _ergebnisBearbeitenInterface.CreateOrUpdateConfirm(_setDaten.CreateErgebnis(e.dt));
        }
        private void ErgebnisBearbeitenInterfaceErgebnisUpdateRequired(object sender, DataTableEventArgs e)
        {
            _ergebnisBearbeitenInterface.CreateOrUpdateConfirm(_setDaten.UpdateErgebnis(e.dt));
        }
        //  Create, update, Delete  <<<<

        private void ErgebnisBearbeitenInterfaceErgebnisBearbeitenRequested(object sender, IDEventArgs e)
        {
            _ergebnisBearbeitenInterface.SetErgebnis(_getDaten.getErgebnis(e.NamenID, e.ErgebnisID));
        }
        private void ErgebnisBearbeitenInterfaceNameRequest(object sender, IDEventArgs e)
        {
            _ergebnisBearbeitenInterface.SetName(_getDaten.getName(e.NamenID));
        }
        private void ErgebnisBearbeitenInterfaceArtRequest(object sender, EventArgs e)
        {
            _ergebnisBearbeitenInterface.SetSchiessArten(_getDaten.getSchiessArten());
        }

        /// <summary>
        /// Material Bearbeiten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuiInterfaceMaterialBearbeitenSetRequired(object sender, InterfaceEventHandler e)
        {
            _materialBearbeitenInterface = e.materialBearbeiten;
            _materialBearbeitenInterface.MaterialByGruppeRequested += MaterialBearbeitenInterfaceMaterialByGruppeRequested;
            _materialBearbeitenInterface.MaterialDeleteRequested += MaterialBearbeitenInterfaceMaterialDeleteRequested;
            _materialBearbeitenInterface.MaterialInsertRequested += MaterialBearbeitenInterfaceMaterialInsertRequested;
            _materialBearbeitenInterface.MaterialUpdateRequested += MaterialBearbeitenInterfaceMaterialUpdateRequested;
            _materialBearbeitenInterface.MaterialDataTableRequested += MaterialBearbeitenInterfaceMaterialDataTableRequested;
        }


        private void MaterialBearbeitenInterfaceMaterialUpdateRequested(object sender, DataTableEventArgs e)
        {
            _setDaten.SetMaterialUpdate(e.dt);
        }
        private void MaterialBearbeitenInterfaceMaterialDataTableRequested(object sender, EventArgs e)
        {
            _materialBearbeitenInterface.SetMaterialDataTable(_getDaten.CreateDataTable("Material"));
        }
        private void MaterialBearbeitenInterfaceMaterialInsertRequested(object sender, DataTableEventArgs e)
        {
            _setDaten.SetMaterialInsert(e.dt);
        }
        private void MaterialBearbeitenInterfaceMaterialByGruppeRequested(object sender, StringEventArgs e)
        {
            switch (e.value)
            {
                case "Handschuhe":
                    _materialBearbeitenInterface.SetHandschuheAll(_getDaten.getMaterialByGruppe(e.value));
                    break;

                case "Jacke":
                    _materialBearbeitenInterface.SetJackenAll(_getDaten.getMaterialByGruppe(e.value));
                    break;

                case "Kleinkaliber":
                    _materialBearbeitenInterface.SetKKAll(_getDaten.getMaterialByGruppe(e.value));
                    break;

                case "Luftgewehr":
                    _materialBearbeitenInterface.SetLGAll(_getDaten.getMaterialByGruppe(e.value));
                    break;
            }
        }

        private void MaterialBearbeitenInterfaceMaterialDeleteRequested(object sender, IDEventArgs e)
        {
            _setDaten.SetMaterialDelete(e.MaterialID);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            //  GuiInterface
            _guiInterface.NamesRequested -= GuiNamesRequested;
            _guiInterface.ErgebnisseRequested -= GuiErgebnisseRequested;
            _guiInterface.SchFestRequested -= GuiSchFestRequested;
            _guiInterface.SchFestSetRequired -= GuiSchFestSetRequired;
            _guiInterface.AlterRequested -= GuiAlterHeuteRequested;
            _guiInterface.SchiessKlasseRequested -= GuiInterfaceSchiessKlasseRequested;
            _guiInterface.ShowMaterialRequested -= GuiShowMaterialRequested;
            _guiInterface.ProfilBerarbeitenSetRequired -= GuiInterfaceProfilBerarbeitenSetRequired;
            _guiInterface.ErgebnisBearbeitenSetRequired -= GuiInterfaceErgebnisBearbeitenSetRequired;
            _guiInterface.XMLDateiDatenbankBearbeitenRequired -= GuiInterfaceXMLDateiDatenbankBearbeitenRequired;
            _guiInterface.DatenbankPathRequested -= GuiInterfaceDatenbankPathRequested;
            _guiInterface.XMLDateiPasswordBearbeitenRequired -= GuiInterfaceXMLDateiPasswordBearbeitenRequired;

            //  ProfilBearbeitenInterface
            _profilBearbeitenInterface.PersonenDatenRequested -= ProfilBearbeitenInterfacePersonenDatenRequested;
            _profilBearbeitenInterface.MaterialByGruppeRequested -= ProfilBearbeitenInterfaceMaterialByGruppeRequested;
            _profilBearbeitenInterface.SetSelectedRequested -= ProfilBearbeitenSetSelectedRequested;
            _profilBearbeitenInterface.ProfilUpdateRequired -= ProfilBearbeitenInterfaceDatenSpeichernRequired;
            _profilBearbeitenInterface.ProfilErstellenRequired -= ProfilBearbeitenInterfaceProfilErstellenRequired;
            _profilBearbeitenInterface.AdresseDatenRequested -= ProfilBearbeitenInterfaceAdresseDatenRequested;
            _profilBearbeitenInterface.PersonenDataTableRequested -= ProfilBearbeitenInterfacePersonenDataTableRequested;
            _profilBearbeitenInterface.ProfilDeleteRequested -= ProfilBearbeitenInterfaceProfilDeleteRequested;

            //  ErgebnisBearbeitenInterface
            _ergebnisBearbeitenInterface.ErgebnisBearbeitenRequest -= ErgebnisBearbeitenInterfaceErgebnisBearbeitenRequested;
            _ergebnisBearbeitenInterface.NameRequest -= ErgebnisBearbeitenInterfaceNameRequest;
            _ergebnisBearbeitenInterface.ArtRequest -= ErgebnisBearbeitenInterfaceArtRequest;
            _ergebnisBearbeitenInterface.ErgebnisCreateRequired -= ErgebnisBearbeitenInterfaceErgebnisCreateRequired;
            _ergebnisBearbeitenInterface.ErgebnisUpdateRequired -= ErgebnisBearbeitenInterfaceErgebnisUpdateRequired;
            _ergebnisBearbeitenInterface.ErgebnisDeleteRequested -= ErgebnisBearbeitenInterfaceErgebnisDeleteRequested;
            _ergebnisBearbeitenInterface.SchiessartCreateRequired -= ErgebnisBearbeitenInterfaceSchiessartCreateRequired;
            _ergebnisBearbeitenInterface.SchiessartDeleteRequested -= ErgebnisBearbeitenInterfaceSchiessartDeleteRequested;

            //  MaterialBearbeitenInterface
            _materialBearbeitenInterface.MaterialByGruppeRequested -= MaterialBearbeitenInterfaceMaterialByGruppeRequested;
            _materialBearbeitenInterface.MaterialDeleteRequested -= MaterialBearbeitenInterfaceMaterialDeleteRequested;
            _materialBearbeitenInterface.MaterialInsertRequested -= MaterialBearbeitenInterfaceMaterialInsertRequested;
            _materialBearbeitenInterface.MaterialUpdateRequested -= MaterialBearbeitenInterfaceMaterialUpdateRequested;
            _materialBearbeitenInterface.MaterialDataTableRequested -= MaterialBearbeitenInterfaceMaterialDataTableRequested;

            //  StatistikInterface
            _guiInterface.MaterialBearbeitenSetRequired -= GuiInterfaceMaterialBearbeitenSetRequired;
            _statistikInterface.ErgebnisseVonBisRequested -= StatistikInterfaceErgebnisseVonBisRequested;
            _statistikInterface.ErgebnisseRequested -= StatistikInterfaceErgebnisseRequested;
            _statistikInterface.ArtRequest -= StatistikInterfaceArtRequest;
        }
    }
}
