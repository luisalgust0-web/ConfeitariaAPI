﻿using CmsConfeitaria.Core.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Integration.ViewModels
{
    public class ReceitaOutput 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public string ModoPreparo { get; set; }
        public IFormFile? File { get; set; }
    }
}
