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
    public partial class FrmCargaDatosPasajero : Form
    {
        public FrmIngresoCantidades formularioAnterior;
        public Viaje viajeActual;
        public int ordenPasaje;
        public decimal cantPasajesActual;
        public decimal cantEncomiendasActual;

        public FrmCargaDatosPasajero(Viaje viaje,decimal cantPasajes,decimal cantEncomiendas,FrmIngresoCantidades ingresoCantidades,int nroOrdenPasaje)
        {
            formularioAnterior = ingresoCantidades;
            formularioAnterior.Visible = false;
            InitializeComponent();
            ordenPasaje = nroOrdenPasaje;
            cantPasajesActual = cantPasajes;
            cantEncomiendasActual = cantEncomiendas;
            if (ordenPasaje <= cantPasajes && ordenPasaje > 0)
            {
                LblNroPasajero.Text = "#" + ordenPasaje;
                ordenPasaje++;
            }
            else
            {
                this.Visible = false;
                //Cargar el formulario de datos del pago
            }

           
        }

        private void FrmCargaDatosPasajero_Load(object sender, EventArgs e)
        {
            if (ordenPasaje == cantPasajesActual+1)
            {
                BtnSiguiente.Text = "FINALIZAR CARGA";
            }
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (ordenPasaje <= cantPasajesActual)
            {
                var nuevoFormulario = new FrmCargaDatosPasajero(viajeActual, cantPasajesActual, cantEncomiendasActual, formularioAnterior, ordenPasaje);
                this.Visible = false;
                nuevoFormulario.ShowDialog();
            }
            else
            {
                this.Visible = false;
                //Cargar el formulario de datos del pago
            }

        }
    }
}
