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
    public partial class ABMCancelarOReemplazar : Form
    {
        public Aeronave aeronaveSeleccionada { get; set; }
        public bool accionTerminada = false;

        public ABMCancelarOReemplazar(Aeronave aeronave)
        {
            InitializeComponent();
            aeronaveSeleccionada = aeronave;
        }

        private void LblCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que desea cancelar todos los pasajes y encomiendas de los viajes?", "Atención", MessageBoxButtons.YesNo);
            if (dialogAnswer == DialogResult.Yes)
            {
                //TODO copiar mati y lucho
            }
        }

        private void LblReemplazar_Click_1(object sender, EventArgs e)
        {
            int cant = 0;
            var dialogAnswer = MessageBox.Show("Esta seguro que desea reemplazar la aeronave?", "Atención", MessageBoxButtons.YesNo);
            if (dialogAnswer == DialogResult.Yes)
            {
                cant = AeronavePersistencia.SeleccionarAeronaveParaReemplazar(aeronaveSeleccionada);
                if (cant == -1)
                {
                    MessageBox.Show("No exitsen aeronaves que puedan reemplazar a la seleccionada, debe dar de alta una nueva", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    var insertarActualizarAeronave = new ABMInsertarActualizarAeronave(aeronaveSeleccionada, false);
                    insertarActualizarAeronave.ShowDialog();
                    if (insertarActualizarAeronave.accionTerminada) MessageBox.Show("La aeronave fue reemplazada por otra satisfactoriamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                MessageBox.Show("La aeronave fue reemplazada satisfactoriamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

        }
    }
}
