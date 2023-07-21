using System.Data.SqlTypes;
using MediatR;

namespace Application.Customers.Create
{
    public record CreateCustomerCommand(string Firstname,string Lastname,DateTime DateOfBirth,string PhoneNumber, string Email,string BankAccountNumber) :IRequest
    {
    }
}
