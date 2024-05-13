using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Integration.ViewModels.Inputs
{
    public class CompraIngredienteInput
    {
        public int Id { get; set; }
        public int IngredienteId { get; set; }
        public int UnidadeMedidaId { get; set; }
        public double Quantidade { get; set; }
        public DateTime DataCompra { get; set; }
        public double Valor { get; set; }
    }
}
