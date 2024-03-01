using CmsConfeitaria.Business.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeMedidaController : ControllerBase
    {
        private readonly IUnidadeMedidaService _unidadeMedidaService;
        public UnidadeMedidaController(IUnidadeMedidaService unidadeMedidaService)
        {
            _unidadeMedidaService = unidadeMedidaService;
        }

        [HttpGet("CarregarListaUnidadeMedida")]
        public IActionResult CarregarListaUnidadeMedida()
        {
            List<UnidadeMedidaOutput> ListaUnidadeMediadaInput = _unidadeMedidaService.ObterUnidadeMedidas();
            return new JsonResult(ListaUnidadeMediadaInput);
        }

        [HttpGet("CarregarUnidadeMedida/{id}")]
        public IActionResult CarregarUnidadeMedida(int id)
        {
            UnidadeMedidaOutput unidadeMedidaOutput = _unidadeMedidaService.ObterUnidadeMedida(id);
            return new JsonResult(unidadeMedidaOutput);
        }

        [HttpPost("EnviarUnidadeMedida")]
        public IActionResult Adicionar(UnidadeMedidaInput unidademedidaInput)
        {
            UnidadeMedidaOutput unidadeMedidaOutput = _unidadeMedidaService.EnviarUnidadeMedida(unidademedidaInput);
            return new JsonResult(unidadeMedidaOutput);

        }

        [HttpDelete("RemoverUnidadeMedida/{id}")]
        public IActionResult Remover(int id)
        {
            _unidadeMedidaService.ExcluirUnidadeMedida(id);
            return Ok();
        }
    }
}
