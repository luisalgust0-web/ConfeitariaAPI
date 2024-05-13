using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.Services.Interfaces
{
    public interface UsuarioService
    {
        public UsuarioOutput Cadastrar(UsuarioInput input);
        public UsuarioOutput Editar(int id, UsuarioInput input);
        public int Excluir(int id);
    }
}
