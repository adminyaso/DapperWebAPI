using DapperWebAPI.Domain.Entities;
using MediatR;

namespace DapperWebAPI.Application.Queries
{
    public class GetCustomersQuery : IRequest<IEnumerable<Customer>>
    {
    }
}