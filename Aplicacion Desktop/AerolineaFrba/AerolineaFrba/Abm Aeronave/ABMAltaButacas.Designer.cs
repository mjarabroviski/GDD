namespace AerolineaFrba.Abm_Aeronave
{
    partial class ABMAltaButacas
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
            this.TxtPasillo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtVentanilla = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnGrabar = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtPasillo
            // 
            this.TxtPasillo.Location = new System.Drawing.Point(149, 18);
            this.TxtPasillo.Name = "TxtPasillo";
            this.TxtPasillo.Size = new System.Drawing.Size(82, 20);
            this.TxtPasillo.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "CANTIDAD PASILLO";
            // 
            // TxtVentanilla
            // 
            this.TxtVentanilla.Location = new System.Drawing.Point(149, 48);
            this.TxtVentanilla.Name = "TxtVentanilla";
            this.TxtVentanilla.Size = new System.Drawing.Size(82, 20);
            this.TxtVentanilla.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "CANTIDAD VENTANILLA";
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnGrabar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnGrabar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGrabar.ForeColor = System.Drawing.Color.White;
            this.BtnGrabar.Location = new System.Drawing.Point(15, 94);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(106, 36);
            this.BtnGrabar.TabIndex = 67;
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
            this.BtnCancelar.Location = new System.Drawing.Point(127, 94);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(104, 36);
            this.BtnCancelar.TabIndex = 68;
            this.BtnCancelar.Text = "CANCELAR";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // ABMAltaButacas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 157);
            this.Controls.Add(this.BtnGrabar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.TxtVentanilla);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtPasillo);
            this.Controls.Add(this.label4);
            this.Name = "ABMAltaButacas";
            this.Text = "ABMAltaButacas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtPasillo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtVentanilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label BtnGrabar;
        private System.Windows.Forms.Label BtnCancelar;
    }
}