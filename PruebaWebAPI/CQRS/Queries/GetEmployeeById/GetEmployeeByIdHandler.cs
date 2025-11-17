using MediatR;
using PruebaWebAPI.Domain.Entities;
using PruebaWebAPI.Infrastructure.Dapper;

namespace PruebaWebAPI.CQRS.Queries.GetEmployeeById
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee?>
    {
        private readonly IEmployeeReadRepository _repo;

        public GetEmployeeByIdHandler(IEmployeeReadRepository repo)
        {
            _repo = repo;
        }

        public async Task<Employee?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByIdAsync(request.Id);
        }
    }
}
