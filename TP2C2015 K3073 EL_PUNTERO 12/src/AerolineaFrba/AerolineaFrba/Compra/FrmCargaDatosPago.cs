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
    public partial class FrmCargaDatosPago : Form
    {
        public decimal cantEnc;
        public decimal cantPas;
        public Viaje viajeActual;
        public double precioPasajes;
        public double precioEncomienda;

        public FrmCargaDatosPago(FrmIngresoCantidades frmIngresoCants,decimal cantPasajes,decimal cantEncomiendas,Viaje viaje)
        {
            InitializeComponent();
            if (frmIngresoCants != null)
                frmIngresoCants.Visible = false;
            cantEnc = cantEncomiendas;
            viajeActual = viaje;
            cantPas = cantPasajes;
            if (cantPas == 0)
            {
                CmbPasajeros.Visible = false;
                BtnDatosViejos.Visible = false;
                BtnDatosNuevos.Visible = false;
                TxtApellidos.Enabled = true;
                TxtCalle.Enabled = true;
                TxtMail.Enabled = true;
                TxtNombres.Enabled = true;
                TxtNroCalle.Enabled = true;
                TxtNroDoc.Enabled = true;
                TxtTelefono.Enabled = true;
                DtpFechaNac.Enabled = true;
                CmbTipoDoc.Enabled = true;
                label14.Visible = false;
            }
            else
            {
                CmbPasajeros.DataSource = ClientePersistencia.ObtenerAuxiliares();
                CmbPasajeros.ValueMember = "ID";
                CmbPasajeros.DisplayMember = "NombreYApellido";
            }
        }

        private void FrmCargaDatosPago_Load(object sender, EventArgs e)
        {
            Image image = Image.FromFile("../../Avion.jpg");
            pbFoto.Image = image;
            pbFoto.SizeMode = PictureBoxSizeMode.CenterImage;
            
            if (AdministradorSesion.UsuarioActual == null)
                BtnEfectivo.Visible = false;

            DtpFechaNac.MaxDate = ConfiguracionDeVariables.FechaSistema;
            DtpFechaNac.Value = ConfiguracionDeVariables.FechaSistema;

            CmbTipoDoc.DataSource = TipoDocumentoPersistencia.ObtenerTodos();
            CmbTipoDoc.ValueMember = "ID";
            CmbTipoDoc.DisplayMember = "Descripcion";

            Servicio servi = ServicioPersistencia.ObtenerServicioAeronave(viajeActual.ID_Aeronave);
            var porcentajeServicio = (servi.Porcentaje/100)+1;
            Ruta ruta = RutaPersistencia.ObtenerRutaPorID(viajeActual.ID_Ruta);
            precioEncomienda = (double)cantEnc * ruta.Precio_Base_KG;
            precioPasajes = (double)cantPas * ruta.Precio_Base_Pasaje * porcentajeServicio;

            label16.Text = "$" + Math.Round((precioEncomienda + precioPasajes),2).ToString();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que desea cancelar la compra?"), "Atención", MessageBoxButtons.YesNo);
            if (dialogAnswer == DialogResult.Yes)
            {
                if(cantPas!=0)
                    CompraPersistencia.BorrarTablaAuxiliar();
                this.Visible = false;
                FrmCompra frmCompra = new FrmCompra();
                frmCompra.ShowDialog();
                this.Close();
            }
        }

        private void CmbPasajeros_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void BtnDatosNuevos_Click(object sender, EventArgs e)
        {
                CmbPasajeros.Enabled = false;
                TxtApellidos.Enabled = true;
                TxtCalle.Enabled = true;
                TxtMail.Enabled = true;
                TxtNombres.Enabled = true;
                TxtNroCalle.Enabled = true;
                TxtNroDoc.Enabled = true;
                TxtTelefono.Enabled = true;
                DtpFechaNac.Enabled = true;
                CmbTipoDoc.Enabled = true;

                TxtApellidos.Text = "";
                TxtMail.Text = "";
                TxtNombres.Text = "";
                TxtNroDoc.Text = "";
                TxtTelefono.Text = "";
                CmbTipoDoc.Text = "";
                TxtNroCalle.Text = "";
                TxtCalle.Text = "";
                DtpFechaNac.Value = ConfiguracionDeVariables.FechaSistema;

                CmbPasajeros.DataSource = ClientePersistencia.ObtenerAuxiliares();
                CmbPasajeros.ValueMember = "ID";
                CmbPasajeros.DisplayMember = "NombreYApellido";
        }

        private void BtnDatosViejos_Click(object sender, EventArgs e)
        {
            CmbPasajeros.Enabled = true;
            TxtApellidos.Enabled = false;
            TxtCalle.Enabled = false;
            TxtMail.Enabled = false;
            TxtNombres.Enabled = false;
            TxtNroCalle.Enabled = false;
            TxtNroDoc.Enabled = false;
            TxtTelefono.Enabled = false;
            DtpFechaNac.Enabled = false;
            CmbTipoDoc.Enabled = false;
            ClienteAuxiliar clienteAux = ClientePersistencia.ObtenerClientePorNombreYApellido(CmbPasajeros.Text);
            for (int i = clienteAux.Direccion.Length-1; i > 0; i--)
            {
                if(!ValidadorDeTipos.IsNumeric(clienteAux.Direccion[i].ToString())){
                    TxtNroCalle.Text = clienteAux.Direccion.Substring(i + 1, clienteAux.Direccion.Length - 1 - i);
                    TxtCalle.Text = clienteAux.Direccion.Substring(0, i+1);
                    i = 0;
                }

            }
            TxtApellidos.Text = clienteAux.Apellido;
            TxtMail.Text = clienteAux.Mail;
            TxtNombres.Text = clienteAux.Nombre;
            TxtNroDoc.Text = clienteAux.Nro_Documento.ToString();
            TxtTelefono.Text = clienteAux.Telefono;
            CmbTipoDoc.Text = TipoDocumentoPersistencia.ObtenerPorID(clienteAux.ID_Tipo_Documento);
            DtpFechaNac.Value = clienteAux.Fecha_Nacimiento;

        }

        private void BtnTarjeta_Click(object sender, EventArgs e)
        {
            try
            {

                Validaciones();

                #region Armado del cliente auxiliar

                ClienteAuxiliar cli = new ClienteAuxiliar();
                cli.Apellido=TxtApellidos.Text;
                cli.Direccion = TxtCalle.Text + TxtNroCalle.Text;
                cli.Fecha_Nacimiento = DtpFechaNac.Value;
                cli.ID_Tipo_Documento = CmbTipoDoc.SelectedIndex+1;
                cli.Mail = TxtMail.Text;
                cli.Nombre = TxtNombres.Text;
                cli.NombreYApellido = cli.Apellido + ", " + cli.Nombre;
                cli.Nro_Documento = Int32.Parse(TxtNroDoc.Text);
                cli.Telefono = TxtTelefono.Text;

                #endregion

                FrmPagoConTarjeta frmPagoTarjeta = new FrmPagoConTarjeta(cli,viajeActual,cantEnc,precioEncomienda,cantPas,precioPasajes,label16.Text);
                frmPagoTarjeta.ShowDialog();
                this.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void Validaciones()
        {
            var mensajeExcepcion = string.Empty;

            if (!(ValidadorDeTipos.IsEmpty(TxtNroDoc.Text)))
            {
                if (!(ValidadorDeTipos.IsNumeric(TxtNroDoc.Text)))
                    mensajeExcepcion += Environment.NewLine + "El documento debe ser un número";
            }
            else
            {
                mensajeExcepcion += Environment.NewLine + "Debe ingresar su documento";
            }

            if (ValidadorDeTipos.IsEmpty(TxtNombres.Text))
            {
                mensajeExcepcion += Environment.NewLine + "Debe ingresar su nombre";
            }

            if (ValidadorDeTipos.IsEmpty(TxtApellidos.Text))
            {
                mensajeExcepcion += Environment.NewLine + "Debe ingresar su apellido";
            }

            if (ValidadorDeTipos.IsEmpty(TxtCalle.Text))
            {
                mensajeExcepcion += Environment.NewLine + "Debe ingresar la calle de su domicilio";
            }

            if (!(ValidadorDeTipos.IsEmpty(TxtNroCalle.Text)))
            {
                if (!(ValidadorDeTipos.IsNumeric(TxtNroCalle.Text)))
                    mensajeExcepcion += Environment.NewLine + "La altura del domicilio debe ser un número";
            }
            else
            {
                mensajeExcepcion += Environment.NewLine + "Debe ingresar la altura de su domicilio";
            }

            if (!(ValidadorDeTipos.IsEmpty(TxtTelefono.Text)))
            {
                if (!(ValidadorDeTipos.IsNumeric(TxtTelefono.Text)))
                    mensajeExcepcion += Environment.NewLine + "El teléfono debe ser un número";
            }
            else
            {
                mensajeExcepcion += Environment.NewLine + "Debe ingresar su teléfono";
            }

            if ((!(ValidadorDeTipos.IsMailValido(TxtMail.Text))) && (!(ValidadorDeTipos.IsEmpty(TxtMail.Text))))
                mensajeExcepcion += Environment.NewLine + "Formato inválido de mail";

            if (!ValidadorDeTipos.IsEmpty(mensajeExcepcion))
                throw new Exception(mensajeExcepcion);

        }

        private void BtnEfectivo_Click(object sender, EventArgs e)
        {
            try
            {
                Validaciones();

                var dialogAnswer = MessageBox.Show(string.Format("Desea confirmar la compra?"), "Atención", MessageBoxButtons.YesNo);
                if (dialogAnswer == DialogResult.Yes)
                {
                    #region Armado del cliente auxiliar

                    ClienteAuxiliar cli = new ClienteAuxiliar();
                    cli.Apellido = TxtApellidos.Text;
                    cli.Direccion = TxtCalle.Text + TxtNroCalle.Text;
                    cli.Fecha_Nacimiento = DtpFechaNac.Value;
                    cli.ID_Tipo_Documento = CmbTipoDoc.SelectedIndex + 1;
                    cli.Mail = TxtMail.Text;
                    cli.Nombre = TxtNombres.Text;
                    cli.NombreYApellido = cli.Apellido + ", " + cli.Nombre;
                    cli.Nro_Documento = Int32.Parse(TxtNroDoc.Text);
                    cli.Telefono = TxtTelefono.Text;

                    #endregion

                    if (cantPas != 0)
                    {
                        for (int i = 1; i <= ClientePersistencia.ObtenerAuxiliares().Count; i++)
                        {
                            CompraPersistencia.GuardarPasajeros(i, viajeActual.ID, precioPasajes);
                        }
                    }

                    CompraPersistencia.GuardarAlQuePaga(cli);
                    CompraPersistencia.GuardarCompraEnEfectivo(cli,
                                                                viajeActual.ID,
                                                                cantEnc,
                                                                precioEncomienda,
                                                                AdministradorSesion.UsuarioActual);

                    FrmInformeDatosCompra frmInfDatosCompra = new FrmInformeDatosCompra(label16.Text,cantPas);
                    frmInfDatosCompra.ShowDialog();
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void TxtNroDoc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!(ValidadorDeTipos.IsNumeric(TxtNroDoc.Text)) && !(ValidadorDeTipos.IsEmpty(TxtNroDoc.Text)))
                    throw new Exception("El documento debe ser un número");

                if (!(ValidadorDeTipos.IsEmpty(TxtNroDoc.Text)))
                {
                    Cliente cliente = CompraPersistencia.ObtenerClientePorDoc(CmbTipoDoc.Text, Int32.Parse(TxtNroDoc.Text));
                    if (cliente != null)
                    {

                        for (int i = cliente.Direccion.Length - 1; i > 0; i--)
                        {
                            if (!ValidadorDeTipos.IsNumeric(cliente.Direccion[i].ToString()))
                            {
                                TxtNroCalle.Text = cliente.Direccion.Substring(i + 1, cliente.Direccion.Length - 1 - i);
                                TxtCalle.Text = cliente.Direccion.Substring(0, i + 1);
                                i = 0;
                            }

                        }

                        TxtApellidos.Text = cliente.Apellido;
                        TxtNombres.Text = cliente.Nombre;
                        TxtMail.Text = cliente.Mail;
                        TxtTelefono.Text = cliente.Telefono;
                        DtpFechaNac.Value = cliente.Fecha_Nacimiento;
                    }
                    else
                    {
                        TxtApellidos.Text = "";
                        TxtNombres.Text = "";
                        TxtCalle.Text = "";
                        TxtNroCalle.Text = "";
                        TxtMail.Text = "";
                        TxtTelefono.Text = "";
                        DtpFechaNac.Value = ConfiguracionDeVariables.FechaSistema;
                    }
                }
                else
                {
                    TxtApellidos.Text = "";
                    TxtNombres.Text = "";
                    TxtCalle.Text = "";
                    TxtNroCalle.Text = "";
                    TxtMail.Text = "";
                    TxtTelefono.Text = "";
                    DtpFechaNac.Value = ConfiguracionDeVariables.FechaSistema;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void TxtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Cuando presiona la tecla 'Enter', realizo el llenado automático
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    if (!(ValidadorDeTipos.IsNumeric(TxtNroDoc.Text)) && !(ValidadorDeTipos.IsEmpty(TxtNroDoc.Text)))
                        throw new Exception("El documento debe ser un número");

                    if (!(ValidadorDeTipos.IsEmpty(TxtNroDoc.Text)))
                    {
                        Cliente cliente = CompraPersistencia.ObtenerClientePorDoc(CmbTipoDoc.Text, Int32.Parse(TxtNroDoc.Text));
                        if (cliente != null)
                        {

                            for (int i = cliente.Direccion.Length - 1; i > 0; i--)
                            {
                                if (!ValidadorDeTipos.IsNumeric(cliente.Direccion[i].ToString()))
                                {
                                    TxtNroCalle.Text = cliente.Direccion.Substring(i + 1, cliente.Direccion.Length - 1 - i);
                                    TxtCalle.Text = cliente.Direccion.Substring(0, i + 1);
                                    i = 0;
                                }

                            }

                            TxtApellidos.Text = cliente.Apellido;
                            TxtNombres.Text = cliente.Nombre;
                            TxtMail.Text = cliente.Mail;
                            TxtTelefono.Text = cliente.Telefono;
                            DtpFechaNac.Value = cliente.Fecha_Nacimiento;
                        }
                        else
                        {
                            TxtApellidos.Text = "";
                            TxtNombres.Text = "";
                            TxtCalle.Text = "";
                            TxtNroCalle.Text = "";
                            TxtMail.Text = "";
                            TxtTelefono.Text = "";
                            DtpFechaNac.Value = ConfiguracionDeVariables.FechaSistema;
                        }
                    }
                    else
                    {
                        TxtApellidos.Text = "";
                        TxtNombres.Text = "";
                        TxtCalle.Text = "";
                        TxtNroCalle.Text = "";
                        TxtMail.Text = "";
                        TxtTelefono.Text = "";
                        DtpFechaNac.Value = ConfiguracionDeVariables.FechaSistema;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atención");
                }
            }
        }
    }
}
