using CQRS_Pattern.Features.Employee.Commands;
using CQRS_Pattern.Features.EmployeeUsingSP_s.Commands;
using CQRS_Pattern.Models.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeUsingSPController : ControllerBase
    { 
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(CreateEmpBySPCommand model)
        {
            return Ok(await Mediator.Send(model));
        }


        [HttpPut]
        [Route("UpdateEmployee")]

        public async Task<IActionResult> UpdateEmployee(UpdateEmpBySPCommand model)
        {
            return Ok(await Mediator.Send(model));
        }
    }
}
