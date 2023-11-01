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
        public List<UnidadeMedidaOutput> BuscarLista();
        public bool Adicionar(UnidadeMedidaInput unidademedidaInput);
        public bool Excluir(UnidadeMedidaInput unidademedidaInput);
    }
}
