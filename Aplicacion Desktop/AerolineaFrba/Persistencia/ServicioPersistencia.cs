﻿using Persistencia.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class ServicioPersistencia
    {
        public static List<Servicio> ObtenerTodos()
        {
            //Obtengo la lista de ciudades almacenadas en la base de datos
            var sp = new StoreProcedure(DBQueries.Servicio.SPGetServicios);
            return sp.ExecuteReader<Servicio>();
        }
    }
}
