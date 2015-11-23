namespace AerolineaFrba.Devolucion
{
    partial class MotivoDevolucion
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
            this.Txt_Motivo = new System.Windows.Forms.TextBox();
            this.Lbl_ingresar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_OK = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Txt_Motivo
            // 
            this.Txt_Motivo.Location = new System.Drawing.Point(12, 51);
            this.Txt_Motivo.Multiline = true;
            this.Txt_Motivo.Name = "Txt_Motivo";
            this.Txt_Motivo.Size = new System.Drawing.Size(348, 168);
            this.Txt_Motivo.TabIndex = 0;
            // 
            // Lbl_ingresar
            // 
            this.Lbl_ingresar.AutoSize = true;
            this.Lbl_ingresar.Location = new System.Drawing.Point(12, 27);
            this.Lbl_ingresar.Name = "Lbl_ingresar";
            this.Lbl_ingresar.Size = new System.Drawing.Size(221, 13);
            this.Lbl_ingresar.TabIndex = 1;
            this.Lbl_ingresar.Text = "INGRESE EL MOTIVO DE LA DEVOLICION:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "( Máximo 100 caracteres )";
            // 
            // Btn_OK
            // 
            this.Btn_OK.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_OK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Btn_OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_OK.ForeColor = System.Drawing.Color.White;
            this.Btn_OK.Location = new System.Drawing.Point(317, 222);
            this.Btn_OK.Name = "Btn_OK";
            this.Btn_OK.Size = new System.Drawing.Size(43, 21);
            this.Btn_OK.TabIndex = 100;
            this.Btn_OK.Text = "OK";
            this.Btn_OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_OK.Click += new System.EventHandler(this.Btn_OK_Click);
            // 
            // MotivoDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 261);
            this.Controls.Add(this.Btn_OK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lbl_ingresar);
            this.Controls.Add(this.Txt_Motivo);
            this.Name = "MotivoDevolucion";
            this.Text = "MotivoDevolucion";
            this.Load += new System.EventHandler(this.MotivoDevolucion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_Motivo;
        private System.Windows.Forms.Label Lbl_ingresar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Btn_OK;
    }
}