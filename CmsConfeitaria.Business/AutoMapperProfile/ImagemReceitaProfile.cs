using AutoMapper;
using CmsConfeitaria.Core.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.AutoMapperProfile
{
    internal class ImagemReceitaProfile : Profile
    {
        public ImagemReceitaProfile()
        {
            CreateMap<IFormFile, ImagemReceita>();
        }
    }
}
