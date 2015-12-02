namespace AerolineaFrba.Listado_Estadistico
{
    partial class Listado_Estadistico
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
            this.LblCerrar = new System.Windows.Forms.Label();
            this.GroupFiltros = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboListado = new System.Windows.Forms.ComboBox();
            this.cboSemestre = new System.Windows.Forms.ComboBox();
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblLimpiar = new System.Windows.Forms.Label();
            this.LblFiltrar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DgvListado = new System.Windows.Forms.DataGridView();
            this.GroupFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // LblCerrar
            // 
            this.LblCerrar.BackColor = System.Drawing.Color.DodgerBlue;
            this.LblCerrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCerrar.ForeColor = System.Drawing.Color.White;
            this.LblCerrar.Location = new System.Drawing.Point(12, 429);
            this.LblCerrar.Name = "LblCerrar";
            this.LblCerrar.Size = new System.Drawing.Size(88, 32);
            this.LblCerrar.TabIndex = 49;
            this.LblCerrar.Text = "LISTO";
            this.LblCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblCerrar.Click += new System.EventHandler(this.LblCerrar_Click);
            // 
            // GroupFiltros
            // 
            this.GroupFiltros.Controls.Add(this.label5);
            this.GroupFiltros.Controls.Add(this.label3);
            this.GroupFiltros.Controls.Add(this.label7);
            this.GroupFiltros.Controls.Add(this.cboListado);
            this.GroupFiltros.Controls.Add(this.cboSemestre);
            this.GroupFiltros.Controls.Add(this.cboAnio);
            this.GroupFiltros.Controls.Add(this.label4);
            this.GroupFiltros.Controls.Add(this.label1);
            this.GroupFiltros.Controls.Add(this.LblLimpiar);
            this.GroupFiltros.Controls.Add(this.LblFiltrar);
            this.GroupFiltros.Controls.Add(this.label2);
            this.GroupFiltros.Location = new System.Drawing.Point(12, 9);
            this.GroupFiltros.Name = "GroupFiltros";
            this.GroupFiltros.Size = new System.Drawing.Size(586, 135);
            this.GroupFiltros.TabIndex = 48;
            this.GroupFiltros.TabStop = false;
            this.GroupFiltros.Text = "FILTROS DE ESTADÍSTICAS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(103, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 20);
            this.label5.TabIndex = 50;
            this.label5.Text = "*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(103, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 20);
            this.label3.TabIndex = 51;
            this.label3.Text = "*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label7.Location = new System.Drawing.Point(104, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 20);
            this.label7.TabIndex = 50;
            this.label7.Text = "*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboListado
            // 
            this.cboListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListado.FormattingEnabled = true;
            this.cboListado.Location = new System.Drawing.Point(121, 84);
            this.cboListado.Name = "cboListado";
            this.cboListado.Size = new System.Drawing.Size(300, 21);
            this.cboListado.TabIndex = 48;
            // 
            // cboSemestre
            // 
            this.cboSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemestre.FormattingEnabled = true;
            this.cboSemestre.Location = new System.Drawing.Point(121, 57);
            this.cboSemestre.Name = "cboSemestre";
            this.cboSemestre.Size = new System.Drawing.Size(169, 21);
            this.cboSemestre.TabIndex = 47;
            // 
            // cboAnio
            // 
            this.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(121, 30);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(169, 21);
            this.cboAnio.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "TIPO DE LISTADO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "SEMESTRE";
            // 
            // LblLimpiar
            // 
            this.LblLimpiar.BackColor = System.Drawing.Color.DodgerBlue;
            this.LblLimpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblLimpiar.ForeColor = System.Drawing.Color.White;
            this.LblLimpiar.Location = new System.Drawing.Point(437, 69);
            this.LblLimpiar.Name = "LblLimpiar";
            this.LblLimpiar.Size = new System.Drawing.Size(124, 32);
            this.LblLimpiar.TabIndex = 35;
            this.LblLimpiar.Text = "LIMPIAR/REFRESCAR";
            this.LblLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblLimpiar.Click += new System.EventHandler(this.LblLimpiar_Click);
            // 
            // LblFiltrar
            // 
            this.LblFiltrar.BackColor = System.Drawing.Color.DodgerBlue;
            this.LblFiltrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblFiltrar.ForeColor = System.Drawing.Color.White;
            this.LblFiltrar.Location = new System.Drawing.Point(437, 30);
            this.LblFiltrar.Name = "LblFiltrar";
            this.LblFiltrar.Size = new System.Drawing.Size(124, 32);
            this.LblFiltrar.TabIndex = 34;
            this.LblFiltrar.Text = "OBTENER ESTADÍSTICA";
            this.LblFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblFiltrar.Click += new System.EventHandler(this.LblFiltrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "AÑO";
            // 
            // DgvListado
            // 
            this.DgvListado.AllowUserToAddRows = false;
            this.DgvListado.AllowUserToDeleteRows = false;
            this.DgvListado.AllowUserToResizeColumns = false;
            this.DgvListado.AllowUserToResizeRows = false;
            this.DgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListado.Location = new System.Drawing.Point(12, 163);
            this.DgvListado.MultiSelect = false;
            this.DgvListado.Name = "DgvListado";
            this.DgvListado.RowHeadersVisible = false;
            this.DgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListado.Size = new System.Drawing.Size(586, 254);
            this.DgvListado.TabIndex = 47;
            // 
            // Listado_Estadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 483);
            this.ControlBox = false;
            this.Controls.Add(this.LblCerrar);
            this.Controls.Add(this.GroupFiltros);
            this.Controls.Add(this.DgvListado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Listado_Estadistico";
            this.Text = "Listado Estadistico";
            this.Load += new System.EventHandler(this.Listado_Estadistico_Load);
            this.GroupFiltros.ResumeLayout(false);
            this.GroupFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblCerrar;
        private System.Windows.Forms.GroupBox GroupFiltros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblLimpiar;
        private System.Windows.Forms.Label LblFiltrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvListado;
        private System.Windows.Forms.ComboBox cboListado;
        private System.Windows.Forms.ComboBox cboSemestre;
        private System.Windows.Forms.ComboBox cboAnio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
    }
}