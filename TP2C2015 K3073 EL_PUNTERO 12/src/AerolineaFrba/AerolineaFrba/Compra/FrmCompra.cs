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

namespace AerolineaFrba.Compra
{
    public partial class FrmCompra : Form
    {
        private List<Viaje> _viajes = new List<Viaje>();

        public FrmCompra()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmCompra_Load(object sender, EventArgs e)
        {
            ActualizarPantalla();
        }

        private void ActualizarPantalla()
        {
            //Borro lo que esta actualmente en la grilla
            BorrarDataGridView();
            var viajesDictionary = new Dictionary<int, Viaje>();

            #region Cargar comboBox

            DtpFechaSalida.MinDate = DateTime.Now;
            
            CmbCiudadOrigen.DataSource = CiudadPersistencia.ObtenerTodos();
            CmbCiudadOrigen.ValueMember = "ID";
            CmbCiudadOrigen.DisplayMember = "Nombre";

            CmbCiudadDestino.DataSource = CiudadPersistencia.ObtenerTodos();
            CmbCiudadDestino.ValueMember = "ID";
            CmbCiudadDestino.DisplayMember = "Nombre";
            #endregion

            BorrarFiltrosUI();

        }

        private void BorrarFiltrosUI()
        {
            DtpFechaSalida.ResetText();
            CmbCiudadOrigen.Text = "CIUDAD ORIGEN";
            CmbCiudadDestino.Text = "CIUDAD DESTINO";
        }

        private void BorrarDataGridView()
        {
            DgvViaje.DataSource = null;
            DgvViaje.Columns.Clear();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            ActualizarPantalla();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var viajesDictionary = new Dictionary<int, Viaje>();

                #region Validaciones

                var filtrosSeteados = true;
                var exceptionMessage = string.Empty;

                if (CmbCiudadOrigen.Text == "CIUDAD ORIGEN")
                    filtrosSeteados = false;

                if (CmbCiudadDestino.Text == "CIUDAD DESTINO")
                    filtrosSeteados = false;

                if (!filtrosSeteados)
                    exceptionMessage = "No se puede realizar la busqueda ya que debe ingresar todos los campos";

                if (!ValidadorDeTipos.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                var filtros = new ViajeFiltros
                {
                    FechaSalida = DtpFechaSalida.Value,
                    CiudadDestino = CmbCiudadDestino.Text,
                    CiudadOrigen = CmbCiudadOrigen.Text
                };

                var viajes = ViajePersistencia.ObtenerViajePorParametros(filtros);

                if (viajes == null || viajes.Count == 0)
                    throw new Exception("No se encontraron viajes según los filtros informados.");

                ActualizarPantalla();

                #region Obtengo el diccionario de viajes

                CmbCiudadOrigen.Text = "CIUDAD ORIGEN";
                CmbCiudadDestino.Text = "CIUDAD DESTINO";
                //Convierto la lista de viajes a un diccionario con entradas de la forma: (ID, Objeto)
                viajesDictionary = viajes.ToDictionary(a => a.ID, a => a);

                #endregion
                
                //Creo un bind para luego setearselo directamente a la DataGridView
                var bind = viajesDictionary.Values.Select(a => new
                {
                    ID = a.ID,
                    FechaSalida = a.Fecha_Salida,
                    CiudadOrigen = ViajePersistencia.ObtenerCiudadOrigenPorIDRuta(a.ID_Ruta),
                    CiudadDestino = ViajePersistencia.ObtenerCiudadDestinoPorIDRuta(a.ID_Ruta),
                    //TipoServicio = AeronavePersistencia.ObtenerServicioPorAeronave(a.ID_Aeronave),
                    ButacasDisponibles = ViajePersistencia.ObtenerButacasDisponibles(a.ID) >=0 ? ViajePersistencia.ObtenerButacasDisponibles(a.ID) : 0,
                    KGsDisponibles = ViajePersistencia.ObtenerKGSDisponibles(a.ID) >=0 ? ViajePersistencia.ObtenerKGSDisponibles(a.ID) : 0
                });
                DgvViaje.DataSource = bind.ToList();
                DgvViaje.Columns[0].Visible = false;

                //Agrego los botones a cada fila para poder modificar/borrar cada ruta
                AgregarBotonesColumnas();

                int j = 0;
                for (int i = 0; i < DgvViaje.RowCount; i++)
                {
                    if (((int)DgvViaje.Rows[i].Cells[5].Value == 0) && ((int)DgvViaje.Rows[i].Cells[6].Value == 0))
                    {
                        DgvViaje.CurrentCell = null;
                        DgvViaje.Rows[i].Visible = false;
                        j++;
                    }
                }
                if (j == DgvViaje.RowCount)
                {
                    throw new Exception("No se encontraron viajes según los filtros informados.");
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }

        }

        private void AgregarBotonesColumnas()
        {
            //Creo la columna de seleccionar
            var columnaSeleccionar = new DataGridViewButtonColumn
            {
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            DgvViaje.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            //Agrego las columnas nuevas
            DgvViaje.Columns.Add(columnaSeleccionar);
        }

        private void DgvViaje_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Funciona solo cuando el usuario hace click en una fila (no en la cabecera)
            if (e.RowIndex == -1)
                return;

            _viajes = ViajePersistencia.ObtenerTodos();

            //Obtengo la ruta correspondiente a la fila seleccionada
            var viajeSeleccionado = _viajes.Find(v => (v.ID == (int)DgvViaje.Rows[e.RowIndex].Cells[0].Value));
            
            if (viajeSeleccionado != null)
            {
                //El usuario tocó el botón de seleccionar
                if (e.ColumnIndex == 7)
                {
                    var ingresoCantidades = new FrmIngresoCantidades(viajeSeleccionado,this);
                    ingresoCantidades.ShowDialog();
                }
            }
        }
    }
}
