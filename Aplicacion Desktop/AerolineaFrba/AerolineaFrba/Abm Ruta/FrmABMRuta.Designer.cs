namespace AerolineaFrba.Abm_Ruta
{
    partial class FrmABMRuta
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
            this.BtnLimpiar = new System.Windows.Forms.Label();
            this.BtnBuscar = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtHastaPasaje = new System.Windows.Forms.TextBox();
            this.TxtHastaKg = new System.Windows.Forms.TextBox();
            this.TxtDesdePasaje = new System.Windows.Forms.TextBox();
            this.TxtDesdeKg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbCiudadDestino = new System.Windows.Forms.ComboBox();
            this.CmbCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.CmbTipoServicio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.DgvRuta = new System.Windows.Forms.DataGridView();
            this.BtnListo = new System.Windows.Forms.Label();
            this.BtnNuevo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRuta)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnLimpiar);
            this.groupBox1.Controls.Add(this.BtnBuscar);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtHastaPasaje);
            this.groupBox1.Controls.Add(this.TxtHastaKg);
            this.groupBox1.Controls.Add(this.TxtDesdePasaje);
            this.groupBox1.Controls.Add(this.TxtDesdeKg);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CmbCiudadDestino);
            this.groupBox1.Controls.Add(this.CmbCiudadOrigen);
            this.groupBox1.Controls.Add(this.CmbTipoServicio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtCodigo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(909, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTROS DE BUSQUEDA";
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnLimpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.ForeColor = System.Drawing.Color.White;
            this.BtnLimpiar.Location = new System.Drawing.Point(817, 59);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(84, 32);
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
            this.BtnBuscar.Location = new System.Drawing.Point(815, 21);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(88, 32);
            this.BtnBuscar.TabIndex = 26;
            this.BtnBuscar.Text = "BUSCAR";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(724, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "HASTA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(616, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "DESDE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(687, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(686, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "-";
            // 
            // TxtHastaPasaje
            // 
            this.TxtHastaPasaje.Location = new System.Drawing.Point(706, 65);
            this.TxtHastaPasaje.Name = "TxtHastaPasaje";
            this.TxtHastaPasaje.Size = new System.Drawing.Size(76, 20);
            this.TxtHastaPasaje.TabIndex = 12;
            // 
            // TxtHastaKg
            // 
            this.TxtHastaKg.Location = new System.Drawing.Point(706, 28);
            this.TxtHastaKg.Name = "TxtHastaKg";
            this.TxtHastaKg.Size = new System.Drawing.Size(76, 20);
            this.TxtHastaKg.TabIndex = 11;
            // 
            // TxtDesdePasaje
            // 
            this.TxtDesdePasaje.Location = new System.Drawing.Point(598, 65);
            this.TxtDesdePasaje.Name = "TxtDesdePasaje";
            this.TxtDesdePasaje.Size = new System.Drawing.Size(76, 20);
            this.TxtDesdePasaje.TabIndex = 10;
            // 
            // TxtDesdeKg
            // 
            this.TxtDesdeKg.Location = new System.Drawing.Point(598, 28);
            this.TxtDesdeKg.Name = "TxtDesdeKg";
            this.TxtDesdeKg.Size = new System.Drawing.Size(76, 20);
            this.TxtDesdeKg.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(454, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "PRECIO BASE x PASAJE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "PRECIO BASE x KG";
            // 
            // CmbCiudadDestino
            // 
            this.CmbCiudadDestino.FormattingEnabled = true;
            this.CmbCiudadDestino.Location = new System.Drawing.Point(267, 65);
            this.CmbCiudadDestino.Name = "CmbCiudadDestino";
            this.CmbCiudadDestino.Size = new System.Drawing.Size(167, 21);
            this.CmbCiudadDestino.TabIndex = 6;
            this.CmbCiudadDestino.Text = "CIUDAD DESTINO";
            // 
            // CmbCiudadOrigen
            // 
            this.CmbCiudadOrigen.FormattingEnabled = true;
            this.CmbCiudadOrigen.Location = new System.Drawing.Point(267, 27);
            this.CmbCiudadOrigen.Name = "CmbCiudadOrigen";
            this.CmbCiudadOrigen.Size = new System.Drawing.Size(167, 21);
            this.CmbCiudadOrigen.TabIndex = 5;
            this.CmbCiudadOrigen.Text = "CIUDAD ORIGEN";
            // 
            // CmbTipoServicio
            // 
            this.CmbTipoServicio.FormattingEnabled = true;
            this.CmbTipoServicio.Location = new System.Drawing.Point(27, 65);
            this.CmbTipoServicio.Name = "CmbTipoServicio";
            this.CmbTipoServicio.Size = new System.Drawing.Size(221, 21);
            this.CmbTipoServicio.TabIndex = 4;
            this.CmbTipoServicio.Text = "SERVICIO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "CÓDIGO DE RUTA";
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Location = new System.Drawing.Point(130, 28);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.Size = new System.Drawing.Size(118, 20);
            this.TxtCodigo.TabIndex = 2;
            // 
            // DgvRuta
            // 
            this.DgvRuta.AllowUserToAddRows = false;
            this.DgvRuta.AllowUserToDeleteRows = false;
            this.DgvRuta.AllowUserToResizeColumns = false;
            this.DgvRuta.AllowUserToResizeRows = false;
            this.DgvRuta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DgvRuta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRuta.Location = new System.Drawing.Point(12, 122);
            this.DgvRuta.MultiSelect = false;
            this.DgvRuta.Name = "DgvRuta";
            this.DgvRuta.RowHeadersVisible = false;
            this.DgvRuta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRuta.Size = new System.Drawing.Size(909, 329);
            this.DgvRuta.TabIndex = 33;
            // 
            // BtnListo
            // 
            this.BtnListo.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnListo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnListo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnListo.ForeColor = System.Drawing.Color.White;
            this.BtnListo.Location = new System.Drawing.Point(833, 463);
            this.BtnListo.Name = "BtnListo";
            this.BtnListo.Size = new System.Drawing.Size(88, 32);
            this.BtnListo.TabIndex = 38;
            this.BtnListo.Text = "LISTO";
            this.BtnListo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnListo.Click += new System.EventHandler(this.BtnListo_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnNuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNuevo.ForeColor = System.Drawing.Color.White;
            this.BtnNuevo.Location = new System.Drawing.Point(12, 463);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(112, 32);
            this.BtnNuevo.TabIndex = 37;
            this.BtnNuevo.Text = "NUEVA RUTA";
            this.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // FrmABMRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 504);
            this.Controls.Add(this.BtnListo);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.DgvRuta);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmABMRuta";
            this.Text = "FrmABMRuta";
            this.Load += new System.EventHandler(this.FrmABMRuta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRuta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbCiudadDestino;
        private System.Windows.Forms.ComboBox CmbCiudadOrigen;
        private System.Windows.Forms.ComboBox CmbTipoServicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtHastaPasaje;
        private System.Windows.Forms.TextBox TxtHastaKg;
        private System.Windows.Forms.TextBox TxtDesdePasaje;
        private System.Windows.Forms.TextBox TxtDesdeKg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label BtnLimpiar;
        private System.Windows.Forms.Label BtnBuscar;
        private System.Windows.Forms.DataGridView DgvRuta;
        private System.Windows.Forms.Label BtnListo;
        private System.Windows.Forms.Label BtnNuevo;

    }
}