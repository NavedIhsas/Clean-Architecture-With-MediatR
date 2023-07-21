using Domain.Customers;
using Infrastructure.Data;
using MediatR;

namespace Application.Customers.Update;

public class UpdateCustomerCommandHandler:IRequestHandler<UpdateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ApplicationDbContext _applicationDbContext;
    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, ApplicationDbContext applicationDbContext)
    {
        _customerRepository = customerRepository;
        _applicationDbContext = applicationDbContext;
    }

    public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {

        var customer =await _customerRepository.GetAsync(request.Id) ?? throw new NullReferenceException($"Customer with this Id {request.Id} was not found");
       
        var isExist = _applicationDbContext.Customers.Any(x =>
            x.Lastname == request.Lastname && x.Firstname == request.Firstname &&
            x.DateOfBirth == request.DateOfBirth && x.Id != request.Id);
       
        if (isExist)
            return;
        

        customer.Update(request.Id,request.Firstname,request.Lastname,request.DateOfBirth,request.PhoneNumber,request.Email,request.BankAccountNumber);
        _customerRepository.Update(customer);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        
    }
}