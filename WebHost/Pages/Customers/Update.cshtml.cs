using Application.Customers.Get;
using Application.Customers.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webHost.Pages.Customers
{
    public class UpdateModel : PageModel
    {
        private readonly IMediator _mediator;

        public UpdateModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public CustomerResponse Query;
        public UpdateCustomerCommand Command { get; set; }
        public async Task OnGet(int id)
        {
            Query = await _mediator.Send(new GetCustomerQuery(id));
        }

        public async Task<IActionResult> OnPostAsync(UpdateCustomerCommand query)
        {
            if (!ModelState.IsValid)
                return Page();

            await _mediator.Send(query);
            return RedirectToPage("/Customers/Index");
        }
    }
}
