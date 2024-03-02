using AutoMapper;
using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Business.Services.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;

namespace CmsConfeitaria.Business.Services
{
    public class RelatorioServiceImpl : RelatorioService
    {
        private readonly DBContextCm _context;
        private readonly ReceitaRespository _receitaService;
        private readonly CompraRepository _compraService;
        private readonly IMapper _mapper;

        public RelatorioServiceImpl(DBContextCm context, ReceitaRespository receitaService, CompraRepository compraService, IMapper mapper)
        {
            _context = context;
            _receitaService = receitaService;
            _compraService = compraService;
            _mapper = mapper;
        }

        public RelatorioReceitaOutput ValorIngredientePorReceita(int receitaId)
        {
            ReceitaOutput receitaOutput = _receitaService.ObterReceita(receitaId);
            Receita receita = _mapper.Map<Receita>(receitaOutput);
            RelatorioReceitaOutput relatorioReceitaOutput = new RelatorioReceitaOutput();

            receitaOutput.Nome = receita.Nome;
            receitaOutput.ModoPreparo = receita.ModoPreparo;

            if (receita.ReceitaIngredientes != null)
            {
                foreach (var item in receita.ReceitaIngredientes)
                {
                    var ingredienteOutput = new RelatorioIngredienteOutput();
                    ingredienteOutput.NomeIngrediente = item.ingrediente.Nome;
                    var ultimaCompra = item.ingrediente.Compras.OrderByDescending(x => x.Id).FirstOrDefault();
                    ingredienteOutput.QuantidadeTotal = ultimaCompra.Quantidade;
                    var valorPorUnidade = ultimaCompra.Valor / ultimaCompra.Quantidade;
                    ingredienteOutput.QuantidadeReceita = item.Quantidade;
                    var valorCalculado = valorPorUnidade * ingredienteOutput.QuantidadeReceita;
                    ingredienteOutput.ValorCalculo = valorCalculado;
                    relatorioReceitaOutput.ValorTotalReceita += valorCalculado;

                    relatorioReceitaOutput.IngredienteOutputs.Add(ingredienteOutput);
                }

                return relatorioReceitaOutput;
            }
            else
                throw new CmsException("essa receita ainda não possui ingredientes cadastrados");
        }
    }
}
