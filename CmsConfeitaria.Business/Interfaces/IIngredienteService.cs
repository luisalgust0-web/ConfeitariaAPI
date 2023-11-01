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
        public List<IngredienteOutput> BuscarLista();
        public bool Adicionar(IngredienteInput ingredienteInput);
        public bool Excluir(IngredienteInput ingredienteInput);
    }
}
