using Application.Customers.Create;
using FluentValidation;
using Infrastructure.Data;
using PhoneNumbers;

namespace Application.Customers.Validation
{
    public class CreateCustomerValidation: AbstractValidator<CreateCustomerCommand>
    {
        private readonly ApplicationDbContext _context;

        public CreateCustomerValidation(ApplicationDbContext context)
        {

            _context = context;
            this.RuleFor(x => x.Firstname).Must(IsUniq).WithMessage("This user is exist").NotNull();
            this.RuleFor(x => x.Lastname).NotNull();
            this.RuleFor(x => x.Email).EmailAddress().NotNull();
            this.RuleFor(x => x.PhoneNumber).Must(IsValid).WithMessage("This phone Number is Not valid").NotNull();
            this.RuleFor(x => x.DateOfBirth).NotNull();
        }
        private bool IsUniq(CreateCustomerCommand arg, string arg2)
        {
            return !_context.Customers.Any(x =>
                x.Lastname == arg.Lastname && x.Firstname == arg.Firstname && x.DateOfBirth == arg.DateOfBirth);
        }

        public  bool IsValid(object value)
        {
            var valueString = value as string;
            if (string.IsNullOrEmpty(valueString))
            {
                return true;
            }

            var util = PhoneNumberUtil.GetInstance();
            try
            {
                var number = util.Parse(valueString, "IR");
                return util.IsValidNumber(number);
            }
            catch (NumberParseException)
            {
                return false;
            }
        }
    }
}


