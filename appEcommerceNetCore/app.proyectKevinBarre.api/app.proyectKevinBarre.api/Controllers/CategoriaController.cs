using app.proyectKevinBarre.services.Interfaces;
using Azure;
using ECommerce_NetCore.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace app.proyectKevinBarre.api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {

        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }


        [HttpGet]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hola Mundo -- categoria");
        }

        [HttpPost("obtenerCategoria")]
        public async Task<IActionResult> ObtenerCategoria()
        {
            var result = await _categoriaService.GetCategoriaLista();
            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpPost("insertarCategoria")]
        public async Task<IActionResult> PostCategories([FromBody] CategoriaRequest request)
        {
            var response = await _categoriaService.CrearCategoria(request);

            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutCategories(int id, [FromBody] CategoriaRequest request)
        {
            return Ok(await _categoriaService.ActualizarCategoria(id, request));
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> EliminarCategoria(int id) 
        {
            var response = await _categoriaService.EliminarCategoria(id);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }

        }
    }
}
