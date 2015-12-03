using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Devolucion
{
    public partial class MotivoDevolucion : Form
    {
        public string Motivo;
        public bool accionTerminada = false;

        public MotivoDevolucion()
        {
            InitializeComponent();
        }

        private void MotivoDevolucion_Load(object sender, EventArgs e)
        {
            Txt_Motivo.MaxLength = 100;
        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            if (Txt_Motivo.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un motivo para la devolucion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dialogAnswer = MessageBox.Show("Desea establecer como motivo de devolución el ingresado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult.Yes == dialogAnswer)
            {
                Motivo = Txt_Motivo.Text;
                accionTerminada = true;
                Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que desea cancelar la operacion?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult.Yes == dialogAnswer)
            {
                accionTerminada = false;
                Close();
            }
        }
    }
}
