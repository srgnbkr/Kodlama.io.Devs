using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Services.UserService
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;   
        }

        public async Task<User> GetByEmail(string email)
        {
            User user = await _userRepository.GetAsync(x => x.Email == email);
            return user;
        }
    }
}
