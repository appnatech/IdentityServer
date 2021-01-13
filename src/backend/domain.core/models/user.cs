using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;

namespace Domain.Core.Models
{
    public class User
    {
        public string SubjectId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<Claim> Claims { get; set; } = new HashSet<Claim>(new ClaimComparer());
    }
}