using AutoMapper;
using CmsConfeitaria.Business.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration;
using CmsConfeitaria.Integration.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CmsConfeitaria.Business
{
    public class UnidadeMedidaService : IUnidadeMedidaService
    {
        private readonly DBContextCm _context;
        private readonly IMapper _mapper;
        public UnidadeMedidaService(DBContextCm context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<UnidadeMedidaOutput> BuscarLista()
        {
            IEnumerable<UnidadeMedida> ListaUnidadeMedidas = _context.UnidadeMedida.AsEnumerable();
            List<UnidadeMedidaOutput> ListaUnidadeMedidasInput = _mapper.Map<List<UnidadeMedidaOutput>>(ListaUnidadeMedidas);
            return ListaUnidadeMedidasInput;
        }
        public bool Adicionar(UnidadeMedidaOutput unidademedidaInput)
        {
            UnidadeMedida unidadeMedida = _mapper.Map<UnidadeMedida>(unidademedidaInput);

            if (!_context.UnidadeMedida.Any(x => x.Nome == unidadeMedida.Nome || x.Sigla == unidadeMedida.Sigla))
            {
                if (unidadeMedida.Id == 0)
                {
                    _context.UnidadeMedida.Add(unidadeMedida);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    _context.UnidadeMedida.Update(unidadeMedida);
                    _context.SaveChanges();
                    return true;
                }
            }
            else
                throw new Exception("nome ou sigla já existente");
        }

        public bool Excluir(UnidadeMedidaOutput unidademedidaInput)
        {
            UnidadeMedida unidadeMedida = _mapper.Map<UnidadeMedida>(unidademedidaInput);
            _context.UnidadeMedida.Remove(unidadeMedida);
            _context.SaveChanges();
            return true;
        }
    }
}
