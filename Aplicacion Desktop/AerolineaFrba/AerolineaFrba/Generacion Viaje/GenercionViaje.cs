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
using AerolineaFrba.Home_Administrador;

namespace AerolineaFrba.Generacion_Viaje
{
    public partial class GenercionViaje : Form
    {
        public GenercionViaje()
        {
            InitializeComponent();
        }

        private void GenercionViaje_Load(object sender, EventArgs e)
        {
            CargarCbos();
            ActualizarFechas();
            ComenzarConCboVacios();
        }

        private void ComenzarConCboVacios()
        {
            CboTipoServicio.Text = "SERVICIO";
            CboAeronave.Text = "MATRICULA AERONAVE";
            CboCiudadOrigen.Text = "CIUDAD ORIGEN";
            CboCiudadDestino.Text = "CIUDAD DESTINO";
        }

        private void CargarCbos()
        {
             CboCiudadOrigen.DataSource = CiudadPersistencia.ObtenerTodos();
             CboCiudadOrigen.ValueMember = "ID";
             CboCiudadOrigen.DisplayMember = "Nombre";

             CboAeronave.DataSource = AeronavePersistencia.ObtenerAeronavesHabilitadas();
             CboAeronave.ValueMember = "ID";
             CboAeronave.DisplayMember = "Matricula";
        }

        private void ActualizarFechas()
        {
            DtpFechaSalida.MinDate = DateTime.Now;
            DtpFechaLlegadaEstimada.MinDate = DateTime.Now;
            DtpFechaLlegada.MinDate = DateTime.Now;

        }

        private void DtpFechaSalida_ValueChanged(object sender, EventArgs e)
        {
            DtpFechaLlegadaEstimada.MinDate = DtpFechaSalida.Value.Date;
            DtpFechaLlegada.MinDate = DtpFechaSalida.Value.Date;
            DtpFechaLlegadaEstimada.MaxDate = DtpFechaSalida.Value.Date.AddDays(1);
            DtpFechaLlegada.MaxDate = DtpFechaSalida.Value.Date.AddDays(1);

        }

        private void DtpFechaLlegadaEstimada_ValueChanged(object sender, EventArgs e)
        {
            DtpFechaLlegada.Value = DtpFechaLlegadaEstimada.Value;
        }

        private void CboCiudadOrigen_Click(object sender, EventArgs e)
        {
            if (CboCiudadOrigen.Text != "CIUDAD ORIGEN")
            {
                CboCiudadDestino.Text = "CIUDAD DESTINO";
                CboCiudadDestino.Enabled = false;
                CboTipoServicio.Text = "TIPO SERVICIO";
                CboTipoServicio.Enabled = false;
            }

        }

        private void Btn_Seleccionar_Click(object sender, EventArgs e)
        {
            if (CboCiudadOrigen.Text != "CIUDAD ORIGEN")
            {
                CboCiudadDestino.Enabled = true;
                int ID_Origen = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CboCiudadOrigen.Text);
                List<Ciudad> ciudadesConMismoOrigen = RutaPersistencia.ObtenerTodasLasCiudadesConOrigen(ID_Origen);

                CboCiudadDestino.DataSource = ciudadesConMismoOrigen;
                CboCiudadDestino.ValueMember = "ID";
                CboCiudadDestino.DisplayMember = "Nombre";
            }
        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            CargarCbos();
            ComenzarConCboVacios();
            CboCiudadDestino.Enabled = false;
            CboTipoServicio.Enabled = false;
            VolverFechasAlEstadoInicial();
            ActualizarFechas();
        }

        private void VolverFechasAlEstadoInicial(){
            DtpFechaSalida.Value = DateTime.Now;
            DtpFechaLlegadaEstimada.Value = DateTime.Now;
            DtpFechaLlegada.Value = DateTime.Now;
            DtpHoraSalida.Value = DateTime.Now;
            DtpHoraLlegadaEstimada.Value = DtpHoraSalida.Value;
            DtpHoraLlegada.Value = DtpHoraSalida.Value;
            DtpHoraLlegadaEstimada.Enabled = false;
            DtpFechaLlegadaEstimada.Enabled = false;
         }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                Hide();
                var home = new HomeAdministrador();
                home.ShowDialog();
                Close();
            }
        }
        
        private void Btn_GenerarViaje_Click(object sender, EventArgs e)
        {
            /*if (ValidarHorarioDeAeronave() == true)
            {*/
                DateTime Fecha_Salida = DateTime.ParseExact("2009-05-08 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff",
                                       System.Globalization.CultureInfo.InvariantCulture);
                DateTime Fecha_Llegada = DateTime.ParseExact("2009-05-08 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff",
                                       System.Globalization.CultureInfo.InvariantCulture);
                int ID_Origen = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CboCiudadOrigen.Text);
                int ID_Destino = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CboCiudadDestino.Text);
                int ID_Ruta = RutaPersistencia.ObtenerRutaPorOrigenYDestino(ID_Origen, ID_Destino).ID;
                //int ID_Aeronave = 
                //GenerarViaje();
           /* }*/

        }
        
        private void DtpHoraSalida_ValueChanged(object sender, EventArgs e)
        {
            DtpHoraLlegadaEstimada.MaxDate = DtpHoraSalida.Value;
            DtpHoraLlegadaEstimada.Enabled = true;
            DtpFechaLlegadaEstimada.Enabled = true;
        }

        private void ObtenerServiciosDisponibles()
        {
            int id_origen = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CboCiudadOrigen.Text);
            int id_destino = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CboCiudadDestino.Text);
            List<Servicio> serviciosDisponibles = ServicioPersistencia.ObtenerServiciosDeRuta(id_origen, id_destino, CboAeronave.Text);
            if (serviciosDisponibles.Count != 0)
            {
                CboTipoServicio.DataSource = serviciosDisponibles;
                CboTipoServicio.ValueMember = "ID_Servicio";
                CboTipoServicio.DisplayMember = "Nombre";
                if (CboAeronave.Text != "MATRICULA AERONAVE") CboTipoServicio.Enabled = true;
            }
            else
            {
                MessageBox.Show("Los datos ingresados no tienen servicios disponibles pruebe otra combincación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
         }

        private void Btn_SeleccionarCiudadDestino_Click(object sender, EventArgs e)
        {
            if(CboCiudadDestino.Text != "CIUDAD DESTINO"){
                ObtenerServiciosDisponibles();
            }
        }

        private void CboAeronave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboCiudadOrigen.Text != "CIUDAD ORIGEN" && CboCiudadDestino.Text != "CIUDAD DESTINO" && CboAeronave.Text != "MATRICULA AERONAVE")
            {
                ObtenerServiciosDisponibles();
            }
        }

    }
}
