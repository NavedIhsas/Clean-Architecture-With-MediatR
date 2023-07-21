#nullable enable
namespace Domain.Customers;

public interface ICustomerRepository
{
    Task<Customer?> GetAsync(int id);
    void Add(Customer customer);
    void Remove(Customer customer);
    void Update(Customer customer);

}