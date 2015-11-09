using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Consulta_Millas
{
    public partial class ConsultaMillas : Form
    {
        public ConsultaMillas()
        {
            InitializeComponent();
        }

        private void ConsultaMillas_Load(object sender, EventArgs e)
        {
            TxtMillas.Enabled = false;
            LbLNac.Visible = false;
            dtpNac.Visible = false;
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarDataGridView();
        }

        private void LimpiarDataGridView()
        {
            dgvCompras.DataSource = null;
            dgvCompras.Columns.Clear();
            dgvCanjes.DataSource = null;
            dgvCanjes.Columns.Clear();
            TxtDni.Text = string.Empty;
        }

        private void LblListo_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
