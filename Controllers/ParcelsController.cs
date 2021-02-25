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
    public class ParcelsController : Controller
    {
        private readonly Hospital_webappDatabase _context;

        public ParcelsController(Hospital_webappDatabase context)
        {
            _context = context;
        }

        // GET: Parcels
        public async Task<IActionResult> Index()
        {
            var hospital_webappDatabase = _context.Parcel.Include(p => p.Companydetails).Include(p => p.Recieverdetails).Include(p => p.Senderdetails);
            return View(await hospital_webappDatabase.ToListAsync());
        }

        // GET: Parcels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcel = await _context.Parcel
                .Include(p => p.Companydetails)
                .Include(p => p.Recieverdetails)
                .Include(p => p.Senderdetails)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcel == null)
            {
                return NotFound();
            }

            return View(parcel);
        }

        // GET: Parcels/Create
        public IActionResult Create()
        {
            ViewData["CompanydetailsId"] = new SelectList(_context.Companydetails, "Id", "Email_Id");
            ViewData["RecieverdetailsId"] = new SelectList(_context.Recieverdetails, "Id", "Email_Id");
            ViewData["SenderdetailsId"] = new SelectList(_context.Senderdetails, "Id", "Email_Id");
            return View();
        }

        // POST: Parcels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Delivery_address,Parcel_weight,Content_type,Shipping_cost,SenderdetailsId,CompanydetailsId,RecieverdetailsId")] Parcel parcel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parcel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanydetailsId"] = new SelectList(_context.Companydetails, "Id", "Email_Id", parcel.CompanydetailsId);
            ViewData["RecieverdetailsId"] = new SelectList(_context.Recieverdetails, "Id", "Email_Id", parcel.RecieverdetailsId);
            ViewData["SenderdetailsId"] = new SelectList(_context.Senderdetails, "Id", "Email_Id", parcel.SenderdetailsId);
            return View(parcel);
        }

        // GET: Parcels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcel = await _context.Parcel.FindAsync(id);
            if (parcel == null)
            {
                return NotFound();
            }
            ViewData["CompanydetailsId"] = new SelectList(_context.Companydetails, "Id", "Email_Id", parcel.CompanydetailsId);
            ViewData["RecieverdetailsId"] = new SelectList(_context.Recieverdetails, "Id", "Email_Id", parcel.RecieverdetailsId);
            ViewData["SenderdetailsId"] = new SelectList(_context.Senderdetails, "Id", "Email_Id", parcel.SenderdetailsId);
            return View(parcel);
        }

        // POST: Parcels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Delivery_address,Parcel_weight,Content_type,Shipping_cost,SenderdetailsId,CompanydetailsId,RecieverdetailsId")] Parcel parcel)
        {
            if (id != parcel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parcel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParcelExists(parcel.Id))
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
            ViewData["CompanydetailsId"] = new SelectList(_context.Companydetails, "Id", "Email_Id", parcel.CompanydetailsId);
            ViewData["RecieverdetailsId"] = new SelectList(_context.Recieverdetails, "Id", "Email_Id", parcel.RecieverdetailsId);
            ViewData["SenderdetailsId"] = new SelectList(_context.Senderdetails, "Id", "Email_Id", parcel.SenderdetailsId);
            return View(parcel);
        }

        // GET: Parcels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcel = await _context.Parcel
                .Include(p => p.Companydetails)
                .Include(p => p.Recieverdetails)
                .Include(p => p.Senderdetails)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcel == null)
            {
                return NotFound();
            }

            return View(parcel);
        }

        // POST: Parcels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parcel = await _context.Parcel.FindAsync(id);
            _context.Parcel.Remove(parcel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParcelExists(int id)
        {
            return _context.Parcel.Any(e => e.Id == id);
        }
    }
}
