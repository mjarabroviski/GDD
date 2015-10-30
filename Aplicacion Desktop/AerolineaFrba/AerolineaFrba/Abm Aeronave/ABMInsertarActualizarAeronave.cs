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

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class ABMInsertarActualizarAeronave : Form
    {
        public Aeronave aeronaveAModificar { get; set; }
        public Aeronave aeronaveAReemplazar { get; set; }
        public Aeronave aeronaveNueva { get; set; }
        public bool accionTerminada = false;
        public bool modoInsertarComun = false;

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

        private void ABMInsertarActualizarAeronave_Load(object sender, EventArgs e)
        {
            #region Cargar Servicios
            //Carga el combobox de servicios
            CboServicio.DataSource = ServicioPersistencia.ObtenerTodos();
            CboServicio.ValueMember = "ID_Servicio";
            CboServicio.DisplayMember = "Nombre";
            #endregion

            //Es una modificacion
            if (aeronaveAModificar != null) {
                #region Cargo los datos de la aeronave

                TxtMatricula.Text = aeronaveAModificar.Matricula;
                TxtModelo.Text = aeronaveAModificar.Modelo;
                TxtFabricante.Text = aeronaveAModificar.Fabricante;
                TxtKG.Text = aeronaveAModificar.KG_Totales.ToString();
                DtpFechaAlta.Text = aeronaveAModificar.Fecha_Alta.ToString();
                #endregion
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
                        exceptionMessage += "De ingresar un valo numerico entero para la cantidad de KG.\n";

                    if (string.IsNullOrEmpty(DtpFechaAlta.Text))
                        exceptionMessage += "La fecha de alta no puede ser vacia.\n";

                    if (!string.IsNullOrEmpty(exceptionMessage))
                        throw new Exception(exceptionMessage);

                    #endregion

                    if (modoInsertarComun || aeronaveAReemplazar != null)
                    {
                            //Valido que no se dupliquen las matriculas
                            Aeronave a = AeronavePersistencia.ObtenerPorMatricula(TxtMatricula.Text, transaccion);
                            if (a != null)
                                throw new Exception("Ya existe una aeronave con la matricula ingresada.");

                            //Valido que la fecha de alta sea mayor o igual al dia de hoy
                            if (DtpFechaAlta.Value.Date >= DateTime.Today)
                                throw new Exception("La fecha ingresada no es válida.\n");

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

                            var butacas = new ABMAltaButacas(aeronaveNueva, transaccion);
                            butacas.ShowDialog();

                            if (butacas.accionTerminada)
                            {
                                transaccion.Commit();
                                MessageBox.Show("Aeronave insertada satisfactoriamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                if (aeronaveAReemplazar != null)
                                {
                                    //ASIGNAR LOS VIAJES DE LA AERONAVE A REEMPLAZAR A LA NUEVA
                                    accionTerminada = true;
                                }
                                Close();
                            }
                            else transaccion.Rollback();
                    }
                    else
                    {
                        //var cantViajes = AeronavePersistencia.ObtenerViajesPorAeronave(aeronaveAModificar);
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
