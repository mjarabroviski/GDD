using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public class Pasaje : IMapable
    {
        public int ID { get; set; }
        public int Codigo_Pasaje { get; set; }
        public int ID_Compra { get; set; }
        public double Precio { get; set; }
        public int ID_Viaje { get; set; }
        public int ID_Butaca { get; set; }
        public int ID_Cliente { get; set; }

        public IMapable Map(SqlDataReader reader)
        {
            return new Pasaje
            {
                ID = Int32.Parse(reader["ID_Pasaje"].ToString()),
                Codigo_Pasaje = Int32.Parse(reader["Codigo_Pasaje"].ToString()),
                ID_Compra = Int32.Parse(reader["ID_Compra"].ToString()),
                Precio = double.Parse(reader["Precio"].ToString()),
                ID_Viaje = Int32.Parse(reader["ID_Viaje"].ToString()),
                ID_Butaca = Int32.Parse(reader["ID_Butaca"].ToString()),
                ID_Cliente = Int32.Parse(reader["ID_Cliente"].ToString())
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
