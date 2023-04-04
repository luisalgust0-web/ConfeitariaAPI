using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Integration.ViewModels
{
    public class RotinaDisparoInput
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Intervalo { get; set; }
        public int TipoIntervalo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
