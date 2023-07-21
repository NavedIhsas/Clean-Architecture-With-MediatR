#nullable enable
namespace Domain.Customers
{
    public class Customer
    {
        public Customer()
        {
            
        }
        public Customer( string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
        {
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }

        public void Update(int id, string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }
        public int Id { get; private set; }
        public string Firstname { get;  private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string BankAccountNumber { get; private set; }
    }
}
