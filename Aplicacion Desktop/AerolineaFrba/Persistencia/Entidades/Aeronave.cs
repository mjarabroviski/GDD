using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public class Aeronave : IMapable
    {
        public int ID { get; set; }
        public string Matricula { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public int ID_Servicio { get; set; }
        public bool Baja_Fuera_De_Servicio { get; set; }
        public bool Baja_Vida_Util { get; set; }
        public DateTime Fecha_Alta { get; set; }
        public int KG_Totales { get; set; }

        //Implementacion de IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Aeronave
            {
                ID = Int32.Parse(reader["ID_Aeronave"].ToString()),
                Matricula = ((String)reader["Matricula"]).Trim(),
                Fabricante = ((String)reader["Fabricante"]).Trim(),
                Modelo = ((String)reader["Modelo"]).Trim(),
                ID_Servicio = Int32.Parse(reader["ID_Servicio"].ToString()),
                Baja_Fuera_De_Servicio = bool.Parse(reader["Baja_Por_Fuera_De_Servicio"].ToString()),
                Baja_Vida_Util = bool.Parse(reader["Baja_Por_Vida_Util"].ToString()),
                Fecha_Alta = DateTime.Parse(reader["Fecha_Alta"].ToString()),
                KG_Totales = Int32.Parse(reader["KG_Totales"].ToString())
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
