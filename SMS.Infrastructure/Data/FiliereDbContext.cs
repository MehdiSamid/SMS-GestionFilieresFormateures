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
}
