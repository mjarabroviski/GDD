using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Entidades
{
    public class ItemDevuelto : IMapable
    {
        public int ID { get; set; }
        public int ID_Encomienda { get; set; }
        public int ID_Pasaje { get; set; }
        public int ID_Devolucion { get; set; }

        public IMapable Map(SqlDataReader reader)
        {
                return new ItemDevuelto
                {
                    ID = Int32.Parse(reader["ID_Item_Devuelto"].ToString()),
                    ID_Encomienda = Int32.Parse(reader["ID_Encomienda"].ToString()),
                    ID_Pasaje = Int32.Parse(reader["ID_Pasaje"].ToString()),
                    ID_Devolucion = Int32.Parse(reader["ID_Devolucion"].ToString())
                };
        }


        public List<SPParameter> UnMap(IMapable entity)
        {
                return new List<SPParameter>();
        }
    }

}
