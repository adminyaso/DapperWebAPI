using DapperWebAPI.Domain.Entities;
using MediatR;

namespace DapperWebAPI.Application.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer?>
    {
        public int Id { get; set; }
    }
}