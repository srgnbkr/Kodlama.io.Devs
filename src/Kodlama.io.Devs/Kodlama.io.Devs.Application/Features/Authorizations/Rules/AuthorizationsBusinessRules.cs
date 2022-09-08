using Core.CrossCuttingConcers.Exceptions;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Rules
{
    public class AuthorizationsBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthorizationsBusinessRules(IUserRepository userRepository)
        {
             
            _userRepository = userRepository;
        }
        public async Task UserEmailShouldBeNotExists(string email)
        {
            User user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("User mail already exists.");
        }
    }
}
