using MediatR;
using SMS.Application.Queries;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SMS.Application.Handlers
{
    //public class GetSecteurHandler : IRequestHandler<GetSecteurQuery, Secteur>
    //{
    //    private readonly IUnitOfWork _unitOfWork;

    //    public GetSecteurHandler(IUnitOfWork unitOfWork)
    //    {
    //        _unitOfWork = unitOfWork;
    //    }

    //    //public async Task<Secteur> Handle(GetSecteurQuery request, CancellationToken cancellationToken)
    //    //{
    //    //    return await _unitOfWork.SecteurRepository.GetByIdAsync(request.Id);
    //    //}
    //}
}
