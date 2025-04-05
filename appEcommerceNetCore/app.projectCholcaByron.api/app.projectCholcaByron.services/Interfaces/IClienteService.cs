using app.projectCholcaByron.common.Dto;

namespace app.projectCholcaByron.services.Interfaces
{
    public interface IClienteService
    {
        Task<BaseResponse<ClienteDto>> GetEntidad(int id);

        Task<BaseResponse<List<ClienteDto>>> GetEntidadLista();

        Task<BaseResponse<ClienteDto>> CrearEntidad(ClienteDto request);

        Task<BaseResponse<ClienteDto>> ActualizarEntidad(int id, ClienteDto request);

        Task<BaseResponse<string>> EliminarEntidad(int id);
    }
}
