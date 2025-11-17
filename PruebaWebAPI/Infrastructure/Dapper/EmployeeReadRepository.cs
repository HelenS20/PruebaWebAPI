using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using PruebaWebAPI.Domain.Entities;

namespace PruebaWebAPI.Infrastructure.Dapper
{
    public class EmployeeReadRepository : IEmployeeReadRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public EmployeeReadRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Connection")
                                ?? throw new InvalidOperationException("Connection string 'Connection' not found.");
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using var conn = CreateConnection();
            const string sql = @"
                SELECT Id,
                       CompanyId,
                       CreatedOn,
                       DeletedOn,
                       Email,
                       Fax,
                       Name,
                       Lastlogin,   
                       PortalId,
                       RoleId,
                       StatusId,
                       Telephone,
                       UpdatedOn,
                       Username
                FROM Employees
                ORDER BY Id;
            ";

            var result = await conn.QueryAsync<Employee>(sql);
            return result;
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            using var conn = CreateConnection();
            const string sql = @"
                SELECT Id,
                       CompanyId,
                       CreatedOn,
                       DeletedOn,
                       Email,
                       Fax,
                       Name,
                       Lastlogin,
                       Password,
                       PortalId,
                       RoleId,
                       StatusId,
                       Telephone,
                       UpdatedOn,
                       Username
                FROM Employees
                WHERE Id = @Id;
            ";

            var result = await conn.QueryFirstOrDefaultAsync<Employee>(sql, new { Id = id });
            return result;
        }
    }
}
