using Capstone02.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone02.Controllers
{
    public class ParentUIController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParentUIController(ApplicationDbContext context)
        {
            _context = context;
        }

        public  IActionResult Index()
        {
            return View();
        }

        public IActionResult Index1()
        {
            return View();
        }
        public IActionResult RedirectToParentUI()
        {
            return RedirectToAction("Index", "ParentUI");
        }
    }
}
