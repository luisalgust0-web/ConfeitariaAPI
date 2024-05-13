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
        public List<Ingrediente> ObterLista();
        public Ingrediente ObterIngrediente(int id);
        public Ingrediente Adicionar(ReceitaInput ingredienteInput);
        public Ingrediente Editar(int id, ReceitaInput ingredienteInput);
        public int Excluir(int id);
    }
}
