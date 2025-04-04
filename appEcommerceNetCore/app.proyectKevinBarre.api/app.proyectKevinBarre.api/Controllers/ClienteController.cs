using app.proyectKevinBarre.services.Interfaces;
using ECommerce_NetCore.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace app.proyectKevinBarre.api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {

        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpGet]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hola Mundo -- categoria");
        }

        [HttpPost("obtenerCliente")]
        public async Task<IActionResult> ObtenerCliente()
        {
            var result = await _clienteService.GetClienteLista();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpPost("insertarCliente")]
        public async Task<IActionResult> PostCliens([FromBody] ClienteRequest request)
        {
            var response = await _clienteService.CrearCliente(request);

            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutCliens(int id, [FromBody] ClienteRequest request)
        {
            return Ok(await _clienteService.ActualizarCliente(id, request));
        }

    }
    
}
