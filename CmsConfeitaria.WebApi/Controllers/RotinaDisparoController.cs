using CmsConfeitaria.Business.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotinaDisparoController : ControllerBase
    {
        private readonly IRotinaDisparoService _service;
        public RotinaDisparoController(IRotinaDisparoService rotinaDisparoService)
        {
            _service = rotinaDisparoService;
        }
        [HttpPost("AdicionaRotina")]
        public IActionResult Adicionar(RotinaDisparoInput input)
        {
            _service.AdicionarRotina(input);
            return Ok();
        }
        [HttpGet("obterRotinas")]
        public IActionResult RotinaLista()
        {
            List<RotinaDisparoInput> listaRotinas = _service.ListaRotinas();
            return new JsonResult(listaRotinas);
        }
    }
}