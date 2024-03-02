using AutoMapper;
using CmsConfeitaria.Business.Repositories.Interfaces;
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

namespace CmsConfeitaria.Business.Repositories
{
    public class CompraRepositoryImpl : CompraRepository
    {
        private readonly DBContextCm _context;
        private readonly IMapper _mapper;
        public CompraRepositoryImpl(DBContextCm dBContext, IMapper mapper)
        {
            _context = dBContext;
            _mapper = mapper;
        }

        public CompraOutput AdicionarCompra(CompraInput compraInput)
        {
            Compra compra = _mapper.Map<Compra>(compraInput);

            _context.Compra.Add(compra);
            _context.SaveChanges();
            CompraOutput compraOutput = _mapper.Map<CompraOutput>(compra);
            return compraOutput;
        }

        public CompraOutput EditarCompra(CompraInput compraInput)
        {
            Compra compra = _mapper.Map<Compra>(compraInput);

            _context.Compra.Update(compra);
            _context.SaveChanges();
            CompraOutput compraOutput = _mapper.Map<CompraOutput>(compra);
            return compraOutput;
        }

        public bool ExcluirCompra(CompraInput compraInput)
        {
            Compra compra = _mapper.Map<Compra>(compraInput);
            _context.Compra.Remove(compra);
            _context.SaveChanges();
            return true;
        }

        public CompraOutput ObterCompra(int id)
        {
            Compra compra = _context.Compra.Where(x => x.Id == id).Include(x => x.Ingrediente).Include(x => x.UnidadeMedida).FirstOrDefault();
            CompraOutput compraOutput = _mapper.Map<CompraOutput>(compra);
            return compraOutput;
        }

        public List<CompraOutput> ObterListaCompras()
        {
            List<Compra> listaCompra = _context.Compra.Include(x => x.Ingrediente).Include(x => x.UnidadeMedida).ToList();
            List<CompraOutput> listaCompraOutput = _mapper.Map<List<CompraOutput>>(listaCompra);
            return listaCompraOutput;
        }
    }
}
