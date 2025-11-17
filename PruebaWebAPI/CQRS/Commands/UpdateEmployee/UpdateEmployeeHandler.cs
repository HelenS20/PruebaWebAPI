using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaWebAPI.Infrastructure.Context;

namespace PruebaWebAPI.CQRS.Commands.UpdateEmployee
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly AppDbContext _context;

        public UpdateEmployeeHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);

            if (employee == null)
                return false;

            employee.CompanyId = request.CompanyId;
            employee.CreatedOn = request.CreatedOn;
            employee.DeletedOn = request.DeletedOn;
            employee.Email = request.Email;
            employee.Fax = request.Fax;
            employee.Name = request.Name;
            employee.Lastlogin = request.Lastlogin;
            employee.Password = request.Password;
            employee.PortalId = request.PortalId;
            employee.RoleId = request.RoleId;
            employee.StatusId = request.StatusId;
            employee.Telephone = request.Telephone;
            employee.UpdatedOn = request.UpdatedOn;
            employee.Username = request.Username;

            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
