using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public class Producto : IMapable
    {
        public int ID { get; set; }
        public String Descripcion { get; set; }
        public int Stock { get; set; }
        public int Puntos { get; set; }

        //Implementacion de IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Producto
            {
                ID = Int32.Parse(reader["ID_Producto"].ToString()),
                Descripcion = ((String)reader["Descripcion"]).Trim(),
                Stock = Int32.Parse(reader["Stock"].ToString()),
                Puntos = Int32.Parse(reader["Puntos"].ToString())

            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
