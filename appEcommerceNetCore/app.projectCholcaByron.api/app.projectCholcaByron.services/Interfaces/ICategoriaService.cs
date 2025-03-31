using app.projectCholcaByron.common.Dto;
using ECommerce_NetCore.Dto.Request;

namespace app.projectCholcaByron.services.Interfaces
{
    public interface ICategoriaService
    {
        Task<BaseResponse<CategoriaDto>> GetCategoria(int id);

        Task<BaseResponse<List<CategoriaDto>>> GetCategoriaLista();

        Task<BaseResponse<CategoriaDto>> CrearCategoria(CategoriaRequest request);

        Task<BaseResponse<CategoriaDto>> ActualizarCategoria(int id, CategoriaRequest request);

        Task<BaseResponse<string>> EliminarCategoria(int id);
    }
}
