using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaWebAPI.Infrastructure.Context;

namespace PruebaWebAPI.CQRS.Commands.DeleteEmployee
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly AppDbContext _context;

        public DeleteEmployeeHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);

            if (employee == null)
                return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
