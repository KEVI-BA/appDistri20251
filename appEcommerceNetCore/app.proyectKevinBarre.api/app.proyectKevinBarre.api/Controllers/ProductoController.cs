using app.proyectKevinBarre.services.Interfaces;
using Azure;
using ECommerce_NetCore.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace app.proyectKevinBarre.api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {

        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }


        [HttpGet]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hola Mundo -- categoria");
        }

        [HttpPost("obtenerProducto")]
        public async Task<IActionResult> ObtenerProducto()
        {
            var result = await _productoService.GetProductoLista();
            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpPost("insertarProducto")]
        public async Task<IActionResult> PostProductos([FromBody] ProductoRequest request)
        {
            var response = await _productoService.CrearProducto(request);

            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutProductos(int id, [FromBody] ProductoRequest request)
        {
            return Ok(await _productoService.ActualizarProducto(id, request));
        }

    }
}
