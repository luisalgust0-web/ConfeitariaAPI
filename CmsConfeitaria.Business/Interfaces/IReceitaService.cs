using CmsConfeitaria.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;

namespace CmsConfeitaria.Business.Interfaces
{
    public interface IReceitaService
    {

        ReceitaOutput EnviarReceita(ReceitaInput receitaInput);
        bool ExcluirReceita(int id);
        List<ReceitaOutput> CarregarListaReceitas();
        ReceitaOutput CarregarReceita(int id);

    }

}

