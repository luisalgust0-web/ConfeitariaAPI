using CmsConfeitaria.Business;
using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using Microsoft.AspNetCore.Mvc;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraIngredienteController : ControllerBase
    {
        private readonly CompraIngredienteRepository _compraRepository;

        public CompraIngredienteController(CompraIngredienteRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        [HttpGet("ObterListaCompraIngredientes")]
        public IActionResult ObterListaCompras()
        {
            List<CompraIngredienteOutput> listaCompraOutput = _compraRepository.ObterListaCompras();
            return new JsonResult(listaCompraOutput);
        }


        [HttpGet("ObterCompraIngrediente/{id}")]
        public IActionResult ObterCompra(int id)
        {
            CompraIngredienteOutput compraOutput = _compraRepository.ObterCompra(id);
            return new JsonResult(compraOutput);
        }

        [HttpPost("AdicionarCompraIngrediente")]
        public IActionResult AdicionarCompra(CompraIngredienteInput compraInput)
        {
            return new JsonResult(_compraRepository.AdicionarCompra(compraInput));
        }

        [HttpPost("EditarCompraIngrediente")]
        public IActionResult EditarCompra(CompraIngredienteInput compraInput)
        {
            return new JsonResult(_compraRepository.EditarCompra(compraInput));
        }

        [HttpDelete("RemoverCompraIngrediente/{id}")]
        public IActionResult Remover(int id)
        {
            _compraRepository.ExcluirCompra(id);
            return Ok();
        }
    }
}
