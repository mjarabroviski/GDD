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

namespace AerolineaFrba.Abm_Rol
{
    public partial class FrmABMRol : Form
    {
        private List<Rol> _roles = new List<Rol>();

        public FrmABMRol()
        {
            InitializeComponent();
        }

        private void BtnListo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmABMRolAltasModificaciones frmABMRolAM = new FrmABMRolAltasModificaciones(null);
            frmABMRolAM.ShowDialog();

            //Paso NULL para volver a obtener todos los registros de la base
            ActualizarPantalla(null);
        }

        private void ActualizarPantalla(List<Rol> roles)
        {
            //Borro lo que esta actualmente en la grilla
            BorrarDataGridView();
            var rolesDictionary = new Dictionary<int, Rol>();

            #region Obtengo el diccionario de roles

            //El datasource debe ser todos los registros de roles almacenados en la base de datos
            if (roles == null)
            {
                BorrarFiltrosUI();
                _roles = RolPersistencia.ObtenerTodos();
                LstFuncionalidades.DataSource = _roles[0].Funcionalidades;
                //Convierto todos los roles a un diccionario con entradas de la forma: (ID, Objeto)
                rolesDictionary = _roles.ToDictionary(a => a.ID, a => a);
            }
            else
            {
                //El datasource debe ser una lista de roles obtenidas por parametro
                LstFuncionalidades.DataSource = roles[0].Funcionalidades;
                //Convierto la lista de roles a un diccionario con entradas de la forma: (ID, Objeto)
                rolesDictionary = roles.ToDictionary(a => a.ID, a => a);
            }

            #endregion

            //Creo un bind para luego setearselo directamente a la DataGridView
            var bind = rolesDictionary.Values.Select(a => new
            {
                Descripcion = a.Descripcion,
                Habilitado = a.Habilitado
            });
            DgvRol.DataSource = bind.ToList();

            //Agrego los botones a cada fila para poder modificar/borrar cada rol
            AgregarBotonesColumnas();

            LstFuncionalidades.DisplayMember = "Descripcion";
            LstFuncionalidades.ValueMember = "ID";
        }

        private void BorrarDataGridView()
        {
            DgvRol.DataSource = null;
            DgvRol.Columns.Clear();
        }

        private void BorrarFiltrosUI()
        {
            TxtDescripcion.Text = string.Empty;
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
            DgvRol.Columns.Add(updateColumn);
            DgvRol.Columns.Add(deleteColumn);
        }

        private void LstFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validations

                var exceptionMessage = string.Empty;

                if (ValidadorDeTipos.IsEmpty(TxtDescripcion.Text))
                    exceptionMessage = "No se puede realizar la busqueda ya que no se informó ningún filtro";

                if (!ValidadorDeTipos.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                List<Rol> roles = null;

                if (ChkExacta.Checked)
                {
                    //Se va a realizar una busqueda exacta (=)
                   var rol = RolPersistencia.ObtenerRolPorNombre(TxtDescripcion.Text);
                    if (rol != null)
                        roles = new List<Rol> { rol };
                }
                else
                {
                    //Se va a realizar una busqueda inexacta (LIKE)
                    roles = RolPersistencia.ObtenerRolPorNombreComo(TxtDescripcion.Text);
                }

                if (roles == null || roles.Count == 0)
                    throw new Exception("No se encontraron roles según los filtros informados.");

                //Recargo los valores de la grilla a partir de los resultados obtenidos en la busqueda
                ActualizarPantalla(roles);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void FrmABMRol_Load(object sender, EventArgs e)  
        {
            ActualizarPantalla(null);
        }

        private void BtnLimpiar_Click_1(object sender, EventArgs e)
        {
            TxtDescripcion.Text = string.Empty;
            ChkExacta.Checked = false;
            ActualizarPantalla(null);
        }


        private void DgvRol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Funciona solo cuando el usuario hace click en una fila (no en la cabecera)
            if (e.RowIndex == -1)
                return;

            //Obtengo el rol correspondiente a la fila seleccionada a partir del ID (primer columna de la fila)
            var rolSeleccionado = _roles.Find(r => r.Descripcion == (string)DgvRol.Rows[e.RowIndex].Cells[0].Value);

            if (rolSeleccionado != null)
            {
                //Cargo la lista de funcionalidades del rol
                LstFuncionalidades.DataSource = rolSeleccionado.Funcionalidades;

                //El usuario tocó el botón de modificar
                if (e.ColumnIndex == 2)
                {
                    var altasModificacionesVisibilidad = new FrmABMRolAltasModificaciones(rolSeleccionado);
                    altasModificacionesVisibilidad.ShowDialog();

                    //Si modificó satisfactoriamante el rol, actualizo la grilla
                    if (altasModificacionesVisibilidad.AccionCompleta)
                        ActualizarPantalla(null);
                }
                else if (e.ColumnIndex == 3)
                {
                    //El usuario tocó el botón de inhabilitar

                    //El rol seleccionado ya se encuentra eliminado (baja lógica)
                    if (!rolSeleccionado.Habilitado)
                    {
                        MessageBox.Show("No se puede eliminar la funcionalidad ya que ya se encuentra desactivada", "Atencion");
                        return;
                    }

                    //Esta tratando de eliminar el rol administrador (no lo permito)
                    if (rolSeleccionado.Descripcion == "Administrador")
                    {
                        MessageBox.Show("No se puede eliminar el rol administrador", "Atencion");
                        return;
                    }

                    var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que quiere desactivar el rol {0}?", rolSeleccionado.Descripcion), "Atención", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        //Defino que ya no este más activo el rol e impacto en la base de datos
                        rolSeleccionado.Habilitado = false;
                        RolPersistencia.Actualizar(rolSeleccionado, null);

                        //Vuelvo a cargar la lista de roles
                        ActualizarPantalla(null);
                    }
                }
            }
        }
         

    }
}
