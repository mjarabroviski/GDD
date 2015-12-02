namespace AerolineaFrba.Canje_Millas
{
    partial class CantidadProducto
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
            this.label4 = new System.Windows.Forms.Label();
            this.BtnCanje = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Label();
            this.cboCantidad = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "SELECCIONE LA CANTIDAD";
            // 
            // BtnCanje
            // 
            this.BtnCanje.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnCanje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnCanje.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCanje.ForeColor = System.Drawing.Color.White;
            this.BtnCanje.Location = new System.Drawing.Point(25, 70);
            this.BtnCanje.Name = "BtnCanje";
            this.BtnCanje.Size = new System.Drawing.Size(101, 29);
            this.BtnCanje.TabIndex = 54;
            this.BtnCanje.Text = "REALIZAR CANJE";
            this.BtnCanje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnCanje.Click += new System.EventHandler(this.BtnCanje_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnCancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Location = new System.Drawing.Point(132, 70);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(101, 29);
            this.BtnCancelar.TabIndex = 55;
            this.BtnCancelar.Text = "CANCELAR";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // cboCantidad
            // 
            this.cboCantidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCantidad.FormattingEnabled = true;
            this.cboCantidad.Location = new System.Drawing.Point(166, 30);
            this.cboCantidad.Name = "cboCantidad";
            this.cboCantidad.Size = new System.Drawing.Size(77, 21);
            this.cboCantidad.TabIndex = 56;
            // 
            // CantidadProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 120);
            this.ControlBox = false;
            this.Controls.Add(this.cboCantidad);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnCanje);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CantidadProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cantidad de Producto";
            this.Load += new System.EventHandler(this.CantidadProducto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label BtnCanje;
        private System.Windows.Forms.Label BtnCancelar;
        private System.Windows.Forms.ComboBox cboCantidad;
    }
}