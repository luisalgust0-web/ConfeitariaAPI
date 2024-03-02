using CmsConfeitaria.Business;
using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using Microsoft.AspNetCore.Mvc;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly CompraRepository _compraRepository;

        public CompraController(CompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        [HttpGet("ObterListaCompras")]
        public IActionResult ObterListaCompras()
        {
            List<CompraOutput> listaCompraOutput = _compraRepository.ObterListaCompras();
            return new JsonResult(listaCompraOutput);
        }

        [HttpGet("ObterCompra/{id}")]
        public IActionResult ObterCompra(int id)
        {
            CompraOutput compraOutput = _compraRepository.ObterCompra(id);
            return new JsonResult(compraOutput);
        }

        [HttpPost("AdicionarCompra")]
        public IActionResult AdicionarCompra(CompraInput compraInput)
        {
            return new JsonResult(_compraRepository.AdicionarCompra(compraInput));
        }

        [HttpPost("EditarCompra")]
        public IActionResult EditarCompra(CompraInput compraInput)
        {
            return new JsonResult(_compraRepository.EditarCompra(compraInput));
        }

        [HttpDelete("RemoverCompra/{id}")]
        public IActionResult Remover(int id)
        {
            _compraRepository.ExcluirCompra(id);
            return Ok();
        }
    }
}
