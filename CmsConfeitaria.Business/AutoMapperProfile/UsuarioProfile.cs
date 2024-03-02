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
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioInput>(MemberList.None).ReverseMap();
            CreateMap<Usuario, UsuarioOutput>(MemberList.None);
        }
    }
}
