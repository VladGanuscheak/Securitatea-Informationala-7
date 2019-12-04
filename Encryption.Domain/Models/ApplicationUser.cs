using System;

namespace Encryption.Domain.Models
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name => $"{FirstName} {LastName}";

        public string Password { get; set; }
    }
}
