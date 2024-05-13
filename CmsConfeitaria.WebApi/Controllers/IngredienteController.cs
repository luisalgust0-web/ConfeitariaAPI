using CmsConfeitaria.Business;
using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Business.Services.Interfaces;
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
        private readonly IngredienteService _ingredienteService;
        public IngredienteController(IngredienteService ingredienteService)
        {
            _ingredienteService = ingredienteService;
        }

        //[Authorize()]
        [HttpGet("ObterLista")]
        public IActionResult CarregarLista()
        {
            List<ReceitaOutput> ListaIngredienteOutput = _ingredienteService.ObterLista();
            return new JsonResult(ListaIngredienteOutput);
        }

        [HttpGet("ObterIngrediente/{id}")]
        public IActionResult CarregarIngrediente(int id)
        {
            ReceitaOutput ingredienteOutput = _ingredienteService.ObterIngrediente(id);
            return new JsonResult(ingredienteOutput);
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(ReceitaInput ingredienteInput)
        {
            return new JsonResult(_ingredienteService.Adicionar(ingredienteInput));
        }

        [HttpPut("Editar/{id}")]
        public IActionResult EditarIngrediente(int id, ReceitaInput ingredienteInput)
        {
            return new JsonResult(_ingredienteService.Editar(id, ingredienteInput));
        }

        [HttpDelete("Remover/{id}")]
        public IActionResult Remover(int id)
        {
            return Ok(_ingredienteService.Excluir(id));
        }
    }
}
