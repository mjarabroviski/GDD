namespace AerolineaFrba.Abm_Rol
{
    partial class FrmABMRol
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
            this.label1 = new System.Windows.Forms.Label();
            this.LstFuncionalidades = new System.Windows.Forms.ListBox();
            this.DgvRol = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.BtnLimpiar = new System.Windows.Forms.Label();
            this.BtnBuscar = new System.Windows.Forms.Label();
            this.ChkExacta = new System.Windows.Forms.CheckBox();
            this.BtnListo = new System.Windows.Forms.Label();
            this.BtnNuevo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRol)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(462, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "FUNCIONALIDADES ASOCIADAS";
            // 
            // LstFuncionalidades
            // 
            this.LstFuncionalidades.FormattingEnabled = true;
            this.LstFuncionalidades.Location = new System.Drawing.Point(462, 138);
            this.LstFuncionalidades.Name = "LstFuncionalidades";
            this.LstFuncionalidades.Size = new System.Drawing.Size(214, 290);
            this.LstFuncionalidades.TabIndex = 37;
            this.LstFuncionalidades.SelectedIndexChanged += new System.EventHandler(this.LstFuncionalidades_SelectedIndexChanged);
            // 
            // DgvRol
            // 
            this.DgvRol.AllowUserToAddRows = false;
            this.DgvRol.AllowUserToDeleteRows = false;
            this.DgvRol.AllowUserToResizeColumns = false;
            this.DgvRol.AllowUserToResizeRows = false;
            this.DgvRol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DgvRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRol.Location = new System.Drawing.Point(31, 112);
            this.DgvRol.MultiSelect = false;
            this.DgvRol.Name = "DgvRol";
            this.DgvRol.RowHeadersVisible = false;
            this.DgvRol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRol.Size = new System.Drawing.Size(413, 317);
            this.DgvRol.TabIndex = 39;
            this.DgvRol.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRol_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtDescripcion);
            this.groupBox2.Controls.Add(this.BtnLimpiar);
            this.groupBox2.Controls.Add(this.BtnBuscar);
            this.groupBox2.Controls.Add(this.ChkExacta);
            this.groupBox2.Location = new System.Drawing.Point(31, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 77);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BUSCAR UN ROL";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(15, 23);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(171, 20);
            this.TxtDescripcion.TabIndex = 26;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.BtnLimpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.ForeColor = System.Drawing.Color.White;
            this.BtnLimpiar.Location = new System.Drawing.Point(314, 23);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(84, 32);
            this.BtnLimpiar.TabIndex = 25;
            this.BtnLimpiar.Text = "LIMPIAR";
            this.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.BtnBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscar.ForeColor = System.Drawing.Color.White;
            this.BtnBuscar.Location = new System.Drawing.Point(208, 23);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(88, 32);
            this.BtnBuscar.TabIndex = 24;
            this.BtnBuscar.Text = "BUSCAR";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChkExacta
            // 
            this.ChkExacta.AutoSize = true;
            this.ChkExacta.Location = new System.Drawing.Point(55, 45);
            this.ChkExacta.Name = "ChkExacta";
            this.ChkExacta.Size = new System.Drawing.Size(131, 17);
            this.ChkExacta.TabIndex = 24;
            this.ChkExacta.Text = "BUSQUEDA EXACTA";
            this.ChkExacta.UseVisualStyleBackColor = true;
            // 
            // BtnListo
            // 
            this.BtnListo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.BtnListo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnListo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnListo.ForeColor = System.Drawing.Color.White;
            this.BtnListo.Location = new System.Drawing.Point(31, 445);
            this.BtnListo.Name = "BtnListo";
            this.BtnListo.Size = new System.Drawing.Size(88, 32);
            this.BtnListo.TabIndex = 36;
            this.BtnListo.Text = "LISTO";
            this.BtnListo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnListo.Click += new System.EventHandler(this.BtnListo_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.BtnNuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNuevo.ForeColor = System.Drawing.Color.White;
            this.BtnNuevo.Location = new System.Drawing.Point(564, 445);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(112, 32);
            this.BtnNuevo.TabIndex = 35;
            this.BtnNuevo.Text = "NUEVO ROL";
            this.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // FrmABMRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 496);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LstFuncionalidades);
            this.Controls.Add(this.DgvRol);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnListo);
            this.Controls.Add(this.BtnNuevo);
            this.Name = "FrmABMRol";
            this.Text = "FrmABMRol";
            ((System.ComponentModel.ISupportInitialize)(this.DgvRol)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox LstFuncionalidades;
        private System.Windows.Forms.DataGridView DgvRol;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label BtnLimpiar;
        private System.Windows.Forms.Label BtnBuscar;
        private System.Windows.Forms.CheckBox ChkExacta;
        private System.Windows.Forms.Label BtnListo;
        private System.Windows.Forms.Label BtnNuevo;
    }
}