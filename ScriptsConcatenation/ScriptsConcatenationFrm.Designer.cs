namespace ScriptsConcatenation
{
    partial class ScriptsConcatenationFrm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ScriptsBrowser = new System.Windows.Forms.OpenFileDialog();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.ScriptsPath = new System.Windows.Forms.TextBox();
            this.BtnConcat = new System.Windows.Forms.Button();
            this.GeneratedFileDescription = new System.Windows.Forms.RichTextBox();
            this.BtnDownload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ScriptsBrowser
            // 
            this.ScriptsBrowser.Filter = "Sql script file|*.sql";
            this.ScriptsBrowser.Multiselect = true;
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Location = new System.Drawing.Point(41, 53);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(53, 23);
            this.BtnBrowse.TabIndex = 0;
            this.BtnBrowse.Text = "Browse";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // ScriptsPath
            // 
            this.ScriptsPath.Location = new System.Drawing.Point(118, 55);
            this.ScriptsPath.Name = "ScriptsPath";
            this.ScriptsPath.ReadOnly = true;
            this.ScriptsPath.Size = new System.Drawing.Size(252, 20);
            this.ScriptsPath.TabIndex = 1;
            // 
            // BtnConcat
            // 
            this.BtnConcat.Enabled = false;
            this.BtnConcat.Location = new System.Drawing.Point(164, 137);
            this.BtnConcat.Name = "BtnConcat";
            this.BtnConcat.Size = new System.Drawing.Size(75, 23);
            this.BtnConcat.TabIndex = 2;
            this.BtnConcat.Text = "Concat";
            this.BtnConcat.UseVisualStyleBackColor = true;
            // 
            // GeneratedFileDescription
            // 
            this.GeneratedFileDescription.Enabled = false;
            this.GeneratedFileDescription.Location = new System.Drawing.Point(41, 166);
            this.GeneratedFileDescription.Name = "GeneratedFileDescription";
            this.GeneratedFileDescription.ReadOnly = true;
            this.GeneratedFileDescription.Size = new System.Drawing.Size(329, 96);
            this.GeneratedFileDescription.TabIndex = 3;
            this.GeneratedFileDescription.Text = "";
            // 
            // BtnDownload
            // 
            this.BtnDownload.Enabled = false;
            this.BtnDownload.Location = new System.Drawing.Point(164, 268);
            this.BtnDownload.Name = "BtnDownload";
            this.BtnDownload.Size = new System.Drawing.Size(75, 23);
            this.BtnDownload.TabIndex = 4;
            this.BtnDownload.Text = "Download";
            this.BtnDownload.UseVisualStyleBackColor = true;
            // 
            // ScriptsConcatenationFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 307);
            this.Controls.Add(this.BtnDownload);
            this.Controls.Add(this.GeneratedFileDescription);
            this.Controls.Add(this.BtnConcat);
            this.Controls.Add(this.ScriptsPath);
            this.Controls.Add(this.BtnBrowse);
            this.Name = "ScriptsConcatenationFrm";
            this.Text = "Scripts Concatenator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ScriptsBrowser;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.TextBox ScriptsPath;
        private System.Windows.Forms.Button BtnConcat;
        private System.Windows.Forms.RichTextBox GeneratedFileDescription;
        private System.Windows.Forms.Button BtnDownload;
    }
}

