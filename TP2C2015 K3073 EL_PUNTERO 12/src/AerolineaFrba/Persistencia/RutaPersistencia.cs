using Filtros;
using Persistencia.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class RutaPersistencia
    {
        public static List<Ruta> ObtenerTodas()
        {
            //Obtengo la lista de rutas almacenadas en la base de datos
            var sp = new StoreProcedure(DBQueries.Ruta.SPGetAllRutas);
            return sp.ExecuteReader<Ruta>();
        }

        public static String ObtenerServicioPorID(int idServicio)
        {
            //Obtengo el servicio
            var param = new List<SPParameter> { new SPParameter("ID_Servicio", idServicio) };
            var sp = new StoreProcedure(DBQueries.Ruta.SPGetServicioPorID, param);

            //Retorno una lista de Servicios a partir de un ExecuteReader
            List<Servicio> servicios = sp.ExecuteReader<Servicio>();

            if (servicios == null || servicios.Count == 0)
                return null;

            return servicios[0].Nombre;
        }

        public static String ObtenerCiudadPorID(int idCiudad)
        {
            //Obtengo la ciudad
            var param = new List<SPParameter> { new SPParameter("ID_Ciudad", idCiudad) };
            var sp = new StoreProcedure(DBQueries.Ruta.SPGetCiudadPorID, param);

            //Retorno una lista de Ciudades a partir de un ExecuteReader
            List<Ciudad> ciudades = sp.ExecuteReader<Ciudad>();

            if (ciudades == null || ciudades.Count == 0)
                return null;

            return ciudades[0].Nombre;
        }

        public static List<Ruta> ObtenerRutasPorParametros(RutaFiltros filtros)
        {
            var param = new List<SPParameter>
            { 
                new SPParameter("Codigo_Ruta", filtros.Codigo ?? (object)DBNull.Value),
                new SPParameter("Ciudad_Origen", filtros.CiudadOrigen ?? (object)DBNull.Value),
                new SPParameter("Ciudad_Destino", filtros.CiudadDestino ?? (object)DBNull.Value),
                new SPParameter("Desde_Kg", filtros.PrecioDesdeKg ?? (object)DBNull.Value),
                new SPParameter("Hasta_Kg", filtros.PrecioHastaKg ?? (object)DBNull.Value),
                new SPParameter("Desde_Pasaje", filtros.PrecioDesdePasaje ?? (object)DBNull.Value),
                new SPParameter("Hasta_Pasaje", filtros.PrecioHastaPasaje ?? (object)DBNull.Value),
                new SPParameter("Tipo_Servicio", filtros.TipoServicio ?? (object)DBNull.Value),
            };

            var sp = new StoreProcedure(DBQueries.Ruta.SPFiltrarRutas, param);

            return sp.ExecuteReader<Ruta>();
        }


        public static void InsertarRuta(Ruta ruta)
        {
            /* 
             * Lo tengo que hacer transaccionado ya que no quiero que pueda llegar a quedar una ruta insertada
             * por la mitad debido a un error
             */
            using (var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    ruta = Insertar(ruta, transaccion);
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw new Exception("Se produjo un error durante la insercion de la ruta");
                }
            }
        }

        private static Ruta Insertar(Ruta ruta, SqlTransaction transaccion)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Codigo", ruta.Codigo_Ruta), 
                    new SPParameter("ID_Ciudad_Destino", ruta.ID_Ciudad_Destino),
                    new SPParameter("ID_Ciudad_Origen", ruta.ID_Ciudad_Origen),
                    //new SPParameter("ID_Servicio", ruta.ID_Servicio),
                    new SPParameter("Precio_Base_KG", ruta.Precio_Base_KG),
                    new SPParameter("Precio_Base_Pasaje", ruta.Precio_Base_Pasaje),
                    new SPParameter("Habilitado", ruta.Habilitado)
                };

            var sp = (transaccion != null)
                        ? new StoreProcedure(DBQueries.Ruta.SPInsertarRuta, param, transaccion)
                        : new StoreProcedure(DBQueries.Ruta.SPInsertarRuta, param);

            ruta.ID = (int)sp.ExecuteScalar(transaccion);

            return ruta;
        }

        public static void ModificarRuta(Ruta ruta)
        {
            /* 
             * Lo tengo que hacer transaccionado ya que no quiero que pueda llegar a quedar una ruta insertada
             * por la mitad debido a un error
             */
            using (var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    Modificar(ruta, transaccion);
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw new Exception("Se produjo un error durante la modificacion de la ruta");
                }
            }
        }

        private static int Modificar(Ruta ruta, SqlTransaction transaccion)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Ruta",ruta.ID),
                    new SPParameter("Codigo", ruta.Codigo_Ruta), 
                    new SPParameter("ID_Ciudad_Destino", ruta.ID_Ciudad_Destino),
                    new SPParameter("ID_Ciudad_Origen", ruta.ID_Ciudad_Origen),
                    //new SPParameter("ID_Servicio", ruta.ID_Servicio),
                    new SPParameter("Precio_Base_KG", ruta.Precio_Base_KG),
                    new SPParameter("Precio_Base_Pasaje", ruta.Precio_Base_Pasaje),
                    new SPParameter("Habilitado", ruta.Habilitado)
                };

            var sp = (transaccion != null)
                        ? new StoreProcedure(DBQueries.Ruta.SPModificarRuta, param, transaccion)
                        : new StoreProcedure(DBQueries.Ruta.SPModificarRuta, param);

            return sp.ExecuteNonQuery(transaccion);
        }

        public static void CancelarPasajesYEncomiendasConRutaInhabilitada(Ruta ruta, String motivo, Usuario usuario)
        {
            using (var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    Cancelar(ruta, motivo, usuario, transaccion);
                    transaccion.Commit();

                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw new Exception("Se produjo un error durante la cancelación de pasajes y encomiendas");
                }
            }
        }

        private static int Cancelar(Ruta ruta, String motivo, Usuario usuario, SqlTransaction transaccion)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Ruta",ruta.ID),
                    new SPParameter("Motivo",motivo),
                    new SPParameter("ID_Usuario",usuario.ID)
                };
            
            var sp = (transaccion != null)
                        ? new StoreProcedure(DBQueries.Ruta.SPCancelarPasajesYEncomiendasConRutaInhabilitada, param, transaccion)
                        : new StoreProcedure(DBQueries.Ruta.SPCancelarPasajesYEncomiendasConRutaInhabilitada, param);
            
            return sp.ExecuteNonQuery(transaccion);
        }

        public static List<Ciudad> ObtenerTodasLasCiudadesConOrigen(int ID_Origen)
        {
            //Obtengo la lista de destinos de un determinado origen
            var param = new List<SPParameter> { new SPParameter("ID_Origen", ID_Origen) };
            var sp = new StoreProcedure(DBQueries.Ruta.SPObtenerTodasLasCiudadesConOrigen, param);
            return sp.ExecuteReader<Ciudad>();
        }

        public static List<Ruta> ObtenerRutaPorOrigenYDestino(int ID_Origen, int ID_Destino)
        {
            var param = new List<SPParameter>
            { 
                new SPParameter("ID_Ciudad_Origen", ID_Origen),
                new SPParameter("ID_Ciudad_Destino", ID_Destino),
            };
            var sp = new StoreProcedure(DBQueries.Ruta.SPObtenerRutaPorOrigenYDestino, param);
            return sp.ExecuteReader<Ruta>();
        }

        public static List<Servicio> ObtenerServiciosPorIDRuta(int ID_Ruta)
        {
            var param = new List<SPParameter>
            { 
                new SPParameter("ID_Ruta",ID_Ruta)
            };

            var sp = new StoreProcedure(DBQueries.Ruta.SPServiciosPorIDRuta, param);

            List<Servicio> servicios = sp.ExecuteReader<Servicio>();

            if (servicios == null || servicios.Count == 0)
                return null;

            return servicios;
        }

    }
}
