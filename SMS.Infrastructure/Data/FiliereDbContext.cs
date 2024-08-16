using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using System;
using System.Linq;

public class FiliereDbContext : DbContext
{
    public FiliereDbContext(DbContextOptions<FiliereDbContext> options) : base(options)
    {
    }

    // Define DbSets for each entity
    public DbSet<Formateur> Formateurs { get; set; }
    public DbSet<Filiere> Filieres { get; set; }
    public DbSet<Secteur> Secteurs { get; set; }
    public DbSet<UnitOfFormation> UnitOfFormations { get; set; }
    public DbSet<Absence> Absences { get; set; }
    public DbSet<Seance> Seances { get; set; }
    public DbSet<FiliereUnitOfFormation> FiliereUnitOfFormations { get; set; }
    public DbSet<Emploi> Emplois { get; set; }


    // Override SaveChanges to implement auditing
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

    // Override OnModelCreating to configure entity behaviors
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
        modelBuilder.Entity<UnitOfFormation>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Secteur>().HasQueryFilter(e => !e.IsDeleted);

        // If there are any relationships to configure, do it here
        // e.g. modelBuilder.Entity<Filiere>()
        //         .HasOne(f => f.UnitOfFormation)
        //         .WithMany(u => u.Filieres)
        //         .HasForeignKey(f => f.UnitOfFormationId);
        modelBuilder.Entity<Formateur>().HasQueryFilter(e => !e.IsDeleted && e.DeletedAt == null);
        modelBuilder.Entity<Filiere>().HasQueryFilter(e => !e.IsDeleted && e.DeletedAt == null);
        modelBuilder.Entity<Absence>().HasOne(a => a.Formateur).WithMany().HasForeignKey(a => a.idFormateur);
        modelBuilder.Entity<Absence>().HasOne(a => a.Seance).WithMany().HasForeignKey(a => a.idSeance);
        modelBuilder.Entity<Absence>().HasQueryFilter(e => !e.IsDeleted && e.DeletedAt == null);
        // modelBuilder.Entity<Secteur>().HasQueryFilter(e => !e.IsDeleted); // Uncomment if needed
        modelBuilder.Entity<FiliereUnitOfFormation>()
            .HasKey(fu => new { fu.FiliereId, fu.UnitOfFormationId });

        modelBuilder.Entity<FiliereUnitOfFormation>()
            .HasOne(fu => fu.Filiere)
            .WithMany(f => f.FiliereUnitOfFormations)
            .HasForeignKey(fu => fu.FiliereId);

        modelBuilder.Entity<FiliereUnitOfFormation>()
            .HasOne(fu => fu.UnitOfFormation)
            .WithMany(u => u.FiliereUnitOfFormations)
            .HasForeignKey(fu => fu.UnitOfFormationId);

        base.OnModelCreating(modelBuilder);
    }

    // Example method to get current user ID
    private string? GetCurrentUserId()
    {
        // Implement logic to get the current user's ID or return null if not available
        return "system"; // Example value, replace with actual logic
    }
}
