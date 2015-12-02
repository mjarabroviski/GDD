namespace AerolineaFrba.Devolucion
{
    partial class DevolucionEncomiendaPasaje
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
            this.DgvEncomiendas = new System.Windows.Forms.DataGridView();
            this.DgvPasaje = new System.Windows.Forms.DataGridView();
            this.Btn_Buscar2 = new System.Windows.Forms.Label();
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNac = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Dtp_FechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.Txt_Dni = new System.Windows.Forms.TextBox();
            this.Btn_Limpiar = new System.Windows.Forms.Label();
            this.Btn_Buscar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEncomiendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPasaje)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Finalizar
            // 
            this.Btn_Finalizar.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_Finalizar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_Finalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Finalizar.ForeColor = System.Drawing.Color.White;
            this.Btn_Finalizar.Location = new System.Drawing.Point(1210, 524);
            this.Btn_Finalizar.Name = "Btn_Finalizar";
            this.Btn_Finalizar.Size = new System.Drawing.Size(91, 34);
            this.Btn_Finalizar.TabIndex = 85;
            this.Btn_Finalizar.Text = "FINALIZAR";
            this.Btn_Finalizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Finalizar.Click += new System.EventHandler(this.Btn_Finalizar_Click);
            // 
            // Btn_DevolverTodos
            // 
            this.Btn_DevolverTodos.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_DevolverTodos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_DevolverTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_DevolverTodos.Enabled = false;
            this.Btn_DevolverTodos.ForeColor = System.Drawing.Color.White;
            this.Btn_DevolverTodos.Location = new System.Drawing.Point(15, 524);
            this.Btn_DevolverTodos.Name = "Btn_DevolverTodos";
            this.Btn_DevolverTodos.Size = new System.Drawing.Size(91, 34);
            this.Btn_DevolverTodos.TabIndex = 84;
            this.Btn_DevolverTodos.Text = "DEVOLVER TODO";
            this.Btn_DevolverTodos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_DevolverTodos.Click += new System.EventHandler(this.Btn_DevolverTodos_Click);
            // 
            // DgvEncomiendas
            // 
            this.DgvEncomiendas.AllowUserToAddRows = false;
            this.DgvEncomiendas.AllowUserToDeleteRows = false;
            this.DgvEncomiendas.AllowUserToResizeColumns = false;
            this.DgvEncomiendas.AllowUserToResizeRows = false;
            this.DgvEncomiendas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvEncomiendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEncomiendas.Location = new System.Drawing.Point(15, 99);
            this.DgvEncomiendas.MultiSelect = false;
            this.DgvEncomiendas.Name = "DgvEncomiendas";
            this.DgvEncomiendas.RowHeadersVisible = false;
            this.DgvEncomiendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEncomiendas.Size = new System.Drawing.Size(660, 422);
            this.DgvEncomiendas.TabIndex = 80;
            this.DgvEncomiendas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEncomiendas_CellContentClick);
            // 
            // DgvPasaje
            // 
            this.DgvPasaje.AllowUserToAddRows = false;
            this.DgvPasaje.AllowUserToDeleteRows = false;
            this.DgvPasaje.AllowUserToResizeColumns = false;
            this.DgvPasaje.AllowUserToResizeRows = false;
            this.DgvPasaje.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvPasaje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPasaje.Location = new System.Drawing.Point(690, 100);
            this.DgvPasaje.MultiSelect = false;
            this.DgvPasaje.Name = "DgvPasaje";
            this.DgvPasaje.RowHeadersVisible = false;
            this.DgvPasaje.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPasaje.Size = new System.Drawing.Size(611, 421);
            this.DgvPasaje.TabIndex = 91;
            // 
            // Btn_Buscar2
            // 
            this.Btn_Buscar2.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_Buscar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_Buscar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Buscar2.ForeColor = System.Drawing.Color.White;
            this.Btn_Buscar2.Location = new System.Drawing.Point(376, 68);
            this.Btn_Buscar2.Name = "Btn_Buscar2";
            this.Btn_Buscar2.Size = new System.Drawing.Size(83, 19);
            this.Btn_Buscar2.TabIndex = 98;
            this.Btn_Buscar2.Text = "BUSCAR";
            this.Btn_Buscar2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Buscar2.Visible = false;
            this.Btn_Buscar2.Click += new System.EventHandler(this.Btn_Buscar2_Click);
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDoc.FormattingEnabled = true;
            this.cboTipoDoc.Location = new System.Drawing.Point(137, 10);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(200, 21);
            this.cboTipoDoc.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 96;
            this.label1.Text = "TIPO DE DOCUMENTO";
            // 
            // lblNac
            // 
            this.lblNac.AutoSize = true;
            this.lblNac.Location = new System.Drawing.Point(12, 71);
            this.lblNac.Name = "lblNac";
            this.lblNac.Size = new System.Drawing.Size(119, 13);
            this.lblNac.TabIndex = 95;
            this.lblNac.Text = "FECHA NACIEMIENTO";
            this.lblNac.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 94;
            this.label3.Text = "DOCUMENTO";
            // 
            // Dtp_FechaNacimiento
            // 
            this.Dtp_FechaNacimiento.CustomFormat = "                   d / M / yyyy ";
            this.Dtp_FechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_FechaNacimiento.Location = new System.Drawing.Point(137, 65);
            this.Dtp_FechaNacimiento.Name = "Dtp_FechaNacimiento";
            this.Dtp_FechaNacimiento.Size = new System.Drawing.Size(200, 20);
            this.Dtp_FechaNacimiento.TabIndex = 93;
            this.Dtp_FechaNacimiento.Visible = false;
            // 
            // Txt_Dni
            // 
            this.Txt_Dni.Location = new System.Drawing.Point(137, 39);
            this.Txt_Dni.Name = "Txt_Dni";
            this.Txt_Dni.Size = new System.Drawing.Size(200, 20);
            this.Txt_Dni.TabIndex = 92;
            // 
            // Btn_Limpiar
            // 
            this.Btn_Limpiar.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_Limpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Limpiar.ForeColor = System.Drawing.Color.White;
            this.Btn_Limpiar.Location = new System.Drawing.Point(376, 38);
            this.Btn_Limpiar.Name = "Btn_Limpiar";
            this.Btn_Limpiar.Size = new System.Drawing.Size(83, 21);
            this.Btn_Limpiar.TabIndex = 99;
            this.Btn_Limpiar.Text = "LIMPIAR";
            this.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Limpiar.Click += new System.EventHandler(this.Btn_Limpiar_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_Buscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Buscar.ForeColor = System.Drawing.Color.White;
            this.Btn_Buscar.Location = new System.Drawing.Point(376, 11);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(83, 20);
            this.Btn_Buscar.TabIndex = 100;
            this.Btn_Buscar.Text = "BUSCAR";
            this.Btn_Buscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // DevolucionEncomiendaPasaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 570);
            this.ControlBox = false;
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Btn_Limpiar);
            this.Controls.Add(this.Btn_Buscar2);
            this.Controls.Add(this.cboTipoDoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNac);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Dtp_FechaNacimiento);
            this.Controls.Add(this.Txt_Dni);
            this.Controls.Add(this.DgvPasaje);
            this.Controls.Add(this.Btn_Finalizar);
            this.Controls.Add(this.Btn_DevolverTodos);
            this.Controls.Add(this.DgvEncomiendas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DevolucionEncomiendaPasaje";
            this.Text = "Devolución Encomienda/Pasaje";
            this.Load += new System.EventHandler(this.DevolucionEncomienda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvEncomiendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPasaje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Btn_Finalizar;
        private System.Windows.Forms.Label Btn_DevolverTodos;
        private System.Windows.Forms.DataGridView DgvEncomiendas;
        private System.Windows.Forms.DataGridView DgvPasaje;
        private System.Windows.Forms.Label Btn_Buscar2;
        private System.Windows.Forms.ComboBox cboTipoDoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker Dtp_FechaNacimiento;
        private System.Windows.Forms.TextBox Txt_Dni;
        private System.Windows.Forms.Label Btn_Limpiar;
        private System.Windows.Forms.Label Btn_Buscar;

    }
}