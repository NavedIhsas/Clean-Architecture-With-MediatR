using Domain.Customers;
using MediatR;

namespace Application.Customers.Remove
{
    public record DeleteCustomerCommand(int CustomerId):IRequest

    {
    }
}
