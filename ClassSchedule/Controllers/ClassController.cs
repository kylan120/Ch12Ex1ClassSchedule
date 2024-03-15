using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;
using ClassSchedule.Models.DataLayer;

namespace ClassSchedule.Controllers
{
    public class ClassController : Controller
    {
        private ClassScheduleUnitOfWork data {  get; set; }
        public ClassController(ClassScheduleUnitOfWork ctx) => 
            data = ctx;
        private Repository<Class> classes { get; set; }
        private Repository<Teacher> teachers { get; set; }
        private Repository<Day> days { get; set; }

        public ClassController(ClassScheduleContext ctx)
        {
            classes = new Repository<Class>(ctx);
            teachers = new Repository<Teacher>(ctx);
            days = new Repository<Day>(ctx);
        }

        public RedirectToActionResult Index() => RedirectToAction("Index", "Home");

        [HttpGet]
        public ViewResult Add()
        {
            this.LoadViewBag("Add");
            return View();
        }
        

        [HttpGet]
        public ViewResult Edit(int id)
        {
            this.LoadViewBag("Edit");
            var c = this.GetClass(id);
            return View("Add", c);
        }

        [HttpPost]
        public IActionResult Add(Class c)
        {
            if (ModelState.IsValid) {
                if (c.ClassId == 0)
                    classes.Insert(c);
                else
                    classes.Update(c);
                classes.Save();
                return RedirectToAction("Index", "Home");
            }
            else {
                string operation = (c.ClassId == 0) ? "Add" : "Edit";
                this.LoadViewBag(operation);
                return View();
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var c = this.GetClass(id);
            return View(c);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Class c)
        {
            classes.Delete(c);
            classes.Save();
            return RedirectToAction("Index", "Home");
        }

        // private helper methods
        private Class GetClass(int id)
        {
            var classOptions = new QueryOptions<Class>
            {
                Includes = "Teacher, Day",
                Where = c => c.ClassId == id
            };
            return data.Class.Get(classOptions);
        }
        private void LoadViewBag(string operation)
        {
            ViewBag.Days = days.List(new QueryOptions<Day> {
                OrderBy = d => d.DayId
            });
            ViewBag.Teachers = teachers.List(new QueryOptions<Teacher> {
                OrderBy = t => t.LastName
            });
            ViewBag.Operation = operation;
        }
    }
}