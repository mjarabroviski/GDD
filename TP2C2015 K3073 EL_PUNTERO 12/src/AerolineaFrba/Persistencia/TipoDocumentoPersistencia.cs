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


        public static string ObtenerPorID(int ID_Tipo_Documento)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Tipo_Documento", ID_Tipo_Documento),
                                                
                                              };

            var sp = new StoreProcedure(DBQueries.TipoDocumento.SPObtenerTipoDocumentoPorID, param);

            List<TipoDocumento> docs = sp.ExecuteReader<TipoDocumento>();

            if (docs.Count == 0 || docs == null) return null;

            return docs[0].Descripcion;
        }
    }
}
