using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration.ViewModels.Inputs;

namespace CmsConfeitaria.Business.Repositories.Interfaces
{
    public interface ReceitaRespository
    {

        Receita Adicionar(ReceitaInput receitaInput);
        Receita Editar(int id, ReceitaInput receitaInput);

        int Excluir(int id);
        List<Receita> ObterLista();
        Receita ObterReceita(int id);

    }

}

