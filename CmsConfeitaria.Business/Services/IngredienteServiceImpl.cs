using AutoMapper;
using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Business.Services.Interfaces;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.Services
{
    public class IngredienteServiceImpl : IngredienteService
    {
        private readonly IMapper _mapper;
        private readonly IngredienteRepository _repository;
        public IngredienteServiceImpl(IMapper mapper, IngredienteRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public ReceitaOutput Adicionar(ReceitaInput input)
        {
            ReceitaOutput ingredienteOutput = _mapper.Map<ReceitaOutput>(_repository.Adicionar(input));
            return ingredienteOutput;
        }

        public ReceitaOutput Editar(int id, ReceitaInput input)
        {
            ReceitaOutput ingredienteOutput = _mapper.Map<ReceitaOutput>(_repository.Editar(id, input));
            return ingredienteOutput;
        }

        public int Excluir(int id)
        {
            return _repository.Excluir(id);
        }

        public ReceitaOutput ObterIngrediente(int id)
        {
            ReceitaOutput ingredienteOutput = _mapper.Map<ReceitaOutput>(_repository.ObterIngrediente(id));
            return ingredienteOutput;
        }

        public List<ReceitaOutput> ObterLista()
        {
            List<ReceitaOutput> listIngredienteOutput = _mapper.Map<List<ReceitaOutput>>(_repository.ObterLista());
            return listIngredienteOutput;
        }
    }
}
