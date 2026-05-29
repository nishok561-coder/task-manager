using TaskManagerWeb.Data;
using TaskManagerWeb.Models;

namespace TaskManagerWeb.Repositories
{
    public class TaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public List<TaskItem> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public void Add(TaskItem task)
        {
            _context.Tasks.Add(task);

            _context.SaveChanges();
        }

        public void Complete(int id)
        {
            var task =
                _context.Tasks.FirstOrDefault(
                    t => t.Id == id);

            if(task != null)
            {
                task.Completed = true;

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var task =
                _context.Tasks.FirstOrDefault(
                    t => t.Id == id);

            if(task != null)
            {
                _context.Tasks.Remove(task);

                _context.SaveChanges();
            }
        }
    }
}