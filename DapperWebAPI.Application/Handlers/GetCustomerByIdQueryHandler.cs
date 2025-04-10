using DapperWebAPI.Application.Queries;
using DapperWebAPI.Domain.Entities;
using DapperWebAPI.Domain.Interfaces;
using MediatR;

namespace DapperWebAPI.Application.Handlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer?>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerByIdQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Customer?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCustomerByIdAsync(request.Id);
        }
    }
}