using AutoMapper;
using CmsConfeitaria.Business.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration;
using CmsConfeitaria.Integration.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business
{
    public class ReceitaService : IReceitaService
    {
        private readonly DBContextCm _dBContextCm;
        private readonly IMapper _mapper;
        public ReceitaService(DBContextCm dBContextCm, IMapper mapper)
        {
            _dBContextCm = dBContextCm;
            _mapper = mapper;
        }

        public List<ReceitaOutput> BuscarLista()
        {
            IEnumerable<Receita> ListaReceita = _dBContextCm.Receita.AsEnumerable();
            List<ReceitaOutput> ListaReceitaInput = _mapper.Map<List<ReceitaOutput>>(ListaReceita);
            return ListaReceitaInput;
        }

        public Receita BuscarPorId(int id)
        {
            var consulta = _dBContextCm.Receita.Where(x => x.Id == id).Include(s => s.ReceitaIngredientes).ThenInclude(s => s.ingrediente).ThenInclude(s => s.Compras);
            Receita receita = consulta.FirstOrDefault();
            return receita;
        }

        public bool Excluir(ReceitaOutput receitaInput)
        {
            Receita receita = _mapper.Map<Receita>(receitaInput);
            _dBContextCm.Receita.Remove(receita);
            _dBContextCm.SaveChanges();
            return true;
        }

        public bool Adicionar(ReceitaOutput receitaInput)
        {
            Receita receita = _mapper.Map<Receita>(receitaInput);
            ImagemReceita imagemReceita = _mapper.Map<ImagemReceita>(receitaInput.File);

            if (!_dBContextCm.Receita.Any(x => x.Nome.ToLower() == receita.Nome.ToLower()))
            {
                if (receita.Id == 0)
                {
                    _dBContextCm.Receita.Add(receita);
                    _dBContextCm.SaveChanges();
                    return true;
                }
                else
                {
                    _dBContextCm.Receita.Update(receita);
                    _dBContextCm.SaveChanges();
                    return true;
                }
            }
            else
                return false;


        }

        public ReceitaOutput BuscarReceitaPorNome(string nome)
        {
            Receita receita = _dBContextCm.Receita.Where(receita => receita.Nome == nome).FirstOrDefault();
            ReceitaOutput receitaInput = _mapper.Map<ReceitaOutput>(receita);
            return receitaInput;
        }

        public List<ReceitaOutput> BuscarReceitaPorIngredientes(string ingrediente)
        {
            List<Receita> receita = _dBContextCm.Receita.Where(R => R.ReceitaIngredientes.Any(x => x.ingrediente.Nome.StartsWith(ingrediente))).ToList();
            List<ReceitaOutput> listaReceitaInput = _mapper.Map<List<ReceitaOutput>>(receita);
            return listaReceitaInput;
        }
    }
}