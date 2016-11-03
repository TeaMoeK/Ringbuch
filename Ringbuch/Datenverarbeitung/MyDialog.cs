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
using System.Runtime.InteropServices;

namespace Ringbuch
{
    public partial class MyDialog : Form
    {
        private string _titel;
        private string _message;
        private string _password = string.Empty;

        private bool _inputBox = false;
        private bool _passwordBox = false;
        private bool _setPassword = false;

        private void MyDialog_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }
        private MyDialog(string titel, string message)
        {
            myDialog(titel, message, false, false, false);
        }
        private MyDialog(string titel, string message, bool inputBox)
        {
            myDialog(titel, message, inputBox, false, false);
        }
        public MyDialog(bool passwordBox, string titel, string message, bool setPassword)
        {
            myDialog(titel, message, true, passwordBox, setPassword);
        }
        /// <summary>
        /// Hier landen die Constructors
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="message"></param>
        /// <param name="inputBox"></param>
        /// <param name="passwordBox"></param>
        private void myDialog(string titel, string message, bool inputBox, bool passwordBox, bool setPassword)
        {
            InitializeComponent();
            _titel = titel;
            _message = message;
            _inputBox = inputBox;
            _passwordBox = passwordBox;
            _setPassword = setPassword;

            txtInputBox.Visible = inputBox;
            chkShowPassword.Visible = passwordBox;
            lblPassword.Visible = passwordBox;
            Init();
            this.TopMost = true;
        }

        private void Init()
        {
            if (_passwordBox) txtInputBox.PasswordChar = '*';
            this.text = _titel;
            richtxtAnzeigeText.Text = _message;
            richtxtAnzeigeText.SelectionAlignment = HorizontalAlignment.Center;
            OK = false;
        }

        private void OK_Klick(object sender, EventArgs e)
        {
            if (_passwordBox)
            {
                if (_setPassword)
                {
                    Crypt.Kodieren(txtInputBox.Text, "akey");
                    decodedText = Crypt.KodierterText;
                    
                    OK = true;
                    this.Dispose();
                }
                else
                {
                    text = txtInputBox.Text;
                    checkPassword();
                }
                if (PasswortOK)
                {
                    OK = true;
                    this.Dispose();
                }
            }
            else
            {
                OK = true;
                this.Dispose();
            }

        }
        private void Exit(object sender, EventArgs e)
        {
            PasswortOK = false;
            this.Dispose();
        }
        public string text { get; set; }
        public string codedText { get; set; }
        public string decodedText { get; set; }
        public bool PasswortOK { get; set; }
        public bool OK { get; set; }
        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OK_Klick(this, new EventArgs());
            }
        }
        private void checkPassword()
        {
            GetDaten getDaten = new GetDaten();
            if (text.ToUpper() == encryptPW(getDaten.getMasterPW()))
            {
                PasswortOK = true;
            }
            else
            {
                PasswortOK = false;
                MessageBox.Show("Das Passwort war falsch!", "Falsches Passwort");
            }
        }
        private string encryptPW(string password)
        {
            Crypt.Dekodieren(password, "akey");
            return Crypt.DeKodierterText;
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
