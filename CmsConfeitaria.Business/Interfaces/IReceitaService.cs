using CmsConfeitaria.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmsConfeitaria.Integration.ViewModels;

namespace CmsConfeitaria.Business.Interfaces
{
    public interface IReceitaService
    {
     
            bool Adicionar(ReceitaOutput receitaInput);
            bool Excluir(ReceitaOutput receitaInput);
            List<ReceitaOutput> BuscarLista();
            Receita BuscarPorId(int id);
            ReceitaOutput BuscarReceitaPorNome(string nome);
            List<ReceitaOutput> BuscarReceitaPorIngredientes(string Ingrediente);

    }

}

