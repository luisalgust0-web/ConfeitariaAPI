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
    public class ReceitaIngredienteProfile : Profile
    {
        public ReceitaIngredienteProfile()
        {
            CreateMap<ReceitaIngrediente, ReceitaIngredienteOutput>(MemberList.None)
            .ForMember(x => x.NomeIngrediente, cfg => cfg.MapFrom(src => src.ingrediente.Nome))
            .ForMember(x => x.NomeReceita, cfg => cfg.MapFrom(src => src.Receita.Nome))
            .ForMember(x => x.Sigla, cfg => cfg.MapFrom(src => src.UnidadeMedida.Sigla));

            CreateMap<ReceitaIngredienteInput, ReceitaIngrediente>(MemberList.None);
        }
    }
}
