using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Configuracion
{
    public static class ConfiguracionDeVariables
    {
        public static string ConnectionString { get; set; }

        public static DateTime FechaSistema { get; set; }

        private static bool _iniciado;

        public static void Iniciar()
        {
            try
            {
                if (!_iniciado)
                {
                    //Le seteo los valores almacenados en el config a las variables globales
                    ConnectionString = ConfigurationManager.ConnectionStrings["DBStringDeConexion"].ConnectionString;
                    FechaSistema = DateTime.ParseExact(ConfigurationManager.AppSettings["FechaSistema"], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                    _iniciado = true;
                }
            }
            catch (Exception)
            {
                throw new Exception("Se produjo un error durante la lectura del archivo de configuracion.");
            }

        }
    }
}
