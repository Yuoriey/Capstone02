using Capstone02.Data;
using Capstone02.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Capstone02.Controllers
{
    public class ParentUIController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ParentUIController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            // Get the currently signed-in user
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                var emailAddress = currentUser.Email;
                var Parents = await _context.Parents.Include(m => m.Student).FirstOrDefaultAsync(m => m.EmailAddress == emailAddress);
                if (Parents != null)
                {
                    ViewBag.Parent = Parents;

                    ////FOR TOTAL BALANCE
                    //int TotalAmount = await _context.PTAFees
                    //    .Where(p => p.Type != null) // Optional: Exclude entries with null types
                    //    .SumAsync(p => p.Amount);
                    var ptaFeesList = await _context.PTAFees.ToListAsync();
                    ViewBag.PTAFeesList = ptaFeesList;
                    ViewBag.TotalAmount = Parents.Balance;

                }
                else
                {

                }
            }
            return View();
        }


        [HttpPost]  
        public async Task<IActionResult> Create([Bind("Id,Type,Amount")] PTAFee pTAFee, string[] SelectedFees, IFormFile ProfileImage)
        {
            // Your logic for handling the form submission
            // 'pTAFee' will contain the data for the newly created fee
            // 'SelectedFees' will contain an array of selected fee types

            // Your logic for processing selected fees
            // For example, you might want to mark them as paid

            // Handle the image upload
            if (ProfileImage != null && ProfileImage.Length > 0)
            {
                // Logic to save the image, for example:
                // var imagePath = Path.Combine("wwwroot/images", ProfileImage.FileName);
                // using (var stream = new FileStream(imagePath, FileMode.Create))
                // {
                //     await ProfileImage.CopyToAsync(stream);
                // }

                // Update your 'pTAFee' object with the image path or any relevant information
                // pTAFee.ImagePath = imagePath;
            }

            _context.Add(pTAFee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult RedirectToParentUI()
        {
            return RedirectToAction("Index", "ParentUI");
        }
    }
}
