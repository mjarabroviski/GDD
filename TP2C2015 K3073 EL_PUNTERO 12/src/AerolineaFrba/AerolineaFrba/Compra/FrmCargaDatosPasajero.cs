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
            else
            {
                this.Visible = false;
                //Cargar el formulario de datos del pago
            }

           
        }

        private void FrmCargaDatosPasajero_Load(object sender, EventArgs e)
        {
            CmbTipoDoc.DataSource = TipoDocumentoPersistencia.ObtenerTodos();
            CmbTipoDoc.ValueMember = "ID";
            CmbTipoDoc.DisplayMember = "Descripcion";

            if (ordenPasaje == cantPasajesActual+1)
            {
                BtnSiguiente.Text = "FINALIZAR CARGA";
            }

            CargarDgvButacas();
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
                Numero = a.Numero,
                Tipo = TipoButacaPersistencia.ObtenerTipoButaca(a).Descripcion,
                Piso = a.Piso
            });

            #endregion

            DgvButacas.DataSource = bind.ToList();
            //AgregarBotonesDeColumnas();

            DgvButacas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                var mensajeExcepcion = string.Empty;

                #region Validaciones
                if (!(ValidadorDeTipos.IsNumeric(TxtNroDoc.Text)))
                    mensajeExcepcion += Environment.NewLine + "El documento debe ser un número";

                if (!(ValidadorDeTipos.IsNumeric(TxtNroCalle.Text)))
                    mensajeExcepcion += Environment.NewLine + "La altura de la dirección debe ser un número";

                if (!(ValidadorDeTipos.IsNumeric(TxtTelefono.Text)))
                    mensajeExcepcion += Environment.NewLine + "El teléfono debe ser un número";

                if ((!(ValidadorDeTipos.IsMailValido(TxtMail.Text))) && (!(ValidadorDeTipos.IsEmpty(TxtMail.Text))))
                    mensajeExcepcion += Environment.NewLine + "Formato inválido de mail";

                if (!ValidadorDeTipos.IsEmpty(mensajeExcepcion))
                    throw new Exception(mensajeExcepcion);

                #endregion
                /*
                CompraPersistencia.CargarTablaDatosPasajeros(CmbTipoDoc.Text,
                                                             TxtNroDoc.Text,
                                                             TxtApellidos.Text,
                                                             TxtNombres.Text,
                                                             TxtCalle.Text,
                                                             TxtNroCalle.Text,
                                                             TxtPiso.Text,
                                                             TxtDepto.Text,
                                                             TxtTelefono.Text,
                                                             DtpFechaNac.Text,
                                                             TxtMail.Text,
                                                             DgvButacas.SelectedRows[0].);

                */

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
    }
}
