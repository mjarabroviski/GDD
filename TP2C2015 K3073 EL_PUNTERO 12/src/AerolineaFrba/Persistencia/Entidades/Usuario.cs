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
        public List<Rol> _Roles { get; set; }
        public string Username { get; set; }
        public string Contrasena { get; set; }
        public bool Habilitado { get; set; }
        public int CantIntentos { get; set; }

        public List<Rol> Roles
        {
            get { return _Roles ?? (_Roles = RolPersistencia.ObtenerRolesPorUsuario(this)); }
            set { _Roles = value; }
        }

        public Usuario AgregarRoles()
        {
            this._Roles = this.Roles;
            return this;
        }

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

        public List<SPParameter> UnMap(IMapable entity) { return new List<SPParameter>(); }
    }
}
