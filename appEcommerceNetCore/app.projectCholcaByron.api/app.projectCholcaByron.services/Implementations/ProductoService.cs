using app.projectCholcaByron.common.Dto;
using app.projectCholcaByron.DataAccess.repositories;
using app.projectCholcaByron.Entities.Models;
using app.projectCholcaByron.services.Interfaces;

namespace app.projectCholcaByron.services.Implementations
{
    public class ProductoService(IProductoRepository repository) : IProductoService
    {
        private readonly IProductoRepository _repository = repository;

        public async Task<BaseResponse<ProductoDto>> ActualizarEntidad(int id, ProductoDto request)
        {
            var response = new BaseResponse<ProductoDto>();
            try
            {
                Producto producto = new();
                producto.Id = id;
                producto.Nombre = request.Nombre;
                producto.Descripcion = request.Descripcion;
                producto.CategoriaId = request.CategoriaId;
                producto.PrecioUnitario = request.PrecioUnitario;
                producto.Fecha = DateTime.Now;
                producto.Estado = true;

                await _repository.ActualizarEntidad(producto);

                response.Result = new ProductoDto
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    PrecioUnitario = producto.PrecioUnitario,
                    CategoriaId = producto.CategoriaId
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


        public async Task<BaseResponse<ProductoDto>> CrearEntidad(ProductoDto request)
        {
            var response = new BaseResponse<ProductoDto>();
            try
            {
                Producto producto = new();
                producto.Nombre = request.Nombre;
                producto.Descripcion = request.Descripcion;
                producto.PrecioUnitario = request.PrecioUnitario;
                producto.CategoriaId = request.CategoriaId;
                producto.Estado = true;
                producto.Fecha = DateTime.Now;
                producto = await _repository.InsertarEntidad(producto);
                response.Result = new ProductoDto
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    PrecioUnitario = producto.PrecioUnitario,
                    CategoriaId = producto.CategoriaId
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

        public async Task<BaseResponse<ProductoDto>> GetEntidad(int id)
        {
            var response = new BaseResponse<ProductoDto>();
            try
            {
                var result = await _repository.ObtenerEntidad(id);
                if (result == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                response.Result = new ProductoDto
                {
                    Id = result.Id,
                    Nombre = result.Nombre,
                    Descripcion = result.Descripcion,
                    CategoriaId = result.Id,
                    PrecioUnitario = result.PrecioUnitario
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

        public async Task<BaseResponse<List<ProductoDto>>> GetEntidadLista()
        {
            var response = new BaseResponse<List<ProductoDto>>();
            try
            {
                var result = await _repository.ObtenerEntidadesLista();
                response.Result = result.Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    PrecioUnitario = p.PrecioUnitario,
                    CategoriaId = p.CategoriaId
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
