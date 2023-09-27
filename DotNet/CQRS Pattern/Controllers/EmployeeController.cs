using CQRS_Pattern.Features.Employee.Commands;
using CQRS_Pattern.Features.Employee.Queries;
using CQRS_Pattern.Models.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        [Route("getAllEmployee")]
        public async Task<IActionResult> getAllEmployee()
        {
            return Ok(await Mediator.Send(new GetAllEmployeeQuery()));
        }


        [HttpGet]
        [Route("getEmployeeByid")]
        public async Task<IActionResult> getEmployeeByid(int id)
        {
            return Ok(await Mediator.Send(new GetAllEmployeeByIdQuery { Id = id }));
        }

        [HttpPost]
        [Route("AddEmployee")]

        public async Task<IActionResult> AddEmployee(CreateEmpRequest model)
        {
            return Ok(await Mediator.Send(new CreateEmployeeCommand { addRequest = model }));
        }
        [HttpPut]
        [Route("UpdateEmployee")]

        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeCommand model)
        {
            return Ok(await Mediator.Send(model));
        }


        [HttpDelete]
        [Route("DeleteEmployeeById")]

        public async Task<IActionResult> DeleteEmployeeById(int id)
        {
            return Ok(await Mediator.Send(new DeleteByIdCommand { Id = id }));
        }
    }
}
