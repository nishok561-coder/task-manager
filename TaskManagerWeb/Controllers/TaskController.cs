using Microsoft.AspNetCore.Mvc;
using TaskManagerWeb.Models;
using TaskManagerWeb.Repositories;

namespace TaskManagerWeb.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskRepository repo = new();

        public IActionResult Index()
        {
            var tasks = repo.GetAll();

            return View(tasks);
        }

        [HttpPost]
        public IActionResult Add(TaskItem task)
        {
            repo.Add(task);

            return RedirectToAction("Index");
        }

        public IActionResult Complete(int id)
        {
            repo.Complete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            repo.Delete(id);

            return RedirectToAction("Index");
        }
    }
}