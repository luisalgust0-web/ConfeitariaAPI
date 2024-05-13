using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Business.Services.Interfaces;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using FastReport;
using FastReport.Export.PdfSimple;
using Microsoft.AspNetCore.Mvc;

namespace CmsConfeitaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly RelatorioService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ReceitaService _receitaService;
        public RelatorioController(RelatorioService service, IWebHostEnvironment webHostEnvironment, ReceitaService receitaService)
        {
            _service = service;
            _receitaService = receitaService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("Relatorio")]
        public IActionResult RelatorioValorTotalReceita(int ReceitaId)
        {
            List<ValorReceitaOutput> listaValorReceita = new List<ValorReceitaOutput>();
            listaValorReceita.Add(_receitaService.custoReceita(ReceitaId));

            string reportFile = Path.Combine(this._webHostEnvironment.ContentRootPath, @"Relatorio\Report.frx");
            Report report = new Report();
            report.Load(reportFile);

            report.Report.Dictionary.RegisterBusinessObject(listaValorReceita, "valorReceita", 30, true);

            report.Report.Prepare();

            var pdfExport = new PDFSimpleExport();

            using (MemoryStream ms = new MemoryStream())
            {
                pdfExport.Export(report, ms);
                ms.Flush();
                return File(new MemoryStream(ms.ToArray()), "application/pdf", Path.GetFileNameWithoutExtension("Receita") + ".pdf");
            }
        }


    }
}
