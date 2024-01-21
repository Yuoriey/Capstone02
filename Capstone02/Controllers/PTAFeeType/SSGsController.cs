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
    public class SSGsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SSGsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SSGs
        public IActionResult Index()
        {
            var ssgTransactions = _context.Transactions
            .Include(t => t.PTAFee)  // Include PTAFee to avoid lazy loading issues
            .Where(t => t.PTAFee != null && t.PTAFee.Type == "SSG")
            .ToList();

            // Calculate total amount for Red Cross fees
            decimal totalAmount = ssgTransactions.Sum(t => t.PTAFee.Amount);

            ViewBag.TotalAmount = totalAmount;
            return View(ssgTransactions);
        }

        //// GET: SSGs/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.SSGs == null)
        //    {
        //        return NotFound();
        //    }

        //    var sSG = await _context.SSGs
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (sSG == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(sSG);
        //}

        //// GET: SSGs/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: SSGs/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] SSG sSG)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(sSG);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(sSG);
        //}

        //// GET: SSGs/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.SSGs == null)
        //    {
        //        return NotFound();
        //    }

        //    var sSG = await _context.SSGs.FindAsync(id);
        //    if (sSG == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(sSG);
        //}

        //// POST: SSGs/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] SSG sSG)
        //{
        //    if (id != sSG.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(sSG);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SSGExists(sSG.Id))
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
        //    return View(sSG);
        //}

        //// GET: SSGs/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.SSGs == null)
        //    {
        //        return NotFound();
        //    }

        //    var sSG = await _context.SSGs
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (sSG == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(sSG);
        //}

        //// POST: SSGs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.SSGs == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.SSGs'  is null.");
        //    }
        //    var sSG = await _context.SSGs.FindAsync(id);
        //    if (sSG != null)
        //    {
        //        _context.SSGs.Remove(sSG);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SSGExists(int id)
        //{
        //  return (_context.SSGs?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
