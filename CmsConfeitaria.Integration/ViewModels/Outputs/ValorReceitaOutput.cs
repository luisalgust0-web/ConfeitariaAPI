using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Integration.ViewModels.Outputs
{
    public class ValorReceitaOutput
    {
        public string NomeReceita { get; set; }
        public List<ValorIngredienteOutput> Ingredientes { get; set; }
        public double ValorTotal { get; set; }

        public ValorReceitaOutput()
        {
            Ingredientes = new List<ValorIngredienteOutput>();
        }

    }
}
