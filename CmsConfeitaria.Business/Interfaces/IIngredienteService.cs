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
    public interface IIngredienteService
    {
        public List<IngredienteOutput> CarregarListaIngredientes();
        public IngredienteOutput ObterIngrediente(int id);
        public IngredienteOutput EnviarIngrediente(IngredienteInput ingredienteInput);
        public bool ExcluirIngrediente(int id);
    }
}
