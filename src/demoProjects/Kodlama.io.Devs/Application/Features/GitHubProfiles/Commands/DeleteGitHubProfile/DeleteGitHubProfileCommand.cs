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

namespace Application.Features.GitHubProfiles.Commands.DeleteGitHubProfile
{
    public class DeleteGitHubProfileCommand : IRequest<DeletedGitHubProfileDto>
    {
        public int Id { get; set; }

    }
    public class DeleteGitHubProfileCommandHandler : IRequestHandler<DeleteGitHubProfileCommand, DeletedGitHubProfileDto>
    {
        private readonly IMapper _mapper;
        private readonly IGitHubProfileRepository gitHubProfileRepository;

        public DeleteGitHubProfileCommandHandler(IMapper mapper, IGitHubProfileRepository gitHubProfileRepository)
        {
            _mapper = mapper;
            this.gitHubProfileRepository = gitHubProfileRepository;
        }

        public async Task<DeletedGitHubProfileDto> Handle(DeleteGitHubProfileCommand request, CancellationToken cancellationToken)
        {
            GitHubProfile mappedGitHubProfile = _mapper.Map<GitHubProfile>(request);
            GitHubProfile deletedGitHubProfile = await gitHubProfileRepository.DeleteAsync(mappedGitHubProfile);
            DeletedGitHubProfileDto deletedGitHubProfileDto = _mapper.Map<DeletedGitHubProfileDto>(deletedGitHubProfile);
            return deletedGitHubProfileDto;
        }
    }
}
