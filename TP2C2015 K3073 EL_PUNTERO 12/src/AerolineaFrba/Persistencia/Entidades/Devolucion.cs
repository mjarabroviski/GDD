using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public class Devolucion : IMapable
    {
        public int ID { get; set; }
        public DateTime Fecha_Devolucion { get; set; }
        public String Motivo { get; set; }
        public int ID_Compra { get; set; }
        public int ID_Usuario { get; set; }

        //Implementacion de IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Devolucion
            {
                ID = Int32.Parse(reader["ID_Devolucion"].ToString()),
                Fecha_Devolucion = DateTime.Parse(reader["Fecha_Devolucion"].ToString()),
                Motivo = ((String)reader["Motivo"]).Trim(),
                ID_Compra = Int32.Parse(reader["ID_Compra"].ToString()),
                ID_Usuario = Int32.Parse(reader["ID_Usuario"].ToString())
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
