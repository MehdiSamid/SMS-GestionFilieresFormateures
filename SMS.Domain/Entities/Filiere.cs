using System.Text.Json.Serialization;

namespace SMS.Domain.Entities
{
    public class Filiere : BaseEntity
    {
        public string NomFiliere { get; set; }
        public string Description { get; set; }
        public string Niveau { get; set; }
        public int Duree { get; set; }
        public int Capacite { get; set; }
        public int GroupCapacity { get; set; }
        public decimal FraisInscription { get; set; }
        public decimal MontantMensuel { get; set; }
        public decimal MontantAnnuel { get; set; }
        public decimal MontantTrimestre { get; set; }

        [JsonIgnore]
        public ICollection<FiliereUnitOfFormation> FiliereUnitOfFormations { get; set; }
    }
}