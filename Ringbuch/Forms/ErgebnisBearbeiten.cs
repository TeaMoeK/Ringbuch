using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Ringbuch
{
    public partial class ErgebnisBearbeiten : Form, ErgebnisBearbeitenInterface
    {
        private int _namenID;
        private int _ergebnisID;
        //  Für das Erstellen eines neuen Datensatzes
        public ErgebnisBearbeiten(int namenID)
        {            
            Create(namenID, -1);
        }
        //  Für das Bearbeiten eines vorhandenen Datensatzes
        public ErgebnisBearbeiten(int namenID, int ergebnisID)
        {
            Create(namenID, ergebnisID);
        }

        private void Create(int namenID, int ergebnisID)
        {
            _namenID = namenID;
            _ergebnisID = ergebnisID;
            InitializeComponent();
            if (_ergebnisID == -1)
            {
                btnDelete.Enabled = false;
            }
        }

        private void Init()
        {
            InvokeArtRequested();
            InvokeNameRequested();

            if (_ergebnisID != -1)
            {
                InvokeErgebnisBearbeitenRequested();
            }
        }

        public void Anzeigen()
        {
            Init();
            this.ShowDialog();
        }

        public event EventHandler<IDEventArgs> ErgebnisBearbeitenRequest;
        private void InvokeErgebnisBearbeitenRequested()
        {
            EventHandler<IDEventArgs> handler = ErgebnisBearbeitenRequest;
            if (handler != null)
            {
                ErgebnisBearbeitenRequest(this, new IDEventArgs(_namenID, _ergebnisID));
            }
        }
        public void SetErgebnis(List<String> ergebnis)
        {
            dateDatum.Value = DateTime.Parse(ergebnis[0]);
            txtSatz1.Text = ergebnis[1];
            txtSatz2.Text = ergebnis[2];
            txtSatz3.Text = ergebnis[3];
            txtSatz4.Text = ergebnis[4];
            txtInfo.Text = ergebnis[6];
            comboArt.SelectedIndex = comboArt.FindStringExact(ergebnis[5]);
        }

        public event EventHandler<IDEventArgs> NameRequest;
        private void InvokeNameRequested()
        {
            EventHandler<IDEventArgs> handler = NameRequest;
            if (handler != null)
            {
                NameRequest(this, new IDEventArgs(_namenID, "name"));
            }
        }
        public void SetName(List<String> name)
        {
            txtVorname.Text = name[0];
            txtZweitname.Text = name[1];
            txtNachname.Text = name[2];
            this.Text = "Ergebnis bearbeiten für: " + name[0] + " " + name[2];
        }
        public event EventHandler ArtRequest;
        private void InvokeArtRequested()
        {
            EventHandler handler = ArtRequest;
            if (handler != null)
            {
                ArtRequest(this, new EventArgs());
                comboArt.SelectedIndex = 0;
            }
        }
        public void SetSchiessArten(List<string> liste)
        {
            foreach (string art in liste)
            {
                comboArt.Items.Add(art);
            }
        }

        public void SetSchiessArten(DataTable dt)
        {
            comboArt.DataSource = dt;
            comboArt.DisplayMember = "SchiessArt";
            comboArt.ValueMember = "rowid";
        }
        private void ErgebnisBearbeiten_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InvokeErgebnisEintragenRequired();
        }
        public void CreateOrUpdateConfirm(bool confirmed)
        {
            if (confirmed)
            {
                this.Dispose();
            }
        }

        public event EventHandler<DataTableEventArgs> ErgebnisCreateRequired;
        public event EventHandler<DataTableEventArgs> ErgebnisUpdateRequired;
        private void InvokeErgebnisEintragenRequired()
        {


            if (_ergebnisID == -1)
            {
                EventHandler<DataTableEventArgs> handler = ErgebnisCreateRequired;
                if (handler != null)
                {
                    ErgebnisCreateRequired(this, new DataTableEventArgs(CreateDataTable()));
                }
            }
            else
            {
                EventHandler<DataTableEventArgs> handler = ErgebnisUpdateRequired;
                if (handler != null)
                {
                    ErgebnisUpdateRequired(this, new DataTableEventArgs(CreateDataTable()));
                }
            }
        }

        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ErgebnisID", typeof(Int16));
            dt.Columns.Add("namenID", typeof(Int16));
            dt.Columns.Add("Datum", typeof(String));
            dt.Columns.Add("Satz1", typeof(Double));
            dt.Columns.Add("Satz2", typeof(Double));
            dt.Columns.Add("Satz3", typeof(Double));
            dt.Columns.Add("Satz4", typeof(Double));
            dt.Columns.Add("Info", typeof(String));
            dt.Columns.Add("SchiessArtenID", typeof(Int32));

            DataRow row = dt.NewRow();
            row["ErgebnisID"] = _ergebnisID;
            row["namenID"] = _namenID;
            row["Datum"] = dateDatum.Value.ToString("yyyy-MM-dd HH:mm");
            if (txtSatz1.Text != "")
            {
                row["Satz1"] = Convert.ToDouble(txtSatz1.Text.Replace('.', ','));
            }
            row["Satz2"] = Convert.ToDouble(txtSatz2.Text.Replace('.', ','));
            row["Satz3"] = Convert.ToDouble(txtSatz3.Text.Replace('.', ','));
            row["Satz4"] = Convert.ToDouble(txtSatz4.Text.Replace('.', ','));
            row["Info"] = txtInfo.Text;
            row["SchiessArtenID"] = comboArt.SelectedValue;
            //row["Art"] = comboArt.SelectedItem;

            dt.Rows.Add(row);
            return dt;
        }
        private void schiessartenLoad()
        {
            comboArt.Items.Clear();
            InvokeArtRequested();
        }
        private void schiessartDelete(object sender, EventArgs e)
        {
            InvokeSchiessartDeleteRequested(comboArt.SelectedItem.ToString());
            schiessartenLoad();
        }
        public event EventHandler<StringEventArgs> SchiessartDeleteRequested;
        private void InvokeSchiessartDeleteRequested(string schiessArt)
        {
            EventHandler<StringEventArgs> handler = SchiessartDeleteRequested;
            if (handler != null)
            {
                SchiessartDeleteRequested(this, new StringEventArgs(schiessArt));
            }
        }
        /// <summary>
        /// Schiessart Neu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void schiessartNeu(object sender, EventArgs e)
        {
            InvokeSchiessartCreateRequired(Interaction.InputBox("Neue Schiessart eingeben." + Environment.NewLine + "Mehrere Einträge durch ',' trennen", "Schiessart neu"));
            schiessartenLoad();
        }
        public event EventHandler<StringEventArgs> SchiessartCreateRequired;
        private void InvokeSchiessartCreateRequired(string schiessart)
        {
            if (schiessart.Trim() != "")
            {
                EventHandler<StringEventArgs> handler = SchiessartCreateRequired;
                if (handler != null)
                {
                    SchiessartCreateRequired(this, new StringEventArgs(schiessart));
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            InvokeErgebnisDeleteRequested();
            this.Dispose();
        }
        public event EventHandler<IDEventArgs> ErgebnisDeleteRequested;
        private void InvokeErgebnisDeleteRequested()
        {
            EventHandler<IDEventArgs> handler = ErgebnisDeleteRequested;
            if (handler != null)
            {
                ErgebnisDeleteRequested(this, new IDEventArgs(_ergebnisID, "ergebnis"));
            }
        }
        private void NumbersOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.') && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if ((sender as TextBox).Text.IndexOf('.') > -1 || (sender as TextBox).Text.IndexOf(',') > -1)
                {
                    e.Handled = true;
                }
            }
        }
        private void InsertZero(object sender, EventArgs e)
        {
            if ((sender as TextBox).Name.ToLower().Contains("txtsatz") && (sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = "0";
            }
        }
    }
}
