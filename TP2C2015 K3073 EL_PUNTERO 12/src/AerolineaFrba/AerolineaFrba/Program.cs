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
            //Application.Run(new Registro_Llegada_Destino.RegistroLlegadaDestino());
            //Application.Run(new Consulta_Millas.ConsultaMillas());
            Application.Run(new LogIn.SeleccionDeUsuario());
            //Application.Run(new Compra.FrmCompra());
        }
    }
}
