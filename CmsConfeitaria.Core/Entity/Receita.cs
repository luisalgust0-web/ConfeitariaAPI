using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Core.Entity
{
    public class Receita
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public string ModoPreparo { get; set; }
        public byte[] Imagem { get; set; }
        public int UserId { get; set; }


        public Usuario user { get; set; }
        public List<ReceitaIngrediente> ReceitaIngredientes { get; set; }
    }
}
