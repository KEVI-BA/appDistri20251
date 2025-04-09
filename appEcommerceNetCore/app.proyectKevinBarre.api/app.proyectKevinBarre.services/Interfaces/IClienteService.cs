using app.proyectKevinBarre.common.Dto;
using ECommerce_NetCore.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.proyectKevinBarre.services.Interfaces
{
    public interface IClienteService
    {
       
        Task<BaseResponse<ClienteDto>> GetCliente(int id);

        Task<BaseResponse<List<ClienteDto>>> GetClienteLista();

        Task<BaseResponse<ClienteDto>> CrearCliente(ClienteRequest request);

        Task<BaseResponse<ClienteDto>> ActualizarCliente(int id, ClienteRequest request);

    }
}
