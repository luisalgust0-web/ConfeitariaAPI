using CmsConfeitaria.Business;
using CmsConfeitaria.Business.Interfaces;
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
        private readonly IReceitaIngredienteService _receitaIngredienteService;
        public ReceitaIngredienteController(IReceitaIngredienteService receitaIngredienteService)
        {
            _receitaIngredienteService = receitaIngredienteService;
        }

        [HttpPost("EnviarReceitaIngrediente")]
        public IActionResult EnviarReceitaIngrediente(ReceitaIngredienteInput receitaIngredienteInput)
        {
            _receitaIngredienteService.EnviarReceitaIngrediente(receitaIngredienteInput);
            return Ok();
        }

        [HttpGet("CarregarListaReceitaIngredientes")]
        public IActionResult CarregarListaReceitaIngredientes()
        {
            List<ReceitaIngredienteOutput> receitaIngredienteInputs = _receitaIngredienteService.ObterReceitaIngredientes();
            return new JsonResult(receitaIngredienteInputs);
        }

        [HttpGet("CarregarListaReceitaIngredientesPorReceitaId/{receitaId}")]
        public IActionResult CarregarListaReceitaIngredientesPorReceitaId(int receitaId)
        {
            List<ReceitaIngredienteOutput> receitaIngredienteInputs = _receitaIngredienteService.ObterReceitaIngredientesPorReceita(receitaId);
            return new JsonResult(receitaIngredienteInputs);
        }

        [HttpGet("CarregarReceitaIngrediente/{id}")]
        public IActionResult CarregarReceitaIngrediente(int id)
        {
            ReceitaIngredienteOutput receitaIngredienteInputs = _receitaIngredienteService.ObterReceitaIngrediente(id);
            return new JsonResult(receitaIngredienteInputs);
        }

        [HttpDelete("RemoverReceitaIngrediente/{id}")]
        public IActionResult RemoverReceitaIngrediente(int id)
        {
            _receitaIngredienteService.ExcluirReceitaIngrediente(id);
            return Ok();
        }
    }
}
