using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Persistencia.Entidades;
using Persistencia;

namespace AerolineaFrba.Generacion_Viaje
{
    public partial class GenercionViaje : Form
    {
        public GenercionViaje()
        {
            InitializeComponent();
        }

        private void GenercionViaje_Load(object sender, EventArgs e)
        {
            ActualizarPantalla(null);
        }

        private void ActualizarPantalla()
        {
             CboCiudadOrigen.DisplayMember = "Nombre_Ciudad";
             CboCiudadOrigen.ValueMember = "ID_Ciudad";
             CboCiudadOrigen.DataSource = CiudadPersistencia.ObtenerTodos();
        }


 

    }
}
