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
    public class Anti_TBFundDriveController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Anti_TBFundDriveController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Anti_TBFundDrive
        public IActionResult Index()
        {
            var anti_TBFundDriveTransactions = _context.Transactions
            .Include(t => t.PTAFee)  // Include PTAFee to avoid lazy loading issues
            .Where(t => t.PTAFee != null && t.PTAFee.Type == "Anti-TB Fund Drive")
            .ToList();

            // Calculate total amount for Red Cross fees
            decimal totalAmount = anti_TBFundDriveTransactions.Sum(t => t.PTAFee.Amount);

            ViewBag.TotalAmount = totalAmount;
            return View(anti_TBFundDriveTransactions);
        }

        //// GET: Anti_TBFundDrive/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Anti_TBFundDrives == null)
        //    {
        //        return NotFound();
        //    }

        //    var anti_TBFundDrive = await _context.Anti_TBFundDrives
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (anti_TBFundDrive == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(anti_TBFundDrive);
        //}

        //// GET: Anti_TBFundDrive/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Anti_TBFundDrive/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] Anti_TBFundDrive anti_TBFundDrive)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(anti_TBFundDrive);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(anti_TBFundDrive);
        //}

        //// GET: Anti_TBFundDrive/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Anti_TBFundDrives == null)
        //    {
        //        return NotFound();
        //    }

        //    var anti_TBFundDrive = await _context.Anti_TBFundDrives.FindAsync(id);
        //    if (anti_TBFundDrive == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(anti_TBFundDrive);
        //}

        //// POST: Anti_TBFundDrive/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Anti_TBFundDrive anti_TBFundDrive)
        //{
        //    if (id != anti_TBFundDrive.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(anti_TBFundDrive);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!Anti_TBFundDriveExists(anti_TBFundDrive.Id))
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
        //    return View(anti_TBFundDrive);
        //}

        //// GET: Anti_TBFundDrive/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Anti_TBFundDrives == null)
        //    {
        //        return NotFound();
        //    }

        //    var anti_TBFundDrive = await _context.Anti_TBFundDrives
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (anti_TBFundDrive == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(anti_TBFundDrive);
        //}

        //// POST: Anti_TBFundDrive/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Anti_TBFundDrives == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Anti_TBFundDrives'  is null.");
        //    }
        //    var anti_TBFundDrive = await _context.Anti_TBFundDrives.FindAsync(id);
        //    if (anti_TBFundDrive != null)
        //    {
        //        _context.Anti_TBFundDrives.Remove(anti_TBFundDrive);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool Anti_TBFundDriveExists(int id)
        //{
        //  return (_context.Anti_TBFundDrives?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
