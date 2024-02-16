using CmsConfeitaria.Business;
using CmsConfeitaria.Business.Interfaces;
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
        private readonly IIngredienteService _ingredienteService;
        public IngredienteController(IIngredienteService ingredienteService)
        {
            _ingredienteService = ingredienteService;
        }

        //[Authorize()]
        [HttpGet("CarregarListaIngredientes")]
        public IActionResult CarregarListaIngredientes()
        {
            List<IngredienteOutput> ListaIngredienteOutput = _ingredienteService.CarregarListaIngredientes();
            return new JsonResult(ListaIngredienteOutput);
        }

        [HttpGet("CarregarIngrediente/{id}")]
        public IActionResult CarregarIngrediente(int id)
        {
            IngredienteOutput ingredienteOutput = _ingredienteService.ObterIngrediente(id);
            return new JsonResult(ingredienteOutput);
        }

        [HttpPost("EnviarIngrediente")]
        public IActionResult EnviarIngrediente(IngredienteInput ingredienteInput)
        {
            return new JsonResult(_ingredienteService.EnviarIngrediente(ingredienteInput));
        }

        [HttpDelete("RemoverIngrediente/{id}")]
        public IActionResult Remover(int id)
        {
            _ingredienteService.ExcluirIngrediente(id);
            return Ok();
        }
    }
}
