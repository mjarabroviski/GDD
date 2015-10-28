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
    public partial class ABMAeronaves : Form
    {
        private List<Aeronave> _aeronaves = new List<Aeronave>();

        public ABMAeronaves()
        {
            InitializeComponent();
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            //Vaciar grilla y limpiar los filtros
            LimpiarFiltros();
            ActualizarPantalla(null);
        }

        public void LimpiarFiltros() {
            TxtFabricante.Text = string.Empty;
            TxtMatricula.Text = string.Empty;
            TxtModelo.Text = string.Empty;
            CboServicio.Text = string.Empty;
            dtpAlta.Text = string.Empty;
        }

        private void LimpiarDataGridView()
        {
            DgvAeronaves.DataSource = null;
            DgvAeronaves.Columns.Clear();
        }

        private void ABMAeronaves_Load(object sender, EventArgs e)
        {
            ActualizarPantalla(null);
        }

        private void ActualizarPantalla(List<Aeronave> aeronaves) { 
            
        }
    }
}
