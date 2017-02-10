namespace Ringbuch
{
    partial class ProfilBearbeiten
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.txtVorname = new System.Windows.Forms.TextBox();
      this.txtZweitname = new System.Windows.Forms.TextBox();
      this.txtNachname = new System.Windows.Forms.TextBox();
      this.dtpGeburtstag = new System.Windows.Forms.DateTimePicker();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.comboGeschlecht = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.comboHandschuhe = new System.Windows.Forms.ComboBox();
      this.comboJacken = new System.Windows.Forms.ComboBox();
      this.comboKK = new System.Windows.Forms.ComboBox();
      this.comboLG = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      this.txtInfo = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.chkDarfLG = new System.Windows.Forms.CheckBox();
      this.chkDarfKK = new System.Windows.Forms.CheckBox();
      this.chkIstKoenig = new System.Windows.Forms.CheckBox();
      this.txtAdresse = new System.Windows.Forms.TextBox();
      this.btnAdresseBearbeiten = new System.Windows.Forms.Button();
      this.groupAdresse = new System.Windows.Forms.GroupBox();
      this.label11 = new System.Windows.Forms.Label();
      this.comboPistole = new System.Windows.Forms.ComboBox();
      this.groupAdresse.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtVorname
      // 
      this.txtVorname.Location = new System.Drawing.Point(15, 25);
      this.txtVorname.Name = "txtVorname";
      this.txtVorname.Size = new System.Drawing.Size(100, 20);
      this.txtVorname.TabIndex = 0;
      this.txtVorname.TextChanged += new System.EventHandler(this.TextChanged);
      // 
      // txtZweitname
      // 
      this.txtZweitname.Location = new System.Drawing.Point(15, 64);
      this.txtZweitname.Name = "txtZweitname";
      this.txtZweitname.Size = new System.Drawing.Size(100, 20);
      this.txtZweitname.TabIndex = 1;
      // 
      // txtNachname
      // 
      this.txtNachname.Location = new System.Drawing.Point(15, 103);
      this.txtNachname.Name = "txtNachname";
      this.txtNachname.Size = new System.Drawing.Size(100, 20);
      this.txtNachname.TabIndex = 2;
      this.txtNachname.TextChanged += new System.EventHandler(this.TextChanged);
      // 
      // dtpGeburtstag
      // 
      this.dtpGeburtstag.Location = new System.Drawing.Point(15, 143);
      this.dtpGeburtstag.Name = "dtpGeburtstag";
      this.dtpGeburtstag.Size = new System.Drawing.Size(206, 20);
      this.dtpGeburtstag.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 13);
      this.label1.TabIndex = 21;
      this.label1.Text = "Vorname";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 48);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(59, 13);
      this.label2.TabIndex = 20;
      this.label2.Text = "Zweitname";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 87);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(59, 13);
      this.label3.TabIndex = 19;
      this.label3.Text = "Nachname";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 127);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(59, 13);
      this.label4.TabIndex = 18;
      this.label4.Text = "Geburtstag";
      // 
      // comboGeschlecht
      // 
      this.comboGeschlecht.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboGeschlecht.FormattingEnabled = true;
      this.comboGeschlecht.Items.AddRange(new object[] {
            "m",
            "w"});
      this.comboGeschlecht.Location = new System.Drawing.Point(121, 25);
      this.comboGeschlecht.Name = "comboGeschlecht";
      this.comboGeschlecht.Size = new System.Drawing.Size(39, 21);
      this.comboGeschlecht.TabIndex = 5;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(118, 9);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(43, 13);
      this.label5.TabIndex = 22;
      this.label5.Text = "Geschl.";
      // 
      // comboHandschuhe
      // 
      this.comboHandschuhe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboHandschuhe.FormattingEnabled = true;
      this.comboHandschuhe.Location = new System.Drawing.Point(350, 25);
      this.comboHandschuhe.Name = "comboHandschuhe";
      this.comboHandschuhe.Size = new System.Drawing.Size(121, 21);
      this.comboHandschuhe.TabIndex = 6;
      // 
      // comboJacken
      // 
      this.comboJacken.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboJacken.FormattingEnabled = true;
      this.comboJacken.Location = new System.Drawing.Point(223, 24);
      this.comboJacken.Name = "comboJacken";
      this.comboJacken.Size = new System.Drawing.Size(121, 21);
      this.comboJacken.TabIndex = 7;
      // 
      // comboKK
      // 
      this.comboKK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboKK.FormattingEnabled = true;
      this.comboKK.Location = new System.Drawing.Point(223, 64);
      this.comboKK.Name = "comboKK";
      this.comboKK.Size = new System.Drawing.Size(121, 21);
      this.comboKK.TabIndex = 8;
      // 
      // comboLG
      // 
      this.comboLG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboLG.FormattingEnabled = true;
      this.comboLG.Location = new System.Drawing.Point(350, 64);
      this.comboLG.Name = "comboLG";
      this.comboLG.Size = new System.Drawing.Size(121, 21);
      this.comboLG.TabIndex = 9;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(347, 9);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(62, 13);
      this.label6.TabIndex = 23;
      this.label6.Text = "Handschuh";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(220, 8);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(36, 13);
      this.label7.TabIndex = 24;
      this.label7.Text = "Jacke";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(221, 49);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(61, 13);
      this.label8.TabIndex = 25;
      this.label8.Text = "Kleinkaliber";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(348, 49);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(60, 13);
      this.label9.TabIndex = 26;
      this.label9.Text = "Luftgewehr";
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(12, 322);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 14;
      this.btnOK.Text = "Speichern";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.SpeichernButton);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(93, 322);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 15;
      this.btnCancel.Text = "Abbrechen";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.beenden);
      // 
      // btnDelete
      // 
      this.btnDelete.Location = new System.Drawing.Point(174, 322);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(75, 23);
      this.btnDelete.TabIndex = 16;
      this.btnDelete.Text = "Löschen";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.delete);
      // 
      // txtInfo
      // 
      this.txtInfo.Location = new System.Drawing.Point(15, 182);
      this.txtInfo.Multiline = true;
      this.txtInfo.Name = "txtInfo";
      this.txtInfo.Size = new System.Drawing.Size(234, 49);
      this.txtInfo.TabIndex = 4;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(12, 166);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(25, 13);
      this.label10.TabIndex = 17;
      this.label10.Text = "Info";
      // 
      // chkDarfLG
      // 
      this.chkDarfLG.AutoSize = true;
      this.chkDarfLG.Location = new System.Drawing.Point(351, 91);
      this.chkDarfLG.Name = "chkDarfLG";
      this.chkDarfLG.Size = new System.Drawing.Size(63, 17);
      this.chkDarfLG.TabIndex = 10;
      this.chkDarfLG.Text = "Darf LG";
      this.chkDarfLG.UseVisualStyleBackColor = true;
      // 
      // chkDarfKK
      // 
      this.chkDarfKK.AutoSize = true;
      this.chkDarfKK.Location = new System.Drawing.Point(223, 91);
      this.chkDarfKK.Name = "chkDarfKK";
      this.chkDarfKK.Size = new System.Drawing.Size(63, 17);
      this.chkDarfKK.TabIndex = 11;
      this.chkDarfKK.Text = "Darf KK";
      this.chkDarfKK.UseVisualStyleBackColor = true;
      // 
      // chkIstKoenig
      // 
      this.chkIstKoenig.AutoSize = true;
      this.chkIstKoenig.Location = new System.Drawing.Point(255, 214);
      this.chkIstKoenig.Name = "chkIstKoenig";
      this.chkIstKoenig.Size = new System.Drawing.Size(53, 17);
      this.chkIstKoenig.TabIndex = 12;
      this.chkIstKoenig.Text = "König";
      this.chkIstKoenig.UseVisualStyleBackColor = true;
      // 
      // txtAdresse
      // 
      this.txtAdresse.Location = new System.Drawing.Point(6, 19);
      this.txtAdresse.Name = "txtAdresse";
      this.txtAdresse.ReadOnly = true;
      this.txtAdresse.Size = new System.Drawing.Size(378, 20);
      this.txtAdresse.TabIndex = 0;
      // 
      // btnAdresseBearbeiten
      // 
      this.btnAdresseBearbeiten.Location = new System.Drawing.Point(6, 45);
      this.btnAdresseBearbeiten.Name = "btnAdresseBearbeiten";
      this.btnAdresseBearbeiten.Size = new System.Drawing.Size(75, 23);
      this.btnAdresseBearbeiten.TabIndex = 1;
      this.btnAdresseBearbeiten.Text = "Bearbeiten";
      this.btnAdresseBearbeiten.UseVisualStyleBackColor = true;
      // 
      // groupAdresse
      // 
      this.groupAdresse.Controls.Add(this.btnAdresseBearbeiten);
      this.groupAdresse.Controls.Add(this.txtAdresse);
      this.groupAdresse.Location = new System.Drawing.Point(15, 237);
      this.groupAdresse.Name = "groupAdresse";
      this.groupAdresse.Size = new System.Drawing.Size(390, 79);
      this.groupAdresse.TabIndex = 13;
      this.groupAdresse.TabStop = false;
      this.groupAdresse.Text = "Adresse";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(286, 112);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(38, 13);
      this.label11.TabIndex = 28;
      this.label11.Text = "Pistole";
      // 
      // comboPistole
      // 
      this.comboPistole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboPistole.FormattingEnabled = true;
      this.comboPistole.Location = new System.Drawing.Point(288, 127);
      this.comboPistole.Name = "comboPistole";
      this.comboPistole.Size = new System.Drawing.Size(121, 21);
      this.comboPistole.TabIndex = 27;
      // 
      // ProfilBearbeiten
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(483, 360);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.comboPistole);
      this.Controls.Add(this.groupAdresse);
      this.Controls.Add(this.chkIstKoenig);
      this.Controls.Add(this.chkDarfKK);
      this.Controls.Add(this.chkDarfLG);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.txtInfo);
      this.Controls.Add(this.btnDelete);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.comboLG);
      this.Controls.Add(this.comboKK);
      this.Controls.Add(this.comboJacken);
      this.Controls.Add(this.comboHandschuhe);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.comboGeschlecht);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.dtpGeburtstag);
      this.Controls.Add(this.txtNachname);
      this.Controls.Add(this.txtZweitname);
      this.Controls.Add(this.txtVorname);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ProfilBearbeiten";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "ProfilBearbeiten";
      this.Load += new System.EventHandler(this.ProfilBearbeiten_Load);
      this.groupAdresse.ResumeLayout(false);
      this.groupAdresse.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVorname;
        private System.Windows.Forms.TextBox txtZweitname;
        private System.Windows.Forms.TextBox txtNachname;
        private System.Windows.Forms.DateTimePicker dtpGeburtstag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboGeschlecht;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboHandschuhe;
        private System.Windows.Forms.ComboBox comboJacken;
        private System.Windows.Forms.ComboBox comboKK;
        private System.Windows.Forms.ComboBox comboLG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkDarfLG;
        private System.Windows.Forms.CheckBox chkDarfKK;
        private System.Windows.Forms.CheckBox chkIstKoenig;
        private System.Windows.Forms.TextBox txtAdresse;
        private System.Windows.Forms.Button btnAdresseBearbeiten;
        private System.Windows.Forms.GroupBox groupAdresse;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.ComboBox comboPistole;
  }
}