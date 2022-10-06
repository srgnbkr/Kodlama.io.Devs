using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.DTOs
{
    public class UserOperationClaimListDto
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string OperatinClaimName { get; set; }
        public bool IsActive { get; set; }
    }
}
