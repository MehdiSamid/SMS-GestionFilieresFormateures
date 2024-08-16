using MediatR;
using System;

namespace SMS.Application.Commands.Seances
{
    public class UpdateSeanceCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string IdFiliere { get; set; }
        public string IdUniteFormation { get; set; }
        public string IdGroupe { get; set; }
        public DateTime Date { get; set; }
        public int SeanceIndex { get; set; }
        public string IdSalle { get; set; }
        public string IdEmploi { get; set; }
        public string IdFormateur { get; set; }
    }
}
