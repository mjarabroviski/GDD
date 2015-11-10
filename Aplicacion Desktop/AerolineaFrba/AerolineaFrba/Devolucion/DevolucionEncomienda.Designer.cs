namespace AerolineaFrba.Devolucion
{
    partial class DevolucionEncomienda
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
            this.Btn_DevolverTodos = new System.Windows.Forms.Label();
            this.Btn_Volver = new System.Windows.Forms.Label();
            this.DgvEncomiendas = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtDNI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtApellido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEncomiendas)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Finalizar
            // 
            this.Btn_Finalizar.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_Finalizar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_Finalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Finalizar.ForeColor = System.Drawing.Color.White;
            this.Btn_Finalizar.Location = new System.Drawing.Point(321, 354);
            this.Btn_Finalizar.Name = "Btn_Finalizar";
            this.Btn_Finalizar.Size = new System.Drawing.Size(91, 34);
            this.Btn_Finalizar.TabIndex = 75;
            this.Btn_Finalizar.Text = "FINALIZAR";
            this.Btn_Finalizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_DevolverTodos
            // 
            this.Btn_DevolverTodos.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_DevolverTodos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_DevolverTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_DevolverTodos.ForeColor = System.Drawing.Color.White;
            this.Btn_DevolverTodos.Location = new System.Drawing.Point(321, 49);
            this.Btn_DevolverTodos.Name = "Btn_DevolverTodos";
            this.Btn_DevolverTodos.Size = new System.Drawing.Size(91, 34);
            this.Btn_DevolverTodos.TabIndex = 74;
            this.Btn_DevolverTodos.Text = "DEVOLVER TODO";
            this.Btn_DevolverTodos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_Volver
            // 
            this.Btn_Volver.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_Volver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_Volver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Volver.ForeColor = System.Drawing.Color.White;
            this.Btn_Volver.Location = new System.Drawing.Point(13, 354);
            this.Btn_Volver.Name = "Btn_Volver";
            this.Btn_Volver.Size = new System.Drawing.Size(91, 34);
            this.Btn_Volver.TabIndex = 73;
            this.Btn_Volver.Text = "VOLVER";
            this.Btn_Volver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvEncomiendas
            // 
            this.DgvEncomiendas.AllowUserToAddRows = false;
            this.DgvEncomiendas.AllowUserToDeleteRows = false;
            this.DgvEncomiendas.AllowUserToResizeColumns = false;
            this.DgvEncomiendas.AllowUserToResizeRows = false;
            this.DgvEncomiendas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvEncomiendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEncomiendas.Location = new System.Drawing.Point(13, 99);
            this.DgvEncomiendas.MultiSelect = false;
            this.DgvEncomiendas.Name = "DgvEncomiendas";
            this.DgvEncomiendas.RowHeadersVisible = false;
            this.DgvEncomiendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEncomiendas.Size = new System.Drawing.Size(399, 237);
            this.DgvEncomiendas.TabIndex = 70;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 72;
            this.label6.Text = "DNI";
            // 
            // TxtDNI
            // 
            this.TxtDNI.Enabled = false;
            this.TxtDNI.Location = new System.Drawing.Point(88, 63);
            this.TxtDNI.Name = "TxtDNI";
            this.TxtDNI.Size = new System.Drawing.Size(140, 20);
            this.TxtDNI.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "APELLIDO";
            // 
            // TxtApellido
            // 
            this.TxtApellido.Enabled = false;
            this.TxtApellido.Location = new System.Drawing.Point(88, 37);
            this.TxtApellido.Name = "TxtApellido";
            this.TxtApellido.Size = new System.Drawing.Size(140, 20);
            this.TxtApellido.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "NOMBRE";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Enabled = false;
            this.TxtNombre.Location = new System.Drawing.Point(88, 11);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(140, 20);
            this.TxtNombre.TabIndex = 66;
            // 
            // DevolucionEncomienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 398);
            this.Controls.Add(this.Btn_Finalizar);
            this.Controls.Add(this.Btn_DevolverTodos);
            this.Controls.Add(this.Btn_Volver);
            this.Controls.Add(this.DgvEncomiendas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtDNI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtApellido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtNombre);
            this.Name = "DevolucionEncomienda";
            this.Text = "Devolucion Encomienda";
            this.Load += new System.EventHandler(this.DevolucionEncomienda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvEncomiendas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Btn_Finalizar;
        private System.Windows.Forms.Label Btn_DevolverTodos;
        private System.Windows.Forms.Label Btn_Volver;
        private System.Windows.Forms.DataGridView DgvEncomiendas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtDNI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtApellido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNombre;
    }
}