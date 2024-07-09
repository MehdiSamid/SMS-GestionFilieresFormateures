using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;

public class FiliereDbContext : DbContext
{
    public FiliereDbContext(DbContextOptions<FiliereDbContext> options) : base(options)
    {
    }

    public FiliereDbContext(DbSet<Formateur> formateurs, DbSet<Filiere> filieres)
    {
        Formateurs = formateurs;
        Filieres = filieres;
    }

    // DbSet properties...
    public DbSet<Formateur> Formateurs { get; set; }
    public DbSet<Filiere> Filieres { get; set; }
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
                    baseEntity.CreatedAt = DateTime.Now;
                    break;
                case EntityState.Modified:
                    baseEntity.UpdatedAt = DateTime.Now;
                    break;
                case EntityState.Deleted:
                    baseEntity.DeletedAt = DateTime.Now;
                    baseEntity.IsDeleted = true;
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

        base.OnModelCreating(modelBuilder);
    }

}

