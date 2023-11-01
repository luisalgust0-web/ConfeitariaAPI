using CmsConfeitaria.Business;
using CmsConfeitaria.Business.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoServie _service;
        public AutenticacaoController(IAutenticacaoServie service)
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
