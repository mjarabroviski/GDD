using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public class Encomienda : IMapable
    {
        public int ID { get; set; }
        public int Codigo_Encomienda { get; set; }
        public int ID_Compra { get; set; }
        public double Precio { get; set; }
        public int ID_Viaje { get; set; }
        public int KG { get; set; }

        public IMapable Map(SqlDataReader reader)
        {
            return new Encomienda
            {
                ID = Int32.Parse(reader["ID_Encomienda"].ToString()),
                Codigo_Encomienda = Int32.Parse(reader["Codigo_Encomienda"].ToString()),
                ID_Compra = Int32.Parse(reader["ID_Compra"].ToString()),
                Precio = double.Parse(reader["Precio"].ToString()),
                ID_Viaje = Int32.Parse(reader["ID_Viaje"].ToString()),
                KG = Int32.Parse(reader["KG"].ToString())
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}

