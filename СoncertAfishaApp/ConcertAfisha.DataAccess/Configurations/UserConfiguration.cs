using ConcertAfisha.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConcertAfisha.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(a => a.Id);
        builder.HasIndex(u => u.UserEmail)
            .IsUnique();
        builder.HasIndex(u => u.Phone)
            .IsUnique();
        builder
            .HasMany(a => a.Members)
            .WithOne()
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}