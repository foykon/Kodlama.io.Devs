﻿using Application.Features.Brands.Models;
using Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage;
using Application.Features.ProgramingLanguages.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgramingLanguage, CreatedProgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage, CreateProgramingLanguageCommand>().ReverseMap();

            CreateMap<ProgramingLanguage, DeletedProgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage, DeleteProgramingLanguageCommand>().ReverseMap();

            CreateMap<ProgramingLanguage, UpdatedProgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage, UpdateProgramingLanguageCommand>().ReverseMap();

            CreateMap<IPaginate<ProgramingLanguage>, ProgramingLanguageListModel>().ReverseMap();
            CreateMap<ProgramingLanguage, GetListPorgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage, GetByIdProgramingLanguageDto>().ReverseMap();
        }
    }
}