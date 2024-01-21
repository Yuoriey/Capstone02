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
    public class PTAMembershipsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PTAMembershipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PTAMemberships
        public IActionResult Index()
        {
            var ptaMembershipTransactions = _context.Transactions
          .Include(t => t.PTAFee)  // Include PTAFee to avoid lazy loading issues
          .Where(t => t.PTAFee != null && t.PTAFee.Type == "PTAMembership")
          .ToList();

            // Calculate total amount for Red Cross fees
            decimal totalAmount = ptaMembershipTransactions.Sum(t => t.PTAFee.Amount);

            ViewBag.TotalAmount = totalAmount;
            return View(ptaMembershipTransactions);
        }

        // GET: PTAMemberships/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.PTAMemberships == null)
        //    {
        //        return NotFound();
        //    }

        //    var pTAMembership = await _context.PTAMemberships
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (pTAMembership == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pTAMembership);
        //}

        //// GET: PTAMemberships/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: PTAMemberships/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] PTAMembership pTAMembership)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(pTAMembership);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(pTAMembership);
        //}

        //// GET: PTAMemberships/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.PTAMemberships == null)
        //    {
        //        return NotFound();
        //    }

        //    var pTAMembership = await _context.PTAMemberships.FindAsync(id);
        //    if (pTAMembership == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(pTAMembership);
        //}

        //// POST: PTAMemberships/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PTAMembership pTAMembership)
        //{
        //    if (id != pTAMembership.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(pTAMembership);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PTAMembershipExists(pTAMembership.Id))
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
        //    return View(pTAMembership);
        //}

        //// GET: PTAMemberships/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.PTAMemberships == null)
        //    {
        //        return NotFound();
        //    }

        //    var pTAMembership = await _context.PTAMemberships
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (pTAMembership == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pTAMembership);
        //}

        //// POST: PTAMemberships/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.PTAMemberships == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.PTAMemberships'  is null.");
        //    }
        //    var pTAMembership = await _context.PTAMemberships.FindAsync(id);
        //    if (pTAMembership != null)
        //    {
        //        _context.PTAMemberships.Remove(pTAMembership);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PTAMembershipExists(int id)
        //{
        //  return (_context.PTAMemberships?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
