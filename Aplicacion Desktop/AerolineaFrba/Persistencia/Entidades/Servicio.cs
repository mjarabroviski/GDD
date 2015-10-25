using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public class Servicio : IMapable
    {
        public int ID_Servicio { get; set; }
        public String Nombre { get; set; }
        public double Porcentaje { get; set; }

        public IMapable Map(SqlDataReader reader)
        {
            return new Servicio
            {
                ID_Servicio = Int32.Parse(reader["ID_Servicio"].ToString()),
                Nombre = ((String)reader["Nombre"]).Trim(),
                Porcentaje = double.Parse(reader["Porcentaje"].ToString())
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
