using CmsConfeitaria.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;

namespace CmsConfeitaria.Business.Repositories.Interfaces
{
    public interface ReceitaRespository
    {

        ReceitaOutput AdicionarReceita(ReceitaInput receitaInput);
        ReceitaOutput EditarReceita(ReceitaInput receitaInput);

        bool ExcluirReceita(int id);
        List<ReceitaOutput> ObterListaReceitas();
        ReceitaOutput ObterReceita(int id);

    }

}

