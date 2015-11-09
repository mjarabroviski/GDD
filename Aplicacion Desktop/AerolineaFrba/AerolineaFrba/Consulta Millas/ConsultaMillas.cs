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

            #region Cargar Tipos de Docuementos

            //Carga el combobox de los tipos de documentos
            cboTipoDoc.DataSource = TipoDocumentoPersistencia.ObtenerTodos();
            cboTipoDoc.ValueMember = "ID_Tipo_Documento";
            cboTipoDoc.DisplayMember = "Descripcion";

            #endregion
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

        private void LblBuscar_Click(object sender, EventArgs e)
        {
            int doc = Convert.ToInt32(TxtDni.Text);
            int tipo = Convert.ToInt32(cboTipoDoc.SelectedValue);
            Cliente cliente = ClientePersistencia.ObtenerClientePorDNI(doc,tipo);
        }
    }
}
