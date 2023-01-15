using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace lab5.Pages.User
{
    public class DeleteModel : PageModel
    {
        private readonly TicketContext _context;
        public lab5.Models.User? user { get; set; }
        public DeleteModel(TicketContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            var person = await _context.Users.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            _context.Users.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");

        }
    }
}
