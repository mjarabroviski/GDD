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
using AerolineaFrba.Home;
using System.Globalization;


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
            DtpHoraSalida.MinDate = DateTime.Now;
            DtpFechaLlegadaEstimada.MaxDate = DateTime.Now.AddDays(1);
            DtpFechaLlegada.MaxDate = DateTime.Now.AddDays(1);
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
            DtpHoraLlegadaEstimada.Value = DateTime.Now;
            DtpHoraLlegada.Value = DateTime.Now;
            DtpHoraLlegadaEstimada.Enabled = false;
            DtpFechaLlegadaEstimada.Enabled = false;
         }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                Close();
            }
        }
        
        private void Btn_GenerarViaje_Click(object sender, EventArgs e)
        {
            #region validacionesCmposCompletos
            #endregion

            //UNO LA FECHA CON LAS HORA      
            DateTime Fecha_Salida = new DateTime(DtpFechaSalida.Value.Year,DtpFechaSalida.Value.Month,DtpFechaSalida.Value.Day,
                                             DtpHoraSalida.Value.Hour,DtpHoraSalida.Value.Minute,DtpHoraSalida.Value.Second);
            DateTime Fecha_Llegada = new DateTime(DtpFechaLlegada.Value.Year, DtpFechaLlegada.Value.Month, DtpFechaLlegada.Value.Day,
                                             DtpHoraLlegada.Value.Hour, DtpHoraLlegada.Value.Minute, DtpHoraLlegada.Value.Second);
            DateTime Fecha_Llegada_Estimada = new DateTime(DtpFechaLlegadaEstimada.Value.Year, DtpFechaLlegadaEstimada.Value.Month, DtpFechaLlegadaEstimada.Value.Day,
                                             DtpHoraLlegadaEstimada.Value.Hour, DtpHoraLlegadaEstimada.Value.Minute, DtpHoraLlegadaEstimada.Value.Second);


            if (ValidarHorarioDeAeronave(Fecha_Salida, Fecha_Llegada_Estimada) == true)
            {

                int ID_Origen = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CboCiudadOrigen.Text);
                int ID_Destino = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CboCiudadDestino.Text);
                var rutas = RutaPersistencia.ObtenerRutaPorOrigenYDestino(ID_Origen, ID_Destino);
                int ID_Ruta = rutas[0].ID;

                var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable);
                int ID_Aeronave = AeronavePersistencia.ObtenerPorMatricula(CboAeronave.Text, transaccion).ID;
                transaccion.Commit();

                ViajePersistencia.GenerarViaje(Fecha_Llegada, Fecha_Salida, Fecha_Llegada_Estimada, ID_Ruta, ID_Aeronave);
                var dialogAnswer = MessageBox.Show("Esta seguro que desea generar el viaje?", "Atencion", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == dialogAnswer)
                {
                    var dialogAnswer2 = MessageBox.Show("Viaje generado satisfactoriamente", "Informacion", MessageBoxButtons.OK);
                    Close();
                }

            }
            else
            {
                var dialogAnswer = MessageBox.Show("La Aeronave se encuentra ocupada para las fechas seleccionada.", "Error", MessageBoxButtons.OK);
            }

            
        }

        private bool ValidarHorarioDeAeronave(DateTime fechaSalida, DateTime fechaLlegadaEstimada)
        {
            var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable);
            int ID_Aeronave = AeronavePersistencia.ObtenerPorMatricula(CboAeronave.Text, transaccion).ID;
            transaccion.Commit();
            return ViajePersistencia.ValidarHorarioDeAeronave(fechaSalida, fechaLlegadaEstimada,ID_Aeronave);
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
            else if (CboAeronave.Text == "MATRICULA AERONAVE")
            {
                MessageBox.Show("Ingrese la Matrícula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Los datos ingresados no tienen servicios disponibles pruebe otra combincación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
            }
         }


        private void CboAeronave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboCiudadOrigen.Text != "CIUDAD ORIGEN" && CboCiudadDestino.Text != "CIUDAD DESTINO" && CboAeronave.Text != "MATRICULA AERONAVE")
            {
                ObtenerServiciosDisponibles();
            }
        }


          private void DtpFechaSalida_ValueChanged_1(object sender, EventArgs e)
          {
              #region vuelvo a bloquear la fecha llegada estimada
              DtpHoraLlegadaEstimada.Enabled = false;
              DtpFechaLlegadaEstimada.Enabled = false;
              #endregion
              if (DtpHoraSalida.Value != DateTime.Now)
              {
                  String horaMinimo = "00:00:00";
                  DtpHoraSalida.MinDate = DateTime.ParseExact(horaMinimo, "HH:mm:ss", CultureInfo.InvariantCulture);
               }


          }


          private void Btn_OK_FS_Click(object sender, EventArgs e)
          {
              #region MAXIMOS Y MINIMOS DE FECHAS
              
              if (DtpFechaSalida.Value.Date.AddDays(1) <= DtpFechaLlegadaEstimada.MinDate)
              {
                  DtpFechaLlegadaEstimada.MinDate = DtpFechaSalida.Value.Date;
                  DtpFechaLlegada.MinDate = DtpFechaSalida.Value.Date;
                  DtpFechaLlegadaEstimada.MaxDate = DtpFechaSalida.Value.Date.AddDays(1);
                  DtpFechaLlegada.MaxDate = DtpFechaSalida.Value.Date.AddDays(1);
              }

              if ( DtpFechaSalida.Value.Date >= DtpFechaLlegadaEstimada.MaxDate)
              {
                  DtpFechaLlegadaEstimada.MaxDate = DtpFechaSalida.Value.Date.AddDays(1);
                  DtpFechaLlegada.MaxDate = DtpFechaSalida.Value.Date.AddDays(1);
                  DtpFechaLlegadaEstimada.MinDate = DtpFechaSalida.Value.Date;
                  DtpFechaLlegada.MinDate = DtpFechaSalida.Value.Date;
              }
              #endregion

              #region habilito fecha llegada estimada 
              actualizarFechaEstimada();
              DtpHoraLlegadaEstimada.Enabled = true;
              DtpFechaLlegadaEstimada.Enabled = true;
              #endregion


          }

          private void DtpHoraSalida_ValueChanged(object sender, EventArgs e)
          {
          }

          private void DtpHoraLlegadaEstimada_ValueChanged(object sender, EventArgs e)
          {
              actualizarFechaEstimada();
              DtpHoraLlegada.Value = DtpHoraLlegadaEstimada.Value;
          }

          private void DtpFechaLlegadaEstimada_ValueChanged_1(object sender, EventArgs e)
          {
              actualizarFechaEstimada();
              DtpFechaLlegada.Value = DtpFechaLlegadaEstimada.Value;
          }


          private void actualizarFechaEstimada()
          {
              if (DtpFechaSalida.Value.Day != DtpFechaLlegadaEstimada.Value.Day)
              {
                  DtpHoraLlegadaEstimada.MaxDate = DtpHoraSalida.Value;
                  String horaMinimo = "00:00:00";
                  DtpHoraLlegadaEstimada.MinDate = DateTime.ParseExact(horaMinimo, "HH:mm:ss", CultureInfo.InvariantCulture);


                  
              }
              else if (DtpFechaSalida.Value.Day == DtpFechaLlegadaEstimada.Value.Day)
              {
                  DtpHoraLlegadaEstimada.MinDate = DtpHoraSalida.Value.AddHours(1);
                  String horaMaximo ="23:59:59";
                  DtpHoraLlegadaEstimada.MaxDate = DateTime.ParseExact(horaMaximo, "HH:mm:ss", CultureInfo.InvariantCulture);
                  
              }
          }

          private void label8_Click(object sender, EventArgs e)
          {
              CboCiudadOrigen.Enabled = true;
          }

        private void Btn_SeleccionarCiudadDestino_Click_1(object sender, EventArgs e)
        {
            if(CboCiudadDestino.Text != "CIUDAD DESTINO"){
                ObtenerServiciosDisponibles();
                DtpFechaSalida.Enabled = true;
                DtpHoraSalida.Enabled = true;
            }
        }

        private void Btn_Matricula_Click(object sender, EventArgs e)
        {
            CboCiudadOrigen.Enabled = true;
        }

    }

}
