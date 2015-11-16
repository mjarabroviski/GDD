using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public class Canje : IMapable
    {
        public int ID { get; set; }
        public int ID_Producto { get; set; }
        public int ID_Cliente { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha_Canje { get; set; }

        //Implementacion de IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Canje
            {
                ID = Int32.Parse(reader["ID_Canje"].ToString()),
                ID_Producto = Int32.Parse(reader["ID_Producto"].ToString()),
                ID_Cliente = Int32.Parse(reader["ID_Cliente"].ToString()),
                Cantidad = Int32.Parse(reader["Cantidad"].ToString()),
                Fecha_Canje = DateTime.Parse(reader["Fecha_Canje"].ToString())
                
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
