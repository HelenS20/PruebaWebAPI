using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaWebAPI.CQRS.Commands.CreateEmployee;
using PruebaWebAPI.CQRS.Commands.UpdateEmployee;
using PruebaWebAPI.CQRS.Commands.DeleteEmployee;
using PruebaWebAPI.CQRS.Queries.GetEmployees;
using PruebaWebAPI.CQRS.Queries.GetEmployeeById;
using PruebaWebAPI.DTOs;

namespace PruebaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/employee
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var query = new GetEmployeesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/employee/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var query = new GetEmployeeByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST: api/employee
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeCreateDto dto)
        {
            var command = new CreateEmployeeCommand
            {
                CompanyId = dto.CompanyId,
                CreatedOn = dto.CreatedOn,
                DeletedOn = dto.DeletedOn,
                Email = dto.Email,
                Fax = dto.Fax,
                Name = dto.Name,
                Lastlogin = dto.Lastlogin,
                Password = dto.Password,
                PortalId = dto.PortalId,
                RoleId = dto.RoleId,
                StatusId = dto.StatusId,
                Telephone = dto.Telephone,
                UpdatedOn = dto.UpdatedOn,
                Username = dto.Username
            };

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetEmployee), new { id = result.Id }, result);
        }

        // PUT: api/employee/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeUpdateDto dto)
        {
            var command = new UpdateEmployeeCommand
            {
                Id = id,
                CompanyId = dto.CompanyId,
                CreatedOn = dto.CreatedOn,
                DeletedOn = dto.DeletedOn,
                Email = dto.Email,
                Fax = dto.Fax,
                Name = dto.Name,
                Lastlogin = dto.Lastlogin,
                Password = dto.Password,
                PortalId = dto.PortalId,
                RoleId = dto.RoleId,
                StatusId = dto.StatusId,
                Telephone = dto.Telephone,
                UpdatedOn = dto.UpdatedOn,
                Username = dto.Username
            };

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/employee/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var command = new DeleteEmployeeCommand { Id = id };
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
