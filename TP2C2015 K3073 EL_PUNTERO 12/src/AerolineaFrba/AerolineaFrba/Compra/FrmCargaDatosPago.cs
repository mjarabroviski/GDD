using Persistencia;
using Persistencia.Entidades;
using Sesion;
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
    public partial class FrmCargaDatosPago : Form
    {
        public FrmCargaDatosPago(FrmIngresoCantidades frmIngresoCants,decimal cantEncomiendas,Viaje viaje)
        {
            InitializeComponent();
            if (frmIngresoCants != null)
                frmIngresoCants.Visible = false;
        }

        private void FrmCargaDatosPago_Load(object sender, EventArgs e)
        {
            if (AdministradorSesion.UsuarioActual == null)
                BtnEfectivo.Visible = false;

            CmbPasajeros.DataSource = ClientePersistencia.ObtenerAuxiliares();
            CmbPasajeros.ValueMember = "ID";
            CmbPasajeros.DisplayMember = "NombreYApellido";
            CmbPasajeros.Text = "Otro";
            TxtNroDoc.Enabled = true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            CompraPersistencia.BorrarTablaAuxiliar();
            this.Visible = false;
            FrmCompra frmCompra = new FrmCompra();
            frmCompra.ShowDialog();
            this.Close();
        }

        private void CmbPasajeros_SelectedValueChanged(object sender, EventArgs e)
        {
            //TODO Cargar los datos del cliente y deshabilitar todos los text
        }
    }
}
