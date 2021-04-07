using System.Collections.Generic;

namespace Domain.Identity.Models
{
    public abstract class Resource
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool Enabled { get; set; } = true;
        public string Description { get; set; }
        public bool ShowInDiscoveryDocument { get; set; } = true;
        public ICollection<string> UserClaims { get; set; } = new HashSet<string>();
        public IDictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
    }
}
