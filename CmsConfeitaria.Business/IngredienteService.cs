using AutoMapper;
using CmsConfeitaria.Business.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business
{
    public class IngredienteService : IIngredienteService
    {
        private readonly DBContextCm _context;
        private readonly IMapper _mapper;
        public IngredienteService(DBContextCm context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IngredienteOutput EnviarIngrediente(IngredienteInput ingredienteInput)
        {
            Ingrediente ingrediente = _mapper.Map<Ingrediente>(ingredienteInput);

            if (!_context.Ingrediente.Any(x => x.Nome.ToLower() == ingrediente.Nome.ToLower()))
            {
                if (ingrediente.Id == 0)
                {
                    _context.Ingrediente.Add(ingrediente);
                    _context.SaveChanges();
                    return _mapper.Map<IngredienteOutput>(ingrediente);
                }
                else
                {

                    _context.Ingrediente.Update(ingrediente);
                    _context.SaveChanges();
                    return _mapper.Map<IngredienteOutput>(ingrediente);
                }
            }
            else
                throw new CmsException("Ingrediente já existente");

        }

        public List<IngredienteOutput> CarregarListaIngredientes()
        {
            IEnumerable<Ingrediente> ListaIngredientes = _context.Ingrediente.AsEnumerable();
            List<IngredienteOutput> ListaIngredientesInput = _mapper.Map<List<IngredienteOutput>>(ListaIngredientes);
            return ListaIngredientesInput;
        }

        public bool ExcluirIngrediente(int ingredienteId)
        {
            Ingrediente ingrediente = _context.Ingrediente.Find(ingredienteId);
            _context.Ingrediente.Remove(ingrediente);
            _context.SaveChanges();
            return true;
        }

        public IngredienteOutput ObterIngrediente(int id)
        {
            Ingrediente ingrediente = _context.Ingrediente.Find(id);
            IngredienteOutput ingredienteOutput = _mapper.Map<IngredienteOutput>(ingrediente);
            return ingredienteOutput;
        }
    }
}
