using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;

namespace CmsConfeitaria.Business.Services.Interfaces
{
    public interface ReceitaService
    {
        public ReceitaOutput Adicionar(ReceitaInput input);
        public ReceitaOutput Editar(int id, ReceitaInput input);
        public int Excluir(int id);
        public List<ReceitaOutput> ObterLista();
        public ReceitaOutput ObterIngrediente(int id);
        public ValorReceitaOutput CustoReceita(int receitaId);
    }
}
