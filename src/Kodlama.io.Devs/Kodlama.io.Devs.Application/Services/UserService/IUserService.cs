﻿using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Services.UserService
{
    public  interface IUserService
    {
        public Task<User> GetByEmail(string email);
    }
}
