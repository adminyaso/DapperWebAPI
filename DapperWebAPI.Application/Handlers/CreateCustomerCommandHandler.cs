using DapperWebAPI.Application.Commands;
using DapperWebAPI.Domain.HelperDto;
using DapperWebAPI.Domain.Interfaces;
using MediatR;

namespace DapperWebAPI.Application.Handlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new CustomerJsonDto
            {
                Name = request.Name,
                Email = request.Email
            };

            var customerId = await _customerRepository.AddCustomerAsync(customer);
            return customerId;
        }
    }
}