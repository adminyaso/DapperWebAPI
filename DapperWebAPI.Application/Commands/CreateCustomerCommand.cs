using MediatR;

namespace DapperWebAPI.Application.Commands
{
    public class CreateCustomerCommand : IRequest<int> 
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}