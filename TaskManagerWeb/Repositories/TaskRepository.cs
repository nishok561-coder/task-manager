using TaskManagerWeb.Models;

namespace TaskManagerWeb.Repositories
{
    public class TaskRepository
    {
        private static List<TaskItem> tasks = new();

        public List<TaskItem> GetAll()
        {
            return tasks;
        }

        public void Add(TaskItem task)
        {
            task.Id = tasks.Count + 1;

            tasks.Add(task);
        }

        public void Complete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                task.Completed = true;
            }
        }

        public void Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                tasks.Remove(task);
            }
        }
    }
}