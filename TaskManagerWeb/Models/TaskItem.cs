namespace TaskManagerWeb.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Priority Priority { get; set; }

        public string DueDate { get; set; }

        public bool Completed { get; set; }
    }
}