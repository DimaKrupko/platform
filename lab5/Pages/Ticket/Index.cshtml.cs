using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Ticket
{
    public class IndexModel : PageModel
    {
        private readonly TicketContext _context;

        public IndexModel(TicketContext context)
        {
            _context = context;
        }
        public List<lab5.Models.Ticket> Tickets { get; set; } = null!;
        public void OnGet()
        {
            Tickets = _context.Tickets.ToList();
        }
    }
}
