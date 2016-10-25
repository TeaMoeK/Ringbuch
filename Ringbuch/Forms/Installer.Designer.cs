namespace Ringbuch
{
    partial class Installer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Installer));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPfad = new System.Windows.Forms.TextBox();
            this.btnConCheck = new System.Windows.Forms.Button();
            this.lblConCheck = new System.Windows.Forms.Label();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOpenFileDialog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datenbank-Pfad";
            // 
            // txtPfad
            // 
            this.txtPfad.Location = new System.Drawing.Point(16, 29);
            this.txtPfad.Name = "txtPfad";
            this.txtPfad.Size = new System.Drawing.Size(261, 20);
            this.txtPfad.TabIndex = 3;
            // 
            // btnConCheck
            // 
            this.btnConCheck.Location = new System.Drawing.Point(16, 55);
            this.btnConCheck.Name = "btnConCheck";
            this.btnConCheck.Size = new System.Drawing.Size(75, 23);
            this.btnConCheck.TabIndex = 8;
            this.btnConCheck.Text = "Prüfen";
            this.btnConCheck.UseVisualStyleBackColor = true;
            // 
            // lblConCheck
            // 
            this.lblConCheck.AutoSize = true;
            this.lblConCheck.Location = new System.Drawing.Point(43, 81);
            this.lblConCheck.Name = "lblConCheck";
            this.lblConCheck.Size = new System.Drawing.Size(16, 13);
            this.lblConCheck.TabIndex = 9;
            this.lblConCheck.Text = "...";
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(121, 55);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(75, 23);
            this.btnInstall.TabIndex = 6;
            this.btnInstall.Text = "Installieren";
            this.btnInstall.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(202, 55);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOpenFileDialog
            // 
            this.btnOpenFileDialog.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpenFileDialog.BackgroundImage")));
            this.btnOpenFileDialog.Location = new System.Drawing.Point(283, 29);
            this.btnOpenFileDialog.Name = "btnOpenFileDialog";
            this.btnOpenFileDialog.Size = new System.Drawing.Size(20, 20);
            this.btnOpenFileDialog.TabIndex = 10;
            this.btnOpenFileDialog.UseVisualStyleBackColor = true;
            this.btnOpenFileDialog.Click += new System.EventHandler(this.btnOpenFileDialog_Click);
            // 
            // Installer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 106);
            this.ControlBox = false;
            this.Controls.Add(this.btnOpenFileDialog);
            this.Controls.Add(this.lblConCheck);
            this.Controls.Add(this.btnConCheck);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.txtPfad);
            this.Controls.Add(this.label1);
            this.HelpButton = true;
            this.Name = "Installer";
            this.Text = "Installer";
            this.Load += new System.EventHandler(this.Installer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPfad;
        private System.Windows.Forms.Button btnConCheck;
        private System.Windows.Forms.Label lblConCheck;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOpenFileDialog;
    }
}