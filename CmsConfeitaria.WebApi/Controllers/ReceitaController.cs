using CmsConfeitaria.Business.Interfaces;
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
        private readonly IReceitaService _receitaService;

        public ReceitaController(IReceitaService receitaService)
        {
            _receitaService = receitaService;
        }

        [HttpPost("EnviarReceita")]
        public IActionResult EnviarReceita([FromForm] ReceitaInput receitaInput)
        {
            ReceitaOutput receita = _receitaService.EnviarReceita(receitaInput);
            return new JsonResult(receita);
        }

        [HttpDelete("ExcluirReceita/{id}")]
        public IActionResult ExcluirReceita(int id)
        {
            _receitaService.ExcluirReceita(id);
            return Ok();
        }

        [HttpGet("CarregarListaReceitas")]
        public IActionResult CarregarListaReceitas()
        {
            List<ReceitaOutput> receitaLista = _receitaService.CarregarListaReceitas();
            return new JsonResult(receitaLista);
        }

        [HttpGet("CarregarReceita/{id}")]
        public IActionResult CarregarReceita(int id)
        {
            ReceitaOutput receita = _receitaService.CarregarReceita(id);
            return new JsonResult(receita);
        }
    }
}

