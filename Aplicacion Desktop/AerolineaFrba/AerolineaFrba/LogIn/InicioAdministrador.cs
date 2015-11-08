using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Persistencia;
using Persistencia.Entidades;
using Herramientas;
using AerolineaFrba.Home;
using Sesion;

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
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                SeleccionDeUsuario selec;
                Hide();
                selec = new SeleccionDeUsuario();
                selec.Show();
                Close();
            }     
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            int resul = Loggear(TxtUsuario.Text, TxtContrasena.Text);

        }

        private void  LimpiarCampos() {
            TxtContrasena.Text = string.Empty;
            TxtUsuario.Text = string.Empty;
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
                    MessageBox.Show("No puede loguearse. El usuario se encuentra inhabilitado debido a que supero el limite de intentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    UsuarioPersistencia.ActualizarPorContrasena(user);
                    MessageBox.Show("Contraseña incorrecta, por favor ingresela nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtContrasena.Text = string.Empty;
                    return 1;
                }
                //Usuario Validado correctamente
                    UsuarioPersistencia.LimpiarIntentos(user);
                    var dialogAnswer2 = MessageBox.Show("Usuario logueado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialogAnswer2 == DialogResult.OK)
                    {
                        
                        AdministradorSesion.UsuarioActual = user;
                        Hide();
                        HomeUsuario home = new HomeUsuario();
                        home.ShowDialog();
                        Close();
                    }

                return 0;
        }

        private void InicioAdministrador_Load(object sender, EventArgs e)
        {
            btnNuevo.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Validacion que exista el usuario antes de cambiar contrasenia
            Usuario user = UsuarioPersistencia.ObtenerPorUserName(TxtUsuario.Text);
            if (user == null)
            {
                MessageBox.Show("El usuario ingresado no existe en el sistema, por favor registrese", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
            else
            {
                ResetearContrasena reset = new ResetearContrasena(user);
                reset.ShowDialog();
            }
        }

        private void TxtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtUsuario.Text)) {
                btnNuevo.Enabled = true;
            }
        }

        private void TxtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Cuando presiona la tecla 'Enter', realizo el login
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Loggear(TxtUsuario.Text, TxtContrasena.Text);
            }
        }
    }
}
