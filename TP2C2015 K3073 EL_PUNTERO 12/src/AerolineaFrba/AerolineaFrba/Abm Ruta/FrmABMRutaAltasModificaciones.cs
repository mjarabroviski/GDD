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
                else
                    if (!(ValidadorDeTipos.IsNumeric(TxtCodigo.Text)))
                        exceptionMessage += Environment.NewLine + "El código de ruta debe ser un número";

                if (CmbCiudadDestino.Text == CmbCiudadOrigen.Text)
                    exceptionMessage += Environment.NewLine + "No puede crear una ruta con la misma ciudad de origen y destino";

                if (string.IsNullOrEmpty(TxtBaseKg.Text))
                    exceptionMessage += Environment.NewLine + "Debe ingresar un precio base por Kg.";
                else
                {
                    if (!ValidadorDeTipos.IsDecimal(TxtBaseKg.Text) || TxtBaseKg.Text.Contains("."))
                        exceptionMessage += Environment.NewLine + "El precio base por Kg debe ser numerico";
                    else
                        if (double.Parse(TxtBaseKg.Text) <= 0)
                            exceptionMessage += Environment.NewLine + "El precio base por Kg debe ser mayor a 0";
                }

                if (string.IsNullOrEmpty(TxtBasePasaje.Text))
                    exceptionMessage += Environment.NewLine + "Debe ingresar un precio base por pasaje";
                else
                {
                    if (!ValidadorDeTipos.IsDecimal(TxtBasePasaje.Text) || TxtBasePasaje.Text.Contains("."))
                        exceptionMessage += Environment.NewLine + "El precio base por pasaje debe ser numerico";
                    else
                        if (double.Parse(TxtBasePasaje.Text) <= 0)
                            exceptionMessage += Environment.NewLine + "El precio base por pasaje debe ser mayor a 0";
                }


                if (!string.IsNullOrEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                if (!modoModificacion)
                {
                    #region Valido que no exista una ruta con la descripcion informada
                    var filtro = new RutaFiltros();
                    filtro.Codigo = Int32.Parse(TxtCodigo.Text);
                    filtro.CiudadOrigen = null;
                    filtro.CiudadDestino = null;
                    filtro.TipoServicio = null;
                    filtro.PrecioDesdeKg = null;
                    filtro.PrecioHastaKg = null;
                    filtro.PrecioDesdePasaje = null;
                    filtro.PrecioHastaPasaje = null;

                    var rutas = RutaPersistencia.ObtenerRutasPorParametros(filtro);

                    if (rutas.Count!=0)
                        throw new Exception("Ya existe una ruta con el código ingresado");

                    #endregion

                    #region Inserto una nueva ruta

                    var ruta = new Ruta();
                    ruta.Codigo_Ruta = (int)(filtro.Codigo);
                    ruta.ID_Ciudad_Origen = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CmbCiudadOrigen.Text);
                    ruta.ID_Ciudad_Destino = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CmbCiudadDestino.Text);
                    ruta.Precio_Base_KG = double.Parse(TxtBaseKg.Text);
                    ruta.Precio_Base_Pasaje = double.Parse(TxtBasePasaje.Text);
                    ruta.Habilitado = !(ChkInhabilitado.Checked);

                    //Impacto en la base
                    RutaPersistencia.InsertarRuta(ruta);
                    AccionCompleta = true;
                    FrmABMRutaModificacionServicio frmModificarServicio = new FrmABMRutaModificacionServicio(ruta,false);
                    frmModificarServicio.ShowDialog();
                    Close();
                    
                    #endregion


                }
                else
                {
                    #region Modifico una ruta existente

                    var rutaAModificar = RutaActual;
                    RutaActual.Codigo_Ruta = Int32.Parse(TxtCodigo.Text);
                    RutaActual.ID_Ciudad_Origen = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CmbCiudadOrigen.Text);
                    RutaActual.ID_Ciudad_Destino = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CmbCiudadDestino.Text);
                    RutaActual.Precio_Base_KG = double.Parse(TxtBaseKg.Text);   
                    RutaActual.Precio_Base_Pasaje = double.Parse(TxtBasePasaje.Text);  
                    RutaActual.Habilitado = !(ChkInhabilitado.Checked);

                    //Impacto en la base
                    RutaPersistencia.ModificarRuta(RutaActual);
                    AccionCompleta = true;
                    FrmABMRutaModificacionServicio frmModificarServicio = new FrmABMRutaModificacionServicio(RutaActual,true);
                    frmModificarServicio.ShowDialog();
                    Close();

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
