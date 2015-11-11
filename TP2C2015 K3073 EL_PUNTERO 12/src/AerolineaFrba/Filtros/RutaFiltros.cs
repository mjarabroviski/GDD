using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtros
{
    public class RutaFiltros
    {
        public int? Codigo { get; set; }
        public string TipoServicio { get; set; }
        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        public double? PrecioDesdeKg { get; set; }
        public double? PrecioHastaKg { get; set; }
        public double? PrecioDesdePasaje { get; set; }
        public double? PrecioHastaPasaje { get; set; }

    }
}
