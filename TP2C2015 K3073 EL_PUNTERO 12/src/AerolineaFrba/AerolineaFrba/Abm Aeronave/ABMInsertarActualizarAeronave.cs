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
using Configuracion;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class ABMInsertarActualizarAeronave : Form
    {
        public Aeronave aeronaveAModificar { get; set; }
        public Aeronave aeronaveAReemplazar { get; set; }
        public Aeronave aeronaveNueva { get; set; }
        public bool accionTerminada = false;
        public bool modoInsertarComun = false;
        public DateTime FechaComienzo = DateTime.MinValue;
        public DateTime FechaReinicio = DateTime.MinValue;

        public ABMInsertarActualizarAeronave(Aeronave aeronave, Boolean modificar)
        {
            InitializeComponent();

            if (aeronave == null) modoInsertarComun = true;
            else
            {
                if (modificar) aeronaveAModificar = aeronave;
                else aeronaveAReemplazar = aeronave;
            }     
        }

        public ABMInsertarActualizarAeronave(Aeronave aeronave,DateTime comienzo,DateTime fin)
        {
            InitializeComponent();

            aeronaveAReemplazar = aeronave;
            FechaComienzo = comienzo;
            FechaReinicio = fin;          
        }

        private void ABMInsertarActualizarAeronave_Load(object sender, EventArgs e)
        {
            #region Cargar Servicios
            //Carga el combobox de servicios
            CboServicio.DataSource = ServicioPersistencia.ObtenerTodos();
            CboServicio.ValueMember = "ID_Servicio";
            CboServicio.DisplayMember = "Nombre";
            #endregion

            //Es una modificacion
            if (aeronaveAModificar != null && FechaComienzo == DateTime.MinValue) {
                #region Cargo los datos de la aeronave

                TxtMatricula.Text = aeronaveAModificar.Matricula;
                TxtModelo.Text = aeronaveAModificar.Modelo;
                TxtFabricante.Text = aeronaveAModificar.Fabricante;
                TxtKG.Text = aeronaveAModificar.KG_Totales.ToString();
                DtpFechaAlta.Text = aeronaveAModificar.Fecha_Alta.ToString();
                CboServicio.SelectedValue = aeronaveAModificar.ID_Servicio;

                DtpFechaAlta.Enabled = false;
                #endregion
            }

            if (aeronaveAReemplazar != null)
            {
                TxtFabricante.Text = aeronaveAReemplazar.Fabricante;
                TxtModelo.Text = aeronaveAReemplazar.Modelo;
                CboServicio.Text = ServicioPersistencia.ObtenerServicioPorNombre(CboServicio.Text, null).Nombre;
                TxtKG.Text = aeronaveAReemplazar.KG_Totales.ToString();

                TxtModelo.Enabled = false;
                TxtFabricante.Enabled = false;
                DtpFechaAlta.Enabled = false;
                CboServicio.Enabled = false;
            }

        }

        private void LblSiguiente_Click(object sender, EventArgs e)
        {
          using (var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    #region ValidacionesEnGral

                    var exceptionMessage = string.Empty;

                    if (string.IsNullOrEmpty(TxtMatricula.Text))
                        exceptionMessage += "La matricula no puede ser vacia.\n";

                    else if (!ValidadorDeTipos.IsMatriculaValida(TxtMatricula.Text))
                        exceptionMessage += "La matricula no es valida.\n";

                    if (string.IsNullOrEmpty(TxtFabricante.Text))
                        exceptionMessage += "El fabricante no puede ser vacío.\n";

                    if (string.IsNullOrEmpty(CboServicio.Text))
                        exceptionMessage += "El tipo de servicio no puede ser vacío.\n";

                    if (string.IsNullOrEmpty(TxtModelo.Text))
                        exceptionMessage += "El modelo no puede ser vacío.\n";

                    if (string.IsNullOrEmpty(TxtKG.Text))
                        exceptionMessage += "La cantidad de KG no puede ser vacia.\n";

                    else if (!ValidadorDeTipos.IsNumeric(TxtKG.Text))
                        exceptionMessage += "Debe ingresar un valor numerico entero para la cantidad de KG.\n";

                    else if (Convert.ToInt32(TxtKG.Text) <= 0)
                        exceptionMessage += "La cantidad de KG debe ser mayor a cero.\n";

                    if(aeronaveAReemplazar != null)
                    {
                        if (Convert.ToInt32(TxtKG.Text) < aeronaveAReemplazar.KG_Totales)
                        {
                            exceptionMessage += "La cantidad de KG debe ser igual o mayor a la de la aeronave a reemplazar.\n";
                            TxtKG.Text = aeronaveAReemplazar.KG_Totales.ToString();
                        }
                    }

                    if (string.IsNullOrEmpty(DtpFechaAlta.Text))
                        exceptionMessage += "La fecha de alta no puede ser vacia.\n";

                    if (!string.IsNullOrEmpty(exceptionMessage))
                        throw new Exception(exceptionMessage);

                    #endregion

                    //El usuario va a dar de alta una aeronave
                    if (modoInsertarComun || aeronaveAReemplazar != null)
                    {
                            //Valido que la fecha de alta sea menor al dia de hoy
                            if (DtpFechaAlta.Value.Date < ConfiguracionDeVariables.FechaSistema.Date)
                                throw new Exception("La fecha ingresada debe ser mayor a la actual.\n");

                            //Valido que no se dupliquen las matriculas
                            Aeronave a = AeronavePersistencia.ObtenerPorMatricula(TxtMatricula.Text, transaccion);
                            if (a != null)
                                 throw new Exception("Ya existe una aeronave con la matricula ingresada.");

                            #region Inserto la nueva aeronave

                            var aeronave = new Aeronave();
                            aeronave.Matricula = TxtMatricula.Text;
                            aeronave.Fabricante = TxtFabricante.Text;
                            aeronave.Modelo = TxtModelo.Text;
                            aeronave.ID_Servicio = ServicioPersistencia.ObtenerServicioPorNombre(CboServicio.Text,transaccion).ID_Servicio;
                            aeronave.Fecha_Alta = DtpFechaAlta.Value;
                            aeronave.KG_Totales = Convert.ToInt32(TxtKG.Text);

                            aeronaveNueva = AeronavePersistencia.InsertarAeronave(aeronave, transaccion);

                            #endregion

                            var butacas = new ABMAltaButacas(aeronaveNueva, transaccion, false, aeronaveAReemplazar);
                            butacas.ShowDialog();

                            if (butacas.accionTerminada)
                            {
                                transaccion.Commit();
                                MessageBox.Show("Aeronave insertada satisfactoriamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                if (aeronaveAReemplazar != null && FechaReinicio == DateTime.MinValue)
                                {
                                    //Asigna los viajes de la aeronave a dar de baja por fin de vida util a la nueva
                                    ViajePersistencia.ReemplazarViajesDePor(aeronaveAReemplazar,aeronaveNueva);
                                    accionTerminada = true;
                                }
                                if (FechaReinicio != DateTime.MinValue || FechaComienzo != DateTime.MinValue)
                                {
                                    //Asigna los viajes de la aeronave a dar de baja por fuera de servicio a la nueva
                                    ViajePersistencia.ReemplazarViajesDePorServicio(aeronaveAReemplazar, aeronaveNueva,FechaComienzo,FechaReinicio);
                                    accionTerminada = true;                                   
                                }
                                Close();
                            }
                            else
                            {
                                transaccion.Rollback();
                                MessageBox.Show("La Aeronave no fue insertada correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Close();
                            }
                    }
                    else if (aeronaveAModificar != null)
                    {
                        //Verifico que no modifique la matricula por otra que ya exista
                        Aeronave a = AeronavePersistencia.ObtenerPorMatricula(TxtMatricula.Text, transaccion);
                        if (a != null && a.ID != aeronaveAModificar.ID)
                            throw new Exception("Ya existe una aeronave con la matricula ingresada.");

                            #region Modifico la aeronave

                            aeronaveAModificar.Matricula = TxtMatricula.Text;
                            aeronaveAModificar.Fabricante = TxtFabricante.Text;
                            aeronaveAModificar.Modelo = TxtModelo.Text;
                            aeronaveAModificar.ID_Servicio = ServicioPersistencia.ObtenerServicioPorNombre(CboServicio.Text, transaccion).ID_Servicio;
                            aeronaveAModificar.Fecha_Alta = DtpFechaAlta.Value;
                            aeronaveAModificar.KG_Totales = Convert.ToInt32(TxtKG.Text);

                            AeronavePersistencia.ModificarAeronave(aeronaveAModificar, transaccion);

                            #endregion

                            var butacas = new ABMButacas(aeronaveAModificar, transaccion);
                            butacas.ShowDialog();

                            if (butacas.accionTerminada)
                            {
                                transaccion.Commit();
                                accionTerminada = true;
                                MessageBox.Show("Aeronave modificada satisfactoriamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Close();
                            }
                            else
                            {
                                transaccion.Rollback();
                                MessageBox.Show("La Aeronave no fue modificada correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Close();
                            }
                    }
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show(ex.Message, "Atención");
                }
          }
   }

        private void LblCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                Close();
            }   
        }
    }
}
