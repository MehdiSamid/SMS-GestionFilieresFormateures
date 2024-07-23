namespace SMS.Domain.Entities
{
    public class FiliereUnitOfFormation
    {
        public Guid FiliereId { get; set; }
        public Filiere Filiere { get; set; }

        public Guid UnitOfFormationId { get; set; }
        public UnitOfFormation UnitOfFormation { get; set; }
    }
}
