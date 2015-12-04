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
        public int maxPasajes;
        public int maxKGS;
        public int cantPasajes = 0;
        public int cantKGS = 0;

        public FrmIngresoCantidades(Viaje viaje,FrmCompra frmCompra)
        {
            formularioAnterior = frmCompra;
            viajeActual = viaje;
            InitializeComponent();
            maxKGS = ViajePersistencia.ObtenerKGSDisponibles(viaje.ID);
            maxPasajes = ViajePersistencia.ObtenerButacasDisponibles(viaje.ID);
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
                if(((ValidadorDeTipos.IsEmpty(cboPasajes.Text)) && (ValidadorDeTipos.IsEmpty(cboKGS.Text))) ||
                    ((ValidadorDeTipos.IsEmpty(cboPasajes.Text)) && (cboKGS.Text=="0")) ||
                    ((cboPasajes.Text == "0") && (ValidadorDeTipos.IsEmpty(cboKGS.Text))) ||
                    ((cboPasajes.Text == "0") && (cboKGS.Text == "0")))
                     throw new Exception("Debe ingresar cantidades mayores a 0");

                if (!(ValidadorDeTipos.IsEmpty(cboPasajes.Text)) && (cboPasajes.Text != "0"))
                    cantPasajes = Convert.ToInt32(cboPasajes.Text);

                if (!(ValidadorDeTipos.IsEmpty(cboKGS.Text)) && (cboKGS.Text != "0"))
                    cantKGS = Convert.ToInt32(cboKGS.Text);
                    

                if (cantPasajes > 0)
                {
                    CompraPersistencia.CrearTablaDatosPasajeros();
                }

                int ordenPasaje;
                if (cantPasajes != 0)
                {
                    ordenPasaje = 1;
                    var cargaPasajeros = new FrmCargaDatosPasajero(viajeActual, cantPasajes,cantKGS, this, ordenPasaje);
                    cargaPasajeros.ShowDialog();
                }
                else
                {
                    //Solo hay encomiendas
                    ordenPasaje = 0;
                    var formularioPago = new FrmCargaDatosPago(this,cantPasajes, cantKGS, viajeActual);
                    formularioPago.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void FrmIngresoCantidades_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= maxPasajes; i++)
            {
                cboPasajes.Items.Add(i);
            }

            for (int i = 0; i <= maxKGS; i++)
            {
                cboKGS.Items.Add(i);
            }
        }
    }
}
