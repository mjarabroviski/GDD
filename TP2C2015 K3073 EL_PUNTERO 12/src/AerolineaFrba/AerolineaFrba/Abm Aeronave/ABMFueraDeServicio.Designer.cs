namespace AerolineaFrba.Abm_Aeronave
{
    partial class ABMFueraDeServicio
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
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpFechaComienzo = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaReinicio = new System.Windows.Forms.DateTimePicker();
            this.BtnGrabar = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Label();
            this.txtAeronave = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "FECHA COMIENZO BAJA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "FECHA REINICIO SERVICIO";
            // 
            // DtpFechaComienzo
            // 
            this.DtpFechaComienzo.CustomFormat = "dd/MM/yyyy HH:mm";
            this.DtpFechaComienzo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFechaComienzo.Location = new System.Drawing.Point(169, 49);
            this.DtpFechaComienzo.Name = "DtpFechaComienzo";
            this.DtpFechaComienzo.Size = new System.Drawing.Size(153, 20);
            this.DtpFechaComienzo.TabIndex = 84;
            this.DtpFechaComienzo.ValueChanged += new System.EventHandler(this.DtpFechaComienzo_ValueChanged);
            // 
            // DtpFechaReinicio
            // 
            this.DtpFechaReinicio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.DtpFechaReinicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFechaReinicio.Location = new System.Drawing.Point(169, 89);
            this.DtpFechaReinicio.Name = "DtpFechaReinicio";
            this.DtpFechaReinicio.Size = new System.Drawing.Size(153, 20);
            this.DtpFechaReinicio.TabIndex = 85;
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnGrabar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnGrabar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGrabar.ForeColor = System.Drawing.Color.White;
            this.BtnGrabar.Location = new System.Drawing.Point(56, 129);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(106, 36);
            this.BtnGrabar.TabIndex = 86;
            this.BtnGrabar.Text = "GRABAR";
            this.BtnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnCancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Location = new System.Drawing.Point(168, 129);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(104, 36);
            this.BtnCancelar.TabIndex = 87;
            this.BtnCancelar.Text = "CANCELAR";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // txtAeronave
            // 
            this.txtAeronave.Location = new System.Drawing.Point(169, 12);
            this.txtAeronave.Name = "txtAeronave";
            this.txtAeronave.Size = new System.Drawing.Size(100, 20);
            this.txtAeronave.TabIndex = 88;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 89;
            this.label2.Text = "AERONAVE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(143, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 20);
            this.label3.TabIndex = 90;
            this.label3.Text = "*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(153, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 20);
            this.label5.TabIndex = 91;
            this.label5.Text = "*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ABMFueraDeServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 183);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAeronave);
            this.Controls.Add(this.BtnGrabar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.DtpFechaReinicio);
            this.Controls.Add(this.DtpFechaComienzo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ABMFueraDeServicio";
            this.Text = "Fuera De Servicio Aeronave";
            this.Load += new System.EventHandler(this.ABMFueraDeServicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpFechaComienzo;
        private System.Windows.Forms.DateTimePicker DtpFechaReinicio;
        private System.Windows.Forms.Label BtnGrabar;
        private System.Windows.Forms.Label BtnCancelar;
        private System.Windows.Forms.TextBox txtAeronave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}