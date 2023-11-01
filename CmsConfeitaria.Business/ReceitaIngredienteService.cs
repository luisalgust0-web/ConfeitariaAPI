using AutoMapper;
using CmsConfeitaria.Business.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business
{
    public class ReceitaIngredienteService : IReceitaIngredienteService
    {
        private readonly DBContextCm _context;
        private readonly IMapper _mapper;

        public ReceitaIngredienteService(DBContextCm context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Adicionar(ReceitaIngredienteInput receitaIngredienteInput)
        {
            ReceitaIngrediente receitaIngrediente = _mapper.Map<ReceitaIngrediente>(receitaIngredienteInput);
            if (!_context.ReceitaIngrediente.Any(x => x.ReceitaId == receitaIngrediente.ReceitaId && x.IngredienteId == receitaIngrediente.IngredienteId))
            {
                if (receitaIngrediente.Id == 0)
                {
                    _context.ReceitaIngrediente.Add(receitaIngrediente);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    _context.ReceitaIngrediente.Update(receitaIngrediente);
                    _context.SaveChanges();
                    return true;
                }
            }
            else
                throw new CmsException("Receita já contem esse ingrediente");
        }

        public bool Excluir(ReceitaIngredienteInput ReceitaIngredienteInput)
        {
            ReceitaIngrediente receitaIngrediente = _mapper.Map<ReceitaIngrediente>(ReceitaIngredienteInput);

            _context.ReceitaIngrediente.Remove(receitaIngrediente);
            _context.SaveChanges();
            return true;
        }

        public List<ReceitaIngredienteOutput> ObterLista()
        {
            IEnumerable<ReceitaIngrediente> receitaIngredientes = _context.ReceitaIngrediente.Include(x => x.Receita).Include(x => x.UnidadeMedida).Include(x => x.ingrediente).AsEnumerable();
            List<ReceitaIngredienteOutput> receitaIngredienteOutputs = _mapper.Map<List<ReceitaIngredienteOutput>>(receitaIngredientes);
            return receitaIngredienteOutputs;
        }

        public List<ReceitaIngredienteOutput> ObterReceitaIngredientePorReceita(int receitaId)
        {
            IEnumerable<ReceitaIngrediente> listaReceitaIngrediente = _context.ReceitaIngrediente.Where(x => x.ReceitaId == receitaId).Include(x => x.Receita).Include(x => x.UnidadeMedida).Include(x => x.ingrediente).AsEnumerable();
            List<ReceitaIngredienteOutput> listaReceitaIngredienteOutput = _mapper.Map<List<ReceitaIngredienteOutput>>(listaReceitaIngrediente);
            return listaReceitaIngredienteOutput;
        }
    }
}
