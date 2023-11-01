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
        [HttpGet("BuscarLista")]
        public IActionResult BuscarLista()
        {
            List<IngredienteOutput> ListaIngredienteInput = _ingredienteService.BuscarLista();
            return new JsonResult(ListaIngredienteInput);
        }
        [HttpPost("AdicionarIngrediente")]
        public IActionResult Adicionar(IngredienteInput ingredienteInput)
        {
            _ingredienteService.Adicionar(ingredienteInput);
            return Ok();
        }
        [HttpPost("RemoverIngrediente")]
        public IActionResult Remover(IngredienteInput ingredienteInput)
        {
            _ingredienteService.Excluir(ingredienteInput);
            return Ok();
        }
    }
}
