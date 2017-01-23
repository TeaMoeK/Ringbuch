using System;
using System.Windows.Forms;

namespace Ringbuch
{
    public partial class MyDialog : Form
    {
        private string _titel;
        private string _message;
        private string _password = string.Empty;

        private bool _adminPW;
        private bool _inputBox = false;
        private bool _passwordBox = false;
        private bool _setPassword = false;

        private const string aes_key = "TimoistDerCoolsteDerCoolenDigger";  //32
        private const string aes_iv = "EineKetteVonkeys";   //16

        private void MyDialog_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }
        // Constructors
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

        public MyDialog(bool passwordBox, string titel, string message)
        {
            _adminPW = true;
            myDialog(titel, message, true, passwordBox, false);
        }
        // Hier landen die Constructors
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
            if (_passwordBox)
            {
                txtInputBox.PasswordChar = '*';
            }
            if (_setPassword)
            {
                txtConfirmPW.Visible = true;
                lblConfirm.Visible = true;
                txtConfirmPW.PasswordChar = '*';
            }
            else
            {
                txtConfirmPW.Visible = false;
                lblConfirm.Visible = false;
            }
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
                    if (txtInputBox.Text == txtConfirmPW.Text)
                    {
                        decodedText = txtInputBox.Text;
                        codedText = encryptPW_AES(txtInputBox.Text);
                        OK = true;
                        this.Dispose();
                    }
                    else
                    {
                        richtxtAnzeigeText.Text = "Die Passwörter stimmen nicht überein.";
                    }
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
            Abbrechen = true;
            OK = false;
            this.Dispose();
        }
        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OK_Klick(this, new EventArgs());
            }
        }
        private void checkPassword()
        {
            if (!_adminPW)
            {
                GetDaten getDaten = new GetDaten();
                if (text == decryptPW_AES(getDaten.getPassword()))
                {
                    PasswortOK = true;
                }
                else
                {
                    PasswortOK = false;
                    MessageBox.Show("Das Passwort war falsch!", "Falsches Passwort");
                }
            }
            else
            {
                text = txtInputBox.Text;
                PasswortOK = true;
            }
        }
        private string encryptPW_AES(string password)
        {
            return AES.AES.EncrytStringToBytes_Aes(password, aes_key, aes_iv);
        }
        private string decryptPW_AES(string password)
        {
            return AES.AES.DecryptStringFromBytes_Aes(password, aes_key, aes_iv);
        }
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (txtInputBox.PasswordChar == '*')
            {
                txtInputBox.PasswordChar = '\0';
                txtConfirmPW.PasswordChar = '\0';
            }
            else
            {
                txtInputBox.PasswordChar = '*';
                txtConfirmPW.PasswordChar = '*';
            }
        }
        // Getter und Setter
        public string text
        {
            get; set;
        }
        public string codedText
        {
            get; set;
        }
        public string decodedText
        {
            get; set;
        }
        public bool PasswortOK
        {
            get; set;
        }
        public bool OK
        {
            get; set;
        }

        public bool Abbrechen
        {
            get; set;
        }
    }
}
