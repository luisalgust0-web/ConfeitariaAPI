using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Integration.ViewModels.Outputs
{
    public class ValorIngredienteOutput
    {
        public string NomeIngrediente { get; set; }
        public double QuantidadeUtilizada { get; set; }
        public double ValorEstimado { get; set; }
    }
}
