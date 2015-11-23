namespace AerolineaFrba.Canje_Millas
{
    partial class Canje
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
            this.btnAceptar = new System.Windows.Forms.Label();
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LbLNac = new System.Windows.Forms.Label();
            this.TxtMillas = new System.Windows.Forms.TextBox();
            this.dtpNac = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.LblBuscar = new System.Windows.Forms.Label();
            this.TxtDni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblLimpiar = new System.Windows.Forms.Label();
            this.LblListo = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnVerProductos = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Controls.Add(this.cboTipoDoc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LbLNac);
            this.groupBox1.Controls.Add(this.TxtMillas);
            this.groupBox1.Controls.Add(this.dtpNac);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.LblBuscar);
            this.groupBox1.Controls.Add(this.TxtDni);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 140);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Millas";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAceptar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(318, 61);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(86, 21);
            this.btnAceptar.TabIndex = 50;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.FormattingEnabled = true;
            this.cboTipoDoc.Location = new System.Drawing.Point(135, 22);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(105, 21);
            this.cboTipoDoc.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "TIPO DE DOCUMENTO";
            // 
            // LbLNac
            // 
            this.LbLNac.AutoSize = true;
            this.LbLNac.Location = new System.Drawing.Point(262, 21);
            this.LbLNac.Name = "LbLNac";
            this.LbLNac.Size = new System.Drawing.Size(199, 13);
            this.LbLNac.TabIndex = 37;
            this.LbLNac.Text = "INGRESE SU FECHA DE NACIMIENTO";
            // 
            // TxtMillas
            // 
            this.TxtMillas.Location = new System.Drawing.Point(258, 109);
            this.TxtMillas.Name = "TxtMillas";
            this.TxtMillas.Size = new System.Drawing.Size(86, 20);
            this.TxtMillas.TabIndex = 37;
            this.TxtMillas.Text = "0";
            // 
            // dtpNac
            // 
            this.dtpNac.Location = new System.Drawing.Point(265, 37);
            this.dtpNac.Name = "dtpNac";
            this.dtpNac.Size = new System.Drawing.Size(200, 20);
            this.dtpNac.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "CANTIDAD MILLAS";
            // 
            // LblBuscar
            // 
            this.LblBuscar.BackColor = System.Drawing.Color.DodgerBlue;
            this.LblBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblBuscar.ForeColor = System.Drawing.Color.White;
            this.LblBuscar.Location = new System.Drawing.Point(9, 85);
            this.LblBuscar.Name = "LblBuscar";
            this.LblBuscar.Size = new System.Drawing.Size(86, 29);
            this.LblBuscar.TabIndex = 35;
            this.LblBuscar.Text = "OBTENER PRODUCTOS";
            this.LblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblBuscar.Click += new System.EventHandler(this.LblBuscar_Click);
            // 
            // TxtDni
            // 
            this.TxtDni.Location = new System.Drawing.Point(135, 49);
            this.TxtDni.Name = "TxtDni";
            this.TxtDni.Size = new System.Drawing.Size(105, 20);
            this.TxtDni.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "DOCUMENTO";
            // 
            // LblLimpiar
            // 
            this.LblLimpiar.BackColor = System.Drawing.Color.DodgerBlue;
            this.LblLimpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblLimpiar.ForeColor = System.Drawing.Color.White;
            this.LblLimpiar.Location = new System.Drawing.Point(383, 454);
            this.LblLimpiar.Name = "LblLimpiar";
            this.LblLimpiar.Size = new System.Drawing.Size(124, 32);
            this.LblLimpiar.TabIndex = 51;
            this.LblLimpiar.Text = "LIMPIAR";
            this.LblLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblLimpiar.Click += new System.EventHandler(this.LblLimpiar_Click);
            // 
            // LblListo
            // 
            this.LblListo.BackColor = System.Drawing.Color.DodgerBlue;
            this.LblListo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblListo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblListo.ForeColor = System.Drawing.Color.White;
            this.LblListo.Location = new System.Drawing.Point(12, 454);
            this.LblListo.Name = "LblListo";
            this.LblListo.Size = new System.Drawing.Size(124, 32);
            this.LblListo.TabIndex = 50;
            this.LblListo.Text = "LISTO";
            this.LblListo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblListo.Click += new System.EventHandler(this.LblListo_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(12, 168);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(495, 274);
            this.dgvProductos.TabIndex = 49;
            this.dgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "PRODUCTOS DISPONIBLES";
            // 
            // BtnVerProductos
            // 
            this.BtnVerProductos.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnVerProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnVerProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnVerProductos.ForeColor = System.Drawing.Color.White;
            this.BtnVerProductos.Location = new System.Drawing.Point(194, 454);
            this.BtnVerProductos.Name = "BtnVerProductos";
            this.BtnVerProductos.Size = new System.Drawing.Size(124, 32);
            this.BtnVerProductos.TabIndex = 53;
            this.BtnVerProductos.Text = "VER TODOS LOS PRODUCTOS";
            this.BtnVerProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnVerProductos.Click += new System.EventHandler(this.BtnVerProductos_Click);
            // 
            // Canje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 501);
            this.Controls.Add(this.BtnVerProductos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LblLimpiar);
            this.Controls.Add(this.LblListo);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.groupBox1);
            this.Name = "Canje";
            this.Text = "Canje";
            this.Load += new System.EventHandler(this.Canje_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label btnAceptar;
        private System.Windows.Forms.ComboBox cboTipoDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LbLNac;
        private System.Windows.Forms.DateTimePicker dtpNac;
        private System.Windows.Forms.TextBox TxtMillas;
        private System.Windows.Forms.Label LblBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtDni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblLimpiar;
        private System.Windows.Forms.Label LblListo;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label BtnVerProductos;
    }
}