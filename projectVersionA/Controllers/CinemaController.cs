using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ustaVideosA.Data;

namespace ustaVideosA.Controllers{
    public class CinemaController : Controller{
        private readonly ApplicationDbContext _context;
        public CinemaController(ApplicationDbContext context){
            _context = context;
        }
        public async Task<IActionResult> Index(){
            var allCinemas = await _context.Cinema.ToListAsync();
            return View(allCinemas);
        }
    }
}