using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Entidades;
using Herramientas;
using System.Data.SqlClient;

namespace Persistencia
{
    public static class TipoDocumentoPersistencia
    {
        public static List<TipoDocumento> ObtenerTodos()
        {
            //Obtengo la lista de tipos de documentos almacenadas en la base de datos
            var sp = new StoreProcedure(DBQueries.TipoDocumento.SPGetAllTipoDocumento);
            return sp.ExecuteReader<TipoDocumento>();
        }

    }
}
