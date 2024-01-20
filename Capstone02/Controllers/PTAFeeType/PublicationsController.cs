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
    public class PublicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Publications
        public IActionResult Index()
        {
            var publicationTransactions = _context.Transactions
            .Include(t => t.PTAFee)  // Include PTAFee to avoid lazy loading issues
            .Where(t => t.PTAFee != null && t.PTAFee.Type == "Publication")
            .ToList();

            // Calculate total amount for Red Cross fees
            decimal totalAmount = publicationTransactions.Sum(t => t.PTAFee.Amount);

            ViewBag.TotalAmount = totalAmount;
            return View(publicationTransactions);
        }


        //// GET: Publications/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Publications == null)
        //    {
        //        return NotFound();
        //    }

        //    var publication = await _context.Publications
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (publication == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(publication);
        //}

        //// GET: Publications/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Publications/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] Publication publication)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(publication);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(publication);
        //}

        //// GET: Publications/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Publications == null)
        //    {
        //        return NotFound();
        //    }

        //    var publication = await _context.Publications.FindAsync(id);
        //    if (publication == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(publication);
        //}

        //// POST: Publications/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Publication publication)
        //{
        //    if (id != publication.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(publication);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PublicationExists(publication.Id))
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
        //    return View(publication);
        //}

        //// GET: Publications/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Publications == null)
        //    {
        //        return NotFound();
        //    }

        //    var publication = await _context.Publications
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (publication == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(publication);
        //}

        //// POST: Publications/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Publications == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Publications'  is null.");
        //    }
        //    var publication = await _context.Publications.FindAsync(id);
        //    if (publication != null)
        //    {
        //        _context.Publications.Remove(publication);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PublicationExists(int id)
        //{
        //  return (_context.Publications?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
