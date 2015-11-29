namespace AerolineaFrba.Abm_Ruta
{
    partial class FrmABMRutaModificacionServicio
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
            this.LstServicios = new System.Windows.Forms.CheckedListBox();
            this.BtnGuardar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LstServicios
            // 
            this.LstServicios.FormattingEnabled = true;
            this.LstServicios.Location = new System.Drawing.Point(12, 47);
            this.LstServicios.Name = "LstServicios";
            this.LstServicios.Size = new System.Drawing.Size(296, 259);
            this.LstServicios.TabIndex = 37;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnGuardar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Location = new System.Drawing.Point(88, 332);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(140, 32);
            this.BtnGuardar.TabIndex = 38;
            this.BtnGuardar.Text = "GUARDAR";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "ELIJA LOS SERVICIOS ASOCIADOS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(192, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmABMRutaModificacionServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 373);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.LstServicios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmABMRutaModificacionServicio";
            this.Text = "Insertar o Modificar Servicios";
            this.Load += new System.EventHandler(this.FrmABMRutaModificacionServicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox LstServicios;
        private System.Windows.Forms.Label BtnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
    }
}