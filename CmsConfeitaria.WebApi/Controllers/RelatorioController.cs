using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Business.Services.Interfaces;
using CmsConfeitaria.Integration.ViewModels.Inputs;
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
        private readonly ReceitaRespository _receitaRepository;
        public RelatorioController(RelatorioService service, IWebHostEnvironment webHostEnvironment, ReceitaRespository receitaRepository)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
            _receitaRepository = receitaRepository;
        }

        [HttpPost("ValorIngredientePorReceita")]
        public RelatorioReceitaOutput ValorIngredientePorReceita(int ReceitaId)
        {
            RelatorioReceitaOutput ValorIngredientePorReceita = _service.ValorIngredientePorReceita(ReceitaId);
            return ValorIngredientePorReceita;
        }

        [HttpGet("Relatorio")]
        public IActionResult Relatorio(int ReceitaId)
        {
            var receita = _receitaRepository.ObterReceita(ReceitaId);


            RelatorioReceitaOutput receitaRelatorio = _service.ValorIngredientePorReceita(receita.Id);


            var reportFile = Path.Combine(this._webHostEnvironment.ContentRootPath, @"Relatorio\Report.frx");
            var report = new FastReport.Report();
            report.Load(reportFile);
            report.Report.SetParameterValue("NomeReceita", receita.Nome);
            report.Report.SetParameterValue("ModoPreparo", receita.ModoPreparo);
            report.Report.SetParameterValue("ValorTotalReceita", receitaRelatorio.ValorTotalReceita);
            report.Report.Dictionary.RegisterBusinessObject(receitaRelatorio.IngredienteOutputs, "ingrediente", 30, true);
            report.Report.Prepare();

            var pdfExport = new PDFSimpleExport();

            using (MemoryStream ms = new MemoryStream())
            {
                pdfExport.Export(report, ms);
                return new FileStreamResult(new MemoryStream(ms.ToArray()), "application/pdf");
            }
        }


    }
}
