using Microsoft.AspNetCore.Mvc;
using ustaVideosB.Data;
using ustaVideosB.Models;
using X.PagedList;

namespace ustaVideosB.Controllers
{
    public class ActorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ActorController(ApplicationDbContext context)        {
            _context = context;
        }
        public IActionResult Index(string sortOn, string orderBy, string pSortOn, int? page) {
            int recordsPerPage = 2;
            if (!page.HasValue) {
                page = 1;
                orderBy = string.IsNullOrWhiteSpace(orderBy) || orderBy.Equals("asc") ? "desc" : "asc";
            } if (!string.IsNullOrWhiteSpace(sortOn) && !sortOn.Equals(pSortOn, StringComparison.CurrentCultureIgnoreCase)){
                orderBy = "asc";
            }

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOn = sortOn;
            var data = _context.Actor.AsQueryable();
            switch (sortOn) {
                case "FullName":
                    data = orderBy.Equals("asc") ? data.OrderBy(i => i.FullName) : data.OrderByDescending(i => i.FullName);
                    break;
                case "Bio":
                    data = orderBy.Equals("asc") ? data.OrderBy(i => i.Bio) : data.OrderByDescending(i => i.Bio);
                    break;
                default:
                    data = data.OrderBy(i => i.Id);
                    break;
            }

            ViewBag.actors = data.ToPagedList(page.Value, recordsPerPage);
            return View(data);
        }

        public IActionResult Details(int id)        {
            var data = _context.Actor.FirstOrDefault(a => a.Id == id);
            if (data == null){
                return View("NotFound");
            }
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

        //[HttpPost, ActionName("Create")]
        public IActionResult Create(){
            return View();
        }
        
        [HttpPost]
        public IActionResult Create([Bind("FullName, Bio, ProfilePictureURL")] Actor data){
            if(!ModelState.IsValid){
                return View(data);
            }

            _context.Actor.Add(data);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        
    }
}