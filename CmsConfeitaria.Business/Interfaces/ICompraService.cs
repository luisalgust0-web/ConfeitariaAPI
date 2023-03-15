using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.Interfaces
{
    public interface ICompraService
    {
        public Compra ObterCompraPorId(int id);
        public bool adicionar(CompraOutput compraInput);
        public bool excluir(CompraOutput compraInput);
        public List<CompraOutput> GetLista();
    }
}
