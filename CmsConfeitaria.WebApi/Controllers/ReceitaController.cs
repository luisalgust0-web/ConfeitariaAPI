using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Business.Services.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly ReceitaService _receitaService;

        public ReceitaController(ReceitaService receitaService)
        {
            _receitaService = receitaService;
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar([FromForm] ReceitaInput receitaInput)
        {
            ReceitaOutput receita = _receitaService.Adicionar(receitaInput);
            return new JsonResult(receita);
        }

        [HttpGet("ObterValorTotalDaReceita")]
        public IActionResult ObterValorTotalDaReceita(int receitaId)
        {
            return new JsonResult(_receitaService.CustoReceita(receitaId));
        }

        [HttpPut("Editar/{id}")]
        public IActionResult Editar([FromForm] int id, ReceitaInput receitaInput)
        {
            ReceitaOutput receita = _receitaService.Editar(id, receitaInput);
            return new JsonResult(receita);
        }

        [HttpDelete("Remover/{id}")]
        public IActionResult Remover(int id)
        {
            _receitaService.Excluir(id);
            return Ok();
        }

        [HttpGet("ObterLista")]
        public IActionResult CarregarLista()
        {
            List<ReceitaOutput> receitaLista = _receitaService.ObterLista();
            return new JsonResult(receitaLista);
        }

        [HttpGet("ObterReceita/{id}")]
        public IActionResult CarregarReceita(int id)
        {
            ReceitaOutput receita = _receitaService.ObterIngrediente(id);
            return new JsonResult(receita);
        }
    }
}

