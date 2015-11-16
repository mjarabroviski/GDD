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

namespace AerolineaFrba.Devolucion
{
    public partial class DevolucionEncomiendaPasaje : Form
    {
        private Cliente cliente;
        public DevolucionEncomiendaPasaje()
        {
            InitializeComponent();
        }

        private void DevolucionEncomienda_Load(object sender, EventArgs e)
        {
            #region Cargar Tipos de Docuementos

            //Carga el combobox de los tipos de documentos
            cboTipoDoc.DataSource = TipoDocumentoPersistencia.ObtenerTodos();
            cboTipoDoc.ValueMember = "ID";
            cboTipoDoc.DisplayMember = "Descripcion";

            #endregion
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                Close();
            }
        
        }

        private void EncontrarUsuario()
        {
            try
            {
                #region Validaciones

                var mensajeDeExcepcion = string.Empty;

                if (ValidadorDeTipos.IsEmpty(Txt_Dni.Text))
                    mensajeDeExcepcion = "Debe ingresar su Numero de Documento";

                if (ValidadorDeTipos.IsEmpty(cboTipoDoc.Text))
                    mensajeDeExcepcion = "Debe ingresar su tipo de Documento";

                if (Txt_Dni.Text.Length > 8 || Txt_Dni.Text.Length < 7 || !ValidadorDeTipos.IsNumeric(Txt_Dni.Text))
                    mensajeDeExcepcion = "El numero de documento es invalido";

                if (!ValidadorDeTipos.IsEmpty(mensajeDeExcepcion))
                    throw new Exception(mensajeDeExcepcion);

                #endregion

                int doc = Convert.ToInt32(Txt_Dni.Text);
                int tipo = Convert.ToInt32(cboTipoDoc.SelectedValue);
                List<Cliente> clientes = ClientePersistencia.ObtenerClientePorDNI(doc, tipo);

                if (clientes.Count == 0 || clientes == null)
                {
                    MessageBox.Show("No se encontraron clientes con esos datos, por favor reingreselos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    BotonesYtextosAestadoAnterior();

                }
                else if (clientes.Count > 1)
                {
                    var msg = MessageBox.Show(string.Format("El numero de documento ingresado fue: {0}. Esta seguro?", Txt_Dni.Text), "Atención", MessageBoxButtons.YesNo);
                    if (msg == DialogResult.Yes)
                    {
                        MessageBox.Show("Por favor ingrese la fecha de nacimiento del cliente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Dtp_FechaNacimiento.Visible = true;
                        lblNac.Visible = true;
                        Txt_Dni.Enabled = false;
                        cboTipoDoc.Enabled = false;
                        Btn_Buscar.Visible = false;
                        Btn_Buscar2.Visible = true;

                    }
                    else
                    {
                        BotonesYtextosAestadoAnterior();
                    }
                }
                else
                {
                    cliente = clientes[0];
                    List<Encomienda> encomiendas = EncomiendaPersistencia.ObtenerEncomiendasFuturas(cliente.ID);
                    List<Pasaje> pasajes = PasajePersistencia.ObtenerPasajesFuturos(cliente.ID);

                    if ((encomiendas == null || encomiendas.Count == 0) & (pasajes == null || pasajes.Count == 0))
                    {
                        throw new Exception("No se encontraron compras disponibles para el cliente ingresado.");
                    }

                    ActualizarEncomiendaDGV(encomiendas);
                    ActualizarPasajeDGV(pasajes);
                    Btn_DevolverTodos.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void Btn_Buscar2_Click(object sender, EventArgs e)
        {
            int doc = Convert.ToInt32(Txt_Dni.Text);
            int tipo = Convert.ToInt32(cboTipoDoc.SelectedValue);
            DateTime fecha = Dtp_FechaNacimiento.Value.Date;
            Cliente cliente = ClientePersistencia.ObtenerClientePorDNIYFechaNac(doc, tipo, fecha);
            if (cliente == null)
            {
                MessageBox.Show("No se encontraron clientes con esos datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BotonesYtextosAestadoAnterior();
            }
            else
            {
                List<Encomienda> encomiendas = EncomiendaPersistencia.ObtenerEncomiendasFuturas(cliente.ID);
                List<Pasaje> pasajes = PasajePersistencia.ObtenerPasajesFuturos(cliente.ID);

                if ((encomiendas == null || encomiendas.Count == 0) & (pasajes == null || pasajes.Count == 0))
                {
                    throw new Exception("No se encontraron compras disponibles para el cliente ingresado.");
                }

                ActualizarEncomiendaDGV(encomiendas);
                ActualizarPasajeDGV(pasajes);
                Btn_DevolverTodos.Enabled = true;
            }
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            EncontrarUsuario();
        }


        private void ActualizarEncomiendaDGV(List<Encomienda> encomiendas)
        {
           
                var diccionarioDeEncimiendas = new Dictionary<int, Encomienda>();
                #region Cargar el diccionario a mostrar en la grilla
                if (encomiendas == null)
                {

                }
                else
                {
                    //El datasource se carga con la lista de pasajes recibida por parámetro
                    diccionarioDeEncimiendas = encomiendas.ToDictionary(e => e.ID, e => e);

                    //Muestra en la grilla el contenido de los pasajes que se encuentran cargados en el diccionario
                    var bind = diccionarioDeEncimiendas.Values.Select(e => new
                    {
                        Codigo_Encomienda = e.Codigo_Encomienda,
                        Kilos = e.KG,
                        Fecha_Salida = EncomiendaPersistencia.ObtenerFechaSalidaDeEncomienda(e.ID),
                        Origen = CiudadPersistencia.ObtenerCiudadPorId_Ciudad(EncomiendaPersistencia.ObtenerRutaDeEncomienda(e.ID).ID_Ciudad_Origen).Nombre,
                        Destino = CiudadPersistencia.ObtenerCiudadPorId_Ciudad(EncomiendaPersistencia.ObtenerRutaDeEncomienda(e.ID).ID_Ciudad_Destino).Nombre,
                        Precio = e.Precio

                    });

                    DgvEncomiendas.DataSource = bind.ToList();
                    AgregarBotonesDeEncomienda();
                    DgvEncomiendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                #endregion

        }

        private void AgregarBotonesDeEncomienda()
        {
            //Creo la columna de realizar devolucion
            var columnaDevolucion = new DataGridViewButtonColumn
            {
                Text = "Realizar Devolucion",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };


            //Agrego las columnas nuevas
            DgvEncomiendas.Columns.Add(columnaDevolucion);
        }

        private void ActualizarPasajeDGV(List<Pasaje> pasajes)
        {
                var diccionarioDePasajes = new Dictionary<int, Pasaje>();
                #region Cargar el diccionario a mostrar en la grilla

                if (pasajes == null)
                {

                }
                else
                {
                    //El datasource se carga con la lista de pasajes recibida por parámetro
                    diccionarioDePasajes = pasajes.ToDictionary(p => p.ID, p => p);

                //Muestra en la grilla el contenido de los pasajes que se encuentran cargados en el diccionario
                var bind = diccionarioDePasajes.Values.Select(p => new
                {
                    Codigo_Pasaje = p.Codigo_Pasaje,
                    Pasajero = ClientePersistencia.ObtenerNombreClientePorID(p.ID_Cliente),
                    Butaca = p.ID_Butaca,
                    Fecha_Salida = PasajePersistencia.ObtenerFechaSalidaDePasaje(p.ID),
                    Origen = CiudadPersistencia.ObtenerCiudadPorId_Ciudad(PasajePersistencia.ObtenerRutaDePasaje(p.ID).ID_Ciudad_Origen).Nombre,
                    Destino = CiudadPersistencia.ObtenerCiudadPorId_Ciudad(PasajePersistencia.ObtenerRutaDePasaje(p.ID).ID_Ciudad_Destino).Nombre,
                    Precio = p.Precio
                });
                DgvPasaje.DataSource = bind.ToList();
                AgregarBotonesDePasaje();
                DgvPasaje.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                #endregion
        }

        private void AgregarBotonesDePasaje()
        {
            //Creo la columna de realizar devolucion
            var columnaDevolucion = new DataGridViewButtonColumn
            {
                Text = "Realizar Devolucion",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };


            //Agrego las columnas nuevas
            DgvPasaje.Columns.Add(columnaDevolucion);
        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            BotonesYtextosAestadoAnterior();
            LimpiarDataGridView();

        }
        private void BotonesYtextosAestadoAnterior()
        {
            Txt_Dni.Text = string.Empty;
            if (Dtp_FechaNacimiento.Visible)
            {
                Dtp_FechaNacimiento.Value = DateTime.Now;
                Dtp_FechaNacimiento.Visible = false;
                lblNac.Visible = false;
                cboTipoDoc.Enabled = true;
                Txt_Dni.Enabled = true;
                Btn_Buscar2.Visible = false;
                Btn_Buscar.Visible = true;

            }
            Btn_DevolverTodos.Enabled = false;
            Btn_Finalizar.Enabled = true;
        }
        private void LimpiarDataGridView()
        {
            DgvEncomiendas.DataSource = null;
            DgvEncomiendas.Columns.Clear();
            DgvPasaje.DataSource = null;
            DgvPasaje.Columns.Clear();

            
        }

        private void Btn_Finalizar_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
