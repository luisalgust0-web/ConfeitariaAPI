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
        public UsuarioOutput AdicionarUsuario(UsuarioInput usuarioInput);
        public UsuarioOutput EditarUsuario(UsuarioInput usuarioInput);
        public bool ExcluirUsuario(int id);
    }
}
