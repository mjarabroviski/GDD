namespace AerolineaFrba.Compra
{
    partial class FrmIngresoCantidades
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NumPasajes = new System.Windows.Forms.NumericUpDown();
            this.NumEncomiendas = new System.Windows.Forms.NumericUpDown();
            this.BtnAceptar = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumPasajes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumEncomiendas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese las cantidades a comprar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pasajes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kilogramos";
            // 
            // NumPasajes
            // 
            this.NumPasajes.BackColor = System.Drawing.Color.White;
            this.NumPasajes.Location = new System.Drawing.Point(109, 67);
            this.NumPasajes.Name = "NumPasajes";
            this.NumPasajes.Size = new System.Drawing.Size(120, 20);
            this.NumPasajes.TabIndex = 5;
            // 
            // NumEncomiendas
            // 
            this.NumEncomiendas.BackColor = System.Drawing.Color.White;
            this.NumEncomiendas.Location = new System.Drawing.Point(109, 126);
            this.NumEncomiendas.Name = "NumEncomiendas";
            this.NumEncomiendas.Size = new System.Drawing.Size(120, 20);
            this.NumEncomiendas.TabIndex = 6;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAceptar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAceptar.ForeColor = System.Drawing.Color.White;
            this.BtnAceptar.Location = new System.Drawing.Point(173, 180);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(88, 32);
            this.BtnAceptar.TabIndex = 27;
            this.BtnAceptar.Text = "ACEPTAR";
            this.BtnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnCancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Location = new System.Drawing.Point(24, 180);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(88, 32);
            this.BtnCancelar.TabIndex = 28;
            this.BtnCancelar.Text = "CANCELAR";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // FrmIngresoCantidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 233);
            this.ControlBox = false;
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.NumEncomiendas);
            this.Controls.Add(this.NumPasajes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmIngresoCantidades";
            this.Text = "Ingreso Cantidades";
            ((System.ComponentModel.ISupportInitialize)(this.NumPasajes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumEncomiendas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumPasajes;
        private System.Windows.Forms.NumericUpDown NumEncomiendas;
        private System.Windows.Forms.Label BtnAceptar;
        private System.Windows.Forms.Label BtnCancelar;
    }
}