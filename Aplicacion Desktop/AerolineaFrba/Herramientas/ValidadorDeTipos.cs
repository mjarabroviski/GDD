using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Persistencia
{
    public static class ValidadorDeTipos
    {
        //Valido si es un dato numerico
        public static bool IsNumeric(string value)
        {
            int i;
            return int.TryParse(value.Trim(), out i);
        }

        //Valido si es un dato decimal
        public static bool IsDecimal(string value)
        {
            double i;
            return double.TryParse(value, out i);
        }

        //Valido si el dato es la cadena vacia
        public static bool IsEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        //Valido si el dato es una fecha valida
        public static bool IsDateTime(string value)
        {
            try
            {
                var i = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
