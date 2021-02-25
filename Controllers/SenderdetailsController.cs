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
    public class SenderdetailsController : Controller
    {
        private readonly Hospital_webappDatabase _context;

        public SenderdetailsController(Hospital_webappDatabase context)
        {
            _context = context;
        }

        // GET: Senderdetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Senderdetails.ToListAsync());
        }

        // GET: Senderdetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var senderdetails = await _context.Senderdetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (senderdetails == null)
            {
                return NotFound();
            }

            return View(senderdetails);
        }

        // GET: Senderdetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Senderdetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email_Id,Address,Mobile_Number")] Senderdetails senderdetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(senderdetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(senderdetails);
        }

        // GET: Senderdetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var senderdetails = await _context.Senderdetails.FindAsync(id);
            if (senderdetails == null)
            {
                return NotFound();
            }
            return View(senderdetails);
        }

        // POST: Senderdetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email_Id,Address,Mobile_Number")] Senderdetails senderdetails)
        {
            if (id != senderdetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(senderdetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SenderdetailsExists(senderdetails.Id))
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
            return View(senderdetails);
        }

        // GET: Senderdetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var senderdetails = await _context.Senderdetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (senderdetails == null)
            {
                return NotFound();
            }

            return View(senderdetails);
        }

        // POST: Senderdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var senderdetails = await _context.Senderdetails.FindAsync(id);
            _context.Senderdetails.Remove(senderdetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SenderdetailsExists(int id)
        {
            return _context.Senderdetails.Any(e => e.Id == id);
        }
    }
}
