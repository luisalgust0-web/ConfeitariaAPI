using AutoMapper;
using CmsConfeitaria.Business.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration;
using CmsConfeitaria.Integration.Migrations;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
            List<ReceitaOutput> listReceitaOutputs = _mapper.Map<List<ReceitaOutput>>(ListaReceita);
            return listReceitaOutputs;
        }

        public ReceitaOutput BuscarPorId(int id)
        {
            var consulta = _dBContextCm.Receita.Where(x => x.Id == id).Include(s => s.ReceitaIngredientes).ThenInclude(s => s.ingrediente).ThenInclude(s => s.Compras);
            ReceitaOutput receitaOutput = _mapper.Map<ReceitaOutput>(consulta.FirstOrDefault());
            return receitaOutput;
        }

        public bool Excluir(ReceitaInput receitaInput)
        {
            Receita receita = _mapper.Map<Receita>(receitaInput);
            _dBContextCm.Receita.Remove(receita);
            _dBContextCm.SaveChanges();
            return true;
        }

        public ReceitaOutput Adicionar(ReceitaInput receitaInput)
        {
            Receita receita = _mapper.Map<Receita>(receitaInput);

            if (!_dBContextCm.Receita.Any(x => x.Nome.ToLower() == receita.Nome.ToLower()))
            {
                if (receita.Id == 0)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        _dBContextCm.Receita.Add(receita);
                        _dBContextCm.SaveChanges();
                        ReceitaOutput receitaOutput = _mapper.Map<ReceitaOutput>(receita);
                        MemoryStream memoryStream = new MemoryStream();

                        ImagemReceita imagemReceita = new ImagemReceita();
                        receitaInput.ImagemFile.CopyTo(memoryStream);
                        imagemReceita.ImagemFile = memoryStream.ToArray();
                        imagemReceita.ReceitaId = receitaOutput.Id;
                        _dBContextCm.ImagemReceita.Add(imagemReceita);
                        _dBContextCm.SaveChanges();

                        scope.Complete();

                        return receitaOutput;
                    }
                }
                else
                {
                    _dBContextCm.Receita.Update(receita);
                    _dBContextCm.SaveChanges();
                    ReceitaOutput receitaOutput = _mapper.Map<ReceitaOutput>(receita);
                    return receitaOutput;
                }
            }
            else
                throw new CmsException("Receita já existente");


        }

        public ReceitaOutput BuscarReceitaPorNome(string nome)
        {
            Receita receita = _dBContextCm.Receita.Where(receita => receita.Nome == nome).FirstOrDefault();
            ReceitaOutput receitaOutput = _mapper.Map<ReceitaOutput>(receita);
            return receitaOutput;
        }

        public List<ReceitaOutput> BuscarReceitaPorIngredientes(string ingrediente)
        {
            List<Receita> receita = _dBContextCm.Receita.Where(R => R.ReceitaIngredientes.Any(x => x.ingrediente.Nome.StartsWith(ingrediente))).ToList();
            List<ReceitaOutput> listaReceitaOutput = _mapper.Map<List<ReceitaOutput>>(receita);
            return listaReceitaOutput;
        }
    }
}