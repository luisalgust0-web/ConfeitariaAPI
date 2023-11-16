using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Core.Entity
{
    public class ImagemReceita
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public byte[]? ImagemFile { get; set; }
        public byte[]? File { get; set; }
        public int ReceitaId { get; set; }

        public Receita Receita { get; set; }
    }
}
