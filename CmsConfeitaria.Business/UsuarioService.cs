using AutoMapper;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.Interfaces
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DBContextCm _context;
        private readonly IMapper _mapper;

        public UsuarioService(DBContextCm context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;        }
        public bool Adicionar(UsuarioInput usuarioInput)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioInput);
            
            if(usuario.Id == 0){
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return true;
            }
            else
            {
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
                return true;
            }
            
        }
    }
}
