using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.Services.Interfaces
{
    public interface IngredienteService
    {
        public ReceitaOutput Adicionar(ReceitaInput input);
        public ReceitaOutput Editar(int id, ReceitaInput input);
        public int Excluir(int id);
        public List<ReceitaOutput> ObterLista();
        public ReceitaOutput ObterIngrediente(int id);
    }
}
