using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectCholcaByron.common.Dto;
using app.projectCholcaByron.DataAccess.repositories;
using app.projectCholcaByron.Entities.Models;
using app.projectCholcaByron.services.Interfaces;
using ECommerce_NetCore.Dto.Request;

namespace app.projectCholcaByron.services.Implementations
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public Task<BaseResponse<CategoriaDto>> ActualizarCategoria(int id, CategoriaRequest request)
        {
            throw new NotImplementedException();
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

        public Task<BaseResponse<string>> EliminarCategoria(int id)
        {
            throw new NotImplementedException();
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
