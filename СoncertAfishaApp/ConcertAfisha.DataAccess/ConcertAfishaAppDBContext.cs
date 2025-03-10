using ConcertAfisha.Core.Models;
using ConcertAfisha.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ConcertAfisha.DataAccess;

public class ConcertAfishaAppDBContext(DbContextOptions<ConcertAfishaAppDBContext> options) : DbContext(options)
{
public DbSet<Concert> ConcertEntities { get; set; }
public DbSet<Member> MemberEntities { get; set; }
public DbSet<User> UserEntities { get; set; }
public DbSet<RefreshToken> RefreshTokenEntities { get; set; }
public DbSet<Location> LocationsOfEventEntities { get; set; }


protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.ApplyConfiguration(new ConcertConfiguration());
    modelBuilder.ApplyConfiguration(new MemberConfiguration());
    modelBuilder.ApplyConfiguration(new UserConfiguration());
    modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
    modelBuilder.ApplyConfiguration(new LocationConfiguration());

    base.OnModelCreating(modelBuilder);
}
}
