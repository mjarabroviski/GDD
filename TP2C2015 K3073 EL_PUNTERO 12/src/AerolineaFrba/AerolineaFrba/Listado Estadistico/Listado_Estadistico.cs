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

namespace AerolineaFrba.Listado_Estadistico
{
    public partial class Listado_Estadistico : Form
    {
        private List<Estadistica> _estadisticas = new List<Estadistica>();

        public Listado_Estadistico()
        {
            InitializeComponent();
        }

        private void LblCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Listado_Estadistico_Load(object sender, EventArgs e)
        {
            ActualizarRecursos(null);
            LimpiarFiltros();
        }

        private void LimpiarFiltros() {
            cboAnio.Text = string.Empty;
            cboListado.Text = string.Empty;
            cboSemestre.Text = string.Empty;
        }

        private void ActualizarRecursos(List<Estadistica> estadisticas) { }
    }
}
