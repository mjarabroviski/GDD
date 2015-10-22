using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public class Rol : IMapable
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
        private List<Funcionalidad> _funcionalidades { get; set; }

        public List<Funcionalidad> Funcionalidades
        {
            get { return _funcionalidades ?? (_funcionalidades = FuncionalidadPersistencia.ObtenerPorRol(this)); }
            set { _funcionalidades = value; }
        }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Rol
            {
                ID = Int32.Parse(reader["ID_Rol"].ToString()),
                Descripcion = ((String)reader["Descripcion"]).Trim(),
                Habilitado = bool.Parse(reader["Habilitado"].ToString())
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
