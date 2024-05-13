using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Core.Entity
{
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Apelido { get; set; }
        public string Senha { get; set; }

        public List<Receita> Receitas { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
        public List<CompraIngrediente> compraIngredientes { get; set; }
    }
}
