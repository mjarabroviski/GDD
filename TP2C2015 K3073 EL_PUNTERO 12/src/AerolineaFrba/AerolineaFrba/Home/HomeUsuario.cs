using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sesion;
using AerolineaFrba.LogIn;
using AerolineaFrba.Abm_Aeronave;
using AerolineaFrba.Abm_Ciudad;
using AerolineaFrba.Abm_Rol;
using AerolineaFrba.Abm_Ruta;
using AerolineaFrba.Canje_Millas;
using AerolineaFrba.Compra;
using AerolineaFrba.Consulta_Millas;
using AerolineaFrba.Devolucion;
using AerolineaFrba.Generacion_Viaje;
using AerolineaFrba.Listado_Estadistico;
using AerolineaFrba.Registro_de_Usuario;
using AerolineaFrba.Registro_Llegada_Destino;
using Persistencia;
using Persistencia.Entidades;


namespace AerolineaFrba.Home
{
    public partial class HomeUsuario : Form
    {
        public HomeUsuario()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            SetMenuPorUsuario();
            if (AdministradorSesion.UsuarioActual != null) cambioDeContraseñaToolStripMenuItem.Visible = true;

        }

        private void SetMenuPorUsuario()
        {
            var administracion = false;
            var viajes = false;
            var atencionCliente = false;
            var listadoEstadistico = false;
            var usuario = false;

            List<Funcionalidad> funcionalidades;
            Usuario user = AdministradorSesion.UsuarioActual;

            if (AdministradorSesion.UsuarioActual != null) funcionalidades = FuncionalidadPersistencia.ObtenerFuncionalidadesPorUsuario(user); 
            else funcionalidades = FuncionalidadPersistencia.ObtenerFuncionalidadesPorNombreRol("Cliente");

            //Obtengo todas las funcionalidades asignadas al rol del usuario logueado
            foreach (var functionalidad in funcionalidades)
            {
                //Obtengo un objeto 'Funcionalidad' a partir de la descripción del rol (como aparece en la base)
                switch (Funcionalidad.ObtenerPorNombre(functionalidad.Descripcion))
                {
                    case Funcionalidades.ABM_Rol:
                        administracionDeRolesToolStripMenuItem.Visible = true;
                        administracion = true;
                        break;

                    case Funcionalidades.ABM_Aeronave:
                        asministracionDeAeronavesToolStripMenuItem.Visible = true;
                        administracion = true;
                        break;

                    case Funcionalidades.ABM_Ciudad:
                        administracionDeCiudadesToolStripMenuItem.Visible = true;
                        administracion = true;
                        break;

                    case Funcionalidades.ABM_Ruta_Aerea:
                        administracionDeRutasAereasToolStripMenuItem.Visible = true;
                        administracion = true;
                        break;

                    case Funcionalidades.Generacion_Viaje:
                        generacionDeViajeToolStripMenuItem.Visible = true;
                        viajes = true;
                        break;

                    case Funcionalidades.Registro_Llegada_Destino:
                        registroDeLlegadaADestinoToolStripMenuItem.Visible = true;
                        viajes = true;
                        break;

                    case Funcionalidades.Compra_Pasaje_Encomienda:
                        compraDePasajeEncomiendaToolStripMenuItem.Visible = true;
                        atencionCliente = true;
                        break;

                    case Funcionalidades.Devolucion_Cancelacion_Pasaje_Encomienda:
                        devolucionDePasajeYoEncomiendaToolStripMenuItem.Visible = true;
                        atencionCliente = true;
                        break;

                    case Funcionalidades.Consulta_Millas:
                        consultaDeMillasDePasajeroFrecuenteToolStripMenuItem.Visible = true;
                        atencionCliente = true;
                        break;

                    case Funcionalidades.Canje_Millas:
                        canjeDeMillasToolStripMenuItem.Visible = true;
                        atencionCliente = true;
                        break;

                    case Funcionalidades.Listado_Estadistico:
                        listadoEstadisticoToolStripMenuItem.Visible = true;
                        listadoEstadistico = true;
                        break;

                    case Funcionalidades.Registro_Usuario:
                        registroDeUsuarioToolStripMenuItem.Visible = true;
                        usuario = true;
                        break;
                }
            }

            //Si no posee ninguna funcionalidad de administración borro el menu item
            if (!administracion)
                menuHome.Items.Remove(administracionToolStripMenuItem);

            //Si no posee ninguna funcionalidad relacionadas con viajes borro el menu item
            if (!viajes)
                menuHome.Items.Remove(viajesToolStripMenuItem);

            //Si no posee ninguna funcionalidad de estadistica borro el menu item
            if (!listadoEstadistico)
                menuHome.Items.Remove(listadoEstadisticoToolStripMenuItem);

            //Si no posee ninguna funcionalidad de usuario borro el menu item
            if (!usuario)
                menuHome.Items.Remove(usuarioToolStripMenuItem);

            //Si no posee ninguna funcionalidad de atencion cliente borro el menu item
            if (!atencionCliente)
                menuHome.Items.Remove(atencionAlClienteToolStripMenuItem);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que desea cerrar sesion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                //Borro la sesión actual (Usuario y Rol logueados)
                AdministradorSesion.BorrarSesionActual();

                this.Hide();
                SeleccionDeUsuario Login = new SeleccionDeUsuario();
                Login.ShowDialog();
                Close();
            }
        }

        private void administracionDeRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var roles = new FrmABMRol();
            roles.ShowDialog();
        }

        private void administracionDeCiudadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ciudades = new ABMCiudades();
            ciudades.ShowDialog();
        }

        private void administracionDeRutasAereasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rutas = new FrmABMRuta();
            rutas.ShowDialog();
        }

        private void asministracionDeAeronavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aeronaves = new ABMAeronaves();
            aeronaves.ShowDialog();
        }

        private void generacionDeViajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var generacion = new GenercionViaje();
            generacion.ShowDialog();
        }

        private void registroDeLlegadaADestinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var registro = new RegistroLlegadaDestino();
            registro.ShowDialog();
        }

        private void compraDePasajeEncomiendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var compra = new FrmCompra();
            compra.ShowDialog();
        }

        private void registroDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var registroUsuario = new RegistroDeUsuario();
            registroUsuario.ShowDialog();
        }

        private void cambioDeContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cambio = new ResetearContrasena(AdministradorSesion.UsuarioActual);
            cambio.ShowDialog();
        }

        private void consultaDeMillasDePasajeroFrecuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var consulta = new ConsultaMillas();
            consulta.ShowDialog();
        }
    }
}
