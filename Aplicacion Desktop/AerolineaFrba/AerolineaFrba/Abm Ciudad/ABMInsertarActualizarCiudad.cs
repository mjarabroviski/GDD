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

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class ABMInsertarActualizarCiudad : Form
    {
        public Ciudad ciudadActual { get; set; }
        public bool accionTerminada = false;

        public ABMInsertarActualizarCiudad(Ciudad ciudad)
        {
            InitializeComponent();
            ciudadActual = ciudad;
        }
    }
}
