using AutoMapper;
using CmsConfeitaria.Business.Interfaces;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration;
using CmsConfeitaria.Integration.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business
{
    public class TemplateEmailService : ITemplateEmailService
    {
        private readonly DBContextCm _context;
        private readonly IMapper _mapper;
        public TemplateEmailService(DBContextCm context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<TemplateEmailInput> getLista()
        {
            IEnumerable<TemplateEmail> enumarabelTemplate = _context.TemplateEmails.AsEnumerable();
            List<TemplateEmailInput> listaTemplate = _mapper.Map<List<TemplateEmailInput>>(enumarabelTemplate);
            return listaTemplate;
        }

        public bool InserirTemplate(TemplateEmailInput input)
        {
            TemplateEmail templateEmail = _mapper.Map<TemplateEmail>(input);
            _context.TemplateEmails.Add(templateEmail);
            _context.SaveChanges();
            return true;
        }
    }
}
