using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Integration.ViewModels.Outputs
{
    public  class CompraOutput
    {
        public int Id { get; set; }
        public int IngredienteId { get; set; }
        public string NomeIngrediente { get; set; }
        public int UnidadeMedidaId { get; set; }
        public string Sigla { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCompra { get; set; }
        public double Valor { get; set; }
    }
}
