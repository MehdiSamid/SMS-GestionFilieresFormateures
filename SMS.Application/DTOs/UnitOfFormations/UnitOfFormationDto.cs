namespace SMS.Application.DTOs.UnitOfFormations
{
    public class UnitOfFormationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Semestre { get; set; } = string.Empty;
        public Guid IdFiliere { get; set; }
        public int Duration { get; set; }
        public int Coefficient { get; set; }
    }
}
