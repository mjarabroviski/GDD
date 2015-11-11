using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public class Ruta : IMapable
    {
        public int ID { get; set; }
        public int Codigo_Ruta { get; set; }
        public int ID_Servicio { get; set; }
        public int ID_Ciudad_Origen { get; set; }
        public int ID_Ciudad_Destino { get; set; }
        public double Precio_Base_KG { get; set; }
        public double Precio_Base_Pasaje { get; set; }
        public bool Habilitado { get; set; }


        public IMapable Map(SqlDataReader reader)
        {
            bool hab;
            if (reader["Habilitado"].ToString() == "1") hab = true;
            else hab = false;
            return new Ruta
            {
                ID = Int32.Parse(reader["ID_Ruta"].ToString()),
                Codigo_Ruta = Int32.Parse(reader["Codigo_Ruta"].ToString()),
                ID_Servicio = Int32.Parse(reader["ID_Servicio"].ToString()),
                ID_Ciudad_Origen = Int32.Parse(reader["ID_Ciudad_Origen"].ToString()),
                ID_Ciudad_Destino = Int32.Parse(reader["ID_Ciudad_Destino"].ToString()),
                Precio_Base_KG = double.Parse(reader["Precio_Base_KG"].ToString()),
                Precio_Base_Pasaje = double.Parse(reader["Precio_Base_Pasaje"].ToString()),
                Habilitado = hab
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
