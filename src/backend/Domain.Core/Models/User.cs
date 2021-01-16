using System;
using System.Collections.Generic;
using System.Linq;
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

        public void UpdateClaim(string type, string value)
        {
            var claim = Claims.FirstOrDefault(c => c.Type == type);
            if (claim is not null)
            {
                // For now, Claims are not persisted in MongoDb, so we skip this exception.

                // TODO: throw proper exception
                // throw new Exception("Claim not found");
            }
            else
            {
                Claims.Remove(claim);
                Claims.Add(new Claim(type, value));
            }
        }
    }
}