using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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

        #region Create
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
        #endregion Create

        #region Edit
        //GET
        public IActionResult Edit(int? id)
        {
            if(id ==null || id == 0)
            {
                return NotFound();
            }

            var taskFromDb = _db.tblTasks.Find(id);

            if (taskFromDb == null)
            {
                return NotFound();
            }
            return View(taskFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(tblTask obj)
        {
            if (ModelState.IsValid)
            {
                _db.tblTasks.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
        #endregion Edit

        #region Delete
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var taskFromDb = _db.tblTasks.Find(id);

            if (taskFromDb == null)
            {
                return NotFound();
            }
            return View(taskFromDb);
        }

        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.tblTasks.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.tblTasks.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion Delete

        #region Update Status
        [HttpPost]
        public IActionResult UpdateStatus(int id, bool status)
        {
            var task = _db.tblTasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            if (task.Status == false)
            {
                task.Status = true;
                _db.SaveChanges();
            }
            else if (task.Status == true)
            {
                task.Status = false;
                _db.SaveChanges();
            }
            //task.Status = !status; // Toggle the status

            //_db.SaveChanges();

            // Redirect to the Index action to refresh the page
            return RedirectToAction("Index");
        }
        #endregion Update Status

        #region Edit PopUp
        //[HttpGet]
        //public IActionResult EditPopUp(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var taskFromDb = _db.tblTasks.Find(id);

        //    if (taskFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return PartialView("_EditTask", taskFromDb);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditPopUp(tblTask obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.tblTasks.Update(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    // Model state is not valid, return the same partial view with validation errors
        //    return PartialView("_EditTask", obj);
        //}
        #endregion EditPopUp
    }
}
