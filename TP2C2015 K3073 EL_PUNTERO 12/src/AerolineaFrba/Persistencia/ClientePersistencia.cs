using System;
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

            List<Cliente> clientes = sp.ExecuteReader<Cliente>();

            return clientes;
        }

        public static Cliente ObtenerClientePorDNIYFechaNac(int doc, int tipo_Doc, DateTime fecha)
        {
            //Traigo el cliente cuyo tipo y nro de documento coincida con los parametros
            var param = new List<SPParameter> { new SPParameter("Documento", doc),
                                                new SPParameter("Tipo_Doc", tipo_Doc),
                                                new SPParameter("Fecha", fecha)
                                              };

            var sp = new StoreProcedure(DBQueries.Cliente.SPGetClientePorTipoYDocumentoYFechaNac, param);

            List<Cliente> clientes = sp.ExecuteReader<Cliente>();

            if (clientes.Count == 0 || clientes == null) return null;

            return clientes[0];
        }


        public static String ObtenerNombreClientePorID(int ID_CLIENTE)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Cliente", ID_CLIENTE),
                                                
                                              };

            var sp = new StoreProcedure(DBQueries.Cliente.SPObtenerNombreClientePorID, param);

            List<Cliente> clientes = sp.ExecuteReader<Cliente>();

            if (clientes.Count == 0 || clientes == null) return null;

            return clientes[0].Apellido.ToUpper() + " " + clientes[0].Nombre.ToUpper();
        }

        public static List<ClienteAuxiliar> ObtenerAuxiliares()
        {
            //Traigo los clientes de la tabla auxiliar
            var param = new List<SPParameter> { };

            var sp = new StoreProcedure(DBQueries.Cliente.SPGetClientesAuxiliares, param);

            List<ClienteAuxiliar> clientes = sp.ExecuteReader<ClienteAuxiliar>();

            return clientes;
        }

        public static Cliente ObtenerClientePorID(int ID)
        {
            //Traigo el cliente cuyo ID coincida con el parametro
            var param = new List<SPParameter> { new SPParameter("ID_Cliente", ID)};

            var sp = new StoreProcedure(DBQueries.Cliente.SPGetClientePorID, param);

            List<Cliente> clientes = sp.ExecuteReader<Cliente>();

            if (clientes.Count == 0 || clientes == null) return null;

            return clientes[0];
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

        public static int ElClienteYaEstaDeViaje(int tipoDoc, int nroDoc, int viajeID,string ape)
        {
            var param = new List<SPParameter> { new SPParameter("Documento", nroDoc),
                                                new SPParameter("Tipo_Doc", tipoDoc),
                                                new SPParameter("ID_Viaje",viajeID),
                                                new SPParameter("Apellido",ape)
                                              };

            var sp = new StoreProcedure(DBQueries.Cliente.SPGetClienteEnViaje, param);

            List<Pasaje> pasajes = sp.ExecuteReader<Pasaje>();

            if (pasajes.Count == 0 || pasajes == null) return 0;

            return pasajes.Count;
        }
    }
}
