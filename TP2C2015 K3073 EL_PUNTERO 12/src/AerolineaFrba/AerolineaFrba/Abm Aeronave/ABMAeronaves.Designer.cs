namespace AerolineaFrba.Abm_Aeronave
{
    partial class ABMAeronaves
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
            this.LblListo = new System.Windows.Forms.Label();
            this.GroupFiltros = new System.Windows.Forms.GroupBox();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.dtpAlta = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.CboServicio = new System.Windows.Forms.ComboBox();
            this.TxtModelo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtFabricante = new System.Windows.Forms.TextBox();
            this.ChkBusquedaExacta = new System.Windows.Forms.CheckBox();
            this.LblLimpiar = new System.Windows.Forms.Label();
            this.LblBuscar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtMatricula = new System.Windows.Forms.TextBox();
            this.LblNuevo = new System.Windows.Forms.Label();
            this.DgvAeronaves = new System.Windows.Forms.DataGridView();
            this.GroupFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAeronaves)).BeginInit();
            this.SuspendLayout();
            // 
            // LblListo
            // 
            this.LblListo.BackColor = System.Drawing.Color.DodgerBlue;
            this.LblListo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblListo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblListo.ForeColor = System.Drawing.Color.White;
            this.LblListo.Location = new System.Drawing.Point(12, 546);
            this.LblListo.Name = "LblListo";
            this.LblListo.Size = new System.Drawing.Size(88, 32);
            this.LblListo.TabIndex = 46;
            this.LblListo.Text = "LISTO";
            this.LblListo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblListo.Click += new System.EventHandler(this.LblListo_Click);
            // 
            // GroupFiltros
            // 
            this.GroupFiltros.Controls.Add(this.chkFecha);
            this.GroupFiltros.Controls.Add(this.dtpAlta);
            this.GroupFiltros.Controls.Add(this.label6);
            this.GroupFiltros.Controls.Add(this.CboServicio);
            this.GroupFiltros.Controls.Add(this.TxtModelo);
            this.GroupFiltros.Controls.Add(this.label3);
            this.GroupFiltros.Controls.Add(this.TxtFabricante);
            this.GroupFiltros.Controls.Add(this.ChkBusquedaExacta);
            this.GroupFiltros.Controls.Add(this.LblLimpiar);
            this.GroupFiltros.Controls.Add(this.LblBuscar);
            this.GroupFiltros.Controls.Add(this.label2);
            this.GroupFiltros.Controls.Add(this.label1);
            this.GroupFiltros.Controls.Add(this.TxtMatricula);
            this.GroupFiltros.Location = new System.Drawing.Point(12, 16);
            this.GroupFiltros.Name = "GroupFiltros";
            this.GroupFiltros.Size = new System.Drawing.Size(981, 135);
            this.GroupFiltros.TabIndex = 44;
            this.GroupFiltros.TabStop = false;
            this.GroupFiltros.Text = "FILTROS DE BUSQUEDA";
            // 
            // chkFecha
            // 
            this.chkFecha.AutoSize = true;
            this.chkFecha.Location = new System.Drawing.Point(526, 37);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(91, 17);
            this.chkFecha.TabIndex = 56;
            this.chkFecha.Text = "FECHA ALTA";
            this.chkFecha.UseVisualStyleBackColor = true;
            this.chkFecha.Click += new System.EventHandler(this.chkFecha_Click);
            // 
            // dtpAlta
            // 
            this.dtpAlta.Location = new System.Drawing.Point(623, 35);
            this.dtpAlta.Name = "dtpAlta";
            this.dtpAlta.Size = new System.Drawing.Size(195, 20);
            this.dtpAlta.TabIndex = 55;
            this.dtpAlta.Value = new System.DateTime(2015, 10, 28, 18, 9, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(275, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "MODELO";
            // 
            // CboServicio
            // 
            this.CboServicio.FormattingEnabled = true;
            this.CboServicio.Location = new System.Drawing.Point(334, 79);
            this.CboServicio.Name = "CboServicio";
            this.CboServicio.Size = new System.Drawing.Size(170, 21);
            this.CboServicio.TabIndex = 41;
            // 
            // TxtModelo
            // 
            this.TxtModelo.Location = new System.Drawing.Point(334, 35);
            this.TxtModelo.Name = "TxtModelo";
            this.TxtModelo.Size = new System.Drawing.Size(170, 20);
            this.TxtModelo.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "FABRICANTE";
            // 
            // TxtFabricante
            // 
            this.TxtFabricante.Location = new System.Drawing.Point(86, 79);
            this.TxtFabricante.Name = "TxtFabricante";
            this.TxtFabricante.Size = new System.Drawing.Size(170, 20);
            this.TxtFabricante.TabIndex = 37;
            // 
            // ChkBusquedaExacta
            // 
            this.ChkBusquedaExacta.AutoSize = true;
            this.ChkBusquedaExacta.Location = new System.Drawing.Point(526, 79);
            this.ChkBusquedaExacta.Name = "ChkBusquedaExacta";
            this.ChkBusquedaExacta.Size = new System.Drawing.Size(131, 17);
            this.ChkBusquedaExacta.TabIndex = 36;
            this.ChkBusquedaExacta.Text = "BUSQUEDA EXACTA";
            this.ChkBusquedaExacta.UseVisualStyleBackColor = true;
            // 
            // LblLimpiar
            // 
            this.LblLimpiar.BackColor = System.Drawing.Color.DodgerBlue;
            this.LblLimpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblLimpiar.ForeColor = System.Drawing.Color.White;
            this.LblLimpiar.Location = new System.Drawing.Point(834, 63);
            this.LblLimpiar.Name = "LblLimpiar";
            this.LblLimpiar.Size = new System.Drawing.Size(124, 32);
            this.LblLimpiar.TabIndex = 35;
            this.LblLimpiar.Text = "LIMPIAR";
            this.LblLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblLimpiar.Click += new System.EventHandler(this.LblLimpiar_Click);
            // 
            // LblBuscar
            // 
            this.LblBuscar.BackColor = System.Drawing.Color.DodgerBlue;
            this.LblBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblBuscar.ForeColor = System.Drawing.Color.White;
            this.LblBuscar.Location = new System.Drawing.Point(834, 23);
            this.LblBuscar.Name = "LblBuscar";
            this.LblBuscar.Size = new System.Drawing.Size(124, 32);
            this.LblBuscar.TabIndex = 34;
            this.LblBuscar.Text = "BUSCAR";
            this.LblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblBuscar.Click += new System.EventHandler(this.LblBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SERVICIO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "MATRICULA";
            // 
            // TxtMatricula
            // 
            this.TxtMatricula.Location = new System.Drawing.Point(86, 35);
            this.TxtMatricula.Name = "TxtMatricula";
            this.TxtMatricula.Size = new System.Drawing.Size(170, 20);
            this.TxtMatricula.TabIndex = 0;
            // 
            // LblNuevo
            // 
            this.LblNuevo.BackColor = System.Drawing.Color.DodgerBlue;
            this.LblNuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblNuevo.ForeColor = System.Drawing.Color.White;
            this.LblNuevo.Location = new System.Drawing.Point(861, 546);
            this.LblNuevo.Name = "LblNuevo";
            this.LblNuevo.Size = new System.Drawing.Size(132, 32);
            this.LblNuevo.TabIndex = 45;
            this.LblNuevo.Text = "NUEVA AERONAVE";
            this.LblNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblNuevo.Click += new System.EventHandler(this.LblNuevo_Click);
            // 
            // DgvAeronaves
            // 
            this.DgvAeronaves.AllowUserToAddRows = false;
            this.DgvAeronaves.AllowUserToDeleteRows = false;
            this.DgvAeronaves.AllowUserToResizeColumns = false;
            this.DgvAeronaves.AllowUserToResizeRows = false;
            this.DgvAeronaves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvAeronaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAeronaves.Location = new System.Drawing.Point(12, 172);
            this.DgvAeronaves.MultiSelect = false;
            this.DgvAeronaves.Name = "DgvAeronaves";
            this.DgvAeronaves.RowHeadersVisible = false;
            this.DgvAeronaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvAeronaves.Size = new System.Drawing.Size(981, 342);
            this.DgvAeronaves.TabIndex = 43;
            this.DgvAeronaves.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAeronaves_CellContentClick);
            // 
            // ABMAeronaves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 594);
            this.ControlBox = false;
            this.Controls.Add(this.LblListo);
            this.Controls.Add(this.GroupFiltros);
            this.Controls.Add(this.LblNuevo);
            this.Controls.Add(this.DgvAeronaves);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ABMAeronaves";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administracion de Aeronaves";
            this.Load += new System.EventHandler(this.ABMAeronaves_Load);
            this.GroupFiltros.ResumeLayout(false);
            this.GroupFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAeronaves)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblListo;
        private System.Windows.Forms.GroupBox GroupFiltros;
        private System.Windows.Forms.ComboBox CboServicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtFabricante;
        private System.Windows.Forms.CheckBox ChkBusquedaExacta;
        private System.Windows.Forms.Label LblLimpiar;
        private System.Windows.Forms.Label LblBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtMatricula;
        private System.Windows.Forms.Label LblNuevo;
        private System.Windows.Forms.DataGridView DgvAeronaves;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtModelo;
        private System.Windows.Forms.DateTimePicker dtpAlta;
        private System.Windows.Forms.CheckBox chkFecha;
    }
}