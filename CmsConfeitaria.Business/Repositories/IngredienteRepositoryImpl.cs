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

        public List<Ingrediente> ObterLista()
        {
            List<Ingrediente> ListaIngredientes = _context.Ingrediente.ToList();
            return ListaIngredientes;
        }

        public int Excluir(int ingredienteId)
        {
            Ingrediente ingrediente = _context.Ingrediente.Find(ingredienteId);
            _context.Ingrediente.Remove(ingrediente);
            _context.SaveChanges();
            return ingredienteId;
        }

        public Ingrediente ObterIngrediente(int id)
        {
            Ingrediente ingrediente = _context.Ingrediente.Find(id);
            return ingrediente;
        }

        public Ingrediente Adicionar(ReceitaInput ingredienteInput)
        {
            Ingrediente ingrediente = _mapper.Map<Ingrediente>(ingredienteInput);

            if (!_context.Ingrediente.Any(x => x.Nome.ToLower() == ingrediente.Nome.ToLower()))
            {
                _context.Ingrediente.Add(ingrediente);
                _context.SaveChanges();
                return ingrediente;
            }
            else
                throw new CmsException("Ingrediente já existente");
        }

        public Ingrediente Editar(int id, ReceitaInput ingredienteInput)
        {
            Ingrediente ingrediente = _context.Ingrediente.Find(id);
            ingrediente.Nome = ingredienteInput.Nome;


            _context.Ingrediente.Update(ingrediente);
            _context.SaveChanges();
            return ingrediente;
        }
    }
}
