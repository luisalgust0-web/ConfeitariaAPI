﻿using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeMedidaController : ControllerBase
    {
        private readonly UnidadeMedidaRepository _unidadeMedidaRepository;
        public UnidadeMedidaController(UnidadeMedidaRepository unidadeMedidaRepository)
        {
            _unidadeMedidaRepository = unidadeMedidaRepository;
        }

        [HttpGet("ObterListaUnidadeMedidas")]
        public IActionResult ObterListaUnidadeMedidas()
        {
            List<UnidadeMedidaOutput> ListaUnidadeMediadaInput = _unidadeMedidaRepository.ObterListaUnidadeMedidas();
            return new JsonResult(ListaUnidadeMediadaInput);
        }

        [HttpGet("ObterUnidadeMedida/{id}")]
        public IActionResult ObterUnidadeMedida(int id)
        {
            UnidadeMedidaOutput unidadeMedidaOutput = _unidadeMedidaRepository.ObterUnidadeMedida(id);
            return new JsonResult(unidadeMedidaOutput);
        }

        [HttpPost("AdicionarUnidadeMedida")]
        public IActionResult AdicionarUnidadeMedida(UnidadeMedidaInput unidademedidaInput)
        {
            UnidadeMedidaOutput unidadeMedidaOutput = _unidadeMedidaRepository.AdicionarUnidadeMedida(unidademedidaInput);
            return new JsonResult(unidadeMedidaOutput);

        }

        [HttpPost("EditarUnidadeMedida")]
        public IActionResult EditarUnidadeMedida(UnidadeMedidaInput unidademedidaInput)
        {
            UnidadeMedidaOutput unidadeMedidaOutput = _unidadeMedidaRepository.EditarUnidadeMedida(unidademedidaInput);
            return new JsonResult(unidadeMedidaOutput);

        }

        [HttpDelete("RemoverUnidadeMedida/{id}")]
        public IActionResult ExcluirUnidadeMedida(int id)
        {
            _unidadeMedidaRepository.ExcluirUnidadeMedida(id);
            return Ok();
        }
    }
}
