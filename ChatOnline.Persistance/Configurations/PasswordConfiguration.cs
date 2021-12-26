using ChatOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatOnline.Persistance.Configurations
{
    public class PasswordConfiguration : IEntityTypeConfiguration<Password>
    {
        public void Configure(EntityTypeBuilder<Password> builder)
        {
            builder.ToTable("Passwords");

            builder.HasKey(p => p.Id);

            builder.Property(p=>p.UserId).IsRequired();
            builder.Property(p=>p.HashPassword).IsRequired();

        }
    }
}
