using CmsConfeitaria.Business;
using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        private readonly IngredienteRepository _ingredienteRepository;
        public IngredienteController(IngredienteRepository ingredienteRepository)
        {
            _ingredienteRepository = ingredienteRepository;
        }

        //[Authorize()]
        [HttpGet("ObterListaIngredientes")]
        public IActionResult CarregarListaIngredientes()
        {
            List<IngredienteOutput> ListaIngredienteOutput = _ingredienteRepository.ObterListaIngredientes();
            return new JsonResult(ListaIngredienteOutput);
        }

        [HttpGet("ObterIngrediente/{id}")]
        public IActionResult CarregarIngrediente(int id)
        {
            IngredienteOutput ingredienteOutput = _ingredienteRepository.ObterIngrediente(id);
            return new JsonResult(ingredienteOutput);
        }

        [HttpPost("AdicioanrIngrediente")]
        public IActionResult AdicionarIngrediente(IngredienteInput ingredienteInput)
        {
            return new JsonResult(_ingredienteRepository.AdicionarIngrediente(ingredienteInput));
        }

        [HttpPost("EditarIngrediente")]
        public IActionResult EditarIngrediente(IngredienteInput ingredienteInput)
        {
            return new JsonResult(_ingredienteRepository.EditarIngrediente(ingredienteInput));
        }

        [HttpDelete("RemoverIngrediente/{id}")]
        public IActionResult Remover(int id)
        {
            _ingredienteRepository.ExcluirIngrediente(id);
            return Ok();
        }
    }
}
