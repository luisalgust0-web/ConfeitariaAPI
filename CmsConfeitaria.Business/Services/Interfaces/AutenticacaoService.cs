using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.Services.Interfaces
{
    public interface AutenticacaoService
    {
        public AutenticacaoOutput EstaAutenticado(AutenticacaoInput input);
    }
}
