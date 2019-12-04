using Encryption.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Encryption.Domain
{
    public interface IEncryptorContext
    {
        DbSet<ApplicationUser> ApplicationUsers { get; set; }

        DbSet<EntityType> Set<EntityType>() where EntityType : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
