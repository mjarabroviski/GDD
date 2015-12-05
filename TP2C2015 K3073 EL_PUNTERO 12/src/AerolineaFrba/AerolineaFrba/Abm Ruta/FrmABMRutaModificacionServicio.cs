using Persistencia;
using Persistencia.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class FrmABMRutaModificacionServicio : Form
    {
        public bool modoModificacion { get; set; }

        public Ruta RutaActual { get; set; }

        public bool AccionCompleta = false;

        public FrmABMRutaModificacionServicio(Ruta ruta,bool modificacion)
        {
            InitializeComponent();
            modoModificacion = modificacion;
            RutaActual = ruta;

        }

        private void FrmABMRutaModificacionServicio_Load(object sender, EventArgs e)
        {
            LstServicios.DataSource = ServicioPersistencia.ObtenerTodos();
            LstServicios.ValueMember = "ID_Servicio";
            LstServicios.DisplayMember = "Nombre";

            if (modoModificacion)
            {
                //Obtengo la lista de servicios a partir de la ruta recibida por parametro
                var serviciosRuta = ServicioPersistencia.ObtenerServiciosPorRuta(RutaActual);

                //Marco como chequeados unicamente los servicios de la ruta
                for (int j = 0; j < LstServicios.Items.Count; j++)
                {
                    var checkboxListItem = (Servicio)LstServicios.Items[j];
                    
                    if (serviciosRuta.Any(p => p.Nombre == checkboxListItem.Nombre))
                        LstServicios.SetItemChecked(j, true);
                    else
                        LstServicios.SetItemChecked(j, false);
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (LstServicios.CheckedItems.Count == 0)
                    throw new Exception("Debe seleccionar por lo menos un servicio");

                RutaActual.Servicios = new List<Servicio>();

                //A partir de los items chequeados, seteo los servicios del objeto a insertar
                foreach (var checkedItem in LstServicios.CheckedItems)
                {
                    var servicio = (Servicio)checkedItem;
                    RutaActual.Servicios.Add(servicio);
                }

                var dialogAnswer = MessageBox.Show("Esta seguro que quiere insertar los servicios seleccionados?", "Atencion", MessageBoxButtons.YesNo);
                if (dialogAnswer == DialogResult.Yes)
                {
                    //Impacto en la base
                    if (!modoModificacion)
                        RutaPersistencia.InsertarRuta(RutaActual);
                    else RutaPersistencia.ModificarRuta(RutaActual);

                    RutaPersistencia.InsertarRutaYServicios(RutaActual);
                    AccionCompleta = true;
                    Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AccionCompleta = false;
            Close();
        }
    }
}
