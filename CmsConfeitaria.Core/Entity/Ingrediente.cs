﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Core.Entity
{
    public class Ingrediente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public int UserId { get; set; }

        public Usuario Usuario { get; set; }
        public List<CompraIngrediente> Compras { get; set; }
        public List<ReceitaIngrediente> ReceitaIngredientes { get; set; }
    }
}
