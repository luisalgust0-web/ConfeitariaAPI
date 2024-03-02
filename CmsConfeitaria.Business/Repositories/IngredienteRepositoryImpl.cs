using AutoMapper;
using CmsConfeitaria.Business.Repositories.Interfaces;
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

namespace CmsConfeitaria.Business.Repositories
{
    public class IngredienteRepositoryImpl : IngredienteRepository
    {
        private readonly DBContextCm _context;
        private readonly IMapper _mapper;
        public IngredienteRepositoryImpl(DBContextCm context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<IngredienteOutput> ObterListaIngredientes()
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

        public IngredienteOutput AdicionarIngrediente(IngredienteInput ingredienteInput)
        {
            Ingrediente ingrediente = _mapper.Map<Ingrediente>(ingredienteInput);

            if (!_context.Ingrediente.Any(x => x.Nome.ToLower() == ingrediente.Nome.ToLower()))
            {
                _context.Ingrediente.Add(ingrediente);
                _context.SaveChanges();
                return _mapper.Map<IngredienteOutput>(ingrediente);
            }
            else
                throw new CmsException("Ingrediente já existente");
        }

        public IngredienteOutput EditarIngrediente(IngredienteInput ingredienteInput)
        {
            Ingrediente ingrediente = _mapper.Map<Ingrediente>(ingredienteInput);

            _context.Ingrediente.Update(ingrediente);
            _context.SaveChanges();
            IngredienteOutput ingredienteOutput = _mapper.Map<IngredienteOutput>(ingrediente);
            return ingredienteOutput;
        }
    }
}
