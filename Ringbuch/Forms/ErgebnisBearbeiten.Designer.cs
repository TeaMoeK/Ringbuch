namespace Ringbuch
{
    partial class ErgebnisBearbeiten
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
            this.txtSatz1 = new System.Windows.Forms.TextBox();
            this.txtSatz2 = new System.Windows.Forms.TextBox();
            this.txtSatz3 = new System.Windows.Forms.TextBox();
            this.txtSatz4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateDatum = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVorname = new System.Windows.Forms.TextBox();
            this.txtZweitname = new System.Windows.Forms.TextBox();
            this.txtNachname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.comboArt = new System.Windows.Forms.ComboBox();
            this.btnSchiessartNeu = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSatz1
            // 
            this.txtSatz1.Location = new System.Drawing.Point(12, 112);
            this.txtSatz1.Name = "txtSatz1";
            this.txtSatz1.Size = new System.Drawing.Size(60, 20);
            this.txtSatz1.TabIndex = 1;
            this.txtSatz1.Text = "0";
            this.txtSatz1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumbersOnly);
            this.txtSatz1.Leave += new System.EventHandler(this.InsertZero);
            // 
            // txtSatz2
            // 
            this.txtSatz2.Location = new System.Drawing.Point(12, 151);
            this.txtSatz2.Name = "txtSatz2";
            this.txtSatz2.Size = new System.Drawing.Size(60, 20);
            this.txtSatz2.TabIndex = 2;
            this.txtSatz2.Text = "0";
            this.txtSatz2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumbersOnly);
            this.txtSatz2.Leave += new System.EventHandler(this.InsertZero);
            // 
            // txtSatz3
            // 
            this.txtSatz3.Location = new System.Drawing.Point(12, 190);
            this.txtSatz3.Name = "txtSatz3";
            this.txtSatz3.Size = new System.Drawing.Size(60, 20);
            this.txtSatz3.TabIndex = 3;
            this.txtSatz3.Text = "0";
            this.txtSatz3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumbersOnly);
            this.txtSatz3.Leave += new System.EventHandler(this.InsertZero);
            // 
            // txtSatz4
            // 
            this.txtSatz4.Location = new System.Drawing.Point(12, 229);
            this.txtSatz4.Name = "txtSatz4";
            this.txtSatz4.Size = new System.Drawing.Size(60, 20);
            this.txtSatz4.TabIndex = 4;
            this.txtSatz4.Text = "0";
            this.txtSatz4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumbersOnly);
            this.txtSatz4.Leave += new System.EventHandler(this.InsertZero);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Satz 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Satz 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Satz 3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Satz 4";
            // 
            // dateDatum
            // 
            this.dateDatum.Location = new System.Drawing.Point(12, 73);
            this.dateDatum.Name = "dateDatum";
            this.dateDatum.Size = new System.Drawing.Size(200, 20);
            this.dateDatum.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Datum";
            // 
            // txtVorname
            // 
            this.txtVorname.Location = new System.Drawing.Point(12, 31);
            this.txtVorname.Name = "txtVorname";
            this.txtVorname.ReadOnly = true;
            this.txtVorname.Size = new System.Drawing.Size(100, 20);
            this.txtVorname.TabIndex = 9;
            // 
            // txtZweitname
            // 
            this.txtZweitname.Location = new System.Drawing.Point(118, 31);
            this.txtZweitname.Name = "txtZweitname";
            this.txtZweitname.ReadOnly = true;
            this.txtZweitname.Size = new System.Drawing.Size(100, 20);
            this.txtZweitname.TabIndex = 10;
            // 
            // txtNachname
            // 
            this.txtNachname.Location = new System.Drawing.Point(224, 31);
            this.txtNachname.Name = "txtNachname";
            this.txtNachname.ReadOnly = true;
            this.txtNachname.Size = new System.Drawing.Size(100, 20);
            this.txtNachname.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Vorname";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(118, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Zweitname";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(224, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Nachname";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(112, 190);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(212, 59);
            this.txtInfo.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(109, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Info";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(9, 336);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(91, 336);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(249, 336);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Löschen";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // comboArt
            // 
            this.comboArt.FormattingEnabled = true;
            this.comboArt.Location = new System.Drawing.Point(6, 19);
            this.comboArt.Name = "comboArt";
            this.comboArt.Size = new System.Drawing.Size(121, 21);
            this.comboArt.TabIndex = 0;
            // 
            // btnSchiessartNeu
            // 
            this.btnSchiessartNeu.Location = new System.Drawing.Point(133, 20);
            this.btnSchiessartNeu.Name = "btnSchiessartNeu";
            this.btnSchiessartNeu.Size = new System.Drawing.Size(55, 20);
            this.btnSchiessartNeu.TabIndex = 1;
            this.btnSchiessartNeu.Text = "Neu";
            this.btnSchiessartNeu.UseVisualStyleBackColor = true;
            this.btnSchiessartNeu.Click += new System.EventHandler(this.schiessartNeu);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Löschen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.schiessartDelete);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboArt);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnSchiessartNeu);
            this.groupBox1.Location = new System.Drawing.Point(12, 255);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 52);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Art";
            // 
            // ErgebnisBearbeiten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 369);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNachname);
            this.Controls.Add(this.txtZweitname);
            this.Controls.Add(this.txtVorname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateDatum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSatz4);
            this.Controls.Add(this.txtSatz3);
            this.Controls.Add(this.txtSatz2);
            this.Controls.Add(this.txtSatz1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErgebnisBearbeiten";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ErgebnisBearbeiten";
            this.Load += new System.EventHandler(this.ErgebnisBearbeiten_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSatz1;
        private System.Windows.Forms.TextBox txtSatz2;
        private System.Windows.Forms.TextBox txtSatz3;
        private System.Windows.Forms.TextBox txtSatz4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateDatum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVorname;
        private System.Windows.Forms.TextBox txtZweitname;
        private System.Windows.Forms.TextBox txtNachname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox comboArt;
        private System.Windows.Forms.Button btnSchiessartNeu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}