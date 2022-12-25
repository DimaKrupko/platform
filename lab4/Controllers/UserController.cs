using lab4.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace lab4.Controllers
{
    public class PersonController : Controller
    {
        TicketContext _context;
        public PersonController(TicketContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Tickets> ticket = _context.Tickets;
            return View(ticket);
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

            var person = await _context.User.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _context.User.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteP(int? id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
