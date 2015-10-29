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
using Herramientas;
using Filtros;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class ABMAeronaves : Form
    {
        private List<Aeronave> _aeronaves = new List<Aeronave>();

        public ABMAeronaves()
        {
            InitializeComponent();
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            //Vaciar grilla y limpiar los filtros
            LimpiarFiltros();
            ActualizarPantalla(null);
        }

        public void LimpiarFiltros() {
            TxtFabricante.Text = string.Empty;
            TxtMatricula.Text = string.Empty;
            TxtModelo.Text = string.Empty;
            CboServicio.Text = string.Empty;
            dtpAlta.Text = string.Empty;
            ChkBusquedaExacta.Checked = false;
        }

        private void LimpiarDataGridView()
        {
            DgvAeronaves.DataSource = null;
            DgvAeronaves.Columns.Clear();
        }

        private void ABMAeronaves_Load(object sender, EventArgs e)
        {
            ActualizarPantalla(null);
        }

        private void ActualizarPantalla(List<Aeronave> aeronaves) {
            #region Cargar Servicios

            //Carga el combobox de servicios
            CboServicio.DataSource = ServicioPersistencia.ObtenerTodos();
            CboServicio.ValueMember = "ID_Servicio";
            CboServicio.DisplayMember = "Nombre";

            #endregion

            LimpiarDataGridView();
            var diccionarioDeAeronaves = new Dictionary<int, Aeronave>();

            #region Cargar el diccionario a mostrar en la grilla

            if (aeronaves == null)
            {
                //El datasource se carga con todos las aeronaves de la BD
                LimpiarFiltros();
                _aeronaves = AeronavePersistencia.ObtenerTodas();
                diccionarioDeAeronaves = _aeronaves.ToDictionary(a => a.ID, a => a);
            }
            else
            {
                //El datasource se carga con la lista de aeronaves recibida por parámetro
                diccionarioDeAeronaves = aeronaves.ToDictionary(a => a.ID, a => a);
            }

            #endregion

            //Muestra en la grilla el contenido de las aeronaves que se encuentran cargados en el diccionario
            var bind = diccionarioDeAeronaves.Values.Select(a => new
            {
                ID = a.ID,
                Matricula = a.Matricula,
                Fabricante = a.Fabricante,
                Modelo = a.Modelo,
                Tipo_Servicio = ServicioPersistencia.ObtenerServicioPorID(a.ID_Servicio).Nombre,
                Baja_Fuera_Servicio = a.Baja_Fuera_De_Servicio,
                Baja_Vida_Util = a.Baja_Vida_Util,
                Fecha_Baja_Definitiva = a.Fecha_Baja_Fuera_Servicio,
                Fecha_Alta = a.Fecha_Alta,
                KG_Totales = a.KG_Totales
            });

            DgvAeronaves.DataSource = bind.ToList();
            AgregarBotonesDeColumnas();

            DgvAeronaves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void AgregarBotonesDeColumnas()
        {
            //Creo la columna de modificar
            var columnaActualizar = new DataGridViewButtonColumn
            {
                Text = "Modificar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };

            //Creo la columna de baja temporal
            var columnaBajaTemporal = new DataGridViewButtonColumn
            {
                Text = "Baja por Fuerva de Servicio",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };

            //Creo la columna para dar de baja por vida util
            var columnaBajaPorVidaUtil = new DataGridViewButtonColumn
            {
                Text = "Baja por Vida Util",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };

            //Agrego las columnas nuevas
            DgvAeronaves.Columns.Add(columnaActualizar);
            DgvAeronaves.Columns.Add(columnaBajaTemporal);
            DgvAeronaves.Columns.Add(columnaBajaPorVidaUtil);
        }

        private void LblBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones

                var filtrosSeteados = false;
                var mensajeDeExcepcion = string.Empty;

                if (!ValidadorDeTipos.IsEmpty(TxtMatricula.Text))
                    filtrosSeteados = true;

                if (!ValidadorDeTipos.IsEmpty(TxtFabricante.Text))
                    filtrosSeteados = true;

                if (!ValidadorDeTipos.IsEmpty(TxtModelo.Text))
                    filtrosSeteados = true;

                if (!ValidadorDeTipos.IsEmpty(CboServicio.Text))
                    filtrosSeteados = true;

                if (!ValidadorDeTipos.IsEmpty(dtpAlta.Text))
                    filtrosSeteados = true;

                if (!filtrosSeteados)
                    mensajeDeExcepcion = "No se puede realizar la búsqueda. Verifique que haya ingresado algún filtro y que los mismos sean válidos.";

                if (!ValidadorDeTipos.IsEmpty(mensajeDeExcepcion))
                    throw new Exception(mensajeDeExcepcion);

                #endregion

                 #region Cargar filtros 
                var filtros = new AeronaveFiltros
                {
                    Matricula = (!ValidadorDeTipos.IsEmpty(TxtMatricula.Text)) ? TxtMatricula.Text : null,
                    Fabricante = (!ValidadorDeTipos.IsEmpty(TxtFabricante.Text)) ? TxtFabricante.Text : null,
                    Modelo = (!ValidadorDeTipos.IsEmpty(TxtModelo.Text)) ? TxtModelo.Text : null,
                    Servicio = (!ValidadorDeTipos.IsEmpty(CboServicio.Text)) ? CboServicio.Text : null,
                    Fecha_Alta = (!ValidadorDeTipos.IsEmpty(dtpAlta.Text)) ? dtpAlta.Value.Date : DateTime.MinValue
                };

                 #endregion

                var aeronaves = (ChkBusquedaExacta.Checked) ? AeronavePersistencia.ObtenerTodasPorParametros(filtros) : AeronavePersistencia.ObtenerTodasPorParametrosComo(filtros);

                if (aeronaves == null || aeronaves.Count == 0)
                    throw new Exception("No se encontraron aeronaves según los filtros informados.");

                //Refrescar la grilla, cargando las aeronaves que se obtuvieron como resultado de los filtros
                ActualizarPantalla(aeronaves);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }
    }
}
