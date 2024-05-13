using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Business.Services.Interfaces;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar([FromBody] UsuarioInput usuario)
        {
            return new JsonResult(_usuarioService.Cadastrar(usuario));
        }

        [HttpPut("Editar/{id}")]
        public IActionResult Editar(int id, [FromBody] UsuarioInput usuario)
        {
            return new JsonResult(_usuarioService.Editar(id, usuario));
        }

        [HttpDelete("Remover/{id}")]
        public IActionResult Remover(int id)
        {
            return new JsonResult(_usuarioService.Excluir(id));
        }

    }
}