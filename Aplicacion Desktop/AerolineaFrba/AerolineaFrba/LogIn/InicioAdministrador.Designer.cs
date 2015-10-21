namespace AerolineaFrba.LogIn
{
    partial class InicioAdministrador
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblNuevo = new System.Windows.Forms.Label();
            this.TxtContrasena = new System.Windows.Forms.TextBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.LblEntrar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "USUARIO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "CONTRASEÑA";
            // 
            // LblNuevo
            // 
            this.LblNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblNuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblNuevo.ForeColor = System.Drawing.Color.White;
            this.LblNuevo.Location = new System.Drawing.Point(191, 147);
            this.LblNuevo.Name = "LblNuevo";
            this.LblNuevo.Size = new System.Drawing.Size(88, 32);
            this.LblNuevo.TabIndex = 9;
            this.LblNuevo.Text = "REGISTRARME";
            this.LblNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtContrasena
            // 
            this.TxtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtContrasena.Location = new System.Drawing.Point(41, 99);
            this.TxtContrasena.Name = "TxtContrasena";
            this.TxtContrasena.PasswordChar = '*';
            this.TxtContrasena.Size = new System.Drawing.Size(296, 20);
            this.TxtContrasena.TabIndex = 8;
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUsuario.Location = new System.Drawing.Point(41, 48);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(296, 20);
            this.TxtUsuario.TabIndex = 7;
            // 
            // LblEntrar
            // 
            this.LblEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblEntrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblEntrar.ForeColor = System.Drawing.Color.White;
            this.LblEntrar.Location = new System.Drawing.Point(97, 147);
            this.LblEntrar.Name = "LblEntrar";
            this.LblEntrar.Size = new System.Drawing.Size(88, 32);
            this.LblEntrar.TabIndex = 6;
            this.LblEntrar.Text = "ACEPTAR";
            this.LblEntrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InicioAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 206);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblNuevo);
            this.Controls.Add(this.TxtContrasena);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.LblEntrar);
            this.Name = "InicioAdministrador";
            this.Text = "InicioAdministrador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblNuevo;
        private System.Windows.Forms.TextBox TxtContrasena;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Label LblEntrar;
    }
}