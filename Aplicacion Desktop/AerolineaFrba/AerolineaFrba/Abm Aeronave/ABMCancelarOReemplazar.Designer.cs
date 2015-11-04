namespace AerolineaFrba.Abm_Aeronave
{
    partial class ABMCancelarOReemplazar
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
            this.LblReemplazar = new System.Windows.Forms.Label();
            this.LblCancelar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblVolver = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblReemplazar
            // 
            this.LblReemplazar.BackColor = System.Drawing.Color.DodgerBlue;
            this.LblReemplazar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblReemplazar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblReemplazar.ForeColor = System.Drawing.Color.White;
            this.LblReemplazar.Location = new System.Drawing.Point(158, 107);
            this.LblReemplazar.Name = "LblReemplazar";
            this.LblReemplazar.Size = new System.Drawing.Size(140, 32);
            this.LblReemplazar.TabIndex = 39;
            this.LblReemplazar.Text = "REEMPLAZAR AERONAVE";
            this.LblReemplazar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblReemplazar.Click += new System.EventHandler(this.LblReemplazar_Click_1);
            // 
            // LblCancelar
            // 
            this.LblCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.LblCancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCancelar.ForeColor = System.Drawing.Color.White;
            this.LblCancelar.Location = new System.Drawing.Point(12, 107);
            this.LblCancelar.Name = "LblCancelar";
            this.LblCancelar.Size = new System.Drawing.Size(140, 32);
            this.LblCancelar.TabIndex = 38;
            this.LblCancelar.Text = "CANCELAR PASAJES/ENCOMIENDAS";
            this.LblCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblCancelar.Click += new System.EventHandler(this.LblCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(411, 36);
            this.label2.TabIndex = 37;
            this.label2.Text = "La aeronave seleccionada tiene viajes programados a futuro. \r\nQue accion desea re" +
    "alizar?";
            // 
            // LblVolver
            // 
            this.LblVolver.BackColor = System.Drawing.Color.DodgerBlue;
            this.LblVolver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblVolver.ForeColor = System.Drawing.Color.White;
            this.LblVolver.Location = new System.Drawing.Point(304, 107);
            this.LblVolver.Name = "LblVolver";
            this.LblVolver.Size = new System.Drawing.Size(145, 32);
            this.LblVolver.TabIndex = 40;
            this.LblVolver.Text = "CANCELAR";
            this.LblVolver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblVolver.Click += new System.EventHandler(this.LblVolver_Click);
            // 
            // ABMCancelarOReemplazar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 168);
            this.Controls.Add(this.LblVolver);
            this.Controls.Add(this.LblReemplazar);
            this.Controls.Add(this.LblCancelar);
            this.Controls.Add(this.label2);
            this.Name = "ABMCancelarOReemplazar";
            this.Text = "Informacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblReemplazar;
        private System.Windows.Forms.Label LblCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblVolver;
    }
}