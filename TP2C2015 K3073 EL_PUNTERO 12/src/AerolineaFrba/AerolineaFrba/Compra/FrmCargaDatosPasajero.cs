﻿using Persistencia;
using Persistencia.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Compra
{
    public partial class FrmCargaDatosPasajero : Form
    {
        public FrmIngresoCantidades formularioAnterior;
        public Viaje viajeActual;
        public int ordenPasaje;
        public decimal cantPasajesActual;
        public decimal cantEncomiendasActual;
        public List<Butaca> ListaButacas = new List<Butaca>();
        public Butaca butacaSeleccionada;

        public FrmCargaDatosPasajero(Viaje viaje,decimal cantPasajes,decimal cantEncomiendas,FrmIngresoCantidades ingresoCantidades,int nroOrdenPasaje)
        {
            formularioAnterior = ingresoCantidades;
            formularioAnterior.Visible = false;
            InitializeComponent();
            ordenPasaje = nroOrdenPasaje;
            cantPasajesActual = cantPasajes;
            cantEncomiendasActual = cantEncomiendas;
            viajeActual = viaje;
            if (ordenPasaje <= cantPasajes && ordenPasaje > 0)
            {
                LblNroPasajero.Text = "#" + ordenPasaje;
                ordenPasaje++;
            }
            else
            {
                this.Visible = false;
                //Cargar el formulario de datos del pago
            }

           
        }

        private void FrmCargaDatosPasajero_Load(object sender, EventArgs e)
        {
            CmbTipoDoc.DataSource = TipoDocumentoPersistencia.ObtenerTodos();
            CmbTipoDoc.ValueMember = "ID";
            CmbTipoDoc.DisplayMember = "Descripcion";

            TxtNroDoc.Select();
            DtpFechaNac.MaxDate = DateTime.Now;

            if (ordenPasaje == cantPasajesActual+1)
            {
                BtnSiguiente.Text = "FINALIZAR CARGA";
            }

            CargarDgvButacas();
            DgvButacas.CurrentCell = DgvButacas.Rows[0].Cells[1];
        }

        private void CargarDgvButacas()
        {
            var diccionarioDeButacas = new Dictionary<int, Butaca>();

            #region Cargar el diccionario a mostrar en la grilla

            ListaButacas = ButacaPersistencia.ObtenerTodasLasLibresDeAeronave(viajeActual);
            diccionarioDeButacas = ListaButacas.ToDictionary(a => a.ID, a => a);

            //Muestra en la grilla el contenido de las butacas que se encuentran cargados en el diccionario
            var bind = diccionarioDeButacas.Values.Select(a => new
            {
                ID = a.ID,
                Numero = a.Numero,
                Tipo = TipoButacaPersistencia.ObtenerTipoButaca(a).Descripcion,
                Piso = a.Piso
            });

            #endregion

            DgvButacas.DataSource = bind.ToList();
            DgvButacas.Columns[0].Visible = false;

            DgvButacas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                var mensajeExcepcion = string.Empty;

                #region Validaciones

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

                #endregion

                butacaSeleccionada = ListaButacas.Find(b => (b.ID == (int)DgvButacas.CurrentRow.Cells[0].Value));

                //MessageBox.Show(string.Format("{0}",butacaSeleccionada.Numero), "Atención");
                
                
                CompraPersistencia.CargarTablaDatosPasajeros(CmbTipoDoc.Text,
                                                             Int32.Parse(TxtNroDoc.Text),
                                                             TxtApellidos.Text,
                                                             TxtNombres.Text,
                                                             TxtCalle.Text,
                                                             TxtNroCalle.Text,
                                                             Int32.Parse(TxtTelefono.Text),
                                                             DtpFechaNac.Value,
                                                             TxtMail.Text,
                                                             butacaSeleccionada.ID);
                
                

                if (ordenPasaje <= cantPasajesActual)
                {
                    var nuevoFormulario = new FrmCargaDatosPasajero(viajeActual, cantPasajesActual, cantEncomiendasActual, formularioAnterior, ordenPasaje);
                    this.Visible = false;
                    nuevoFormulario.ShowDialog();
                }
                else
                {
                    this.Visible = false;
                    //Cargar el formulario de datos del pago
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show(string.Format("Esta seguro que desea cancelar?"), "Atención", MessageBoxButtons.YesNo);
            if (dialogAnswer == DialogResult.Yes)
            {
                CompraPersistencia.BorrarTablaAuxiliar();
                formularioAnterior.Visible = true;
                this.Visible = false;
            }
        }

        private void TxtNroDoc_Leave(object sender, EventArgs e)
        {
            if (!(ValidadorDeTipos.IsEmpty(TxtNroDoc.Text)))
            {
                Cliente cliente = CompraPersistencia.ObtenerClientePorDoc(CmbTipoDoc.Text, Int32.Parse(TxtNroDoc.Text));
                if (cliente != null)
                {
                    string[] split = cliente.Direccion.Split(new Char [] {'0','1','2','3','4','5','6','7','8','9'});
                    TxtCalle.Text = split[0];
                    //TODO Arreglar el split para el nro de la calle

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
                    DtpFechaNac.Value = DateTime.Today;
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
                DtpFechaNac.Value = DateTime.Today;
            }
        }
    }
}
