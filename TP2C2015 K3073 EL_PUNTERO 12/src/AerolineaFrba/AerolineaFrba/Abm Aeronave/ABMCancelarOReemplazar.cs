using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Persistencia;
using Persistencia.Entidades;
using Sesion;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class ABMCancelarOReemplazar : Form
    {
        public Aeronave aeronaveSeleccionada { get; set; }
        public bool accionTerminada = false;
        public bool vidaUtil = false;
        public DateTime FechaComienzo;
        public DateTime FechaReinicio;

        public ABMCancelarOReemplazar(Aeronave aeronave, Boolean vida, DateTime comienzo, DateTime fin)
        {
            InitializeComponent();
            if (vida) vidaUtil = true;
            else vidaUtil = false;
            aeronaveSeleccionada = aeronave;
            FechaComienzo = comienzo;
            FechaReinicio = fin;
        }

        private void LblCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que desea cancelar todos los pasajes y encomiendas de los viajes?", "Atención", MessageBoxButtons.YesNo);
            if (dialogAnswer == DialogResult.Yes)
            {
                //Baja por fin de vida util
                if (vidaUtil)
                {
                    DevolucionPersistencia.CancelarPasajesYEncomiendasPorBajaAeronave(aeronaveSeleccionada, "Aeronave dada de baja por fin de vida util", AdministradorSesion.UsuarioActual);
                    accionTerminada = true;
                    MessageBox.Show("Los pasajes y encomiendas de la aeronave fueron cancelados satisfactoriamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                //Baja por fuera de servicio
                else
                {
                    DevolucionPersistencia.CancelarPasajesYEncomiendasPorBajaServicioAeronave(aeronaveSeleccionada,"Aeronave dada de baja por fuera de servicio", FechaComienzo, FechaReinicio, AdministradorSesion.UsuarioActual);
                    accionTerminada = true;
                    MessageBox.Show("Los pasajes y encomiendas de la aeronave fueron cancelados satisfactoriamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }

        private void LblReemplazar_Click_1(object sender, EventArgs e)
        {
            int cant = 0;
            var dialogAnswer = MessageBox.Show("Esta seguro que desea reemplazar la aeronave?", "Atención", MessageBoxButtons.YesNo);
            if (dialogAnswer == DialogResult.Yes)
            {
                //Baja por fin de vida util
                if (vidaUtil)
                {
                    cant = AeronavePersistencia.SeleccionarAeronaveParaReemplazar(aeronaveSeleccionada);
                    if (cant == -1 || cant == 0)
                    {
                        MessageBox.Show("No existen aeronaves que puedan reemplazar a la seleccionada, debe dar de alta una nueva", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        var insertarActualizarAeronave = new ABMInsertarActualizarAeronave(aeronaveSeleccionada, false);
                        insertarActualizarAeronave.ShowDialog();
                        if (insertarActualizarAeronave.accionTerminada)
                        {
                            MessageBox.Show("La aeronave fue reemplazada por otra satisfactoriamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            accionTerminada = true;
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("La aeronave fue reemplazada satisfactoriamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        accionTerminada = true;
                        Close();
                    }
                }
                //Baja por fuera de servicio
                else
                {
                    cant = AeronavePersistencia.SeleccionarAeronaveParaReemplazarPorServicio(aeronaveSeleccionada,FechaComienzo,FechaReinicio);
                    if (cant == -1 || cant == 0)
                    {
                        MessageBox.Show("No existen aeronaves que puedan reemplazar a la seleccionada, debe dar de alta una nueva", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        var insertarActualizarAeronave = new ABMInsertarActualizarAeronave(aeronaveSeleccionada,FechaComienzo,FechaReinicio);
                        insertarActualizarAeronave.ShowDialog();

                        if (insertarActualizarAeronave.accionTerminada)
                        {
                            MessageBox.Show("La aeronave fue reemplazada por otra satisfactoriamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            accionTerminada = true;
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("La aeronave fue reemplazada satisfactoriamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        accionTerminada = true;
                        Close();
                    }
                }
            }
        }

        private void LblVolver_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                accionTerminada = false;
                Close();
            }
        }
    }
}
