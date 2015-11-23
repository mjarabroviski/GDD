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

namespace AerolineaFrba.Canje_Millas
{
    public partial class CantidadProducto : Form
    {
        public bool accionTerminada = false;
        public Cliente clienteActual;
        public Producto productoACanjear;
        public int cantMax;

        public CantidadProducto(Producto producto, Cliente cliente)
        {
            InitializeComponent();

            clienteActual = cliente;
            productoACanjear = producto;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                accionTerminada = false;
                Close();
            }  
        }

        private void CantidadProducto_Load(object sender, EventArgs e)
        {
            int cantPorPuntos = clienteActual.Millas / productoACanjear.Puntos;
            if (productoACanjear.Stock < cantPorPuntos) cantMax = productoACanjear.Stock;
            else cantMax = cantPorPuntos;

            for (int i = 1; i <= cantMax; i++)
            {
                cboCantidad.Items.Add(i);
            }
        }

        private void BtnCanje_Click(object sender, EventArgs e)
        {
             try
            {
                #region Validaciones

                var mensajeDeExcepcion = string.Empty;

                if (ValidadorDeTipos.IsEmpty(cboCantidad.Text))
                    mensajeDeExcepcion = "Debe ingresar una cantidad";

                if (!ValidadorDeTipos.IsEmpty(mensajeDeExcepcion))
                    throw new Exception(mensajeDeExcepcion);

                #endregion

                var msg = MessageBox.Show(string.Format("Esta seguro que desea canjear {0} {1}?", cboCantidad.Text, productoACanjear.Descripcion), "Atención", MessageBoxButtons.YesNo);
                if (msg == DialogResult.Yes)
                {
                    int modificaciones = CanjePersistencia.GenerarCanje(productoACanjear, Convert.ToInt32(cboCantidad.Text), clienteActual);
                    accionTerminada = true;
                    Close();
                }

            }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Atención");
             }
        }
    }
}
