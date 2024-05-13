using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.Repositories.Interfaces
{
    public interface UsuarioRepository
    {
        public Usuario Cadastrar(UsuarioInput usuarioInput);
        public Usuario Editar(int id, UsuarioInput usuarioInput);
        public int Excluir(int id);
    }
}
