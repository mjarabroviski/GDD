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


namespace AerolineaFrba.Registro_Llegada_Destino
{
    public partial class InformacionAeronave : Form
    {
        Aeronave aeronave;
        Viaje viaje;
        AerolineaFrba.Registro_Llegada_Destino.RegistroLlegadaDestino registro;

        public InformacionAeronave(Aeronave aeronave1, Viaje viaje1, AerolineaFrba.Registro_Llegada_Destino.RegistroLlegadaDestino form1)
        {
            InitializeComponent();
            aeronave = aeronave1;
            viaje = viaje1;
            registro = form1;
        }

        private void BtnAgregarFecha_Click(object sender, EventArgs e)
        {
            Hide();
            var agregarFecha = new AgregarFechaLlegada(aeronave,viaje, registro);
            agregarFecha.ShowDialog();
            Close();
         
        }

        private void Btn_Volver_Click_1(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que desea volver al formulario ?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                Close();
            }
        }

        private void InformacionAeronave_Load(object sender, EventArgs e)
        {
            #region completo los textbox
            if (aeronave.Baja_Vida_Util == true)Txt_BajaVidaUtil.Text = "SI";
            else Txt_BajaVidaUtil.Text = "NO";

            if (aeronave.Baja_Fuera_De_Servicio== true)Txt_BajaFuera.Text = "SI";
            else Txt_BajaFuera.Text = "NO";

            Txt_Fabricante.Text = aeronave.Fabricante;
            Txt_FechaAlta.Text = aeronave.Fecha_Alta.ToString();
            Txt_FechaBajaDef.Text = aeronave.Fecha_Baja_Fuera_Servicio.ToString();
            Txt_KG.Text = aeronave.KG_Totales.ToString();
            Txt_Matricula.Text = aeronave.Matricula;
            Txt_Modelo.Text = aeronave.Modelo; 
            Servicio serv = ServicioPersistencia.ObtenerServicioPorID(aeronave.ID_Servicio);
            Txt_TipoServicio.Text = serv.Nombre;
            #endregion

        }

        private void Txt_TipoServicio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
