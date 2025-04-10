using MediatR;

namespace DapperWebAPI.Application.Commands
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}