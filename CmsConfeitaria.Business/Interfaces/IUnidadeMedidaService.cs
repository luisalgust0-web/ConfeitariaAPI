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
    public interface IUnidadeMedidaService
    {
        public List<UnidadeMedidaOutput> ObterUnidadeMedidas();
        public UnidadeMedidaOutput ObterUnidadeMedida(int id);
        public UnidadeMedidaOutput EnviarUnidadeMedida(UnidadeMedidaInput unidademedidaInput);
        public bool ExcluirUnidadeMedida(int id);
    }
}
