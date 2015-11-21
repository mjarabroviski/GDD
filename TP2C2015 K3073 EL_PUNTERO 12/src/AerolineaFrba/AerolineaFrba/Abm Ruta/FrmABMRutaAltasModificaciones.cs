using Filtros;
using Persistencia;
using Persistencia.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class FrmABMRutaAltasModificaciones : Form
    {
        public bool modoModificacion { get; set; }

        public Ruta RutaActual { get; set; }

        public bool AccionCompleta = false;

        public FrmABMRutaAltasModificaciones(Ruta ruta)
        {
            InitializeComponent();

            //Si no se le pasa ninguna ruta por parámetro (NULL) se considera que esta trabajando en modo alta
            modoModificacion = !(ruta == null);

            if (modoModificacion)
                RutaActual = ruta;

        }

        private void FrmABMRutaAltasModificaciones_Load(object sender, EventArgs e)
        {
            this.Text = (!modoModificacion) ? string.Format("{0} - {1}", "AerolineaFrba", "Nueva ruta") : string.Format("{0} - {1}", "AerolineaFrba", "Modificar ruta");

            #region Cargar comboBox
            CmbTipoServicio.Enabled = false;

            CmbCiudadOrigen.DataSource = CiudadPersistencia.ObtenerTodos();
            CmbCiudadOrigen.ValueMember = "ID";
            CmbCiudadOrigen.DisplayMember = "Nombre";

            CmbCiudadDestino.DataSource = CiudadPersistencia.ObtenerTodos();
            CmbCiudadDestino.ValueMember = "ID";
            CmbCiudadDestino.DisplayMember = "Nombre";
            #endregion

            ChkInhabilitado.Checked = false;

            if (modoModificacion)
            {
                //Esta trabajando en modo modificación
                TxtCodigo.Text = RutaActual.Codigo_Ruta.ToString();
                ChkInhabilitado.Checked = !(RutaActual.Habilitado);

                CmbTipoServicio.DataSource = RutaPersistencia.ObtenerServiciosPorIDRuta(RutaActual.ID);
                CmbTipoServicio.ValueMember = "ID_Servicio";
                CmbTipoServicio.DisplayMember = "Nombre";

                CmbCiudadOrigen.Text = RutaPersistencia.ObtenerCiudadPorID(RutaActual.ID_Ciudad_Origen);
                CmbCiudadDestino.Text = RutaPersistencia.ObtenerCiudadPorID(RutaActual.ID_Ciudad_Destino);
                TxtBaseKg.Text = RutaActual.Precio_Base_KG.ToString();
                TxtBasePasaje.Text = RutaActual.Precio_Base_Pasaje.ToString();
                if (RutaActual.Habilitado) ChkInhabilitado.Enabled = false;
            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                Close();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones

                var exceptionMessage = string.Empty;

                if (string.IsNullOrEmpty(TxtCodigo.Text))
                    exceptionMessage += "El código de la ruta no puede ser vacío.";

                if (string.IsNullOrEmpty(TxtBaseKg.Text))
                    exceptionMessage += Environment.NewLine + "Debe ingresar un precio base por Kg.";

                if (string.IsNullOrEmpty(TxtBasePasaje.Text))
                    exceptionMessage += Environment.NewLine + "Debe ingresar un precio base por pasaje";

                if (!string.IsNullOrEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                if (!modoModificacion)
                {
                    #region Valido que no exista una ruta con la descripcion informada
                    var filtro = new RutaFiltros();
                    filtro.Codigo = Int32.Parse(TxtCodigo.Text);
                    filtro.CiudadOrigen = CmbCiudadOrigen.Text;
                    filtro.CiudadDestino = CmbCiudadDestino.Text;
                    filtro.TipoServicio = CmbTipoServicio.Text;
                    filtro.PrecioDesdeKg = double.Parse(TxtBaseKg.Text);
                    filtro.PrecioHastaKg = double.Parse(TxtBaseKg.Text);
                    filtro.PrecioDesdePasaje = double.Parse(TxtBasePasaje.Text);
                    filtro.PrecioHastaPasaje = double.Parse(TxtBasePasaje.Text);

                    var rutas = RutaPersistencia.ObtenerRutasPorParametros(filtro);
                    var mensajeExcepcion = string.Empty;

                    if (rutas.Count!=0)
                        throw new Exception("Ya existe una ruta con los datos ingresados");

                    #endregion

                    if (filtro.CiudadOrigen == filtro.CiudadDestino)
                        mensajeExcepcion += "No puede crear una ruta con la misma ciudad de origen y destino";

                    if(!(ValidadorDeTipos.IsNumeric(TxtCodigo.Text)))
                        mensajeExcepcion += Environment.NewLine + "El código de ruta debe ser un número";

                    if (!(ValidadorDeTipos.IsNumeric(TxtBaseKg.Text)))
                        mensajeExcepcion += Environment.NewLine + "El precio base del KG debe ser un número";

                    if (!(ValidadorDeTipos.IsNumeric(TxtBasePasaje.Text)))
                        mensajeExcepcion += Environment.NewLine + "El precio base del pasaje debe ser un número";

                    if (!ValidadorDeTipos.IsEmpty(mensajeExcepcion))
                        throw new Exception(mensajeExcepcion);

                    //TODO Por qué no me muestra el mensaje de error que le dije??

                    #region Inserto una nueva ruta

                    var ruta = new Ruta();
                    ruta.Codigo_Ruta = (int)(filtro.Codigo);
                    ruta.ID_Ciudad_Origen = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(filtro.CiudadOrigen);
                    ruta.ID_Ciudad_Destino = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(filtro.CiudadDestino);
                    //ruta.ID_Servicio = ServicioPersistencia.ObtenerIDPorNombreDeServicio(filtro.TipoServicio);
                    ruta.Precio_Base_KG = (double)filtro.PrecioDesdeKg;   //ES INDISTINTO PONER DESDE O HASTA PORQUE EN ESTE CASO SON IGUALES
                    ruta.Precio_Base_Pasaje = (double)filtro.PrecioDesdePasaje;  //ES INDISTINTO PONER DESDE O HASTA PORQUE EN ESTE CASO SON IGUALES
                    ruta.Habilitado = !(ChkInhabilitado.Checked);

                    var dialogAnswer = MessageBox.Show("Esta seguro que quiere insertar la nueva ruta?", "Atencion", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        //Impacto en la base
                        RutaPersistencia.InsertarRuta(ruta);
                        AccionCompleta = true;
                        Close();
                    }
                    
                    #endregion

                }
                else
                {
                    #region Modifico una ruta existente

                    var rutaAModificar = RutaActual;
                    RutaActual.Codigo_Ruta = Int32.Parse(TxtCodigo.Text);
                    RutaActual.ID_Ciudad_Origen = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CmbCiudadOrigen.Text);
                    RutaActual.ID_Ciudad_Destino = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CmbCiudadDestino.Text);
                    //RutaActual.ID_Servicio = ServicioPersistencia.ObtenerIDPorNombreDeServicio(CmbTipoServicio.Text);
                    RutaActual.Precio_Base_KG = double.Parse(TxtBaseKg.Text);   //ES INDISTINTO PONER DESDE O HASTA PORQUE EN ESTE CASO SON IGUALES
                    RutaActual.Precio_Base_Pasaje = double.Parse(TxtBasePasaje.Text);  //ES INDISTINTO PONER DESDE O HASTA PORQUE EN ESTE CASO SON IGUALES
                    RutaActual.Habilitado = !(ChkInhabilitado.Checked);

                    var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que quiere modificar la ruta {0} de {1} a {2}?", rutaAModificar.Codigo_Ruta, RutaPersistencia.ObtenerCiudadPorID(rutaAModificar.ID_Ciudad_Origen), RutaPersistencia.ObtenerCiudadPorID(rutaAModificar.ID_Ciudad_Destino)), "Atención", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        //Impacto en la base
                        RutaPersistencia.ModificarRuta(RutaActual);
                        AccionCompleta = true;
                        Close();
                    }


                    #endregion
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }


    }
}
