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
    public interface IngredienteRepository
    {
        public List<IngredienteOutput> ObterListaIngredientes();
        public IngredienteOutput ObterIngrediente(int id);
        public IngredienteOutput AdicionarIngrediente(IngredienteInput ingredienteInput);
        public IngredienteOutput EditarIngrediente(IngredienteInput ingredienteInput);
        public bool ExcluirIngrediente(int id);
    }
}
