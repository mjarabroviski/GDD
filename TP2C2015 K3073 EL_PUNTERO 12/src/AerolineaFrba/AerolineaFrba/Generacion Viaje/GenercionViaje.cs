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
            CboTipoServicio.Text = "TIPO SERVICIO";
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


        private void DtpFechaLlegadaEstimada_ValueChanged(object sender, EventArgs e)
        {
            DtpFechaLlegada.Value = DtpFechaLlegadaEstimada.Value;
        }

        private void CboCiudadOrigen_Click(object sender, EventArgs e)
        {
           /* if (CboCiudadOrigen.Text != "CIUDAD ORIGEN")
            {
                CboCiudadDestino.Text = "CIUDAD DESTINO";
                CboCiudadDestino.Enabled = false;
                CboTipoServicio.Text = "TIPO SERVICIO";
                CboTipoServicio.Enabled = false;
            }*/

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
            ActualizarFechas();
        }

        private void ActualizarFechas()
        {
            DtpFechaSalida.MinDate = DateTime.Now;
            DtpFechaLlegadaEstimada.MinDate = DtpFechaSalida.Value.AddHours(1);

            DtpFechaSalida.Value = DateTime.Now;
            DtpFechaLlegadaEstimada.Value = DtpFechaSalida.Value.AddHours(1);
            DtpFechaLlegada.Value = DtpFechaLlegadaEstimada.Value;
            DtpFechaLlegadaEstimada.Enabled = false;
            DtpFechaSalida.Enabled = false;
           
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
            try
            {
                #region validacionesDeHoras
                if ( DtpFechaLlegada.Value.Month != DtpFechaSalida.Value.Month
                    || DtpFechaLlegada.Value.Year != DtpFechaSalida.Value.Year)
                {
                    throw new Exception("Asegurese de ingresar el horario correctamente.");

                }
                if (DtpFechaLlegada.Value.Month == DtpFechaSalida.Value.Month
                     && DtpFechaLlegada.Value.Year == DtpFechaSalida.Value.Year
                     && DtpFechaLlegada.Value.Day != DtpFechaSalida.Value.Day
                     && DtpFechaLlegada.Value.Day != DtpFechaSalida.Value.AddDays(1).Day
                     )
                {
                    throw new Exception("Asegurese de ingresar el horario correctamente.");

                }

                if (DtpFechaLlegada.Value.Day == DtpFechaSalida.Value.Day)
                {
                    if (DtpFechaSalida.Value.TimeOfDay > DtpFechaLlegada.Value.TimeOfDay)
                    {
                       throw new Exception("Asegurese de ingresar el horario correctamente.");
                    }
                }
                if (DtpFechaLlegada.Value.Day == DtpFechaSalida.Value.AddDays(1).Day)
                {
                    if (DtpFechaSalida.Value.TimeOfDay < DtpFechaLlegada.Value.TimeOfDay)
                    {
                        throw new Exception("Asegurese de ingresar el horario correctamente.");
                    }

                }

                #endregion

                if (ValidarHorarioDeAeronave(DtpFechaSalida.Value, DtpFechaLlegadaEstimada.Value))
                {

                    int ID_Origen = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CboCiudadOrigen.Text);
                    int ID_Destino = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CboCiudadDestino.Text);
                    var rutas = RutaPersistencia.ObtenerRutaPorOrigenYDestino(ID_Origen, ID_Destino);
                    int ID_Ruta = rutas[0].ID;

                    var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable);
                    int ID_Aeronave = AeronavePersistencia.ObtenerPorMatricula(CboAeronave.Text, transaccion).ID;
                    transaccion.Commit();

                    ViajePersistencia.GenerarViaje(DtpFechaLlegada.Value, DtpFechaSalida.Value, DtpFechaLlegadaEstimada.Value, ID_Ruta, ID_Aeronave);
                    var dialogAnswer = MessageBox.Show("Esta seguro que desea generar el viaje?", "Atencion", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == dialogAnswer)
                    {
                        var dialogAnswer2 = MessageBox.Show("Viaje generado satisfactoriamente", "Informacion", MessageBoxButtons.OK);
                        LimpiarCampos();
                    }

                }
                else
                {
                    throw new Exception("La Aeronave se encuentra ocupada para las fechas seleccionada.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
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
            }
         }


        private void CboAeronave_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (CboCiudadOrigen.Text != "CIUDAD ORIGEN" && CboCiudadDestino.Text != "CIUDAD DESTINO" && CboAeronave.Text != "MATRICULA AERONAVE")
            {
                ObtenerServiciosDisponibles();
            }*/
        }


          private void DtpFechaSalida_ValueChanged_1(object sender, EventArgs e)
          {
                  DtpFechaLlegadaEstimada.Value = DtpFechaSalida.Value.AddHours(1);
                  DtpFechaLlegada.Value = DtpFechaLlegadaEstimada.Value;
          }

          private void DtpFechaLlegadaEstimada_ValueChanged_1(object sender, EventArgs e)
          {

              DtpFechaLlegada.Value = DtpFechaLlegadaEstimada.Value;
          }

          private void label8_Click(object sender, EventArgs e)
          {
              CboCiudadOrigen.Enabled = true;
          }

        private void Btn_SeleccionarCiudadDestino_Click_1(object sender, EventArgs e)
        {
            if (CboCiudadOrigen.Text != "CIUDAD ORIGEN" && CboCiudadDestino.Text != "CIUDAD DESTINO" && CboAeronave.Text != "MATRICULA AERONAVE")
            {
                ObtenerServiciosDisponibles();
                DtpFechaSalida.Enabled = true;
                DtpFechaLlegadaEstimada.Enabled = true;
            }
            else
            {
                MessageBox.Show("Debe ingresar los campos obligatorios disponibles");
            }
        }

        private void CboCiudadOrigen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CboCiudadOrigen.Text != "CIUDAD ORIGEN" && CboCiudadDestino.Text != "CIUDAD DESTINO" && CboAeronave.Text != "MATRICULA AERONAVE")
            {
                ObtenerServiciosDisponibles();
            }
            else
            {
                CboCiudadDestino.Enabled = true;
                int ID_Origen = Convert.ToInt32(CboCiudadOrigen.SelectedValue);
                List<Ciudad> ciudadesConMismoOrigen = RutaPersistencia.ObtenerTodasLasCiudadesConOrigen(ID_Origen);

                CboCiudadDestino.DataSource = ciudadesConMismoOrigen;
                CboCiudadDestino.ValueMember = "ID";
                CboCiudadDestino.DisplayMember = "Nombre";
            }
        }

        private void CboAeronave_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CboCiudadOrigen.Text != "CIUDAD ORIGEN" && CboCiudadDestino.Text != "CIUDAD DESTINO" && CboAeronave.Text != "MATRICULA AERONAVE")
            {
                ObtenerServiciosDisponibles();
            }
        }

        private void CboCiudadDestino_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CboCiudadOrigen.Text != "CIUDAD ORIGEN" && CboCiudadDestino.Text != "CIUDAD DESTINO" && CboAeronave.Text != "MATRICULA AERONAVE")
            {
                ObtenerServiciosDisponibles();
            }
        }

    }

}
