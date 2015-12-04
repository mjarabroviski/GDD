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
using Configuracion;

namespace AerolineaFrba.Consulta_Millas
{
    public partial class ConsultaMillas : Form
    {
        private List<RegistroMillas> registrosMillas = new List<RegistroMillas>();
        private List<Canje> canjes = new List<Canje>();
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

            dtpNac.Value = ConfiguracionDeVariables.FechaSistema;
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarDataGridView();
            LbLNac.Visible = false;
            dtpNac.Visible = false;
            dtpNac.Value = ConfiguracionDeVariables.FechaSistema;
            btnAceptar.Visible = false;
            cboTipoDoc.Enabled = true;
            TxtDni.Enabled = true;
            TxtDni.Text = string.Empty;
            LblBuscar.Enabled = true;
            TxtMillas.Text = string.Empty;
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

                if(!ValidadorDeTipos.IsNumeric(TxtDni.Text))
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
                         dtpNac.Value = ConfiguracionDeVariables.FechaSistema;
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

                    registrosMillas = RegistroMillasPersistencia.ObtenerPorIDCliente(cliente.ID);
                    canjes = CanjePersistencia.ObtenerPorIDCliente(cliente.ID);
                    if ((registrosMillas.Count == 0 || registrosMillas == null) && (canjes.Count == 0 || canjes == null))
                    {
                        MessageBox.Show("No cuenta con registros de compras ni canjes realizados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarDataGridView();
                        dtpNac.Visible = false;
                        LbLNac.Visible = false;
                        dtpNac.Value = ConfiguracionDeVariables.FechaSistema;
                        btnAceptar.Visible = false;
                        TxtDni.Text = string.Empty;
                        TxtDni.Enabled = true;
                        LblBuscar.Enabled = true;
                        cboTipoDoc.Enabled = true;

                    }
                    else
                    {
                        ActualizarRegistroMillas();
                        ActualizarCanjes();
                        CalcularMillas();
                    }
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
                dtpNac.Value = ConfiguracionDeVariables.FechaSistema;
                btnAceptar.Visible = false;
                TxtDni.Text = string.Empty;
                TxtDni.Enabled = true;
                LblBuscar.Enabled = true;
                cboTipoDoc.Enabled= true;
            }
            else
            {
                //Cargar las compras y los canjes del cliente
                registrosMillas = RegistroMillasPersistencia.ObtenerPorIDCliente(cliente.ID);
                canjes = CanjePersistencia.ObtenerPorIDCliente(cliente.ID);
                if ((registrosMillas.Count == 0 || registrosMillas == null) && (canjes.Count == 0 || canjes == null))
                {
                    MessageBox.Show("No cuenta con registros de compras ni canjes realizados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarDataGridView();
                    dtpNac.Visible = false;
                    LbLNac.Visible = false;
                    dtpNac.Value = ConfiguracionDeVariables.FechaSistema;
                    btnAceptar.Visible = false;
                    TxtDni.Text = string.Empty;
                    TxtDni.Enabled = true;
                    LblBuscar.Enabled = true;
                    cboTipoDoc.Enabled = true;

                }
                else
                {
                    ActualizarRegistroMillas();
                    ActualizarCanjes();
                    CalcularMillas();
                }
            }
        }

        private void ActualizarRegistroMillas()
        {
            dgvCompras.DataSource = null;
            dgvCompras.Columns.Clear();

            var diccionarioDeCompras = new Dictionary<int, RegistroMillas>();

            #region Cargar el diccionario a mostrar en la grilla

            registrosMillas = RegistroMillasPersistencia.ObtenerPorIDCliente(cliente.ID);
            diccionarioDeCompras = registrosMillas.ToDictionary(a => a.ID, a => a);

            //Muestra en la grilla el contenido de los registros que se encuentran cargados en el diccionario
            var bind = diccionarioDeCompras.Values.Select(a => new
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

        private void ActualizarCanjes() {
            dgvCanjes.DataSource = null;
            dgvCanjes.Columns.Clear();

            var diccionarioDeCanjes = new Dictionary<int, Canje>();

            #region Cargar el diccionario a mostrar en la grilla

            canjes = CanjePersistencia.ObtenerPorIDCliente(cliente.ID);
            diccionarioDeCanjes = canjes.ToDictionary(a => a.ID, a => a);

            //Muestra en la grilla el contenido de los registros que se encuentran cargados en el diccionario
            var bind = diccionarioDeCanjes.Values.Select(a => new
            {
                Fecha_Canje = a.Fecha_Canje.Date,
                Producto = (ProductoPersistencia.ObtenerProductoPorID(a.ID_Producto).Descripcion),
                Cantidad = a.Cantidad,
                Millas = a.Cantidad * (ProductoPersistencia.ObtenerProductoPorID(a.ID_Producto).Puntos)
            });

            #endregion

            dgvCanjes.DataSource = bind.ToList();
            dgvCanjes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CalcularMillas() {
            //faltan las de canje
            int sum = 0;
            for (int i = 0; i < dgvCompras.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvCompras.Rows[i].Cells[2].Value);
            }
            for (int i = 0; i < dgvCanjes.Rows.Count; ++i)
            {
                sum -= Convert.ToInt32(dgvCanjes.Rows[i].Cells[3].Value);
            }
            TxtMillas.Text = sum.ToString();
        }
    }

}
