using Application.Customers.Remove;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webHost.Pages.Customers
{
    public class RemoveModel : PageModel
    {
        private readonly IMediator _mediator;

        public RemoveModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public DeleteCustomerCommand Command;
        public async Task<IActionResult> OnGetAsync(int id)
        {
            await _mediator.Send(new DeleteCustomerCommand(id));

           return RedirectToPage("/Customers/Index");
        }

    }
}
