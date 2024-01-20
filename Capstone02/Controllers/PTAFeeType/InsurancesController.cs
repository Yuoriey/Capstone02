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
    public class InsurancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InsurancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Insurances
        public IActionResult Index()
        {
            var insuranceTransactions = _context.Transactions
            .Include(t => t.PTAFee)  // Include PTAFee to avoid lazy loading issues
            .Where(t => t.PTAFee != null && t.PTAFee.Type == "Insurance")
            .ToList();

            // Calculate total amount for Red Cross fees
            decimal totalAmount = insuranceTransactions.Sum(t => t.PTAFee.Amount);

            ViewBag.TotalAmount = totalAmount;
            return View(insuranceTransactions);
        }

        //// GET: Insurances/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Insurances == null)
        //    {
        //        return NotFound();
        //    }

        //    var insurance = await _context.Insurances
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (insurance == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(insurance);
        //}

        //// GET: Insurances/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Insurances/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] Insurance insurance)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(insurance);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(insurance);
        //}

        //// GET: Insurances/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Insurances == null)
        //    {
        //        return NotFound();
        //    }

        //    var insurance = await _context.Insurances.FindAsync(id);
        //    if (insurance == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(insurance);
        //}

        //// POST: Insurances/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Insurance insurance)
        //{
        //    if (id != insurance.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(insurance);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!InsuranceExists(insurance.Id))
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
        //    return View(insurance);
        //}

        //// GET: Insurances/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Insurances == null)
        //    {
        //        return NotFound();
        //    }

        //    var insurance = await _context.Insurances
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (insurance == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(insurance);
        //}

        //// POST: Insurances/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Insurances == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Insurances'  is null.");
        //    }
        //    var insurance = await _context.Insurances.FindAsync(id);
        //    if (insurance != null)
        //    {
        //        _context.Insurances.Remove(insurance);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool InsuranceExists(int id)
        //{
        //  return (_context.Insurances?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
