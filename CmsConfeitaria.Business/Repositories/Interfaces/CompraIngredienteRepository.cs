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
    public interface CompraIngredienteRepository
    {
        public CompraIngredienteOutput ObterCompra(int id);
        public CompraIngredienteOutput ObterUltimaCompraPorIngredienteId(int ingredienteId);
        public CompraIngredienteOutput AdicionarCompra(CompraIngredienteInput compraInput);
        public CompraIngredienteOutput EditarCompra(CompraIngredienteInput compraInput);
        public bool ExcluirCompra(int id);
        public List<CompraIngredienteOutput> ObterListaCompras();
    }
}
