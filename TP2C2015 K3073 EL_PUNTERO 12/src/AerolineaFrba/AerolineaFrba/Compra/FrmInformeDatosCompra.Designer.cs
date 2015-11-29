namespace AerolineaFrba.Compra
{
    partial class FrmInformeDatosCompra
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPNR = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnOK = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(26, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 67);
            this.panel1.TabIndex = 109;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(122, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 31);
            this.label16.TabIndex = 107;
            this.label16.Text = "PRECIO";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 25);
            this.label15.TabIndex = 106;
            this.label15.Text = "PRECIO:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel2.Controls.Add(this.txtPNR);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(26, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 50);
            this.panel2.TabIndex = 110;
            // 
            // txtPNR
            // 
            this.txtPNR.Enabled = false;
            this.txtPNR.Location = new System.Drawing.Point(87, 13);
            this.txtPNR.Multiline = true;
            this.txtPNR.Name = "txtPNR";
            this.txtPNR.Size = new System.Drawing.Size(144, 25);
            this.txtPNR.TabIndex = 108;
            this.txtPNR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 25);
            this.label2.TabIndex = 106;
            this.label2.Text = "PNR :";
            // 
            // BtnOK
            // 
            this.BtnOK.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnOK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOK.ForeColor = System.Drawing.Color.White;
            this.BtnOK.Location = new System.Drawing.Point(113, 166);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(88, 43);
            this.BtnOK.TabIndex = 118;
            this.BtnOK.Text = "OK";
            this.BtnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // FrmInformeDatosCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 218);
            this.ControlBox = false;
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInformeDatosCompra";
            this.Text = "Informe de Datos de Compra";
            this.Load += new System.EventHandler(this.FrmInformeDatosCompra_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label BtnOK;
        private System.Windows.Forms.TextBox txtPNR;
    }
}