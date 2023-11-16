using AutoMapper;
using CmsConfeitaria.Business.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CmsConfeitaria.Business
{
    public class RelatorioService : IRelatorioService
    {
        private readonly DBContextCm _context;
        private readonly IReceitaService _receitaService;
        private readonly ICompraService _compraService;
        private readonly IMapper _mapper;

        public RelatorioService(DBContextCm context, IReceitaService receitaService, ICompraService compraService, IMapper mapper)
        {
            _context = context;
            _receitaService = receitaService;
            _compraService = compraService;
            _mapper = mapper;
        }

        public RelatorioReceitaOutput ValorIngredientePorReceita(int receitaId)
        {
            ReceitaOutput receitaOutput = _receitaService.BuscarPorId(receitaId);
            Receita receita = _mapper.Map<Receita>(receitaOutput);
            RelatorioReceitaOutput relatorioReceitaOutput = new RelatorioReceitaOutput();

            receitaOutput.Nome = receita.Nome;
            receitaOutput.ModoPreparo = receita.ModoPreparo;

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
    }
}
