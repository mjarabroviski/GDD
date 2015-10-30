namespace AerolineaFrba.Abm_Aeronave
{
    partial class ABMButacas
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
            this.DgvButacas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvButacas)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvButacas
            // 
            this.DgvButacas.AllowUserToAddRows = false;
            this.DgvButacas.AllowUserToDeleteRows = false;
            this.DgvButacas.AllowUserToResizeColumns = false;
            this.DgvButacas.AllowUserToResizeRows = false;
            this.DgvButacas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvButacas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvButacas.Location = new System.Drawing.Point(12, 12);
            this.DgvButacas.MultiSelect = false;
            this.DgvButacas.Name = "DgvButacas";
            this.DgvButacas.RowHeadersVisible = false;
            this.DgvButacas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvButacas.Size = new System.Drawing.Size(482, 342);
            this.DgvButacas.TabIndex = 44;
            // 
            // ABMButacas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 463);
            this.Controls.Add(this.DgvButacas);
            this.Name = "ABMButacas";
            this.Text = "ABMButacas";
            this.Load += new System.EventHandler(this.ABMButacas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvButacas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvButacas;


    }
}