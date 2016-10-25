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
    public partial class MyDialog : Form
    {
        private string _titel;
        private string _message;
        private string _password = "xm1014";

        private void MyDialog_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        public MyDialog(string titel, string message, string password)
        {
            InitializeComponent();
            _titel = titel;
            _message = message;
            if (password != "")
            {
                _password = password;
            }
            txtInputBox.PasswordChar = '*';
            Init();
        }
        public MyDialog(string titel, string message)
        {
            InitializeComponent();
            _titel = titel;
            _message = message;
            txtInputBox.Visible = false;
            chkShowPassword.Visible = false;
            lblPassword.Visible = false;
            Init();
        }
        private void Init()
        {
            this.Text = _titel;            
            richtxtAnzeigeText.Text = _message;
            richtxtAnzeigeText.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void OK(object sender, EventArgs e)
        {
            if (txtInputBox.Text == "xm1014")
            {
                this.PasswortOK = true;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Falsches Passwort.", ";(");
                this.PasswortOK = false;
            }
        }
        private void Exit(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public bool PasswortOK { get; set; }
        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OK(this, new EventArgs());
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (txtInputBox.PasswordChar == '*')
            {
                txtInputBox.PasswordChar = '\0';
            }
            else
            {
                txtInputBox.PasswordChar = '*';
            }
        }
    }
}
