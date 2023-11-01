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
    public class CompraService : ICompraService
    {
        private readonly DBContextCm _context;
        private readonly IMapper _mapper;
        public CompraService(DBContextCm dBContext, IMapper mapper)
        {
            _context = dBContext;
            _mapper = mapper;
        }

        public bool Adicionar(CompraInput compraInput)
        {
            Compra compra = _mapper.Map<Compra>(compraInput);

            if (compra.Id == 0)
            {
                _context.Compra.Add(compra);
                _context.SaveChanges();
                return true;
            }
            else
            {
                _context.Compra.Update(compra);
                _context.SaveChanges();
                return true;
            }
        }

        public bool Excluir(CompraInput compraInput)
        {
            Compra compra = _mapper.Map<Compra>(compraInput);
            _context.Compra.Remove(compra);
            _context.SaveChanges();
            return true;
        }

        public List<CompraOutput> GetLista()
        {
            IEnumerable<Compra> enumerableCompra = _context.Compra.Include(x => x.Ingrediente).Include(x => x.UnidadeMedida).AsEnumerable();
            List<CompraOutput> listaCompra = _mapper.Map<List<CompraOutput>>(enumerableCompra);
            return listaCompra;
        }

        public CompraOutput ObterCompraPorId(int id)
        {
            Compra compra = _context.Compra.Where(x => x.Id == id).Include(x => x.Ingrediente).Include(x => x.UnidadeMedida).FirstOrDefault();
            CompraOutput compraOutput = _mapper.Map<CompraOutput>(compra);
            return compraOutput;
        }
    }
}
