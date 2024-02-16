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
    public class IngredienteProfile : Profile
    {
        public IngredienteProfile()
        {
            CreateMap<Ingrediente, IngredienteOutput>(MemberList.None);

            CreateMap<IngredienteInput, Ingrediente>(MemberList.None);
        }
    }
}
