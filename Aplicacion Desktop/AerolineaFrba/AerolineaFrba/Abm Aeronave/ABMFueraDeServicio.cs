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
    public partial class ABMFueraDeServicio : Form
    {
        public Aeronave aeronaveAModificar { get; set; }
        public bool accionTerminada = false;

        public ABMFueraDeServicio(Aeronave aeronave)
        {
            InitializeComponent();
            aeronaveAModificar = aeronave;
        }

        private void ABMFueraDeServicio_Load(object sender, EventArgs e)
        {
            txtAeronave.Enabled = false;
            txtAeronave.Text = aeronaveAModificar.Matricula;
            dtpFechaReinicio.MinDate = DtpFechaComienzo.Value.Date;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                    accionTerminada = false;
                    Close();
            }  
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            //VALIDAR FECHAS Y VIAJES DE LA AERONAVE
            //LLEVAR A CANCELAROREEMPLAZAR
        }

        private void DtpFechaComienzo_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaReinicio.MinDate = DtpFechaComienzo.Value.Date;
        }
    }
}
