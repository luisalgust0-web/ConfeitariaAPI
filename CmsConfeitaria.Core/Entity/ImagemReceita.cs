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
<<<<<<< HEAD
        public byte[]? File { get; set; }
=======
        public byte[]? ImagemFile { get; set; }
>>>>>>> ace6998ca0dae0047ecbf6a867f07d3e0d446c0b
        public int ReceitaId { get; set; }

        public Receita Receita { get; set; }
    }
}
