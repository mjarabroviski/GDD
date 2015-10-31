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
        private List<Aeronave> ListaAeronaves = new List<Aeronave>();

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
            chkFecha.Checked = true;

            #region Cargar Servicios

            //Carga el combobox de servicios
            CboServicio.DataSource = ServicioPersistencia.ObtenerTodos();
            CboServicio.ValueMember = "ID_Servicio";
            CboServicio.DisplayMember = "Nombre";

            #endregion

            LimpiarFiltros();
        }

        private void ActualizarPantalla(List<Aeronave> aeronaves) {
            LimpiarDataGridView();
            var diccionarioDeAeronaves = new Dictionary<int, Aeronave>();

            #region Cargar el diccionario a mostrar en la grilla

            if (aeronaves == null)
            {
                //El datasource se carga con todos las aeronaves de la BD
                LimpiarFiltros();
                ListaAeronaves = AeronavePersistencia.ObtenerTodas();
                diccionarioDeAeronaves = ListaAeronaves.ToDictionary(a => a.ID, a => a);
            }
            else
            {
                //El datasource se carga con la lista de aeronaves recibida por parámetro
                diccionarioDeAeronaves = aeronaves.ToDictionary(a => a.ID, a => a);
            }

            //Muestra en la grilla el contenido de las aeronaves que se encuentran cargados en el diccionario
            var bind = diccionarioDeAeronaves.Values.Select(a => new
            {
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

            #endregion

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

                if (chkFecha.Checked && !ValidadorDeTipos.IsEmpty(dtpAlta.Text))
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
                    Fecha_Alta = (chkFecha.Checked==true) ? dtpAlta.Value.Date : DateTime.MinValue
                };

                 #endregion

                var aeronaves = (ChkBusquedaExacta.Checked) ? AeronavePersistencia.ObtenerTodasPorParametros(filtros) : AeronavePersistencia.ObtenerTodasPorParametrosComo(filtros);

                if (aeronaves == null || aeronaves.Count == 0)
                {
                    ActualizarPantalla(null);
                    LimpiarFiltros();
                    throw new Exception("No se encontraron aeronaves según los filtros informados.");
                }

                //Refrescar la grilla, cargando las aeronaves que se obtuvieron como resultado de los filtros
                CboServicio.Text = string.Empty;
                ActualizarPantalla(aeronaves);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void chkFecha_Click(object sender, EventArgs e)
        {
            if (chkFecha.Checked) dtpAlta.Enabled = true;
            else dtpAlta.Enabled = false;
        }

        private void DgvAeronaves_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int cant = 0;
            //Solo funciona cuando el usuario hace click en los botones de la columnas
            if (e.RowIndex == -1 || e.ColumnIndex >= 0 && e.ColumnIndex < 9)
                return;

            var aeronaveSeleccionada = ListaAeronaves.Find(aeronave => aeronave.Matricula == (string)DgvAeronaves.Rows[e.RowIndex].Cells[0].Value);

            if (aeronaveSeleccionada != null)
            {
                //El usuario tocó el botón de modificar
                if (e.ColumnIndex == 9)
                {
                    var insertarActualizarAeronave = new ABMInsertarActualizarAeronave(aeronaveSeleccionada,true);
                    insertarActualizarAeronave.ShowDialog();

                    //Paso NULL para volver a obtener todos los registros de la base
                    if (insertarActualizarAeronave.accionTerminada)
                        ActualizarPantalla(null);
                }
                //El usuario tocó el botón de dar de baja por vida util
                else if (e.ColumnIndex == 11)
                {
                    var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que quiere dar de baja por fin de vida util la aeronave {0}?", aeronaveSeleccionada.Matricula), "Atención", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        cant = AeronavePersistencia.BajaPorVidaUtil(aeronaveSeleccionada);
                        if ( cant == -1)
                        {
                            var cancelarOReemplazar = new ABMCancelarOReemplazar(aeronaveSeleccionada);
                            cancelarOReemplazar.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("La aeronave fue dada de baja por fin de vida util correctamente","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            ActualizarPantalla(null);
                        }
                    }
                }
                else if (e.ColumnIndex == 10)
                {
                    var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que quiere dar de baja por fuera de servicio la aeronave {0}?", aeronaveSeleccionada.Matricula), "Atención", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                            var fueraDeServicio = new ABMFueraDeServicio(aeronaveSeleccionada);
                            fueraDeServicio.ShowDialog();
                    }
                }
            }
        }

        private void LblNuevo_Click(object sender, EventArgs e)
        {
            var insertarActualizarAeronave = new ABMInsertarActualizarAeronave(null, false);
            insertarActualizarAeronave.ShowDialog();
            ActualizarPantalla(null);
        }
    }
}
