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
    public partial class ABMAltaButacas : Form
    {
        public Aeronave aeronave { get; set; }
        public SqlTransaction transaccionConcurrente;
        public bool accionTerminada = false;
        public int ult = 0;
        public Aeronave aeronaveReemplazo { get; set; }
        public int cantMaxP = 0;
        public int cantMaxV = 0;

        public ABMAltaButacas(Aeronave aeronaveIncompleta, SqlTransaction transaccion, bool modifica, Aeronave aeronaveAReemplazar)
        {
            InitializeComponent();
            aeronave = aeronaveIncompleta;
            transaccionConcurrente = transaccion;

            if (modifica)
            {
                ult = ButacaPersistencia.ObtenerMaxNroButaca(aeronave, transaccionConcurrente);
            }
            if (aeronaveAReemplazar != null)
            {
                aeronaveReemplazo = aeronaveAReemplazar;
                cantMaxP = ButacaPersistencia.ObtenerCantButacasPorAeronave(aeronaveAReemplazar, "Pasillo",transaccionConcurrente);
                cantMaxV = ButacaPersistencia.ObtenerCantButacasPorAeronave(aeronaveAReemplazar, "Ventanilla",transaccionConcurrente);
                TxtPasillo.Text = cantMaxP.ToString();
                TxtVentanilla.Text = cantMaxV.ToString();
            }
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones

                var exceptionMessage = string.Empty;

                //Alta aeronave (no se permiten valores en cero)
                if (ult == 0)
                {
                    if (string.IsNullOrEmpty(TxtPasillo.Text))
                        exceptionMessage += "La cantidad de pasillo no puede ser vacia.\n";

                    else if (!ValidadorDeTipos.IsNumeric(TxtPasillo.Text))
                        exceptionMessage += "El valor de pasillo no es valido, debe ser un numero entero.\n";

                    else if (Convert.ToInt32(TxtPasillo.Text) <= 0)
                        exceptionMessage += "El valor de pasillo debe ser mayor a cero.\n";

                    if (string.IsNullOrEmpty(TxtVentanilla.Text))
                        exceptionMessage += "La cantidad de ventanilla no puede ser vacia.\n";

                    else if (!ValidadorDeTipos.IsNumeric(TxtVentanilla.Text))
                        exceptionMessage += "El valor de ventanilla no es valido, debe ser un numero entero.\n";

                    else if (Convert.ToInt32(TxtVentanilla.Text) <= 0)
                        exceptionMessage += "El valor de ventanilla debe ser mayor a cero.\n";
                }
                //modificacion aeronave (se permite algun valor en cero)
                else 
                {
                    if (string.IsNullOrEmpty(TxtPasillo.Text))
                        exceptionMessage += "La cantidad de pasillo no puede ser vacia. Si no desea agregar, ingrese cero.\n";

                    else if (!ValidadorDeTipos.IsNumeric(TxtPasillo.Text))
                        exceptionMessage += "El valor de pasillo no es valido, debe ser un numero entero.\n";

                    else if (Convert.ToInt32(TxtPasillo.Text) < 0)
                        exceptionMessage += "El valor de pasillo debe ser mayor o igual a cero.\n";

                    if (string.IsNullOrEmpty(TxtVentanilla.Text))
                        exceptionMessage += "La cantidad de ventanilla no puede ser vacia. Si no desea agregar, ingrese cero\n";

                    else if (!ValidadorDeTipos.IsNumeric(TxtVentanilla.Text))
                        exceptionMessage += "El valor de ventanilla no es valido, debe ser un numero entero.\n";

                    else if (Convert.ToInt32(TxtVentanilla.Text) < 0)
                        exceptionMessage += "El valor de ventanilla debe ser mayor o igual a cero.\n";
                }

                if (aeronaveReemplazo != null)
                {
                    if (Convert.ToInt32(TxtPasillo.Text) < cantMaxP)
                    {
                        exceptionMessage += "Los valores de pasillo no pueden superar a los de la aeronave que estoy reemplazando.\n";
                        TxtPasillo.Text = cantMaxP.ToString();
                    }

                    if (Convert.ToInt32(TxtVentanilla.Text) < cantMaxV)
                    {
                        exceptionMessage += "Los valores de ventanilla no pueden superar a los de la aeronave que estoy reemplazando.\n";
                        TxtVentanilla.Text = cantMaxV.ToString();
                    }
                }

                if (!string.IsNullOrEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                if (Convert.ToInt32(TxtPasillo.Text) == 0 && Convert.ToInt32(TxtVentanilla.Text) == 0)
                {
                    accionTerminada = true;
                    Close();
                    return;
                }

                    if (aeronave != null)
                    {
                        //Alta aeronave
                        if (ult == 0)
                        {
                            #region Inserto las butacas de pasillo

                            var cantPasillo = Convert.ToInt32(TxtPasillo.Text);
                            for (int i = 0; i < cantPasillo; i++)
                            {
                                var pasillo = new Butaca();
                                pasillo.Numero = i;
                                pasillo.ID_Tipo = ButacaPersistencia.ObtenerIdTipoPorDescripcion("Pasillo", transaccionConcurrente).ID_Tipo;
                                pasillo.ID_Aeronave = aeronave.ID;

                                ButacaPersistencia.InsertarButaca(pasillo, transaccionConcurrente);
                            }
                            #endregion

                            #region Inserto las butacas de ventanilla

                            var cantVentanilla = Convert.ToInt32(TxtVentanilla.Text);
                            for (int i = cantPasillo ; i < cantPasillo + cantVentanilla; i++)
                            {
                                var ventanilla = new Butaca();
                                ventanilla.Numero = i;
                                ventanilla.ID_Tipo = ButacaPersistencia.ObtenerIdTipoPorDescripcion("Ventanilla", transaccionConcurrente).ID_Tipo;
                                ventanilla.ID_Aeronave = aeronave.ID;

                                ButacaPersistencia.InsertarButaca(ventanilla, transaccionConcurrente);
                            }
                            #endregion

                            accionTerminada = true;
                            Close();
                        }
                        else
                        {
                            //Modificacion aeronave
                            #region Inserto las butacas de pasillo
                            int i;
                            var cantPasillo = Convert.ToInt32(TxtPasillo.Text);
                            for (i = ult+1 ; i <= cantPasillo+ult; i++)
                            {
                                var pasillo = new Butaca();
                                pasillo.Numero = i;
                                pasillo.ID_Tipo = ButacaPersistencia.ObtenerIdTipoPorDescripcion("Pasillo", transaccionConcurrente).ID_Tipo;
                                pasillo.ID_Aeronave = aeronave.ID;

                                ButacaPersistencia.InsertarButaca(pasillo, transaccionConcurrente);
                            }
                            #endregion

                            #region Inserto las butacas de ventanilla

                            var cantVentanilla = Convert.ToInt32(TxtVentanilla.Text);
                            for (int j = i; j < i  + cantVentanilla; j++)
                            {
                                var ventanilla = new Butaca();
                                ventanilla.Numero = j;
                                ventanilla.ID_Tipo = ButacaPersistencia.ObtenerIdTipoPorDescripcion("Ventanilla", transaccionConcurrente).ID_Tipo;
                                ventanilla.ID_Aeronave = aeronave.ID;

                                ButacaPersistencia.InsertarButaca(ventanilla, transaccionConcurrente);
                            }
                            #endregion

                            MessageBox.Show("Butacas agregadas satisfactoriamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            accionTerminada = true;
                            Close();
                        }
                    }
                    else if (ult == 0)
                    {
                        AeronavePersistencia.eliminarAeronave(aeronave,transaccionConcurrente);
                        exceptionMessage += "Hubo un error al agregar las butacas, no se pudo insertar la aeronave\n";
                        accionTerminada = false;
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atención");
                }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                if (ult == 0)
                {
                    AeronavePersistencia.eliminarAeronave(aeronave,transaccionConcurrente);
                    accionTerminada = false;
                    Close();
                }
                Close();
            }  
        }
    }
}
