using lab4.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers
{
    public class TicketsController : Controller
    {
        TicketContext _context;
        public TicketsController(TicketContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Tickets> tickets = _context.Tickets;
            return View(tickets);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tickets ticket)
        {

            if (ModelState.IsValid)
            {
                await _context.Tickets.AddAsync(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ticket);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Tickets ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Tickets.Update(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteP(int? id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}