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
            this.GroupFiltros = new System.Windows.Forms.GroupBox();
            this.CboTipo = new System.Windows.Forms.ComboBox();
            this.BtnLimpiar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAgregarButacas = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Label();
            this.BtnGrabar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvButacas)).BeginInit();
            this.GroupFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvButacas
            // 
            this.DgvButacas.AllowUserToAddRows = false;
            this.DgvButacas.AllowUserToDeleteRows = false;
            this.DgvButacas.AllowUserToResizeColumns = false;
            this.DgvButacas.AllowUserToResizeRows = false;
            this.DgvButacas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvButacas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvButacas.Location = new System.Drawing.Point(12, 102);
            this.DgvButacas.MultiSelect = false;
            this.DgvButacas.Name = "DgvButacas";
            this.DgvButacas.RowHeadersVisible = false;
            this.DgvButacas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvButacas.Size = new System.Drawing.Size(366, 208);
            this.DgvButacas.TabIndex = 44;
            this.DgvButacas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvButacas_CellContentClick);
            // 
            // GroupFiltros
            // 
            this.GroupFiltros.Controls.Add(this.BtnGrabar);
            this.GroupFiltros.Controls.Add(this.CboTipo);
            this.GroupFiltros.Controls.Add(this.label1);
            this.GroupFiltros.Location = new System.Drawing.Point(12, 12);
            this.GroupFiltros.Name = "GroupFiltros";
            this.GroupFiltros.Size = new System.Drawing.Size(366, 73);
            this.GroupFiltros.TabIndex = 45;
            this.GroupFiltros.TabStop = false;
            this.GroupFiltros.Text = "MODIFICACION DE TIPO";
            // 
            // CboTipo
            // 
            this.CboTipo.FormattingEnabled = true;
            this.CboTipo.Location = new System.Drawing.Point(98, 30);
            this.CboTipo.Name = "CboTipo";
            this.CboTipo.Size = new System.Drawing.Size(124, 21);
            this.CboTipo.TabIndex = 42;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnLimpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.ForeColor = System.Drawing.Color.White;
            this.BtnLimpiar.Location = new System.Drawing.Point(136, 330);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(118, 36);
            this.BtnLimpiar.TabIndex = 35;
            this.BtnLimpiar.Text = "ACTUALIZAR PANTALLA";
            this.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TIPO BUTACA";
            // 
            // BtnAgregarButacas
            // 
            this.BtnAgregarButacas.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAgregarButacas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnAgregarButacas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgregarButacas.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarButacas.Location = new System.Drawing.Point(12, 330);
            this.BtnAgregarButacas.Name = "BtnAgregarButacas";
            this.BtnAgregarButacas.Size = new System.Drawing.Size(117, 36);
            this.BtnAgregarButacas.TabIndex = 69;
            this.BtnAgregarButacas.Text = "AGREGAR BUTACAS";
            this.BtnAgregarButacas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnAgregarButacas.Click += new System.EventHandler(this.BtnAgregarButacas_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnCancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Location = new System.Drawing.Point(261, 330);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(117, 36);
            this.BtnCancelar.TabIndex = 70;
            this.BtnCancelar.Text = "FINALIZAR";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnGrabar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnGrabar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGrabar.ForeColor = System.Drawing.Color.White;
            this.BtnGrabar.Location = new System.Drawing.Point(249, 25);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(88, 29);
            this.BtnGrabar.TabIndex = 71;
            this.BtnGrabar.Text = "GUARDAR CAMBIOS";
            this.BtnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // ABMButacas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 396);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnAgregarButacas);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.GroupFiltros);
            this.Controls.Add(this.DgvButacas);
            this.Name = "ABMButacas";
            this.Text = "Modificacion de Butacas";
            this.Load += new System.EventHandler(this.ABMButacas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvButacas)).EndInit();
            this.GroupFiltros.ResumeLayout(false);
            this.GroupFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvButacas;
        private System.Windows.Forms.GroupBox GroupFiltros;
        private System.Windows.Forms.Label BtnLimpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboTipo;
        private System.Windows.Forms.Label BtnAgregarButacas;
        private System.Windows.Forms.Label BtnCancelar;
        private System.Windows.Forms.Label BtnGrabar;


    }
}