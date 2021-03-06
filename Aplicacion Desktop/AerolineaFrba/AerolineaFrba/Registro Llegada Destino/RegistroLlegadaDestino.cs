﻿using System;
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
            ComenzarConCboVacios();
            DtpFechaSalida.Value = DateTime.Now;
            DtpFechaLlegada.Value = DateTime.Now;

        }


        private void Btn_Cancelar_Click_1(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                Close();
            }
        }

        private void Btn_Finalizar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Registro finalizado correctamente","Informacion", MessageBoxButtons.OK);
            limpiarCampos();
            Btn_Cancelar.Enabled = true;
            Btn_Registrar.Enabled = true;
            DtpFechaSalida.Enabled = true;
            CboAeronave.Enabled = true;
            CboCiudadDestino.Enabled = true;
            CboCiudadOrigen.Enabled = true;
            Btn_Limpiar.Enabled = true;

            Btn_Finalizar.Enabled = false;  
        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            CboAeronave.Text = "MATRICULA AERONAVE";
            CboCiudadOrigen.Text = "CIUDAD ORIGEN";
            CboCiudadDestino.Text = "CIUDAD DESTINO";
            DtpFechaSalida.Value = DateTime.Now;
            DtpFechaLlegada.Value = DateTime.Now;
        }

        private void Btn_Registrar_Click(object sender, EventArgs e)
        {
            try
            {
                #region ValidacionesEnGral
                var exceptionMessage = string.Empty;
                if (CboAeronave.Text == "MATRICULA AERONAVE")
                    exceptionMessage += "La matricula no puede ser vacía.\n";
                if (CboCiudadOrigen.Text == "CIUDAD ORIGEN")
                    exceptionMessage += "La ciudad origen no puede ser vacía.\n";
                if (CboCiudadDestino.Text == "CIUDAD DESTINO")
                    exceptionMessage += "La ciudad destino no puede ser vacía.\n";
                if (!string.IsNullOrEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

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
                    ComenzarConCboVacios();
                    DtpFechaSalida.Value = DateTime.Now;
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
                    ComenzarConCboVacios();
                    DtpFechaSalida.Value = DateTime.Now;
                    throw new Exception("Los campos ingresados no coninciden con un viaje realizado.");
                }

                Aeronave aeronave = aeronaves[0];
                Viaje viaje = viajes[0];
                var infoAeronave = new InformacionAeronave(aeronave,viaje,this);
                infoAeronave.ShowDialog();
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }

        }

        public void actualizarLlegada(DateTime fechallegada)
        {
            DtpFechaLlegada.Value = fechallegada;
            Btn_Finalizar.Enabled = true;
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
