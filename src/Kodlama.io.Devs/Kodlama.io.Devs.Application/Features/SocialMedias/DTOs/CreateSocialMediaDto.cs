﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.SocialMedias.DTOs
{
    public class CreateSocialMediaDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GithubUrl { get; set; }
        public bool IsActive { get; set; }

    }
}
