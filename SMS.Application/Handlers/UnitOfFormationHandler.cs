using SMS.Application.Commands;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System.Threading.Tasks;

namespace SMS.Application.Handlers
{
    public class UnitOfFormationHandler
    {
        private readonly IUnitOfFormationRepository _repository;

        public UnitOfFormationHandler(IUnitOfFormationRepository repository)
        {
            _repository = repository;
        }

        public async Task<UnitOfFormation> HandleCreateCommand(CreateUnitOfFormationCommand command)
        {
            var unitOfFormation = new UnitOfFormation
            {
                Name = command.Name,
                //IdFiliere = command.IdFiliere,
                Duration = command.Duration
            };

            return await _repository.AddAsync(unitOfFormation);
        }
    }
}
