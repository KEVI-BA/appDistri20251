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
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<CategoriaDto>> ActualizarCategoria(int id, CategoriaRequest request)
        {
            var response = new BaseResponse<CategoriaDto>();
            try
            {

                var categoria = await _repository.GetCategoria(id);
                if (categoria == null)
                {
                    response.Success = false;
                    response.ErrorMessage = $"No se encontró la categoría con ID {id}";
                    return response;
                }

                
                categoria.Nombre = request.Nombre;
                categoria.Descripcion = request.Descripcion;

                await _repository.UpdateCategoria(categoria); 
                response.Result = new CategoriaDto
                {
                    Id = categoria.Id,
                    Nombre = categoria.Nombre,
                    Descripcion = categoria.Descripcion
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

        public async Task<BaseResponse<CategoriaDto>> CrearCategoria(CategoriaRequest request)
        {
            var response = new BaseResponse<CategoriaDto>();
            try
            {
                Categoria categoryEntity = new();
                categoryEntity.Nombre = request.Nombre;
                categoryEntity.Descripcion = request.Descripcion;

                var categoria = await _repository.CreateCategoria(categoryEntity);

                response.Result = new CategoriaDto
                {
                    Id = categoria.Id,
                    Nombre = categoria.Nombre,
                    Descripcion = categoria.Descripcion
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

        public async Task<BaseResponse<CategoriaDto>> EliminarCategoria(int id)
        {
            var response = new BaseResponse<CategoriaDto>();

            try
            {
                var categoria = await _repository.GetCategoria(id); 
                if (categoria == null)
                {
                    response.Success = false;
                    response.ErrorMessage = $"No se encontró la categoría con ID {id}";
                    return response;
                }

                categoria.Estado = false;

                await _repository.DeleteCategoria(id);
                response.Result = new CategoriaDto
                {
                    Id = categoria.Id,
                    Nombre = categoria.Nombre,
                    Descripcion = categoria.Descripcion
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

        public async Task<BaseResponse<CategoriaDto>> GetCategoria(int id)
        {
            var response = new BaseResponse<CategoriaDto>();
            try
            {
                var categoria = await _repository.GetCategoria(id);
                if (categoria == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                response.Result = new CategoriaDto
                {
                    Id = categoria.Id,
                    Nombre = categoria.Nombre,
                    Descripcion = categoria.Descripcion
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


        public async Task<BaseResponse<List<CategoriaDto>>> GetCategoriaLista()
        {
            var response = new BaseResponse<List<CategoriaDto>>();
            try
            {
                var result = await _repository.GetCategoriaLista();

                response.Result = result.Select(p => new CategoriaDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion
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
