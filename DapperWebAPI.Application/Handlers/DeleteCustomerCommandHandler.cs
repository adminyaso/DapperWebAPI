using DapperWebAPI.Application.Commands;
using DapperWebAPI.Domain.Interfaces;
using MediatR;

namespace DapperWebAPI.Application.Handlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerRepository _repository;

        public DeleteCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteCustomerAsync(request.Id);
        }
    }
}