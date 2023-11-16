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

        ReceitaOutput Adicionar(ReceitaInput receitaInput);
        bool Excluir(ReceitaInput receitaInput);
        List<ReceitaOutput> BuscarLista();
        ReceitaOutput BuscarPorId(int id);
        ReceitaOutput BuscarReceitaPorNome(string nome);
        List<ReceitaOutput> BuscarReceitaPorIngredientes(string Ingrediente);

    }

}

