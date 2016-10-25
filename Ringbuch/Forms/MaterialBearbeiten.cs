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
    public partial class MaterialBearbeiten : Form, MaterialBearbeitenInterface
    {

        private DataTable _materialDataTable;
        public MaterialBearbeiten()
        {
            InitializeComponent();
        }

        private void MaterialBearbeiten_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            Init();
        }

        private void Init()
        {
            InvokeMaterialByGruppeRequested("Handschuhe");
            InvokeMaterialByGruppeRequested("Jacke");
            InvokeMaterialByGruppeRequested("Kleinkaliber");
            InvokeMaterialByGruppeRequested("Luftgewehr");
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

        public void Anzeigen()
        {
            Init();
            clearTextBoxes();
            this.ShowDialog();
        }
        private void clearTextBoxes()
        {
            txtHandschuhBezeichnung.Text = "";
            txtJackeBezeichnung.Text = "";
            txtKleinkaliberBezeichnung.Text = "";
            txtLuftgewehrBezeichnung.Text = "";
        }


        private void SelectionToTextBox2(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)(sender as ComboBox).DataSource;
            string selectetValue = "";

            selectetValue = (sender as ComboBox).SelectedValue.ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == selectetValue && !dt.Rows[i]["Bezeichnung"].ToString().ToLower().Contains("n/a"))
                {
                    groupTextBoxes.Controls["txt" + (sender as ComboBox).Tag.ToString() + "Bezeichnung"].Text = dt.Rows[i]["Bezeichnung"].ToString();
                    groupTextBoxes.Controls["txt" + (sender as ComboBox).Tag.ToString() + "Langtext"].Text = dt.Rows[i]["Langtext"].ToString();
                    groupTextBoxes.Controls["txt" + (sender as ComboBox).Tag.ToString() + "Groesse"].Text = dt.Rows[i]["Groesse"].ToString();
                    break;
                }
                else
                {
                    groupTextBoxes.Controls["txt" + (sender as ComboBox).Tag.ToString() + "Bezeichnung"].Text = "";
                    groupTextBoxes.Controls["txt" + (sender as ComboBox).Tag.ToString() + "Langtext"].Text = "";
                    groupTextBoxes.Controls["txt" + (sender as ComboBox).Tag.ToString() + "Groesse"].Text = "";
                }
            }
        }

        /// <summary>
        /// Material Delete
        /// </summary>
        public event EventHandler<IDEventArgs> MaterialDeleteRequested;
        private void InvokeMaterialDeleteRequested(int id)
        {
            EventHandler<IDEventArgs> handler = MaterialDeleteRequested;
            if (handler != null)
            {
                MaterialDeleteRequested(this, new IDEventArgs(id, "material"));
            }
        }
        private void delete(object sender, EventArgs e)
        {
            int id = getSelectedId(sender);
            if (id > 0)
            {
                InvokeMaterialDeleteRequested(id);
            }
            Init();
        }

        private int getSelectedId(object sender)
        {
            int id = -1;
            switch ((sender as Button).Name.ToLower())
            {
                case "btnhandschuhdelete":
                case "btnhandschuhupdate":
                    id = Convert.ToInt16(comboHandschuhe.SelectedValue.ToString());
                    break;
                case "btnjackedelete":
                case "btnjackeupdate":
                    id = Convert.ToInt16(comboJacken.SelectedValue.ToString());
                    break;
                case "btnkkdelete":
                case "btnkkupdate":
                    id = Convert.ToInt16(comboKK.SelectedValue.ToString());
                    break;
                case "btnlgdelete":
                case "btnlgupdate":
                    id = Convert.ToInt16(comboLG.SelectedValue.ToString());
                    break;
            }
            return id;
        }
        /// <summary>
        /// Material Insert
        /// </summary>
        public event EventHandler<DataTableEventArgs> MaterialInsertRequested;
        private void InvokeMaterialInsertRequested(object sender)
        {
            EventHandler<DataTableEventArgs> handler = MaterialInsertRequested;
            if (handler != null)
            {
                InvokeMaterialDataTableRequested();
                MaterialInsertRequested(this, new DataTableEventArgs(CreateDataTable(sender)));
            }
        }
        private void MaterialInsert(object sender, EventArgs e)
        {
            InvokeMaterialInsertRequested(sender);
            Init();
            //this.Dispose();
        }
        private DataTable CreateDataTable(object sender)
        {
            DataTable dt = _materialDataTable;
            string rowID = "-1";
            switch ((sender as Button).Name.ToLower())
            {
                case "btnhandschuhinsert":
                case "btnhandschuhupdate":
                    dt.Rows.Add(new object[]
                    {
                        rowID,
                        "Handschuhe",
                        txtHandschuhBezeichnung.Text,
                        txtHandschuhLangtext.Text,
                        txtHandschuhGroesse.Text
                    });
                    break;

                case "btnjackeinsert":
                case "btnjackeupdate":
                    dt.Rows.Add(new object[]
                    {
                        rowID,
                        "Jacke",
                        txtJackeBezeichnung.Text,
                        txtJackeLangtext.Text,
                        txtJackeGroesse.Text
                    });
                    break;

                case "btnkkinsert":
                case "btnkkupdate":
                    dt.Rows.Add(new object[]
                    {
                        rowID,
                        "Kleinkaliber",
                        txtKleinkaliberBezeichnung.Text,
                        txtKleinkaliberLangtext.Text,
                        txtKleinkaliberGroesse.Text
                    });
                    break;

                case "btnlginsert":
                case "btnlgupdate":
                    dt.Rows.Add(new object[]
                    {
                        rowID,
                        "Luftgewehr",
                        txtLuftgewehrBezeichnung.Text,
                        txtLuftgewehrLangtext.Text,
                        txtLuftgewehrGroesse.Text
                    });
                    break;
            }
            return dt;
        }
        public event EventHandler MaterialDataTableRequested;
        private void InvokeMaterialDataTableRequested()
        {
            EventHandler handler = MaterialDataTableRequested;
            if (handler != null)
            {
                MaterialDataTableRequested(this, new EventArgs());
            }
        }
        public void SetMaterialDataTable(DataTable dt)
        {
            _materialDataTable = dt;
        }

        private void beenden(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void MaterialUpdate(object sender, EventArgs e)
        {
            InvokeMaterialDataTableRequested();
            int id = getSelectedId(sender);
            DataTable dt = CreateDataTable(sender);
            dt.Rows[0]["rowID"] = id;
            InvokeMaterialUpdateRequested(dt);
            Init();
        }
        public event EventHandler<DataTableEventArgs> MaterialUpdateRequested;
        private void InvokeMaterialUpdateRequested(DataTable dt)
        {
            EventHandler<DataTableEventArgs> handler = MaterialUpdateRequested;
            if (handler != null)
            {
                MaterialUpdateRequested(this, new DataTableEventArgs(dt));
            }
        }
    }
}
