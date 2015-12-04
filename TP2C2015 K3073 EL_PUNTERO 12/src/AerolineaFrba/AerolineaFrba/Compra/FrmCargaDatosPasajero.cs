using Persistencia;
using Persistencia.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Configuracion;

namespace AerolineaFrba.Compra
{
    public partial class FrmCargaDatosPasajero : Form
    {
        public FrmIngresoCantidades formularioAnterior;
        public Viaje viajeActual;
        public int ordenPasaje;
        public decimal cantPasajesActual;
        public decimal cantEncomiendasActual;
        public List<Butaca> ListaButacas = new List<Butaca>();
        public Butaca butacaSeleccionada;

        public FrmCargaDatosPasajero(Viaje viaje,decimal cantPasajes,decimal cantEncomiendas,FrmIngresoCantidades ingresoCantidades,int nroOrdenPasaje)
        {
            formularioAnterior = ingresoCantidades;
            formularioAnterior.Visible = false;
            InitializeComponent();
            ordenPasaje = nroOrdenPasaje;
            cantPasajesActual = cantPasajes;
            cantEncomiendasActual = cantEncomiendas;
            viajeActual = viaje;
            if (ordenPasaje <= cantPasajes && ordenPasaje > 0)
            {
                LblNroPasajero.Text = "#" + ordenPasaje;
                ordenPasaje++;
            }
        }

        private void FrmCargaDatosPasajero_Load(object sender, EventArgs e)
        {
            CmbTipoDoc.DataSource = TipoDocumentoPersistencia.ObtenerTodos();
            CmbTipoDoc.ValueMember = "ID";
            CmbTipoDoc.DisplayMember = "Descripcion";

            TxtNroDoc.Select();
            DtpFechaNac.MaxDate = ConfiguracionDeVariables.FechaSistema;
            DtpFechaNac.Value = ConfiguracionDeVariables.FechaSistema;

            if (ordenPasaje == cantPasajesActual+1)
            {
                BtnSiguiente.Text = "FINALIZAR CARGA";
            }

            CargarDgvButacas();
            DgvButacas.CurrentCell = DgvButacas.Rows[0].Cells[1];
        }

        private void CargarDgvButacas()
        {
            var diccionarioDeButacas = new Dictionary<int, Butaca>();

            #region Cargar el diccionario a mostrar en la grilla

            ListaButacas = ButacaPersistencia.ObtenerTodasLasLibresDeAeronave(viajeActual);
            diccionarioDeButacas = ListaButacas.ToDictionary(a => a.ID, a => a);

            //Muestra en la grilla el contenido de las butacas que se encuentran cargados en el diccionario
            var bind = diccionarioDeButacas.Values.Select(a => new
            {
                ID = a.ID,
                Numero = a.Numero,
                Tipo = TipoButacaPersistencia.ObtenerTipoButaca(a).Descripcion,
                Piso = a.Piso
            });

            #endregion

            DgvButacas.DataSource = bind.ToList();
            DgvButacas.Columns[0].Visible = false;

            DgvButacas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                var mensajeExcepcion = string.Empty;

                #region Validaciones

                if (!(ValidadorDeTipos.IsEmpty(TxtNroDoc.Text)))
                {
                    if (!(ValidadorDeTipos.IsNumeric(TxtNroDoc.Text)))
                        mensajeExcepcion += Environment.NewLine + "El documento debe ser un número";
                }
                else
                {
                    mensajeExcepcion += Environment.NewLine + "Debe ingresar su documento";
                }

                if (ValidadorDeTipos.IsEmpty(TxtNombres.Text))
                {
                    mensajeExcepcion += Environment.NewLine + "Debe ingresar su nombre";
                }

                if (ValidadorDeTipos.IsEmpty(TxtApellidos.Text))
                {
                    mensajeExcepcion += Environment.NewLine + "Debe ingresar su apellido";
                }

                if (ValidadorDeTipos.IsEmpty(TxtCalle.Text))
                {
                    mensajeExcepcion += Environment.NewLine + "Debe ingresar la calle de su domicilio";
                }

                if (!(ValidadorDeTipos.IsEmpty(TxtNroCalle.Text)))
                {
                    if (!(ValidadorDeTipos.IsNumeric(TxtNroCalle.Text)))
                        mensajeExcepcion += Environment.NewLine + "La altura del domicilio debe ser un número";
                }
                else
                {
                    mensajeExcepcion += Environment.NewLine + "Debe ingresar la altura de su domicilio";
                }

                if (!(ValidadorDeTipos.IsEmpty(TxtTelefono.Text)))
                {
                    if (!(ValidadorDeTipos.IsNumeric(TxtTelefono.Text)))
                        mensajeExcepcion += Environment.NewLine + "El teléfono debe ser un número";
                }
                else
                {
                    mensajeExcepcion += Environment.NewLine + "Debe ingresar su teléfono";
                }

                if ((!(ValidadorDeTipos.IsMailValido(TxtMail.Text))) && (!(ValidadorDeTipos.IsEmpty(TxtMail.Text))))
                    mensajeExcepcion += Environment.NewLine + "Formato inválido de mail";

                if(!(ValidadorDeTipos.IsEmpty(TxtNroDoc.Text)))
                    if (ClientePersistencia.ElClienteYaEstaDeViaje(CmbTipoDoc.SelectedIndex + 1, Int32.Parse(TxtNroDoc.Text), viajeActual.ID, TxtApellidos.Text) > 0)
                        mensajeExcepcion += Environment.NewLine + "Ese cliente ya se encuentra en viaje para esas fechas";

                if (!ValidadorDeTipos.IsEmpty(mensajeExcepcion))
                    throw new Exception(mensajeExcepcion);

                #endregion

                butacaSeleccionada = ListaButacas.Find(b => (b.ID == (int)DgvButacas.CurrentRow.Cells[0].Value)); 
                
                CompraPersistencia.CargarTablaDatosPasajeros(CmbTipoDoc.Text,
                                                             Int32.Parse(TxtNroDoc.Text),
                                                             TxtApellidos.Text,
                                                             TxtNombres.Text,
                                                             TxtCalle.Text,
                                                             TxtNroCalle.Text,
                                                             TxtTelefono.Text,
                                                             DtpFechaNac.Value,
                                                             TxtMail.Text,
                                                             butacaSeleccionada.ID);
                
                

                if (ordenPasaje <= cantPasajesActual)
                {
                    var nuevoFormulario = new FrmCargaDatosPasajero(viajeActual, cantPasajesActual, cantEncomiendasActual, formularioAnterior, ordenPasaje);
                    this.Visible = false;
                    nuevoFormulario.ShowDialog();
                }
                else
                {
                    this.Visible = false;
                    var formularioPago = new FrmCargaDatosPago(null,cantPasajesActual,cantEncomiendasActual,viajeActual);
                    formularioPago.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que desea cancelar?"), "Atención", MessageBoxButtons.YesNo);
            if (dialogAnswer == DialogResult.Yes)
            {
                CompraPersistencia.BorrarTablaAuxiliar();
                formularioAnterior.Visible = true;
                this.Visible = false;
            }
        }

        private void TxtNroDoc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!(ValidadorDeTipos.IsNumeric(TxtNroDoc.Text)) && !(ValidadorDeTipos.IsEmpty(TxtNroDoc.Text)))
                    throw new Exception("El documento debe ser un número");

                if (!(ValidadorDeTipos.IsEmpty(TxtNroDoc.Text)))
                {
                    Cliente cliente = CompraPersistencia.ObtenerClientePorDoc(CmbTipoDoc.Text, Int32.Parse(TxtNroDoc.Text));
                    if (cliente != null)
                    {

                        for (int i = cliente.Direccion.Length-1; i > 0; i--)
                        {
                            if(!ValidadorDeTipos.IsNumeric(cliente.Direccion[i].ToString())){
                                TxtNroCalle.Text = cliente.Direccion.Substring(i + 1, cliente.Direccion.Length - 1 - i);
                                TxtCalle.Text = cliente.Direccion.Substring(0, i+1);
                                i = 0;
                            }

                        }

                        TxtApellidos.Text = cliente.Apellido;
                        TxtNombres.Text = cliente.Nombre;
                        TxtMail.Text = cliente.Mail;
                        TxtTelefono.Text = cliente.Telefono;
                        DtpFechaNac.Value = cliente.Fecha_Nacimiento;
                    }
                    else
                    {
                        TxtApellidos.Text = "";
                        TxtNombres.Text = "";
                        TxtCalle.Text = "";
                        TxtNroCalle.Text = "";
                        TxtMail.Text = "";
                        TxtTelefono.Text = "";
                        DtpFechaNac.Value = ConfiguracionDeVariables.FechaSistema;
                    }
                }
                else
                {
                    TxtApellidos.Text = "";
                    TxtNombres.Text = "";
                    TxtCalle.Text = "";
                    TxtNroCalle.Text = "";
                    TxtMail.Text = "";
                    TxtTelefono.Text = "";
                    DtpFechaNac.Value = ConfiguracionDeVariables.FechaSistema;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void TxtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Cuando presiona la tecla 'Enter', realizo el llenado automático
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    if (!(ValidadorDeTipos.IsNumeric(TxtNroDoc.Text)) && !(ValidadorDeTipos.IsEmpty(TxtNroDoc.Text)))
                        throw new Exception("El documento debe ser un número");

                    if (!(ValidadorDeTipos.IsEmpty(TxtNroDoc.Text)))
                    {
                        Cliente cliente = CompraPersistencia.ObtenerClientePorDoc(CmbTipoDoc.Text, Int32.Parse(TxtNroDoc.Text));
                        if (cliente != null)
                        {

                            for (int i = cliente.Direccion.Length - 1; i > 0; i--)
                            {
                                if (!ValidadorDeTipos.IsNumeric(cliente.Direccion[i].ToString()))
                                {
                                    TxtNroCalle.Text = cliente.Direccion.Substring(i + 1, cliente.Direccion.Length - 1 - i);
                                    TxtCalle.Text = cliente.Direccion.Substring(0, i + 1);
                                    i = 0;
                                }

                            }

                            TxtApellidos.Text = cliente.Apellido;
                            TxtNombres.Text = cliente.Nombre;
                            TxtMail.Text = cliente.Mail;
                            TxtTelefono.Text = cliente.Telefono;
                            DtpFechaNac.Value = cliente.Fecha_Nacimiento;
                        }
                        else
                        {
                            TxtApellidos.Text = "";
                            TxtNombres.Text = "";
                            TxtCalle.Text = "";
                            TxtNroCalle.Text = "";
                            TxtMail.Text = "";
                            TxtTelefono.Text = "";
                            DtpFechaNac.Value = ConfiguracionDeVariables.FechaSistema;
                        }
                    }
                    else
                    {
                        TxtApellidos.Text = "";
                        TxtNombres.Text = "";
                        TxtCalle.Text = "";
                        TxtNroCalle.Text = "";
                        TxtMail.Text = "";
                        TxtTelefono.Text = "";
                        DtpFechaNac.Value = ConfiguracionDeVariables.FechaSistema;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atención");
                }
            }
        }
    }
}
