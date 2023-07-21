using MediatR;

namespace Application.Customers.Get
{
    public record GetCustomerQuery(int Id):IRequest<CustomerResponse>

    {
    }
}
