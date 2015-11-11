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

namespace AerolineaFrba.Abm_Rol
{
    public partial class FrmABMRolAltasModificaciones : Form
    {
        public bool modoModificacion { get; set; }

        public Rol RolActual { get; set; }

        public bool AccionCompleta = false;

        public FrmABMRolAltasModificaciones(Rol rol)
        {
            InitializeComponent();

            //Si no se le pasa ningún rol por parámetro (NULL) se considera que esta trabajando en modo alta
            modoModificacion = !(rol == null);

            if (modoModificacion)
                RolActual = rol;

        }

        private void FrmABMRolAltasModificaciones_Load(object sender, EventArgs e)
        {
            this.Text = (!modoModificacion) ? string.Format("{0} - {1}", "AerolineaFrba", "Nuevo rol") : string.Format("{0} - {1}", "AerolineaFrba", "Modificar rol");

            //Obtengo todas las funcionalidades de la base de datos
            LstFuncionalidades.DataSource = FuncionalidadPersistencia.ObtenerTodas();
            LstFuncionalidades.ValueMember = "ID";
            LstFuncionalidades.DisplayMember = "Descripcion";

            ChkInhabilitado.Checked = false;

            if (modoModificacion)
            {
                //Esta trabajando en modo modificación
                TxtRol.Text = RolActual.Descripcion;
                ChkInhabilitado.Checked = !(RolActual.Habilitado);

                //Obtengo la lista de funcionalidades a partir del rol recibido por parametro
                var featuresRol = FuncionalidadPersistencia.ObtenerPorRol(RolActual);

                //Marco como chequeados unicamente las funcionalidades del rol
                for (int j = 0; j < LstFuncionalidades.Items.Count; j++)
                {
                    var checkboxListItem = (Funcionalidad)LstFuncionalidades.Items[j];

                    if (featuresRol.Any(p => p.Descripcion == checkboxListItem.Descripcion))
                        LstFuncionalidades.SetItemChecked(j, true);
                    else
                        LstFuncionalidades.SetItemChecked(j, false);
                }
                if (RolActual.Habilitado) ChkInhabilitado.Enabled = false;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                Close();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e) 
        {
            try
            {
                #region Validations

                var exceptionMessage = string.Empty;

                if (string.IsNullOrEmpty(TxtRol.Text))
                    exceptionMessage += "El nombre del rol no puede ser vacío.";

                if (LstFuncionalidades.CheckedItems.Count == 0)
                    exceptionMessage += Environment.NewLine + "Debe seleccionar por lo menos una funcionalidad.";

                if (!string.IsNullOrEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                if (!modoModificacion)
                {
                    //Valido que no exista un rol con la descripcion informada
                    if (RolPersistencia.ObtenerRolPorNombre(TxtRol.Text) != null)
                        throw new Exception("Ya existe un rol con el nombre ingresado.");

                    #region Inserto el rol con sus funcionalidades

                    var rol = new Rol();
                    rol.Habilitado = !(ChkInhabilitado.Checked);
                    rol.Descripcion = TxtRol.Text;

                    //A partir de los items chequeados, seteo las funcionalidades del objeto a insertar
                    foreach (var checkedItem in LstFuncionalidades.CheckedItems)
                    {
                        var funcionalidad = (Funcionalidad)checkedItem;
                        rol.Funcionalidades.Add(funcionalidad);
                    }

                    var dialogAnswer = MessageBox.Show("Esta seguro que quiere insertar el nuevo rol?", "Atencion", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        //Impacto en la base
                        RolPersistencia.InsertarRolYFucionalidades(rol);
                        AccionCompleta = true;
                        Close();
                    }

                    #endregion
                }
                else
                {
                    #region Modifico un rol existente y sus funcionalidades

                    RolActual.Habilitado = !(ChkInhabilitado.Checked);
                    RolActual.Descripcion = TxtRol.Text;
                    RolActual.Funcionalidades = new List<Funcionalidad>();

                    //A partir de los items chequeados, seteo las funcionalidades del objeto a insertar
                    foreach (var checkedItem in LstFuncionalidades.CheckedItems)
                    {
                        var feature = (Funcionalidad)checkedItem;
                        RolActual.Funcionalidades.Add(feature);
                    }

                    var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que quiere modificar el rol {0}?", RolActual.Descripcion), "Atencion", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        //Impacto en la base
                        RolPersistencia.ModificarRolYFuncionalidades(RolActual);
                        AccionCompleta = true;
                        Close();
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }


    }
}
