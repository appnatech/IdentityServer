using System;

namespace Domain.Identity.Models
{
    public class Secret
    {
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        public string Type { get; set; }
        public Secret()
        {
            Type = IdentityServerConstants.SecretTypes.SharedSecret;
        }

        public Secret(string value, DateTime? expiration = null) : this()
        {
            Value = value;
            Expiration = expiration;
        }

        public Secret(string value, string description, DateTime? expiration = null) : this()
        {
            Description = description;
            Value = value;
            Expiration = expiration;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + (Value?.GetHashCode() ?? 0);
                hash = hash * 23 + (Type?.GetHashCode() ?? 0);

                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is not Secret other)
            {
                return false;
            }

            if (ReferenceEquals(other, this))
            {
                return true;
            }

            return string.Equals(other.Type, Type, StringComparison.Ordinal) && string.Equals(other.Value, Value, StringComparison.Ordinal);
        }
    }
}
