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

namespace AerolineaFrba.Canje_Millas
{
    public partial class VerTodosLosProductos : Form
    {
        private List<Producto> productos = new List<Producto>();

        public VerTodosLosProductos()
        {
            InitializeComponent();
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void VerTodosLosProductos_Load(object sender, EventArgs e)
        {
            ActualizarProductos();
        }

        public void ActualizarProductos() {
            LimpiarDataGridView();
            var diccionarioDeProductos = new Dictionary<int, Producto>();

            #region Cargar el diccionario a mostrar en la grilla

            productos = ProductoPersistencia.ObtenerTodos();
            if (productos.Count == 0 || productos == null)
            {
                MessageBox.Show("No se cuenta con productos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarDataGridView();
            }
            diccionarioDeProductos = productos.ToDictionary(a => a.ID, a => a);

            //Muestra en la grilla el contenido de los registros que se encuentran cargados en el diccionario
            var bind = diccionarioDeProductos.Values.Select(a => new
            {
                Descripcion = a.Descripcion,
                Millas_Necesarias = a.Puntos
            });

            #endregion

            dgvProductos.DataSource = bind.ToList();
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LimpiarDataGridView()
        {
            dgvProductos.DataSource = null;
            dgvProductos.Columns.Clear();
        }
    }
}
