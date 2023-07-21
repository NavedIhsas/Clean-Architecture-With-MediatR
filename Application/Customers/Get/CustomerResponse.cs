namespace Application.Customers.Get;

public record CustomerResponse(int Id, string Firstname, string Lastname, DateTime DateOfBirth, string PhoneNumber, string Email,string BankAccountNumber)
{
   
}