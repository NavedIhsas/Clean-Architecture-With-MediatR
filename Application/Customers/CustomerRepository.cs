using Domain.Customers;
using Infrastructure.Data;

namespace Application.Customers
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetAsync(int id)
        {
          return await _context.Customers.FindAsync(id);
           
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Remove(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }
    }
}
