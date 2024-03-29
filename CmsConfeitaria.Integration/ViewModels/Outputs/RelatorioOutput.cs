﻿using CmsConfeitaria.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Integration.ViewModels.Inputs
{
    public class RelatorioReceitaOutput
    {
        public string Nome { get; set; }
        public string ModoPreparo { get; set; }
        public double ValorTotalReceita { get; set; }
        public List<RelatorioIngredienteOutput> IngredienteOutputs { get; set; }

        public RelatorioReceitaOutput()
        {
            IngredienteOutputs = new List<RelatorioIngredienteOutput>();
        }
    }
    public class RelatorioIngredienteOutput
    {
        public string NomeIngrediente { get; set; }
        public int QuantidadeTotal { get; set; }
        public double ValorCalculo { get; set; }
        public double QuantidadeReceita { get; set; }
    }

}
