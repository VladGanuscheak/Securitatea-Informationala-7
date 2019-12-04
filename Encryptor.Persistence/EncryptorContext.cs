using Encryption.Domain;
using Encryption.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Encryptor.Persistence
{
    public class EncryptorContext : DbContext, IEncryptorContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public EncryptorContext(DbContextOptions<EncryptorContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().Ignore(x => x.Name);

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = Guid.NewGuid(), FirstName = "Vlad", LastName = "G", Password = "passwD." });
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = Guid.NewGuid(), FirstName = "Easy", LastName = "E", Password = "EE" });
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = Guid.NewGuid(), FirstName = "Unknown", LastName = "", Password = "nooasswd" });
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = Guid.NewGuid(), FirstName = "Inkognito", LastName = ";)", Password = "lolHz" });
            
            base.OnModelCreating(modelBuilder);
        }

        public override DbSet<EntityType> Set<EntityType>()
        {
            return base.Set<EntityType>();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
