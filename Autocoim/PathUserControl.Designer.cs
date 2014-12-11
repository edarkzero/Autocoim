namespace Autocoim
{
    partial class PathUserControl
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSearchGP = new System.Windows.Forms.Label();
            this.buttonSearchGP = new System.Windows.Forms.Button();
            this.labelSearchEmail = new System.Windows.Forms.Label();
            this.buttonSearchEmail = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSearchFolder = new System.Windows.Forms.Label();
            this.buttonSearchFolder = new System.Windows.Forms.Button();
            this.openFileDialogGP = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogEmail = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogAll = new System.Windows.Forms.FolderBrowserDialog();
            this.labelPathGP = new System.Windows.Forms.Label();
            this.labelPathEmail = new System.Windows.Forms.Label();
            this.labelPathFolder = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSearchGP
            // 
            this.labelSearchGP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSearchGP.AutoSize = true;
            this.labelSearchGP.Location = new System.Drawing.Point(3, 0);
            this.labelSearchGP.Name = "labelSearchGP";
            this.labelSearchGP.Size = new System.Drawing.Size(133, 45);
            this.labelSearchGP.TabIndex = 0;
            this.labelSearchGP.Text = "GP Excel";
            this.labelSearchGP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonSearchGP
            // 
            this.buttonSearchGP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearchGP.Location = new System.Drawing.Point(142, 3);
            this.buttonSearchGP.Name = "buttonSearchGP";
            this.buttonSearchGP.Size = new System.Drawing.Size(127, 39);
            this.buttonSearchGP.TabIndex = 1;
            this.buttonSearchGP.Text = "Search";
            this.buttonSearchGP.UseVisualStyleBackColor = true;
            this.buttonSearchGP.Click += new System.EventHandler(this.buttonSearchGP_Click);
            // 
            // labelSearchEmail
            // 
            this.labelSearchEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSearchEmail.AutoSize = true;
            this.labelSearchEmail.Location = new System.Drawing.Point(3, 45);
            this.labelSearchEmail.Name = "labelSearchEmail";
            this.labelSearchEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelSearchEmail.Size = new System.Drawing.Size(133, 45);
            this.labelSearchEmail.TabIndex = 2;
            this.labelSearchEmail.Text = "Email Excel";
            this.labelSearchEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonSearchEmail
            // 
            this.buttonSearchEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearchEmail.Location = new System.Drawing.Point(142, 48);
            this.buttonSearchEmail.Name = "buttonSearchEmail";
            this.buttonSearchEmail.Size = new System.Drawing.Size(127, 39);
            this.buttonSearchEmail.TabIndex = 3;
            this.buttonSearchEmail.Text = "Search";
            this.buttonSearchEmail.UseVisualStyleBackColor = true;
            this.buttonSearchEmail.Click += new System.EventHandler(this.buttonSearchEmail_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.10294F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.89706F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 263F));
            this.tableLayoutPanel1.Controls.Add(this.labelPathFolder, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelPathEmail, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSearchEmail, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSearchGP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelSearchGP, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelSearchEmail, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSearchFolder, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonSearchFolder, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelPathGP, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(536, 135);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelSearchFolder
            // 
            this.labelSearchFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSearchFolder.AutoSize = true;
            this.labelSearchFolder.Location = new System.Drawing.Point(3, 90);
            this.labelSearchFolder.Name = "labelSearchFolder";
            this.labelSearchFolder.Size = new System.Drawing.Size(133, 45);
            this.labelSearchFolder.TabIndex = 4;
            this.labelSearchFolder.Text = "GP and Email folder";
            this.labelSearchFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonSearchFolder
            // 
            this.buttonSearchFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearchFolder.Location = new System.Drawing.Point(142, 93);
            this.buttonSearchFolder.Name = "buttonSearchFolder";
            this.buttonSearchFolder.Size = new System.Drawing.Size(127, 39);
            this.buttonSearchFolder.TabIndex = 5;
            this.buttonSearchFolder.Text = "Search";
            this.buttonSearchFolder.UseVisualStyleBackColor = true;
            this.buttonSearchFolder.Click += new System.EventHandler(this.buttonSearchFolder_Click);
            // 
            // openFileDialogGP
            // 
            this.openFileDialogGP.FileName = "GPComprobantes.xlsx";
            this.openFileDialogGP.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            // 
            // openFileDialogEmail
            // 
            this.openFileDialogEmail.FileName = "GPEmail.xlsx";
            this.openFileDialogEmail.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            // 
            // labelPathGP
            // 
            this.labelPathGP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPathGP.AutoSize = true;
            this.labelPathGP.Location = new System.Drawing.Point(275, 0);
            this.labelPathGP.Name = "labelPathGP";
            this.labelPathGP.Size = new System.Drawing.Size(258, 45);
            this.labelPathGP.TabIndex = 6;
            this.labelPathGP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPathEmail
            // 
            this.labelPathEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPathEmail.AutoSize = true;
            this.labelPathEmail.Location = new System.Drawing.Point(275, 45);
            this.labelPathEmail.Name = "labelPathEmail";
            this.labelPathEmail.Size = new System.Drawing.Size(258, 45);
            this.labelPathEmail.TabIndex = 7;
            this.labelPathEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPathFolder
            // 
            this.labelPathFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPathFolder.AutoSize = true;
            this.labelPathFolder.Location = new System.Drawing.Point(275, 90);
            this.labelPathFolder.Name = "labelPathFolder";
            this.labelPathFolder.Size = new System.Drawing.Size(258, 45);
            this.labelPathFolder.TabIndex = 8;
            this.labelPathFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PathUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PathUserControl";
            this.Size = new System.Drawing.Size(546, 146);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelSearchGP;
        private System.Windows.Forms.Button buttonSearchGP;
        private System.Windows.Forms.Label labelSearchEmail;
        private System.Windows.Forms.Button buttonSearchEmail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.OpenFileDialog openFileDialogGP;
        private System.Windows.Forms.OpenFileDialog openFileDialogEmail;
        private System.Windows.Forms.Label labelSearchFolder;
        private System.Windows.Forms.Button buttonSearchFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogAll;
        private System.Windows.Forms.Label labelPathFolder;
        private System.Windows.Forms.Label labelPathEmail;
        private System.Windows.Forms.Label labelPathGP;

    }
}
