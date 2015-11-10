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
    public partial class DevolucionPasaje : Form
    {
        public DevolucionPasaje()
        {
            InitializeComponent();
        }

        private void DevolucionPasaje_Load(object sender, EventArgs e)
        {
            ActualizarPantalla(null);
        }

        private void ActualizarPantalla(List<Pasaje> pasajes)
        {
            var diccionarioDePasajes = new Dictionary<int, Pasaje>();

            #region Cargar el diccionario a mostrar en la grilla

            if (pasajes == null)
            {

            }
            else
            {
                //El datasource se carga con la lista de pasajes recibida por parámetro
                diccionarioDePasajes = pasajes.ToDictionary(p => p.ID, p => p);
            }

            //Muestra en la grilla el contenido de los pasajes que se encuentran cargados en el diccionario
            var bind = diccionarioDePasajes.Values.Select(p => new
            {
                Codigo_Pasaje = p.Codigo_Pasaje,
                Pasajero = p.ID_Cliente,
                Numero_Butaca = p.ID_Butaca,
                Precio = p.Precio
            });

            #endregion

            DgvPasaje.DataSource = bind.ToList();
            AgregarBotonesDeColumnas();

            DgvPasaje.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
            DgvPasaje.Columns.Add(columnaDevolucion);
        }

    }
}
