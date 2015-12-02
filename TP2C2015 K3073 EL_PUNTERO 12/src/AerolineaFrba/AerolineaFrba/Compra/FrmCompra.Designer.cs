namespace AerolineaFrba.Compra
{
    partial class FrmCompra
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtpFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.BtnLimpiar = new System.Windows.Forms.Label();
            this.BtnBuscar = new System.Windows.Forms.Label();
            this.CmbCiudadDestino = new System.Windows.Forms.ComboBox();
            this.CmbCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvViaje = new System.Windows.Forms.DataGridView();
            this.BtnCancelar = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvViaje)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtpFechaSalida);
            this.groupBox1.Controls.Add(this.BtnLimpiar);
            this.groupBox1.Controls.Add(this.BtnBuscar);
            this.groupBox1.Controls.Add(this.CmbCiudadDestino);
            this.groupBox1.Controls.Add(this.CmbCiudadOrigen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(110, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 104);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTROS DE BUSQUEDA";
            // 
            // DtpFechaSalida
            // 
            this.DtpFechaSalida.Location = new System.Drawing.Point(136, 27);
            this.DtpFechaSalida.Name = "DtpFechaSalida";
            this.DtpFechaSalida.Size = new System.Drawing.Size(231, 20);
            this.DtpFechaSalida.TabIndex = 28;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnLimpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.ForeColor = System.Drawing.Color.White;
            this.BtnLimpiar.Location = new System.Drawing.Point(391, 59);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(88, 32);
            this.BtnLimpiar.TabIndex = 27;
            this.BtnLimpiar.Text = "LIMPIAR";
            this.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscar.ForeColor = System.Drawing.Color.White;
            this.BtnBuscar.Location = new System.Drawing.Point(391, 23);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(88, 32);
            this.BtnBuscar.TabIndex = 26;
            this.BtnBuscar.Text = "BUSCAR";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // CmbCiudadDestino
            // 
            this.CmbCiudadDestino.FormattingEnabled = true;
            this.CmbCiudadDestino.Location = new System.Drawing.Point(200, 66);
            this.CmbCiudadDestino.Name = "CmbCiudadDestino";
            this.CmbCiudadDestino.Size = new System.Drawing.Size(167, 21);
            this.CmbCiudadDestino.TabIndex = 6;
            this.CmbCiudadDestino.Text = "CIUDAD DESTINO";
            // 
            // CmbCiudadOrigen
            // 
            this.CmbCiudadOrigen.FormattingEnabled = true;
            this.CmbCiudadOrigen.Location = new System.Drawing.Point(27, 66);
            this.CmbCiudadOrigen.Name = "CmbCiudadOrigen";
            this.CmbCiudadOrigen.Size = new System.Drawing.Size(167, 21);
            this.CmbCiudadOrigen.TabIndex = 5;
            this.CmbCiudadOrigen.Text = "CIUDAD ORIGEN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "FECHA DE SALIDA";
            // 
            // DgvViaje
            // 
            this.DgvViaje.AllowUserToAddRows = false;
            this.DgvViaje.AllowUserToDeleteRows = false;
            this.DgvViaje.AllowUserToResizeColumns = false;
            this.DgvViaje.AllowUserToResizeRows = false;
            this.DgvViaje.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DgvViaje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvViaje.Location = new System.Drawing.Point(12, 122);
            this.DgvViaje.MultiSelect = false;
            this.DgvViaje.Name = "DgvViaje";
            this.DgvViaje.RowHeadersVisible = false;
            this.DgvViaje.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvViaje.Size = new System.Drawing.Size(718, 269);
            this.DgvViaje.TabIndex = 34;
            this.DgvViaje.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvViaje_CellContentClick);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnCancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Location = new System.Drawing.Point(12, 404);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(88, 32);
            this.BtnCancelar.TabIndex = 35;
            this.BtnCancelar.Text = "CANCELAR";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // FrmCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 448);
            this.ControlBox = false;
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.DgvViaje);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compra de Pasajes/Encomiendas";
            this.Load += new System.EventHandler(this.FrmCompra_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvViaje)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DtpFechaSalida;
        private System.Windows.Forms.Label BtnLimpiar;
        private System.Windows.Forms.Label BtnBuscar;
        private System.Windows.Forms.ComboBox CmbCiudadDestino;
        private System.Windows.Forms.ComboBox CmbCiudadOrigen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvViaje;
        private System.Windows.Forms.Label BtnCancelar;
    }
}