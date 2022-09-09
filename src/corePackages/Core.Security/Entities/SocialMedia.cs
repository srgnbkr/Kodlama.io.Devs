using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class SocialMedia : Entity
    {
        public int UserId { get; set; }
        public string GithubUrl { get; set; }
        public User User { get; set; }

        public SocialMedia()
        {

        }

        public SocialMedia(int id,bool isActive,int userId,string githubUrl):this()
        {
            Id = id;
            IsActive = isActive;
            UserId = userId;
            GithubUrl = githubUrl;

        }
    }
}
