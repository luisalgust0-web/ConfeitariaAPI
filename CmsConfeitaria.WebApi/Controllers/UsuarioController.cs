using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("AdicionarUsuario")]
        public IActionResult Adicionar(UsuarioInput usuario)
        {
            return new JsonResult(_usuarioRepository.AdicionarUsuario(usuario));
        }

    }
}