﻿namespace SMS.Domain.Entities
{
    public class Filiere : BaseEntity
    {
        public string NomFiliere { get; set; }
        public string Description { get; set; }
        public string Niveau { get; set; }
        public int Duree { get; set; }
        public int Capacite { get; set; }
        public decimal FraisInscription { get; set; }
        public decimal MontantMensuel { get; set; }
        public decimal MontantAnnuel { get; set; }
        public decimal MontantTrimestre { get; set; }

        // New properties to link Filiere with UnitOfFormation
        public Guid UnitOfFormationId { get; set; }
        public UnitOfFormation UnitOfFormation { get; set; }
    }
}
