using MediTrack.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediTrack.Controllers
{
    public class ExpiryController : Controller
    {
        private readonly MediTrackContext _context;

        public ExpiryController(MediTrackContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var today = DateTime.Today;
            var limitDate = today.AddDays(30);

            var medicines = await _context.Medicines
                .Where(m => m.ExpiryDate.HasValue &&
                            m.ExpiryDate.Value <= limitDate)
                .OrderBy(m => m.ExpiryDate)
                .ToListAsync();

            return View("~/Views/Expiry/Index.cshtml", medicines);
        }
    }
}