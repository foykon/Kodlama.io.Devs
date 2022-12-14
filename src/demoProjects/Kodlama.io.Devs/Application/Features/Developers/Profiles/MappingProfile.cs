using Application.Features.Developers.Commands.CreateDeveloper;
using Application.Features.Developers.Commands.LoginDeveloper;
using Application.Features.Developers.Dtos;
using AutoMapper;
using Core.Security.JWT;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developers.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Developer, LoginDeveloperCommand>().ReverseMap();
            CreateMap<Developer, CreateDeveloperCommand>().ReverseMap();
            CreateMap<TokenDto, AccessToken>().ReverseMap();
        }
    }
}
