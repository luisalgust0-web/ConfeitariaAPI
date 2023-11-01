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
    public class ComrpaProfile : Profile
    {
        public ComrpaProfile()
        {
            CreateMap<Compra, CompraOutput>(MemberList.None).ForMember(x => x.NomeIngrediente, cfg => cfg.MapFrom(src => src.Ingrediente.Nome)).ForMember(x => x.Sigla, cfg => cfg.MapFrom(src => src.UnidadeMedida.Sigla));

            CreateMap<CompraInput, Compra>(MemberList.None);
        }
    }
}
