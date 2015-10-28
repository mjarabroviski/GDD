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

namespace AerolineaFrba.Abm_Ruta
{
    public partial class FrmABMRuta : Form
    {
        private List<Ruta> _rutas = new List<Ruta>();

        public FrmABMRuta()
        {
            InitializeComponent();
        }

        private void TxtDesdeKg_Click(object sender, EventArgs e){}

        private void TxtDesdePasaje_TextChanged(object sender, EventArgs e){}

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void TxtDesdePasaje_Click(object sender, EventArgs e) { }

        private void TxtHastaKg_Click(object sender, EventArgs e) { }

        private void TxtHastaPasaje_Click(object sender, EventArgs e){ }

        private void TxtHastaPasaje_TextChanged(object sender, EventArgs e){}

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
                PrecioBasePasaje = a.Precio_Base_Pasaje
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
            CmbCiudadOrigen.ResetText();
            CmbCiudadDestino.ResetText();
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

    }
}
