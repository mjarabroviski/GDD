using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using Persistencia.Entidades;

namespace Sesion
{    
    public class AdministradorSesion
    {
        //Usuario logueado
        public static Usuario UsuarioActual { get; set; }

        public static void BorrarSesionActual()
        {
            //Borro los datos del ultimo acceso
            AdministradorSesion.UsuarioActual = null;
        }

    }
}
