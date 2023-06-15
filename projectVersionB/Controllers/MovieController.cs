using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ustaVideosB.Data;

namespace ustaVideosB.Controllers{
    public class MovieController : Controller{
        private readonly ApplicationDbContext _context;
        public MovieController(ApplicationDbContext context){
            _context = context;
        }
        public async Task <IActionResult> Index(){
            var allMovies = await _context.Movie.ToListAsync();
            return View(allMovies);
        }
    }
}