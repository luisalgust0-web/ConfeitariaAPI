﻿using CmsConfeitaria.Integration.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.Interfaces
{
    public interface IAutenticacaoServie
    {
        public AutenticacaoOutput EstaAutenticado(AutenticacaoInput input);
    }
}
