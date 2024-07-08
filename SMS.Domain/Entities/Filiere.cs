namespace SMS.Domain.Entities
{
    public class Filiere
    {
        public int FiliereID { get; set; }
        public string NomFiliere { get; set; }
        public string Description { get; set; }
        public string Niveau { get; set; }
        public int Duree { get; set; }
        public int Capacite { get; set; }
    }

}
