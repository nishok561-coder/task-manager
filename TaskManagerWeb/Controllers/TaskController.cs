using Microsoft.AspNetCore.Mvc;
using TaskManagerWeb.Models;
using TaskManagerWeb.Repositories;

namespace TaskManagerWeb.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskRepository _repo;

        public TaskController(
            TaskRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var tasks = _repo.GetAll();

            return View(tasks);
        }

        [HttpPost]
        public IActionResult Add(TaskItem task)
        {
            _repo.Add(task);

            return RedirectToAction("Index");
        }

        public IActionResult Complete(int id)
        {
            _repo.Complete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _repo.Delete(id);

            return RedirectToAction("Index");
        }
    }
}