using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.Entidades
{
    public interface IMapable
    {
        IMapable Map(SqlDataReader reader);
        List<SPParameter> UnMap(IMapable entity);
    }
}
