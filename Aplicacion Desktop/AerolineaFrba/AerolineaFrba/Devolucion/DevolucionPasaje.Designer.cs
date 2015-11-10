namespace AerolineaFrba.Devolucion
{
    partial class DevolucionPasaje
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
            this.Btn_Finalizar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Volver = new System.Windows.Forms.Label();
            this.DgvPasaje = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtDNI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtApellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPasaje)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Finalizar
            // 
            this.Btn_Finalizar.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_Finalizar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_Finalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Finalizar.ForeColor = System.Drawing.Color.White;
            this.Btn_Finalizar.Location = new System.Drawing.Point(379, 354);
            this.Btn_Finalizar.Name = "Btn_Finalizar";
            this.Btn_Finalizar.Size = new System.Drawing.Size(91, 34);
            this.Btn_Finalizar.TabIndex = 85;
            this.Btn_Finalizar.Text = "FINALIZAR";
            this.Btn_Finalizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(379, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 34);
            this.label1.TabIndex = 84;
            this.label1.Text = "DEVOLVER TODO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_Volver
            // 
            this.Btn_Volver.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_Volver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_Volver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Volver.ForeColor = System.Drawing.Color.White;
            this.Btn_Volver.Location = new System.Drawing.Point(12, 353);
            this.Btn_Volver.Name = "Btn_Volver";
            this.Btn_Volver.Size = new System.Drawing.Size(91, 34);
            this.Btn_Volver.TabIndex = 83;
            this.Btn_Volver.Text = "VOLVER";
            this.Btn_Volver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvPasaje
            // 
            this.DgvPasaje.AllowUserToAddRows = false;
            this.DgvPasaje.AllowUserToDeleteRows = false;
            this.DgvPasaje.AllowUserToResizeColumns = false;
            this.DgvPasaje.AllowUserToResizeRows = false;
            this.DgvPasaje.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvPasaje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPasaje.Location = new System.Drawing.Point(15, 100);
            this.DgvPasaje.MultiSelect = false;
            this.DgvPasaje.Name = "DgvPasaje";
            this.DgvPasaje.RowHeadersVisible = false;
            this.DgvPasaje.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPasaje.Size = new System.Drawing.Size(455, 237);
            this.DgvPasaje.TabIndex = 80;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 82;
            this.label6.Text = "DOCUMENTO";
            // 
            // TxtDNI
            // 
            this.TxtDNI.Enabled = false;
            this.TxtDNI.Location = new System.Drawing.Point(95, 62);
            this.TxtDNI.Name = "TxtDNI";
            this.TxtDNI.Size = new System.Drawing.Size(140, 20);
            this.TxtDNI.TabIndex = 81;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 79;
            this.label3.Text = "APELLIDO";
            // 
            // TxtApellido
            // 
            this.TxtApellido.Enabled = false;
            this.TxtApellido.Location = new System.Drawing.Point(95, 36);
            this.TxtApellido.Name = "TxtApellido";
            this.TxtApellido.Size = new System.Drawing.Size(140, 20);
            this.TxtApellido.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 77;
            this.label2.Text = "NOMBRE";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Enabled = false;
            this.TxtNombre.Location = new System.Drawing.Point(95, 11);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(140, 20);
            this.TxtNombre.TabIndex = 76;
            // 
            // DevolucionPasaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 398);
            this.Controls.Add(this.Btn_Finalizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Volver);
            this.Controls.Add(this.DgvPasaje);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtDNI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtApellido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtNombre);
            this.Name = "DevolucionPasaje";
            this.Text = "Devolucion Pasaje";
            this.Load += new System.EventHandler(this.DevolucionPasaje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPasaje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Btn_Finalizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Btn_Volver;
        private System.Windows.Forms.DataGridView DgvPasaje;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtDNI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtApellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNombre;
    }
}