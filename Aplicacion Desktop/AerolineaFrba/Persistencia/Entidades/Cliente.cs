using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public class Cliente : IMapable
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int ID_Tipo_Documento { get; set; }
        public int Nro_Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public int Millas { get; set; }

        //Implementacion de IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Cliente
            {
                ID = Int32.Parse(reader["ID_Cliente"].ToString()),
                Nombre = ((String)reader["Nombre"]).Trim(),
                Apellido = ((String)reader["Apellido"]).Trim(),
                ID_Tipo_Documento = Int32.Parse(reader["ID_Tipo_Documento"].ToString()),
                Nro_Documento = Int32.Parse(reader["Nro_Documento"].ToString()),
                Mail = ((String)reader["Mail"]).Trim(),
                Telefono = ((String)reader["Telefono"]).Trim(),
                Direccion = ((String)reader["Direccion"]).Trim(),
                Fecha_Nacimiento = DateTime.Parse(reader["Fecha_Nacimiento"].ToString()),
                Millas = Int32.Parse(reader["Millas"].ToString())
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
