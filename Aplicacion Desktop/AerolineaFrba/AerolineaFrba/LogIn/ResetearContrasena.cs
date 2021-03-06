﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herramientas;
using Persistencia;
using Persistencia.Entidades;

namespace AerolineaFrba.LogIn
{
    public partial class ResetearContrasena : Form
    {
        Usuario usuario;

        public ResetearContrasena(Usuario user)
        {
            InitializeComponent();
            usuario = user;
        }

        private void LblAceptar_Click(object sender, EventArgs e)
        {

            //Valido que las contraseñas coincidan
            if (TxtContrasena.Text != TxtContrasenaRepetida.Text)
            {
                MessageBox.Show("Las contrasenas informadas no coinciden.", "Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                TxtContrasena.Text = string.Empty;
                TxtContrasenaRepetida.Text = string.Empty;
            }
            else
            {
                //Encripto la nueva contraseña
                var hashContrasena = SHA256Encriptador.Encode(TxtContrasena.Text);

                //Impacto el cambio en la base de datos
                UsuarioPersistencia.CambiarContrasena(usuario, hashContrasena);
                MessageBox.Show("Contraseña modificada satisfactoriamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Close();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                Close();
            }
        }
    }
}
