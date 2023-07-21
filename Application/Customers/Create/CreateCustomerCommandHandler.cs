using Domain.Customers;
using Infrastructure.Data;
using MediatR;

namespace Application.Customers.Create;

public record CreateCustomerCommandHandler:IRequestHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ApplicationDbContext _applicationDbContext;
    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, ApplicationDbContext applicationDbContext)
    {
        _customerRepository = customerRepository;
        _applicationDbContext = applicationDbContext;
    }
    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(request.Firstname, request.Lastname, request.DateOfBirth, request.PhoneNumber,
            request.Email, request.BankAccountNumber);

        if(_applicationDbContext.Customers.Any(x=>x.Lastname==request.Lastname&&x.Firstname==request.Firstname && x.DateOfBirth==request.DateOfBirth))
            return;
        _customerRepository.Add(customer);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}