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
    public interface CompraRepository
    {
        public CompraOutput ObterCompra(int id);
        public CompraOutput AdicionarCompra(CompraInput compraInput);
        public CompraOutput EditarCompra(CompraInput compraInput);
        public bool ExcluirCompra(int id);
        public List<CompraOutput> ObterListaCompras();
    }
}
