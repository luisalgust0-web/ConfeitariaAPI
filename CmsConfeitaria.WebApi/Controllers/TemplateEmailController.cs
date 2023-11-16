using CmsConfeitaria.Business.Interfaces;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateEmailController : ControllerBase
    {
        private readonly ITemplateEmailService _service;
        public TemplateEmailController(ITemplateEmailService service)
        {
            _service = service;
        }

        [HttpPost("AdicionarTemplate")]
        public IActionResult AdicionarTemplate(TemplateEmailInput input)
        {
            _service.InserirTemplate(input);
            return Ok();
        }
        [HttpGet("ListaTemplate")]
        public IActionResult actionResult()
        {
            List<TemplateEmailInput> listaTemplate = _service.getLista();
            return new JsonResult(listaTemplate);
        }
    }
}
