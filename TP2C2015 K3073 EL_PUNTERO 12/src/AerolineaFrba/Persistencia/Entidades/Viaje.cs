using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public class Viaje : IMapable
    {
        public int ID { get; set; }
        public int ID_Aeronave { get; set; }
        public int ID_Ruta { get; set; }
        public DateTime Fecha_Salida { get; set; }
        public DateTime Fecha_Llegada { get; set; }
        public DateTime Fecha_Llegada_Estimada { get; set; }

        //Implementacion de IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Viaje
            {
                ID = Int32.Parse(reader["ID_Viaje"].ToString()),
                ID_Aeronave = Int32.Parse(reader["ID_Aeronave"].ToString()),
                ID_Ruta = Int32.Parse(reader["ID_Ruta"].ToString()),
                Fecha_Salida = DateTime.Parse(reader["Fecha_Salida"].ToString()),
                Fecha_Llegada = traerFechaLlegada(reader["Fecha_Llegada"].ToString()),
                Fecha_Llegada_Estimada = DateTime.Parse(reader["Fecha_Llegada_Estimada"].ToString())
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }

        public DateTime traerFechaLlegada(string fecha)
        {
            if (fecha == "") return DateTime.MinValue;
            return DateTime.Parse(fecha);
        }
    }
}
