using AutoMapper;
using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.Repositories
{
    public class UsuarioRepositoryImpl : UsuarioRepository
    {
        private readonly DBContextCm _context;
        private readonly IMapper _mapper;

        public UsuarioRepositoryImpl(DBContextCm context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UsuarioOutput AdicionarUsuario(UsuarioInput usuarioInput)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioInput);

            if (!_context.Usuarios.Any(usuario => usuario.Nome.ToLower() == usuarioInput.Nome.ToLower()))
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                UsuarioOutput usuarioOutput = _mapper.Map<UsuarioOutput>(usuario);
                return usuarioOutput;
            }
            else
            {
                throw new CmsException("Usuario já cadastrado");
            }

        }

        public UsuarioOutput EditarUsuario(UsuarioInput usuarioInput)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioInput);

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            UsuarioOutput usuarioOutput = _mapper.Map<UsuarioOutput>(usuario);
            return usuarioOutput; ;
        }

        public bool ExcluirUsuario(int id)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuario);
            return true;
        }
    }
}
