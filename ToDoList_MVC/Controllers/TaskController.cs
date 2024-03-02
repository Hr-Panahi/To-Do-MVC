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

        public IActionResult Create()
        {
            return View();
        }
    }
}
