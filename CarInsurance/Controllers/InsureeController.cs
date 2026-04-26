using CarInsurance.Data;
using CarInsurance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarInsurance.Controllers
{
    // Controller for Insuree pages
    public class InsureeController : Controller
    {
        // Database context
        private readonly InsuranceContext _context;

        // Constructor gets database context
        public InsureeController(InsuranceContext context)
        {
            _context = context;
        }

        // Shows all insurees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Insurees.ToListAsync());
        }

        // Shows create form
        public IActionResult Create()
        {
            return View();
        }

        // Saves new insuree
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                insuree.Quote = CalculateQuote(insuree);

                _context.Add(insuree);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(insuree);
        }

        // Shows details for one insuree
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees
                .FirstOrDefaultAsync(m => m.Id == id);

            if (insuree == null)
            {
                return NotFound();
            }

            return View(insuree);
        }

        // Shows edit form
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees.FindAsync(id);

            if (insuree == null)
            {
                return NotFound();
            }

            return View(insuree);
        }

        // Saves edited insuree
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Insuree insuree)
        {
            if (id != insuree.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                insuree.Quote = CalculateQuote(insuree);

                _context.Update(insuree);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(insuree);
        }

        // Shows delete confirmation
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees
                .FirstOrDefaultAsync(m => m.Id == id);

            if (insuree == null)
            {
                return NotFound();
            }

            return View(insuree);
        }

        // Deletes insuree
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insuree = await _context.Insurees.FindAsync(id);

            if (insuree != null)
            {
                _context.Insurees.Remove(insuree);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Admin page showing issued quotes
        public async Task<IActionResult> Admin()
        {
            return View(await _context.Insurees.ToListAsync());
        }

        // Calculates insurance quote
        private decimal CalculateQuote(Insuree insuree)
        {
            decimal quote = 50;

            int age = DateTime.Today.Year - insuree.DateOfBirth.Year;

            if (insuree.DateOfBirth.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            if (age <= 18)
            {
                quote += 100;
            }
            else if (age >= 19 && age <= 25)
            {
                quote += 50;
            }
            else
            {
                quote += 25;
            }

            if (insuree.CarYear < 2000)
            {
                quote += 25;
            }

            if (insuree.CarYear > 2015)
            {
                quote += 25;
            }

            if (insuree.CarMake.ToLower() == "porsche")
            {
                quote += 25;
            }

            if (insuree.CarMake.ToLower() == "porsche" &&
                insuree.CarModel.ToLower() == "911 carrera")
            {
                quote += 25;
            }

            quote += insuree.SpeedingTickets * 10;

            if (insuree.DUI)
            {
                quote *= 1.25m;
            }

            if (insuree.FullCoverage)
            {
                quote *= 1.50m;
            }

            return quote;
        }
    }
}