namespace SMS.Application.DTOs.UnitOfFormations
{
    public class AddUnitofFormationDto
    {
        public string Name { get; set; } = string.Empty;
        public string Semestre { get; set; }
        public int Duration { get; set; }
        public int Coefficient { get; set; }
        public Guid FiliereId { get; set; }
    }

}
