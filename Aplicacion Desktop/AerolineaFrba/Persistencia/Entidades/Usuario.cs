using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public class Usuario : IMapable
    {
        public int ID { get; set; }
        private Rol rol { get; set; }
        public string Username { get; set; }
        public string Contrasena { get; set; }
        public bool Habilitado { get; set; }
        public int CantIntentos { get; set; }

        //Implementacion de IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Usuario
                {
                    ID = Int32.Parse(reader["ID_Usuario"].ToString()),
                    Username = reader["Username"].ToString(),
                    Contrasena = reader["Password"].ToString(),
                    Habilitado = bool.Parse(reader["Habilitado"].ToString()),
                    CantIntentos = int.Parse(reader["Cant_Intentos"].ToString())
                };
        }

        public Rol Rol
        {
            get { return rol ?? (rol = RolPersistencia.ObtenerRolPorUsuario(this)); }
            set { rol = value; }
        }

        public List<SPParameter> UnMap(IMapable entity) { return new List<SPParameter>(); }
    }
}
