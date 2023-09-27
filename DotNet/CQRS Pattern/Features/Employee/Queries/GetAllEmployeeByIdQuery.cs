using CQRS_Pattern.Models;
using CQRS_Pattern.Models.Response;
using MediatR;

namespace CQRS_Pattern.Features.Employee.Queries
{
    public class GetAllEmployeeByIdQuery : IRequest<EmpResponse>
    {
        public int Id { get; set; }

        public class GetAllEmployeeByIdHandler : IRequestHandler<GetAllEmployeeByIdQuery, EmpResponse>
        {
            private readonly sdirectdbContext _Context;
            public GetAllEmployeeByIdHandler(sdirectdbContext Context)
            {
                _Context = Context;
            }
            public async Task<EmpResponse> Handle(GetAllEmployeeByIdQuery request, CancellationToken cancellationToken)
            {
                var objEmp = (from emp in _Context.AstitvaEmp308s
                              where emp.EmpId == request.Id
                              select new EmpResponse()
                              {
                                  EmpId = emp.EmpId,
                                  EmpName = emp.EmpName,
                                  EmpEmail = emp.EmpEmail,
                                  EmpDob = emp.EmpDob,
                                  EmpAddress = emp.EmpAddress
                              }).FirstOrDefault();
                return objEmp;
            }
        }
    }
}
