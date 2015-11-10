namespace AerolineaFrba.Devolucion
{
    partial class PasajeEncomienda
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Dtp_FechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.Txt_Dni = new System.Windows.Forms.TextBox();
            this.Btn_DevPasaje = new System.Windows.Forms.Label();
            this.Btn_DevEncomienda = new System.Windows.Forms.Label();
            this.Btn_Cancelar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(148, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(99, 21);
            this.comboBox1.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "TIPO DE DOCUMENTO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "FECHA NACIEMIENTO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "DOCUMENTO";
            // 
            // Dtp_FechaNacimiento
            // 
            this.Dtp_FechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_FechaNacimiento.Location = new System.Drawing.Point(148, 68);
            this.Dtp_FechaNacimiento.Name = "Dtp_FechaNacimiento";
            this.Dtp_FechaNacimiento.Size = new System.Drawing.Size(99, 20);
            this.Dtp_FechaNacimiento.TabIndex = 26;
            this.Dtp_FechaNacimiento.Visible = false;
            // 
            // Txt_Dni
            // 
            this.Txt_Dni.Location = new System.Drawing.Point(148, 42);
            this.Txt_Dni.Name = "Txt_Dni";
            this.Txt_Dni.Size = new System.Drawing.Size(99, 20);
            this.Txt_Dni.TabIndex = 25;
            // 
            // Btn_DevPasaje
            // 
            this.Btn_DevPasaje.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_DevPasaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_DevPasaje.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_DevPasaje.ForeColor = System.Drawing.Color.White;
            this.Btn_DevPasaje.Location = new System.Drawing.Point(212, 104);
            this.Btn_DevPasaje.Name = "Btn_DevPasaje";
            this.Btn_DevPasaje.Size = new System.Drawing.Size(91, 34);
            this.Btn_DevPasaje.TabIndex = 24;
            this.Btn_DevPasaje.Text = "DEVOLUCION\r\n PASAJE";
            this.Btn_DevPasaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_DevEncomienda
            // 
            this.Btn_DevEncomienda.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_DevEncomienda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_DevEncomienda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_DevEncomienda.ForeColor = System.Drawing.Color.White;
            this.Btn_DevEncomienda.Location = new System.Drawing.Point(115, 104);
            this.Btn_DevEncomienda.Name = "Btn_DevEncomienda";
            this.Btn_DevEncomienda.Size = new System.Drawing.Size(91, 34);
            this.Btn_DevEncomienda.TabIndex = 23;
            this.Btn_DevEncomienda.Text = " DEVOLUCION\r\n ENCOMIENDA\r\n";
            this.Btn_DevEncomienda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_DevEncomienda.Click += new System.EventHandler(this.Btn_DevEncomienda_Click_1);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_Cancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Cancelar.ForeColor = System.Drawing.Color.White;
            this.Btn_Cancelar.Location = new System.Drawing.Point(18, 104);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(91, 34);
            this.Btn_Cancelar.TabIndex = 22;
            this.Btn_Cancelar.Text = " CANCELAR";
            this.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click_1);
            // 
            // PasajeEncomienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 150);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Dtp_FechaNacimiento);
            this.Controls.Add(this.Txt_Dni);
            this.Controls.Add(this.Btn_DevPasaje);
            this.Controls.Add(this.Btn_DevEncomienda);
            this.Controls.Add(this.Btn_Cancelar);
            this.Name = "PasajeEncomienda";
            this.Text = "Devolucion Pasaje/Encomienda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker Dtp_FechaNacimiento;
        private System.Windows.Forms.TextBox Txt_Dni;
        private System.Windows.Forms.Label Btn_DevPasaje;
        private System.Windows.Forms.Label Btn_DevEncomienda;
        private System.Windows.Forms.Label Btn_Cancelar;
    }
}