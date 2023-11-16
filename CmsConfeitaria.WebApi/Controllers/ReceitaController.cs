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

        [HttpPost("Adicionar")]
        public IActionResult Adicionar([FromForm] ReceitaInput receitaInput)
        {
<<<<<<< HEAD
            _receitaService.Adicionar(receitaInput);

            return Ok();
=======
            ReceitaOutput receita = _receitaService.Adicionar(receitaInput);
            return new JsonResult(receita);
>>>>>>> ace6998ca0dae0047ecbf6a867f07d3e0d446c0b
        }

        [HttpPost("Excluir")]
        public IActionResult Excluir(ReceitaInput receitaInput)
        {
            _receitaService.Excluir(receitaInput);
            return Ok();
        }

        [HttpGet("BuscarLista")]
        public IActionResult RetornarLista()
        {
            List<ReceitaOutput> receitaLista = _receitaService.BuscarLista();
            return new JsonResult(receitaLista);
        }

        [HttpGet("RetornarReceitaId")]
        public IActionResult RetornarReceitaPorId(int id)
        {
            ReceitaOutput receita = _receitaService.BuscarPorId(id);
            return new JsonResult(receita);
        }
        [HttpGet("RetornarReceitaNome")]
        public IActionResult RetornarReceitaPorNome(string nome)
        {
            ReceitaOutput receita = _receitaService.BuscarReceitaPorNome(nome);
            return new JsonResult(receita);
        }
        [HttpGet("RetornarReceitasPorIngrediente")]
        public IActionResult RetornarReceitasPorIngrediente(string Ingrediente)
        {
            List<ReceitaOutput> receita = _receitaService.BuscarReceitaPorIngredientes(Ingrediente);
            return new JsonResult(receita);
        }
    }
}

