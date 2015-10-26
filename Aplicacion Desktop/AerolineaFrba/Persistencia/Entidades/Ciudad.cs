using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public class Ciudad : IMapable
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        //Implementacion de IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Ciudad
            {
                ID = Int32.Parse(reader["ID_Ciudad"].ToString()),
                Nombre = ((String)reader["Nombre_Ciudad"]).Trim()
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
