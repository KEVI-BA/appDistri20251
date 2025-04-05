using app.projectCholcaByron.common.Dto;
using ECommerce_NetCore.Dto.Request;

namespace app.projectCholcaByron.services.Interfaces
{
    public interface IProductoService
    {
        Task<BaseResponse<ProductoDto>> GetEntidad(int id);

        Task<BaseResponse<List<ProductoDto>>> GetEntidadLista();

        Task<BaseResponse<ProductoDto>> CrearEntidad(ProductoDto request);

        Task<BaseResponse<ProductoDto>> ActualizarEntidad(int id, ProductoDto request);

        Task<BaseResponse<string>> EliminarEntidad(int id);
    }
}
