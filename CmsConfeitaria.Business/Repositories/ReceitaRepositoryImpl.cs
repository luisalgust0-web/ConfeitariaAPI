using AutoMapper;
using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using Microsoft.EntityFrameworkCore;

namespace CmsConfeitaria.Business.Repositories
{
    public class ReceitaRepositoryImpl : ReceitaRespository
    {
        private readonly DBContextCm _dBContextCm;
        private readonly IMapper _mapper;
        public ReceitaRepositoryImpl(DBContextCm dBContextCm, IMapper mapper)
        {
            _dBContextCm = dBContextCm;
            _mapper = mapper;
        }

        public List<Receita> ObterLista()
        {
            List<Receita> listaReceita = _dBContextCm.Receita.ToList();
            return listaReceita;
        }

        public Receita ObterReceita(int id)
        {
            Receita receita = _dBContextCm.Receita.Where(x => x.Id == id).Include(s => s.ReceitaIngredientes).ThenInclude(s => s.ingrediente).ThenInclude(s => s.Compras).FirstOrDefault();
            return receita;
        }

        public int Excluir(int id)
        {
            Receita receita = _dBContextCm.Receita.Find(id);
            _dBContextCm.Receita.Remove(receita);
            _dBContextCm.SaveChanges();
            return id;
        }

        public Receita Adicionar(ReceitaInput receitaInput)
        {
            Receita receita = _mapper.Map<Receita>(receitaInput);

            if (!_dBContextCm.Receita.Any(x => x.Nome.ToLower() == receita.Nome.ToLower()))
            {
                _dBContextCm.Receita.Add(receita);
                _dBContextCm.SaveChanges();
                return receita;
            }
            else
            {
                throw new CmsException("Receita já existente");
            }
        }

        public Receita Editar(int id, ReceitaInput receitaInput)
        {
            Receita receita = _dBContextCm.Receita.Find(id);

            receita.ModoPreparo = receitaInput.ModoPreparo;
            receita.Nome = receitaInput.Nome;
            //receita.Imagem = receitaInput.


            _dBContextCm.Receita.Update(receita);
            _dBContextCm.SaveChanges();
            return receita;
        }
    }
}