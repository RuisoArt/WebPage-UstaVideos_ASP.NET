using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ustaVideosA.Data;

namespace ustaVideosA.Controllers{
    public class DirectorController : Controller{
        private readonly ApplicationDbContext _context;
        public DirectorController(ApplicationDbContext context){
            _context = context;
        }
        public async Task<IActionResult> Index(){
            var allDirectors = await _context.Director.ToListAsync();
            return View(allDirectors);
        }
    }
}