using DAL.Models;

namespace ToDoList.Models
{
    public class IndexViewModel
    {
        public TodoTask CreateModel { get; set; }

        public List<TodoTask> ListModel { get; set; }
    }
}
