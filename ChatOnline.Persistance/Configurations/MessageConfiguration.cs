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
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Content).HasMaxLength(2000).IsRequired();
            builder.Property(p=>p.FriendId).IsRequired();

            builder.HasOne(p => p.User)
                   .WithMany(p => p.Messages)
                   .HasForeignKey(p => p.UserId);
        }

    }
}
