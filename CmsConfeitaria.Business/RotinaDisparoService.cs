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

namespace CmsConfeitaria.Business
{
    public class RotinaDisparoService : IRotinaDisparoService
    {
        private readonly IMapper _mapper;
        private readonly DBContextCm _context;
        public RotinaDisparoService(IMapper mapper, DBContextCm context)
        {
            _mapper = mapper;
            _context = context;
        }
        public bool AdicionarRotina(RotinaDisparoInput input)
        {
            RotinaDisparo rotinaDisparo = _mapper.Map<RotinaDisparo>(input);
            _context.RotinaDisparos.Add(rotinaDisparo);
            _context.SaveChanges();
            return true;
        }

        public List<RotinaDisparoInput> ListaRotinas()
        {
            IEnumerable<RotinaDisparo> enumerableRotinaDisparo = _context.RotinaDisparos.AsEnumerable();
            List<RotinaDisparoInput> listaRotinaDisparo = _mapper.Map<List<RotinaDisparoInput>>(enumerableRotinaDisparo);
            return listaRotinaDisparo;
        }
    }
}
