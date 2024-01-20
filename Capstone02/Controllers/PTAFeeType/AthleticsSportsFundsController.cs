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
    public class AthleticsSportsFundsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AthleticsSportsFundsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AthleticsSportsFunds
        public IActionResult Index()
        {
            var athleticsSportsFundTransactions = _context.Transactions
            .Include(t => t.PTAFee)  // Include PTAFee to avoid lazy loading issues
            .Where(t => t.PTAFee != null && t.PTAFee.Type == "Athletics/Sports Fund")
            .ToList();

            // Calculate total amount for Red Cross fees
            decimal totalAmount = athleticsSportsFundTransactions.Sum(t => t.PTAFee.Amount);

            ViewBag.TotalAmount = totalAmount;
            return View(athleticsSportsFundTransactions);
        }

        //// GET: AthleticsSportsFunds/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.aAhleticsSportsFunds == null)
        //    {
        //        return NotFound();
        //    }

        //    var athleticsSportsFund = await _context.aAhleticsSportsFunds
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (athleticsSportsFund == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(athleticsSportsFund);
        //}

        //// GET: AthleticsSportsFunds/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AthleticsSportsFunds/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] AthleticsSportsFund athleticsSportsFund)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(athleticsSportsFund);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(athleticsSportsFund);
        //}

        //// GET: AthleticsSportsFunds/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.aAhleticsSportsFunds == null)
        //    {
        //        return NotFound();
        //    }

        //    var athleticsSportsFund = await _context.aAhleticsSportsFunds.FindAsync(id);
        //    if (athleticsSportsFund == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(athleticsSportsFund);
        //}

        //// POST: AthleticsSportsFunds/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] AthleticsSportsFund athleticsSportsFund)
        //{
        //    if (id != athleticsSportsFund.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(athleticsSportsFund);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AthleticsSportsFundExists(athleticsSportsFund.Id))
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
        //    return View(athleticsSportsFund);
        //}

        //// GET: AthleticsSportsFunds/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.aAhleticsSportsFunds == null)
        //    {
        //        return NotFound();
        //    }

        //    var athleticsSportsFund = await _context.aAhleticsSportsFunds
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (athleticsSportsFund == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(athleticsSportsFund);
        //}

        //// POST: AthleticsSportsFunds/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.aAhleticsSportsFunds == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.aAhleticsSportsFunds'  is null.");
        //    }
        //    var athleticsSportsFund = await _context.aAhleticsSportsFunds.FindAsync(id);
        //    if (athleticsSportsFund != null)
        //    {
        //        _context.aAhleticsSportsFunds.Remove(athleticsSportsFund);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AthleticsSportsFundExists(int id)
        //{
        //  return (_context.aAhleticsSportsFunds?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
