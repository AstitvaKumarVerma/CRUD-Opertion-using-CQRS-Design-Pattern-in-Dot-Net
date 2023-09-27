using CQRS_Pattern.Models;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CQRS_Pattern.Features.Employee.Queries
{
    public class GetAllEmployeeQuery : IRequest<IEnumerable<AstitvaEmp308>>
    {
        public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<AstitvaEmp308>>
        {
            private readonly sdirectdbContext _Context;
            public GetAllEmployeeQueryHandler(sdirectdbContext Context)
            {
                _Context = Context;
            }
            public async Task<IEnumerable<AstitvaEmp308>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
            {
                var objEmp = _Context.AstitvaEmp308s.ToList();
                return objEmp;
            }
        }
    }
}
