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
    public class CompanydetailsController : Controller
    {
        private readonly Hospital_webappDatabase _context;

        public CompanydetailsController(Hospital_webappDatabase context)
        {
            _context = context;
        }

        // GET: Companydetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Companydetails.ToListAsync());
        }

        // GET: Companydetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companydetails = await _context.Companydetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companydetails == null)
            {
                return NotFound();
            }

            return View(companydetails);
        }

        // GET: Companydetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companydetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email_Id,Address,Mobile_Number,Website")] Companydetails companydetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companydetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companydetails);
        }

        // GET: Companydetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companydetails = await _context.Companydetails.FindAsync(id);
            if (companydetails == null)
            {
                return NotFound();
            }
            return View(companydetails);
        }

        // POST: Companydetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email_Id,Address,Mobile_Number,Website")] Companydetails companydetails)
        {
            if (id != companydetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companydetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanydetailsExists(companydetails.Id))
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
            return View(companydetails);
        }

        // GET: Companydetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companydetails = await _context.Companydetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companydetails == null)
            {
                return NotFound();
            }

            return View(companydetails);
        }

        // POST: Companydetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companydetails = await _context.Companydetails.FindAsync(id);
            _context.Companydetails.Remove(companydetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanydetailsExists(int id)
        {
            return _context.Companydetails.Any(e => e.Id == id);
        }
    }
}
