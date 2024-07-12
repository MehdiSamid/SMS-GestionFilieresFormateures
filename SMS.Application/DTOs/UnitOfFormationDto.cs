using System;

namespace SMS.Application.DTOs
{
    public class UnitOfFormationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid IdFiliere { get; set; }
        public int Duration { get; set; }
    }
}
