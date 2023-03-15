using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Core.Entity
{
    public class ImagemReceita
    {
        public int Id { get; set; }
        public byte[]? Imagem { get; set; }
        public int ReceitaId { get; set; }

        public Receita Receita { get; set; }
    }
}
