using CQRS_Pattern.Models;
using CQRS_Pattern.Models.Request;
using CQRS_Pattern.Models.Response;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CQRS_Pattern.Features.Employee.Commands
{
    public class CreateEmployeeCommand : IRequest<ResponseDto>
    {
        public CreateEmpRequest addRequest { get; set; }
        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, ResponseDto>
        {
            private readonly sdirectdbContext _context;
            public CreateEmployeeCommandHandler(sdirectdbContext context)
            {
                _context = context;
            }
            public async Task<ResponseDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                ResponseDto obj = new ResponseDto();
                try
                {
                    var data = _context.AstitvaEmp308s.FirstOrDefault(e =>  e.EmpName == request.addRequest.EmpName && e.EmpEmail == request.addRequest.EmpEmail && e.EmpDob == request.addRequest.EmpDob);

                    if(data != null) 
                    {
                        obj.StatusCode = 404;
                        obj.Message = "Employee Already Exists.";

                        return obj;
                    }

                    else {
                        var UserData = new AstitvaEmp308()
                        {
                            EmpName = request.addRequest.EmpName,
                            EmpEmail = request.addRequest.EmpEmail,
                            EmpDob = request.addRequest.EmpDob,
                            EmpAddress = request.addRequest.EmpAddress
                        };
                        _context.AstitvaEmp308s.Add(UserData);
                        _context.SaveChanges();
                        obj.StatusCode = 200;
                        obj.Message = "Employee Added Successfully.";

                        return obj;
                    }
                }
                catch (Exception ex)
                {
                    obj.StatusCode = 500;
                    obj.Message = ex.Message;

                    return obj;
                }
            }
        }
    }
}
