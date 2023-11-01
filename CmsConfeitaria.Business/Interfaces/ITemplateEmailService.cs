using CmsConfeitaria.Integration.ViewModels.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.Interfaces
{
    public interface ITemplateEmailService
    {
        public List<TemplateEmailInput> getLista();
        public bool InserirTemplate(TemplateEmailInput input);
    }
}
