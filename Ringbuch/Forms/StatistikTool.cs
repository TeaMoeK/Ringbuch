using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PolyABC;

namespace Ringbuch
{
    public partial class StatistikTool : Form, StatistikToolInterface
    {
        private int _namenID;
        public StatistikTool(int namenID)
        {
            _namenID = namenID;
            InitializeComponent();
        }

        public void Anzeigen()
        {
            Init();
            this.Show();
        }

        private void StatistikTool_Load(object sender, EventArgs e)
        {
            InvokeErgebnisseRequested();
            InvokeArtRequest();
        }

        private void Init()
        {
            dgvAuswertung.Columns.Add("GesamtErgebniss", "Gesamt");
        }
        public event EventHandler<IDEventArgs> ErgebnisseRequested;
        private void InvokeErgebnisseRequested()
        {
            EventHandler<IDEventArgs> handler = ErgebnisseRequested;
            if (handler != null)
            {
                ErgebnisseRequested(this, new IDEventArgs(_namenID, "name"));
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
        private void click(object sender, EventArgs e)
        {
            InvokeErgebnisseVonBisRequested();
        }
        public event EventHandler<MultibleDataEventArgs> ErgebnisseVonBisRequested;
        private void InvokeErgebnisseVonBisRequested()
        {
            EventHandler<MultibleDataEventArgs> handler = ErgebnisseVonBisRequested;
            if (handler != null)
            {
                ErgebnisseVonBisRequested(this, new MultibleDataEventArgs(_namenID, dtVon.Value, dtBis.Value, comboSchiessart.SelectedItem));
            }
        }
        public event EventHandler ArtRequest;
        private void InvokeArtRequest()
        {
            EventHandler handler = ArtRequest;
            if (handler != null)
            {
                ArtRequest(this, new EventArgs());
            }
        }
        public void SetSchiessArten(List<string> liste)
        {
            comboSchiessart.Items.Add("Alle");
            foreach (string art in liste)
            {
                comboSchiessart.Items.Add(art);
            }
            comboSchiessart.SelectedIndex = 0;
        }

        private void Reset(object sender, EventArgs e)
        {
            InvokeErgebnisseRequested();
            comboSchiessart.SelectedIndex = 0;
            dtVon.Value = DateTime.Now;
            dtBis.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Crypt.Kodieren(txtKlartext.Text, txtKey.Text);
            txtBox.Text = Crypt.KodierterText;
        }
    }
}
