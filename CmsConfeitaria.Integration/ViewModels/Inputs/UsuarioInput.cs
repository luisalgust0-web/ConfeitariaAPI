using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Integration.ViewModels.Inputs
{
    public class UsuarioInput
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string LoginNome { get; set; }
        public string Senha { get; set; }
    }
}
