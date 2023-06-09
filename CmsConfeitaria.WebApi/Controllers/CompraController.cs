﻿using CmsConfeitaria.Business;
using CmsConfeitaria.Business.Interfaces;
using CmsConfeitaria.Integration.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _service; 

        public CompraController(ICompraService service)
        {
            _service = service;
        }

        [HttpGet("ListaComrpa")]
        public IActionResult GetLista()
        {
            List<CompraOutput> listaCompra = _service.GetLista();
            return new JsonResult(listaCompra);
        }
        [HttpPost("AdicionarCompra")]
        public IActionResult Adicionar(CompraOutput compraInput)
        {
            _service.adicionar(compraInput);
            return Ok();
        }
        [HttpPost("RemoverCompra")]
        public IActionResult Remover(CompraOutput compraInput)
        {
            _service.excluir(compraInput);
            return Ok();
        }
    }
}
