using AutoMapper;
using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Business.Services.Interfaces;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;

namespace CmsConfeitaria.Business.Services
{
    public class ReceitaServiceImpl : ReceitaService
    {
        private readonly CompraIngredienteRepository _compraIngredienteRepository;
        private readonly ReceitaIngredienteRepository _receitaIngredienteRespository;
        private readonly ReceitaRespository _receitaRepository;
        private readonly IMapper _mapper;

        public ReceitaServiceImpl(CompraIngredienteRepository compraIngredienteRepository, ReceitaIngredienteRepository receitaIngredienteRespository, ReceitaRespository receitaRepository)
        {
            _compraIngredienteRepository = compraIngredienteRepository;
            _receitaIngredienteRespository = receitaIngredienteRespository;
            _receitaRepository = receitaRepository;
        }

        public ReceitaOutput Adicionar(ReceitaInput input)
        {
            return _mapper.Map<ReceitaOutput>(_receitaRepository.Adicionar(input));
        }

        public ReceitaOutput Editar(int id, ReceitaInput input)
        {
            return _mapper.Map<ReceitaOutput>(_receitaRepository.Editar(id, input));
        }

        public int Excluir(int id)
        {
            return _receitaRepository.Excluir(id);
        }

        public ReceitaOutput ObterIngrediente(int id)
        {
            return _mapper.Map<ReceitaOutput>(_receitaRepository.ObterReceita(id));
        }

        public List<ReceitaOutput> ObterLista()
        {
            return _mapper.Map<List<ReceitaOutput>>(_receitaRepository.ObterLista());
        }

        public ValorReceitaOutput CustoReceita(int receitaId)
        {
            ValorReceitaOutput valorReceita = new ValorReceitaOutput();

            List<ReceitaIngredienteOutput> listaIngredientesDaReceita = _receitaIngredienteRespository.ObterListaReceitaIngredientesPorReceita(receitaId);

            foreach (ReceitaIngredienteOutput receitaIngrediente in listaIngredientesDaReceita)
            {
                ValorIngredienteOutput valorIngrediente = custoIngredienteReceita(receitaIngrediente);
                valorReceita.Ingredientes.Add(valorIngrediente);
                valorReceita.ValorTotal += valorIngrediente.ValorEstimado;
                valorReceita.NomeReceita = receitaIngrediente.NomeReceita;
            }

            return valorReceita;
        }

        private ValorIngredienteOutput custoIngredienteReceita(ReceitaIngredienteOutput receitaIngrediente)
        {
            ValorIngredienteOutput valorIngredienteReceita = new ValorIngredienteOutput();

            CompraIngredienteOutput compraIngredienteOutput = _compraIngredienteRepository.ObterUltimaCompraPorIngredienteId(receitaIngrediente.IngredienteId);

            valorIngredienteReceita.ValorEstimado = (receitaIngrediente.Quantidade * compraIngredienteOutput.Valor) / compraIngredienteOutput.Quantidade;
            valorIngredienteReceita.NomeIngrediente = receitaIngrediente.NomeIngrediente;
            valorIngredienteReceita.QuantidadeUtilizada = receitaIngrediente.Quantidade;

            return valorIngredienteReceita;
        }

    }
}
