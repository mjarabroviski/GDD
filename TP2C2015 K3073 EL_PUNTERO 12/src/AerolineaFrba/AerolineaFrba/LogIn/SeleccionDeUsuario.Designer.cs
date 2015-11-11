namespace AerolineaFrba.LogIn
{
    partial class SeleccionDeUsuario
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
            this.CboRoles = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEntrar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CboRoles
            // 
            this.CboRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboRoles.FormattingEnabled = true;
            this.CboRoles.Location = new System.Drawing.Point(65, 62);
            this.CboRoles.Name = "CboRoles";
            this.CboRoles.Size = new System.Drawing.Size(296, 21);
            this.CboRoles.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "ROL A USAR";
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEntrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrar.ForeColor = System.Drawing.Color.White;
            this.btnEntrar.Location = new System.Drawing.Point(139, 126);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(119, 32);
            this.btnEntrar.TabIndex = 13;
            this.btnEntrar.Text = "LISTO";
            this.btnEntrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // SeleccionDeUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 206);
            this.Controls.Add(this.CboRoles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEntrar);
            this.Name = "SeleccionDeUsuario";
            this.Text = "Seleccion de Usuario";
            this.Load += new System.EventHandler(this.SeleccionDeUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CboRoles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label btnEntrar;
    }
}