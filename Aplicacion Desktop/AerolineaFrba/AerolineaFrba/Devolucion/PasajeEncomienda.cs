using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herramientas;
using Persistencia;

namespace AerolineaFrba.Devolucion
{
    public partial class PasajeEncomienda : Form
    {
        public PasajeEncomienda()
        {
            InitializeComponent();
        }
        private void Btn_Cancelar_Click_1(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                Close();
            }
        }

        private void Btn_DevEncomienda_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Txt_Dni.Text != string.Empty || (ValidadorDeTipos.IsNumeric(Txt_Dni.Text)) || Txt_Dni.Text.Count() < 8)
                {

                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

    }
}
