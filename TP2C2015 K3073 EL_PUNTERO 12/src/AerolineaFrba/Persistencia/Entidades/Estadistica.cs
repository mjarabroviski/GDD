﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Persistencia.Entidades;

namespace Persistencia.Entidades
{
    public class Estadistica : IMapable
    {
        public string Parametro { get; set; }
        public double Valor { get; set; }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Estadistica
            {
                Parametro = ((String)reader["Parametro"]).Trim(),
                Valor = double.Parse(reader["Valor"].ToString())
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }


    }
}