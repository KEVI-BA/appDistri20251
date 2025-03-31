using app.projectCholcaByron.services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace app.projectCholcaByron.api.Controllers
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
            return Ok("Hola Mundo -- oficina usuario");
        }


        [HttpPost("obtenerCategoria")]
        public async Task<IActionResult> ObtenerCategoria()
        {
            var result = await _categoriaService.GetCategoriaLista();
            return Ok(result);
        }

    }
}
