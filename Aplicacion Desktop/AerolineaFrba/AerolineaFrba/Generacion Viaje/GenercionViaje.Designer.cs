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
            this.CboMatriculasAeronaves = new System.Windows.Forms.ComboBox();
            this.CboCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.CboCiudadDestino = new System.Windows.Forms.ComboBox();
            this.CboTipoServicio = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DtpFechaLlegada = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaLlegadaEstimada = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.DtpFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.CboMatriculasAeronaves);
            this.groupBox1.Controls.Add(this.CboCiudadOrigen);
            this.groupBox1.Controls.Add(this.CboCiudadDestino);
            this.groupBox1.Controls.Add(this.CboTipoServicio);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.DtpFechaLlegada);
            this.groupBox1.Controls.Add(this.DtpFechaLlegadaEstimada);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.DtpFechaSalida);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 312);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS DEL VIAJE A GENERAR";
            // 
            // CboMatriculasAeronaves
            // 
            this.CboMatriculasAeronaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboMatriculasAeronaves.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboMatriculasAeronaves.FormattingEnabled = true;
            this.CboMatriculasAeronaves.Items.AddRange(new object[] {
            "Borrador",
            "Activa",
            "Pausada",
            "Finalizada"});
            this.CboMatriculasAeronaves.Location = new System.Drawing.Point(134, 24);
            this.CboMatriculasAeronaves.Name = "CboMatriculasAeronaves";
            this.CboMatriculasAeronaves.Size = new System.Drawing.Size(216, 21);
            this.CboMatriculasAeronaves.TabIndex = 64;
            // 
            // CboCiudadOrigen
            // 
            this.CboCiudadOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboCiudadOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboCiudadOrigen.FormattingEnabled = true;
            this.CboCiudadOrigen.Items.AddRange(new object[] {
            "Borrador",
            "Activa",
            "Pausada",
            "Finalizada"});
            this.CboCiudadOrigen.Location = new System.Drawing.Point(134, 58);
            this.CboCiudadOrigen.Name = "CboCiudadOrigen";
            this.CboCiudadOrigen.Size = new System.Drawing.Size(216, 21);
            this.CboCiudadOrigen.TabIndex = 63;
            // 
            // CboCiudadDestino
            // 
            this.CboCiudadDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboCiudadDestino.Enabled = false;
            this.CboCiudadDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboCiudadDestino.FormattingEnabled = true;
            this.CboCiudadDestino.Items.AddRange(new object[] {
            "Borrador",
            "Activa",
            "Pausada",
            "Finalizada"});
            this.CboCiudadDestino.Location = new System.Drawing.Point(134, 95);
            this.CboCiudadDestino.Name = "CboCiudadDestino";
            this.CboCiudadDestino.Size = new System.Drawing.Size(216, 21);
            this.CboCiudadDestino.TabIndex = 62;
            // 
            // CboTipoServicio
            // 
            this.CboTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboTipoServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboTipoServicio.FormattingEnabled = true;
            this.CboTipoServicio.Items.AddRange(new object[] {
            "Borrador",
            "Activa",
            "Pausada",
            "Finalizada"});
            this.CboTipoServicio.Location = new System.Drawing.Point(134, 134);
            this.CboTipoServicio.Name = "CboTipoServicio";
            this.CboTipoServicio.Size = new System.Drawing.Size(216, 21);
            this.CboTipoServicio.TabIndex = 61;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label15.Location = new System.Drawing.Point(113, 142);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 20);
            this.label15.TabIndex = 60;
            this.label15.Text = "*";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 142);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 13);
            this.label13.TabIndex = 59;
            this.label13.Text = "TIPO SERVICIO";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label12.Location = new System.Drawing.Point(113, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 20);
            this.label12.TabIndex = 57;
            this.label12.Text = "*";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "CIUDAD DESTINO";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "CIUDAD ORIGEN";
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
            this.DtpFechaLlegada.Enabled = false;
            this.DtpFechaLlegada.Location = new System.Drawing.Point(189, 275);
            this.DtpFechaLlegada.Name = "DtpFechaLlegada";
            this.DtpFechaLlegada.Size = new System.Drawing.Size(200, 20);
            this.DtpFechaLlegada.TabIndex = 52;
            // 
            // DtpFechaLlegadaEstimada
            // 
            this.DtpFechaLlegadaEstimada.Location = new System.Drawing.Point(189, 232);
            this.DtpFechaLlegadaEstimada.Name = "DtpFechaLlegadaEstimada";
            this.DtpFechaLlegadaEstimada.Size = new System.Drawing.Size(200, 20);
            this.DtpFechaLlegadaEstimada.TabIndex = 51;
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
            this.DtpFechaSalida.Location = new System.Drawing.Point(189, 191);
            this.DtpFechaSalida.Name = "DtpFechaSalida";
            this.DtpFechaSalida.Size = new System.Drawing.Size(200, 20);
            this.DtpFechaSalida.TabIndex = 49;
            this.DtpFechaSalida.Value = new System.DateTime(2015, 10, 28, 19, 15, 33, 0);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label7.Location = new System.Drawing.Point(113, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 20);
            this.label7.TabIndex = 43;
            this.label7.Text = "*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label4.Location = new System.Drawing.Point(113, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 20);
            this.label4.TabIndex = 42;
            this.label4.Text = "*";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "AERONAVE";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 13);
            this.label14.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(173, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 32);
            this.label1.TabIndex = 54;
            this.label1.Text = "LIMPIAR";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DodgerBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(306, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 32);
            this.label2.TabIndex = 53;
            this.label2.Text = "CANCELAR";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DodgerBlue;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(42, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 32);
            this.label3.TabIndex = 52;
            this.label3.Text = "LISTO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label16.Location = new System.Drawing.Point(103, 192);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 20);
            this.label16.TabIndex = 65;
            this.label16.Text = "*";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label17.Location = new System.Drawing.Point(168, 232);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 20);
            this.label17.TabIndex = 66;
            this.label17.Text = "*";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GenercionViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 389);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker DtpFechaSalida;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DtpFechaLlegada;
        private System.Windows.Forms.DateTimePicker DtpFechaLlegadaEstimada;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CboMatriculasAeronaves;
        private System.Windows.Forms.ComboBox CboCiudadOrigen;
        private System.Windows.Forms.ComboBox CboCiudadDestino;
        private System.Windows.Forms.ComboBox CboTipoServicio;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
    }
}