﻿using Persistencia.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia
{
    public class ServicioPersistencia
    {
        public static List<Servicio> ObtenerTodos()
        {
            //Obtengo la lista de servicios almacenados en la base de datos
            var sp = new StoreProcedure(DBQueries.Servicio.SPGetServicios);
            return sp.ExecuteReader<Servicio>();
        }

        public static int ObtenerIDPorNombreDeServicio(string servicio)
        {
            var param = new List<SPParameter>
            {
                new SPParameter("TipoServicio",servicio),
            };

            var sp = new StoreProcedure(DBQueries.Servicio.SPObtenerIDPorNombreDeServicio, param);

            List<Servicio> servicios = sp.ExecuteReader<Servicio>();

            return servicios[0].ID_Servicio;
        }

        public static Servicio ObtenerServicioPorNombre(string servicio, SqlTransaction transaction)
        {
            var param = new List<SPParameter>{new SPParameter("TipoServicio",servicio),};
            var sp = new StoreProcedure(DBQueries.Servicio.SPObtenerServicioPorNombre, param, transaction);

            var servicios = sp.ExecuteReaderTransactioned<Servicio>(transaction);

            if (servicios == null || servicios.Count == 0)
                return null;

            return servicios[0];
        }

        public static Servicio ObtenerServicioPorID(int ID)
        {
            //Traigo el servicio cuyo id coincida con el del parametro
            var param = new List<SPParameter> { new SPParameter("ID_Servicio", ID) };
            var sp = new StoreProcedure(DBQueries.Servicio.SPGetServicioPorID, param);

            List<Servicio> servicios = sp.ExecuteReader<Servicio>();

            if (servicios == null || servicios.Count == 0)
                return null;

            return servicios[0];
        }

        public static List<Servicio> ObtenerServiciosDeRuta(int origen,int destino,string matricula)
        {
            var param = new List<SPParameter> { 
                new SPParameter("ID_Ciudad_Origen", origen),
                new SPParameter("ID_Ciudad_Destino", destino),
                new SPParameter("Matricula", matricula) };
            var sp = new StoreProcedure(DBQueries.Servicio.SPObtenerServiciosDeRuta,param);
            return sp.ExecuteReader<Servicio>();
        }
    }
}
