using MediatR;
using PruebaWebAPI.Domain.Entities;
using System.Collections.Generic;

namespace PruebaWebAPI.CQRS.Queries.GetEmployees
{
    public class GetEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
    }
}
