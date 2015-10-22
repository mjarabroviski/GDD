using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Entidades
{
    public static class DBQueries
    {
        public static class Rol
        {
            public static String SPGetRoles = "EL_PUNTERO.GetRoles";
        }

        public static class Funcionalidad
        {
            public static String SPGetFuncionalidades = "EL_PUNTERO.GetFuncionalidades";
            public static String SPGetFuncionalidadesPorRol = "EL_PUNTERO.GetAFuncionalidadesPorRol";
        }
    }
}
