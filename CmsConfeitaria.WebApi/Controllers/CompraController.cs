using CmsConfeitaria.Business;
using CmsConfeitaria.Business.Interfaces;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using Microsoft.AspNetCore.Mvc;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _service;

        public CompraController(ICompraService service)
        {
            _service = service;
        }

        [HttpGet("ListaComrpa")]
        public IActionResult GetLista()
        {
            List<CompraOutput> listaCompra = _service.GetLista();
            return new JsonResult(listaCompra);
        }
        [HttpPost("AdicionarCompra")]
        public IActionResult Adicionar(CompraInput compraInput)
        {
            _service.Adicionar(compraInput);
            return Ok();
        }
        [HttpPost("RemoverCompra")]
        public IActionResult Remover(CompraInput compraInput)
        {
            _service.Excluir(compraInput);
            return Ok();
        }
    }
}
