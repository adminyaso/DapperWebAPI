using DapperWebAPI.Application.Commands;
using DapperWebAPI.Domain.HelperDto;
using DapperWebAPI.Domain.Interfaces;
using MediatR;

namespace DapperWebAPI.Application.Handlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _repository;

        public UpdateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var updateInput = new CustomerJsonDto
            {
                Name = request.Name,
                Email = request.Email
            };

            return await _repository.UpdateCustomerAsync(request.Id, updateInput);
        }
    }
}