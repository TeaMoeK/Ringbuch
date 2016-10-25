using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ringbuch
{
    public partial class ProfilBearbeiten : Form, ProfilBearbeitenInterface
    {
        private int _namenID = -1;
        private DataTable _dt;
        public ProfilBearbeiten(int namenID)
        {
            _namenID = namenID;
            InitializeComponent();
        }
        public ProfilBearbeiten()
        {
            InitializeComponent();
        }

        public void Anzeigen()
        {
            Init();
            this.ShowDialog();
        }

        private void Init()
        {

            InvokeMaterialByGruppeRequested("Handschuhe");
            InvokeMaterialByGruppeRequested("Jacke");
            InvokeMaterialByGruppeRequested("Kleinkaliber");
            InvokeMaterialByGruppeRequested("Luftgewehr");
            if (_namenID != -1)
            {
                InvokePersonenDatenRequested();
                InvokeSetSelectedRequested();                
            }
            else
            {
                NeuesProfil();
            }
        }

        private void NeuesProfil()
        {
            txtVorname.BackColor = Color.Red;
            txtNachname.BackColor = Color.Red;
            comboGeschlecht.SelectedIndex = 0;
            btnDelete.Enabled = false;
        }

        private void TextChanged(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text != "")
            {
                (sender as TextBox).BackColor = Color.White;
            }
            else
            {
                (sender as TextBox).BackColor = Color.Red;
            }
        }

        public int SetNamenID
        {
            set { _namenID = value; }
        }

        public event EventHandler<IDEventArgs> PersonenDatenRequested;
        private void InvokePersonenDatenRequested()
        {
            EventHandler<IDEventArgs> handler = PersonenDatenRequested;
            if (handler != null)
            {
                PersonenDatenRequested(this, new IDEventArgs(_namenID, "name"));
            }
        }
        public void SetPersonenDaten(DataTable dt)
        {
            txtVorname.Text = dt.Rows[0]["Vorname"].ToString();
            txtZweitname.Text = dt.Rows[0]["Zweitname"].ToString();
            txtNachname.Text = dt.Rows[0]["Nachname"].ToString();
            for (int i = 0; i < comboGeschlecht.Items.Count; i++)
            {
                if (Object.Equals(dt.Rows[0]["Geschlecht"].ToString(), comboGeschlecht.Items[i]))
                {
                    comboGeschlecht.SelectedIndex = i;
                }
            }
            dtpGeburtstag.Value = DateTime.Parse(dt.Rows[0]["Geburtstag"].ToString());
            txtInfo.Text = dt.Rows[0]["Info"].ToString();

            if (dt.Rows[0]["DarfLG"].ToString().ToLower() == "true")
            {
                chkDarfLG.Checked = true;
            }
            else
            {
                chkDarfLG.Checked = false;
            }

            if (dt.Rows[0]["DarfKK"].ToString().ToLower() == "true")
            {
                chkDarfKK.Checked = true;
            }
            else
            {
                chkDarfKK.Checked = false;
            }

            if (dt.Rows[0]["istKoenig"].ToString().ToLower() == "true")
            {
                chkIstKoenig.Checked = true;
            }
            else
            {
                chkIstKoenig.Checked = false;
            }
        }

        public void SetAdresse(string adresse)
        {
            txtAdresse.Text = adresse;
        }
        public event EventHandler<StringEventArgs> MaterialByGruppeRequested;
        private void InvokeMaterialByGruppeRequested(string gruppe)
        {
            EventHandler<StringEventArgs> handler = MaterialByGruppeRequested;
            if (handler != null)
            {
                MaterialByGruppeRequested(this, new StringEventArgs(gruppe));
            }
        }
        public void SetJackenAll(DataTable dt)
        {
            comboJacken.DataSource = dt;
            comboJacken.DisplayMember = "Anzeige";
            comboJacken.ValueMember = "rowid";
        }
        public void SetKKAll(DataTable dt)
        {
            comboKK.DataSource = dt;
            comboKK.DisplayMember = "Anzeige";
            comboKK.ValueMember = "rowid";
        }
        public void SetLGAll(DataTable dt)
        {
            comboLG.DataSource = dt;
            comboLG.DisplayMember = "Anzeige";
            comboLG.ValueMember = "rowid";
        }
        public void SetHandschuheAll(DataTable dt)
        {
            comboHandschuhe.DataSource = dt;
            comboHandschuhe.DisplayMember = "Anzeige";
            comboHandschuhe.ValueMember = "rowid";
        }

        public event EventHandler<IDEventArgs> SetSelectedRequested;
        private void InvokeSetSelectedRequested()
        {
            EventHandler<IDEventArgs> handler = SetSelectedRequested;
            if (handler != null)
            {
                SetSelectedRequested(this, new IDEventArgs(_namenID, "name"));
            }
        }

        public void SetColmboBoxesSelected(int HandschuhID, int JackeID, int KleinkaliberID, int LuftgewehrID)
        {
            if (HandschuhID != 0)
            {
                comboHandschuhe.SelectedValue = HandschuhID;
            }
            if (JackeID != 0)
            {
                comboJacken.SelectedValue = JackeID;
            }
            if (KleinkaliberID != 0)
            {
                comboKK.SelectedValue = KleinkaliberID;
            }
            if (LuftgewehrID != 0)
            {
                comboLG.SelectedValue = LuftgewehrID;
            }
        }

        /// <summary>
        /// AdresseDatenRequested
        /// </summary>
        public event EventHandler<IDEventArgs> AdresseDatenRequested;
        private void InvokeAdresseDatenRequested()
        {
            EventHandler<IDEventArgs> handler = AdresseDatenRequested;
            if (handler != null)
            {
                AdresseDatenRequested(this, new IDEventArgs(_namenID, "name"));
            }
        }
        public void SetAdressDaten(DataTable dt)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Speichern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpeichernButton(object sender, EventArgs e)
        {
            if (EingegebeneDatenOK())
            {
                if (CreateDataTable())
                {
                    InvokeDatenSpeichernRequired();
                    this.Dispose();
                }
            }
        }

        private bool EingegebeneDatenOK()
        {
            if (txtVorname.BackColor == Color.Red || txtNachname.BackColor == Color.Red)
            {
                MessageBox.Show("Die rot markierten Bereiche müssen gefüllt sein");
                return false;
            }
            else
            {
                return true;
            }
        }
        public event EventHandler<DataTableEventArgs> ProfilUpdateRequired;
        public event EventHandler<DataTableEventArgs> ProfilErstellenRequired;
        private void InvokeDatenSpeichernRequired()
        {
            if (_namenID != -1)
            {
                EventHandler<DataTableEventArgs> handler = ProfilUpdateRequired;
                if (handler != null)
                {
                    ProfilUpdateRequired(this, new DataTableEventArgs(_dt));
                }
            }
            else
            {
                EventHandler<DataTableEventArgs> handler = ProfilErstellenRequired;
                if (handler != null)
                {
                    ProfilErstellenRequired(this, new DataTableEventArgs(_dt));
                }
            }
        }
        public event EventHandler PersonenDataTableRequested;
        private void InvokePersonenDataTableRequested()
        {
            EventHandler handler = PersonenDataTableRequested;
            if (handler != null)
            {
                PersonenDataTableRequested(this, new EventArgs());
            }
        }
        public void SetDataTable(DataTable dt)
        {
            _dt = dt;
        }
        private bool CreateDataTable()
        {
            InvokePersonenDataTableRequested();
            if (_dt != null)
            {
                DataRow row2 = _dt.NewRow();
                row2["rowid"] = _namenID;
                row2["AdressID"] = -1;
                row2["Vorname"] = txtVorname.Text;
                row2["Zweitname"] = txtZweitname.Text;
                row2["Nachname"] = txtNachname.Text;
                row2["Geburtstag"] = dtpGeburtstag.Value.ToString("yyyy-MM-dd");
                row2["Geschlecht"] = Convert.ToChar(comboGeschlecht.SelectedItem);
                row2["HandschuhID"] = comboHandschuhe.SelectedValue;
                row2["JackeID"] = comboJacken.SelectedValue;
                row2["LuftgewehrID"] = comboLG.SelectedValue;
                row2["KleinkaliberID"] = comboKK.SelectedValue;
                row2["Info"] = txtInfo.Text;
                row2["DarfLG"] = chkDarfLG.Checked;
                row2["DarfKK"] = chkDarfKK.Checked;
                row2["IstKoenig"] = chkIstKoenig.Checked;

                _dt.Rows.Add(row2);
                return true;
            }
            else
            {
                MessageBox.Show("Beim Erstellen der DataTable ist ein Fehler aufgeteten.");
                return false;
            }
        }
        public event EventHandler<IDEventArgs> ProfilDeleteRequested;
        private void InvokeProfilDeleteRequested()
        {
            EventHandler<IDEventArgs> handler = ProfilDeleteRequested;
            if (handler != null)
            {
                ProfilDeleteRequested(this, new IDEventArgs(_namenID, "name"));
            }
        }
        private void delete(object sender, EventArgs e)
        {
            InvokeProfilDeleteRequested();
            this.Dispose();
        }
        private void beenden(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void ProfilBearbeiten_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }
    }
}
