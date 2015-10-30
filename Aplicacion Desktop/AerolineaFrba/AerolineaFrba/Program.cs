using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Configuracion;

namespace AerolineaFrba
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfiguracionDeVariables.Iniciar();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Abm_Ciudad.ABMCiudades());
            Application.Run(new Abm_Aeronave.ABMAeronaves());
            //Application.Run(new Registro_de_Usuario.RegistroDeUsuario());
            //Application.Run(new Abm_Rol.FrmABMRol());
            //Application.Run(new Abm_Ruta.FrmABMRuta());
        }
    }
}
