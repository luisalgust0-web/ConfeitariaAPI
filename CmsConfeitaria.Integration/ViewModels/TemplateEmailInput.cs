using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Integration.ViewModels
{
    public class TemplateEmailInput
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
