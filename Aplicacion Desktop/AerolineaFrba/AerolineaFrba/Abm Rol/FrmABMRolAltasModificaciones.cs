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

        public Rol CurrentRole { get; set; }

        public bool AccionCompleta = false;

        public FrmABMRolAltasModificaciones(Rol rol)
        {
            InitializeComponent();

            //Si no se le pasa ningún rol por parámetro (NULL) se considera que esta trabajando en modo alta
            modoModificacion = rol == null;

            if (!modoModificacion)
                CurrentRole = rol;

        }

        private void FrmABMRolAltasModificaciones_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                Close();
            }
        }
    }
}
