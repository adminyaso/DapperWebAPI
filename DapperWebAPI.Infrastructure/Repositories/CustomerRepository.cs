using Dapper;
using DapperWebAPI.Domain.Entities;
using DapperWebAPI.Domain.HelperDto;
using DapperWebAPI.Domain.Interfaces;
using DapperWebAPI.Infrastructure.Data;
using System.Data;
using System.Text.Json;

namespace DapperWebAPI.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> AddCustomerAsync(CustomerJsonDto customerJsonDto)
        {
            try
            {
                string json = JsonSerializer.Serialize(customerJsonDto);

                var procedureName = "usp_InsertCustomerJson";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerData", json, DbType.String);

                using (var connection = _context.CreateConnection())
                {
                    var newId = await connection.QuerySingleAsync<int>(
                        procedureName,
                        parameters,
                        commandType: CommandType.StoredProcedure);
                    return newId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddCustomerAsync sırasında hata: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            try
            {
                var procedureName = "usp_GetCustomersJson";
                using (var connection = _context.CreateConnection())
                {
                    var jsonResult = await connection.ExecuteScalarAsync<string>(
                        procedureName,
                        commandType: CommandType.StoredProcedure);

                    if (string.IsNullOrWhiteSpace(jsonResult))
                        return new List<Customer>();

                    var dtos = JsonSerializer.Deserialize<IEnumerable<Customer>>(jsonResult);
                    return dtos ?? new List<Customer>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetCustomersAsync sırasında hata: {ex.Message}");
                throw;
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            try
            {
                var procedureName = "usp_GetCustomerByIdJson";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = _context.CreateConnection())
                {
                    var jsonResult = await connection.ExecuteScalarAsync<string>(
                        procedureName,
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    if (string.IsNullOrWhiteSpace(jsonResult))
                        return null;

                    var dto = JsonSerializer.Deserialize<Customer>(jsonResult);
                    return dto;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetCustomerByIdAsync sırasında hata: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateCustomerAsync(int id, CustomerJsonDto customerJsonDto)
        {
            try
            {
                string json = JsonSerializer.Serialize(customerJsonDto);

                var procedureName = "usp_UpdateCustomerJson";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);
                parameters.Add("CustomerData", json, DbType.String);

                using (var connection = _context.CreateConnection())
                {
                    var affectedRows = await connection.ExecuteAsync(
                        procedureName,
                        parameters,
                        commandType: CommandType.StoredProcedure);
                    return affectedRows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateCustomerAsync sırasında hata: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            try
            {
                var procedureName = "usp_DeleteCustomerJson";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = _context.CreateConnection())
                {
                    var affectedRows = await connection.ExecuteAsync(
                        procedureName,
                        parameters,
                        commandType: CommandType.StoredProcedure);
                    return affectedRows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteCustomerAsync sırasında hata: {ex.Message}");
                throw;
            }
        }
    }
}