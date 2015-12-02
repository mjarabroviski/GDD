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

namespace AerolineaFrba.Canje_Millas
{
    public partial class Canje : Form
    {
        private List<Producto> productos = new List<Producto>();
        Cliente cliente;

        public Canje()
        {
            InitializeComponent();
        }

        private void Canje_Load(object sender, EventArgs e)
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

        private void LimpiarDataGridView()
        {
            dgvProductos.DataSource = null;
            dgvProductos.Columns.Clear();
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar() {
            LimpiarDataGridView();
            LbLNac.Visible = false;
            dtpNac.Visible = false;
            btnAceptar.Visible = false;
            cboTipoDoc.Enabled = true;
            TxtDni.Enabled = true;
            TxtDni.Text = string.Empty;
            LblBuscar.Enabled = true;
            TxtMillas.Text = string.Empty;
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

                if (!ValidadorDeTipos.IsNumeric(TxtDni.Text))
                    mensajeDeExcepcion = "El numero de documento es invalido";

                if (!ValidadorDeTipos.IsEmpty(mensajeDeExcepcion))
                    throw new Exception(mensajeDeExcepcion);

                #endregion

                int doc = Convert.ToInt32(TxtDni.Text);
                int tipo = Convert.ToInt32(cboTipoDoc.SelectedValue);
                List<Cliente> clientes = ClientePersistencia.ObtenerClientePorDNI(doc, tipo);

                if (clientes.Count == 0 || clientes == null)
                {
                    MessageBox.Show("No se encontraron clientes con esos datos, por favor reingreselos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtDni.Text = string.Empty;
                }
                else if (clientes.Count > 1)
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
                    cliente = clientes[0];
                    if (cliente.Millas == 0 || cliente.Millas < ProductoPersistencia.ObtenerProductoMinimo())
                    {
                        MessageBox.Show("El cliente seleccionado no cuenta con millas suficientes para realizar un canje", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtDni.Text = string.Empty;
                    } 
                    else
                    {
                        //Cargar las millas del cliente
                        TxtMillas.Text = cliente.Millas.ToString();
                        //Cargar los productos disponibles para su cantidad de millas
                        ActualizarProductos();
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
            if (cliente == null)
            {
                MessageBox.Show("No se encontraron clientes con esos datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNac.Visible = false;
                LbLNac.Visible = false;
                btnAceptar.Visible = false;
                TxtDni.Text = string.Empty;
                TxtDni.Enabled = true;
                LblBuscar.Enabled = true;
                cboTipoDoc.Enabled = true;
            }
            else
            {
                if (cliente.Millas == 0 || cliente.Millas < ProductoPersistencia.ObtenerProductoMinimo())
                {
                    MessageBox.Show("El cliente seleccionado no cuenta con millas suficientes para realizar un canje", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpNac.Visible = false;
                    LbLNac.Visible = false;
                    btnAceptar.Visible = false;
                    TxtDni.Text = string.Empty;
                    TxtDni.Enabled = true;
                    LblBuscar.Enabled = true;
                    cboTipoDoc.Enabled = true;
                    
                }
                else
                {
                    //Cargar las millas del cliente
                    TxtMillas.Text = cliente.Millas.ToString();
                    //Cargar los productos disponibles para su cantidad de millas
                    ActualizarProductos();
                }
            }
        }

        public void ActualizarProductos() {
            LimpiarDataGridView();
            var diccionarioDeProductos = new Dictionary<int, Producto>();

            #region Cargar el diccionario a mostrar en la grilla

            productos = ProductoPersistencia.ObtenerLosPosiblesParaUnCliente(cliente);
            if (productos.Count == 0 || productos == null)
            {
                MessageBox.Show("No cuenta con millas suficientes para realizar un canje", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarDataGridView();
                dtpNac.Visible = false;
                LbLNac.Visible = false;
                btnAceptar.Visible = false;
                TxtDni.Text = string.Empty;
                TxtDni.Enabled = true;
                LblBuscar.Enabled = true;
                cboTipoDoc.Enabled = true;
            }
            diccionarioDeProductos = productos.ToDictionary(a => a.ID, a => a);

            //Muestra en la grilla el contenido de los registros que se encuentran cargados en el diccionario
            var bind = diccionarioDeProductos.Values.Select(a => new
            {
                Descripcion = a.Descripcion,
                Millas_Necesarias = a.Puntos
            });

            #endregion

            dgvProductos.DataSource = bind.ToList();
            AgregarBotonesDeColumnas();
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BtnVerProductos_Click(object sender, EventArgs e)
        {
            var prod = new VerTodosLosProductos();
            prod.ShowDialog();
        }

        public void AgregarBotonesDeColumnas()
        {
            //Creo la columna de canjear
            var columnaCanjear = new DataGridViewButtonColumn
            {
                Text = "Realizar Canje",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };

            //Agrego la columna nueva
            dgvProductos.Columns.Add(columnaCanjear);
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Solo funciona cuando el usuario hace click en los botones de la columnas
            if (e.RowIndex == -1 || e.ColumnIndex >= 0 && e.ColumnIndex < 2)
                return;

            var productoSeleccionado = productos.Find(producto => producto.Descripcion == (string)dgvProductos.Rows[e.RowIndex].Cells[0].Value);

            if (productoSeleccionado != null)
            {
                //El usuario tocó el botón de canjear
                if (e.ColumnIndex == 2)
                {
                    var cant = new CantidadProducto(productoSeleccionado,cliente);
                    cant.ShowDialog();

                    if (cant.accionTerminada)
                    {
                         var dialogAnswer = MessageBox.Show("Canje realizado satisfactoriamente! Desea realizar otro canje?", "Felicitaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                         if (DialogResult.Yes == dialogAnswer)
                         {
                             cliente = ClientePersistencia.ObtenerClientePorID(cliente.ID);
                             TxtMillas.Text = cliente.Millas.ToString();
                             if (cliente.Millas == 0 || cliente.Millas < ProductoPersistencia.ObtenerProductoMinimo())
                             {
                                 MessageBox.Show("No cuenta con millas suficientes para realizar un canje", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                 LimpiarDataGridView();
                                 dtpNac.Visible = false;
                                 LbLNac.Visible = false;
                                 btnAceptar.Visible = false;
                                 TxtDni.Text = string.Empty;
                                 TxtDni.Enabled = true;
                                 LblBuscar.Enabled = true;
                                 TxtMillas.Text = string.Empty;
                                 cboTipoDoc.Enabled = true;
                             }
                             else ActualizarProductos();
                         }
                         else
                         {
                             Limpiar();
                         }
                    }
                }
            }
            
        }

    }
}
