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
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnConcat = new System.Windows.Forms.Button();
            this.BtnDownload = new System.Windows.Forms.Button();
            this.ScriptsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ScriptsBrowser
            // 
            this.ScriptsBrowser.Filter = "Sql script file|*.sql";
            this.ScriptsBrowser.Multiselect = true;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(99, 172);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(84, 23);
            this.BtnAdd.TabIndex = 0;
            this.BtnAdd.Text = "Add scripts";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // BtnConcat
            // 
            this.BtnConcat.Enabled = false;
            this.BtnConcat.Location = new System.Drawing.Point(164, 213);
            this.BtnConcat.Name = "BtnConcat";
            this.BtnConcat.Size = new System.Drawing.Size(75, 23);
            this.BtnConcat.TabIndex = 2;
            this.BtnConcat.Text = "Concat";
            this.BtnConcat.UseVisualStyleBackColor = true;
            this.BtnConcat.Click += new System.EventHandler(this.BtnConcat_Click);
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
            this.BtnDownload.Click += new System.EventHandler(this.BtnDownload_Click);
            // 
            // ScriptsList
            // 
            this.ScriptsList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ScriptsList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ScriptsList.CausesValidation = false;
            this.ScriptsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.ScriptsList.GridLines = true;
            this.ScriptsList.HideSelection = false;
            this.ScriptsList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ScriptsList.Location = new System.Drawing.Point(12, 12);
            this.ScriptsList.Name = "ScriptsList";
            this.ScriptsList.ShowItemToolTips = true;
            this.ScriptsList.Size = new System.Drawing.Size(377, 144);
            this.ScriptsList.TabIndex = 5;
            this.ScriptsList.TileSize = new System.Drawing.Size(300, 20);
            this.ScriptsList.UseCompatibleStateImageBehavior = false;
            this.ScriptsList.View = System.Windows.Forms.View.Details;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Enabled = false;
            this.BtnDelete.Location = new System.Drawing.Point(232, 172);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(84, 23);
            this.BtnDelete.TabIndex = 6;
            this.BtnDelete.Text = "Delete scripts";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // ScriptsConcatenationFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 307);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.ScriptsList);
            this.Controls.Add(this.BtnDownload);
            this.Controls.Add(this.BtnConcat);
            this.Controls.Add(this.BtnAdd);
            this.Name = "ScriptsConcatenationFrm";
            this.Text = "Scripts Concatenator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ScriptsBrowser;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnConcat;
        private System.Windows.Forms.Button BtnDownload;
        private System.Windows.Forms.ListView ScriptsList;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

