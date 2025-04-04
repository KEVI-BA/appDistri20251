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
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public Task<BaseResponse<ProductoDto>> ActualizarProducto(int id, ProductoRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<ProductoDto>> CrearProducto(ProductoRequest request)
        {
            var response = new BaseResponse<ProductoDto>();
            try
            {
                Producto productEntity = new();
                productEntity.Nombre = request.Nombre;
                productEntity.Descripcion = request.Descripcion;
                productEntity.CategoriaId = request.CategoriaId;
                productEntity.Categoria= request.Categoria;
                productEntity.PrecioUnitario = request.PrecioUnitario;


                var producto = await _repository.CreateProducto(productEntity);

                response.Result = new ProductoDto
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    CategoriaId = producto.CategoriaId,
                    Categoria = producto.Categoria,
                    PrecioUnitario = producto.PrecioUnitario
                  
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

        public Task<BaseResponse<string>> EliminarProducto(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<ProductoDto>> GetProducto(int id)
        {
            var response = new BaseResponse<ProductoDto>();
            try
            {
                var producto = await _repository.GetProducto(id);
                if (producto == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                response.Result = new ProductoDto
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                   Descripcion = producto.Descripcion,
                   CategoriaId = producto.CategoriaId,
                   Categoria = producto.Categoria,
                   PrecioUnitario = producto.PrecioUnitario
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


        public async Task<BaseResponse<List<ProductoDto>>> GetProductoLista()
        {
            var response = new BaseResponse<List<ProductoDto>>();
            try
            {
                var result = await _repository.GetProductoLista();

                response.Result = result.Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    CategoriaId = p.CategoriaId,
                    Categoria = p.Categoria,
                    PrecioUnitario = p.PrecioUnitario

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
