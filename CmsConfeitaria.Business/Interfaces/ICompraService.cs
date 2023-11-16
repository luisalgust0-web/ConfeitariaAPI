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
    public interface ICompraService
    {
        public CompraOutput ObterCompraPorId(int id);
        public bool Adicionar(CompraInput compraInput);
        public bool Excluir(CompraInput compraInput);
        public List<CompraOutput> GetLista();
    }
}
