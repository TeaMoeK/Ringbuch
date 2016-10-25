namespace Ringbuch
{
    partial class Hauptfenster
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hauptfenster));
            this.dgvMaterial = new System.Windows.Forms.DataGridView();
            this.dgvErgebnisse = new System.Windows.Forms.DataGridView();
            this.dgvAlter = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtSchFest = new System.Windows.Forms.DateTimePicker();
            this.dgvNamen = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statistikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.erstellenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.löschenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.archivierteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ergebnisseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eingebenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ändernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hinzufügenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkDarfLG = new System.Windows.Forms.CheckBox();
            this.chkDarfKK = new System.Windows.Forms.CheckBox();
            this.chkIstKoenig = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtJahrgang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInfotext = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblAlterNachJahrgang = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErgebnisse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNamen)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMaterial
            // 
            this.dgvMaterial.AllowUserToAddRows = false;
            this.dgvMaterial.AllowUserToDeleteRows = false;
            this.dgvMaterial.AllowUserToResizeColumns = false;
            this.dgvMaterial.AllowUserToResizeRows = false;
            this.dgvMaterial.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterial.Location = new System.Drawing.Point(236, 43);
            this.dgvMaterial.Name = "dgvMaterial";
            this.dgvMaterial.ReadOnly = true;
            this.dgvMaterial.RowHeadersVisible = false;
            this.dgvMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterial.Size = new System.Drawing.Size(294, 112);
            this.dgvMaterial.TabIndex = 7;
            this.dgvMaterial.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvMaterial_MouseDoubleClick);
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
            this.dgvErgebnisse.Location = new System.Drawing.Point(236, 232);
            this.dgvErgebnisse.MultiSelect = false;
            this.dgvErgebnisse.Name = "dgvErgebnisse";
            this.dgvErgebnisse.ReadOnly = true;
            this.dgvErgebnisse.RowHeadersVisible = false;
            this.dgvErgebnisse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErgebnisse.Size = new System.Drawing.Size(606, 313);
            this.dgvErgebnisse.TabIndex = 11;
            this.dgvErgebnisse.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ergebnisBearbeiten);
            // 
            // dgvAlter
            // 
            this.dgvAlter.AllowUserToAddRows = false;
            this.dgvAlter.AllowUserToDeleteRows = false;
            this.dgvAlter.AllowUserToResizeColumns = false;
            this.dgvAlter.AllowUserToResizeRows = false;
            this.dgvAlter.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAlter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlter.Location = new System.Drawing.Point(236, 181);
            this.dgvAlter.MultiSelect = false;
            this.dgvAlter.Name = "dgvAlter";
            this.dgvAlter.ReadOnly = true;
            this.dgvAlter.RowHeadersVisible = false;
            this.dgvAlter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlter.Size = new System.Drawing.Size(294, 45);
            this.dgvAlter.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(579, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Schützenfest:";
            // 
            // dtSchFest
            // 
            this.dtSchFest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtSchFest.Location = new System.Drawing.Point(654, 2);
            this.dtSchFest.Name = "dtSchFest";
            this.dtSchFest.Size = new System.Drawing.Size(200, 20);
            this.dtSchFest.TabIndex = 12;
            this.dtSchFest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtSchFest_KeyPress);
            // 
            // dgvNamen
            // 
            this.dgvNamen.AllowUserToAddRows = false;
            this.dgvNamen.AllowUserToDeleteRows = false;
            this.dgvNamen.AllowUserToResizeColumns = false;
            this.dgvNamen.AllowUserToResizeRows = false;
            this.dgvNamen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvNamen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNamen.Location = new System.Drawing.Point(12, 43);
            this.dgvNamen.MultiSelect = false;
            this.dgvNamen.Name = "dgvNamen";
            this.dgvNamen.ReadOnly = true;
            this.dgvNamen.RowHeadersVisible = false;
            this.dgvNamen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNamen.Size = new System.Drawing.Size(218, 502);
            this.dgvNamen.TabIndex = 6;
            this.dgvNamen.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.profilbearbeiten);
            this.dgvNamen.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNamen_RowEnter);
            this.dgvNamen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvNamen_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem1,
            this.profilToolStripMenuItem1,
            this.dateiToolStripMenuItem,
            this.materialToolStripMenuItem1,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(854, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem1
            // 
            this.dateiToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenToolStripMenuItem,
            this.statistikToolStripMenuItem,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem1.Name = "dateiToolStripMenuItem1";
            this.dateiToolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem1.Text = "Datei";
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem});
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.serverToolStripMenuItem.Text = "Datenbank";
            this.serverToolStripMenuItem.Click += new System.EventHandler(this.SetDatabaseToXML);
            // 
            // statistikToolStripMenuItem
            // 
            this.statistikToolStripMenuItem.Name = "statistikToolStripMenuItem";
            this.statistikToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.statistikToolStripMenuItem.Text = "Statistik";
            this.statistikToolStripMenuItem.Click += new System.EventHandler(this.StatistikAufrufen);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            // 
            // profilToolStripMenuItem1
            // 
            this.profilToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.erstellenToolStripMenuItem1,
            this.bearbeitenToolStripMenuItem2,
            this.löschenToolStripMenuItem1,
            this.archivierteToolStripMenuItem});
            this.profilToolStripMenuItem1.Name = "profilToolStripMenuItem1";
            this.profilToolStripMenuItem1.Size = new System.Drawing.Size(47, 20);
            this.profilToolStripMenuItem1.Text = "Profil";
            // 
            // erstellenToolStripMenuItem1
            // 
            this.erstellenToolStripMenuItem1.Name = "erstellenToolStripMenuItem1";
            this.erstellenToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.erstellenToolStripMenuItem1.Text = "Erstellen";
            this.erstellenToolStripMenuItem1.ToolTipText = "Einen neuen Schützen anlegen";
            this.erstellenToolStripMenuItem1.Click += new System.EventHandler(this.profilErstellen);
            // 
            // bearbeitenToolStripMenuItem2
            // 
            this.bearbeitenToolStripMenuItem2.Name = "bearbeitenToolStripMenuItem2";
            this.bearbeitenToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.bearbeitenToolStripMenuItem2.Text = "Bearbeiten";
            this.bearbeitenToolStripMenuItem2.ToolTipText = "Markierten Schützen bearbeiten";
            this.bearbeitenToolStripMenuItem2.Click += new System.EventHandler(this.profilBearbeiten);
            // 
            // löschenToolStripMenuItem1
            // 
            this.löschenToolStripMenuItem1.Name = "löschenToolStripMenuItem1";
            this.löschenToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.löschenToolStripMenuItem1.Text = "Löschen";
            this.löschenToolStripMenuItem1.ToolTipText = "Markierten Schützen löschen";
            this.löschenToolStripMenuItem1.Click += new System.EventHandler(this.profilDelete);
            // 
            // archivierteToolStripMenuItem
            // 
            this.archivierteToolStripMenuItem.Name = "archivierteToolStripMenuItem";
            this.archivierteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.archivierteToolStripMenuItem.Text = "Archivierte";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ergebnisseToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.dateiToolStripMenuItem.Text = "Ergebnisse";
            // 
            // ergebnisseToolStripMenuItem
            // 
            this.ergebnisseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eingebenToolStripMenuItem,
            this.ändernToolStripMenuItem});
            this.ergebnisseToolStripMenuItem.Name = "ergebnisseToolStripMenuItem";
            this.ergebnisseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ergebnisseToolStripMenuItem.Text = "Ergebnisse";
            // 
            // eingebenToolStripMenuItem
            // 
            this.eingebenToolStripMenuItem.Name = "eingebenToolStripMenuItem";
            this.eingebenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eingebenToolStripMenuItem.Text = "Eingeben";
            this.eingebenToolStripMenuItem.ToolTipText = "Für markierten Schützen ein neues Ergebnis eingeben";
            this.eingebenToolStripMenuItem.Click += new System.EventHandler(this.eingebenToolStripMenuItem_Click);
            // 
            // ändernToolStripMenuItem
            // 
            this.ändernToolStripMenuItem.Name = "ändernToolStripMenuItem";
            this.ändernToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ändernToolStripMenuItem.Text = "Ändern";
            this.ändernToolStripMenuItem.ToolTipText = "Markiertes Ergebnis bearbeiten";
            this.ändernToolStripMenuItem.Click += new System.EventHandler(this.ergebnisBearbeiten);
            // 
            // materialToolStripMenuItem1
            // 
            this.materialToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hinzufügenToolStripMenuItem1});
            this.materialToolStripMenuItem1.Name = "materialToolStripMenuItem1";
            this.materialToolStripMenuItem1.Size = new System.Drawing.Size(62, 20);
            this.materialToolStripMenuItem1.Text = "Material";
            // 
            // hinzufügenToolStripMenuItem1
            // 
            this.hinzufügenToolStripMenuItem1.Name = "hinzufügenToolStripMenuItem1";
            this.hinzufügenToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.hinzufügenToolStripMenuItem1.Text = "Bearbeiten";
            this.hinzufügenToolStripMenuItem1.ToolTipText = "Material ändern, hinzufügen oder löschen";
            this.hinzufügenToolStripMenuItem1.Click += new System.EventHandler(this.materialBearbeitenToolStripMenuItem1_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.debugToolStripMenuItem_Click);
            // 
            // chkDarfLG
            // 
            this.chkDarfLG.AutoSize = true;
            this.chkDarfLG.Enabled = false;
            this.chkDarfLG.Location = new System.Drawing.Point(6, 19);
            this.chkDarfLG.Name = "chkDarfLG";
            this.chkDarfLG.Size = new System.Drawing.Size(63, 17);
            this.chkDarfLG.TabIndex = 17;
            this.chkDarfLG.Text = "Darf LG";
            this.chkDarfLG.UseVisualStyleBackColor = true;
            // 
            // chkDarfKK
            // 
            this.chkDarfKK.AutoSize = true;
            this.chkDarfKK.Enabled = false;
            this.chkDarfKK.Location = new System.Drawing.Point(75, 19);
            this.chkDarfKK.Name = "chkDarfKK";
            this.chkDarfKK.Size = new System.Drawing.Size(63, 17);
            this.chkDarfKK.TabIndex = 18;
            this.chkDarfKK.Text = "Darf KK";
            this.chkDarfKK.UseVisualStyleBackColor = true;
            // 
            // chkIstKoenig
            // 
            this.chkIstKoenig.AutoSize = true;
            this.chkIstKoenig.Enabled = false;
            this.chkIstKoenig.Location = new System.Drawing.Point(144, 20);
            this.chkIstKoenig.Name = "chkIstKoenig";
            this.chkIstKoenig.Size = new System.Drawing.Size(53, 17);
            this.chkIstKoenig.TabIndex = 19;
            this.chkIstKoenig.Text = "König";
            this.chkIstKoenig.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtJahrgang);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtInfotext);
            this.groupBox1.Controls.Add(this.chkDarfLG);
            this.groupBox1.Controls.Add(this.chkIstKoenig);
            this.groupBox1.Controls.Add(this.chkDarfKK);
            this.groupBox1.Location = new System.Drawing.Point(536, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 112);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Infos";
            // 
            // txtJahrgang
            // 
            this.txtJahrgang.Location = new System.Drawing.Point(203, 42);
            this.txtJahrgang.Name = "txtJahrgang";
            this.txtJahrgang.ReadOnly = true;
            this.txtJahrgang.Size = new System.Drawing.Size(62, 20);
            this.txtJahrgang.TabIndex = 22;
            this.txtJahrgang.Text = "00.00.0000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Geburtstag";
            // 
            // txtInfotext
            // 
            this.txtInfotext.Location = new System.Drawing.Point(6, 42);
            this.txtInfotext.Multiline = true;
            this.txtInfotext.Name = "txtInfotext";
            this.txtInfotext.ReadOnly = true;
            this.txtInfotext.Size = new System.Drawing.Size(191, 64);
            this.txtInfotext.TabIndex = 20;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(12, 548);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(35, 13);
            this.lblVersion.TabIndex = 21;
            this.lblVersion.Text = "label2";
            // 
            // lblAlterNachJahrgang
            // 
            this.lblAlterNachJahrgang.AutoSize = true;
            this.lblAlterNachJahrgang.Location = new System.Drawing.Point(536, 181);
            this.lblAlterNachJahrgang.Name = "lblAlterNachJahrgang";
            this.lblAlterNachJahrgang.Size = new System.Drawing.Size(105, 13);
            this.lblAlterNachJahrgang.TabIndex = 22;
            this.lblAlterNachJahrgang.Text = "Alter nach Jahrgang:";
            // 
            // Hauptfenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 561);
            this.Controls.Add(this.lblAlterNachJahrgang);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvMaterial);
            this.Controls.Add(this.dgvErgebnisse);
            this.Controls.Add(this.dgvAlter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtSchFest);
            this.Controls.Add(this.dgvNamen);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(870, 600);
            this.Name = "Hauptfenster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ringbuch";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErgebnisse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNamen)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMaterial;
        private System.Windows.Forms.DataGridView dgvErgebnisse;
        private System.Windows.Forms.DataGridView dgvAlter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtSchFest;
        private System.Windows.Forms.DataGridView dgvNamen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profilToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem erstellenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ergebnisseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eingebenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ändernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hinzufügenToolStripMenuItem1;
        private System.Windows.Forms.CheckBox chkDarfLG;
        private System.Windows.Forms.CheckBox chkDarfKK;
        private System.Windows.Forms.CheckBox chkIstKoenig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInfotext;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ToolStripMenuItem archivierteToolStripMenuItem;
        private System.Windows.Forms.TextBox txtJahrgang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem statistikToolStripMenuItem;
        private System.Windows.Forms.Label lblAlterNachJahrgang;

    }
}

