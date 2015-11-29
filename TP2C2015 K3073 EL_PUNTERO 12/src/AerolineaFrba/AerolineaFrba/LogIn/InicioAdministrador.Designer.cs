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
            this.TxtContrasena = new System.Windows.Forms.TextBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.txtAdministrador = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "USUARIO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "CONTRASEÑA";
            // 
            // TxtContrasena
            // 
            this.TxtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtContrasena.Location = new System.Drawing.Point(41, 130);
            this.TxtContrasena.Name = "TxtContrasena";
            this.TxtContrasena.PasswordChar = '*';
            this.TxtContrasena.Size = new System.Drawing.Size(308, 20);
            this.TxtContrasena.TabIndex = 8;
            this.TxtContrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtContrasena_KeyPress);
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUsuario.Location = new System.Drawing.Point(41, 79);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(308, 20);
            this.TxtUsuario.TabIndex = 7;
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEntrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrar.ForeColor = System.Drawing.Color.White;
            this.btnEntrar.Location = new System.Drawing.Point(41, 172);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(143, 32);
            this.btnEntrar.TabIndex = 6;
            this.btnEntrar.Text = "ACEPTAR";
            this.btnEntrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnVolver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(206, 172);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(143, 32);
            this.btnVolver.TabIndex = 12;
            this.btnVolver.Text = "CANCELAR";
            this.btnVolver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(41, 12);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(29, 13);
            this.lblRol.TabIndex = 72;
            this.lblRol.Text = "ROL";
            // 
            // txtAdministrador
            // 
            this.txtAdministrador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdministrador.Location = new System.Drawing.Point(41, 31);
            this.txtAdministrador.Name = "txtAdministrador";
            this.txtAdministrador.Size = new System.Drawing.Size(308, 20);
            this.txtAdministrador.TabIndex = 71;
            // 
            // InicioAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 229);
            this.ControlBox = false;
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.txtAdministrador);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtContrasena);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.btnEntrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InicioAdministrador";
            this.Text = "Inicio Administrador";
            this.Load += new System.EventHandler(this.InicioAdministrador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtContrasena;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Label btnEntrar;
        private System.Windows.Forms.Label btnVolver;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.TextBox txtAdministrador;
    }
}