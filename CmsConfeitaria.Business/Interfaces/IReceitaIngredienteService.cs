using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.Interfaces
{
    public interface IReceitaIngredienteService
    {
        public bool EnviarReceitaIngrediente(ReceitaIngredienteInput receitaIngredienteInput);
        List<ReceitaIngredienteOutput> ObterReceitaIngredientes();
        ReceitaIngredienteOutput ObterReceitaIngrediente(int id);
        public bool ExcluirReceitaIngrediente(int id);
        public List<ReceitaIngredienteOutput> ObterReceitaIngredientesPorReceita(int receitaId);
    }
}
