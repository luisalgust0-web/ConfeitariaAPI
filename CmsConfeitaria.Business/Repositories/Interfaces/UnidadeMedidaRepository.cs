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
    public interface UnidadeMedidaRepository
    {
        public List<UnidadeMedidaOutput> ObterListaUnidadeMedidas();
        public UnidadeMedidaOutput ObterUnidadeMedida(int id);
        public UnidadeMedidaOutput AdicionarUnidadeMedida(UnidadeMedidaInput unidademedidaInput);
        public UnidadeMedidaOutput EditarUnidadeMedida(UnidadeMedidaInput unidademedidaInput);
        public bool ExcluirUnidadeMedida(int id);
    }
}
