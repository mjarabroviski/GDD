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

        public ABMAltaButacas(Aeronave aeronaveIncompleta, SqlTransaction transaccion)
        {
            InitializeComponent();
            aeronave = aeronaveIncompleta;
            transaccionConcurrente = transaccion;
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            
                try
                {
                    #region Validaciones

                    var exceptionMessage = string.Empty;

                    if (string.IsNullOrEmpty(TxtPasillo.Text))
                        exceptionMessage += "La cantidad de pasillo no puede ser vacia, si no desea tener este tipo de butacas ingrese cero.\n";

                    else if (!ValidadorDeTipos.IsNumeric(TxtPasillo.Text))
                        exceptionMessage += "El valor de pasillo no es valido, debe ser un numero entero.\n";

                    if (string.IsNullOrEmpty(TxtVentanilla.Text))
                        exceptionMessage += "La cantidad de ventanilla no puede ser vacia, si no desea tener este tipo de butacas ingrese cero.\n";

                    else if (!ValidadorDeTipos.IsNumeric(TxtVentanilla.Text))
                        exceptionMessage += "El valor de ventanilla no es valido, debe ser un numero entero.\n";

                    if (!string.IsNullOrEmpty(exceptionMessage))
                        throw new Exception(exceptionMessage);

                    #endregion

                    if (aeronave != null)
                    {
                        #region Inserto las butacas de pasillo
                        var cantPasillo = Convert.ToInt32(TxtPasillo.Text);

                        for (int i = 1; i <= cantPasillo; i++)
                        {      
                                var pasillo = new Butaca();
                                pasillo.Numero = i;
                                pasillo.ID_Tipo = ButacaPersistencia.ObtenerIdTipoPorDescripcion("Pasillo", transaccionConcurrente).ID_Tipo;
                                pasillo.ID_Aeronave = aeronave.ID;

                                ButacaPersistencia.InsertarButaca(pasillo,transaccionConcurrente); 
                        }
                        #endregion

                        MessageBox.Show("Butacas agregadas satisfactoriamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        accionTerminada = true;
                        Close();
                    }
                    else
                    {
                        exceptionMessage += "Hubo un error al agregar las butacas\n";
                        this.Hide();
                        var aero = new ABMAeronaves();
                        aero.ShowDialog();
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
                var aero = new ABMAeronaves();
                aero.ShowDialog();
                Close();
            }  
        }
    }
}
