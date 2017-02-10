using System;
using System.Data;

namespace Ringbuch
{
  public interface ProfilBearbeitenInterface
  {
    event EventHandler<IDEventArgs> PersonenDatenRequested;
    /// <summary>
    /// Reaktion auf 'PersonenDatenRequested'
    /// </summary>
    void SetPersonenDaten(DataTable dt);
    void SetAdresse(string adresse);

    event EventHandler<StringEventArgs> MaterialByGruppeRequested;
    /// <summary>
    /// Reaktion auf 'MaterialByGruppeRequested'
    /// </summary>
    /// <param name="dt"></param>
    void SetHandschuheAll(DataTable dt);
    void SetJackenAll(DataTable dt);
    void SetKKAll(DataTable dt);
    void SetLGAll(DataTable dt);
    void SetPistoleAll(DataTable dt);

    event EventHandler<IDEventArgs> SetSelectedRequested;
    /// <summary>
    /// Reaktion auf 'SetSelectedRequested'
    /// </summary>
    /// <param name="ID"></param>
    void SetColmboBoxesSelected(int HandschuhID, int JackeID, int KleinkaliberID, int LuftgewehrID, int PistolenID);

    event EventHandler<IDEventArgs> AdresseDatenRequested;
    /// <summary>
    /// Reaktion auf 'AdresseDatenRequested'
    /// </summary>
    /// <param name="dt"></param>
    void SetAdressDaten(DataTable dt);

    event EventHandler PersonenDataTableRequested;
    void SetDataTable(DataTable dt);

    event EventHandler<DataTableEventArgs> ProfilUpdateRequired;
    event EventHandler<DataTableEventArgs> ProfilErstellenRequired;
    event EventHandler<IDEventArgs> ProfilDeleteRequested;
    void SetDatenOk(bool datenOK);

  }
}
