using EmployeeRegistrationApp.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistrationApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeCommand cmd)
        {
            try
            {
                var id = await _mediator.Send(cmd);
                return CreatedAtAction(nameof(Get), new { id }, null);
            }
            catch (Exception ex)
            {
                var errormsg = ex.Message;
                return errormsg.Contains("duplicate") 
                    ? Conflict(errormsg) 
                    : BadRequest(errormsg);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var emp = await _mediator.Send(new GetEmployeeByIdQuery(id));
            if (emp is null) return NotFound();
            return Ok(emp);
        }

        // PUT and DELETE similarly...
    }
}
