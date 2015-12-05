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
using Configuracion;

namespace AerolineaFrba.Registro_Llegada_Destino
{
    public partial class RegistroLlegadaDestino : Form
    {
       
        
        public RegistroLlegadaDestino()
        {
            InitializeComponent();
        }

        private void CargarCbos()
        {
            CboCiudadOrigen.DataSource = CiudadPersistencia.ObtenerTodos();
            CboCiudadOrigen.ValueMember = "ID";
            CboCiudadOrigen.DisplayMember = "Nombre";

            CboAeronave.DataSource = AeronavePersistencia.ObtenerAeronavesHabilitadas();
            CboAeronave.ValueMember = "ID";
            CboAeronave.DisplayMember = "Matricula";

            CboCiudadDestino.DataSource = CiudadPersistencia.ObtenerTodos();
            CboCiudadDestino.ValueMember = "ID";
            CboCiudadDestino.DisplayMember = "Nombre";
        }

        private void RegistroLlegadaDestino_Load(object sender, EventArgs e)
        {
            CargarCbos();
            DtpFechaSalida.Value = ConfiguracionDeVariables.FechaSistema;
        }


        private void Btn_Cancelar_Click_1(object sender, EventArgs e)
        {
                Close();
        }

        public void volverAEstadoInicial(){
            limpiarCampos();
            CargarCbos();
            
            Btn_Cancelar.Enabled = true;
            Btn_Registrar.Enabled = true;
            DtpFechaSalida.Enabled = true;
            CboAeronave.Enabled = true;
            CboCiudadDestino.Enabled = true;
            CboCiudadOrigen.Enabled = true;
            Btn_Limpiar.Enabled = true;
        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            CargarCbos();
        }

        private void limpiarCampos()
        {
            DtpFechaSalida.Value = ConfiguracionDeVariables.FechaSistema;
        }

        private void Btn_Registrar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (DtpFechaSalida.Value > ConfiguracionDeVariables.FechaSistema)
                {
                    volverAEstadoInicial();
                    throw new Exception("No se puede registrar un viaje posterior a la fecha actual.");
                }

                #region declaraciones
                Aeronave aeronave = AeronavePersistencia.ObtenerPorMatricula(CboAeronave.Text);
                int ID_Origen = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CboCiudadOrigen.Text);
                int ID_Destino = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CboCiudadDestino.Text);

                #endregion

                #region busco aeronave
                var viajes = ViajePersistencia.ObtenerViaje(aeronave.ID, ID_Origen, DtpFechaSalida.Value);
                if (viajes == null || viajes.Count == 0)
                {
                    limpiarCampos();
                    CargarCbos();
                    throw new Exception("Los campos ingresados no coninciden con un viaje realizado.");
                }

                Viaje viaje = viajes[0];

                if (viaje.Fecha_Llegada != DateTime.MinValue)
                {
                    limpiarCampos();
                    CargarCbos();
                    throw new Exception("El viaje ya fue registrado anteriormente.");
                }

                if (RutaPersistencia.ObtenerCiudadDestino(viaje.ID_Ruta) != ID_Destino)
                {
                    var dialogAnswer = MessageBox.Show("La ciudad de destino no coincide con la del viaje. Esta seguro que desea registrarlo de todos modos?", "Atencion", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        var infoAeronave = new InformacionAeronave(aeronave, viaje, this);
                        infoAeronave.ShowDialog();
                        volverAEstadoInicial();
                    }
                }
                else
                {
                    var infoAeronave = new InformacionAeronave(aeronave, viaje, this);
                    infoAeronave.ShowDialog();
                    volverAEstadoInicial();
                }
                
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }

        }

        public void actualizarLlegada(DateTime fechallegada)
        {
            Btn_Registrar.Enabled = false;
            DtpFechaSalida.Enabled = false;
            CboAeronave.Enabled = false;
            CboCiudadDestino.Enabled = false;
            CboCiudadOrigen.Enabled = false;
            Btn_Cancelar.Enabled = false;
            Btn_Limpiar.Enabled = false;
            
        }
    }
}
