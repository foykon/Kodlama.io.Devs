using Application.Features.GitHubProfiles.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GitHubProfiles.Commands.UpdateGitHubProfile
{
    public class UpdateGitHubProfileCommand : IRequest<UpdatedGitHubProfileDto>
    {
        public int Id { get; set; }
        public int? DeveloperId { get; set; }
        public string ProfileUrl { get; set; }
        public class UpdateGitHubProfileCommandHandler : IRequestHandler<UpdateGitHubProfileCommand, UpdatedGitHubProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IGitHubProfileRepository _gitHubProfileRepository;

            public UpdateGitHubProfileCommandHandler(IMapper mapper, IGitHubProfileRepository gitHubProfileRepository)
            {
                _mapper = mapper;
                _gitHubProfileRepository = gitHubProfileRepository;
            }

            public async Task<UpdatedGitHubProfileDto> Handle(UpdateGitHubProfileCommand request, CancellationToken cancellationToken)
            {
                GitHubProfile mappedGitHubProfile = _mapper.Map<GitHubProfile>(request);
                GitHubProfile updatedGitHubProfile = await _gitHubProfileRepository.UpdateAsync(mappedGitHubProfile);
                UpdatedGitHubProfileDto updatedGitHubProfileDto = _mapper.Map<UpdatedGitHubProfileDto>(updatedGitHubProfile);
                return updatedGitHubProfileDto;

            }
        }
    }
}
