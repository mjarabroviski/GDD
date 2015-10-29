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
using Filtros;

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class ABMInsertarActualizarCiudad : Form
    {
        public Ciudad ciudadAModificar { get; set; }
        public bool accionTerminada = false;
        public bool modoInsertar { get; set; }

        public ABMInsertarActualizarCiudad(Ciudad ciudad)
        {
            InitializeComponent();
            //Si no se le pasa ningún rol por parámetro (NULL) se considera que esta trabajando en modo alta
            modoInsertar = ciudad == null;

            if (!modoInsertar)
            {
                ciudadAModificar = ciudad;
            }
        }

        private void LblCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                Hide();
                ABMCiudades ciudades = new ABMCiudades();
                ciudades.ShowDialog();
                Close();
            }

        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            TxtNombreCiudad.Text = string.Empty;
        }

        private void LblGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones

                var excepcion = string.Empty;

                if (ValidadorDeTipos.IsEmpty(TxtNombreCiudad.Text))
                    excepcion = "El nombre ingresado no puede ser vacío.";

                if (!ValidadorDeTipos.IsEmpty(excepcion))
                    throw new Exception(excepcion);

                #endregion

                if (modoInsertar)
                {
                    var filters = new CiudadFiltros { Nombre = TxtNombreCiudad.Text };
                    //Valido que no exista una ciudad con la descripcion informada
                    if (CiudadPersistencia.ObtenerTodasPorParametro(filters).Count > 0)
                    {
                        throw new Exception("Ya existe una ciudad con la descripcion informada.");
                    }
                    #region Inserto la nueva ciudad

                    var ciudadNueva = new Ciudad();
                    ciudadNueva.Nombre = TxtNombreCiudad.Text;

                    var dialogAnswer = MessageBox.Show("Esta seguro que quiere insertar la nueva ciudad?", "Atencion", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        if (CiudadPersistencia.InsertarCiudad(ciudadNueva) == 1)
                        {
                            MessageBox.Show("Se inserto satisfactoriamente la nueva Ciudad", "Atencion");
                            accionTerminada = true;
                            Close();
                        }
                    }

                    #endregion
                }
                else
                {
                    #region Modifico una ciudad existente

                    ciudadAModificar.Nombre = TxtNombreCiudad.Text;
                    var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que quiere modificar la ciudad {0}?", ciudadAModificar.Nombre), "Atencion", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        //Modifico exitosamente si la cantidad de registros afectados es 1
                        if (CiudadPersistencia.ActualizarCiudad(ciudadAModificar) == 1)
                        {
                            MessageBox.Show("Se modifico satisfactoriamente la ciudad", "Atencion");
                            accionTerminada = true;
                            //Close();
                        }
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


            