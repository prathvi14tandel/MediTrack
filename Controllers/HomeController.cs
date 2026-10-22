
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediTrack.Data;
using MediTrack.Models;

namespace MediTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly MediTrackContext _context;

        public HomeController(MediTrackContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var medicines = await _context.Medicines.ToListAsync();

            ViewBag.TotalMedicines = medicines.Count;
            ViewBag.InStock = medicines.Count(m => m.Quantity > 0);
            ViewBag.LowStock = medicines.Count(
                m => m.Quantity > 0 && m.Quantity <= 10);

            ViewBag.ExpiryAlerts = medicines.Count(m =>
                m.ExpiryDate.HasValue &&
                m.ExpiryDate.Value.Date <= DateTime.Today.AddDays(30));

            return View();
        }
    }
}
