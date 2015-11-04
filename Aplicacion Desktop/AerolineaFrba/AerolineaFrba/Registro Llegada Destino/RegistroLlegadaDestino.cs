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
using System.Globalization;

namespace AerolineaFrba.Registro_Llegada_Destino
{
    public partial class RegistroLlegadaDestino : Form
    {
       
        
        public RegistroLlegadaDestino()
        {
            InitializeComponent();
        }

        private void ComenzarConCboVacios()
        {
            CboAeronave.Text = "MATRICULA AERONAVE";
            CboCiudadOrigen.Text = "CIUDAD ORIGEN";
            CboCiudadDestino.Text = "CIUDAD DESTINO";
        }

        private void CargarCbos()
        {
            CboCiudadOrigen.DataSource = CiudadPersistencia.ObtenerTodos();
            CboCiudadOrigen.ValueMember = "ID";
            CboCiudadOrigen.DisplayMember = "Nombre";

            CboAeronave.DataSource = AeronavePersistencia.ObtenerTodas();
            CboAeronave.ValueMember = "ID";
            CboAeronave.DisplayMember = "Matricula";

            CboCiudadDestino.DataSource = CiudadPersistencia.ObtenerTodos();
            CboCiudadDestino.ValueMember = "ID";
            CboCiudadDestino.DisplayMember = "Nombre";
        }

        private void RegistroLlegadaDestino_Load(object sender, EventArgs e)
        {
            CargarCbos();
            ComenzarConCboVacios();
            DtpFechaSalida.Value = DateTime.Now;

        }


        private void Btn_Cancelar_Click_1(object sender, EventArgs e)
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

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {

            using (var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    #region ValidacionesEnGral
                    var exceptionMessage = string.Empty;
                    if (CboAeronave.Text == "MATRICULA AERONAVE")
                        exceptionMessage += "La matricula no puede ser vacia.\n";
                    if (CboCiudadOrigen.Text == "CIUDAD ORIGEN")
                        exceptionMessage += "La ciudad origen no puede ser vacia.\n";
                    if (CboCiudadDestino.Text == "CIUDAD DESTINO")
                        exceptionMessage += "La ciudad destino no puede ser vacia.\n";
                    #endregion

                    #region declaraciones
                    int ID_Aeronave = AeronavePersistencia.ObtenerPorMatricula(CboAeronave.Text, transaccion).ID;
                    int ID_Origen = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CboCiudadOrigen.Text);
                    int ID_Destino = CiudadPersistencia.ObtenerIDPorNombreDeCiudad(CboCiudadDestino.Text);
                    int ID_Ruta = RutaPersistencia.ObtenerRutaPorOrigenYDestino(ID_Origen, ID_Destino).ID;
                    #endregion

                    #region busco aeronave
                    List<Aeronave> aeronaves = ViajePersistencia.ValidarAeronaveDelViaje(ID_Aeronave, ID_Ruta, DtpFechaSalida.Value.Date, transaccion);
                    if (aeronaves != null)
                    {
                        
                        Aeronave aeronave = aeronaves[0];
                        var dialogAnswer = MessageBox.Show("Desea registrar la llegada de la aeronave a destino?", "Atencion", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == dialogAnswer)
                        {
                            //transaccion.Commit();
                            Hide();
                            var infoAeronave = new InformacionAeronave(aeronave);
                            infoAeronave.ShowDialog();
                            Close();
                        }
                    }
                    else
                    {
                        ComenzarConCboVacios();
                        DtpFechaSalida.Value = DateTime.Now;
                        throw new Exception("Los campos ingresados no coninciden con un viaje realizado.");
                        
                    }
                #endregion

                }
                catch (Exception ex)
                {
                    transaccion.Commit();
                    MessageBox.Show(ex.Message, "Atención");
                }

            }

        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            CboAeronave.Text = "MATRICULA AERONAVE";
            CboCiudadOrigen.Text = "CIUDAD ORIGEN";
            CboCiudadDestino.Text = "CIUDAD DESTINO";
            DtpFechaSalida.Value = DateTime.Now;
        }


    }
}
