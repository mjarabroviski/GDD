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
        private List<RegistroMillas> registrosMillas = new List<RegistroMillas>();
        Cliente cliente;

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
            LbLNac.Visible = false;
            dtpNac.Visible = false;
            btnAceptar.Visible = false;
            cboTipoDoc.Enabled = true;
            TxtDni.Enabled = true;
            TxtDni.Text = string.Empty;
            LblBuscar.Enabled = true;
        }

        private void LimpiarDataGridView()
        {
            dgvCompras.DataSource = null;
            dgvCompras.Columns.Clear();
            dgvCanjes.DataSource = null;
            dgvCanjes.Columns.Clear();
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
                         cboTipoDoc.Enabled = false;
                     }
                     else
                     {
                         TxtDni.Text = string.Empty;
                     }
                }
                else 
                {
                    //Cargar las compras y los canjes del cliente
                    cliente = clientes[0];
                    ActualizarRegistroMillas();
                    CalcularMillas();
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
            cliente = ClientePersistencia.ObtenerClientePorDNIYFechaNac(doc, tipo, fecha);
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
                ActualizarRegistroMillas();
                CalcularMillas();
            }
        }

        private void ActualizarRegistroMillas()
        {
            LimpiarDataGridView();
            var diccionarioDeAeronaves = new Dictionary<int, RegistroMillas>();

            #region Cargar el diccionario a mostrar en la grilla

                registrosMillas = RegistroMillasPersistencia.ObtenerPorIDCliente(cliente.ID);
                if (registrosMillas.Count == 0 || registrosMillas == null) MessageBox.Show("No cuenta con registros de compras", "Atención", MessageBoxButtons.OK,MessageBoxIcon.Information);
                diccionarioDeAeronaves = registrosMillas.ToDictionary(a => a.ID, a => a);

            //Muestra en la grilla el contenido de los registros que se encuentran cargados en el diccionario
            var bind = diccionarioDeAeronaves.Values.Select(a => new
            {
                Fecha_Inicio = a.Fecha_Inicio.Date,
                Codigo_Item = a.Codigo_Item,
                Millas = a.Millas,
                Fecha_Vencimiento = a.Fecha_Inicio.AddDays(366).Date
            });

            #endregion

            dgvCompras.DataSource = bind.ToList();
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CalcularMillas() {
            //faltan las de canje
            int sum = 0;
            for (int i = 0; i < dgvCompras.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvCompras.Rows[i].Cells[2].Value);
            }
            TxtMillas.Text = sum.ToString();
        }
    }

}
