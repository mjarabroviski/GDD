namespace AerolineaFrba.Generacion_Viaje
{
    partial class GenercionViaje
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
            this.Btn_SeleccionarCiudadDestino = new System.Windows.Forms.Label();
            this.DtpHoraLlegada = new System.Windows.Forms.DateTimePicker();
            this.DtpHoraLlegadaEstimada = new System.Windows.Forms.DateTimePicker();
            this.DtpHoraSalida = new System.Windows.Forms.DateTimePicker();
            this.Btn_Seleccionar = new System.Windows.Forms.Label();
            this.CboAeronave = new System.Windows.Forms.ComboBox();
            this.CboTipoServicio = new System.Windows.Forms.ComboBox();
            this.CboCiudadDestino = new System.Windows.Forms.ComboBox();
            this.CboCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DtpFechaLlegada = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaLlegadaEstimada = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.DtpFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Btn_Limpiar = new System.Windows.Forms.Label();
            this.Btn_Cancelar = new System.Windows.Forms.Label();
            this.Btn_GenerarViaje = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btn_SeleccionarCiudadDestino);
            this.groupBox1.Controls.Add(this.DtpHoraLlegada);
            this.groupBox1.Controls.Add(this.DtpHoraLlegadaEstimada);
            this.groupBox1.Controls.Add(this.DtpHoraSalida);
            this.groupBox1.Controls.Add(this.Btn_Seleccionar);
            this.groupBox1.Controls.Add(this.CboAeronave);
            this.groupBox1.Controls.Add(this.CboTipoServicio);
            this.groupBox1.Controls.Add(this.CboCiudadDestino);
            this.groupBox1.Controls.Add(this.CboCiudadOrigen);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.DtpFechaLlegada);
            this.groupBox1.Controls.Add(this.DtpFechaLlegadaEstimada);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.DtpFechaSalida);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 312);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS DEL VIAJE A GENERAR";
            // 
            // Btn_SeleccionarCiudadDestino
            // 
            this.Btn_SeleccionarCiudadDestino.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_SeleccionarCiudadDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_SeleccionarCiudadDestino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_SeleccionarCiudadDestino.ForeColor = System.Drawing.Color.White;
            this.Btn_SeleccionarCiudadDestino.Location = new System.Drawing.Point(189, 106);
            this.Btn_SeleccionarCiudadDestino.Name = "Btn_SeleccionarCiudadDestino";
            this.Btn_SeleccionarCiudadDestino.Size = new System.Drawing.Size(190, 21);
            this.Btn_SeleccionarCiudadDestino.TabIndex = 75;
            this.Btn_SeleccionarCiudadDestino.Text = "SELECCIONAR CIUDAD DESTINO";
            this.Btn_SeleccionarCiudadDestino.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_SeleccionarCiudadDestino.Click += new System.EventHandler(this.Btn_SeleccionarCiudadDestino_Click);
            // 
            // DtpHoraLlegada
            // 
            this.DtpHoraLlegada.Enabled = false;
            this.DtpHoraLlegada.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DtpHoraLlegada.Location = new System.Drawing.Point(285, 274);
            this.DtpHoraLlegada.Name = "DtpHoraLlegada";
            this.DtpHoraLlegada.ShowUpDown = true;
            this.DtpHoraLlegada.Size = new System.Drawing.Size(88, 20);
            this.DtpHoraLlegada.TabIndex = 74;
            // 
            // DtpHoraLlegadaEstimada
            // 
            this.DtpHoraLlegadaEstimada.Enabled = false;
            this.DtpHoraLlegadaEstimada.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DtpHoraLlegadaEstimada.Location = new System.Drawing.Point(285, 232);
            this.DtpHoraLlegadaEstimada.Name = "DtpHoraLlegadaEstimada";
            this.DtpHoraLlegadaEstimada.ShowUpDown = true;
            this.DtpHoraLlegadaEstimada.Size = new System.Drawing.Size(88, 20);
            this.DtpHoraLlegadaEstimada.TabIndex = 73;
            // 
            // DtpHoraSalida
            // 
            this.DtpHoraSalida.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DtpHoraSalida.Location = new System.Drawing.Point(285, 190);
            this.DtpHoraSalida.Name = "DtpHoraSalida";
            this.DtpHoraSalida.ShowUpDown = true;
            this.DtpHoraSalida.Size = new System.Drawing.Size(88, 20);
            this.DtpHoraSalida.TabIndex = 72;
            this.DtpHoraSalida.ValueChanged += new System.EventHandler(this.DtpHoraSalida_ValueChanged);
            // 
            // Btn_Seleccionar
            // 
            this.Btn_Seleccionar.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_Seleccionar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_Seleccionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Seleccionar.ForeColor = System.Drawing.Color.White;
            this.Btn_Seleccionar.Location = new System.Drawing.Point(189, 65);
            this.Btn_Seleccionar.Name = "Btn_Seleccionar";
            this.Btn_Seleccionar.Size = new System.Drawing.Size(190, 21);
            this.Btn_Seleccionar.TabIndex = 71;
            this.Btn_Seleccionar.Text = "SELECCIONAR CIUDAD ORIGEN";
            this.Btn_Seleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Seleccionar.Click += new System.EventHandler(this.Btn_Seleccionar_Click);
            // 
            // CboAeronave
            // 
            this.CboAeronave.FormattingEnabled = true;
            this.CboAeronave.Location = new System.Drawing.Point(15, 24);
            this.CboAeronave.Name = "CboAeronave";
            this.CboAeronave.Size = new System.Drawing.Size(165, 21);
            this.CboAeronave.TabIndex = 70;
            this.CboAeronave.Text = "MATRICULA AERONAVE";
            this.CboAeronave.SelectedIndexChanged += new System.EventHandler(this.CboAeronave_SelectedIndexChanged);
            // 
            // CboTipoServicio
            // 
            this.CboTipoServicio.Enabled = false;
            this.CboTipoServicio.FormattingEnabled = true;
            this.CboTipoServicio.Location = new System.Drawing.Point(15, 147);
            this.CboTipoServicio.Name = "CboTipoServicio";
            this.CboTipoServicio.Size = new System.Drawing.Size(165, 21);
            this.CboTipoServicio.TabIndex = 69;
            this.CboTipoServicio.Text = "TIPO SERVICIO";
            // 
            // CboCiudadDestino
            // 
            this.CboCiudadDestino.Enabled = false;
            this.CboCiudadDestino.FormattingEnabled = true;
            this.CboCiudadDestino.Location = new System.Drawing.Point(15, 106);
            this.CboCiudadDestino.Name = "CboCiudadDestino";
            this.CboCiudadDestino.Size = new System.Drawing.Size(165, 21);
            this.CboCiudadDestino.TabIndex = 68;
            this.CboCiudadDestino.Text = "CIUDAD DESTINO";
            // 
            // CboCiudadOrigen
            // 
            this.CboCiudadOrigen.FormattingEnabled = true;
            this.CboCiudadOrigen.Location = new System.Drawing.Point(15, 65);
            this.CboCiudadOrigen.Name = "CboCiudadOrigen";
            this.CboCiudadOrigen.Size = new System.Drawing.Size(165, 21);
            this.CboCiudadOrigen.TabIndex = 67;
            this.CboCiudadOrigen.Text = "CIUDAD ORIGEN";
            this.CboCiudadOrigen.Click += new System.EventHandler(this.CboCiudadOrigen_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label17.Location = new System.Drawing.Point(161, 237);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 20);
            this.label17.TabIndex = 66;
            this.label17.Text = "*";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label16.Location = new System.Drawing.Point(92, 195);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 20);
            this.label16.TabIndex = 65;
            this.label16.Text = "*";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 54;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "FECHA LLEGADA";
            // 
            // DtpFechaLlegada
            // 
            this.DtpFechaLlegada.CustomFormat = "dd/MM/yyyy    HH:mm:ss  ";
            this.DtpFechaLlegada.Enabled = false;
            this.DtpFechaLlegada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaLlegada.Location = new System.Drawing.Point(187, 275);
            this.DtpFechaLlegada.Name = "DtpFechaLlegada";
            this.DtpFechaLlegada.Size = new System.Drawing.Size(92, 20);
            this.DtpFechaLlegada.TabIndex = 52;
            // 
            // DtpFechaLlegadaEstimada
            // 
            this.DtpFechaLlegadaEstimada.CustomFormat = "";
            this.DtpFechaLlegadaEstimada.Enabled = false;
            this.DtpFechaLlegadaEstimada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaLlegadaEstimada.Location = new System.Drawing.Point(189, 233);
            this.DtpFechaLlegadaEstimada.Name = "DtpFechaLlegadaEstimada";
            this.DtpFechaLlegadaEstimada.Size = new System.Drawing.Size(92, 20);
            this.DtpFechaLlegadaEstimada.TabIndex = 52;
            this.DtpFechaLlegadaEstimada.ValueChanged += new System.EventHandler(this.DtpFechaLlegadaEstimada_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "FECHA LLEGADA ESTIMADA";
            // 
            // DtpFechaSalida
            // 
            this.DtpFechaSalida.CustomFormat = "d/M/yyy    HH:mm:ss";
            this.DtpFechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaSalida.Location = new System.Drawing.Point(189, 191);
            this.DtpFechaSalida.Name = "DtpFechaSalida";
            this.DtpFechaSalida.Size = new System.Drawing.Size(92, 20);
            this.DtpFechaSalida.TabIndex = 52;
            this.DtpFechaSalida.Value = new System.DateTime(2015, 10, 29, 0, 0, 0, 0);
            this.DtpFechaSalida.ValueChanged += new System.EventHandler(this.DtpFechaSalida_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(14, 197);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 13);
            this.label21.TabIndex = 48;
            this.label21.Text = "FECHA SALIDA";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 13);
            this.label14.TabIndex = 22;
            // 
            // Btn_Limpiar
            // 
            this.Btn_Limpiar.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_Limpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Limpiar.ForeColor = System.Drawing.Color.White;
            this.Btn_Limpiar.Location = new System.Drawing.Point(173, 344);
            this.Btn_Limpiar.Name = "Btn_Limpiar";
            this.Btn_Limpiar.Size = new System.Drawing.Size(95, 32);
            this.Btn_Limpiar.TabIndex = 54;
            this.Btn_Limpiar.Text = "LIMPIAR";
            this.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Limpiar.Click += new System.EventHandler(this.Btn_Limpiar_Click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_Cancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Cancelar.ForeColor = System.Drawing.Color.White;
            this.Btn_Cancelar.Location = new System.Drawing.Point(274, 344);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(95, 32);
            this.Btn_Cancelar.TabIndex = 53;
            this.Btn_Cancelar.Text = "CANCELAR";
            this.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_GenerarViaje
            // 
            this.Btn_GenerarViaje.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_GenerarViaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_GenerarViaje.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_GenerarViaje.ForeColor = System.Drawing.Color.White;
            this.Btn_GenerarViaje.Location = new System.Drawing.Point(72, 344);
            this.Btn_GenerarViaje.Name = "Btn_GenerarViaje";
            this.Btn_GenerarViaje.Size = new System.Drawing.Size(95, 32);
            this.Btn_GenerarViaje.TabIndex = 52;
            this.Btn_GenerarViaje.Text = "GENERAR VIAJE";
            this.Btn_GenerarViaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_GenerarViaje.Click += new System.EventHandler(this.Btn_GenerarViaje_Click);
            // 
            // GenercionViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 389);
            this.Controls.Add(this.Btn_Limpiar);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_GenerarViaje);
            this.Controls.Add(this.groupBox1);
            this.Name = "GenercionViaje";
            this.Text = "GenercionViaje";
            this.Load += new System.EventHandler(this.GenercionViaje_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker DtpFechaSalida;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DtpFechaLlegada;
        private System.Windows.Forms.DateTimePicker DtpFechaLlegadaEstimada;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Btn_Limpiar;
        private System.Windows.Forms.Label Btn_Cancelar;
        private System.Windows.Forms.Label Btn_GenerarViaje;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox CboCiudadOrigen;
        private System.Windows.Forms.ComboBox CboCiudadDestino;
        private System.Windows.Forms.ComboBox CboTipoServicio;
        private System.Windows.Forms.ComboBox CboAeronave;
        private System.Windows.Forms.Label Btn_Seleccionar;
        private System.Windows.Forms.DateTimePicker DtpHoraLlegada;
        private System.Windows.Forms.DateTimePicker DtpHoraLlegadaEstimada;
        private System.Windows.Forms.DateTimePicker DtpHoraSalida;
        private System.Windows.Forms.Label Btn_SeleccionarCiudadDestino;
    }
}