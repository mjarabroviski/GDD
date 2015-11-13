using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

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

        //Valido si el dato es una matricula
        public static bool IsMatriculaValida(string value)
        {
            if (value.Length == 0 || value.Length != 7) return false;

            for (int i = 0; i < 3; i++)
            {
                char Ch = value[i];
                if (IsNumeric(Ch.ToString()) || IsDecimal(Ch.ToString()))
                {
                    return false;
                }
            }

            if (value[3] != '-') return false;

            for (int i = 4; i < 7; i++)
            {
                char Ch = value[i];
                if (!IsNumeric(Ch.ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        public static Boolean IsMailValido(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}
