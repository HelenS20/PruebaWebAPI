using MediatR;

namespace PruebaWebAPI.CQRS.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
