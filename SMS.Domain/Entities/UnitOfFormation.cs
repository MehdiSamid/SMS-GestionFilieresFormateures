namespace SMS.Domain.Entities
{
    public class UnitOfFormation : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Semestre { get; set; }
        public int Duration { get; set; }
        public int Coefficient { get; set; }

        public ICollection<FiliereUnitOfFormation> FiliereUnitOfFormations { get; set; }
    }
}