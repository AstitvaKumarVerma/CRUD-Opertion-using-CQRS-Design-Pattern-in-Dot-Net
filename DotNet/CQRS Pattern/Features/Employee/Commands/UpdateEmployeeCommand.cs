using CQRS_Pattern.Models;
using CQRS_Pattern.Models.Request;
using CQRS_Pattern.Models.Response;
using MediatR;

namespace CQRS_Pattern.Features.Employee.Commands
{
    public class UpdateEmployeeCommand : UpdateEmpRequest,IRequest<ResponseDto>
    {
       // public UpdateEmpRequest updateReq { get; set; }
        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, ResponseDto>
        {
            private readonly sdirectdbContext _context;
            public UpdateEmployeeCommandHandler(sdirectdbContext context)
            {
                _context = context;
            }
            public async Task<ResponseDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                ResponseDto obj = new ResponseDto();
                try
                {
                    AstitvaEmp308 data = _context.AstitvaEmp308s.FirstOrDefault(e => e.EmpId == request.EmpId);

                    if (data != null)
                    {
                         data.EmpName = request.EmpName;
                         data.EmpEmail = request.EmpEmail;
                         data.EmpDob = request.EmpDob;
                         data.EmpAddress = request.EmpAddress;
                        _context.SaveChanges();

                        obj.StatusCode = 200;
                        obj.Message = "Employee Updated Successfully.";

                        return obj;
                    }
                    else
                    {
                        obj.StatusCode = 400;
                        obj.Message = "Employee Id doesn't exist.";
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
