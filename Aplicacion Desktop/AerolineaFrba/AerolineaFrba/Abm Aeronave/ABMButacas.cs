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

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class ABMButacas : Form
    {
        public bool esUnAlta = false;

        public ABMButacas(bool alta, Aeronave aeronave)
        {
            InitializeComponent();
            esUnAlta = alta;
        }

        private void ABMButacas_Load(object sender, EventArgs e)
        {
           // if (alta) CARGAR FORMULARIO PARA ALTA
          //  else CARGAR FORMULARIO PARA MODIFICACION

        }
    }
}
