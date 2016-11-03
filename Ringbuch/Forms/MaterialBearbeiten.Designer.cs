namespace Ringbuch
{
    partial class MaterialBearbeiten
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
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboLG = new System.Windows.Forms.ComboBox();
            this.comboKK = new System.Windows.Forms.ComboBox();
            this.comboJacken = new System.Windows.Forms.ComboBox();
            this.comboHandschuhe = new System.Windows.Forms.ComboBox();
            this.btnHandschuhInsert = new System.Windows.Forms.Button();
            this.btnHandschuhDelete = new System.Windows.Forms.Button();
            this.btnJackeDelete = new System.Windows.Forms.Button();
            this.btnJackeInsert = new System.Windows.Forms.Button();
            this.btnKKDelete = new System.Windows.Forms.Button();
            this.btnKKInsert = new System.Windows.Forms.Button();
            this.btnLGDelete = new System.Windows.Forms.Button();
            this.btnLGInsert = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnHandschuhUpdate = new System.Windows.Forms.Button();
            this.btnJackeUpdate = new System.Windows.Forms.Button();
            this.btnKKUpdate = new System.Windows.Forms.Button();
            this.btnLGUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHandschuhBezeichnung = new System.Windows.Forms.TextBox();
            this.txtJackeBezeichnung = new System.Windows.Forms.TextBox();
            this.txtKleinkaliberBezeichnung = new System.Windows.Forms.TextBox();
            this.txtHandschuhLangtext = new System.Windows.Forms.TextBox();
            this.txtLuftgewehrBezeichnung = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJackeLangtext = new System.Windows.Forms.TextBox();
            this.txtHandschuhGroesse = new System.Windows.Forms.TextBox();
            this.txtJackeGroesse = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKleinkaliberLangtext = new System.Windows.Forms.TextBox();
            this.txtKleinkaliberGroesse = new System.Windows.Forms.TextBox();
            this.txtLuftgewehrGroesse = new System.Windows.Forms.TextBox();
            this.txtLuftgewehrLangtext = new System.Windows.Forms.TextBox();
            this.groupTextBoxes = new System.Windows.Forms.GroupBox();
            this.groupTextBoxes.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Luftgewehr";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Kleinkaliber";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Jacke";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Handschuh";
            // 
            // comboLG
            // 
            this.comboLG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLG.FormattingEnabled = true;
            this.comboLG.Location = new System.Drawing.Point(14, 151);
            this.comboLG.Name = "comboLG";
            this.comboLG.Size = new System.Drawing.Size(121, 21);
            this.comboLG.TabIndex = 21;
            this.comboLG.TabStop = false;
            this.comboLG.Tag = "Luftgewehr";
            this.comboLG.SelectedIndexChanged += new System.EventHandler(this.SelectionToTextBox2);
            // 
            // comboKK
            // 
            this.comboKK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboKK.FormattingEnabled = true;
            this.comboKK.Location = new System.Drawing.Point(14, 111);
            this.comboKK.Name = "comboKK";
            this.comboKK.Size = new System.Drawing.Size(121, 21);
            this.comboKK.TabIndex = 14;
            this.comboKK.TabStop = false;
            this.comboKK.Tag = "Kleinkaliber";
            this.comboKK.SelectedIndexChanged += new System.EventHandler(this.SelectionToTextBox2);
            // 
            // comboJacken
            // 
            this.comboJacken.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboJacken.FormattingEnabled = true;
            this.comboJacken.Location = new System.Drawing.Point(14, 72);
            this.comboJacken.Name = "comboJacken";
            this.comboJacken.Size = new System.Drawing.Size(121, 21);
            this.comboJacken.TabIndex = 7;
            this.comboJacken.TabStop = false;
            this.comboJacken.Tag = "Jacke";
            this.comboJacken.SelectedIndexChanged += new System.EventHandler(this.SelectionToTextBox2);
            // 
            // comboHandschuhe
            // 
            this.comboHandschuhe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHandschuhe.FormattingEnabled = true;
            this.comboHandschuhe.Location = new System.Drawing.Point(14, 34);
            this.comboHandschuhe.Name = "comboHandschuhe";
            this.comboHandschuhe.Size = new System.Drawing.Size(121, 21);
            this.comboHandschuhe.TabIndex = 0;
            this.comboHandschuhe.TabStop = false;
            this.comboHandschuhe.Tag = "Handschuh";
            this.comboHandschuhe.SelectedIndexChanged += new System.EventHandler(this.SelectionToTextBox2);
            // 
            // btnHandschuhInsert
            // 
            this.btnHandschuhInsert.Location = new System.Drawing.Point(478, 34);
            this.btnHandschuhInsert.Name = "btnHandschuhInsert";
            this.btnHandschuhInsert.Size = new System.Drawing.Size(75, 23);
            this.btnHandschuhInsert.TabIndex = 4;
            this.btnHandschuhInsert.TabStop = false;
            this.btnHandschuhInsert.Text = "Hinzufügen";
            this.btnHandschuhInsert.UseVisualStyleBackColor = true;
            this.btnHandschuhInsert.Click += new System.EventHandler(this.MaterialInsert);
            // 
            // btnHandschuhDelete
            // 
            this.btnHandschuhDelete.Location = new System.Drawing.Point(640, 34);
            this.btnHandschuhDelete.Name = "btnHandschuhDelete";
            this.btnHandschuhDelete.Size = new System.Drawing.Size(75, 23);
            this.btnHandschuhDelete.TabIndex = 6;
            this.btnHandschuhDelete.TabStop = false;
            this.btnHandschuhDelete.Text = "Löschen";
            this.btnHandschuhDelete.UseVisualStyleBackColor = true;
            this.btnHandschuhDelete.Click += new System.EventHandler(this.delete);
            // 
            // btnJackeDelete
            // 
            this.btnJackeDelete.Location = new System.Drawing.Point(640, 72);
            this.btnJackeDelete.Name = "btnJackeDelete";
            this.btnJackeDelete.Size = new System.Drawing.Size(75, 23);
            this.btnJackeDelete.TabIndex = 13;
            this.btnJackeDelete.TabStop = false;
            this.btnJackeDelete.Text = "Löschen";
            this.btnJackeDelete.UseVisualStyleBackColor = true;
            this.btnJackeDelete.Click += new System.EventHandler(this.delete);
            // 
            // btnJackeInsert
            // 
            this.btnJackeInsert.Location = new System.Drawing.Point(478, 72);
            this.btnJackeInsert.Name = "btnJackeInsert";
            this.btnJackeInsert.Size = new System.Drawing.Size(75, 23);
            this.btnJackeInsert.TabIndex = 11;
            this.btnJackeInsert.TabStop = false;
            this.btnJackeInsert.Text = "Hinzufügen";
            this.btnJackeInsert.UseVisualStyleBackColor = true;
            this.btnJackeInsert.Click += new System.EventHandler(this.MaterialInsert);
            // 
            // btnKKDelete
            // 
            this.btnKKDelete.Location = new System.Drawing.Point(640, 111);
            this.btnKKDelete.Name = "btnKKDelete";
            this.btnKKDelete.Size = new System.Drawing.Size(75, 23);
            this.btnKKDelete.TabIndex = 20;
            this.btnKKDelete.TabStop = false;
            this.btnKKDelete.Text = "Löschen";
            this.btnKKDelete.UseVisualStyleBackColor = true;
            this.btnKKDelete.Click += new System.EventHandler(this.delete);
            // 
            // btnKKInsert
            // 
            this.btnKKInsert.Location = new System.Drawing.Point(478, 111);
            this.btnKKInsert.Name = "btnKKInsert";
            this.btnKKInsert.Size = new System.Drawing.Size(75, 23);
            this.btnKKInsert.TabIndex = 18;
            this.btnKKInsert.TabStop = false;
            this.btnKKInsert.Text = "Hinzufügen";
            this.btnKKInsert.UseVisualStyleBackColor = true;
            this.btnKKInsert.Click += new System.EventHandler(this.MaterialInsert);
            // 
            // btnLGDelete
            // 
            this.btnLGDelete.Location = new System.Drawing.Point(640, 151);
            this.btnLGDelete.Name = "btnLGDelete";
            this.btnLGDelete.Size = new System.Drawing.Size(75, 23);
            this.btnLGDelete.TabIndex = 27;
            this.btnLGDelete.TabStop = false;
            this.btnLGDelete.Text = "Löschen";
            this.btnLGDelete.UseVisualStyleBackColor = true;
            this.btnLGDelete.Click += new System.EventHandler(this.delete);
            // 
            // btnLGInsert
            // 
            this.btnLGInsert.Location = new System.Drawing.Point(478, 151);
            this.btnLGInsert.Name = "btnLGInsert";
            this.btnLGInsert.Size = new System.Drawing.Size(75, 23);
            this.btnLGInsert.TabIndex = 25;
            this.btnLGInsert.TabStop = false;
            this.btnLGInsert.Text = "Hinzufügen";
            this.btnLGInsert.UseVisualStyleBackColor = true;
            this.btnLGInsert.Click += new System.EventHandler(this.MaterialInsert);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(14, 190);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Beenden";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.beenden);
            // 
            // btnHandschuhUpdate
            // 
            this.btnHandschuhUpdate.Location = new System.Drawing.Point(559, 34);
            this.btnHandschuhUpdate.Name = "btnHandschuhUpdate";
            this.btnHandschuhUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnHandschuhUpdate.TabIndex = 5;
            this.btnHandschuhUpdate.TabStop = false;
            this.btnHandschuhUpdate.Text = "Ändern";
            this.btnHandschuhUpdate.UseVisualStyleBackColor = true;
            this.btnHandschuhUpdate.Click += new System.EventHandler(this.MaterialUpdate);
            // 
            // btnJackeUpdate
            // 
            this.btnJackeUpdate.Location = new System.Drawing.Point(559, 72);
            this.btnJackeUpdate.Name = "btnJackeUpdate";
            this.btnJackeUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnJackeUpdate.TabIndex = 12;
            this.btnJackeUpdate.TabStop = false;
            this.btnJackeUpdate.Text = "Ändern";
            this.btnJackeUpdate.UseVisualStyleBackColor = true;
            this.btnJackeUpdate.Click += new System.EventHandler(this.MaterialUpdate);
            // 
            // btnKKUpdate
            // 
            this.btnKKUpdate.Location = new System.Drawing.Point(559, 111);
            this.btnKKUpdate.Name = "btnKKUpdate";
            this.btnKKUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnKKUpdate.TabIndex = 19;
            this.btnKKUpdate.TabStop = false;
            this.btnKKUpdate.Text = "Ändern";
            this.btnKKUpdate.UseVisualStyleBackColor = true;
            this.btnKKUpdate.Click += new System.EventHandler(this.MaterialUpdate);
            // 
            // btnLGUpdate
            // 
            this.btnLGUpdate.Location = new System.Drawing.Point(559, 151);
            this.btnLGUpdate.Name = "btnLGUpdate";
            this.btnLGUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnLGUpdate.TabIndex = 26;
            this.btnLGUpdate.TabStop = false;
            this.btnLGUpdate.Text = "Ändern";
            this.btnLGUpdate.UseVisualStyleBackColor = true;
            this.btnLGUpdate.Click += new System.EventHandler(this.MaterialUpdate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Bezeichnung";
            // 
            // txtHandschuhBezeichnung
            // 
            this.txtHandschuhBezeichnung.Location = new System.Drawing.Point(9, 34);
            this.txtHandschuhBezeichnung.Name = "txtHandschuhBezeichnung";
            this.txtHandschuhBezeichnung.Size = new System.Drawing.Size(100, 20);
            this.txtHandschuhBezeichnung.TabIndex = 1;
            this.txtHandschuhBezeichnung.Tag = "Handschuh";
            // 
            // txtJackeBezeichnung
            // 
            this.txtJackeBezeichnung.Location = new System.Drawing.Point(9, 72);
            this.txtJackeBezeichnung.Name = "txtJackeBezeichnung";
            this.txtJackeBezeichnung.Size = new System.Drawing.Size(100, 20);
            this.txtJackeBezeichnung.TabIndex = 8;
            // 
            // txtKleinkaliberBezeichnung
            // 
            this.txtKleinkaliberBezeichnung.Location = new System.Drawing.Point(9, 111);
            this.txtKleinkaliberBezeichnung.Name = "txtKleinkaliberBezeichnung";
            this.txtKleinkaliberBezeichnung.Size = new System.Drawing.Size(100, 20);
            this.txtKleinkaliberBezeichnung.TabIndex = 15;
            // 
            // txtHandschuhLangtext
            // 
            this.txtHandschuhLangtext.Location = new System.Drawing.Point(115, 34);
            this.txtHandschuhLangtext.Name = "txtHandschuhLangtext";
            this.txtHandschuhLangtext.Size = new System.Drawing.Size(100, 20);
            this.txtHandschuhLangtext.TabIndex = 2;
            this.txtHandschuhLangtext.Tag = "Handschuh";
            // 
            // txtLuftgewehrBezeichnung
            // 
            this.txtLuftgewehrBezeichnung.Location = new System.Drawing.Point(10, 151);
            this.txtLuftgewehrBezeichnung.Name = "txtLuftgewehrBezeichnung";
            this.txtLuftgewehrBezeichnung.Size = new System.Drawing.Size(100, 20);
            this.txtLuftgewehrBezeichnung.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Größe";
            // 
            // txtJackeLangtext
            // 
            this.txtJackeLangtext.Location = new System.Drawing.Point(116, 72);
            this.txtJackeLangtext.Name = "txtJackeLangtext";
            this.txtJackeLangtext.Size = new System.Drawing.Size(100, 20);
            this.txtJackeLangtext.TabIndex = 9;
            // 
            // txtHandschuhGroesse
            // 
            this.txtHandschuhGroesse.Location = new System.Drawing.Point(221, 34);
            this.txtHandschuhGroesse.Name = "txtHandschuhGroesse";
            this.txtHandschuhGroesse.Size = new System.Drawing.Size(100, 20);
            this.txtHandschuhGroesse.TabIndex = 3;
            this.txtHandschuhGroesse.Tag = "Handschuh";
            // 
            // txtJackeGroesse
            // 
            this.txtJackeGroesse.Location = new System.Drawing.Point(222, 72);
            this.txtJackeGroesse.Name = "txtJackeGroesse";
            this.txtJackeGroesse.Size = new System.Drawing.Size(100, 20);
            this.txtJackeGroesse.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Langtext";
            // 
            // txtKleinkaliberLangtext
            // 
            this.txtKleinkaliberLangtext.Location = new System.Drawing.Point(116, 111);
            this.txtKleinkaliberLangtext.Name = "txtKleinkaliberLangtext";
            this.txtKleinkaliberLangtext.Size = new System.Drawing.Size(100, 20);
            this.txtKleinkaliberLangtext.TabIndex = 16;
            // 
            // txtKleinkaliberGroesse
            // 
            this.txtKleinkaliberGroesse.Location = new System.Drawing.Point(222, 111);
            this.txtKleinkaliberGroesse.Name = "txtKleinkaliberGroesse";
            this.txtKleinkaliberGroesse.Size = new System.Drawing.Size(100, 20);
            this.txtKleinkaliberGroesse.TabIndex = 17;
            // 
            // txtLuftgewehrGroesse
            // 
            this.txtLuftgewehrGroesse.Location = new System.Drawing.Point(222, 151);
            this.txtLuftgewehrGroesse.Name = "txtLuftgewehrGroesse";
            this.txtLuftgewehrGroesse.Size = new System.Drawing.Size(100, 20);
            this.txtLuftgewehrGroesse.TabIndex = 24;
            // 
            // txtLuftgewehrLangtext
            // 
            this.txtLuftgewehrLangtext.Location = new System.Drawing.Point(116, 151);
            this.txtLuftgewehrLangtext.Name = "txtLuftgewehrLangtext";
            this.txtLuftgewehrLangtext.Size = new System.Drawing.Size(100, 20);
            this.txtLuftgewehrLangtext.TabIndex = 23;
            // 
            // groupTextBoxes
            // 
            this.groupTextBoxes.Controls.Add(this.label1);
            this.groupTextBoxes.Controls.Add(this.txtLuftgewehrLangtext);
            this.groupTextBoxes.Controls.Add(this.txtHandschuhBezeichnung);
            this.groupTextBoxes.Controls.Add(this.txtLuftgewehrGroesse);
            this.groupTextBoxes.Controls.Add(this.txtJackeBezeichnung);
            this.groupTextBoxes.Controls.Add(this.txtKleinkaliberGroesse);
            this.groupTextBoxes.Controls.Add(this.txtKleinkaliberBezeichnung);
            this.groupTextBoxes.Controls.Add(this.txtKleinkaliberLangtext);
            this.groupTextBoxes.Controls.Add(this.txtHandschuhLangtext);
            this.groupTextBoxes.Controls.Add(this.label2);
            this.groupTextBoxes.Controls.Add(this.txtLuftgewehrBezeichnung);
            this.groupTextBoxes.Controls.Add(this.txtJackeGroesse);
            this.groupTextBoxes.Controls.Add(this.label3);
            this.groupTextBoxes.Controls.Add(this.txtHandschuhGroesse);
            this.groupTextBoxes.Controls.Add(this.txtJackeLangtext);
            this.groupTextBoxes.Location = new System.Drawing.Point(141, 3);
            this.groupTextBoxes.Name = "groupTextBoxes";
            this.groupTextBoxes.Size = new System.Drawing.Size(331, 179);
            this.groupTextBoxes.TabIndex = 36;
            this.groupTextBoxes.TabStop = false;
            // 
            // MaterialBearbeiten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 227);
            this.Controls.Add(this.groupTextBoxes);
            this.Controls.Add(this.comboHandschuhe);
            this.Controls.Add(this.btnLGUpdate);
            this.Controls.Add(this.btnKKUpdate);
            this.Controls.Add(this.btnJackeUpdate);
            this.Controls.Add(this.btnHandschuhUpdate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLGDelete);
            this.Controls.Add(this.btnLGInsert);
            this.Controls.Add(this.btnKKDelete);
            this.Controls.Add(this.btnKKInsert);
            this.Controls.Add(this.btnJackeDelete);
            this.Controls.Add(this.btnJackeInsert);
            this.Controls.Add(this.btnHandschuhDelete);
            this.Controls.Add(this.btnHandschuhInsert);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboLG);
            this.Controls.Add(this.comboKK);
            this.Controls.Add(this.comboJacken);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialBearbeiten";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Material";
            this.Load += new System.EventHandler(this.MaterialBearbeiten_Load);
            this.groupTextBoxes.ResumeLayout(false);
            this.groupTextBoxes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboLG;
        private System.Windows.Forms.ComboBox comboKK;
        private System.Windows.Forms.ComboBox comboJacken;
        private System.Windows.Forms.ComboBox comboHandschuhe;
        private System.Windows.Forms.Button btnHandschuhInsert;
        private System.Windows.Forms.Button btnHandschuhDelete;
        private System.Windows.Forms.Button btnJackeDelete;
        private System.Windows.Forms.Button btnJackeInsert;
        private System.Windows.Forms.Button btnKKDelete;
        private System.Windows.Forms.Button btnKKInsert;
        private System.Windows.Forms.Button btnLGDelete;
        private System.Windows.Forms.Button btnLGInsert;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnHandschuhUpdate;
        private System.Windows.Forms.Button btnJackeUpdate;
        private System.Windows.Forms.Button btnKKUpdate;
        private System.Windows.Forms.Button btnLGUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHandschuhBezeichnung;
        private System.Windows.Forms.TextBox txtJackeBezeichnung;
        private System.Windows.Forms.TextBox txtKleinkaliberBezeichnung;
        private System.Windows.Forms.TextBox txtHandschuhLangtext;
        private System.Windows.Forms.TextBox txtLuftgewehrBezeichnung;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJackeLangtext;
        private System.Windows.Forms.TextBox txtHandschuhGroesse;
        private System.Windows.Forms.TextBox txtJackeGroesse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKleinkaliberLangtext;
        private System.Windows.Forms.TextBox txtKleinkaliberGroesse;
        private System.Windows.Forms.TextBox txtLuftgewehrGroesse;
        private System.Windows.Forms.TextBox txtLuftgewehrLangtext;
        private System.Windows.Forms.GroupBox groupTextBoxes;
    }
}