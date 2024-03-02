using CmsConfeitaria.Business;
using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaIngredienteController : ControllerBase
    {
        private readonly ReceitaIngredienteRepository _receitaIngredienteRepository;
        public ReceitaIngredienteController(ReceitaIngredienteRepository receitaIngredienteRepository)
        {
            _receitaIngredienteRepository = receitaIngredienteRepository;
        }

        [HttpPost("AdicionarReceitaIngrediente")]
        public IActionResult AdicionarReceitaIngrediente(ReceitaIngredienteInput receitaIngredienteInput)
        {
            ReceitaIngredienteOutput receitaIngredienteOutput = _receitaIngredienteRepository.AdicionarReceitaIngrediente(receitaIngredienteInput);
            return new JsonResult(receitaIngredienteOutput);
        }

        [HttpPost("EditarReceitaIngrediente")]
        public IActionResult EditarReceitaIngrediente(ReceitaIngredienteInput receitaIngredienteInput)
        {
            ReceitaIngredienteOutput receitaIngredienteOutput = _receitaIngredienteRepository.EditarReceitaIngrediente(receitaIngredienteInput);
            return new JsonResult(receitaIngredienteOutput);
        }

        [HttpGet("ObterListaReceitaIngredientes")]
        public IActionResult ObterListaReceitaIngredientes()
        {
            List<ReceitaIngredienteOutput> receitaIngredienteInputs = _receitaIngredienteRepository.ObterListaReceitaIngredientes();
            return new JsonResult(receitaIngredienteInputs);
        }

        [HttpGet("ObterListaReceitaIngredientesPorReceita/{receitaId}")]
        public IActionResult ObterListaReceitaIngredientesPorReceita(int receitaId)
        {
            List<ReceitaIngredienteOutput> receitaIngredienteInputs = _receitaIngredienteRepository.ObterListaReceitaIngredientesPorReceita(receitaId);
            return new JsonResult(receitaIngredienteInputs);
        }

        [HttpGet("ObterReceitaIngrediente/{id}")]
        public IActionResult CarregarReceitaIngrediente(int id)
        {
            ReceitaIngredienteOutput receitaIngredienteInputs = _receitaIngredienteRepository.ObterReceitaIngrediente(id);
            return new JsonResult(receitaIngredienteInputs);
        }

        [HttpDelete("RemoverReceitaIngrediente/{id}")]
        public IActionResult RemoverReceitaIngrediente(int id)
        {
            _receitaIngredienteRepository.ExcluirReceitaIngrediente(id);
            return Ok();
        }
    }
}
