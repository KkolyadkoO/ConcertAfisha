using ConcertAfisha.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConcertAfisha.DataAccess.Configurations;

public class ConcertConfiguration: IEntityTypeConfiguration<Concert>
{
    public void Configure(EntityTypeBuilder<Concert> builder)
    {
        builder.HasKey(a => a.Id);
        
        builder
            .HasIndex(c => c.Title)
            .IsUnique();

        builder
            .Property(c => c.Title)
            .IsRequired();
    }
}