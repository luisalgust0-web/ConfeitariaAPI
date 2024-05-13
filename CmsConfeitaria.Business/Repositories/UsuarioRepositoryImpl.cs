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

        public Usuario Cadastrar(UsuarioInput usuarioInput)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioInput);

            if (!_context.Usuarios.Any(usuario => usuario.NomeUsuario.ToLower() == usuarioInput.NomeUsuario.ToLower()))
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return usuario;
            }
            else
            {
                throw new CmsException("Usuario já cadastrado");
            }

        }

        public Usuario Editar(int id, UsuarioInput usuarioInput)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            usuario.Senha = usuarioInput.Senha;
            usuario.Apelido = usuarioInput.Apelido;

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public int Excluir(int id)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuario);
            return id;
        }
    }
}
