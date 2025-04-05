using app.projectCholcaByron.common.Dto;
using app.projectCholcaByron.DataAccess.repositories;
using app.projectCholcaByron.Entities.Models;
using app.projectCholcaByron.services.eventMQ;
using app.projectCholcaByron.services.Interfaces;

namespace app.projectCholcaByron.services.Implementations
{
    public class ClienteService(IClienteRepository repository, IRabbitMQService rabbitMQService) : IClienteService
    {
        private readonly IClienteRepository _repository = repository;
        private readonly IRabbitMQService _rabbitMQService = rabbitMQService;


        public async Task<BaseResponse<ClienteDto>> ActualizarEntidad(int id, ClienteDto request)
        {
            var response = new BaseResponse<ClienteDto>();
            try
            {
                Cliente cliente = new();
                cliente.Id = id;
                cliente.Nombre = request.Nombre;
                cliente.Apellido = request.Apellido;
                cliente.Email = request.Email;
                cliente.FechaNacimiento = request.FechaNacimiento;
                cliente.Fecha = DateTime.Now;
                cliente.CedulaIdentidad = request.CedulaIdentidad;

                await _repository.ActualizarEntidad(cliente);

                response.Result = new ClienteDto
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Email = cliente.Email,
                    CedulaIdentidad = cliente.CedulaIdentidad,
                    FechaNacimiento = cliente.FechaNacimiento
                };
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<BaseResponse<ClienteDto>> CrearEntidad(ClienteDto request)
        {
            var response = new BaseResponse<ClienteDto>();
            try
            {
                Cliente cliente = new();
                cliente.Nombre = request.Nombre;
                cliente.Apellido = request.Apellido;
                cliente.Email = request.Email;
                cliente.FechaNacimiento = request.FechaNacimiento;
                cliente.Fecha = DateTime.Now;
                cliente.CedulaIdentidad = request.CedulaIdentidad;

                cliente = await _repository.InsertarEntidad(cliente);

                response.Result = new ClienteDto
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Email = cliente.Email,
                    CedulaIdentidad = cliente.CedulaIdentidad,
                    FechaNacimiento = cliente.FechaNacimiento
                };
                response.Success = true;

                await _rabbitMQService.PublishMessage(response.Result, "ClienteQueue");
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<BaseResponse<string>> EliminarEntidad(int id)
        {
            var response = new BaseResponse<string>();
            try
            {
                await _repository.EliminarEntidad(id);

                response.Result = "OK";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<BaseResponse<ClienteDto>> GetEntidad(int id)
        {
            var response = new BaseResponse<ClienteDto>();
            try
            {
                var cliente = await _repository.ObtenerEntidad(id);
                if (cliente == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                response.Result = new ClienteDto
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Email = cliente.Email,
                    CedulaIdentidad = cliente.CedulaIdentidad,
                    FechaNacimiento = cliente.FechaNacimiento
                };
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<BaseResponse<List<ClienteDto>>> GetEntidadLista()
        {
            var response = new BaseResponse<List<ClienteDto>>();
            try
            {
                var result = await _repository.ObtenerEntidadesLista();
                response.Result = result.Select(cliente => new ClienteDto
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Email = cliente.Email,
                    CedulaIdentidad = cliente.CedulaIdentidad,
                    FechaNacimiento = cliente.FechaNacimiento
                }).ToList();

                if (response.Result.Count > 0)
                {
                    response.Success = true;
                    response.ErrorMessage = "Datos encontrados";
                }
                else {
                    response.Success = false;
                    response.ErrorMessage = "Datos vacios";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
