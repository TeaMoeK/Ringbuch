using Logging_APE;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;


namespace Ringbuch
{
    public partial class Hauptfenster : Form, GuiInterface
    {
        private bool _debug = false;

        public Hauptfenster()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
            NameSelected();
            Versionsnummer();
            InitToolTip();
            InvokeDatenbankPathRequested();
        }
        private void InitToolTip()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
        }
        private void Init()
        {
            InvokeNamesRequested();
            InvokeSchFestRequested();
            if (Debugger.IsAttached)
            {
                Debug();
            }
            else
            {
                noDebug();
            }
            dgvAlter.Columns.Add("AlterHeute", "Alter(Heute)");
            dgvAlter.Columns.Add("AlterSchFest", "Alter(SchFest)");
            dgvAlter.Columns.Add("Wettkampfklasse", "Wettkampfklasse");
            dgvAlter.Columns.Add("Schuss", "Schuss");
            dgvAlter.Columns.Add("Schiessart", "Schiessart");
            dgvAlter.Rows.Add();
            dgvAlter.ClearSelection();
            dgvAlter.Columns[2].ToolTipText =
                "Schülerklasse B <= 12" + Environment.NewLine +
                "Schülerklasse A: 13 bis 14" + Environment.NewLine +
                "Jugendklasse: 15 bis 16" + Environment.NewLine +
                "Juniorenklasse B: 17 bis 18" + Environment.NewLine +
                "Juniorenklasse A: 19 bis 20" + Environment.NewLine +
                "Herren/Damen: > 20";
            dgvAlter.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            int breite = 0;
            for (int i = 0; i < dgvAlter.Columns.Count; i++)
            {
                dgvAlter.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                breite += dgvAlter.Columns[i].Width;
            }
            dgvAlter.Width = breite - 8;
        }

        private void Debug()
        {
            _debug = true;
            debugToolStripMenuItem.Visible = true;
            archivierteToolStripMenuItem.Visible = true;
            statistikToolStripMenuItem.Visible = true;
        }

        private void noDebug()
        {
            _debug = false;
            debugToolStripMenuItem.Visible = false;
            archivierteToolStripMenuItem.Visible = false;
            statistikToolStripMenuItem.Visible = false;
        }
        public event EventHandler DatenbankPathRequested;
        private void InvokeDatenbankPathRequested()
        {
            EventHandler handler = DatenbankPathRequested;
            if (handler != null)
            {
                DatenbankPathRequested(this, new EventArgs());
            }
        }
        public void SetDatabasePathToTitle(string path)
        {
            this.Text = "Ringbuch @ " + path;
        }
        private void Versionsnummer()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            lblVersion.Text = "V." + fvi.FileVersion;
        }

        private void dgvNamen_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            NameSelected();
        }

        private void NameSelected()
        {
            if (dgvNamen.SelectedCells.Count != 0)
            {
                int index = dgvNamen.SelectedCells[0].RowIndex;
                DataGridViewRow selectedNamenRow = dgvNamen.Rows[index];

                //  ID der Person aus dem DGV auslesen und in rowid speichern
                int rowid = Convert.ToInt16(selectedNamenRow.Cells[0].Value);

                InvokeErgebnisseRequested(rowid);
                InvokeAlterHeuteRequested(rowid);
                InvokeSchiessKlasseRequested(rowid);

                MaterialRequest(selectedNamenRow);
                chkDarfLG.Checked = Convert.ToBoolean(selectedNamenRow.Cells["DarfLG"].Value);
                chkDarfKK.Checked = Convert.ToBoolean(selectedNamenRow.Cells["DarfKK"].Value);
                chkIstKoenig.Checked = Convert.ToBoolean(selectedNamenRow.Cells["IstKoenig"].Value);
                txtInfotext.Text = selectedNamenRow.Cells["Info"].Value.ToString();
                txtJahrgang.Text = Convert.ToDateTime(selectedNamenRow.Cells["Geburtstag"].Value).ToString("dd.MM.yyyy");
            }
        }
        public event EventHandler<IDEventArgs> SchiessKlasseRequested;
        private void InvokeSchiessKlasseRequested(int namenID)
        {
            EventHandler<IDEventArgs> handler = SchiessKlasseRequested;
            if (handler != null)
            {
                SchiessKlasseRequested(this, new IDEventArgs(namenID, "name"));
            }
        }
        public void SetSchiessKlasse(string schiessKlasse, int Schuss, string schiessart)
        {
            dgvAlter.Rows[0].Cells[4].Value = schiessart;
            dgvAlter.Rows[0].Cells[3].Value = Schuss;
            dgvAlter.Rows[0].Cells[2].Value = schiessKlasse;
        }
        private void MaterialRequest(DataGridViewRow selectedRow)
        {
            List<int> MaterialIDListe = new List<int>();
            for (int i = 9; i <= 12; i++)
            {
                MaterialIDListe.Add(Convert.ToInt16(selectedRow.Cells[i].Value));
            }
            InvokeMaterialRequested(MaterialIDListe);
        }

        /// <summary>
        /// NamesRequested
        /// </summary>
        public event EventHandler NamesRequested;
        private void InvokeNamesRequested()
        {
            EventHandler handler = NamesRequested;
            if (handler != null)
            {
                NamesRequested(this, new EventArgs());
            }
        }
        public void SetNamen(DataTable dt)
        {
            dgvNamen.DataSource = dt;
            for (int i = 0; i < 16; i++)
            {
                if (i < 2 || i > 4 || i == 13)
                {
                    dgvNamen.Columns[i].Visible = false;
                }
            }
            dgvNamen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// ErgebnisseRequested
        /// </summary>
        public event EventHandler<IDEventArgs> ErgebnisseRequested;
        private void InvokeErgebnisseRequested(int ID)
        {
            EventHandler<IDEventArgs> handler = ErgebnisseRequested;
            if (handler != null)
            {
                ErgebnisseRequested(this, new IDEventArgs(ID, "name"));
            }
        }
        public void SetErgebnisse(DataTable dt)
        {
            dgvErgebnisse.DataSource = dt;
            dgvErgebnisse.Columns[0].Visible = false;
            dgvErgebnisse.Columns[1].Visible = false;
            dgvErgebnisse.Columns["IstArchiviert"].Visible = false;
            dgvErgebnisse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            for (int i = 2; i <= 9; i++)
            {
                DataGridViewColumn column = dgvErgebnisse.Columns[i];
                if (i == 2)
                {
                    column.Width = 100;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (i > 2 && i < 8)
                {
                    column.Width = 50;
                    DataGridViewCellStyle style = dgvErgebnisse.Columns[i].DefaultCellStyle;
                    style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (i == 8)
                {
                    column.Width = 55;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }
        /// <summary>
        /// SchFestRequested
        /// </summary>
        public event EventHandler SchFestRequested;
        private void InvokeSchFestRequested()
        {
            EventHandler handler = SchFestRequested;
            if (handler != null)
            {
                SchFestRequested(this, new EventArgs());
            }
        }
        public void SetSchFest(string datum)
        {
            dtSchFest.Value = DateTime.Parse(datum);
        }

        /// <summary>
        /// MaterialRequested
        /// </summary>
        public event EventHandler<IntListeEventArgs> ShowMaterialRequested;
        public void InvokeMaterialRequested(List<int> MaterialIDListe)
        {
            EventHandler<IntListeEventArgs> handler = ShowMaterialRequested;
            if (handler != null)
            {
                ShowMaterialRequested(this, new IntListeEventArgs(MaterialIDListe));
            }
        }
        public void SetShowMaterial(DataTable dt)
        {
            dgvMaterial.DataSource = dt;
            dgvMaterial.Columns[0].Visible = false;
            dgvMaterial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int width = 0;
            if (dgvMaterial.Rows.Count > 0)
            {
                DataGridViewRow row = dgvMaterial.Rows[0];


                int height = row.Height * 5;
                for (int i = 1; i <= 4; i++)
                {
                    DataGridViewColumn column = dgvMaterial.Columns[i];
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    width = width + column.Width;

                }

                dgvMaterial.Width = width + 3;
                dgvMaterial.Height = height + 1;
                dgvMaterial.Columns[4].HeaderText = "Größe";
                dgvMaterial.Sort(dgvMaterial.Columns[1], ListSortDirection.Ascending);
            }
        }

        /// <summary>
        /// SchFestSetRequired
        /// </summary>
        public event EventHandler<DateTimeEventArgs> SchFestSetRequired;
        private void InvokeSchFestSetRequired(DateTime datum)
        {
            EventHandler<DateTimeEventArgs> handler = SchFestSetRequired;
            if (handler != null)
            {
                SchFestSetRequired(this, new DateTimeEventArgs(datum));
            }
        }
        private void SchFestInDBSchreiben()
        {
            InvokeSchFestSetRequired(dtSchFest.Value);
        }
        private void dtSchFest_Leave(object sender, EventArgs e)
        {
            SchFestInDBSchreiben();
        }
        private void dtSchFest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                SchFestInDBSchreiben();
                NameSelected();
            }
        }

        public event EventHandler<IDEventArgs> AlterRequested;
        private void InvokeAlterHeuteRequested(int namenID)
        {
            EventHandler<IDEventArgs> handler = AlterRequested;
            if (handler != null)
            {
                AlterRequested(this, new IDEventArgs(namenID, "name"));
            }
        }
        public void SetAlter(List<int> alter)
        {
            if (alter.Count == 2)
            {
                dgvAlter.Rows[0].Cells[0].Value = alter[0];
                dgvAlter.Rows[0].Cells[1].Value = alter[1];
            }
            else
            {
                dgvAlter.Rows[0].Cells[0].Value = alter[0];
                dgvAlter.Rows[0].Cells[1].Value = "DT@Past?";
            }
            DataGridViewColumn column = dgvAlter.Columns[0];
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DataGridViewRow row = dgvAlter.Rows[0];

        }
        #region Profil
        public event EventHandler<InterfaceEventHandler> ProfilBerarbeitenSetRequired;
        private void InvokeProfilBerarbeitenSetRequired(ProfilBearbeiten profilBearbeiten)
        {
            EventHandler<InterfaceEventHandler> handler = ProfilBerarbeitenSetRequired;
            if (handler != null)
            {
                ProfilBerarbeitenSetRequired(this, new InterfaceEventHandler(profilBearbeiten));
            }
        }

        private void profilBearbeiten(object sender, EventArgs e)
        {
            profilBearbeiten();
        }
        private void profilbearbeiten(object sender, DataGridViewCellEventArgs e)
        {
            profilBearbeiten();
        }
        private void profilBearbeiten()
        {
            if (dgvNamen.Rows.Count > 0)
            {
                int index = dgvNamen.SelectedCells[0].RowIndex;
                int rowCount = dgvNamen.Rows.Count;
                DataGridViewRow selectedRow = dgvNamen.Rows[index];

                ProfilBearbeiten profilBearbeiten = new ProfilBearbeiten(Convert.ToInt16(selectedRow.Cells[0].Value));
                InvokeProfilBerarbeitenSetRequired(profilBearbeiten);
                profilBearbeiten.Anzeigen();

                InvokeNamesRequested();                 //  Daten neu laden            
                NameSelected();                         //  Anzeige refresh
                if (dgvNamen.Rows.Count >= rowCount)
                {
                    dgvNamen.Rows[index].Selected = true;   //  zuvor markierte Zeile wieder markieren
                    NameSelected();
                }
            }
        }
        private void profilErstellen(object sender, EventArgs e)
        {
            ProfilBearbeiten profilBearbeiten = new ProfilBearbeiten();
            int index = 0;
            if (dgvNamen.SelectedCells.Count > 0)
            {
                index = dgvNamen.SelectedCells[0].RowIndex;
            }

            int rowCount = dgvNamen.Rows.Count;
            InvokeProfilBerarbeitenSetRequired(profilBearbeiten);
            profilBearbeiten.Anzeigen();

            InvokeNamesRequested();                 //  Daten neu laden
            NameSelected();                         //  Anzeige refresh
            if (dgvNamen.Rows.Count > rowCount)
            {
                dgvNamen.Rows[dgvNamen.Rows.Count - 1].Selected = true;
                NameSelected();
            }
            else if (dgvNamen.Rows.Count == rowCount && dgvNamen.Rows.Count > 0)
            {
                dgvNamen.Rows[index].Selected = true;
                NameSelected();
            }
        }

        private void profilDelete(object sender, EventArgs e)
        {
            profilDelete();
        }

        private void profilDelete()
        {
            if (dgvNamen.Rows.Count > 0)
            {
                int indexName = dgvNamen.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvNamen.Rows[indexName];
                int rowCount = dgvNamen.RowCount;

                InvokeProfilDeleteRequested(Convert.ToInt16(selectedRow.Cells[0].Value));
                InvokeNamesRequested();
                if (dgvNamen.RowCount == rowCount)
                {
                    dgvNamen.Rows[indexName].Selected = true;
                }
                NameSelected();
            }
            else
            {
                MessageBox.Show("Es stehen keine Profile zum löschen bereit.");
            }
        }
        public event EventHandler<IDEventArgs> ProfilDeleteRequested;
        private void InvokeProfilDeleteRequested(int ID)
        {
            EventHandler<IDEventArgs> handler = ProfilDeleteRequested;
            if (handler != null)
            {
                ProfilDeleteRequested(this, new IDEventArgs(ID, "name"));
            }
        }
        private void dgvNamen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                profilDelete();
            }
        }
        #endregion Profil

        #region Ergebnisse
        public event EventHandler<InterfaceEventHandler> ErgebnisBearbeitenSetRequired;
        private void InvokeErgebnisBearbeitenSetRequired(ErgebnisBearbeiten ergebnisBearbeiten)
        {
            EventHandler<InterfaceEventHandler> handler = ErgebnisBearbeitenSetRequired;
            if (handler != null)
            {
                ErgebnisBearbeitenSetRequired(this, new InterfaceEventHandler(ergebnisBearbeiten));
            }
        }

        private void ergebnisBearbeiten(object sender, EventArgs e)
        {
            ergebnisBearbeiten();
        }
        private void ergebnisBearbeiten(object sender, DataGridViewCellEventArgs e)
        {
            ergebnisBearbeiten();
        }
        private void ergebnisBearbeiten()
        {
            if (dgvErgebnisse.CurrentCell != null)
            {
                int indexName = dgvNamen.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRowName = dgvNamen.Rows[indexName];

                try
                {
                    int indexErgebnis = dgvErgebnisse.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRowErgebnis = dgvErgebnisse.Rows[indexErgebnis];

                    ErgebnisBearbeiten ergebnisBearbeiten = new ErgebnisBearbeiten(Convert.ToInt16(selectedRowName.Cells[0].Value), Convert.ToInt16(selectedRowErgebnis.Cells[0].Value));
                    InvokeErgebnisBearbeitenSetRequired(ergebnisBearbeiten);
                    ergebnisBearbeiten.Anzeigen();

                    InvokeNamesRequested();                 //  Daten neu laden
                    dgvNamen.Rows[indexName].Selected = true;   //  zuvor markierte Zeile wieder markieren
                    NameSelected();                         //  Anzeige refresh
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Debug: Edit Ergebnis");
                }
            }
            else
            {
                MessageBox.Show("Es stehen keine Ergebnisse zum ändern bereit.");
            }
        }

        private void eingebenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ergebnisEingeben();
        }

        private void ergebnisEingeben()
        {
            if (dgvNamen.Rows.Count > 0)
            {
                int indexName = dgvNamen.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRowName = dgvNamen.Rows[indexName];

                ErgebnisBearbeiten ergebnisEingeben = new ErgebnisBearbeiten(Convert.ToInt16(selectedRowName.Cells[0].Value));
                InvokeErgebnisBearbeitenSetRequired(ergebnisEingeben);
                ergebnisEingeben.Anzeigen();

                InvokeNamesRequested();                 //  Daten neu laden
                dgvNamen.Rows[indexName].Selected = true;   //  zuvor markierte Zeile wieder markieren
                NameSelected();                         //  Anzeige refresh
            }
            else
            {
                MessageBox.Show("Es existieren keine Profile.");
            }
        }
        public event EventHandler<IDEventArgs> ErgebnisDeleteRequested;
        private void ErgebnisDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvokeErgebnisDeleteRequested();

        }
        private void dgvErgebnisse_KeyDown(object sender, KeyEventArgs e)
        {
            InvokeErgebnisDeleteRequested();
        }
        private void InvokeErgebnisDeleteRequested()
        {
            EventHandler<IDEventArgs> handler = ErgebnisDeleteRequested;
            if (handler != null)
            {
                int indexErgebnis = dgvErgebnisse.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRowErgebnis = dgvErgebnisse.Rows[indexErgebnis];
                ErgebnisDeleteRequested(this, new IDEventArgs(Convert.ToInt16(selectedRowErgebnis.Cells[0].Value), "ergebnis"));
                NameSelected();
            }
        }
        #endregion Ergebnisse
        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Bugs: " + Environment.NewLine +
                "Features: " + Environment.NewLine +
                "-Archivierte Profile anzeigen lassen" + Environment.NewLine +
                "-Installer");
        }
        #region Material
        private void materialBearbeitenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            materialBearbeiten();
        }
        private void materialBearbeiten()
        {
            MaterialBearbeiten materialBearbeiten = new MaterialBearbeiten();
            InvokeMaterialBearbeitenSetRequired(materialBearbeiten);
            materialBearbeiten.Anzeigen();
        }

        public event EventHandler<InterfaceEventHandler> MaterialBearbeitenSetRequired;
        private void InvokeMaterialBearbeitenSetRequired(MaterialBearbeiten materialBearbeiten)
        {
            EventHandler<InterfaceEventHandler> handler = MaterialBearbeitenSetRequired;
            if (handler != null)
            {
                MaterialBearbeitenSetRequired(this, new InterfaceEventHandler(materialBearbeiten));
            }
        }
        #endregion Material
        private void SetPasswordToXML(object sender, EventArgs e)
        {
            InvokeXMLDateiPasswordBearbeitenRequired();
        }
        public event EventHandler XMLDateiPasswordBearbeitenRequired;
        private void InvokeXMLDateiPasswordBearbeitenRequired()
        {
            EventHandler handler = XMLDateiPasswordBearbeitenRequired;
            if (handler != null)
            {
                XMLDateiPasswordBearbeitenRequired(this, new EventArgs());
            }
        }
        private void SetDatabaseToXML(object sender, EventArgs e)
        {
            InvokeXMLDateiDatenbankBearbeitenRequired();
        }
        public event EventHandler XMLDateiDatenbankBearbeitenRequired;
        private void InvokeXMLDateiDatenbankBearbeitenRequired()
        {
            EventHandler handler = XMLDateiDatenbankBearbeitenRequired;
            if (handler != null)
            {
                XMLDateiDatenbankBearbeitenRequired(this, new EventArgs());
            }
        }
        #region Statistik
        private void StatistikAufrufen(object sender, EventArgs e)
        {
            int indexName = dgvNamen.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvNamen.Rows[indexName];
            StatistikTool statistikTool = new StatistikTool(Convert.ToInt16(selectedRow.Cells[0].Value));
            InvokeStatistikToolSetRequired(statistikTool);
            statistikTool.Anzeigen();
        }

        public event EventHandler<InterfaceEventHandler> StatistikToolSetRequired;

        private void InvokeStatistikToolSetRequired(StatistikTool statistikTool)
        {
            EventHandler<InterfaceEventHandler> handler = StatistikToolSetRequired;
            if (handler != null)
            {
                StatistikToolSetRequired(this, new InterfaceEventHandler(statistikTool));
            }
        }
        #endregion Statistik
        private void dgvMaterial_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            materialBearbeiten();
        }

        private void LogAnzeigen(object sender, EventArgs e)
        {
            Log.Instance.ShowLogViewer();
        }

        public event EventHandler AdminPassword;


        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvokeAdminPassword();

        }
        private void InvokeAdminPassword()
        {
            EventHandler handler = AdminPassword;
            if (handler != null)
            {
                AdminPassword(this, new EventArgs());
            }
        }

        public void SetAdminMode(bool isAdmin)
        {
            string adminMode = " - Admin";
            if (isAdmin)
            {                
                this.Text += adminMode;
            }
            else
            {
                this.Text = this.Text.Replace(adminMode, "");
            }
        }
    }
}
