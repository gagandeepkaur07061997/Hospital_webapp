using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_webapp.Data;
using Hospital_webapp.Models;

namespace Hospital_webapp.Controllers
{
    public class RecieverdetailsController : Controller
    {
        private readonly Hospital_webappDatabase _context;

        public RecieverdetailsController(Hospital_webappDatabase context)
        {
            _context = context;
        }

        // GET: Recieverdetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recieverdetails.ToListAsync());
        }

        // GET: Recieverdetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recieverdetails = await _context.Recieverdetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recieverdetails == null)
            {
                return NotFound();
            }

            return View(recieverdetails);
        }

        // GET: Recieverdetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recieverdetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email_Id,Address,Mobile_Number")] Recieverdetails recieverdetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recieverdetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recieverdetails);
        }

        // GET: Recieverdetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recieverdetails = await _context.Recieverdetails.FindAsync(id);
            if (recieverdetails == null)
            {
                return NotFound();
            }
            return View(recieverdetails);
        }

        // POST: Recieverdetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email_Id,Address,Mobile_Number")] Recieverdetails recieverdetails)
        {
            if (id != recieverdetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recieverdetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecieverdetailsExists(recieverdetails.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recieverdetails);
        }

        // GET: Recieverdetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recieverdetails = await _context.Recieverdetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recieverdetails == null)
            {
                return NotFound();
            }

            return View(recieverdetails);
        }

        // POST: Recieverdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recieverdetails = await _context.Recieverdetails.FindAsync(id);
            _context.Recieverdetails.Remove(recieverdetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecieverdetailsExists(int id)
        {
            return _context.Recieverdetails.Any(e => e.Id == id);
        }
    }
}
