using Application.Features.ProgramingLanguages.Models;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Queries.GetListProgramingLanguage;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Queries.GetByIdProgramingLanguage
{
    public class GetByIdProgramingLanguageQuery : IRequest<GetByIdProgramingLanguageDto>
    {
        public int Id { get; set; }

        public class GetListProgramingLanguageQueryHandler : IRequestHandler<GetByIdProgramingLanguageQuery, GetByIdProgramingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public GetListProgramingLanguageQueryHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;

            }

            public async Task<GetByIdProgramingLanguageDto> Handle(GetByIdProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgramingLanguage programingLanguage = await _programingLanguageRepository.GetAsync(b => b.Id == request.Id);

                _programingLanguageBusinessRules.ProgramingLanguageSouldExistWhenRequested(programingLanguage);

                GetByIdProgramingLanguageDto getByIdProgramingLanguageDto = _mapper.Map<GetByIdProgramingLanguageDto>(programingLanguage);

                return getByIdProgramingLanguageDto;
            }
        }
    }
}
