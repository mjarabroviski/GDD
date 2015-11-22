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

            DtpFechaNac.MaxDate = DateTime.Now;
            DtpFechaNac.Value = DateTime.Now;
            CmbPasajeros.DataSource = ClientePersistencia.ObtenerAuxiliares();
            CmbPasajeros.ValueMember = "ID";
            CmbPasajeros.DisplayMember = "NombreYApellido";
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
        }

        private void BtnDatosNuevos_Click(object sender, EventArgs e)
        {
                CmbPasajeros.Enabled = false;
                TxtApellidos.Enabled = true;
                TxtCalle.Enabled = true;
                TxtMail.Enabled = true;
                TxtNombres.Enabled = true;
                TxtNroCalle.Enabled = true;
                TxtNroDoc.Enabled = true;
                TxtTelefono.Enabled = true;
                DtpFechaNac.Enabled = true;
                CmbTipoDoc.Enabled = true;

                TxtApellidos.Text = "";
                TxtMail.Text = "";
                TxtNombres.Text = "";
                TxtNroDoc.Text = "";
                TxtTelefono.Text = "";
                CmbTipoDoc.Text = "";
                TxtNroCalle.Text = "";
                TxtCalle.Text = "";
                DtpFechaNac.Value = DateTime.Today;

                CmbPasajeros.DataSource = ClientePersistencia.ObtenerAuxiliares();
                CmbPasajeros.ValueMember = "ID";
                CmbPasajeros.DisplayMember = "NombreYApellido";
        }

        private void BtnDatosViejos_Click(object sender, EventArgs e)
        {
            CmbPasajeros.Enabled = true;
            TxtApellidos.Enabled = false;
            TxtCalle.Enabled = false;
            TxtMail.Enabled = false;
            TxtNombres.Enabled = false;
            TxtNroCalle.Enabled = false;
            TxtNroDoc.Enabled = false;
            TxtTelefono.Enabled = false;
            DtpFechaNac.Enabled = false;
            CmbTipoDoc.Enabled = false;
            ClienteAuxiliar clienteAux = ClientePersistencia.ObtenerClientePorNombreYApellido(CmbPasajeros.Text);
            for (int i = clienteAux.Direccion.Length-1; i > 0; i--)
            {
                if(!ValidadorDeTipos.IsNumeric(clienteAux.Direccion[i].ToString())){
                    TxtNroCalle.Text = clienteAux.Direccion.Substring(i + 1, clienteAux.Direccion.Length - 1 - i);
                    TxtCalle.Text = clienteAux.Direccion.Substring(0, i+1);
                    i = 0;
                }

            }
            TxtApellidos.Text = clienteAux.Apellido;
            TxtMail.Text = clienteAux.Mail;
            TxtNombres.Text = clienteAux.Nombre;
            TxtNroDoc.Text = clienteAux.Nro_Documento.ToString();
            TxtTelefono.Text = clienteAux.Telefono;
            CmbTipoDoc.Text = TipoDocumentoPersistencia.ObtenerPorID(clienteAux.ID_Tipo_Documento);
            DtpFechaNac.Value = clienteAux.Fecha_Nacimiento;

        }
    }
}
