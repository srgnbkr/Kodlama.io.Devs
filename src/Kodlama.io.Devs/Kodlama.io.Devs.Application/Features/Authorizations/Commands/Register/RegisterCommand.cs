﻿using Core.Security.DTOs;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authorizations.DTOs;
using Kodlama.io.Devs.Application.Features.Authorizations.Rules;
using Kodlama.io.Devs.Application.Services.AuthService;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Commands.Register
{
    public class RegisterCommand : IRequest<RegisteredDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IPAddress { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly AuthorizationsBusinessRules _authorizationsBusinessRules;
            private readonly IAuthService _authService;

            public RegisterCommandHandler(IUserRepository userRepository, AuthorizationsBusinessRules authorizationsBusinessRules, IAuthService authService)
            {
                _userRepository = userRepository;
                _authorizationsBusinessRules = authorizationsBusinessRules;
                _authService = authService;
            }

            public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authorizationsBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

                byte[] passWordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passWordHash, out passwordSalt);

                User user = new User
                {
                    Email = request.UserForRegisterDto.Email,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    PasswordHash = passWordHash,
                    PasswordSalt = passwordSalt,
                    Status = true,
                    
                };

                User createdUser = await _userRepository.AddAsync(user);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IPAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                RegisteredDto registeredDto = new()
                {
                    AccessToken = createdAccessToken,
                    RefreshToken = addedRefreshToken
                   
                };
                return registeredDto;


            }
        }
    }
}
