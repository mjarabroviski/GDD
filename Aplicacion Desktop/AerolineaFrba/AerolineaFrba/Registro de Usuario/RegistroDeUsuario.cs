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
using AerolineaFrba.Home_Administrador;

namespace AerolineaFrba.Registro_de_Usuario
{
    public partial class RegistroDeUsuario : Form
    {
        public RegistroDeUsuario()
        {
            InitializeComponent();
        }

        private void LimpiarCampos() {
            TxtContrasena.Text = string.Empty;
            TxtUsuario.Text = string.Empty;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Rol rolAUsar = RolPersistencia.ObtenerRolPorNombre("Administrador");

            try
            {
                #region Validaciones
                var exceptionMessage = string.Empty;

                if (string.IsNullOrEmpty(TxtUsuario.Text) && string.IsNullOrEmpty(TxtContrasena.Text))
                    throw new Exception("No puede haber campos vacíos");

                if (string.IsNullOrEmpty(TxtUsuario.Text))
                    throw new Exception("Debe completar el nombre de usuario");

                if (string.IsNullOrEmpty(TxtContrasena.Text))
                    throw new Exception("Debe completar la contraseña");

                if (UsuarioPersistencia.ObtenerPorUserName(TxtUsuario.Text) != null)
                    exceptionMessage += Environment.NewLine + "Ya existe un usuario con el nombre ingresado.";
               
                if (!rolAUsar.Habilitado)
                {
                    exceptionMessage += Environment.NewLine + "El Rol a registrar se encuentra inhabilitado.";
                }

                if (!string.IsNullOrEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);
                #endregion

                #region Inserto el nuevo usuario

                Usuario user = new Usuario();
                user.Username = TxtUsuario.Text;
                user.Contrasena = SHA256Encriptador.Encode(TxtContrasena.Text);

                var dialogAnswer = MessageBox.Show("Esta seguro que quiere insertar el nuevo usuario?", "Atencion", MessageBoxButtons.YesNo);
                if (dialogAnswer == DialogResult.Yes)
                {
                    using (var transaction = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
                    {
                        user.Rol = rolAUsar;
                        UsuarioPersistencia.InsertarUsuario(user,transaction);
                        transaction.Commit();
                        
                        var dialogAnswer2 = MessageBox.Show("Usuario registrado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dialogAnswer2 == DialogResult.OK) {
                            Hide();
                            HomeAdministrador homeAdmin = new HomeAdministrador();
                            homeAdmin.ShowDialog();
                            Close(); 
                         }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
                LimpiarCampos();

            }
          #endregion
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                Hide();
                HomeAdministrador homeAdmin = new HomeAdministrador();
                homeAdmin.ShowDialog();
                Close();
            }
        }
    }
}
