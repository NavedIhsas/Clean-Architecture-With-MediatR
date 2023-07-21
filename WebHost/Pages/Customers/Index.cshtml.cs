using Domain.Customers;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace webHost.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

    
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Customer> Customers;
        public async Task OnGet()
        {
          Customers= await _context.Customers.AsNoTracking().ToListAsync();
        }
    }
}
