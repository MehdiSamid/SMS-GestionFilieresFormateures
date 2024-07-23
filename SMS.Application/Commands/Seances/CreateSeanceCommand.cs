﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Commands.Seances
{
    public class CreateSeanceCommand : IRequest<Guid>
    {
        public string IdFiliere { get; set; }
        public string IdUniteFormation { get; set; }
        public string IdGroupe { get; set; }
        public DateTime Date { get; set; }
        public DateTime hDebut { get; set; }
        public DateTime hFin { get; set; }
        public string IdSalle { get; set; }
        public string IdEmploi { get; set; }
        public string IdFormateur { get; set; }
    }
}
