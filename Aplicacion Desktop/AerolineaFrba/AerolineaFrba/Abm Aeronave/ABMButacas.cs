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
using System.Data.SqlClient;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class ABMButacas : Form
    {
        public Aeronave aeronave { get; set; }
        public SqlTransaction transaccionConcurrente;
        public bool accionTerminada = false;
        private List<Butaca> ListaButacas = new List<Butaca>();

        public ABMButacas(Aeronave aeronaveAModificar, SqlTransaction transaccion)
        {
            InitializeComponent();
            aeronave = aeronaveAModificar;
            transaccionConcurrente = transaccion;
        }

        private void ABMButacas_Load(object sender, EventArgs e)
        {
            CboTipo.Enabled = false;
            BtnGrabar.Enabled = false;
            ActualizarPantalla(null);
            Limpiar();

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que desea modificar la aeronave?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                accionTerminada = true;
                Close();
            } 
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            //Vaciar grilla y limpiar los filtros
            Limpiar();
            ActualizarPantalla(null);
        }

        public void Limpiar()
        {
            CboTipo.Text = string.Empty;
        }

        private void LimpiarDataGridView()
        {
            DgvButacas.DataSource = null;
            DgvButacas.Columns.Clear();
        }

        private void ActualizarPantalla(List<Butaca> butacas)
        {
            LimpiarDataGridView();
            var diccionarioDeButacas = new Dictionary<int, Butaca>();

            #region Cargar el diccionario a mostrar en la grilla

            if (butacas == null)
            {
                //El datasource se carga con todos las aeronaves de la BD
                Limpiar();
                ListaButacas = ButacaPersistencia.ObtenerTodasDeAeronave(aeronave, transaccionConcurrente);
                diccionarioDeButacas = ListaButacas.ToDictionary(a => a.ID, a => a);
            }
            else
            {
                //El datasource se carga con la lista de butacas recibida por parámetro
                diccionarioDeButacas = butacas.ToDictionary(a => a.ID, a => a);
            }

            //Muestra en la grilla el contenido de las butacas que se encuentran cargados en el diccionario
            var bind = diccionarioDeButacas.Values.Select(a => new
            {
                Numero = a.Numero,
                Tipo = TipoButacaPersistencia.ObtenerTipoPorButaca(a, transaccionConcurrente).Descripcion
            });

            #endregion

            DgvButacas.DataSource = bind.ToList();
            AgregarBotonesDeColumnas();

            DgvButacas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AgregarBotonesDeColumnas()
        {
            //Creo la columna de modificar
            var columnaActualizar = new DataGridViewButtonColumn
            {
                Text = "Modificar Servicio",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };

            //Agrego la columna nueva
            DgvButacas.Columns.Add(columnaActualizar);
        }

    }
}
