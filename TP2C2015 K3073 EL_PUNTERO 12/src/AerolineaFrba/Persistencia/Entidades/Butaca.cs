using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public class Butaca : IMapable
    {
        public int ID { get; set; }
        public int Numero { get; set; }
        public int ID_Tipo { get; set; }
        public int Piso { get; set; }
        public int ID_Aeronave { get; set; }
        public bool Habilitado { get; set; }

        //Implementacion de IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Butaca
            {
                ID = Int32.Parse(reader["ID_Butaca"].ToString()),
                Numero = Int32.Parse(reader["Nro_Butaca"].ToString()),
                ID_Tipo = Int32.Parse(reader["ID_Tipo_Butaca"].ToString()),
                Piso = Int32.Parse(reader["Piso_Butaca"].ToString()),
                ID_Aeronave = Int32.Parse(reader["ID_Aeronave"].ToString()),
                Habilitado = bool.Parse(reader["Habilitado"].ToString())
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }      
}
