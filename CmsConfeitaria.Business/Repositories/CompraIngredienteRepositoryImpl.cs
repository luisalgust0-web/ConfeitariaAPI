using AutoMapper;
using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.Repositories
{
    public class CompraIngredienteRepositoryImpl : CompraIngredienteRepository
    {
        private readonly DBContextCm _context;
        private readonly IMapper _mapper;
        public CompraIngredienteRepositoryImpl(DBContextCm dBContext, IMapper mapper)
        {
            _context = dBContext;
            _mapper = mapper;
        }

        public CompraIngredienteOutput AdicionarCompra(CompraIngredienteInput compraInput)
        {
            CompraIngrediente compra = _mapper.Map<CompraIngrediente>(compraInput);

            _context.Compra.Add(compra);
            _context.SaveChanges();
            CompraIngredienteOutput compraOutput = _mapper.Map<CompraIngredienteOutput>(compra);
            return compraOutput;
        }

        public CompraIngredienteOutput EditarCompra(CompraIngredienteInput compraInput)
        {
            CompraIngrediente compra = _mapper.Map<CompraIngrediente>(compraInput);

            _context.Compra.Update(compra);
            _context.SaveChanges();
            CompraIngredienteOutput compraOutput = _mapper.Map<CompraIngredienteOutput>(compra);
            return compraOutput;
        }

        public bool ExcluirCompra(int id)
        {
            CompraIngrediente compra = _context.Compra.Find(id);
            _context.Compra.Remove(compra);
            _context.SaveChanges();
            return true;
        }

        public CompraIngredienteOutput ObterCompra(int id)
        {
            CompraIngrediente compra = _context.Compra.Where(x => x.Id == id).Include(x => x.Ingrediente).Include(x => x.UnidadeMedida).FirstOrDefault();
            CompraIngredienteOutput compraOutput = _mapper.Map<CompraIngredienteOutput>(compra);
            return compraOutput;
        }

        public CompraIngredienteOutput ObterUltimaCompraPorIngredienteId(int ingredienteId)
        {
            var compraIngrediente = _context.Compra.Where(x => x.IngredienteId == ingredienteId).OrderByDescending(x => x.DataCadastro).FirstOrDefault();
            CompraIngredienteOutput compraOutput = _mapper.Map<CompraIngredienteOutput>(compraIngrediente);
            return compraOutput;
        }

        public List<CompraIngredienteOutput> ObterListaCompras()
        {
            List<CompraIngrediente> listaCompra = _context.Compra.Include(x => x.Ingrediente).Include(x => x.UnidadeMedida).ToList();
            List<CompraIngredienteOutput> listaCompraOutput = _mapper.Map<List<CompraIngredienteOutput>>(listaCompra);
            return listaCompraOutput;
        }
    }
}
