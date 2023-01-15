using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace lab5.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly TicketContext _context;

        public IndexModel(TicketContext context)
        {
            _context = context;
        }
        public List<lab5.Models.User> Users { get; set; } = null!;
        public void OnGet()
        {
            Users = _context.Users.ToList();
        }
    }
}
