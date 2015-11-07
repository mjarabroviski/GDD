using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public class Funcionalidad : IMapable
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        //Implementacion de IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Funcionalidad
                {
                    ID = int.Parse(reader["ID_Funcionalidad"].ToString()),
                    Descripcion = reader["Descripcion"].ToString()
                };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }

        public static Funcionalidades? ObtenerPorNombre (string func)
        {
            if (func == "ABM de Rol") return Funcionalidades.ABM_Rol;
            if (func == "Registro de Usuario") return Funcionalidades.Registro_Usuario;
            if (func == "ABM de Ciudad") return Funcionalidades.ABM_Ciudad;
            if (func == "ABM de Ruta Aerea") return Funcionalidades.ABM_Ruta_Aerea;
            if (func == "ABM de Aeronave") return Funcionalidades.ABM_Ruta_Aerea;
            if (func == "Generacion de Viaje") return Funcionalidades.Generacion_Viaje;
            if (func == "Registro de Llegada a Destino") return Funcionalidades.Registro_Llegada_Destino;
            if (func == "Compra de pasaje/encomienda") return Funcionalidades.Compra_Pasaje_Encomienda;
            if (func == "Devolucion/Cancelacion de pasaje/encomienda") return Funcionalidades.Devolucion_Cancelacion_Pasaje_Encomienda;
            if (func == "Consulta de millas de pasajero frecuente") return Funcionalidades.Consulta_Millas;
            if (func == "Canje de Millas") return Funcionalidades.Canje_Millas;
            if (func == "Listado Estadistico") return Funcionalidades.Listado_Estadistico;

            return null;
        }
    }

    public enum Funcionalidades
    {
        ABM_Rol,
        Registro_Usuario,
        ABM_Ciudad,
        ABM_Ruta_Aerea,
        ABM_Aeronave,
        Generacion_Viaje,
        Registro_Llegada_Destino,
        Compra_Pasaje_Encomienda,
        Devolucion_Cancelacion_Pasaje_Encomienda,
        Consulta_Millas,
        Canje_Millas,
        Listado_Estadistico
    }
}
