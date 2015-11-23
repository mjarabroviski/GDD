using Persistencia;
using Persistencia.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Compra
{
    public partial class FrmIngresoCantidades : Form
    {
        public FrmCompra formularioAnterior;
        public Viaje viajeActual;

        public FrmIngresoCantidades(Viaje viaje,FrmCompra frmCompra)
        {
            formularioAnterior = frmCompra;
            viajeActual = viaje;
            InitializeComponent();
            NumEncomiendas.Maximum = ViajePersistencia.ObtenerKGSDisponibles(viaje.ID);
            NumPasajes.Maximum = ViajePersistencia.ObtenerButacasDisponibles(viaje.ID);
            formularioAnterior.Visible = false;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            formularioAnterior.Visible = true;
            Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (NumPasajes.Value > 0)
                {
                    CompraPersistencia.CrearTablaDatosPasajeros();
                }

                int ordenPasaje;
                if (NumPasajes.Value == 0 && NumEncomiendas.Value == 0) throw new Exception("Debe ingresar cantidades mayores a 0");
                if (NumPasajes.Value != 0)
                {
                    ordenPasaje = 1;
                    var cargaPasajeros = new FrmCargaDatosPasajero(viajeActual, NumPasajes.Value, NumEncomiendas.Value, this, ordenPasaje);
                    cargaPasajeros.ShowDialog();
                }
                else
                {
                    //Solo hay encomiendas
                    ordenPasaje = 0;
                    var formularioPago = new FrmCargaDatosPago(this,NumEncomiendas.Value,viajeActual);
                    formularioPago.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }
    }
}
