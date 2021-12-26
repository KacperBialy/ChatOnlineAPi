using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChatOnline.Domain.Common;
using System.Reflection;
using ChatOnline.Domain.Entities;
using ChatOnline.Application.Common.Interfaces;

namespace ChatOnline.Persistance
{
    public class ChatOnlineDbContext : DbContext
    {
        private readonly IDateTime _dateTime;
        public ChatOnlineDbContext(DbContextOptions<ChatOnlineDbContext> options, IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
        }

        public DbSet<Password> Messages { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // method indicates all EF CORE configuration (classes which implements IEntityTypeConfiguration)

            modelBuilder.SeedData();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = string.Empty;
                        entry.Entity.Created = _dateTime.Now;
                        entry.Entity.StatusId = 1;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.Modified = _dateTime.Now;
                        entry.Entity.StatusId = 1;
                        break;

                    case EntityState.Deleted:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.Modified = _dateTime.Now;
                        entry.Entity.InactivatedBy = string.Empty;
                        entry.Entity.Inactivated = _dateTime.Now;
                        entry.Entity.StatusId = 0;
                        entry.State = EntityState.Modified; // Show entity framework that we do not want to delete entity
                        break;

                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
