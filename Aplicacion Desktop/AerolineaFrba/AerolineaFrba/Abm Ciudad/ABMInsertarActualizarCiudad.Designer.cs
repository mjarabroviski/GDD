namespace AerolineaFrba.Abm_Ciudad
{
    partial class ABMInsertarActualizarCiudad
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
            this.BtnLimpiar = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Label();
            this.BtnGrabar = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtNombreCiudad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnLimpiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.ForeColor = System.Drawing.Color.White;
            this.BtnLimpiar.Location = new System.Drawing.Point(107, 81);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(92, 36);
            this.BtnLimpiar.TabIndex = 35;
            this.BtnLimpiar.Text = "LIMPIAR";
            this.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnLimpiar.Click += new System.EventHandler(this.LblLimpiar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnCancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Location = new System.Drawing.Point(204, 81);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(92, 36);
            this.BtnCancelar.TabIndex = 34;
            this.BtnCancelar.Text = "CANCELAR";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnCancelar.Click += new System.EventHandler(this.LblCancelar_Click);
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnGrabar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnGrabar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGrabar.ForeColor = System.Drawing.Color.White;
            this.BtnGrabar.Location = new System.Drawing.Point(6, 81);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(96, 36);
            this.BtnGrabar.TabIndex = 33;
            this.BtnGrabar.Text = "GRABAR";
            this.BtnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnGrabar.Click += new System.EventHandler(this.LblGrabar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnGrabar);
            this.groupBox1.Controls.Add(this.BtnCancelar);
            this.groupBox1.Controls.Add(this.BtnLimpiar);
            this.groupBox1.Controls.Add(this.TxtNombreCiudad);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 134);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INFORMACION DE CIUDAD";
            // 
            // TxtNombreCiudad
            // 
            this.TxtNombreCiudad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNombreCiudad.Location = new System.Drawing.Point(17, 43);
            this.TxtNombreCiudad.Name = "TxtNombreCiudad";
            this.TxtNombreCiudad.Size = new System.Drawing.Size(262, 20);
            this.TxtNombreCiudad.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label3.Location = new System.Drawing.Point(67, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "NOMBRE";
            // 
            // ABMInsertarActualizarCiudad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 161);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(341, 200);
            this.MinimumSize = new System.Drawing.Size(341, 200);
            this.Name = "ABMInsertarActualizarCiudad";
            this.Text = "ABMInsertarActualizarCiudad";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label BtnLimpiar;
        private System.Windows.Forms.Label BtnCancelar;
        private System.Windows.Forms.Label BtnGrabar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtNombreCiudad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}