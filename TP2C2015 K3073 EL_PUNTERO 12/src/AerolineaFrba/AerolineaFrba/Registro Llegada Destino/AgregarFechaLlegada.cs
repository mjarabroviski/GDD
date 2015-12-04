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

namespace AerolineaFrba.Registro_Llegada_Destino
{
    public partial class AgregarFechaLlegada : Form
    {

        Aeronave aeronave;
        Viaje viaje;
        AerolineaFrba.Registro_Llegada_Destino.RegistroLlegadaDestino registro;

        public AgregarFechaLlegada(Aeronave aeronave1,Viaje viaje1,AerolineaFrba.Registro_Llegada_Destino.RegistroLlegadaDestino form1)
        {
            InitializeComponent();
            aeronave = aeronave1;
            viaje = viaje1;
            registro = form1;

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                #region ValidacionesEnGral
                var exceptionMessage = string.Empty;
                if (viaje.Fecha_Salida >= DtpFechaLlegada.Value)
                    exceptionMessage += "La fecha de llegada debe ser mayor a la fecha de salida.\n";
                if ( DtpFechaLlegada.Value > viaje.Fecha_Salida.AddDays(1))
                    exceptionMessage += "La fecha de llegada no puede superar las 24HS de vuelo.\n";
                if (!string.IsNullOrEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);
                #endregion

                //Se registra la fecha de llegada del viaje y se registran las millas de los pasajeros
                ViajePersistencia.ActualizarFechaLlegada(viaje.ID,DtpFechaLlegada.Value);
                RegistroMillasPersistencia.ActualizarMillas(viaje.ID);

                MessageBox.Show("Fecha registrada correctamente", "Informacion", MessageBoxButtons.OK);
                Hide();
                registro.actualizarLlegada(DtpFechaLlegada.Value);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }

         }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
                    
             var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
             if (DialogResult.Yes == dialogAnswer)
             {
                 Close();
             }
        
        }

        private void AgregarFechaLlegada_Load(object sender, EventArgs e)
        {
            DtpFechaLlegada.Value = viaje.Fecha_Llegada_Estimada;
        }

    }
}
