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
        public bool accionTerminadaDeUna = false;

        public ABMFueraDeServicio(Aeronave aeronave)
        {
            InitializeComponent();
            aeronaveAModificar = aeronave;
        }

        private void ABMFueraDeServicio_Load(object sender, EventArgs e)
        {
            txtAeronave.Enabled = false;
            txtAeronave.Text = aeronaveAModificar.Matricula;
            DtpFechaReinicio.MinDate = DtpFechaComienzo.Value.Date;
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
            int cant = 0;
             try {

                    #region Validaciones

                    var exceptionMessage = string.Empty;

                    if (string.IsNullOrEmpty(DtpFechaReinicio.Text))
                        exceptionMessage += "La fecha de reinicio no puede ser vacia.\n";

                    if (string.IsNullOrEmpty(DtpFechaComienzo.Text))
                        exceptionMessage += "La fecha de reinicio no puede ser vacia.\n";

                    if (DtpFechaComienzo.Value.Date == DtpFechaReinicio.Value.Date && DtpFechaComienzo.Value.Hour >= DtpFechaReinicio.Value.Hour)
                        exceptionMessage += "La fecha de reinicio tiene que ser mayor que la de baja";

                    if (!string.IsNullOrEmpty(exceptionMessage))
                        throw new Exception(exceptionMessage);

                    #endregion

                     cant = AeronavePersistencia.BajaPorFueraDeServicio(aeronaveAModificar, DtpFechaComienzo.Value, DtpFechaReinicio.Value);
                     //Tiene que modificar un registro e insertar un registro
                     if (cant != 2) 
                     {
                         var cancelarOReemplazar = new ABMCancelarOReemplazar(aeronaveAModificar, false,DtpFechaComienzo.Value,DtpFechaReinicio.Value);
                         cancelarOReemplazar.ShowDialog();

                         if (cancelarOReemplazar.accionTerminada)
                         {
                             AeronavePersistencia.DarDeBajaPorFueraDeServicio(aeronaveAModificar,DtpFechaComienzo.Value,DtpFechaReinicio.Value);
                             accionTerminada = true;
                             Close();
                         }
                     }
                     else
                     {
                         accionTerminadaDeUna = true;
                         Close();
                     }
                 }     
                 catch (Exception ex) 
                    {
                         MessageBox.Show(ex.Message, "Atención");
                    }        
        }

        private void DtpFechaComienzo_ValueChanged(object sender, EventArgs e)
        {
            DtpFechaReinicio.MinDate = DtpFechaComienzo.Value.Date;
            DtpFechaReinicio.Value = DtpFechaComienzo.Value;
        }
    }
}
