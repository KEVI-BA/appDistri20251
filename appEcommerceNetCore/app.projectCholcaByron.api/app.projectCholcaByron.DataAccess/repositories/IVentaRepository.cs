﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectCholcaByron.Entities.Models;

namespace app.projectCholcaByron.DataAccess.repositories
{
    public interface IVentaRepository
    {
        Task<Venta> InsertarEntidad(Venta entity);

        Task EliminarEntidad(int id);

        Task<Venta> ObtenerEntidad(int id);

        Task<List<Venta>> ObtenerEntidadesLista();

        Task ActualizarEntidad(Venta entity);
    }
}
