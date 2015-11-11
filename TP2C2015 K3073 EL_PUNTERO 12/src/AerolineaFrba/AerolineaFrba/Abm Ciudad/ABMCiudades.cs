using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Persistencia.Entidades;
using Persistencia;
using Filtros;

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class ABMCiudades : Form
    {
        private List<Ciudad> Listaciudades = new List<Ciudad>();

        public ABMCiudades()
        {
            InitializeComponent();
        }

        private void ABMCiudades_Load(object sender, EventArgs e)
        {
            ActualizarPantalla(null);
        }

        private void ActualizarPantalla(List<Ciudad> ciudades) {
            //Borro lo que esta actualmente en la grilla
            LimpiarDataGridView();
            var ciudadesDiccionario = new Dictionary<int, Ciudad>();

            #region Obtener el diccionario de ciudades

            if (ciudades == null)
            {
                //El datasource debe ser todos los registros de ciudades almacenados en la base de datos
                LimpiarFiltros();
                Listaciudades = CiudadPersistencia.ObtenerTodos();
                //Convierto todas las ciudades a un diccionario con entradas de la forma: (ID, Objeto)
                ciudadesDiccionario = Listaciudades.ToDictionary(a => a.ID, a => a);
            }
            else
            {
                //El datasource debe ser una lista de ciudades obtenidas por parametro
                //Convierto la lista de ciudades a un diccionario con entradas de la forma: (ID, Objeto)
                ciudadesDiccionario = ciudades.ToDictionary(a => a.ID, a => a);
            }

            #endregion

            //Creo un bind para luego setearselo directamente a la DataGridView
            var bind = ciudadesDiccionario.Values.Select(a => new
            {
                //Codigo = a.ID,
                Nombre = a.Nombre
            });

            DgvCiudad.DataSource = bind.ToList();

            //Agrego los botones a cada fila para poder modificar/borrar cada ciudad
            AgregarBotonesDeColumnas();
        }

        private void LimpiarDataGridView()
        {
            DgvCiudad.DataSource = null;
            DgvCiudad.Columns.Clear();
        }

        private void LimpiarFiltros() {
            TxtNombre.Text = string.Empty;
            ChkBusqueda.Checked = false;
        }

        private void AgregarBotonesDeColumnas()
        {
            //Creo la columna de modificar
            var columnaActualizar = new DataGridViewButtonColumn
            {
                Text = "Modificar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
           
            //Creo la columna de borrar
            var columnaEliminar = new DataGridViewButtonColumn
            {
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            //Agrego las columnas nuevas
            DgvCiudad.Columns.Add(columnaActualizar);
            DgvCiudad.Columns.Add(columnaEliminar);
        }

        private void DgvCiudad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int cant = 0;
            //Solo funciona cuando el usuario hace click en los botones (columnas 1 y 2)
            if (e.RowIndex == -1)
                return;

            var ciudadSeleccionada = Listaciudades.Find(ciudad => ciudad.Nombre == (string)DgvCiudad.Rows[e.RowIndex].Cells[0].Value);

            if (ciudadSeleccionada != null)
            {
                //El usuario tocó el botón de modificar
                if (e.ColumnIndex == 1 )
                {
                    
                    var insertarActualizarCiudad = new ABMInsertarActualizarCiudad(ciudadSeleccionada);
                    insertarActualizarCiudad.ShowDialog();

                    //Paso NULL para volver a obtener todos los registros de la base
                    if (insertarActualizarCiudad.accionTerminada)
                        ActualizarPantalla(null);
                    
                }
                else if (e.ColumnIndex == 2)
                {
                    //El usuario tocó el botón de eliminar
                    using (var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
                    {
                        try
                        {
                            var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que quiere eliminar la ciudad {0}?", ciudadSeleccionada.Nombre), "Atención", MessageBoxButtons.YesNo);
                            if (dialogAnswer == DialogResult.Yes)
                            {
                                cant = CiudadPersistencia.Eliminar(ciudadSeleccionada, transaccion);
                                if ( cant == -1)
                                {
                                    transaccion.Commit();
                                    MessageBox.Show("No se puede eliminar la ciudad ya que tiene viajes asignados", "Error");
                                    return;
                                }
                                else
                                {
                                    transaccion.Commit();
                                    MessageBox.Show("La ciudad fue eliminada correctamente", "Atencion");
                                    ActualizarPantalla(null);
                                }
                            }

                        }
                        catch (Exception)
                        {
                            transaccion.Rollback();
                            throw new Exception("Se produjo un error durante la eliminacion de la ciudad");
                        }
                    }
                }
            }
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblNuevo_Click(object sender, EventArgs e)
        {
            var insertarActualizarCiudad = new ABMInsertarActualizarCiudad(null);
            insertarActualizarCiudad.ShowDialog();

            //Paso NULL para volver a obtener todos los registros de la base
            if (insertarActualizarCiudad.accionTerminada)
                ActualizarPantalla(null);
        }

        private void LblBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validations

                var filtros = false;
                var exceptionMessage = string.Empty;

                if (!ValidadorDeTipos.IsEmpty(TxtNombre.Text))
                    filtros = true;

                if (!filtros)
                    exceptionMessage = "No se puede realizar la busqueda ya que no se informó ningún filtro";

                if (!ValidadorDeTipos.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                //Armo el objeto que representa a los filtros a partir de los valores de los controles
                var filtro = new CiudadFiltros
                {
                    Nombre = (!ValidadorDeTipos.IsEmpty(TxtNombre.Text)) ? TxtNombre.Text : null,
                };

                var ciudades = new List<Ciudad>();
                if (ChkBusqueda.Checked) ciudades = CiudadPersistencia.ObtenerTodasPorParametro(filtro);
                else ciudades = CiudadPersistencia.ObtenerTodosPorParametroComo(filtro);

                if (ciudades == null || ciudades.Count == 0)
                {
                    LimpiarFiltros();
                    ActualizarPantalla(null);
                    throw new Exception("No se encontraron ciudades según los filtros informados.");
                }

                //Cargo la grilla a partir de los registros obtenidos en la busqueda
                ActualizarPantalla(ciudades);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void ChkBusquedaExacta_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            //Vaciar grilla y limpiar los filtros
            LimpiarFiltros();
            ActualizarPantalla(null);
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
