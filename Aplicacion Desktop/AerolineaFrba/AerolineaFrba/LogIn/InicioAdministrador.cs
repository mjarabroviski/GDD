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
            this.Hide();
            SeleccionDeUsuario selec = new SeleccionDeUsuario();
            selec.Show();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Loggear(TxtUsuario.Text, TxtContrasena.Text);
        }

        private void Loggear(string usuario, string contrasena)
        {
            try
            {
                //Realizo validaciones de datos ingresados
                if (string.IsNullOrEmpty(usuario))
                    throw new Exception("Debe ingresar un nombre de usuario");

                if (string.IsNullOrEmpty(contrasena))
                    throw new Exception("Debe ingresar una constaseña");

                //Valido que los datos del usuario ingresados sean correctos
                var user = UsuarioPersistencia.Login(usuario, contrasena);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }
    }
}
