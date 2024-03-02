using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.Repositories.Interfaces
{
    public interface ReceitaIngredienteRepository
    {
        public ReceitaIngredienteOutput AdicionarReceitaIngrediente(ReceitaIngredienteInput receitaIngredienteInput);
        public ReceitaIngredienteOutput EditarReceitaIngrediente(ReceitaIngredienteInput receitaIngredienteInput);
        List<ReceitaIngredienteOutput> ObterListaReceitaIngredientes();
        ReceitaIngredienteOutput ObterReceitaIngrediente(int id);
        public bool ExcluirReceitaIngrediente(int id);
        public List<ReceitaIngredienteOutput> ObterListaReceitaIngredientesPorReceita(int receitaId);
    }
}
