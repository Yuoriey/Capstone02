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
    public class BoyGirlsScoutsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoyGirlsScoutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BoyGirlsScouts
        public IActionResult Index()
        {
            var boyGirlScoutTransactions = _context.Transactions
            .Include(t => t.PTAFee)  // Include PTAFee to avoid lazy loading issues
            .Where(t => t.PTAFee != null && t.PTAFee.Type == "Boy/Girls Scout")
            .ToList();

            // Calculate total amount for Red Cross fees
            decimal totalAmount = boyGirlScoutTransactions.Sum(t => t.PTAFee.Amount);

            ViewBag.TotalAmount = totalAmount;
            return View(boyGirlScoutTransactions);
        }

        //// GET: BoyGirlsScouts/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.BoyGirlsScouts == null)
        //    {
        //        return NotFound();
        //    }

        //    var boyGirlsScout = await _context.BoyGirlsScouts
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (boyGirlsScout == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(boyGirlsScout);
        //}

        //// GET: BoyGirlsScouts/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: BoyGirlsScouts/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] BoyGirlsScout boyGirlsScout)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(boyGirlsScout);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(boyGirlsScout);
        //}

        //// GET: BoyGirlsScouts/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.BoyGirlsScouts == null)
        //    {
        //        return NotFound();
        //    }

        //    var boyGirlsScout = await _context.BoyGirlsScouts.FindAsync(id);
        //    if (boyGirlsScout == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(boyGirlsScout);
        //}

        //// POST: BoyGirlsScouts/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] BoyGirlsScout boyGirlsScout)
        //{
        //    if (id != boyGirlsScout.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(boyGirlsScout);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BoyGirlsScoutExists(boyGirlsScout.Id))
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
        //    return View(boyGirlsScout);
        //}

        //// GET: BoyGirlsScouts/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.BoyGirlsScouts == null)
        //    {
        //        return NotFound();
        //    }

        //    var boyGirlsScout = await _context.BoyGirlsScouts
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (boyGirlsScout == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(boyGirlsScout);
        //}

        //// POST: BoyGirlsScouts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.BoyGirlsScouts == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.BoyGirlsScouts'  is null.");
        //    }
        //    var boyGirlsScout = await _context.BoyGirlsScouts.FindAsync(id);
        //    if (boyGirlsScout != null)
        //    {
        //        _context.BoyGirlsScouts.Remove(boyGirlsScout);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BoyGirlsScoutExists(int id)
        //{
        //  return (_context.BoyGirlsScouts?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
