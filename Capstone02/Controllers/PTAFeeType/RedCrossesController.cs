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
    public class RedCrossesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RedCrossesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RedCrosses
        public IActionResult Index()
        {
            var redCrossTransactions = _context.Transactions
            .Include(t => t.PTAFee)  // Include PTAFee to avoid lazy loading issues
            .Where(t => t.PTAFee != null && t.PTAFee.Type == "RedCross")
            .ToList();

            // Calculate total amount for Red Cross fees
            decimal totalAmount = redCrossTransactions.Sum(t => t.PTAFee.Amount);

            ViewBag.TotalAmount = totalAmount;
            return View(redCrossTransactions);
        }

        // GET: RedCrosses/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.RedCrosses == null)
        //    {
        //        return NotFound();
        //    }

        //    var redCross = await _context.RedCrosses
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (redCross == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(redCross);
        //}

        //// GET: RedCrosses/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: RedCrosses/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] RedCross redCross)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(redCross);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(redCross);
        //}

        //// GET: RedCrosses/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.RedCrosses == null)
        //    {
        //        return NotFound();
        //    }

        //    var redCross = await _context.RedCrosses.FindAsync(id);
        //    if (redCross == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(redCross);
        //}

        //// POST: RedCrosses/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] RedCross redCross)
        //{
        //    if (id != redCross.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(redCross);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RedCrossExists(redCross.Id))
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
        //    return View(redCross);
        //}

        //// GET: RedCrosses/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.RedCrosses == null)
        //    {
        //        return NotFound();
        //    }

        //    var redCross = await _context.RedCrosses
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (redCross == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(redCross);
        //}

        //// POST: RedCrosses/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.RedCrosses == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.RedCrosses'  is null.");
        //    }
        //    var redCross = await _context.RedCrosses.FindAsync(id);
        //    if (redCross != null)
        //    {
        //        _context.RedCrosses.Remove(redCross);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool RedCrossExists(int id)
        //{
        //  return (_context.RedCrosses?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
