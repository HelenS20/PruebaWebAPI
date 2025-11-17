using MediatR;
using PruebaWebAPI.Domain.Entities;
using PruebaWebAPI.Infrastructure.Dapper;

namespace PruebaWebAPI.CQRS.Queries.GetEmployees
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<Employee>>
    {
        private readonly IEmployeeReadRepository _repo;

        public GetEmployeesHandler(IEmployeeReadRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAllAsync();
        }
    }
}
