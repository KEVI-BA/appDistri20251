using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.proyectKevinBarre.accessData.repositories;
using app.proyectKevinBarre.common.Dto;
using app.proyectKevinBarre.entities.Models;
using app.proyectKevinBarre.services.Interfaces;
using ECommerce_NetCore.Dto.Request;

namespace app.proyectKevinBarre.services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public Task<BaseResponse<ClienteDto>> ActualizarCliente(int id, ClienteRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<ClienteDto>> CrearCliente(ClienteRequest request)
        {
            var response = new BaseResponse<ClienteDto>();
            try
            {
                Cliente categoryEntity = new();
                categoryEntity.Nombre = request.Nombre;
                categoryEntity.Apellido = request.Apellido;
                categoryEntity.Email = request.Email;
                categoryEntity.FechaNacimiento = request.FechaNacimiento;
                categoryEntity.CedulaIdentidad = request.CedulaIdentidad;
                

                var cliente = await _repository.CreateCliente(categoryEntity);

                response.Result = new ClienteDto
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Email = cliente.Email,
                    FechaNacimiento = cliente.FechaNacimiento,
                    CedulaIdentidad = cliente.CedulaIdentidad,
                    
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

        public Task<BaseResponse<string>> EliminarCliente(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<ClienteDto>> GetCliente(int id)
        {
            var response = new BaseResponse<ClienteDto>();
            try
            {
                var cliente = await _repository.GetCliente(id);
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
                    FechaNacimiento = cliente.FechaNacimiento,
                    CedulaIdentidad = cliente.CedulaIdentidad,
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


        public async Task<BaseResponse<List<ClienteDto>>> GetClienteLista()
        {
            var response = new BaseResponse<List<ClienteDto>>();
            try
            {
                var result = await _repository.GetClienteLista();

                response.Result = result.Select(p => new ClienteDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    Email = p.Email,
                    FechaNacimiento = p.FechaNacimiento,
                    CedulaIdentidad = p.CedulaIdentidad,

                }).ToList();
                response.Success = true;
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
