﻿using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.Services.Interfaces
{
    public interface RelatorioService
    {
        public FileStreamResult GerarRelatorio(ValorReceitaOutput valorReceita);
    }
}
