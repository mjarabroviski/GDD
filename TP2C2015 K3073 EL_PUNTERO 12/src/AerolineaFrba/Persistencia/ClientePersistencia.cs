﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Herramientas;
using System.Data.SqlClient;
using Persistencia.Entidades;


namespace Persistencia
{
    public static class ClientePersistencia
    {
        public static List<Cliente> ObtenerClientePorDNI(int doc, int tipo_Doc )
        {
            //Traigo el cliente cuyo tipo y nro de documento coincida con los parametros
            var param = new List<SPParameter> { new SPParameter("Documento", doc),
                                                new SPParameter("Tipo_Doc", tipo_Doc)
                                              };

            var sp = new StoreProcedure(DBQueries.Cliente.SPGetClientePorTipoYDocumento, param);

            List<Cliente> users = sp.ExecuteReader<Cliente>();

            return users;
        }

        public static Cliente ObtenerClientePorDNIYFechaNac(int doc, int tipo_Doc, DateTime fecha)
        {
            //Traigo el cliente cuyo tipo y nro de documento coincida con los parametros
            var param = new List<SPParameter> { new SPParameter("Documento", doc),
                                                new SPParameter("Tipo_Doc", tipo_Doc),
                                                new SPParameter("Fecha", fecha)
                                              };

            var sp = new StoreProcedure(DBQueries.Cliente.SPGetClientePorTipoYDocumentoYFechaNac, param);

            List<Cliente> users = sp.ExecuteReader<Cliente>();

            if (users.Count == 0 || users == null) return null;
                
            return users[0];
        }


        public static String ObtenerNombreClientePorID(int ID_CLIENTE)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Cliente", ID_CLIENTE),
                                                
                                              };

            var sp = new StoreProcedure(DBQueries.Cliente.SPObtenerNombreClientePorID, param);

            List<Cliente> users = sp.ExecuteReader<Cliente>();

            if (users.Count == 0 || users == null) return null;

            return users[0].Apellido.ToUpper() + " " + users[0].Nombre.ToUpper();
        }

        public static object ObtenerAuxiliares()
        {
            //Traigo los clientes de la tabla auxiliar
            var param = new List<SPParameter> { };

            var sp = new StoreProcedure(DBQueries.Cliente.SPGetClientesAuxiliares, param);

            List<ClienteAuxiliar> users = sp.ExecuteReader<ClienteAuxiliar>();

            return users;
        }

        public static ClienteAuxiliar ObtenerClientePorNombreYApellido(string p)
        {
            //Traigo el cliente cuyo nomyape coincida con los parametros
            var param = new List<SPParameter> { new SPParameter("NombreYApellido", p),
                                              };

            var sp = new StoreProcedure(DBQueries.Cliente.SPGetClientePorNombreYApellido, param);

            List<ClienteAuxiliar> users = sp.ExecuteReader<ClienteAuxiliar>();

            if (users.Count == 0 || users == null) return null;

            return users[0];
        }
    }
}
