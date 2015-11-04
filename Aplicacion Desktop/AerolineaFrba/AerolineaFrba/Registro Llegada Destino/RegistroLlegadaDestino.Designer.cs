namespace AerolineaFrba.Registro_Llegada_Destino
{
    partial class RegistroLlegadaDestino
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
            this.DtpFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.CboAeronave = new System.Windows.Forms.ComboBox();
            this.CboCiudadDestino = new System.Windows.Forms.ComboBox();
            this.CboCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.RegistroLlegadaADestino = new System.Windows.Forms.GroupBox();
            this.Btn_Cancelar = new System.Windows.Forms.Label();
            this.Btn_Aceptar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Btn_Limpiar = new System.Windows.Forms.Label();
            this.RegistroLlegadaADestino.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtpFechaSalida
            // 
            this.DtpFechaSalida.CustomFormat = "d/MM/yyyy   HH:mm:ss";
            this.DtpFechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFechaSalida.Location = new System.Drawing.Point(129, 167);
            this.DtpFechaSalida.Name = "DtpFechaSalida";
            this.DtpFechaSalida.Size = new System.Drawing.Size(150, 20);
            this.DtpFechaSalida.TabIndex = 78;
            this.DtpFechaSalida.Value = new System.DateTime(2015, 10, 29, 0, 0, 0, 0);
            // 
            // CboAeronave
            // 
            this.CboAeronave.FormattingEnabled = true;
            this.CboAeronave.Location = new System.Drawing.Point(22, 43);
            this.CboAeronave.Name = "CboAeronave";
            this.CboAeronave.Size = new System.Drawing.Size(165, 21);
            this.CboAeronave.TabIndex = 70;
            this.CboAeronave.Text = "MATRICULA AERONAVE";
            // 
            // CboCiudadDestino
            // 
            this.CboCiudadDestino.FormattingEnabled = true;
            this.CboCiudadDestino.Location = new System.Drawing.Point(22, 125);
            this.CboCiudadDestino.Name = "CboCiudadDestino";
            this.CboCiudadDestino.Size = new System.Drawing.Size(165, 21);
            this.CboCiudadDestino.TabIndex = 68;
            this.CboCiudadDestino.Text = "CIUDAD DESTINO";
            // 
            // CboCiudadOrigen
            // 
            this.CboCiudadOrigen.FormattingEnabled = true;
            this.CboCiudadOrigen.Location = new System.Drawing.Point(22, 84);
            this.CboCiudadOrigen.Name = "CboCiudadOrigen";
            this.CboCiudadOrigen.Size = new System.Drawing.Size(165, 21);
            this.CboCiudadOrigen.TabIndex = 67;
            this.CboCiudadOrigen.Text = "CIUDAD ORIGEN";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(19, 173);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 13);
            this.label21.TabIndex = 48;
            this.label21.Text = "FECHA SALIDA";
            // 
            // RegistroLlegadaADestino
            // 
            this.RegistroLlegadaADestino.Controls.Add(this.Btn_Limpiar);
            this.RegistroLlegadaADestino.Controls.Add(this.Btn_Cancelar);
            this.RegistroLlegadaADestino.Controls.Add(this.Btn_Aceptar);
            this.RegistroLlegadaADestino.Controls.Add(this.label4);
            this.RegistroLlegadaADestino.Controls.Add(this.label3);
            this.RegistroLlegadaADestino.Controls.Add(this.label2);
            this.RegistroLlegadaADestino.Controls.Add(this.DtpFechaSalida);
            this.RegistroLlegadaADestino.Controls.Add(this.CboAeronave);
            this.RegistroLlegadaADestino.Controls.Add(this.CboCiudadDestino);
            this.RegistroLlegadaADestino.Controls.Add(this.CboCiudadOrigen);
            this.RegistroLlegadaADestino.Controls.Add(this.label16);
            this.RegistroLlegadaADestino.Controls.Add(this.label9);
            this.RegistroLlegadaADestino.Controls.Add(this.label21);
            this.RegistroLlegadaADestino.Controls.Add(this.label14);
            this.RegistroLlegadaADestino.Location = new System.Drawing.Point(11, 12);
            this.RegistroLlegadaADestino.Name = "RegistroLlegadaADestino";
            this.RegistroLlegadaADestino.Size = new System.Drawing.Size(314, 250);
            this.RegistroLlegadaADestino.TabIndex = 48;
            this.RegistroLlegadaADestino.TabStop = false;
            this.RegistroLlegadaADestino.Text = "REGISTRO LLEGADA A DESTINO";
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_Cancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Cancelar.ForeColor = System.Drawing.Color.White;
            this.Btn_Cancelar.Location = new System.Drawing.Point(114, 206);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(76, 23);
            this.Btn_Cancelar.TabIndex = 95;
            this.Btn_Cancelar.Text = "CANCELAR";
            this.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click_1);
            // 
            // Btn_Aceptar
            // 
            this.Btn_Aceptar.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_Aceptar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_Aceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Aceptar.ForeColor = System.Drawing.Color.White;
            this.Btn_Aceptar.Location = new System.Drawing.Point(196, 206);
            this.Btn_Aceptar.Name = "Btn_Aceptar";
            this.Btn_Aceptar.Size = new System.Drawing.Size(76, 23);
            this.Btn_Aceptar.TabIndex = 94;
            this.Btn_Aceptar.Text = "ACEPTAR";
            this.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Aceptar.Click += new System.EventHandler(this.Btn_Aceptar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label4.Location = new System.Drawing.Point(193, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 20);
            this.label4.TabIndex = 86;
            this.label4.Text = "*";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label3.Location = new System.Drawing.Point(193, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 20);
            this.label3.TabIndex = 85;
            this.label3.Text = "*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label2.Location = new System.Drawing.Point(192, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 84;
            this.label2.Text = "*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label16.Location = new System.Drawing.Point(99, 173);
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
            this.Btn_Limpiar.Location = new System.Drawing.Point(32, 206);
            this.Btn_Limpiar.Name = "Btn_Limpiar";
            this.Btn_Limpiar.Size = new System.Drawing.Size(76, 23);
            this.Btn_Limpiar.TabIndex = 96;
            this.Btn_Limpiar.Text = "LIMPIAR";
            this.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Limpiar.Click += new System.EventHandler(this.Btn_Limpiar_Click);
            // 
            // RegistroLlegadaDestino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 270);
            this.Controls.Add(this.RegistroLlegadaADestino);
            this.Name = "RegistroLlegadaDestino";
            this.Text = "RegistroLlegadaDestino";
            this.Load += new System.EventHandler(this.RegistroLlegadaDestino_Load);
            this.RegistroLlegadaADestino.ResumeLayout(false);
            this.RegistroLlegadaADestino.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DtpFechaSalida;
        private System.Windows.Forms.ComboBox CboAeronave;
        private System.Windows.Forms.ComboBox CboCiudadDestino;
        private System.Windows.Forms.ComboBox CboCiudadOrigen;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox RegistroLlegadaADestino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label Btn_Cancelar;
        private System.Windows.Forms.Label Btn_Aceptar;
        private System.Windows.Forms.Label Btn_Limpiar;

    }
}