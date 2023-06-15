using Microsoft.AspNetCore.Mvc;
using ustaVideosA.Data;
using ustaVideosA.Models;

namespace ustaVideosA.Controllers
{
    public class ActorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ActorController(ApplicationDbContext context)        {
            _context = context;
        }
        public IActionResult Index()        {
            var allActor = _context.Actor.ToList();
            return View(allActor);
        }

        public IActionResult Details(int id)        {
            var data = _context.Actor.FirstOrDefault(a => a.Id == id);
            return View(data);
        }
        public IActionResult Edit(int id){
            var data = _context.Actor.FirstOrDefault(a => a.Id == id);
            if (data == null){
                return View("NotFound");
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id, FullName, Bio, ProfilePictureURL")] Actor data){
            if(!ModelState.IsValid){
                return View(data);
            }
            if(id == data.Id){
                _context.Actor.Update(data);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }

        public IActionResult Delete(int id){
            var data = _context.Actor.FirstOrDefault(a => a.Id == id);
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id){
            var data = _context.Actor.FirstOrDefault(a=> a.Id == id);
            if(data == null) return View("NotFound");
            _context.Actor.Remove(data);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
    }
}