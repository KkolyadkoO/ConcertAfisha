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
            .Property(c => c.Title)
            .IsRequired();
        
        builder
            .HasMany(c => c.Members)
            .WithOne()
            .HasForeignKey(f => f.ConcertId)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasOne<Location>()
            .WithMany()
            .HasForeignKey(e => e.LocationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}