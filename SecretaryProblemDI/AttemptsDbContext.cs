using Microsoft.EntityFrameworkCore;
using SecretaryProblemDI.Entities;

namespace SecretaryProblemDI;

public class AttemptsDbContext : DbContext
{
    public DbSet<AttemptRecordEntity> AttemptRecordEntities { get; set; }
    
    public DbSet<RatingContenderEntity> RatingContenderEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=db;Username=admin;Password=password");
    }
}