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

namespace AerolineaFrba.Devolucion
{
    public partial class DevolucionEncomienda : Form
    {
        public DevolucionEncomienda()
        {
            InitializeComponent();
        }

        private void DevolucionEncomienda_Load(object sender, EventArgs e)
        {
            ActualizarPantalla(null);
        }

        private void ActualizarPantalla(List<Encomienda> encomienda)
        {
            var diccionarioDeEncimiendas = new Dictionary<int, Encomienda>();

            #region Cargar el diccionario a mostrar en la grilla

            if (encomienda == null)
            {

            }
            else
            {
                //El datasource se carga con la lista de pasajes recibida por parámetro
                diccionarioDeEncimiendas = encomienda.ToDictionary(e => e.ID, e => e);
            }

            //Muestra en la grilla el contenido de los pasajes que se encuentran cargados en el diccionario
            var bind = diccionarioDeEncimiendas.Values.Select(e => new
            {
                Codigo_Pasaje = e.Codigo_Encomienda,
                Numero_Butaca = e.KG,
                Precio = e.Precio
            });

            #endregion

            DgvEncomiendas.DataSource = bind.ToList();
            AgregarBotonesDeColumnas();

            DgvEncomiendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void AgregarBotonesDeColumnas()
        {
            //Creo la columna de realizar devolucion
            var columnaDevolucion = new DataGridViewButtonColumn
            {
                Text = "Realizar Devolucion",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };


            //Agrego las columnas nuevas
            DgvEncomiendas.Columns.Add(columnaDevolucion);
        }
    }
}

