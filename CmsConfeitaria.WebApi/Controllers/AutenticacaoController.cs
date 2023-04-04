using CmsConfeitaria.Business;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration;
using CmsConfeitaria.Integration.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly AutenticacaoService _service;
        public AutenticacaoController(AutenticacaoService service)
        {
            _service = service;
        }

        [HttpPost("Autenticar")]
        public AutenticacaoOutput Autenticar(AutenticacaoInput input)
        {
            AutenticacaoOutput aut = _service.EstaAutenticado(input);
            return aut;
        }
    }
}
