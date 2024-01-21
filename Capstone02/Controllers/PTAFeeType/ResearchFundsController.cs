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
    public class ResearchFundsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResearchFundsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ResearchFunds
        public IActionResult Index()
        {
            var researchFundTransactions = _context.Transactions
            .Include(t => t.PTAFee)  // Include PTAFee to avoid lazy loading issues
            .Where(t => t.PTAFee != null && t.PTAFee.Type == "Research Fund")
            .ToList();

            // Calculate total amount for Red Cross fees
            decimal totalAmount = researchFundTransactions.Sum(t => t.PTAFee.Amount);

            ViewBag.TotalAmount = totalAmount;
            return View(researchFundTransactions);
        }

        //// GET: ResearchFunds/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.ResearchFunds == null)
        //    {
        //        return NotFound();
        //    }

        //    var researchFund = await _context.ResearchFunds
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (researchFund == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(researchFund);
        //}

        //// GET: ResearchFunds/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ResearchFunds/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] ResearchFund researchFund)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(researchFund);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(researchFund);
        //}

        //// GET: ResearchFunds/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.ResearchFunds == null)
        //    {
        //        return NotFound();
        //    }

        //    var researchFund = await _context.ResearchFunds.FindAsync(id);
        //    if (researchFund == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(researchFund);
        //}

        //// POST: ResearchFunds/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ResearchFund researchFund)
        //{
        //    if (id != researchFund.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(researchFund);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ResearchFundExists(researchFund.Id))
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
        //    return View(researchFund);
        //}

        //// GET: ResearchFunds/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.ResearchFunds == null)
        //    {
        //        return NotFound();
        //    }

        //    var researchFund = await _context.ResearchFunds
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (researchFund == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(researchFund);
        //}

        //// POST: ResearchFunds/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.ResearchFunds == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.ResearchFunds'  is null.");
        //    }
        //    var researchFund = await _context.ResearchFunds.FindAsync(id);
        //    if (researchFund != null)
        //    {
        //        _context.ResearchFunds.Remove(researchFund);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ResearchFundExists(int id)
        //{
        //  return (_context.ResearchFunds?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
