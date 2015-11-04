using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Abm_Aeronave;

namespace AerolineaFrba.Home_Administrador
{
    public partial class HomeAdministrador : Form
    {
        public HomeAdministrador()
        {
            InitializeComponent();
        }

        private void HomeAdministrador_Load(object sender, EventArgs e)
        {
            //TODO En el cerrar sesion va a haber que poner AdministradorSesion.BorrarSesionActual();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            ABMAeronaves aero = new ABMAeronaves();
            aero.ShowDialog();

        }
    }
}
