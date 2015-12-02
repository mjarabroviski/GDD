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
            DtpFechaSalida.Value = DateTime.Now;
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
            DtpFechaSalida.Value = DateTime.Now;
        }

        private void Btn_Registrar_Click(object sender, EventArgs e)
        {
            try
            {

                #region declaraciones
                var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable);
                int ID_Aeronave = AeronavePersistencia.ObtenerPorMatricula(CboAeronave.Text,transaccion).ID;
                transaccion.Commit();
                int ID_Origen = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CboCiudadOrigen.Text);
                int ID_Destino = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CboCiudadDestino.Text);
                var rutas = RutaPersistencia.ObtenerRutaPorOrigenYDestino(ID_Origen, ID_Destino);
                int ID_Ruta;

                if (rutas == null || rutas.Count == 0)
                {
                    volverAEstadoInicial();
                    throw new Exception("Los campos ingresados no coninciden con un viaje realizado.");
                }
                else
                {
                    ID_Ruta = rutas[0].ID;
                }

                #endregion

                #region busco aeronave
                var aeronaves = ViajePersistencia.ValidarAeronaveDelViaje(ID_Aeronave, ID_Ruta, DtpFechaSalida.Value);
                var viajes = ViajePersistencia.ObtenerViaje(ID_Aeronave, ID_Ruta, DtpFechaSalida.Value);
                if (viajes == null || viajes.Count == 0)
                {
                    limpiarCampos();
                    CargarCbos();
                    throw new Exception("Los campos ingresados no coninciden con un viaje realizado.");
                }

                Aeronave aeronave = aeronaves[0];
                Viaje viaje = viajes[0];
                var infoAeronave = new InformacionAeronave(aeronave,viaje,this);
                infoAeronave.ShowDialog();
                volverAEstadoInicial();
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

        private void CboAeronave_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
