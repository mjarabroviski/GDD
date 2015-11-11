using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public class TipoDocumento : IMapable
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        //Implementacion de IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new TipoDocumento
            {
                ID = Int32.Parse(reader["ID_Tipo_Documento"].ToString()),
                Descripcion = ((String)reader["Descripcion"]).Trim()
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
