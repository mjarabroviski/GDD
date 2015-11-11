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

namespace AerolineaFrba.Consulta_Millas
{
    public partial class ConsultaMillas : Form
    {
        public ConsultaMillas()
        {
            InitializeComponent();
        }

        private void ConsultaMillas_Load(object sender, EventArgs e)
        {
            TxtMillas.Enabled = false;
            LbLNac.Visible = false;
            dtpNac.Visible = false;
            btnAceptar.Visible = false;

            #region Cargar Tipos de Docuementos

            //Carga el combobox de los tipos de documentos
            cboTipoDoc.DataSource = TipoDocumentoPersistencia.ObtenerTodos();
            cboTipoDoc.ValueMember = "ID";
            cboTipoDoc.DisplayMember = "Descripcion";

            #endregion
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarDataGridView();
        }

        private void LimpiarDataGridView()
        {
            dgvCompras.DataSource = null;
            dgvCompras.Columns.Clear();
            dgvCanjes.DataSource = null;
            dgvCanjes.Columns.Clear();
            TxtDni.Text = string.Empty;
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones

                var mensajeDeExcepcion = string.Empty;

                if (ValidadorDeTipos.IsEmpty(TxtDni.Text))
                    mensajeDeExcepcion = "Debe ingresar su Numero de Documento";

                if (ValidadorDeTipos.IsEmpty(cboTipoDoc.Text))
                    mensajeDeExcepcion = "Debe ingresar su tipo de Documento";

                if(TxtDni.Text.Length > 8 || TxtDni.Text.Length < 7 || !ValidadorDeTipos.IsNumeric(TxtDni.Text))
                    mensajeDeExcepcion = "El numero de documento es invalido";

                if (!ValidadorDeTipos.IsEmpty(mensajeDeExcepcion))
                    throw new Exception(mensajeDeExcepcion);

                #endregion

                int doc = Convert.ToInt32(TxtDni.Text);
                int tipo = Convert.ToInt32(cboTipoDoc.SelectedValue);
                List<Cliente> clientes = ClientePersistencia.ObtenerClientePorDNI(doc,tipo);

                if (clientes.Count == 0 || clientes == null)
                {
                    MessageBox.Show("No se encontraron clientes con esos datos, por favor reingreselos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtDni.Text = string.Empty;
                }
                else if(clientes.Count > 1)
                {
                     var msg = MessageBox.Show(string.Format("Su numero de documento ingresado fue: {0}. Esta seguro?", TxtDni.Text), "Atención", MessageBoxButtons.YesNo);
                     if (msg == DialogResult.Yes)
                     {
                         MessageBox.Show("Por favor ingrese su fecha de nacimiento", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                         dtpNac.Visible = true;
                         LbLNac.Visible = true;
                         btnAceptar.Visible = true;
                         TxtDni.Enabled = false;
                         LblBuscar.Enabled = false;
                     }
                     else
                     {
                         TxtDni.Text = string.Empty;
                     }
                }
                else 
                {
                    //Cargar las compras y los canjes del cliente
                    Cliente cliente = clientes[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int doc = Convert.ToInt32(TxtDni.Text);
            int tipo = Convert.ToInt32(cboTipoDoc.SelectedValue);
            DateTime fecha = dtpNac.Value.Date;
            Cliente cliente = ClientePersistencia.ObtenerClientePorDNIYFechaNac(doc, tipo, fecha);
            if (cliente == null) {
                MessageBox.Show("No se encontraron clientes con esos datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNac.Visible = false;
                LbLNac.Visible = false;
                btnAceptar.Visible = false;
                TxtDni.Text = string.Empty;
                TxtDni.Enabled = true;
                LblBuscar.Enabled = true;
            }
            else
            {
                //Cargar las compras y los canjes del cliente
            }
        }
    }
}
