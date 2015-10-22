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
    public partial class SeleccionDeUsuario : Form
    {
        public SeleccionDeUsuario()
        {
            InitializeComponent();
        }

        private void SeleccionDeUsuario_Load(object sender, EventArgs e)
        {
            CboRoles.DisplayMember = "Descripcion";
            CboRoles.ValueMember = "ID_Rol";
            CboRoles.DataSource = RolPersistencia.ObtenerTodos();
        }

        private void LblEntrar_Click(object sender, EventArgs e)
        {

        }
    }
}
