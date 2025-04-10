using DapperWebAPI.Application.Queries;
using DapperWebAPI.Domain.Entities;
using DapperWebAPI.Domain.Interfaces;
using MediatR;

namespace DapperWebAPI.Application.Handlers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomersAsync();
        }
    }
}