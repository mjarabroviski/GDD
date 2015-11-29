using Persistencia;
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
    public partial class FrmInformeDatosCompra : Form
    {
        decimal cantPasajeros;

        public FrmInformeDatosCompra(string precioTotal,decimal cantPas)
        {
            InitializeComponent();
            label16.Text = precioTotal;
            cantPasajeros = cantPas;
            int PNR  = CompraPersistencia.ObtenerPNR();
            txtPNR.Text = PNR.ToString();
        }

        private void FrmInformeDatosCompra_Load(object sender, EventArgs e)
        {
            if(cantPasajeros!=0)
                CompraPersistencia.BorrarTablaAuxiliar();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
