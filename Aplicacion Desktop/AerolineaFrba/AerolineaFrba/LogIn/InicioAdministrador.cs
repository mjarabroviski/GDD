﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Persistencia;
using Herramientas;

namespace AerolineaFrba.LogIn
{
    public partial class InicioAdministrador : Form
    {
        public InicioAdministrador()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            SeleccionDeUsuario selec;
            Hide();
            selec = new SeleccionDeUsuario();
            selec.Show();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            int resul = Loggear(TxtUsuario.Text, TxtContrasena.Text);
        }

        private void  LimpiarCampos() {
            TxtContrasena.Text = "";
            TxtUsuario.Text = "";
        }

        private int Loggear(string usuario, string contrasena)
        {
                //Realizo validaciones de datos ingresados
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Debe completar ambos campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
                return 1;
            }

               //Valido que los datos del usuario ingresados sean correctos
                var user = UsuarioPersistencia.Login(usuario);

                if (user == null)
                {
                     MessageBox.Show("El usuario ingresado no existe en el sistema, por favor registrese","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                     LimpiarCampos();
                     return 1;
                } 

                //El usuario no se encuentra habilitado
                else if (!user.Habilitado)
                {
                    MessageBox.Show("No puede loguearse. El usuario se encuentra inhabilitado debido a supero el limite de intentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Hide();
                    SeleccionDeUsuario selec = new SeleccionDeUsuario();
                    selec.ShowDialog();
                    Close();
                }
                 //Usuario y contrasenia no coinciden
                else if (user.Contrasena != SHA256Encriptador.Encode(contrasena))
                {
                    user.CantIntentos -= 1;
                    if (user.CantIntentos == 0) user.Habilitado = false;
                    UsuarioPersistencia.Update(user);
                    MessageBox.Show("Contraseña incorrecta, por favor ingresela nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtContrasena.Text = "";
                    return 1;
                }
                //Usuario Validado correctamente
                    UsuarioPersistencia.LimpiarIntentos(user);
                    MessageBox.Show("Usuario logueado correctamente");
                    //REDIRECCIONAR AL HOME DE ADMINISTRADOR

                return 0;
        }

        private void InicioAdministrador_Load(object sender, EventArgs e)
        {
            
        }
    }
}