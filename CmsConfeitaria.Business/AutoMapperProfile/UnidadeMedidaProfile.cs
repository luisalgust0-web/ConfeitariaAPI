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
    public class UnidadeMedidaProfile : Profile
    {
        public UnidadeMedidaProfile()
        {
            CreateMap<UnidadeMedida, UnidadeMedidaOutput>(MemberList.None);

            CreateMap<UnidadeMedidaInput, UnidadeMedida>(MemberList.None);
        }
    }
}
