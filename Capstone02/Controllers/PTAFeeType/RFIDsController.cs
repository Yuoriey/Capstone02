using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone02.Data;
using Capstone02.Models.PTAFeeType;

namespace Capstone02.Controllers.PTAFeeType
{
    public class RFIDsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RFIDsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RFIDs
        public IActionResult Index()
        {
            var rfidTransactions = _context.Transactions
            .Include(t => t.PTAFee)  // Include PTAFee to avoid lazy loading issues
            .Where(t => t.PTAFee != null && t.PTAFee.Type == "RFID")
            .ToList();

            // Calculate total amount for Red Cross fees
            decimal totalAmount = rfidTransactions.Sum(t => t.PTAFee.Amount);

            ViewBag.TotalAmount = totalAmount;
            return View(rfidTransactions);
        }

        //// GET: RFIDs/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.RFIDs == null)
        //    {
        //        return NotFound();
        //    }

        //    var rFID = await _context.RFIDs
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (rFID == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(rFID);
        //}

        //// GET: RFIDs/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: RFIDs/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] RFID rFID)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(rFID);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(rFID);
        //}

        //// GET: RFIDs/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.RFIDs == null)
        //    {
        //        return NotFound();
        //    }

        //    var rFID = await _context.RFIDs.FindAsync(id);
        //    if (rFID == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(rFID);
        //}

        //// POST: RFIDs/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] RFID rFID)
        //{
        //    if (id != rFID.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(rFID);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RFIDExists(rFID.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(rFID);
        //}

        //// GET: RFIDs/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.RFIDs == null)
        //    {
        //        return NotFound();
        //    }

        //    var rFID = await _context.RFIDs
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (rFID == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(rFID);
        //}

        //// POST: RFIDs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.RFIDs == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.RFIDs'  is null.");
        //    }
        //    var rFID = await _context.RFIDs.FindAsync(id);
        //    if (rFID != null)
        //    {
        //        _context.RFIDs.Remove(rFID);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool RFIDExists(int id)
        //{
        //  return (_context.RFIDs?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
