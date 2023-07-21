using Application.Customers.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webHost.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;
        public CreateCustomerCommand Command;

        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync(CreateCustomerCommand command)
        {
            if(!ModelState.IsValid)
                return Page();
            await _mediator.Send(command);
           return RedirectToPage("/Customers/Index");


        }
    }
}
