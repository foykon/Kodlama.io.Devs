using Application.Features.Developers.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developers.Commands.LoginDeveloper
{
    public class LoginDeveloperCommand : UserForLoginDto, IRequest<TokenDto> 
    {
        public class LoginDeveloperCommandHandler : IRequestHandler<LoginDeveloperCommand, TokenDto>
        {
            private readonly IMapper _mapper;
            private readonly IDeveloperRepository _developerRepository;
            private readonly ITokenHelper _tokenHelper;

            public LoginDeveloperCommandHandler(IMapper mapper, IDeveloperRepository developerRepository, ITokenHelper tokenHelper)
            {
                _mapper = mapper;
                _developerRepository = developerRepository;
                _tokenHelper = tokenHelper;
            }

            public async Task<TokenDto> Handle(LoginDeveloperCommand request, CancellationToken cancellationToken)
            {
                Developer developer = await _developerRepository.GetAsync(d => d.Email == request.Email);
                if (developer == null)
                {
                    throw new BusinessException("a");
                }
                if (HashingHelper.VerifyPasswordHash(request.Password, developer.PasswordHash, developer.PasswordSalt) != true)
                {
                    throw new BusinessException("b");
                }
                List<OperationClaim> operationClaims = new List<OperationClaim>();
                foreach (var operationClaim in developer.UserOperationClaims)
                {
                    operationClaims.Add(operationClaim.OperationClaim);
                }
                var token = _tokenHelper.CreateToken(developer, operationClaims);
                TokenDto tokenDto = _mapper.Map<TokenDto>(token);
                return tokenDto;

            }
        } 
    }
}
