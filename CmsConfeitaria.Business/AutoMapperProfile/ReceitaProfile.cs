using AutoMapper;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.AutoMapperProfile
{
    public class ReceitaProfile : Profile
    {
        public ReceitaProfile()
        {
            CreateMap<Receita, ReceitaOutput>(MemberList.None);

            CreateMap<ReceitaInput, Receita>(MemberList.None);

            CreateMap<ReceitaOutput, Receita>(MemberList.None);
        }
    }
}
