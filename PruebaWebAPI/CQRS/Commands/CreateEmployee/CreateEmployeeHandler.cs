using MediatR;
using PruebaWebAPI.Domain.Entities;
using PruebaWebAPI.Infrastructure.Context;

namespace PruebaWebAPI.CQRS.Commands.CreateEmployee
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly AppDbContext _context;

        public CreateEmployeeHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                CompanyId = request.CompanyId,
                CreatedOn = request.CreatedOn,
                DeletedOn = request.DeletedOn,
                Email = request.Email,
                Fax = request.Fax,
                Name = request.Name,
                Lastlogin = request.Lastlogin,
                Password = request.Password,
                PortalId = request.PortalId,
                RoleId = request.RoleId,
                StatusId = request.StatusId,
                Telephone = request.Telephone,
                UpdatedOn = request.UpdatedOn,
                Username = request.Username
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return employee;
        }
    }
}
