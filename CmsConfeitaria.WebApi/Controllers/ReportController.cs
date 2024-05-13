using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using FastReport;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testeController : ControllerBase
    {

        private IWebHostEnvironment _webHostEnvironment;

        public testeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("report")]
        public ActionResult GenerateModelReport()
        {
            List<ValorReceitaOutput> valorReceitas = new List<ValorReceitaOutput>();


            string reportFile = Path.Combine(this._webHostEnvironment.ContentRootPath, @"Relatorio\Report.frx");
            Report report = new Report();
            report.Report.Dictionary.RegisterBusinessObject(valorReceitas, "valorReceita", 10 ,true);
            report.Report.Save(reportFile);

            return Ok("OK");
        }
    }
}
