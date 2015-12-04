using Persistencia;
using Persistencia.Entidades;
using Sesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Configuracion;

namespace AerolineaFrba.Compra
{
    public partial class FrmPagoConTarjeta : Form
    {
        public ClienteAuxiliar cliente;
        public Viaje viajeActual;
        public decimal cantKgs;
        public decimal cantPasajes;
        public double precioEnc;
        public double precioPas;
        public string precioTot;

        public FrmPagoConTarjeta(ClienteAuxiliar cli,Viaje viajeAct,decimal cantEnc,double precioEncomienda,decimal cantPas,double precioPasajes,string precioTotal)
        {
            InitializeComponent();
            cliente = cli; 
            TxtTitular.Text = cli.NombreYApellido;
            viajeActual = viajeAct;
            cantKgs = cantEnc;
            precioEnc = precioEncomienda;
            cantPasajes = cantPas;
            precioPas = precioPasajes;
            precioTot = precioTotal;
        }

        private void FrmPagoConTarjeta_Load(object sender, EventArgs e)
        {
            CmbTipoTarjeta.DataSource = TipoTarjetaPersistencia.ObtenerTodos();
            CmbTipoTarjeta.ValueMember = "ID";
            CmbTipoTarjeta.DisplayMember = "Descripcion";

            CmbCantCuotas.Text = "1";
        }

        private void TxtMes_TextChanged(object sender, EventArgs e)
        {
            TxtMes.ForeColor = SystemColors.WindowText;
        }

        private void TxtAnio_TextChanged(object sender, EventArgs e)
        {
            TxtAnio.ForeColor = SystemColors.WindowText;
        }

        private void TxtMes_Click(object sender, EventArgs e)
        {
            TxtMes.Text = "";
        }

        private void TxtAnio_Click(object sender, EventArgs e)
        {
            TxtAnio.Text = "";
        }

        private void BtnTarjeta_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones
                var mensajeExcepcion = string.Empty;

                if (!(ValidadorDeTipos.IsEmpty(TxtNroTarjeta.Text)))
                {
                    if (!(ValidadorDeTipos.IsNumeric(TxtNroTarjeta.Text)))
                        mensajeExcepcion += Environment.NewLine + "El formato del número de la tarjeta es incorrecto";
                }
                else
                {
                    mensajeExcepcion += Environment.NewLine + "Debe ingresar el número de su tarjeta";
                }

                if (!(ValidadorDeTipos.IsEmpty(TxtCodigoSeguridad.Text)))
                {
                    if (!(ValidadorDeTipos.IsNumeric(TxtCodigoSeguridad.Text)))
                        mensajeExcepcion += Environment.NewLine + "El formato del código de seguridad es incorrecto";
                }
                else
                {
                    mensajeExcepcion += Environment.NewLine + "Debe ingresar el código de seguridad";
                }

                if (!(ValidadorDeTipos.IsEmpty(TxtMes.Text)))
                {
                    if (!(ValidadorDeTipos.IsNumeric(TxtMes.Text)))
                    {
                        mensajeExcepcion += Environment.NewLine + "El formato del mes de vencimiento es incorrecto";
                    }
                    else
                    {
                        if (Int32.Parse(TxtMes.Text) < 1 || Int32.Parse(TxtMes.Text) > 12)
                            mensajeExcepcion += Environment.NewLine + "El mes de vencimiento es incorrecto";
                    }
                }
                else
                {
                    mensajeExcepcion += Environment.NewLine + "Debe ingresar el mes de vencimiento";
                }

                if (!(ValidadorDeTipos.IsEmpty(TxtAnio.Text)))
                {
                    if (!(ValidadorDeTipos.IsNumeric(TxtAnio.Text)))
                    {
                        mensajeExcepcion += Environment.NewLine + "El formato del año de vencimiento es incorrecto";
                    }
                    else
                    {
                        if (Int32.Parse(TxtAnio.Text) < ConfiguracionDeVariables.FechaSistema.Year)
                        {
                            mensajeExcepcion += Environment.NewLine + "La tarjeta esta vencida";
                        }
                        if (Int32.Parse(TxtAnio.Text) == ConfiguracionDeVariables.FechaSistema.Year)
                        {
                            if (Int32.Parse(TxtMes.Text) <= ConfiguracionDeVariables.FechaSistema.Month)
                                mensajeExcepcion += Environment.NewLine + "La tarjeta esta vencida";
                        }
                    }
                }
                else
                {
                    mensajeExcepcion += Environment.NewLine + "Debe ingresar el año de vencimiento";
                }


                if (!ValidadorDeTipos.IsEmpty(mensajeExcepcion))
                    throw new Exception(mensajeExcepcion);

                #endregion

                var dialogAnswer = MessageBox.Show(string.Format("Desea confirmar la compra?"), "Atención", MessageBoxButtons.YesNo);
                if (dialogAnswer == DialogResult.Yes)
                {
                    if (cantPasajes != 0)
                    {
                        int cantAuxiliares = ClientePersistencia.ObtenerAuxiliares().Count;
                        for (int i = 1; i <= cantAuxiliares; i++)
                        {
                            CompraPersistencia.GuardarPasajeros(i,viajeActual.ID,precioPas/cantAuxiliares);
                        }
                    }

                    CompraPersistencia.GuardarAlQuePaga(cliente);
                    CompraPersistencia.GuardarTarjetaYConfirmarCompra(cliente, 
                                                                      CmbTipoTarjeta.SelectedIndex+1, 
                                                                      Int32.Parse(TxtNroTarjeta.Text), 
                                                                      Int32.Parse(CmbCantCuotas.Text),
                                                                      viajeActual.ID,
                                                                      cantKgs,
                                                                      precioEnc,
                                                                      AdministradorSesion.UsuarioActual);

                    FrmInformeDatosCompra frmInfDatosCompra = new FrmInformeDatosCompra(precioTot,cantPasajes);
                    frmInfDatosCompra.ShowDialog();
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (cantPasajes != 0)
                CompraPersistencia.BorrarTablaAuxiliar();
            Close();
        }
    }
}
