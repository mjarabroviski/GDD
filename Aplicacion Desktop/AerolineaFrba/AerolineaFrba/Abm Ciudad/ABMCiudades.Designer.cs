namespace AerolineaFrba.Abm_Ciudad
{
    partial class ABMCiudades
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
            this.DgvCiudad = new System.Windows.Forms.DataGridView();
            this.LblListo = new System.Windows.Forms.Label();
            this.LblNuevo = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblBuscar = new System.Windows.Forms.Label();
            this.LblLimpiar = new System.Windows.Forms.Label();
            this.ChkBusqueda = new System.Windows.Forms.CheckBox();
            this.GroupFiltros = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCiudad)).BeginInit();
            this.GroupFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvCiudad
            // 
            this.DgvCiudad.AllowUserToAddRows = false;
            this.DgvCiudad.AllowUserToDeleteRows = false;
            this.DgvCiudad.AllowUserToResizeColumns = false;
            this.DgvCiudad.AllowUserToResizeRows = false;
            this.DgvCiudad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvCiudad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCiudad.Location = new System.Drawing.Point(12, 107);
            this.DgvCiudad.MultiSelect = false;
            this.DgvCiudad.Name = "DgvCiudad";
            this.DgvCiudad.RowHeadersVisible = false;
            this.DgvCiudad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCiudad.Size = new System.Drawing.Size(680, 345);
            this.DgvCiudad.TabIndex = 36;
            this.DgvCiudad.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCiudad_CellContentClick);
            // 
            // LblListo
            // 
            this.LblListo.BackColor = System.Drawing.Color.DodgerBlue;
            this.LblListo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblListo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblListo.ForeColor = System.Drawing.Color.White;
            this.LblListo.Location = new System.Drawing.Point(12, 465);
            this.LblListo.Name = "LblListo";
            this.LblListo.Size = new System.Drawing.Size(88, 32);
            this.LblListo.TabIndex = 35;
            this.LblListo.Text = "LISTO";
            this.LblListo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblListo.Click += new System.EventHandler(this.LblListo_Click);
            // 
            // LblNuevo
            // 
            this.LblNuevo.BackColor = System.Drawing.Color.DodgerBlue;
            this.LblNuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblNuevo.ForeColor = System.Drawing.Color.White;
            this.LblNuevo.Location = new System.Drawing.Point(560, 465);
            this.LblNuevo.Name = "LblNuevo";
            this.LblNuevo.Size = new System.Drawing.Size(132, 32);
            this.LblNuevo.TabIndex = 34;
            this.LblNuevo.Text = "NUEVA CIUDAD";
            this.LblNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblNuevo.Click += new System.EventHandler(this.LblNuevo_Click);
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(100, 23);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(118, 20);
            this.TxtNombre.TabIndex = 0;
            this.TxtNombre.TextChanged += new System.EventHandler(this.TxtNombre_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NOMBRE";
            // 
            // LblBuscar
            // 
            this.LblBuscar.BackColor = System.Drawing.Color.DodgerBlue;
            this.LblBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblBuscar.ForeColor = System.Drawing.Color.White;
            this.LblBuscar.Location = new System.Drawing.Point(468, 16);
            this.LblBuscar.Name = "LblBuscar";
            this.LblBuscar.Size = new System.Drawing.Size(88, 32);
            this.LblBuscar.TabIndex = 34;
            this.LblBuscar.Text = "BUSCAR";
            this.LblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblBuscar.Click += new System.EventHandler(this.LblBuscar_Click);
            // 
            // LblLimpiar
            // 
            this.LblLimpiar.BackColor = System.Drawing.Color.DodgerBlue;
            this.LblLimpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblLimpiar.ForeColor = System.Drawing.Color.White;
            this.LblLimpiar.Location = new System.Drawing.Point(573, 16);
            this.LblLimpiar.Name = "LblLimpiar";
            this.LblLimpiar.Size = new System.Drawing.Size(88, 32);
            this.LblLimpiar.TabIndex = 35;
            this.LblLimpiar.Text = "LIMPIAR";
            this.LblLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblLimpiar.Click += new System.EventHandler(this.LblLimpiar_Click);
            // 
            // ChkBusqueda
            // 
            this.ChkBusqueda.AutoSize = true;
            this.ChkBusqueda.Location = new System.Drawing.Point(243, 25);
            this.ChkBusqueda.Name = "ChkBusqueda";
            this.ChkBusqueda.Size = new System.Drawing.Size(131, 17);
            this.ChkBusqueda.TabIndex = 36;
            this.ChkBusqueda.Text = "BUSQUEDA EXACTA";
            this.ChkBusqueda.UseVisualStyleBackColor = true;
            this.ChkBusqueda.CheckedChanged += new System.EventHandler(this.ChkBusquedaExacta_CheckedChanged);
            // 
            // GroupFiltros
            // 
            this.GroupFiltros.Controls.Add(this.ChkBusqueda);
            this.GroupFiltros.Controls.Add(this.LblLimpiar);
            this.GroupFiltros.Controls.Add(this.LblBuscar);
            this.GroupFiltros.Controls.Add(this.label1);
            this.GroupFiltros.Controls.Add(this.TxtNombre);
            this.GroupFiltros.Location = new System.Drawing.Point(12, 14);
            this.GroupFiltros.Name = "GroupFiltros";
            this.GroupFiltros.Size = new System.Drawing.Size(680, 73);
            this.GroupFiltros.TabIndex = 37;
            this.GroupFiltros.TabStop = false;
            this.GroupFiltros.Text = "FILTROS DE BUSQUEDA";
            // 
            // ABMCiudades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 511);
            this.Controls.Add(this.GroupFiltros);
            this.Controls.Add(this.DgvCiudad);
            this.Controls.Add(this.LblListo);
            this.Controls.Add(this.LblNuevo);
            this.MaximumSize = new System.Drawing.Size(720, 550);
            this.MinimumSize = new System.Drawing.Size(720, 550);
            this.Name = "ABMCiudades";
            this.Text = "Administracion de Ciudades";
            this.Load += new System.EventHandler(this.ABMCiudades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCiudad)).EndInit();
            this.GroupFiltros.ResumeLayout(false);
            this.GroupFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvCiudad;
        private System.Windows.Forms.Label LblListo;
        private System.Windows.Forms.Label LblNuevo;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblBuscar;
        private System.Windows.Forms.Label LblLimpiar;
        private System.Windows.Forms.CheckBox ChkBusqueda;
        private System.Windows.Forms.GroupBox GroupFiltros;
    }
}