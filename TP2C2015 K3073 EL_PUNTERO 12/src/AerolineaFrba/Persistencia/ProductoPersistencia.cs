﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using Persistencia.Entidades;

namespace Persistencia
{
    public static class ProductoPersistencia
    {
        public static List<Producto> ObtenerTodos()
        {
            //Obtengo la lista de productos almacenadas en la base de datos
            var sp = new StoreProcedure(DBQueries.Producto.SPGetProductos);
            return sp.ExecuteReader<Producto>();
        }

        public static List<Producto> ObtenerLosPosiblesParaUnCliente(Cliente cliente)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Cliente", cliente.ID)
                };
            var sp = new StoreProcedure(DBQueries.Producto.SPObtenerProductosParaUnCliente, param);
            List<Producto> productos = sp.ExecuteReader<Producto>();

            if (productos == null || productos.Count == 0)
                return null;

            return productos;
        }

    }
}