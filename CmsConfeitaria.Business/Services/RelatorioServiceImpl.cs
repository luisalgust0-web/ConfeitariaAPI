using AutoMapper;
using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Business.Services.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration;
using FastReport.Export.PdfSimple;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using FastReport;
using System.IO;

namespace CmsConfeitaria.Business.Services
{
    public class RelatorioServiceImpl : RelatorioService
    {
        private readonly DBContextCm _context;
        private readonly ReceitaRespository _receitaService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RelatorioServiceImpl(DBContextCm context, ReceitaRespository receitaService, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _receitaService = receitaService;
            _webHostEnvironment = webHostEnvironment;

    }

        public FileStreamResult GerarRelatorio(ValorReceitaOutput valorReceita)
        {

            string reportFile = Path.Combine(this._webHostEnvironment.ContentRootPath, @"Relatorio\Report.frx");
            Report report = new Report();
            report.Load(reportFile);

            report.Report.SetParameterValue("NomeReceita", valorReceita.NomeReceita);
            report.Report.SetParameterValue("ValorTotal", valorReceita.ValorTotal);
            report.Report.Dictionary.RegisterBusinessObject(valorReceita.Ingredientes, "ingredientes", 30, true);

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
