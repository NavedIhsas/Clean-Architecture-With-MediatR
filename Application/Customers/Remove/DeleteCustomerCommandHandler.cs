using Domain.Customers;
using Infrastructure.Data;
using MediatR;

namespace Application.Customers.Remove
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ApplicationDbContext _applicationDbContext;
        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, ApplicationDbContext applicationDbContext)
        {
            _customerRepository = customerRepository;
            _applicationDbContext = applicationDbContext;
        }

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer =await _customerRepository.GetAsync(request.CustomerId);
            if (customer != null)
            {
                _customerRepository.Remove( customer);
               await _applicationDbContext.SaveChangesAsync(cancellationToken);
               return;
               
            }


            throw new NullReferenceException($"Customer with this id {request.CustomerId} was not found");
        }
    }
}