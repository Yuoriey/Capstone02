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
    public class GPTAElectricitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GPTAElectricitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GPTAElectricities
        public IActionResult Index()
        {
            var gptaElectricityTransactions = _context.Transactions
            .Include(t => t.PTAFee)  // Include PTAFee to avoid lazy loading issues
            .Where(t => t.PTAFee != null && t.PTAFee.Type == "GPTA Electricity")
            .ToList();

            // Calculate total amount for Red Cross fees
            decimal totalAmount = gptaElectricityTransactions.Sum(t => t.PTAFee.Amount);

            ViewBag.TotalAmount = totalAmount;
            return View(gptaElectricityTransactions);
        }

        //// GET: GPTAElectricities/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null || _context.GPTAElectricities == null)
        //    {
        //        return NotFound();
        //    }

        //    var gPTAElectricity = await _context.GPTAElectricities
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (gPTAElectricity == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(gPTAElectricity);
        //}

        //// GET: GPTAElectricities/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: GPTAElectricities/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] GPTAElectricity gPTAElectricity)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(gPTAElectricity);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(gPTAElectricity);
        //}

        //// GET: GPTAElectricities/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null || _context.GPTAElectricities == null)
        //    {
        //        return NotFound();
        //    }

        //    var gPTAElectricity = await _context.GPTAElectricities.FindAsync(id);
        //    if (gPTAElectricity == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(gPTAElectricity);
        //}

        //// POST: GPTAElectricities/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("Id,Name")] GPTAElectricity gPTAElectricity)
        //{
        //    if (id != gPTAElectricity.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(gPTAElectricity);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!GPTAElectricityExists(gPTAElectricity.Id))
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
        //    return View(gPTAElectricity);
        //}

        //// GET: GPTAElectricities/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null || _context.GPTAElectricities == null)
        //    {
        //        return NotFound();
        //    }

        //    var gPTAElectricity = await _context.GPTAElectricities
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (gPTAElectricity == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(gPTAElectricity);
        //}

        //// POST: GPTAElectricities/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    if (_context.GPTAElectricities == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.GPTAElectricities'  is null.");
        //    }
        //    var gPTAElectricity = await _context.GPTAElectricities.FindAsync(id);
        //    if (gPTAElectricity != null)
        //    {
        //        _context.GPTAElectricities.Remove(gPTAElectricity);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool GPTAElectricityExists(string id)
        //{
        //  return (_context.GPTAElectricities?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
