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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SQLite-Datenbank | *.db";
            openFileDialog.Title = "Select Database";
            openFileDialog.ShowDialog();
            txtPfad.Text = openFileDialog.FileName;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
