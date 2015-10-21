using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Configuracion;

namespace Persistencia.Entidades
{
    public class DBManager
    {
        private SqlConnection _connection;

        public SqlConnection Connection
        {
            get
            {
                if (_connection.State != ConnectionState.Open)
                    OpenConnection();

                return _connection;
            }
        }

        /*
         * Constructor private -> Singleton.
         * Se instancia solo una vez, para mantener siempre la misma conexion a la DB.
         */
        private DBManager()
        {
            OpenConnection();
        }

        private void OpenConnection()
        {
            try
            {
                //Abro la conexion
                _connection = new SqlConnection(ConfiguracionDeVariables.ConnectionString);
                _connection.Open();
            }
            catch
            {
                throw new Exception("Error iniciando la conexion con la base de datos.");
            }
        }

        private static DBManager _dBManager;

        public static DBManager Instance()
        {
            return _dBManager ?? (_dBManager = new DBManager());
        }

        public void CloseConnection()
        {
            _connection.Close();
        }
    }
}
