using Domain.Customers;
using Infrastructure.Data;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.Get
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GetCustomerQueryHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<CustomerResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _applicationDbContext.Customers.Where(x => x.Id == request.Id).Select(x =>
                    new CustomerResponse(x.Id, x.Firstname, x.Lastname, x.DateOfBirth, x.PhoneNumber, x.Email,x.BankAccountNumber))
                .FirstOrDefaultAsync(cancellationToken);

            return customer ?? throw new NullReferenceException("customer was not found");
        }
    }
}
