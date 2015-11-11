using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public class RegistroMillas: IMapable
    {
        public int ID { get; set; }
        public int ID_Cliente { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public int Codigo_Item { get; set; }
        public int Millas { get; set; }

        //Implementacion de IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new RegistroMillas
            {
                ID = Int32.Parse(reader["ID_Registro"].ToString()),
                ID_Cliente = Int32.Parse(reader["ID_Cliente"].ToString()),
                Fecha_Inicio = DateTime.Parse(reader["Fecha_Inicio"].ToString()),
                Codigo_Item = Int32.Parse(reader["Codigo_Item"].ToString()),
                Millas = Int32.Parse(reader["Millas"].ToString())
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
