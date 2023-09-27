using CQRS_Pattern.Models;
using CQRS_Pattern.Models.Response;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CQRS_Pattern.Features.Employee.Commands
{
    public class DeleteByIdCommand : IRequest<ResponseDto>
    {
        public int Id { get; set; }
        public class DeleteByIdCommandHandler : IRequestHandler<DeleteByIdCommand, ResponseDto>
        {
            private readonly sdirectdbContext _Context;
            public DeleteByIdCommandHandler(sdirectdbContext Context)
            {
                _Context = Context;
            }

            public async Task<ResponseDto> Handle(DeleteByIdCommand request, CancellationToken cancellationToken)
            {
                ResponseDto res = new ResponseDto();

                try 
                {
                    AstitvaEmp308 data = _Context.AstitvaEmp308s.FirstOrDefault(e => e.EmpId == request.Id);

                    if(data != null)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _Context.SaveChanges();

                        res.StatusCode = 200;
                        res.Message = "Employee Deleted Successfully.";

                        return res;
                    }
                    else
                    {
                        res.StatusCode = 404;
                        res.Message = "Id doesn't exist";
                        return res;
                    }
                }
                catch (Exception ex) 
                {
                    res.StatusCode = 500;
                    res.Message = ex.Message;

                    return res;
                }
            }
        }
    }
}
