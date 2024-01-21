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
    public class LearnersAreasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LearnersAreasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LearnersAreas
        public IActionResult Index()
        {
            var learnerAreasTransactions = _context.Transactions
            .Include(t => t.PTAFee)  // Include PTAFee to avoid lazy loading issues
            .Where(t => t.PTAFee != null && t.PTAFee.Type == "Learners Areas")
            .ToList();

            // Calculate total amount for Red Cross fees
            decimal totalAmount = learnerAreasTransactions.Sum(t => t.PTAFee.Amount);

            ViewBag.TotalAmount = totalAmount;
            return View(learnerAreasTransactions);
        }

        //// GET: LearnersAreas/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.LearnersAreas == null)
        //    {
        //        return NotFound();
        //    }

        //    var learnersAreas = await _context.LearnersAreas
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (learnersAreas == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(learnersAreas);
        //}

        //// GET: LearnersAreas/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: LearnersAreas/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] LearnersAreas learnersAreas)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(learnersAreas);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(learnersAreas);
        //}

        //// GET: LearnersAreas/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.LearnersAreas == null)
        //    {
        //        return NotFound();
        //    }

        //    var learnersAreas = await _context.LearnersAreas.FindAsync(id);
        //    if (learnersAreas == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(learnersAreas);
        //}

        //// POST: LearnersAreas/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] LearnersAreas learnersAreas)
        //{
        //    if (id != learnersAreas.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(learnersAreas);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LearnersAreasExists(learnersAreas.Id))
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
        //    return View(learnersAreas);
        //}

        //// GET: LearnersAreas/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.LearnersAreas == null)
        //    {
        //        return NotFound();
        //    }

        //    var learnersAreas = await _context.LearnersAreas
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (learnersAreas == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(learnersAreas);
        //}

        //// POST: LearnersAreas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.LearnersAreas == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.LearnersAreas'  is null.");
        //    }
        //    var learnersAreas = await _context.LearnersAreas.FindAsync(id);
        //    if (learnersAreas != null)
        //    {
        //        _context.LearnersAreas.Remove(learnersAreas);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool LearnersAreasExists(int id)
        //{
        //  return (_context.LearnersAreas?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
