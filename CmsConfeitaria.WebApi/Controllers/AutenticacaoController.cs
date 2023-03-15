using CmsConfeitaria.Integration.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        [HttpPost]
        public AutenticacaoOutput Autenticar(AutenticacaoInput input)
        {
            AutenticacaoOutput model = new AutenticacaoOutput() { Hora = DateTime.Now, Password = "validpassword", User = "validuser" };

            return model;
        }
    }
}
