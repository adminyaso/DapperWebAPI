using DapperWebAPI.Domain.Entities;
using DapperWebAPI.Domain.HelperDto;

namespace DapperWebAPI.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> AddCustomerAsync(CustomerJsonDto customerJsonDto);

        Task<IEnumerable<Customer>> GetCustomersAsync();

        Task<Customer> GetCustomerByIdAsync(int id);

        Task<bool> UpdateCustomerAsync(int id, CustomerJsonDto customerJsonDto);

        Task<bool> DeleteCustomerAsync(int id);
    }
}