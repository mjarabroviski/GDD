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
        public Butaca butacaSeleccionada { get; set; }

        public ABMButacas(Aeronave aeronaveAModificar, SqlTransaction transaccion)
        {
            InitializeComponent();
            aeronave = aeronaveAModificar;
            transaccionConcurrente = transaccion;
        }

        private void ABMButacas_Load(object sender, EventArgs e)
        {
            #region Cargar Tipos

            //Carga el combobox de tipos
            CboTipo.DataSource = TipoButacaPersistencia.ObtenerTodos(transaccionConcurrente);
            CboTipo.DisplayMember = "Descripcion";
            CboTipo.ValueMember = "ID";
            
            #endregion

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
            //Vaciar grilla y limpiar 
            Limpiar();
            ActualizarPantalla(null);
            CboTipo.Enabled = false;
            BtnGrabar.Enabled = false;
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
                Tipo = TipoButacaPersistencia.ObtenerTipoPorButaca(a, transaccionConcurrente).Descripcion,
                Habilitado = a.Habilitado
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

            //Creo la columna de baja 
            var columnaBaja = new DataGridViewButtonColumn
            {
                Text = "Baja Butaca",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };

            //Agrego las columnas nuevas
            DgvButacas.Columns.Add(columnaActualizar);
            DgvButacas.Columns.Add(columnaBaja);
        }

        private void DgvButacas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int cant = 0;
            //Solo funciona cuando el usuario hace click en los botones de la columnas
            if (e.RowIndex == -1 || e.ColumnIndex >= 0 && e.ColumnIndex < 3)
                return;

            butacaSeleccionada = ListaButacas.Find(butaca => butaca.Numero == Convert.ToInt32(DgvButacas.Rows[e.RowIndex].Cells[0].Value));

            if (butacaSeleccionada != null)
            {
                //El usuario tocó el botón de modificar
                if (e.ColumnIndex == 3)
                {
                    CboTipo.Enabled = true;
                    CboTipo.SelectedValue = butacaSeleccionada.ID_Tipo;
                    BtnGrabar.Enabled = true;                  
                }
                //El usuario tocó el botón de baja
                else if (e.ColumnIndex == 4)
                {
                    CboTipo.SelectedValue = butacaSeleccionada.ID_Tipo;
                    var dialogAnswer = MessageBox.Show("Esta seguro que desea dar de baja la butaca?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        cant = ButacaPersistencia.DarDeBajaButaca(butacaSeleccionada, transaccionConcurrente);
                        if (cant != -1)
                        {
                            MessageBox.Show("La butaca fue dada de baja satisfactoriamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            ActualizarPantalla(null);
                        }
                        else
                        {
                            MessageBox.Show("La butaca no pudo darse de baja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            int cant = 0;
            butacaSeleccionada.ID_Tipo = TipoButacaPersistencia.ObtenerTipoPorDescripcion(CboTipo.Text,transaccionConcurrente).ID;
            var dialogAnswer = MessageBox.Show("Esta seguro que desea modificar la butaca?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogAnswer == DialogResult.Yes)
            {
                cant = ButacaPersistencia.ModificarButaca(butacaSeleccionada,transaccionConcurrente);
                if (cant != -1)
                {
                    MessageBox.Show("La butaca fue modificada satisfactoriamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    BtnGrabar.Enabled = false;
                    CboTipo.Enabled = false;
                    ActualizarPantalla(null);
                }
                else
                {
                    MessageBox.Show("La butaca no fue modificada satisfactoriamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BtnGrabar.Enabled = false;
                    CboTipo.Enabled = false;
                }
            }
        }

        private void BtnAgregarButacas_Click(object sender, EventArgs e)
        {
            var alta = new ABMAltaButacas(aeronave, transaccionConcurrente, true, null);
            alta.ShowDialog();

            if (alta.accionTerminada)
            {
                accionTerminada = true;
                Limpiar();
                ActualizarPantalla(null);
            }

        }
    }
}
