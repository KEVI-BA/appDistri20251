﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectCholcaByron.Entities.Models;

namespace app.projectCholcaByron.DataAccess.repositories
{
    public interface IProductoRepository
    {
        Task<Producto> InsertarEntidad(Producto entity);

        Task EliminarEntidad(int id);

        Task<Producto> ObtenerEntidad(int id);

        Task<List<Producto>> ObtenerEntidadesLista();

        Task ActualizarEntidad(Producto entity);
    }
}
