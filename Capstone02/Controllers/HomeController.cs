using Capstone02.Data;
using Capstone02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Capstone02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult>Index()
        {
            var applicationDbContext = _context.Transactions.Include(t => t.Employee).Include(t => t.PTAFee).Include(t => t.Parent);

            var orderedTransactions = applicationDbContext
                .OrderByDescending(t => t.TransactionDate);

            ViewBag.OverallNumberOfStudentsPaid = await applicationDbContext
                .Where(t => t.TransactionDate.Year == DateTime.Now.Year)
                .Select(t => t.ParentId)
                .Distinct()
                .CountAsync();

            ViewBag.OverallTotalPaidPTAFees = await applicationDbContext
                .Where(t => t.TransactionDate.Year == DateTime.Now.Year)
                .SumAsync(t => t.PTAFee.Amount);

            var todayTransactions = await applicationDbContext
                .Where(t => t.TransactionDate.Date == DateTime.Today)
                .ToListAsync();

            decimal totalAmountToday = todayTransactions.Sum(t => t.PTAFee.Amount);

            decimal overallTotalAmount = await applicationDbContext
                .SumAsync(t => t.PTAFee.Amount);

            ViewBag.TotalStudentsToday = todayTransactions.Count();
            ViewBag.TotalAmountToday = totalAmountToday;

            ViewBag.OverallTotalAmount = overallTotalAmount;

            return View(await orderedTransactions.ToListAsync());

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
