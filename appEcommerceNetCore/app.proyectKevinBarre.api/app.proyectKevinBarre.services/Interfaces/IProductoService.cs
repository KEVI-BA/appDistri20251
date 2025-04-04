using app.proyectKevinBarre.common.Dto;
using ECommerce_NetCore.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.proyectKevinBarre.services.Interfaces
{
    public interface IProductoService
    {
        Task<BaseResponse<ProductoDto>> GetProducto(int id);

        Task<BaseResponse<List<ProductoDto>>> GetProductoLista();

        Task<BaseResponse<ProductoDto>> CrearProducto(ProductoRequest request);

        Task<BaseResponse<ProductoDto>> ActualizarProducto(int id, ProductoRequest request);

        Task<BaseResponse<string>> EliminarProducto(int id);
    }
}
