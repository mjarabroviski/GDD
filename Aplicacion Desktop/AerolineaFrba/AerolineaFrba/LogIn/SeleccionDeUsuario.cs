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
using AerolineaFrba.Home_Cliente;
using Sesion;

namespace AerolineaFrba.LogIn
{
    public partial class SeleccionDeUsuario : Form
    {
        public SeleccionDeUsuario()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //Obtengo el rol que seleccionó el usuario
            var RolSeleccionado = (Rol)CboRoles.SelectedItem;

            if (RolSeleccionado != null && RolSeleccionado.Descripcion == "Administrador")
            {
                var msg = MessageBox.Show(string.Format("Se procederá a loggear con el siguiente rol: {0}. Esta seguro?", RolSeleccionado.Descripcion), "Atención", MessageBoxButtons.YesNo);
                if (msg == DialogResult.Yes)
                {
                   this.Hide();

                    //Muestro pantalla para iniciar sesion
                    InicioAdministrador inic = new InicioAdministrador();
                    inic.ShowDialog();
                }
            }
            else if (RolSeleccionado.Descripcion == "Cliente")
            {
                var msg = MessageBox.Show(string.Format("Se procederá a loggear con el siguiente rol: {0}. Esta seguro?", RolSeleccionado.Descripcion), "Atención", MessageBoxButtons.YesNo);
                if (msg == DialogResult.Yes)
                {
                    Hide();
                    HomeCliente homeAdmin = new HomeCliente();
                    homeAdmin.ShowDialog();
                    Close();
                }
                
            }else
            {
                MessageBox.Show("Primero debe seleccionar un rol.", "Atención");
            }
        }

        private void SeleccionDeUsuario_Load(object sender, EventArgs e)
        {
            CboRoles.DisplayMember = "Descripcion";
            CboRoles.ValueMember = "ID_Rol";
            CboRoles.DataSource = RolPersistencia.ObtenerTodos();
            AdministradorSesion.UsuarioActual = null;
        }
    }
}
