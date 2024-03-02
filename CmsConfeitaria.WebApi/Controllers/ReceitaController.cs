using CmsConfeitaria.Business.Repositories.Interfaces;
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
        private readonly ReceitaRespository _receitaRepository;

        public ReceitaController(ReceitaRespository receitaRepository)
        {
            _receitaRepository = receitaRepository;
        }

        [HttpPost("AdicionarReceita")]
        public IActionResult AdicionarReceita([FromForm] ReceitaInput receitaInput)
        {
            ReceitaOutput receita = _receitaRepository.AdicionarReceita(receitaInput);
            return new JsonResult(receita);
        }

        [HttpPost("EditarReceita")]
        public IActionResult EditarReceita([FromForm] ReceitaInput receitaInput)
        {
            ReceitaOutput receita = _receitaRepository.EditarReceita(receitaInput);
            return new JsonResult(receita);
        }

        [HttpDelete("ExcluirReceita/{id}")]
        public IActionResult ExcluirReceita(int id)
        {
            _receitaRepository.ExcluirReceita(id);
            return Ok();
        }

        [HttpGet("CarregarListaReceitas")]
        public IActionResult CarregarListaReceitas()
        {
            List<ReceitaOutput> receitaLista = _receitaRepository.ObterListaReceitas();
            return new JsonResult(receitaLista);
        }

        [HttpGet("CarregarReceita/{id}")]
        public IActionResult CarregarReceita(int id)
        {
            ReceitaOutput receita = _receitaRepository.ObterReceita(id);
            return new JsonResult(receita);
        }
    }
}

