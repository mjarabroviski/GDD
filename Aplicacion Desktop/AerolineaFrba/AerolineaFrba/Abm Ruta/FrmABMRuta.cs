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
using Persistencia;
using Filtros;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class FrmABMRuta : Form
    {
        private List<Ruta> _rutas = new List<Ruta>();

        public FrmABMRuta()
        {
            InitializeComponent();
        }

        private void BtnListo_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void FrmABMRuta_Load(object sender, EventArgs e)
        {
            ActualizarPantalla(null);
        }
        
        private void ActualizarPantalla(List<Ruta> rutas)
        {
            //Borro lo que esta actualmente en la grilla
            BorrarDataGridView();
            var rutasDictionary = new Dictionary<int, Ruta>();

            #region Cargar comboBox
            CmbTipoServicio.DataSource = ServicioPersistencia.ObtenerTodos();
            CmbTipoServicio.ValueMember = "ID_Servicio";
            CmbTipoServicio.DisplayMember = "Nombre";

            CmbCiudadOrigen.DataSource = CiudadPersistencia.ObtenerTodos();
            CmbCiudadOrigen.ValueMember = "ID";
            CmbCiudadOrigen.DisplayMember = "Nombre";

            CmbCiudadDestino.DataSource = CiudadPersistencia.ObtenerTodos();
            CmbCiudadDestino.ValueMember = "ID";
            CmbCiudadDestino.DisplayMember = "Nombre";
            #endregion

            #region Obtengo el diccionario de rutas

            //El datasource debe ser todos los registros de roles almacenados en la base de datos
            if (rutas == null)
            {
                BorrarFiltrosUI();
                _rutas = RutaPersistencia.ObtenerTodas();
                //Convierto todas las rutas a un diccionario con entradas de la forma: (ID, Objeto)
                rutasDictionary = _rutas.ToDictionary(a => a.ID, a => a);
            }
            else
            {
                CmbTipoServicio.Text = "SERVICIO";
                CmbCiudadOrigen.Text = "CIUDAD ORIGEN";
                CmbCiudadDestino.Text = "CIUDAD DESTINO";
                //Convierto la lista de rutas a un diccionario con entradas de la forma: (ID, Objeto)
                rutasDictionary = rutas.ToDictionary(a => a.ID, a => a);
            }

            #endregion

            //Creo un bind para luego setearselo directamente a la DataGridView
            var bind = rutasDictionary.Values.Select(a => new
            {
                CodigoRuta = a.Codigo_Ruta,
                TipoServicio = RutaPersistencia.ObtenerServicioPorID(a.ID_Servicio),
                CiudadOrigen = RutaPersistencia.ObtenerCiudadPorID(a.ID_Ciudad_Origen),
                CiudadDestino = RutaPersistencia.ObtenerCiudadPorID(a.ID_Ciudad_Destino),
                PrecioBaseKg = a.Precio_Base_KG,
                PrecioBasePasaje = a.Precio_Base_Pasaje,
                Habilitado = a.Habilitado
            });
            DgvRuta.DataSource = bind.ToList();

            //Agrego los botones a cada fila para poder modificar/borrar cada rol
            AgregarBotonesColumnas();
        }

        private void BorrarDataGridView()
        {
            DgvRuta.DataSource = null;
            DgvRuta.Columns.Clear();
        }

        private void BorrarFiltrosUI()
        {
            TxtCodigo.Text = string.Empty;
            TxtDesdeKg.Text = string.Empty;
            TxtDesdePasaje.Text = string.Empty;
            TxtHastaKg.Text = string.Empty;
            TxtHastaPasaje.Text = string.Empty;
            CmbTipoServicio.Text = "SERVICIO";
            CmbCiudadOrigen.Text = "CIUDAD ORIGEN";
            CmbCiudadDestino.Text = "CIUDAD DESTINO";
        }

        private void AgregarBotonesColumnas()
        {
            //Creo la columna de modificar
            var updateColumn = new DataGridViewButtonColumn
            {
                Text = "Modificar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            //Creo la columna de borrar
            var deleteColumn = new DataGridViewButtonColumn
            {
                Text = "Inhabilitar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            //Agrego las columnas nuevas
            DgvRuta.Columns.Add(updateColumn);
            DgvRuta.Columns.Add(deleteColumn);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                #region Validaciones

                var filtrosSeteados = false;
                var exceptionMessage = string.Empty;

                if (!ValidadorDeTipos.IsEmpty(TxtCodigo.Text))
                    filtrosSeteados = true;

                if (!ValidadorDeTipos.IsEmpty(TxtDesdeKg.Text))
                    filtrosSeteados = true;

                if (!ValidadorDeTipos.IsEmpty(TxtDesdePasaje.Text))
                    filtrosSeteados = true;

                if (!ValidadorDeTipos.IsEmpty(TxtHastaKg.Text))
                    filtrosSeteados = true;

                if (!ValidadorDeTipos.IsEmpty(TxtHastaPasaje.Text))
                    filtrosSeteados = true;

                if (CmbTipoServicio.Text != "SERVICIO")
                    filtrosSeteados = true;

                if (CmbCiudadOrigen.Text != "CIUDAD ORIGEN")
                    filtrosSeteados = true;

                if (CmbCiudadDestino.Text != "CIUDAD DESTINO")
                    filtrosSeteados = true;

                if (!filtrosSeteados)
                    exceptionMessage = "No se puede realizar la busqueda porque no ingreso ningun filtro";

                if (!ValidadorDeTipos.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                #region Cargo los filtros ingresados en el objeto RutaFiltros
                int? cod;
                if (!ValidadorDeTipos.IsEmpty(TxtCodigo.Text)) cod = Int32.Parse(TxtCodigo.Text);
                else cod =null;

                double? desdeKg;
                if (!ValidadorDeTipos.IsEmpty(TxtDesdeKg.Text)) desdeKg = double.Parse(TxtDesdeKg.Text);
                else desdeKg = null;

                double? hastaKg;
                if (!ValidadorDeTipos.IsEmpty(TxtHastaKg.Text)) hastaKg = double.Parse(TxtHastaKg.Text);
                else hastaKg = null;

                double? desdePje;
                if (!ValidadorDeTipos.IsEmpty(TxtDesdePasaje.Text)) desdePje = double.Parse(TxtDesdePasaje.Text);
                else desdePje = null;

                double? hastaPje;
                if (!ValidadorDeTipos.IsEmpty(TxtHastaPasaje.Text)) hastaPje = double.Parse(TxtHastaPasaje.Text);
                else hastaPje = null; 

                var filtros = new RutaFiltros
                {
                    Codigo = cod,
                    TipoServicio = (CmbTipoServicio.Text != "SERVICIO") ? CmbTipoServicio.Text : null,
                    CiudadDestino = (CmbCiudadDestino.Text != "CIUDAD DESTINO") ? CmbCiudadDestino.Text : null,
                    CiudadOrigen = (CmbCiudadOrigen.Text != "CIUDAD ORIGEN") ? CmbCiudadOrigen.Text : null,
                    PrecioDesdeKg = desdeKg,
                    PrecioHastaKg = hastaKg,
                    PrecioDesdePasaje = desdePje,
                    PrecioHastaPasaje = hastaPje
                };

                #endregion

                var rutas = RutaPersistencia.ObtenerRutasPorParametros(filtros);

                if (rutas == null || rutas.Count == 0)
                    throw new Exception("No se encontraron rutas según los filtros informados.");

                //Recargo los valores de la grilla a partir de los resultados obtenidos en la busqueda
                ActualizarPantalla(rutas);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            ActualizarPantalla(null);
        }

        private void BtnNuevo_Click(object sender, EventArgs e){
            FrmABMRutaAltasModificaciones frmABMRutaAM = new FrmABMRutaAltasModificaciones(null);
            frmABMRutaAM.ShowDialog();

            //Paso NULL para volver a obtener todos los registros de la base
            //ActualizarPantalla(null); 
        //TODO
        }



    }
}
