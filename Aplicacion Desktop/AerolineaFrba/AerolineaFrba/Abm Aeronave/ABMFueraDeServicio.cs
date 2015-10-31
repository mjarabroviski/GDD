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
    public partial class ABMFueraDeServicio : Form
    {
        public Aeronave aeronaveAModificar { get; set; }
        public bool accionTerminada = false;

        public ABMFueraDeServicio(Aeronave aeronave)
        {
            InitializeComponent();
            aeronaveAModificar = aeronave;
        }

        private void ABMFueraDeServicio_Load(object sender, EventArgs e)
        {

        }
    }
}
