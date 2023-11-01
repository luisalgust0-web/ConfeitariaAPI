﻿using AutoMapper;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.AutoMapperProfile
{
    public class RotinaProfile : Profile
    {
        public RotinaProfile()
        {
            CreateMap<RotinaDisparo, RotinaDisparoInput>(MemberList.None).ReverseMap();
        }
    }
}
