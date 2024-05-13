using AutoMapper;
using CmsConfeitaria.Business.Repositories;
using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Business.Services.Interfaces;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.Services
{
    public class UsuarioServiceImpl : UsuarioService
    {
        private UsuarioRepository _repository;
        private IMapper _mapper;

        public UsuarioServiceImpl(UsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UsuarioOutput Cadastrar(UsuarioInput input)
        {
            UsuarioOutput usuarioOutput = _mapper.Map<UsuarioOutput>(_repository.Cadastrar(input));
            return usuarioOutput;
        }

        public UsuarioOutput Editar(int id, UsuarioInput input)
        {
            UsuarioOutput usuarioOutput = _mapper.Map<UsuarioOutput>(_repository.Editar(id, input));
            return usuarioOutput;
        }

        public int Excluir(int id)
        {
            return _repository.Excluir(id);
        }
    }
}
