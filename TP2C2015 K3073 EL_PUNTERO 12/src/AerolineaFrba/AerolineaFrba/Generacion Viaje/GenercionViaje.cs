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
            DtpFechaSalida.MinDate = DateTime.Today;
            DtpFechaLlegadaEstimada.MinDate = DtpFechaSalida.Value.AddHours(1);

            CargarCbos();
            ActualizarFechas();
            ComenzarConCboVacios();
        }

        private void ComenzarConCboVacios()
        {
            Txt_Servicio.Text = "TIPO SERVICIO";
            CboAeronave.Text = "MATRICULA AERONAVE";
            CboCiudadOrigen.Text = "CIUDAD ORIGEN";
            CboCiudadDestino.Text = "CIUDAD DESTINO";
        }

        private void CargarCbos()
        {
             CboAeronave.DataSource = AeronavePersistencia.ObtenerAeronavesHabilitadas();
             CboAeronave.ValueMember = "ID";
             CboAeronave.DisplayMember = "Matricula";
        }


        private void DtpFechaLlegadaEstimada_ValueChanged(object sender, EventArgs e)
        {
            DtpFechaLlegada.Value = DtpFechaLlegadaEstimada.Value;
        }


        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            CargarCbos();
            ComenzarConCboVacios();
            CboCiudadOrigen.Enabled = false;
            CboCiudadDestino.Enabled = false;
            ActualizarFechas();
        }

        private void ActualizarFechas()
        {

            DtpFechaSalida.Value = DateTime.Now;
            DtpFechaLlegadaEstimada.Enabled = false;
            DtpFechaSalida.Enabled = false;
           
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere volver al Home?", "Atencion", MessageBoxButtons.YesNo);
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

                if (ValidarHorarioDeAeronave(DtpFechaSalida.Value, DtpFechaLlegadaEstimada.Value) == 0)
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

        private int ValidarHorarioDeAeronave(DateTime fechaSalida, DateTime fechaLlegadaEstimada)
        {
            var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable);
            int ID_Aeronave = AeronavePersistencia.ObtenerPorMatricula(CboAeronave.Text, transaccion).ID;
            transaccion.Commit();
            return ViajePersistencia.ValidarHorarioDeAeronave(fechaSalida, fechaLlegadaEstimada,ID_Aeronave);
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

        private void Btn_SeleccionarCiudadDestino_Click_1(object sender, EventArgs e)
        {
            if (CboCiudadOrigen.Text != "CIUDAD ORIGEN" && CboCiudadDestino.Text != "CIUDAD DESTINO" && CboAeronave.Text != "MATRICULA AERONAVE")
            {
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
                CboCiudadDestino.Enabled = true;
                int ID_Origen = Convert.ToInt32(CboCiudadOrigen.SelectedValue);
                List<Ciudad> ciudadesConMismoOrigen = RutaPersistencia.ObtenerTodasLasCiudadesConOrigen(ID_Origen);

                CboCiudadDestino.DataSource = ciudadesConMismoOrigen;
                CboCiudadDestino.ValueMember = "ID";
                CboCiudadDestino.DisplayMember = "Nombre";

                DtpFechaSalida.Enabled = true;
                DtpFechaLlegadaEstimada.Enabled = true;
            
        }

        private void CboAeronave_SelectionChangeCommitted(object sender, EventArgs e)
        {
                //SERVICIO
                Aeronave aero = (Aeronave)CboAeronave.SelectedItem;
                var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable);
                int ID_Aeronave = aero.ID;
                transaccion.Commit();
                Servicio servicio = ServicioPersistencia.ObtenerServicioAeronave(ID_Aeronave);
                Txt_Servicio.Text = servicio.Nombre;

                //CIUDAD ORIGEN
                CboCiudadOrigen.Enabled = true;
                CboCiudadOrigen.DataSource = CiudadPersistencia.ObtenerCiudadesOrigenParaUnServicio(servicio.ID_Servicio);
                CboCiudadOrigen.ValueMember = "ID";
                CboCiudadOrigen.DisplayMember = "Nombre";
                
                //CIUDAD DESTINO
                CboCiudadDestino.Enabled = true;
                int ID_Origen = Convert.ToInt32(CboCiudadOrigen.SelectedValue);
                List<Ciudad> ciudadesConMismoOrigen = RutaPersistencia.ObtenerTodasLasCiudadesConOrigen(ID_Origen);

                CboCiudadDestino.DataSource = ciudadesConMismoOrigen;
                CboCiudadDestino.ValueMember = "ID";
                CboCiudadDestino.DisplayMember = "Nombre";

                //FECHAS
                DtpFechaSalida.Enabled = true;
                DtpFechaLlegadaEstimada.Enabled = true;

        }

        
        
    }

}
