using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using System.Linq;

public class FiliereDbContext : DbContext
{
    public FiliereDbContext(DbContextOptions<FiliereDbContext> options) : base(options)
    {
    }

    public FiliereDbContext(DbSet<Formateur> formateurs, DbSet<Filiere> filieres, DbSet<Secteur> secteurs)
    {
        Formateurs = formateurs;
        Filieres = filieres;
        Secteur = secteurs;
    }
    public DbSet<Formateur> Formateurs { get; set; }
    public DbSet<Filiere> Filieres { get; set; }
    public DbSet<Secteur> Secteur { get; set; }
    //public DbSet<AttributionFormateur> AttributionsFormateurs { get; set; }
    //public DbSet<Presence> Presences { get; set; }

    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added ||
                e.State == EntityState.Modified ||
                e.State == EntityState.Deleted));

        foreach (var entityEntry in entries)
        {
            var baseEntity = (BaseEntity)entityEntry.Entity;
            switch (entityEntry.State)
            {
                case EntityState.Added:
                    baseEntity.CreatedAt = DateTime.UtcNow;
                    baseEntity.CreatedBy = GetCurrentUserId(); // Replace with logic to get the current user ID
                    break;
                case EntityState.Modified:
                    baseEntity.UpdatedAt = DateTime.UtcNow;
                    baseEntity.ModifiedBy = GetCurrentUserId(); // Replace with logic to get the current user ID
                    break;
                case EntityState.Deleted:
                    baseEntity.DeletedAt = DateTime.UtcNow;
                    baseEntity.IsDeleted = true;
                    baseEntity.DeletedBy = GetCurrentUserId(); // Replace with logic to get the current user ID
                    entityEntry.State = EntityState.Modified; // Ensure the entity is not removed from the database
                    break;
            }
        }

        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Formateur>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Filiere>().HasQueryFilter(e => !e.IsDeleted);
        //modelBuilder.Entity<Secteur>().HasQueryFilter(e => !e.IsDeleted);

        base.OnModelCreating(modelBuilder);
    }

    private string? GetCurrentUserId()
    {
        // Implement logic to get the current user's ID or return null if not available
        return "system"; // Example value, replace with actual logic
    }
}
