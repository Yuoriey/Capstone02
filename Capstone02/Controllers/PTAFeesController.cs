using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone02.Data;
using Capstone02.Models;

namespace Capstone02.Controllers
{
    public class PTAFeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PTAFeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PTAFees
        public async Task<IActionResult> Index()
        {
            var pTAFeeDBContext = _context.PTAFees.Include(p => p.Employee).Include(p => p.Student);
            return View(await pTAFeeDBContext.ToListAsync());
        }

        // GET: PTAFees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pTAFee = await _context.PTAFees
                .Include(p => p.Employee)
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pTAFee == null)
            {
                return NotFound();
            }

            return View(pTAFee);
        }

        // GET: PTAFees/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Type");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Year");
            return View();
        }

        // POST: PTAFees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Amount,Date,SchoolYear,ReferenceNumber,EmployeeId,StudentId")] PTAFee pTAFee)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(pTAFee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Type", pTAFee.EmployeeId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Year", pTAFee.StudentId);
            return View(pTAFee);
        }

        // GET: PTAFees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pTAFee = await _context.PTAFees.FindAsync(id);
            if (pTAFee == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Type", pTAFee.EmployeeId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Year", pTAFee.StudentId);
            return View(pTAFee);
        }

        // POST: PTAFees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Amount,Date,SchoolYear,ReferenceNumber,EmployeeId,StudentId")] PTAFee pTAFee)
        {
            if (id != pTAFee.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pTAFee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PTAFeeExists(pTAFee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Type", pTAFee.EmployeeId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Year", pTAFee.StudentId);
            return View(pTAFee);
        }

        // GET: PTAFees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pTAFee = await _context.PTAFees
                .Include(p => p.Employee)
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pTAFee == null)
            {
                return NotFound();
            }

            return View(pTAFee);
        }

        // POST: PTAFees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pTAFee = await _context.PTAFees.FindAsync(id);
            if (pTAFee != null)
            {
                _context.PTAFees.Remove(pTAFee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PTAFeeExists(int id)
        {
            return _context.PTAFees.Any(e => e.Id == id);
        }
    }
}
