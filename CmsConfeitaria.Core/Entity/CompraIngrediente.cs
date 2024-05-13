using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Core.Entity
{
    public class CompraIngrediente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IngredienteId { get; set; }
        public int UnidadeMedidaId { get; set; }
        public double Quantidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public double Valor { get; set; }

        public Ingrediente Ingrediente { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
    }
}
