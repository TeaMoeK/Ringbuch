using System;
using System.Windows.Forms;

namespace Ringbuch
{
    public partial class Installer : Form
    {

        public Installer()
        {
            InitializeComponent();
        }

        private void Installer_Load(object sender, EventArgs e)
        {

        }

        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            openFolder.ShowDialog();
            txtPfad.Text = openFolder.SelectedPath;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Wirklich beenden?", "Beenden", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            CreateDatabase createDB = new CreateDatabase();
            createDB.DBErstellen(txtPfad.Text);
        }
    }
}
