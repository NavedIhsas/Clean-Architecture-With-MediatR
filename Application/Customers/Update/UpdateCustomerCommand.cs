using MediatR;

namespace Application.Customers.Update
{
    public record UpdateCustomerCommand(int Id, string Firstname, string Lastname, DateTime DateOfBirth, string PhoneNumber, string Email, string BankAccountNumber) : IRequest
    {
    }
}
