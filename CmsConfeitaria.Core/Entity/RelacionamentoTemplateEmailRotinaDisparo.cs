using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Core.Entity
{
    public class RelacionamentoTemplateEmailRotinaDisparo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TemplateEmailId { get; set; }
        public int RotinaDisparoId { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
