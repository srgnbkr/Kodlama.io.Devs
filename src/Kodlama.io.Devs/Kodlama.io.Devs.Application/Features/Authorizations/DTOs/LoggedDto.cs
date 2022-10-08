using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Enums;

namespace Kodlama.io.Devs.Application.Features.Authorizations.DTOs
{
    public class LoggedDto
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
        public AuthenticatorType? RequiredAuthenticatorType { get; set; }

        public LoggedResponseDto CreateResponseDto()
        {
            return new() { AccessToken = AccessToken, RequiredAuthenticatorType = RequiredAuthenticatorType };
        }


        public class LoggedResponseDto
        {
            public AccessToken AccessToken { get; set; }
            public AuthenticatorType? RequiredAuthenticatorType { get; set; }
        }
    }
}
