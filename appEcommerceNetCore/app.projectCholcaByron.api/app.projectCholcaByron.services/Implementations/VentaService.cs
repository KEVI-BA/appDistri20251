using app.projectCholcaByron.common.Dto;
using app.projectCholcaByron.DataAccess.repositories;
using app.projectCholcaByron.Entities.Models;
using app.projectCholcaByron.services.Interfaces;

namespace app.projectCholcaByron.services.Implementations
{
    public class VentaService : IVentaService
    {

        private readonly IVentaRepository _repository;

        public VentaService(IVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<VentaDto>> ActualizarEntidad(int id, VentaDto request)
        {
            var response = new BaseResponse<VentaDto>();
            try
            {
                Venta venta = new();
                venta.Id = id;
                venta.ClienteId = request.ClienteId;
                venta.FechaVenta = DateTime.Now;
                venta.NumeroFactura = request.NumeroFactura;
                venta.MetodoPago = request.MetodoPago;
                venta.Fecha = DateTime.Now;
                venta.Estado = true;

                await _repository.ActualizarEntidad(venta);

                response.Result = new VentaDto
                {
                    Id = venta.Id,
                    ClienteId = venta.ClienteId,
                    FechaVenta = venta.FechaVenta,
                    NumeroFactura = venta.NumeroFactura,
                    MetodoPago = venta.MetodoPago
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

        public async Task<BaseResponse<VentaDto>> CrearEntidad(VentaDto request)
        {
            var response = new BaseResponse<VentaDto>();
            try
            {
                Venta venta = new();
                venta.Id = request.Id;
                venta.ClienteId = request.ClienteId;
                venta.FechaVenta = DateTime.Now;
                venta.NumeroFactura = request.NumeroFactura;
                venta.MetodoPago = request.MetodoPago;
                venta.Fecha = DateTime.Now;
                venta.Estado = true;

                venta = await _repository.InsertarEntidad(venta);
                response.Result = new VentaDto
                {
                    Id = venta.Id,
                    ClienteId = venta.ClienteId,
                    FechaVenta = venta.FechaVenta,
                    NumeroFactura = venta.NumeroFactura,
                    MetodoPago = venta.MetodoPago
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

        public async Task<BaseResponse<VentaDto>> GetEntidad(int id)
        {
            var response = new BaseResponse<VentaDto>();
            try
            {
                var venta = await _repository.ObtenerEntidad(id);
                if (venta == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                response.Result = new VentaDto
                {
                    Id = venta.Id,
                    ClienteId = venta.ClienteId,
                    FechaVenta = venta.FechaVenta,
                    NumeroFactura = venta.NumeroFactura,
                    MetodoPago = venta.MetodoPago
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

        public async Task<BaseResponse<List<VentaDto>>> GetEntidadLista()
        {
            var response = new BaseResponse<List<VentaDto>>();
            try
            {
                var result = await _repository.ObtenerEntidadesLista();
                response.Result = result.Select(venta => new VentaDto
                {
                    Id = venta.Id,
                    ClienteId = venta.ClienteId,
                    FechaVenta = venta.FechaVenta,
                    NumeroFactura = venta.NumeroFactura,
                    MetodoPago = venta.MetodoPago
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
