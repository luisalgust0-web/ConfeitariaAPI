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
        [HttpGet("BuscarListaUnidadeMedida")]
        public IActionResult BusacarLista()
        {
            List<UnidadeMedidaOutput> ListaUnidadeMediadaInput = _unidadeMedidaService.BuscarLista();
            return new JsonResult(ListaUnidadeMediadaInput);
        }
        [HttpPost("AdicionarUnidadeMedida")]
        public IActionResult Adicionar(UnidadeMedidaInput unidademedidaInput)
        {
            _unidadeMedidaService.Adicionar(unidademedidaInput);
            return Ok();

        }
        [HttpPost("RemoverUnidadeMedida")]
        public IActionResult Remover(UnidadeMedidaInput unidademedidaInput)
        {
            _unidadeMedidaService.Excluir(unidademedidaInput);
            return Ok();
        }
    }
}
