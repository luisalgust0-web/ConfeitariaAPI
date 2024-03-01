﻿using AutoMapper;
using CmsConfeitaria.Business.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
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
        public List<UnidadeMedidaOutput> ObterUnidadeMedidas()
        {
            IEnumerable<UnidadeMedida> ListaUnidadeMedidas = _context.UnidadeMedida.AsEnumerable();
            List<UnidadeMedidaOutput> ListaUnidadeMedidasOutput = _mapper.Map<List<UnidadeMedidaOutput>>(ListaUnidadeMedidas);
            return ListaUnidadeMedidasOutput;
        }

        public UnidadeMedidaOutput ObterUnidadeMedida(int id)
        {
            UnidadeMedida unidadeMedida = _context.UnidadeMedida.Find(id);
            UnidadeMedidaOutput unidadeMedidaOutput = _mapper.Map<UnidadeMedidaOutput>(unidadeMedida);
            return unidadeMedidaOutput;
        }

        public UnidadeMedidaOutput EnviarUnidadeMedida(UnidadeMedidaInput unidademedidaInput)
        {
            UnidadeMedida unidadeMedida = _mapper.Map<UnidadeMedida>(unidademedidaInput);

            if (unidadeMedida.Id == 0)
            {
                if (!_context.UnidadeMedida.Any(x => x.Nome == unidadeMedida.Nome || x.Sigla == unidadeMedida.Sigla))
                {
                    _context.UnidadeMedida.Add(unidadeMedida);
                    _context.SaveChanges();
                    UnidadeMedidaOutput unidadeMedidaOutput = _mapper.Map<UnidadeMedidaOutput>(unidadeMedida);
                    return unidadeMedidaOutput;
                }
                else
                    throw new CmsException("nome ou sigla já existente");
            }
            else
            {
                _context.UnidadeMedida.Update(unidadeMedida);
                _context.SaveChanges();
                UnidadeMedidaOutput unidadeMedidaOutput = _mapper.Map<UnidadeMedidaOutput>(unidadeMedida);
                return unidadeMedidaOutput;
            }
        }

        public bool ExcluirUnidadeMedida(int id)
        {
            UnidadeMedida unidadeMedida = _context.UnidadeMedida.Find(id);
            _context.UnidadeMedida.Remove(unidadeMedida);
            _context.SaveChanges();
            return true;
        }
    }
}
