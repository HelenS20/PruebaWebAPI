using PruebaWebAPI.Domain.Entities;

namespace PruebaWebAPI.Infrastructure.Dapper
{
    public interface IEmployeeReadRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
    }
}