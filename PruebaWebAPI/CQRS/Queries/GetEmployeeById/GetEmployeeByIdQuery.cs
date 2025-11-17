using MediatR;
using PruebaWebAPI.Domain.Entities;

namespace PruebaWebAPI.CQRS.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery : IRequest<Employee?>
    {
        public int Id { get; set; }
    }
}
