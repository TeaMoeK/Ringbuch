namespace Ringbuch
{
    partial class StatistikTool
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
            this.dgvErgebnisse = new System.Windows.Forms.DataGridView();
            this.dtVon = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboSchiessart = new System.Windows.Forms.ComboBox();
            this.lvlBis = new System.Windows.Forms.Label();
            this.dtBis = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNurVom = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvAuswertung = new System.Windows.Forms.DataGridView();
            this.txtKlartext = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErgebnisse)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuswertung)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvErgebnisse
            // 
            this.dgvErgebnisse.AllowUserToAddRows = false;
            this.dgvErgebnisse.AllowUserToDeleteRows = false;
            this.dgvErgebnisse.AllowUserToResizeColumns = false;
            this.dgvErgebnisse.AllowUserToResizeRows = false;
            this.dgvErgebnisse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvErgebnisse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErgebnisse.Location = new System.Drawing.Point(278, 12);
            this.dgvErgebnisse.Name = "dgvErgebnisse";
            this.dgvErgebnisse.ReadOnly = true;
            this.dgvErgebnisse.RowHeadersVisible = false;
            this.dgvErgebnisse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErgebnisse.Size = new System.Drawing.Size(786, 500);
            this.dgvErgebnisse.TabIndex = 0;
            // 
            // dtVon
            // 
            this.dtVon.Location = new System.Drawing.Point(37, 16);
            this.dtVon.Name = "dtVon";
            this.dtVon.Size = new System.Drawing.Size(200, 20);
            this.dtVon.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtBox);
            this.groupBox2.Controls.Add(this.txtKey);
            this.groupBox2.Controls.Add(this.txtKlartext);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboSchiessart);
            this.groupBox2.Controls.Add(this.lvlBis);
            this.groupBox2.Controls.Add(this.dtBis);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnNurVom);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.dtVon);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 588);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ergebnisse anzeigen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Schiessart";
            // 
            // comboSchiessart
            // 
            this.comboSchiessart.FormattingEnabled = true;
            this.comboSchiessart.Location = new System.Drawing.Point(68, 67);
            this.comboSchiessart.Name = "comboSchiessart";
            this.comboSchiessart.Size = new System.Drawing.Size(119, 21);
            this.comboSchiessart.TabIndex = 10;
            // 
            // lvlBis
            // 
            this.lvlBis.AutoSize = true;
            this.lvlBis.Location = new System.Drawing.Point(11, 41);
            this.lvlBis.Name = "lvlBis";
            this.lvlBis.Size = new System.Drawing.Size(20, 13);
            this.lvlBis.TabIndex = 9;
            this.lvlBis.Text = "bis";
            // 
            // dtBis
            // 
            this.dtBis.Location = new System.Drawing.Point(37, 41);
            this.dtBis.Name = "dtBis";
            this.dtBis.Size = new System.Drawing.Size(200, 20);
            this.dtBis.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Von";
            // 
            // btnNurVom
            // 
            this.btnNurVom.Location = new System.Drawing.Point(155, 94);
            this.btnNurVom.Name = "btnNurVom";
            this.btnNurVom.Size = new System.Drawing.Size(82, 23);
            this.btnNurVom.TabIndex = 6;
            this.btnNurVom.Text = "Anzeigen";
            this.btnNurVom.UseVisualStyleBackColor = true;
            this.btnNurVom.Click += new System.EventHandler(this.click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(155, 123);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(82, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Zurücksetzen";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.Reset);
            // 
            // dgvAuswertung
            // 
            this.dgvAuswertung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuswertung.Location = new System.Drawing.Point(278, 518);
            this.dgvAuswertung.Name = "dgvAuswertung";
            this.dgvAuswertung.Size = new System.Drawing.Size(786, 82);
            this.dgvAuswertung.TabIndex = 6;
            // 
            // txtKlartext
            // 
            this.txtKlartext.Location = new System.Drawing.Point(6, 182);
            this.txtKlartext.Name = "txtKlartext";
            this.txtKlartext.Size = new System.Drawing.Size(100, 20);
            this.txtKlartext.TabIndex = 12;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(6, 208);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(100, 20);
            this.txtKey.TabIndex = 13;
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(6, 234);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(100, 20);
            this.txtBox.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Klick";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StatistikTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 612);
            this.Controls.Add(this.dgvAuswertung);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvErgebnisse);
            this.Name = "StatistikTool";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StatistikTool";
            this.Load += new System.EventHandler(this.StatistikTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErgebnisse)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuswertung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvErgebnisse;
        private System.Windows.Forms.DateTimePicker dtVon;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lvlBis;
        private System.Windows.Forms.DateTimePicker dtBis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNurVom;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboSchiessart;
        private System.Windows.Forms.DataGridView dgvAuswertung;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtKlartext;
    }
}