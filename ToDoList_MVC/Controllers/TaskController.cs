using Microsoft.AspNetCore.Mvc;
using ToDoList_MVC.Data;
using ToDoList_MVC.Models;

namespace ToDoList_MVC.Controllers
{
    public class TaskController : Controller
    {

        private readonly ApplicationDbContext _db;

        public TaskController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<tblTask> objTaskList = _db.tblTasks;

            return View(objTaskList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(tblTask obj)
        {
            if (ModelState.IsValid)
            {
                _db.tblTasks.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);

        }
    }
}
